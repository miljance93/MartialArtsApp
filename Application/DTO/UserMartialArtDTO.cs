using System;
using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class UserMartialArtDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        [JsonIgnore]
        public string HostUsername { get; set; }
    }
}
