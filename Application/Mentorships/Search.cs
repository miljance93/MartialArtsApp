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
    public class Search
    {
        public record Query(string CoachId) : IRequest<Result<MentorshipDTO>>;

        public class Handler : IRequestHandler<Query, Result<MentorshipDTO>>
        {
            private readonly IMentorshipRepository _mentorshipRepository;

            public Handler(IMentorshipRepository mentorshipRepository)
            {
                _mentorshipRepository = mentorshipRepository;
            }
            public async Task<Result<MentorshipDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _mentorshipRepository.FindAsync<MentorshipDTO>(x => x.CoachId == request.CoachId);
                if (result != null)
                {
                    return new Result<MentorshipDTO> { IsSuccess = true, Value = result };
                }

                return new Result<MentorshipDTO> { IsSuccess = false, Error = "Mentorship not found!" };
            }
        }
    }
}
