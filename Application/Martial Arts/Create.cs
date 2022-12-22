using Application.Core;
using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.UserAccess;
using Domain;
using Domain.IdentityAuth;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Martial_Arts
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public MartialArt MartialArt { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.MartialArt).SetValidator(new MartialArtValidator());
            }
        }


        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IMartialArtRepository _martialArtRepository;
            private readonly IUserAccessor _userAccessor;
            private readonly UserManager<ApplicationUser> _userManager;

            public Handler(IMartialArtRepository martialArtRepository, IUserAccessor userAccessor, UserManager<ApplicationUser> userManager)
            {
                _martialArtRepository = martialArtRepository;
                _userAccessor = userAccessor;
                _userManager = userManager;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
                
                var attendee = new MartialArtAttendee
                {
                    User = user,
                    MartialArt = request.MartialArt,
                    IsCoach = true
                };  

                 request.MartialArt.Attendees.Add(attendee);

                if (await _martialArtRepository.Exists(request.MartialArt))
                {
                    return Result<Unit>.Failure($"{request.MartialArt.Name} is not created");
                }

                await _martialArtRepository.CreateAsync(request.MartialArt);
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
