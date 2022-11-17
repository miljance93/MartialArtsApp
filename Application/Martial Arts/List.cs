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

namespace Application.Martial_Arts
{
    public class List
    {
        public record Query : IRequest<Result<List<MartialArtDTO>>>;

        public class Handler : IRequestHandler<Query, Result<List<MartialArtDTO>>>
        {
            private readonly IMartialArtRepository _martialArtRepository;

            public Handler(IMartialArtRepository martialArtRepository)
            {
                _martialArtRepository = martialArtRepository;
            }

            public async Task<Result<List<MartialArtDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _martialArtRepository.GetAllAsync<MartialArtDTO>();
                if (result != null)
                {
                    return  Result<List<MartialArtDTO>>.Success(result.ToList());
                }

                return Result<List<MartialArtDTO>>.Failure("Couldn't find list of martial arts");
            }
        }
    }
}
