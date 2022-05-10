using Application.Interfaces;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
