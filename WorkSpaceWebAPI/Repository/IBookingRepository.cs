using System.Linq.Expressions;
using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        IQueryable<BookingDTO> Get(Expression<Func<Booking, bool>> expression);
        IQueryable<Booking> GetByStartTime(TimeOnly startTime);
    }
}
