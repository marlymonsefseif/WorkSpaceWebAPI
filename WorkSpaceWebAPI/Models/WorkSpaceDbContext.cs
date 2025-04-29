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
            modelBuilder
                .Entity<Spaces>()
                .HasData(
                new Spaces
                {
                     Id = 1,
                     Name = "StudyRoom 1",
                     Description = "Room To Study",
                     Capacity = 50,
                     PricePerHour = 20,
                     AvailableFrom = TimeSpan.FromHours(8),
                     AvailableTo = TimeSpan.FromHours(16),
                     IsAvailable = true,
                     SpaceType = SpaceTypes.StudySpace
                },
                new Spaces
                {
                    Id = 2,
                    Name = "ITI Lab",
                    Description = "Lab for practice",
                    Capacity = 30,
                    PricePerHour = 25,
                    AvailableFrom = TimeSpan.FromHours(9),
                    AvailableTo = TimeSpan.FromHours(17),
                    IsAvailable = true,
                    SpaceType = SpaceTypes.TechLab
                },
                new Spaces
                {
                    Id = 3,
                    Name = "Meeting Room A",
                    Description = "Team meetings",
                    Capacity = 10,
                    PricePerHour = 15,
                    AvailableFrom = TimeSpan.FromHours(10),
                    AvailableTo = TimeSpan.FromHours(14),
                    IsAvailable = false,
                    SpaceType = SpaceTypes.MeetingRoom
                },
                new Spaces
                {
                    Id = 4,
                    Name = "Workshop Hall",
                    Description = "Events and workshops",
                    Capacity = 100,
                    PricePerHour = 50,
                    AvailableFrom = TimeSpan.FromHours(9),
                    AvailableTo = TimeSpan.FromHours(18),
                    IsAvailable = true,
                    SpaceType = SpaceTypes.EventSpace
                },
                new Spaces
                {
                    Id = 5,
                    Name = "Silent Study Room",
                    Description = "For focused study",
                    Capacity = 20,
                    PricePerHour = 10,
                    AvailableFrom = TimeSpan.FromHours(7),
                    AvailableTo = TimeSpan.FromHours(22),
                    IsAvailable = true,
                    SpaceType = SpaceTypes.StudySpace
                }
                );

            modelBuilder.Entity<Review>().HasData(
            new Review
            {
                Id = 1,
                UserId = 1,
                RoomId = 1,
                Rating = 5,
                Comment = "Amazing place, very comfortable for studying!",
                CreatedAt = DateTime.UtcNow
            },
            new Review
            {
                Id = 2,
                UserId = 2,
                RoomId = 2,
                Rating = 4,
                Comment = "Nice, but could be a bit quieter.",
                CreatedAt = DateTime.UtcNow
            } );

            // Seed Data for Contact Messages
            modelBuilder.Entity<ContactMessage>().HasData(
                new ContactMessage
                {
                    Id = 1,
                    FullName = "Ahmed Ali",
                    Email = "ahmed@example.com",
                    Subject = "Inquiry about rooms",
                    Message = "Can I get the pricing details and booking information?",
                    CreatedAt = DateTime.UtcNow
                },
                new ContactMessage
                {
                    Id = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara@example.com",
                    Subject = "Issue with booking",
                    Message = "I booked a room but didn’t receive a confirmation. Can you contact me?",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
