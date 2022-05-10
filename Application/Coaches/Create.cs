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
    public class Create
    {
        public record Command(CoachDTO CoachDTO) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly ICoachRepository repository;

            public Handler(ICoachRepository repository)
            {
                this.repository = repository;
            }
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await repository.Exists(request.CoachDTO))
                {
                    return new Result<bool> { IsSuccess = false, Error = "Coach allready exists!" };
                }
                var result = await repository.PostAsync(request.CoachDTO);
                return new Result<bool> { IsSuccess = true, Value = result };
            }
        }
    }
}
