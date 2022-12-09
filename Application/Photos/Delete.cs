using Application.Core;
using Application.Interfaces;
using Application.Interfaces.PhotoAccess;
using Application.Interfaces.UserAccess;
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

namespace Application.Photos
{
    public class Delete
    {
        public record Command(string Id) : IRequest<Result<Unit>>;

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IPhotoAccessor _photoAccessor;
            private readonly IUserAccessor _userAccessor;
            private readonly UserManager<ApplicationUser> _userManager;

            public Handler(IPhotoAccessor photoAccessor, IUserAccessor userAccessor, UserManager<ApplicationUser> userManager)
            {
                _photoAccessor = photoAccessor;
                _userAccessor = userAccessor;
                _userManager = userManager;
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

                if (photo.IsMain)
                {
                    return Result<Unit>.Failure("You cannot delete your main photo");
                }

                var result = await _photoAccessor.DeletePhoto(request.Id);

                if (result == null) 
                {
                    return Result<Unit>.Failure("Problem deleting photo from Cloudinary");
                }

                user.Photos.Remove(photo);
                var success = await _userManager.UpdateAsync(user);

                if (success.Succeeded)
                {
                    return Result<Unit>.Success(Unit.Value);
                }

                return Result<Unit>.Failure("Problem deleting photo from API");

            }
        }
    }
}
