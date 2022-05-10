using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain;
using System;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
