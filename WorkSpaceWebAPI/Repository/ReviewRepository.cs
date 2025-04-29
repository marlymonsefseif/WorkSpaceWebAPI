using Microsoft.EntityFrameworkCore;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly WorkSpaceDbContext _context;

        public ReviewRepository(WorkSpaceDbContext context)
        {
            _context = context;
        }

        public List<Review> GetAll()
        {
            return _context.Reviews
                .Include(r => r.User)
                .Include(r => r.space)
                .ToList();
        }

        public Review GetById(int id)
        {
            return _context.Reviews
                .Include(r => r.User)
                .Include(r => r.space)
                .FirstOrDefault(r => r.Id == id);
        }

        public void Insert(Review entity)
        {
            entity.CreatedAt = DateTime.Now;
            _context.Reviews.Add(entity);
        }

        public void Update(Review entity)
        {
            _context.Reviews.Update(entity);
        }

        public void Delete(Review entity)
        {
            _context.Reviews.Remove(entity);
        }

        public void DeleteById(int id)
        {
            var review = GetById(id);
            if (review != null)
                Delete(review);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
