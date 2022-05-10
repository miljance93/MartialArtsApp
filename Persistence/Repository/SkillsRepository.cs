using Application.Interfaces;
using AutoMapper;
using Domain;

namespace Persistence.Repository
{
    public class SkillsRepository : Repository<Skill>, ISkillsRepository
    {
        public SkillsRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
