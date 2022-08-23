using Application.Core;
using Application.DTO;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;

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
