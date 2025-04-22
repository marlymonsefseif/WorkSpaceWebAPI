using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public class BookingRepo : IBookingRepo
    {
        ApplicationDbContext context;
        public BookingRepo(ApplicationDbContext context) 
        {
            this.context = context;
        }
        public void Delete(Booking entity)
        {
            if (entity != null)
            {
                context.Bookings.Remove(entity);
            }
        }

        public void DeleteById(int id)
        {
            Booking item = GetById(id);
            if (item != null)
            {
                context.Bookings.Remove(item);
            }
        }

        public List<Booking> GetAll()
        {
            return context.Bookings.ToList();
        }

        public Booking GetById(int id)
        {
            return context.Bookings.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Booking entity)
        {
            context.Bookings.Add(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Booking entity)
        {
            context.Update(entity);
        }
    }
}
