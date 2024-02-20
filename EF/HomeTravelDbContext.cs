using HomeTravelAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HomeTravelAPI.EF
{
    public class HomeTravelDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public HomeTravelDbContext(DbContextOptions<HomeTravelDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<HomeStay> HomeStays { get; set; }
        public DbSet<ImageHome> ImageHomes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<AppRole> Role { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Policy> Policy { get; set; }
    }
}
