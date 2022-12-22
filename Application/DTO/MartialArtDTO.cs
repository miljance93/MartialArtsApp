using Domain;
using System;
using System.Collections.Generic;

namespace Application.DTO
{
    public class MartialArtDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string HostUsername { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime Date { get; set; }
        public ICollection<AttendeeDTO> Attendees { get; set; }
    }
}
