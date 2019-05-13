using System;
using System.Collections.Generic;
using System.Text;
using FourthStar1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;




//# Seeding the Database

// You can seed your database by adding instructions in your `ApplicationDbContext.cs` file with an `OnModelCreating` method.  Once you've defined some objects in this method, when you generate a new migration with `Add-Migration [DescriptiveLabel]`, then instructions will be added to the migration file to insert the data.
//When the `Update-Database` instruction is given, then the items will be added to your database.

namespace FourthStar1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Drill> Drills { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //below patch suggested by stack Overflow: https://stackoverflow.com/questions/40703615/the-entity-type-identityuserloginstring-requires-a-primary-key-to-be-defined/40824620
            {
                base.OnModelCreating(modelBuilder);
            }

            // Create a new user for Identity Framework
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            // Create a few Teams
            modelBuilder.Entity<Team>().HasData(
                new Team()
                {
                    TeamId = 1,
                    TeamName = "Team Lasers"
                },
                new Team()
                {
                    TeamId = 2,
                    TeamName = "Team Express"
                }
            );

            // Create a few categories
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Set Pieces"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Warm Ups"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Offense"
                },
                new Category()
                {
                    CategoryId = 4,
                    CategoryName = "Defense"
                },
                new Category()
                {
                    CategoryId = 5,
                    CategoryName = "GoalKeeper Drills"
                }
            );

            // Create a few drills
            modelBuilder.Entity<Drill>().HasData(
                new Drill()
                {
                    Id = 1,
                    UserId = user.Id,
                    DrillName = "Warm Up / Stretches",
                    DrillDescription = "Take 1/2 a lap around the field, stretch hamstrings, quads, calves, torso",
                    PlayersRequired = 1,
                    CategoryId = 2,
                    DateCreated = DateTime.Now
                },
                new Drill()
                {
                    Id = 2,
                    UserId = user.Id,
                    DrillName = "3 cone drill",
                    DrillDescription = "Set up 3 cones in a straight line directly in front of the 18 yard box; player will dribble the ball and weave through all 3 cones, then shoot on goal",
                    PlayersRequired = 1,
                    CategoryId = 3,
                    DateCreated = DateTime.Now
                },
                new Drill()
                {
                    Id = 3,
                    UserId = user.Id,
                    DrillName = "Penalty Kick - GoalKeeper",
                    DrillDescription = "Make yourself BIG; pick a direction to dive, angle out at a 30 degree angle to maximize your angle",
                    PlayersRequired = 2,
                    CategoryId = 5,
                    DateCreated = DateTime.Now
                },
                new Drill()
                {
                    Id = 4,
                    UserId = user.Id,
                    DrillName = "5 v 2",
                    DrillDescription = "Five offensive players on the perimeter; 2 touches max; 2 defenders inside the perimeter",
                    PlayersRequired = 2,
                    CategoryId = 5,
                    DateCreated = DateTime.Now
                },
                new Drill()
                {
                    Id = 5,
                    UserId = user.Id,
                    DrillName = "Penalty Kick - Offense",
                    DrillDescription = "Place the ball on the 12 yard mark; aim for the side netting",
                    PlayersRequired = 2,
                    CategoryId = 3,
                    DateCreated = DateTime.Now
                }
            );
        }
    }
}
