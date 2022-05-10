using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MartialArtSkill
    {
        public int MartialArtId { get; set; }
        public MartialArt MartialArt { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
