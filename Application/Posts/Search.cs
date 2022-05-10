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
    public class Search
    {
        public record Query(int Id) : IRequest<Result<PostDTO>>;

        public class Handler : IRequestHandler<Query, Result<PostDTO>>
        {
            private readonly IPostRepository _postRepository;

            public Handler(IPostRepository postRepository)
            {
                _postRepository = postRepository;
            }
            public async Task<Result<PostDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _postRepository.FindAsync<PostDTO>(x => x.Id == request.Id);
                if (result != null)
                {
                    return new Result<PostDTO> { IsSuccess = true, Value = result };
                }

                return new Result<PostDTO> { IsSuccess = false, Error = "Post not found!" };
            }
        }
    }
}
