using Domain.IdentityAuth;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class MartialArt 
    { 
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime Date { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<MartialArtAttendee> Attendees { get; set; } = new List<MartialArtAttendee>();
    }
}
