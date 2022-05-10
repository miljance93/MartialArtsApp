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
    public class Create
    {
        public record Command(ClassDTO Class) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly IClassRepository _classRepository;

            public Handler(IClassRepository classRepository)
            {
                _classRepository = classRepository;
            }
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _classRepository.PostAsync(request.Class);
                return new Result<bool> { IsSuccess = true, Value = result };
            }
        }
    }
}
