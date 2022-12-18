using Application.Core;
using Application.Interfaces;
using Application.Interfaces.UserAccess;
using Application.Profiles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Followers
{
    public class List
    {
        public class Query : IRequest<Result<List<Profiles.Profile>>>
        {
            public string Predicate { get; set; }
            public string Username { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<Profiles.Profile>>>
        {
            private readonly IUserFollowingRepository _userFollowingRepository;

            public Handler(IUserFollowingRepository userFollowingRepository)
            {
                _userFollowingRepository = userFollowingRepository;
            }
            public async Task<Result<List<Profile>>> Handle(Query request, CancellationToken cancellationToken)
            {

                switch (request.Predicate)
                {
                    case "followers":
                        var followers = await _userFollowingRepository.Followers(request.Username);
                        return followers;
                    case "following":
                        var followings = await _userFollowingRepository.Followings(request.Username);
                        return followings;
                    default:
                        return null;
                }
            }
        }
    }
}
