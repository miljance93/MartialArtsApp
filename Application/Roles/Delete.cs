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

namespace Application.Roles
{
    public class Delete
    {
        public record Command(int Id) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly IRoleRepository _roleRepository;

            public Handler(IRoleRepository roleRepository)
            {
                _roleRepository = roleRepository;
            }
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _roleRepository.GetByIdAsync<RoleDTO>(x => x.Id == request.Id);
                if (result != null)
                {
                    var role = await _roleRepository.DeleteAsync(result);
                    return new Result<bool> { IsSuccess = true, Value = role };
                }

                return new Result<bool> { IsSuccess = false, Error = "Role is not deleted!" };
            }
        }
    }
}
