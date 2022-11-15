using Domain;
using Domain.IdentityAuth;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new ApplicationUser { Id = "1", FirstName = "Jonh", LastName = "Jonson",  });
                context.Users.Add(new ApplicationUser { Id = "2", FirstName = "Mike", LastName = "Tyson" });
                context.Users.Add(new ApplicationUser { Id = "3", FirstName = "Kamaru", LastName = "Ousman" });
                
                context.MartialArts.Add(new MartialArt { Name = "Muay Thai" });
                context.MartialArts.Add(new MartialArt { Name = "Brazilian Jiu-Jitsu" });
                context.MartialArts.Add(new MartialArt { Name = "Mixed Martial Arts" });
                await context.SaveChangesAsync();
            }
            if (!context.Reviews.Any())
            {
                context.Reviews.Add(new Review { CoachId = "2", StarRating = 5, ClientId = "1" });
                context.Reviews.Add(new Review { CoachId = "2", StarRating = 4, ClientId = "2" });
                context.Reviews.Add(new Review { CoachId = "2", StarRating = 3, ClientId = "3" });

                await context.SaveChangesAsync();
            }
        }
    }
}
