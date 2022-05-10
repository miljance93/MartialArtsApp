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

namespace Application.Schedules
{
    public class Create
    {
        public record Command(ScheduleDTO ScheduleDTO): IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly IScheduleRepository _repository;

            public Handler(IScheduleRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _repository.Exists(request.ScheduleDTO))
                {
                    return new Result<bool> { IsSuccess = false, Error = "Schedule allready exists!" };
                }

                var result = await _repository.PostAsync(request.ScheduleDTO);
                return new Result<bool> { IsSuccess = true, Value = result };
            }
        }
    }
}
