using Application.Interfaces;
using AutoMapper;
using Domain;

namespace Persistence.Repository
{
    public class MentorshipRepository : Repository<Mentorship>, IMentorshipRepository
    {
        public MentorshipRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
