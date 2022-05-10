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
    public class Create
    {
        public record Command(ClientDTO Client) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly IClientRepository _clientRepository;

            public Handler(IClientRepository clientRepository)
            {
                _clientRepository = clientRepository;
            }
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _clientRepository.Exists(request.Client))
                {
                    return new Result<bool> { IsSuccess = false, Error = "Client already exists!" };
                }

                var result = await _clientRepository.PostAsync(request.Client);
                return new Result<bool> { IsSuccess = true, Value = result };
            }
        }
    }
}
