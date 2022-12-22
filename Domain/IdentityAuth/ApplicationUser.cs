using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain.IdentityAuth
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string Bio { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<MartialArtAttendee> MartialArts { get; set; }     
      
        public ICollection<UserFollowing> Followings { get; set; }
        public ICollection<UserFollowing> Followers { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
