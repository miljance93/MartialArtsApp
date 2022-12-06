using Application.Core;
using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
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
            private readonly IMapper _mapper;

            public Handler(IMartialArtRepository martialArtRepository, IMapper mapper)
            {
                _martialArtRepository = martialArtRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<MartialArtDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _martialArtRepository.GetMartialArtsWithUsers(cancellationToken);
                
                if (result != null)
                {
                    return  Result<List<MartialArtDTO>>.Success(_mapper.Map<List<MartialArtDTO>>(result.ToList()));;
                }

                return Result<List<MartialArtDTO>>.Failure("Couldn't find list of martial arts");
            }
        }
    }
}
