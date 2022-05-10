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
    public class Delete
    {
        public record Command(int Id) : IRequest<Result<ClassDTO>>;

        public class Handler : IRequestHandler<Command, Result<ClassDTO>>
        {
            private readonly IClassRepository _classRepository;

            public Handler(IClassRepository classRepository)
            {
                _classRepository = classRepository;
            }
            public async Task<Result<ClassDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _classRepository.GetByIdAsync<ClassDTO>(x => x.Id == request.Id);
                if (result != null)
                {
                    await _classRepository.DeleteAsync(result);
                    return new Result<ClassDTO> { IsSuccess = true, Value = result };
                }

                return new Result<ClassDTO> { IsSuccess = false, Error = "Class not deleted!" };
            }
        }
    }
}
