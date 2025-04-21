using Microsoft.EntityFrameworkCore;

namespace WorkSpaceWebAPI.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
             
        }

        public DbSet<Spaces> Spaces { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<SpaceAmenity> SpaceAmenities { get; set; }
        //public DbSet<Gallery> Galleries { get; set; }
        //public DbSet<Booking> Bookings { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Review> Reviews { get; set; }
        //public DbSet<MemberShipPlan> MemberShipPlans { get; set; }
        //public DbSet<UserMemberShip> UserMemberShips { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<ContactMessage> ContactMessages { get; set; }
        //public DbSet<Amenity> Amenities { get; set; }
        //public DbSet<SpaceAmenity> SpaceAmenities{ get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}
