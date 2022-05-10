using Domain.IdentityAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Package
    {
        public int Id { get; set; }
        public string Duration { get; set; }
        public int NumberOfSessions { get; set; }
        public string Name { get; set; }
        public string TrainerId { get; set; }
        public ApplicationUser Trainer { get; set; }
    }
}
