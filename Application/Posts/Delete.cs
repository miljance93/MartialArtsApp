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

namespace Application.Posts
{
    public class Delete
    {
        public record Command(PostDTO Post) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly IPostRepository _postRepository;

            public Handler(IPostRepository postRepository)
            {
                _postRepository = postRepository;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _postRepository.Exists(request.Post))
                {
                    var result = await _postRepository.DeleteAsync(request.Post);
                    return new Result<bool> { IsSuccess = true, Value = result };
                }

                return new Result<bool> { IsSuccess = false, Error = "Post is not deleted" };
            }
        }
    }
}
