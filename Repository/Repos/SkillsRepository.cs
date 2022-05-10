using Application.Interfaces;
using AutoMapper;
using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repos
{
    public class SkillsRepository : Repository<Skill>, ISkillsRepository
    {
        public SkillsRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
