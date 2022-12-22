using Application.DTO;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMartialArtRepository : IRepository<MartialArt>
    {
        Task<PagedList<MartialArtDTO>> GetMartialArtsWithUsers(CancellationToken cancellationToken, int pageNumber, int pageSize);
        Task<MartialArt> GetMartialArtWithUsers(string id);
        Task<MartialArtDTO> GetMartialArt(string id);
        Task<bool> CreateAsync(MartialArt martialArt);
        Task<bool> UpdateAsync(MartialArt martialArt);
    }
}
