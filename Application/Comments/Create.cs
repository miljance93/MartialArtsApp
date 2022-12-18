using Application.Core;
using Application.DTO;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using FluentValidation;
using Application.Interfaces.UserAccess;
using Microsoft.AspNetCore.Identity;
using Domain.IdentityAuth;
using Microsoft.EntityFrameworkCore;
using Domain;
using AutoMapper;

namespace Application.Comments
{
    public class Create
    {
        public class Command : IRequest<Result<CommentDTO>>
        {
            public string Body { get; set; }
            public string MartialArtId { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Body).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, Result<CommentDTO>>
        {
            private readonly IMartialArtRepository _martialArtRepository;
            private readonly IUserAccessor _userAccessor;
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IMapper _mapper;

            public Handler(IMartialArtRepository martialArtRepository, 
                IUserAccessor userAccessor, UserManager<ApplicationUser> userManager, IMapper mapper)
            {
                _martialArtRepository = martialArtRepository;
                _userAccessor = userAccessor;
                _userManager = userManager;
                _mapper = mapper;
            }
            public async Task<Result<CommentDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var martialArt = await _martialArtRepository.GetByIdAsync<MartialArt>(x => x.Id == request.MartialArtId);
                if (martialArt == null)
                {
                    return null;
                }

                var user = await _userManager.Users.Include(p => p.Photos).SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

                var comment = new Comment
                {
                    Author = user,
                    MartialArt = martialArt,
                    Body = request.Body
                };


                martialArt.Comments.Add(comment);

                var success = await _martialArtRepository.UpdateAsync(martialArt);
                if (success)
                {
                    return  Result<CommentDTO>.Success(_mapper.Map<CommentDTO>(comment));
                }
                return new Result<CommentDTO> { IsSuccess = false, Error = "Failed to post comment" }; 
            }
        }
    }
}
