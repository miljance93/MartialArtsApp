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
            if (!context.Users.Any())
            {
                var users = new List<ApplicationUser>
                {
                    new ApplicationUser { FirstName = "Jonh", LastName = "Jonson", Email = "jonhjonson@test.com", UserName = "jonhjonson@test.com" },
                    new ApplicationUser { FirstName = "Mike", LastName = "Tyson", Email = "miketyson@test.com", UserName = "miketyson@test.com" },
                    new ApplicationUser { FirstName = "Kamaru", LastName = "Ousman", Email = "kamaruousman@test.com", UserName = "kamaruousman@test.com" },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Test12.");
                }
            }
            //if (!context.Reviews.Any())
            //{
            //    context.Reviews.Add(new Review { CoachId = "2", StarRating = 5, ClientId = "1" });
            //    context.Reviews.Add(new Review { CoachId = "2", StarRating = 4, ClientId = "2" });
            //    context.Reviews.Add(new Review { CoachId = "2", StarRating = 3, ClientId = "3" });

            //    await context.SaveChangesAsync();
            //}

            if (!context.MartialArts.Any())
            {
                context.MartialArts.Add(new MartialArt { Id = "1", Name = "Muay Thai" });
                context.MartialArts.Add(new MartialArt { Id = "2", Name = "Brazilian Jiu-Jitsu" });
                context.MartialArts.Add(new MartialArt { Id = "3", Name = "Mixed Martial Arts" });

                await context.SaveChangesAsync();
            }
        }
    }
}
