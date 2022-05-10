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
    public class List
    {
        public record Query : IRequest<Result<List<ScheduleDTO>>>;

        public class Handler : IRequestHandler<Query, Result<List<ScheduleDTO>>>
        {
            private readonly IScheduleRepository _scheduleRepository;

            public Handler(IScheduleRepository scheduleRepository)
            {
                _scheduleRepository = scheduleRepository;
            } 

            public async Task<Result<List<ScheduleDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _scheduleRepository.GetAllAsync<ScheduleDTO>();
                if (result != null)
                {
                    return new Result<List<ScheduleDTO>> { IsSuccess = true, Value = result.ToList() };
                }

                return new Result<List<ScheduleDTO>> { IsSuccess = false, Error = "No schedules found!" };
            }
        }
    }
}
