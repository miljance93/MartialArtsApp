using Domain.IdentityAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MartialArtAttendee
    {
        public string AppUserId { get; set; }
        public ApplicationUser User { get; set; }
        public string MartialArtId { get; set; }
        public MartialArt MartialArt { get; set; }
        public bool IsCoach { get; set; }
    }
}
