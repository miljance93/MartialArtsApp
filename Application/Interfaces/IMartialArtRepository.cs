using Application.DTO;
using Domain;
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
        Task<IEnumerable<MartialArtDTO>> GetMartialArtsWithUsers(CancellationToken cancellationToken);
        Task<MartialArt> GetMartialArtWithUsers(string id);
        Task<MartialArtDTO> GetMartialArt(string id);
    }
}
