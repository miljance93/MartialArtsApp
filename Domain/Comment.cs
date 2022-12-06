using Domain.IdentityAuth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Body { get; set; }
        public string AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }
        public string MartialArtId { get; set; }
        [ForeignKey("MartialArtId")]
        public MartialArt MartialArt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
