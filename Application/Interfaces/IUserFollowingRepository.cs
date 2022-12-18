using Application.Clients;
using Application.Core;
using Domain;
using Domain.IdentityAuth;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserFollowingRepository : IRepository<UserFollowing>
    {
        Task<UserFollowing> FindFollowing(params object[] objects);
        Task<Result<Unit>> FollowToggle(UserFollowing userFollowing, ApplicationUser observer, ApplicationUser target);
        Task<Result<List<Profiles.Profile>>> Followers(string username);
        Task<Result<List<Profiles.Profile>>> Followings(string username);
    }
}
