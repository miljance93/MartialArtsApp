using Domain.IdentityAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new ApplicationUser { FirstName = "Jonh", LastName = "Legend" });
                await context.SaveChangesAsync();
            }            
        }
    }
}
