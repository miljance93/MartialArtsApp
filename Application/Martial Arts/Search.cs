using Application.Core;
using Application.DTO;
using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Martial_Arts
{
    public class Search
    {
        public record Query(string Id) : IRequest<Result<MartialArtDTO>>;

        public class Handler : IRequestHandler<Query, Result<MartialArtDTO>>
        {
            private readonly IMartialArtRepository _martialArtRepository;

            public Handler(IMartialArtRepository martialArtRepository)
            {
                _martialArtRepository = martialArtRepository;
            }

            public async Task<Result<MartialArtDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _martialArtRepository.FindAsync<MartialArtDTO>(x => x.Id == request.Id);
                if (result != null)
                {
                    return new Result<MartialArtDTO> { IsSuccess = true, Value = result };
                }

                return new Result<MartialArtDTO> { IsSuccess = false, Error = "No martial art found!" };
            }
        }
    }
}
