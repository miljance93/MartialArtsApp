using Application.Interfaces;
using AutoMapper;
using Domain;

namespace Persistence.Repository
{
    public class MartialArtRepository : Repository<MartialArt>, IMartialArtRepository
    {
        public MartialArtRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
