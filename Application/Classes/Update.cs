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
    public class Update
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
                var getClassById = await _classRepository.GetByIdAsync<ClassDTO>(x => x.Id == request.Class.Id);
                if (getClassById is not null)
                {
                    getClassById.Classroom = request.Class.Classroom;
                    var result = await _classRepository.UpdateAsync(getClassById);
                    return new Result<bool> { IsSuccess = true, Value = result};
                }

                return new Result<bool> { IsSuccess = false, Error = "Class is not updated!"};
            }
        }
    }
}
