using Application.Core;
using Application.DTO;
using Application.Interfaces;
using Domain.IdentityAuth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Coaches
{
    public class Search
    {
        public record Query(string SkillName) : IRequest<Result<List<CoachSearchDTO>>>;

        public class Handler : IRequestHandler<Query, Result<List<CoachSearchDTO>>>
        {
            private readonly ISkillsRepository repository;

            public Handler(ISkillsRepository repository)
            {
                this.repository = repository;
            }
            public async Task<Result<List<CoachSearchDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await repository.FilterAllAsync<CoachSearchDTO>(x => x.Skills.Any(x => x.Name == request.SkillName));
                if (!result.Any())
                {
                    return new Result<List<CoachSearchDTO>> { IsSuccess = false, Error = "No coaches with requseted skills" };
                }
                return new Result<List<CoachSearchDTO>> { IsSuccess = true, Value = result.ToList() };
            }
        }
    }
}
