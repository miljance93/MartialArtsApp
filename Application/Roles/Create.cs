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

namespace Application.Roles
{
    public class Create
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
                if (await _roleRepository.Exists(request.Role))
                {
                    return new Result<bool> { IsSuccess = false, Error = "Role allready exists!" };
                }

                var result = await _roleRepository.PostAsync(request.Role);
                return new Result<bool> { IsSuccess = true, Value = result };
            }
        }
    }
}
