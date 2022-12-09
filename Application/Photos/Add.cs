using Application.Core;
using Application.Interfaces;
using Application.Interfaces.PhotoAccess;
using Application.Interfaces.UserAccess;
using Domain;
using Domain.IdentityAuth;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    public class Add
    {
        public class Command : IRequest<Result<Photo>>
        {
            public IFormFile File { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Photo>>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly IPhotoAccessor _photoAccessor;
            private readonly UserManager<ApplicationUser> _userManager;

            public Handler(IUserAccessor userAccessor, IPhotoAccessor photoAccessor, UserManager<ApplicationUser> userManager)
            {
                _userAccessor = userAccessor;
                _photoAccessor = photoAccessor;
                _userManager = userManager;
            }

            public async Task<Result<Photo>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.Users.Include(p => p.Photos).FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

                if (user == null) return null;


                var photoUploadResult = await _photoAccessor.AddPhoto(request.File);

                var photo = new Photo
                {
                    Url = photoUploadResult.Url,
                    Id = photoUploadResult.PublicId,
                };


                if (!user.Photos.Any(x => x.IsMain))
                {
                    photo.IsMain = true;
                }
                user.Photos.Add(photo);
                
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return Result<Photo>.Success(photo);
                }

                return Result<Photo>.Failure("Problem adding photo");
            }
        }
    }
}
