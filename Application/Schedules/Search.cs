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
    public class Search
    {
        public record Query(int Id) : IRequest<Result<ScheduleDTO>>;

        public class Handler : IRequestHandler<Query, Result<ScheduleDTO>>
        {
            private readonly IScheduleRepository _scheduleRepository;

            public Handler(IScheduleRepository scheduleRepository)
            {
                _scheduleRepository = scheduleRepository;
            }

            public async Task<Result<ScheduleDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _scheduleRepository.FindAsync<ScheduleDTO>(x => x.Id == request.Id);
                if (result != null)
                {
                    return new Result<ScheduleDTO> { IsSuccess = true, Value = result };
                }

                return new Result<ScheduleDTO> { IsSuccess = false, Error = "Schedule not found!" };
            }
        }
    }
}
