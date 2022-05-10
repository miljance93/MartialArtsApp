using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {

        public ScheduleRepository(ApplicationDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public async Task<bool> Exists(ScheduleDTO schedule)
        {
            if (await context.Schedules.ContainsAsync(mapper.Map<Schedule>(schedule)))
            {
                return true;
            }
            return false;
        }
    }
}
