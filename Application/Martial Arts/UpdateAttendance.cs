using Application.Core;
using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.UserAccess;
using Domain;
using Domain.IdentityAuth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Martial_Arts
{
    public class UpdateAttendance
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }
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
                var martialArt = await _martialArtRepository.GetMartialArtWithUsers(request.Id);

                if (martialArt == null)
                {
                    return null;
                }

                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

                if (user == null) 
                { 
                    return null; 
                }

                var hostUsername = martialArt.Attendees.FirstOrDefault(x => x.IsCoach)?.User?.UserName;

                var attendance =  martialArt.Attendees.FirstOrDefault(x => x.User.UserName == user.UserName);

                if (attendance != null && hostUsername == user.UserName)
                {
                    martialArt.IsCancelled = !martialArt.IsCancelled;
                }

                if (attendance != null && hostUsername != user.UserName)
                {
                    martialArt.Attendees.Remove(attendance);
                }

                if (attendance == null)
                {
                    attendance = new MartialArtAttendee
                    {
                        User = user,
                        MartialArt = martialArt,
                        IsCoach = false,
                    };

                    martialArt.Attendees.Add(attendance);
                }

                var result = await _martialArtRepository.UpdateAsync(martialArt);

                return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Problem updating attendance");
            }
        }
    }
}
