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
                context.Users.Add(new ApplicationUser { Id = "1", FirstName = "Jonh", LastName = "Jonson" });
                context.Users.Add(new ApplicationUser { Id = "2", FirstName = "Mike", LastName = "Tyson" });
                context.Users.Add(new ApplicationUser { Id = "3", FirstName = "Kamaru", LastName = "Ousman" });
                //context.Reviews.Add(new Review { CoachId = "2", StarRating = 5 });
                //context.Reviews.Add(new Review { CoachId = "2", StarRating = 4 });
                //context.Reviews.Add(new Review { CoachId = "2", StarRating = 3 });
                context.MartialArts.Add(new MartialArt { Name = "Muay Thai" });
                context.MartialArts.Add(new MartialArt { Name = "Brazilian Jiu-Jitsu" });
                context.MartialArts.Add(new MartialArt { Name = "Mixed Martial Arts" });
                await context.SaveChangesAsync();
            }            
        }
    }
}
