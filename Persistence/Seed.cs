using Domain;
using Domain.IdentityAuth;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            //if (!context.Users.Any())
            //{
            //    var users = new List<ApplicationUser>
            //    {
            //        new ApplicationUser(){ Email = "tester@test.com", FirstName = "Tester", LastName = "Testeric"}
            //    };

            //    foreach (var user in users)
            //    {
            //        await userManager.CreateAsync(user, "Test12.");
            //    }
            //}
        }
    }
}
