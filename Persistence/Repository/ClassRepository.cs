using Application.Interfaces;
using AutoMapper;
using Domain;

namespace Persistence.Repository
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
