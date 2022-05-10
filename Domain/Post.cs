using Domain.IdentityAuth;

namespace Domain
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CoachId { get; set; }
        public ApplicationUser Coach { get; set; }

    }
}
