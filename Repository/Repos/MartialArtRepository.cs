using Application.Interfaces;
using AutoMapper;
using Domain;
using Repository;

namespace RepositoryLayer
{
    public class MartialArtRepository : Repository<MartialArt>, IMartialArtRepository
    {
        public MartialArtRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
