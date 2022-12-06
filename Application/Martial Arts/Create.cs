﻿using Application.Core;
using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.UserAccess;
using Domain;
using Domain.IdentityAuth;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Martial_Arts
{
    public class Create
    {
        public record Command(MartialArtDTO MartialArt) : IRequest<Result<Unit>>;

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


                var martialArt = new MartialArt
                {
                    Id = request.MartialArt.Id,
                    Name = request.MartialArt.Name,
                    LongDescription = request.MartialArt.LongDescription,
                    ShortDescription = request.MartialArt.ShortDescription,
                    Attendees = request.MartialArt.Attendees
                };

                var attendee = new MartialArtAttendee
                {
                    User = user,
                    MartialArt = martialArt,
                    IsCoach = true
                };

                 request.MartialArt.Attendees.Add(attendee);

                if (await _martialArtRepository.Exists(request.MartialArt))
                {
                    return Result<Unit>.Failure($"{request.MartialArt.Name} is not created");
                }

                await _martialArtRepository.PostAsync(request.MartialArt);
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
