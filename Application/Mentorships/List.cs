using Application.Core;
using Application.DTO;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mentorships
{
    public class List 
    {
        public record Query(string CoachId) : IRequest<Result<List<Mentorship>>>;

        public class Handler : IRequestHandler<Query, Result<List<Mentorship>>>
        {
            private readonly IMentorshipRepository _repository;

            public Handler(IMentorshipRepository repository)
            {
                _repository = repository;
            }
            public async Task<Result<List<Mentorship>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _repository.FilterAllAsync<Mentorship>(x => x.CoachId == request.CoachId);
                if (!result.Any())
                {
                    return new Result<List<Mentorship>> { IsSuccess = false, Error = "No mentorships" };
                }
                return new Result<List<Mentorship>> { IsSuccess = true, Value = result.ToList() };
            }
        }
    }
}
