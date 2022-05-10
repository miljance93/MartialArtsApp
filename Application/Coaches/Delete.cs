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
    public class Delete
    {
        public record Command(string CoachId) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly ICoachRepository _coachRepository;

            public Handler(ICoachRepository coachRepository)
            {
                _coachRepository = coachRepository;
            }
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var getCoach = await _coachRepository.GetByIdAsync<CoachDTO>(x => x.Id == request.CoachId);
                if (await _coachRepository.Exists(getCoach))
                {
                    var result = await _coachRepository.DeleteAsync(getCoach);
                    return new Result<bool> { IsSuccess = true, Value = result };
                }

                return new Result<bool> { IsSuccess = false, Error = "Coach is not deleted!" };
            }
        }
    }
}
