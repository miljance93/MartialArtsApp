using Application.Core;
using Application.DTO;
using Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Clients
{
    public class List
    {
        public record Query : IRequest<Result<List<ClientDTO>>>;

        public class Handler : IRequestHandler<Query, Result<List<ClientDTO>>>
        {
            private readonly IClientRepository repository;

            public Handler(IClientRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result<List<ClientDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await repository.GetAllAsync<ClientDTO>();
                var listOfClients = result.ToList();

                if (listOfClients.Count == 0)
                {
                    return new Result<List<ClientDTO>> { IsSuccess = false, Error = "There is no clients!" };
                }
                return new Result<List<ClientDTO>> { IsSuccess = true, Value = listOfClients };
            }
        }
    }
}
