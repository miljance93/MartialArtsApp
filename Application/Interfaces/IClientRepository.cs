using Domain.IdentityAuth;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IClientRepository : IRepository<ApplicationUser>
    {
        Task<PagedList<ClientDTO>> GetClients(PagingParameterModel pagingParameterModel);
    }
}
