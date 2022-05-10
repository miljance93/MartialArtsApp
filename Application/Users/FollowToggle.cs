using Application.Core;
using Application.DTO;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users
{
    public class FollowToggle 
    {
        public record Command(UserFollowingDTO UserFollowing) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly IUserFollowingRepository _userFollowing;

            public Handler(IUserFollowingRepository userFollowing)
            {
                _userFollowing = userFollowing;
            }
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _userFollowing.Exists(request.UserFollowing))
                {
                    return new Result<bool> { IsSuccess = false, Error = "Follow alredy exists!" };
                }

                var result = await _userFollowing.PostAsync(request.UserFollowing);
                return new Result<bool> { IsSuccess = true, Value = result };
            }
        }
    }
}
