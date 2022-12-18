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

namespace Application.Followers
{
    public class FollowToggle
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string TargetUsername { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUserFollowingRepository _userFollowing;
            private readonly IUserAccessor _userAccessor;
            private readonly UserManager<ApplicationUser> _userManager;

            public Handler(IUserFollowingRepository userFollowing, IUserAccessor userAccessor, UserManager<ApplicationUser> userManager)
            {
                _userFollowing = userFollowing;
                _userAccessor = userAccessor;
                _userManager = userManager;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var observer = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

                var target = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == request.TargetUsername);

                if (target == null)
                {
                    return null;
                }

                var following = await _userFollowing.FindFollowing(observer.Id, target.Id);

               return await _userFollowing.FollowToggle(following, observer, target);                
            }
        }
    }
}
