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
    public class List
    {
        public record Query : IRequest<Result<List<PostDTO>>>;

        public class Handler : IRequestHandler<Query, Result<List<PostDTO>>>
        {
            private readonly IPostRepository _postRepository;

            public Handler(IPostRepository postRepository)
            {
                _postRepository = postRepository;
            }
            public async Task<Result<List<PostDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _postRepository.GetAllAsync<PostDTO>();
                if (result != null)
                {
                    return new Result<List<PostDTO>> { IsSuccess = true, Value = result.ToList() };
                }

                return new Result<List<PostDTO>> { IsSuccess = false, Error = "Posts not found!" };
            }
        }
    }
}
