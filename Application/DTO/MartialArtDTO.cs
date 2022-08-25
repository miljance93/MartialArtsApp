using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class MartialArtDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CoachId { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}
