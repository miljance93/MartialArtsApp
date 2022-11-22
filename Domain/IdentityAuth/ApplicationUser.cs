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
        public string MobilePhone { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public List<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<MartialArt> MartialArts { get; set; }        
        public ICollection<Review> ClientReviews { get; set; }
        public ICollection<Schedule> ClientsSchedule { get; set; }        
        public ICollection<Review> CoachReviews { get; set; }
        public ICollection<Schedule> CoachesSchedule { get; set; }
        public ICollection<Mentorship> Clients { get; set; }
        public ICollection<Mentorship> Coaches { get; set; }
        public ICollection<AppUserSkill> Skills { get; set; }
        public ICollection<UserFollowing> ClientsFollowing { get; set; }
        public ICollection<UserFollowing> CoachesFollowing { get; set; }
    }
}
