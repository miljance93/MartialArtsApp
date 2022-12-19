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
