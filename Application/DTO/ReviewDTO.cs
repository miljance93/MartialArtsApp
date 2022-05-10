using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ReviewDTO
    {
        public string ClientId { get; set; }
        public string CoachId { get; set; }
        public int StarRating { get; set; }
    }
}
