using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchedHoliday.Repo.Activity;
using SchedHoliday.Repo.Holiday;
using SchedHoliday.Repo.Message;
using SchedHoliday.Repo.User;
using SchedHoliday.Repo.UserHoliday;

namespace SchedHoliday.Repo
{
    public class _DbContext : IdentityDbContext<DTOUser>
    {
        public DbSet<DTOActivity>? Activitys { get; set; }
        public DbSet<DTOHoliday>? Holidays { get; set; }
        public DbSet<DTOMessage>? Messages { get; set; }
        public DbSet<DTOUser>? Users { get; set; }


        public _DbContext(DbContextOptions<_DbContext> creds) : base(creds) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DTOHoliday>()
                .HasMany(h => h.Messages)
                .WithOne(m => m.Holiday)
                .HasForeignKey(m => m.Id);

            builder.Entity<DTOHoliday>()
                .HasMany(h => h.Activities)
                .WithOne(a => a.Holiday)
                .HasForeignKey(a => a.HolidayId);


            /*builder.Entity<DTOHoliday>()
                .HasOne(h => h.Creator)
                .WithMany(c => c.Holidays)
                .HasForeignKey(h => h.CreatorId);*/


            builder.Entity<DTOUser>()
                .HasMany(u => u.Messages)
                .WithOne(m => m.Sender)
                .HasForeignKey(m => m.SenderId);

           builder.Entity<DTOUser>()
                .HasMany(u => u.Holidays)
                .WithMany(h => h.Users)
                .UsingEntity(ent => ent.ToTable("UsersHolidays"));

            builder.Entity<DTOMessage>()
                .HasOne(m => m.Holiday)
                .WithMany(h => h.Messages)
                .HasForeignKey(h => h.HolidayId);

            Seed(builder);
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            // voyage 1
            //StartDate = new DateTime(2023, 12, 15, 17, 0, 0),
            //EndDate = new DateTime(2023, 12, 22, 17, 0, 0),


            var activities = new List<DTOActivity>
            {
                new DTOActivity
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Name = "Kayak",
                    Description = "Faire du kayak sur une rivière",
                    StartDate = new DateTime(2023, 12, 16, 14, 0, 0),
                    EndDate = new DateTime(2023, 12, 16, 16, 0, 0),
                },

                new DTOActivity
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Name = "Balade en bateau",
                    Description = "grande balade sur un bateau pirate",
                    StartDate = new DateTime(2023, 12, 17, 14, 0, 0),
                    EndDate = new DateTime(2023, 12, 17, 16, 0, 0),

                },

                new DTOActivity
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Name = "Visite d'une grotte",
                    Description = "Visite une grotte dans Marseille",
                    StartDate = new DateTime(2023, 12, 19, 14, 0, 0),
                    EndDate = new DateTime(2023, 12, 19, 16, 0, 0),

                },

                new DTOActivity
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Name = "Marche",
                    Description = "on se baladera sur un marché",
                    StartDate = new DateTime(2023, 12, 20, 14, 0, 0),
                    EndDate = new DateTime(2023, 12, 20, 16, 0, 0),

                }
            };


            modelBuilder.Entity<DTOHoliday>().HasData(new DTOHoliday
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "Voyage Marseille",
                StartDate = new DateTime(2023, 12, 15, 17, 0, 0),
                EndDate = new DateTime(2023, 12, 22, 17, 0, 0),
                Longitude = 43.299232110639,
                Latitude = 5.364150874956166,
            });

            /*foreach(var a in activities)
            {
                modelBuilder.Entity<DTOActivity>().HasData(a);
            }*/


            /*//voyage 2  , 
            modelBuilder.Entity<DTOHoliday>().HasData(new DTOHoliday
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "Voyage New-York",
                StartDate = new DateTime(2024, 01, 01, 17, 0, 0),
                EndDate = new DateTime(2024, 01, 07, 17, 0, 0),
                Longitude = 40.75825212980446,
                Latitude = -73.98518566013351,
            });
            modelBuilder.Entity<DTOActivity>().HasData(new DTOActivity
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "visite musée dinosaure",
                Description = "On visitera un musée avec des squellettes de dinosaure",
                StartDate = new DateTime(2024, 01, 02, 13, 0, 0),
                EndDate = new DateTime(2024, 01, 02, 17, 0, 0),
            });
            modelBuilder.Entity<DTOActivity>().HasData(new DTOActivity
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "centre ville",
                Description = "Visite du centre ville avec les grands écrans",
                StartDate = new DateTime(2024, 01, 04, 13, 0, 0),
                EndDate = new DateTime(2024, 01, 04, 17, 0, 0),
            });
            modelBuilder.Entity<DTOActivity>().HasData(new DTOActivity
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "aquarium",
                Description = "Visite d'un aquarium. Bloop bloop",
                StartDate = new DateTime(2024, 01, 05, 13, 0, 0),
                EndDate = new DateTime(2024, 01, 05, 17, 0, 0),
            });

            //voyage 3 , 
            modelBuilder.Entity<DTOHoliday>().HasData(new DTOHoliday
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "Voyage Italie",
                StartDate = new DateTime(2023, 11, 15, 17, 0, 0),
                EndDate = new DateTime(2023, 11, 22, 17, 0, 0),
                Longitude = 41.92987912368395,
                Latitude = 12.416510281876892,
            });
            modelBuilder.Entity<DTOActivity>().HasData(new DTOActivity
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "colliser",
                Description = "Visite le colliser de Rome",
                StartDate = new DateTime(2023, 11, 16, 13, 0, 0),
                EndDate = new DateTime(2023, 11, 16, 15, 0, 0),
            });
            modelBuilder.Entity<DTOActivity>().HasData(new DTOActivity
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "Balade à chaval. Oui, j'ai bien dit chaval",
                Description = "Nous ferrons une balade avec des chevaux.",
                StartDate = new DateTime(2023, 11, 18, 15, 0, 0),
                EndDate = new DateTime(2023, 11, 18, 16, 0, 0),
            });
            modelBuilder.Entity<DTOActivity>().HasData(new DTOActivity
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "tir à l'arc",
                Description = "On tirera sur les passants depuis la chambre d'hôtel",
                StartDate = new DateTime(2023, 11, 19, 10, 0, 0),
                EndDate = new DateTime(2023, 11, 19, 11, 0, 0),
            });

            //voyage 4 , 
            modelBuilder.Entity<DTOHoliday>().HasData(new DTOHoliday
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "Voyage Japon",
                StartDate = new DateTime(2024, 01, 01, 17, 0, 0),
                EndDate = new DateTime(2024, 01, 07, 17, 0, 0),
                Longitude = 35.734012428235765,
                Latitude = 139.6445064205227,
            });*/

        }

    }
}
