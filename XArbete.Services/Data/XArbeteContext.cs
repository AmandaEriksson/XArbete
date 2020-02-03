using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XArbete.Domain.Models;

namespace XArbete.Services.Data
{
    public class XArbeteContext : IdentityDbContext<ApplicationUser>
    {
        public XArbeteContext(DbContextOptions<XArbeteContext> options) : base(options)
        {

        }
        public DbSet<KennelDog> KennelDogs { get; set; }

        public DbSet<PuppyGroup> PuppyGroups { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerDog> CustomerDogs { get; set; }

        public DbSet<TrainingHallBooking> TrainingHallBookings { get; set; }

        public DbSet<HotelBooking> HotelBookings { get; set; }

        public DbSet<GuestBookComment> GuestbookComments { get; set; }
        public DbSet<Puppy> Puppies { get; set; }

        public DbSet<Content> Contents { get; set; }

        public DbSet<ContentSection> ContentSections { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CustomerCourse> CustomerCourses { get; set; }


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
