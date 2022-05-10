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
    public class Delete
    {
        public record Command(ScheduleDTO Schedule) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly IScheduleRepository _scheduleRepository;

            public Handler(IScheduleRepository scheduleRepository)
            {
                _scheduleRepository = scheduleRepository;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _scheduleRepository.Exists(request.Schedule))
                {
                    var result = await _scheduleRepository.DeleteAsync(request.Schedule);
                    return new Result<bool> { IsSuccess = true, Value = result };
                }

                return new Result<bool> { IsSuccess = false, Error = "Schedule is not deleted!" };
            }
        }
    }
}
