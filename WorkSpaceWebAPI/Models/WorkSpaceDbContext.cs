using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WorkSpaceWebAPI.Models
{
    public class WorkSpaceDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public WorkSpaceDbContext() { }
        public WorkSpaceDbContext(DbContextOptions<WorkSpaceDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Spaces> Spaces { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<SpaceAmenity> SpaceAmenities { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<MembershipPlan> MembershipPlans { get; set; }
        public DbSet<UserMembership> UserMemberships { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpaceAmenity>()
                .HasKey(s => new {s.SpaceId,s.AmenityId});
            modelBuilder.Entity<SpaceAmenity>()
                .HasOne(sa => sa.Space)
                .WithMany(s => s.SpaceAmenities)
                .HasForeignKey(sa => sa.SpaceId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<SpaceAmenity>()
                .HasOne(sa => sa.Amenity)
                .WithMany(a=>a.SpaceAmenities)
                .HasForeignKey(sa => sa.AmenityId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
          

          

        
           
        }
    }
}
