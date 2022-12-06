using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class MartialArtRepository : Repository<MartialArt>, IMartialArtRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MartialArtRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MartialArtDTO>> GetMartialArtsWithUsers(CancellationToken cancellationToken)
        {
            var martialArts = await context.MartialArts
                .ProjectTo<MartialArtDTO>(_mapper.ConfigurationProvider)// Mapira ono sto nam je potrebno. Primer: ne izvlaci ConcurencyStamp. Time je ubrzan query 
                .ToListAsync(cancellationToken);

            return martialArts;
        }

        public async Task<MartialArt> GetMartialArtWithUsers(string id)
        {
            var martialArt = await _context.MartialArts.Include(a => a.Attendees).ThenInclude(u => u.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            var martialArtToReturn = _mapper.Map<MartialArtDTO>(martialArt);

            return martialArt;
        }
    }
}
