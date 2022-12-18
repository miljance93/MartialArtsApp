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
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MartialArtAttendee> MartialArtAttendees { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Comment>()
                .HasOne(m => m.MartialArt)
                .WithMany(c => c.Comments)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<MartialArtAttendee>(b =>
            {
                b.HasKey(ma => new { ma.AppUserId, ma.MartialArtId });

                b.HasOne(u => u.User)
                .WithMany(m => m.MartialArts)
                .HasForeignKey(ma => ma.AppUserId);

                b.HasOne(m => m.MartialArt)
                .WithMany(a => a.Attendees)
                .HasForeignKey(ma => ma.MartialArtId);
            });

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
                b.HasKey(uf => new { uf.ObserverId, uf.TargetId });

                b.HasOne(uf => uf.Observer)
                    .WithMany(cl => cl.Followings)
                    .HasForeignKey(r => r.ObserverId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(uf => uf.Target)
                    .WithMany(c => c.Followers)
                    .HasForeignKey(r => r.TargetId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
