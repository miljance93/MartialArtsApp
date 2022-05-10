using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.IdentityAuth;
using System;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class CoachRepository : Repository<ApplicationUser>, ICoachRepository
    {
        public CoachRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
