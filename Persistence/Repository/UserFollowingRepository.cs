using Application.Core;
using Application.Interfaces;
using Application.Interfaces.UserAccess;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Domain.IdentityAuth;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class UserFollowingRepository : Repository<UserFollowing>, IUserFollowingRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public UserFollowingRepository(ApplicationDbContext context, IMapper mapper, IUserAccessor userAccessor) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<UserFollowing> FindFollowing(params object[] expression)
        {
            var following = await _context.UserFollowings.FindAsync(expression);

            return following;
        }

        public async Task<Result<List<Application.Profiles.Profile>>> Followers(string username)
        {
            var profiles = await _context.UserFollowings.Where(x => x.Target.UserName == username)
                 .Select(u => u.Observer)
                 .ProjectTo<Application.Profiles.Profile>(_mapper.ConfigurationProvider, new { currentUsername = _userAccessor.GetUsername()})
                 .ToListAsync();

            return Result<List<Application.Profiles.Profile>>.Success(profiles);
        }

        public async Task<Result<List<Application.Profiles.Profile>>> Followings(string username)
        {
            var profiles = await _context.UserFollowings.Where(x => x.Observer.UserName == username)
                 .Select(u => u.Target)
                 .ProjectTo<Application.Profiles.Profile>(_mapper.ConfigurationProvider, new { currentUsername = _userAccessor.GetUsername() })
                 .ToListAsync();

            return Result<List<Application.Profiles.Profile>>.Success(profiles);
        }

        public async Task<Result<Unit>> FollowToggle(UserFollowing userFollowing, ApplicationUser observer, ApplicationUser target)
        {
            if (userFollowing == null)
            {

                userFollowing = new UserFollowing
                {
                    Observer = observer,
                    Target = target,
                };

                _context.UserFollowings.Add(userFollowing);
            }
            else
            {
                _context.UserFollowings.Remove(userFollowing);
            }

            var success = await _context.SaveChangesAsync() > 0;
            if (success)
            {
                return Result<Unit>.Success(Unit.Value);
            }
            return Result<Unit>.Failure("Failed to update following");
        }
    }
}
