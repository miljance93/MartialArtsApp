using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.IdentityAuth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class Details
    {
        public record Query(string Username) : IRequest<Result<Profile>>;

        public class Handler : IRequestHandler<Query, Result<Profile>>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IMapper _mapper;

            public Handler(UserManager<ApplicationUser> userManager, IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
            }

            public async Task<Result<Profile>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.Users
                    .ProjectTo<Profile>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(x => x.Username == request.Username);

                return Result<Profile>.Success(user);
            }
        }
    }
}
