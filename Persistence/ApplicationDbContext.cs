using Domain;
using Domain.IdentityAuth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<MartialArt> MartialArts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Mentorship> Mentorships { get; set; }
        public DbSet<Package> Packages { get; set; }
        public new DbSet<Role> Roles { get; set; }
        public DbSet<UserFollowing> UserFollowings { get; set; }
        public DbSet<AuditLogs> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Review>(b =>
            {
                b.HasKey(r => new { r.CoachId, r.ClientId });

                b.HasOne(r => r.Coach)
                    .WithMany(cl => cl.ClientReviews)
                    .HasForeignKey(r => r.CoachId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(r => r.Client)
                    .WithMany(c => c.CoachReviews)
                    .HasForeignKey(r => r.ClientId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<MartialArtSkill>(b =>
            {
                b.HasKey(m => new { m.MartialArtId, m.SkillId });

                b.HasOne(m => m.MartialArt)
                    .WithMany(s => s.Skills)
                    .HasForeignKey(m => m.MartialArtId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(s => s.Skill)
                    .WithMany(c => c.MartialArts)
                    .HasForeignKey(s => s.SkillId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<AppUserSkill>(b =>
            {
                b.HasKey(a => new { a.TrainerId, a.SkillId });

                b.HasOne(a => a.Trainer)
                    .WithMany(s => s.Skills)
                    .HasForeignKey(a => a.TrainerId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(s => s.Skill)
                    .WithMany(t => t.Trainers)
                    .HasForeignKey(s => s.SkillId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Schedule>(b =>
            {
                b.HasKey(a => new { a.ClientId, a.CoachId });

                b.HasOne(a => a.Client)
                    .WithMany(s => s.ClientsSchedule)
                    .HasForeignKey(a => a.ClientId)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(s => s.Coach)
                    .WithMany(t => t.CoachesSchedule)
                    .HasForeignKey(s => s.CoachId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Mentorship>(b =>
            {
                b.HasKey(m => new { m.ClientId, m.CoachId });

                b.HasOne(c => c.Coach)
                    .WithMany(cl => cl.Clients)
                    .HasForeignKey(c => c.CoachId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(c => c.Client)
                    .WithMany(co => co.Coaches)
                    .HasForeignKey(c => c.ClientId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<UserFollowing>(b =>
            {
                b.HasKey(uf => new { uf.CoachId, uf.ClientId });

                b.HasOne(uf => uf.Coach)
                    .WithMany(cl => cl.ClientsFollowing)
                    .HasForeignKey(r => r.CoachId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(uf => uf.Client)
                    .WithMany(c => c.CoachesFollowing)
                    .HasForeignKey(r => r.ClientId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            //Seed Data
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { FirstName = "Jonh", LastName = "Smith" }
                );
        }
    }
}
