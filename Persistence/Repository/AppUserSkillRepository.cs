using Application.Interfaces;
using AutoMapper;
using Domain;

namespace Persistence.Repository
{
    public class AppUserSkillRepository : Repository<AppUserSkill>, IAppUserSkillRepository
    {
        public AppUserSkillRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
