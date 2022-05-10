using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.IdentityAuth;
using Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class ClientRepository : Repository<ApplicationUser>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<PagedList<ClientDTO>> GetClients(PagingParameterModel pagingParameterModel)
        {
            return mapper.Map<PagedList<ClientDTO>>(await PagedList<ApplicationUser>
                .GetPagedList(FindAll<ApplicationUser>()
                .OrderBy(c => c.UserName), pagingParameterModel
                .PageNumber, pagingParameterModel.PageSize));
        }
    }
}
