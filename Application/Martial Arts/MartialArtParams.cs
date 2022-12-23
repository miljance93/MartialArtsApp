using Domain.Models;
using System;

namespace Application.Martial_Arts
{
    public class MartialArtParams : PagingParams
    {
        public bool IsGoing { get; set; }
        public bool IsHost { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
    }
}
