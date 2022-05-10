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

namespace Application.Clients
{
    public class Search
    {
        public record Query(string UserName) : IRequest<Result<ClientDTO>>;

        public class Handler : IRequestHandler<Query, Result<ClientDTO>>
        {
            private readonly IClientRepository _clientRepository;

            public Handler(IClientRepository clientRepository)
            {
                _clientRepository = clientRepository;
            }
            public async Task<Result<ClientDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _clientRepository.FindAsync<ClientDTO>(x => x.UserName == request.UserName);
                if (result != null)
                {
                    return new Result<ClientDTO> { IsSuccess = true, Value = result };
                }

                return new Result<ClientDTO> { IsSuccess = false, Error = "Client not found!" };
            }
        }
    }
}
