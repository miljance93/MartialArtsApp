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

namespace Application.Classes
{
    public class List
    {
        public record Query : IRequest<Result<List<ClassDTO>>>;

        public class Handler : IRequestHandler<Query, Result<List<ClassDTO>>>
        {
            private readonly IClassRepository _classRepository;

            public Handler(IClassRepository classRepository)
            {
                _classRepository = classRepository;
            }
            public async Task<Result<List<ClassDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _classRepository.GetAllAsync<ClassDTO>();
                if (result.Any())
                {
                    return new Result<List<ClassDTO>> { IsSuccess = true, Value = result.ToList() };
                }

                return new Result<List<ClassDTO>> { IsSuccess = false, Error = "No classes found!" };
            }
        }
    }
}
