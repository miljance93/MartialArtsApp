using Application.Core;
using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Martial_Arts
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<MartialArtDTO>>>
        {
            public MartialArtParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<MartialArtDTO>>>
        {
            private readonly IMartialArtRepository _martialArtRepository;
            private readonly IMapper _mapper;

            public Handler(IMartialArtRepository martialArtRepository, IMapper mapper)
            {
                _martialArtRepository = martialArtRepository;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<MartialArtDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var martialArts = await _martialArtRepository.GetMartialArtsWithUsers(cancellationToken, request.Params.PageNumber, request.Params.PageSize, request.Params);

                return Result<PagedList<MartialArtDTO>>.Success(martialArts);
            }
        }
    }
}
