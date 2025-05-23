using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        public List<ReviewDTO> GetReviews();
    }
}
