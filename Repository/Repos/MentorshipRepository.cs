using Application.Interfaces;
using AutoMapper;
using Domain;
using Repository;

namespace RepositoryLayer.Repos
{
    public class MentorshipRepository : Repository<Mentorship>, IMentorshipRepository
    {
        public MentorshipRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
