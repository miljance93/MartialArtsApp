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
    public class List
    {
        public record Query : IRequest<Result<List<RoleDTO>>>;

        public class Handler : IRequestHandler<Query, Result<List<RoleDTO>>>
        {
            private readonly IRoleRepository _roleRepository;

            public Handler(IRoleRepository roleRepository)
            {
                _roleRepository = roleRepository;
            }
            public async Task<Result<List<RoleDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _roleRepository.GetAllAsync<RoleDTO>();
                var listOfRoles = result.ToList();
                if (listOfRoles.Count == 0)
                {
                    return new Result<List<RoleDTO>> { IsSuccess = false, Error = "No Roles found!" };
                }

                return new Result<List<RoleDTO>> { IsSuccess = true, Value = listOfRoles };
            }
        }
    }
}
