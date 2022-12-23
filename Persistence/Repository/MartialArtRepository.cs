using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.UserAccess;
using Application.Martial_Arts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class MartialArtRepository : Repository<MartialArt>, IMartialArtRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public MartialArtRepository(ApplicationDbContext context, IMapper mapper, IUserAccessor userAccessor) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<bool> CreateAsync(MartialArt martialArt)
        {
            bool result;
            try
            {
                _context.MartialArts.Add(martialArt);
                await _context.SaveChangesAsync();

                result = true;
            }
            catch (System.Exception)
            {
                result = false;
            }

            return result;
        }

        public async Task<MartialArtDTO> GetMartialArt(string id)
        {
            var martialArt = await _context.MartialArts
                .ProjectTo<MartialArtDTO>(_mapper.ConfigurationProvider, new { currentUsername = _userAccessor.GetUsername() })
                .FirstOrDefaultAsync(x => x.Id == id);
            return martialArt;
        }

        public async Task<PagedList<MartialArtDTO>> GetMartialArtsWithUsers(CancellationToken cancellationToken, 
            int pageNumber, int pageSize, MartialArtParams @params)
        {
            var query = context.MartialArts
                .Where(d => d.Date >= @params.StartDate)
                .OrderBy(d => d.Date)
                .ProjectTo<MartialArtDTO>(_mapper.ConfigurationProvider,
                    new { currentUsername = _userAccessor.GetUsername() })// Mapira ono sto nam je potrebno. Primer: ne izvlaci ConcurencyStamp. Time je ubrzan query 
                .AsQueryable();

            if(@params.IsGoing && !@params.IsHost)
            {
                query = query.Where(x => x.Attendees.Any(a => a.Username == _userAccessor.GetUsername()));  
            }

            if (@params.IsHost && !@params.IsGoing) 
            {
                query = query.Where(x => x.HostUsername == _userAccessor.GetUsername());
            }

            return await PagedList<MartialArtDTO>.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<MartialArt> GetMartialArtWithUsers(string id)
        {
            var martialArt = await _context.MartialArts.Include(a => a.Attendees).ThenInclude(u => u.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            var martialArtToReturn = _mapper.Map<MartialArtDTO>(martialArt);

            return martialArt;
        }

        public async Task<bool> UpdateAsync(MartialArt martialArt)
        {
            bool result;
            try
            {
                _context.MartialArts.Update(martialArt);
                await _context.SaveChangesAsync();

                result = true;
            }
            catch (System.Exception)
            {
                result = false;
            }

            return result;
        }
    }
}
