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

namespace Application.Comments
{
    public class List
    {
        public class Query : IRequest<Result<List<CommentDTO>>>
        {
            public int MartialArtId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<CommentDTO>>>
        {
            private readonly ICommentRepository _commentRepository;

            public Handler(ICommentRepository commentRepository)
            {
                _commentRepository = commentRepository;
            }
            public async Task<Result<List<CommentDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var comments = await _commentRepository.GetAllAsync<CommentDTO>();
                comments.Where(x => x.MartialArtId == request.MartialArtId).OrderBy(x => x.CreatedAt);

                return new Result<List<CommentDTO>> { IsSuccess = true, Value = comments.ToList() };
            }
        }
    }
}
