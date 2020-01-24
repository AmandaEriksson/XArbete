using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XArbete.Web.User.Models;
using XArbete.Web.Kennel.Models;
using XArbete.Web.Customer.Models;
using XArbete.Web.TrainingHall.Models;
using XArbete.Web.DogHotel.Models;
using XArbete.Web.GuestBook.Models;

namespace XArbete.Web.Data
{
    public class XArbeteContext : IdentityDbContext<ApplicationUser>
    {
        public XArbeteContext(DbContextOptions<XArbeteContext> options) : base(options)
        {

        }
        public DbSet<KennelDog> KennelDogs { get; set; }

        public DbSet<PuppyGroup> PuppyGroups { get; set; }

        public DbSet<XArbete.Web.Customer.Models.Customer> Customers { get; set; }

        public DbSet<Dog> Dogs { get; set; }

        public DbSet<TrainingHallBooking> TrainingHallBookings { get; set; }

        public DbSet<HotelBooking> HotelBookings { get; set; }

        public DbSet<GuestBookComment> GuestbookComments { get; set; }
        public DbSet<Puppy> Puppies { get; set; }

        public DbSet<KennelContent> KennelContents { get; set; }

        public DbSet<KennelContentSection> KennelContentSections { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// Cache DateTime.Now
            //var createdDate = DateTime.Now;

            ///* Model configurations (validation rules) */
            //// AppUser
            //modelBuilder.Entity<Customer>().HasKey(c => c.ID);
            //modelBuilder.Entity<Customer>().HasMany(a => a.Dogs);

            //// UserRole
            //modelBuilder.Entity<Dog>().HasKey(c => c.ID);
            //modelBuilder.Entity<Dog>().HasOne(c => c.Owner);

            //// TrainingSession
            //modelBuilder.Entity<HotelBooking>()
            //    .HasKey(c => c.ID);

            //// LeaveApplication
            //modelBuilder.Entity<TrainingHallBooking>()
            //    .HasKey(c => c.ID);

            //// ActivityLog
            //modelBuilder.Entity<GuestBookComment>()
            //    .HasKey(c => c.ID);

         
            //// UsersRolesMaps
            //modelBuilder.Entity<UsersRolesMap>()
            //    .HasKey(x => new { x.AppUserId, x.UserRoleId });
            //modelBuilder.Entity<UsersRolesMap>()
            //    .HasOne(x => x.AppUser)
            //    .WithMany(m => m.Roles)
            //    .HasForeignKey(x => x.AppUserId);
            //modelBuilder.Entity<UsersRolesMap>()
            //    .HasOne(x => x.UserRole)
            //    .WithMany(e => e.AppUsers)
            //    .HasForeignKey(x => x.UserRoleId);
        }

    }
}
