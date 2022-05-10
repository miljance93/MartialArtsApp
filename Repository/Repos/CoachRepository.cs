using AutoMapper;
using Repository;
using Domain.IdentityAuth;
using Application.Interfaces;
using Application.DTO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace RepositoryLayer
{
    public class CoachRepository : Repository<ApplicationUser>, ICoachRepository
    {
        public CoachRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public async Task<bool> Exists(CoachDTO coach)
        {
            if (await context.Users.ContainsAsync(mapper.Map<ApplicationUser>(coach)))
            {
                return true;
            }
            return false;
        }

    }
}
