using Application.Core;
using Application.Interfaces.UserAccess;
using Domain.IdentityAuth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Photos
{
    public class SetMain
    {
        public record Command(string Id) : IRequest<Result<Unit>>;

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IUserAccessor _userAccessor;

            public Handler(UserManager<ApplicationUser> userManager, IUserAccessor userAccessor)
            {
                _userManager = userManager;
                _userAccessor = userAccessor;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.Users.Include(p => p.Photos).FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

                if (user == null)
                {
                    return null;
                }

                var photo = user.Photos.FirstOrDefault(x => x.Id == request.Id);

                if (photo == null)
                {
                    return null;
                }

                var currentMain = user.Photos.FirstOrDefault(x => x.IsMain);

                if (currentMain != null) 
                {
                    currentMain.IsMain = false;
                }

                photo.IsMain = true;

                var success = await _userManager.UpdateAsync(user);

                if (success.Succeeded)
                {
                    return Result<Unit>.Success(Unit.Value);
                }

                return Result<Unit>.Failure("Failed to set main photo");
            }
        }
    }
}
