using Application.DTO;
using Application.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Clients
{
    public class PaginatedList
    {
        public record Query(PagingParameterModel PagingParameterModel) : IRequest<PagedList<ClientDTO>>;

        public class Handler : IRequestHandler<Query, PagedList<ClientDTO>>
        {
            private readonly IClientRepository _clientRepository;

            public Handler(IClientRepository clientRepository)
            {
                _clientRepository = clientRepository;
            }
            public async Task<PagedList<ClientDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _clientRepository.GetClients(request.PagingParameterModel);
                return result;
            }
        }
    }
}
