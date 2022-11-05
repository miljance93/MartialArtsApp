using Domain.IdentityAuth;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class MartialArt : IGenericModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public List<Comment> Comments { get; set; }
        public ApplicationUser Coach { get; set; }
        public ICollection<MartialArtSkill> Skills { get; set; }
    }
}
