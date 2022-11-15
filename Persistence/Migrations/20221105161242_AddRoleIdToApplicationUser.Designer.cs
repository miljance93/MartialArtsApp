﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221105161242_AddRoleIdToApplicationUser")]
    partial class AddRoleIdToApplicationUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.AppUserSkill", b =>
                {
                    b.Property<string>("TrainerId")
                        .HasColumnType("text");

                    b.Property<int>("SkillId")
                        .HasColumnType("integer");

                    b.HasKey("TrainerId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("AppUserSkill");
                });

            modelBuilder.Entity("Domain.AuditLogs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<string>("Method")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CommentId"));

                    b.Property<string>("AuthorId")
                        .HasColumnType("text");

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MartialArtId")
                        .HasColumnType("integer");

                    b.HasKey("CommentId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("MartialArtId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domain.IdentityAuth.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.MartialArt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CoachId")
                        .HasColumnType("text");

                    b.Property<string>("LongDescription")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.ToTable("MartialArts");
                });

            modelBuilder.Entity("Domain.MartialArtSkill", b =>
                {
                    b.Property<int>("MartialArtId")
                        .HasColumnType("integer");

                    b.Property<int>("SkillId")
                        .HasColumnType("integer");

                    b.HasKey("MartialArtId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("MartialArtSkill");
                });

            modelBuilder.Entity("Domain.Mentorship", b =>
                {
                    b.Property<string>("ClientId")
                        .HasColumnType("text");

                    b.Property<string>("CoachId")
                        .HasColumnType("text");

                    b.Property<int>("NumberOfSessions")
                        .HasColumnType("integer");

                    b.HasKey("ClientId", "CoachId");

                    b.HasIndex("CoachId");

                    b.ToTable("Mentorships");
                });

            modelBuilder.Entity("Domain.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Duration")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("NumberOfSessions")
                        .HasColumnType("integer");

                    b.Property<string>("TrainerId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("Domain.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CoachId")
                        .HasColumnType("integer");

                    b.Property<string>("CoachId1")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CoachId1");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Domain.Review", b =>
                {
                    b.Property<string>("CoachId")
                        .HasColumnType("text");

                    b.Property<string>("ClientId")
                        .HasColumnType("text");

                    b.Property<int>("StarRating")
                        .HasColumnType("integer");

                    b.HasKey("CoachId", "ClientId");

                    b.HasIndex("ClientId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Schedule", b =>
                {
                    b.Property<string>("ClientId")
                        .HasColumnType("text");

                    b.Property<string>("CoachId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ClientId", "CoachId");

                    b.HasIndex("CoachId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Domain.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("Domain.UserFollowing", b =>
                {
                    b.Property<string>("CoachId")
                        .HasColumnType("text");

                    b.Property<string>("ClientId")
                        .HasColumnType("text");

                    b.HasKey("CoachId", "ClientId");

                    b.HasIndex("ClientId");

                    b.ToTable("UserFollowings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.AppUserSkill", b =>
                {
                    b.HasOne("Domain.Skill", "Skill")
                        .WithMany("Trainers")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.IdentityAuth.ApplicationUser", "Trainer")
                        .WithMany("Skills")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.HasOne("Domain.IdentityAuth.ApplicationUser", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Domain.MartialArt", "MartialArt")
                        .WithMany("Comments")
                        .HasForeignKey("MartialArtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("MartialArt");
                });

            modelBuilder.Entity("Domain.IdentityAuth.ApplicationUser", b =>
                {
                    b.HasOne("Domain.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.MartialArt", b =>
                {
                    b.HasOne("Domain.IdentityAuth.ApplicationUser", "Coach")
                        .WithMany("MartialArts")
                        .HasForeignKey("CoachId");

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("Domain.MartialArtSkill", b =>
                {
                    b.HasOne("Domain.MartialArt", "MartialArt")
                        .WithMany("Skills")
                        .HasForeignKey("MartialArtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Skill", "Skill")
                        .WithMany("MartialArts")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MartialArt");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Domain.Mentorship", b =>
                {
                    b.HasOne("Domain.IdentityAuth.ApplicationUser", "Client")
                        .WithMany("Coaches")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.IdentityAuth.ApplicationUser", "Coach")
                        .WithMany("Clients")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("Domain.Package", b =>
                {
                    b.HasOne("Domain.IdentityAuth.ApplicationUser", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerId");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Domain.Post", b =>
                {
                    b.HasOne("Domain.IdentityAuth.ApplicationUser", "Coach")
                        .WithMany("Posts")
                        .HasForeignKey("CoachId1");

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("Domain.Review", b =>
                {
                    b.HasOne("Domain.IdentityAuth.ApplicationUser", "Client")
                        .WithMany("CoachReviews")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.IdentityAuth.ApplicationUser", "Coach")
                        .WithMany("ClientReviews")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("Domain.Schedule", b =>
                {
                    b.HasOne("Domain.IdentityAuth.ApplicationUser", "Client")
                        .WithMany("ClientsSchedule")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.IdentityAuth.ApplicationUser", "Coach")
                        .WithMany("CoachesSchedule")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("Domain.UserFollowing", b =>
                {
                    b.HasOne("Domain.IdentityAuth.ApplicationUser", "Client")
                        .WithMany("CoachesFollowing")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.IdentityAuth.ApplicationUser", "Coach")
                        .WithMany("ClientsFollowing")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.IdentityAuth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.IdentityAuth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.IdentityAuth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.IdentityAuth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.IdentityAuth.ApplicationUser", b =>
                {
                    b.Navigation("ClientReviews");

                    b.Navigation("Clients");

                    b.Navigation("ClientsFollowing");

                    b.Navigation("ClientsSchedule");

                    b.Navigation("CoachReviews");

                    b.Navigation("Coaches");

                    b.Navigation("CoachesFollowing");

                    b.Navigation("CoachesSchedule");

                    b.Navigation("Comments");

                    b.Navigation("MartialArts");

                    b.Navigation("Posts");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Domain.MartialArt", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Domain.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Skill", b =>
                {
                    b.Navigation("MartialArts");

                    b.Navigation("Trainers");
                });
#pragma warning restore 612, 618
        }
    }
}