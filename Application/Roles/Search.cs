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
    public class Search
    {
        public record Query(int Id) : IRequest<Result<RoleDTO>>;

        public class Handler : IRequestHandler<Query, Result<RoleDTO>>
        {
            private readonly IRoleRepository _roleRepository;

            public Handler(IRoleRepository roleRepository)
            {
                _roleRepository = roleRepository;
            }
            public async Task<Result<RoleDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _roleRepository.GetByIdAsync<RoleDTO>(x => x.Id == request.Id);
                if (result != null)
                {
                    return new Result<RoleDTO> { IsSuccess = true, Value = result };
                }

                return new Result<RoleDTO> { IsSuccess = false, Error = "Role not found!" };
            }
        }
    }
}
