using Domain.IdentityAuth;
using System.Collections.Generic;

namespace Domain
{
    public class MartialArt 
    { 
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public bool IsCancelled { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<MartialArtAttendee> Attendees { get; set; } = new List<MartialArtAttendee>();
    }
}
