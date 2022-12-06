using Application.Core;
using Application.DTO;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Comments
{
    public class Create
    {
        public record Command(string Body, string MartialArtId) : IRequest<Result<CommentDTO>>;

        public class Handler : IRequestHandler<Command, Result<CommentDTO>>
        {
            private readonly ICommentRepository _commentRepository;
            private readonly IMartialArtRepository _martialArtRepository;
            private readonly ICoachRepository _coachRepository;

            public Handler(ICommentRepository commentRepository, IMartialArtRepository martialArtRepository, ICoachRepository coachRepository)
            {
                _commentRepository = commentRepository;
                _martialArtRepository = martialArtRepository;
                _coachRepository = coachRepository;
            }
            public async Task<Result<CommentDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var martialArt = await _martialArtRepository.GetByIdAsync<MartialArtDTO>(x => x.Id == request.MartialArtId);
                if (martialArt == null)
                {
                    return null;
                }

              //  var coach = await _coachRepository.GetByIdAsync<CoachDTO>(x => x.Id == martialArt.CoachId);

                var comment = new CommentDTO
                {
                    //Username = coach.UserName,
                    Body = request.Body
                };

                var success = await _commentRepository.PostAsync(comment);
                if (success)
                {
                    return new Result<CommentDTO> { IsSuccess = true, Value = comment };
                }
                return new Result<CommentDTO> { IsSuccess = false, Error = "Failed to post comment" }; // Next 213
            }
        }
    }
}
