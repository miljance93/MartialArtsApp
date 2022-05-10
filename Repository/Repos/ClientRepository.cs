using AutoMapper;
using Domain.IdentityAuth;
using Domain.Models;
using Repository;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.DTO;
using System.Linq.Expressions;
using System;

namespace RepositoryLayer
{
    public class ClientRepository : Repository<ApplicationUser>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public Task<TInput> FindAsync<TInput>(Expression<Func<TInput, bool>> expression) where TInput : class
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<ClientDTO>> GetClients(PagingParameterModel pagingParameterModel)
        {
            return Task.FromResult(PagedList<ClientDTO>
                .GetPagedList(FindAll<ClientDTO>()
                .OrderBy(c => c.Id), pagingParameterModel
                .PageNumber, pagingParameterModel.PageSize));
        }
    }
}
