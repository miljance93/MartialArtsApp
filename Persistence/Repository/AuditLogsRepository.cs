using AutoMapper;
using Domain;
using Application.Interfaces;

namespace Persistence.Repository
{
    public class AuditLogsRepository : Repository<AuditLogs>, IAuditLogsRepository
    {
        public AuditLogsRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
