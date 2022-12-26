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

namespace Application.Profiles
{
    public class ListMartialArts
    {
        public class Query : IRequest<Result<List<UserMartialArtDTO>>>
        {
            public string Username { get; set; }
            public string Predicate { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<UserMartialArtDTO>>>
        {
            private readonly IMartialArtRepository _martialArtRepository;

            public Handler(IMartialArtRepository martialArtRepository)
            {
                _martialArtRepository = martialArtRepository;
            }
            public async Task<Result<List<UserMartialArtDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _martialArtRepository.GetEvents(request.Username, request.Predicate);
                return result;
            }
        }
    }
}
