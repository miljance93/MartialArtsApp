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

namespace Application.Coaches
{
    public class List
    {
        public record Query : IRequest<Result<List<CoachDTO>>>;

        public class Handler : IRequestHandler<Query, Result<List<CoachDTO>>>
        {
            private readonly ICoachRepository repository;

            public Handler(ICoachRepository repository)
            {
                this.repository = repository;
            }
            public async Task<Result<List<CoachDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await repository.GetAllAsync<CoachDTO>();
                if (result != null)
                {
                    return new Result<List<CoachDTO>> { IsSuccess = true, Value = result.ToList() };
                }

                return new Result<List<CoachDTO>> { IsSuccess = false, Error = "List of coaches not found!" };
            }
        }
    }
}
