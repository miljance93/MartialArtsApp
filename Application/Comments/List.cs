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
            public string MartialArtId { get; set; }
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
                var commentsToReturn = comments.Where(x => x.MartialArtId == request.MartialArtId).OrderByDescending(x => x.CreatedAt);

                return Result<List<CommentDTO>>.Success(commentsToReturn.ToList());
            }
        }
    }
}
