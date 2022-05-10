using Domain.IdentityAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserFollowing
    {
        public string ClientId { get; set; }
        public ApplicationUser Client { get; set; }
        public string CoachId { get; set; }
        public ApplicationUser Coach { get; set; }
    }
}
