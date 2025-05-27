using System.Linq.Expressions;
using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public class BookingRepository : IBookingRepository
    {
        WorkSpaceDbContext context;
        public BookingRepository(WorkSpaceDbContext context) 
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

        public IQueryable<BookingDTO> Get(Expression<Func<Booking, bool>> expression)
        {
            return context.Bookings.Where(expression).Select(b => new BookingDTO()
            {
                Id = b.Id,
                UserId = b.User.Id,
                UserName = b.User.ToString(),
                ZoneId = b.ZoneId,
                ZoneName = b.zone.Name,
                StartTime = b.StartTime,
                EndTime = b.EndTime,
                Amount = b.Amount,
                status = b.status,
            });
        }

        public List<Booking> GetAll()
        {
            return context.Bookings.ToList();
        }

        public Booking GetById(int id)
        {
            return context.Bookings.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Booking> GetByStartTime(TimeOnly startTime)
        {
            return context.Bookings.Where(x => x.StartTime == startTime);
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
