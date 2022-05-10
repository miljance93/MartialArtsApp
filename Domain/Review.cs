using Domain.IdentityAuth;

namespace Domain
{
    public class Review
    {
        public string ClientId { get; set; }
        public ApplicationUser Client { get; set; }
        public string CoachId { get; set; }
        public ApplicationUser Coach { get; set; }
        public int StarRating { get; set; }
    }
}
