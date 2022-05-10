using Application.Core;
using Application.DTO;
using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Posts
{
    public class Create 
    {
        public record Command(PostDTO PostDTO) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly IPostRepository _repository;

            public Handler(IPostRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _repository.Exists(request.PostDTO))
                {
                    return new Result<bool> { IsSuccess = false, Error = "Schedule allready exists!" };
                }

                var result = await _repository.PostAsync(request.PostDTO);
                return new Result<bool> { IsSuccess = true, Value = result };
            }
        }
    }
}
