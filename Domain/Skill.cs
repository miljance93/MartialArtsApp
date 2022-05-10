using Domain.IdentityAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Skill
    {
        public int Id { get; set; }       
        public string Name { get; set; }
        public ICollection<AppUserSkill> Trainers { get; set; }
        public ICollection<MartialArtSkill> MartialArts { get; set; }
    }
}
