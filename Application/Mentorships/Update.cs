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

namespace Application.Mentorships
{
    public class Update
    {
        public record Command(MentorshipDTO Mentorship) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly IMentorshipRepository _mentorshipRepository;

            public Handler(IMentorshipRepository mentorshipRepository)
            {
                _mentorshipRepository = mentorshipRepository;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _mentorshipRepository.Exists(request.Mentorship))
                {
                    var result = await _mentorshipRepository.UpdateAsync(request.Mentorship);
                    return new Result<bool> { IsSuccess = true, Value = result };
                }

                return new Result<bool> { IsSuccess = false, Error = "Mentorship is not updated!" };
            }
        }
    }
}
