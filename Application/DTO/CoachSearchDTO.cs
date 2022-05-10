using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CoachSearchDTO
    {
        public string Name { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
