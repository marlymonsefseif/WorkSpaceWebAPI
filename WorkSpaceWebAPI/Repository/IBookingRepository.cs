using System.Linq.Expressions;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        IQueryable<Booking> Get(Expression<Func<Booking, bool>> expression);
        IQueryable<Booking> GetByStartTime(TimeOnly startTime);
    }
}
