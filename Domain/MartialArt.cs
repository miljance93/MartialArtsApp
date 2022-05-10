using Domain.IdentityAuth;
using System.Collections.Generic;

namespace Domain
{
    public class MartialArt : IGenericModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUser Coach { get; set; }
        public ICollection<MartialArtSkill> Skills { get; set; }
    }
}
