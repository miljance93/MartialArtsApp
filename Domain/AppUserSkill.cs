using Domain.IdentityAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AppUserSkill
    {
        public string TrainerId { get; set; }
        public ApplicationUser Trainer { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }

    }
}
