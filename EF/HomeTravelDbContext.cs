using Azure;
using HomeTravelAPI.Configurations;
using HomeTravelAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
            builder.Entity<HomeStay>().HasMany(x => x.Services).WithMany(x => x.HomeStays).UsingEntity(x => x.ToTable("HomeStay_Service"));

            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new AppRoleConfiguration());
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles").HasKey(x => new { x.UserId,x.RoleId});
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens").HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<HomeStay> HomeStays { get; set; }
        public DbSet<ImageHome> ImageHomes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Refund> Refunds { get; set; }
        public DbSet<AppRole> Role { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Policy> Policy { get; set; }
    }
}
