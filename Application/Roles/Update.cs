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
    public class Update
    {
        public record Command(RoleDTO Role) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly IRoleRepository _roleRepository;

            public Handler(IRoleRepository roleRepository)
            {
                _roleRepository = roleRepository;
            }
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var findRole = await _roleRepository.GetByIdAsync<RoleDTO>(x => x.Id == request.Role.Id);
                if (findRole != null)
                {
                    var result = await _roleRepository.UpdateAsync(findRole);
                    return new Result<bool> { IsSuccess = true, Value = result };
                }

                return new Result<bool> { IsSuccess = false, Error = "Role is not updated!" };
            }
        }
    }
}
