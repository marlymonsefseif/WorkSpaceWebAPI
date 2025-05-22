using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;
using WorkSpaceWebAPI.Repository;

namespace WorkSpaceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly WorkSpaceDbContext _context;
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(WorkSpaceDbContext context, IReviewRepository reviewRepository)
        {
            _context = context;
            _reviewRepository = reviewRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ReviewDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var review = new Review
            {
                UserId = dto.UserId,
                RoomId = dto.RoomId,
                Rating = dto.Rating,
                Comment = dto.Comment,
                CreatedAt = DateTime.UtcNow
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Review added successfully!" });
        }

        [HttpGet("room/{roomId}")]
        public async Task<IActionResult> GetReviewsForRoom(int roomId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.RoomId == roomId)
                .Include(r => r.User)
                .ToListAsync();

            return Ok(reviews);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewDTO dto)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
                return NotFound(new { message = "Review not found" });

            review.Rating = dto.Rating;
            review.Comment = dto.Comment;
            review.RoomId = dto.RoomId;
            review.UserId = dto.UserId;
            review.CreatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Review updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
                return NotFound(new { message = "Review not found" });

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Review deleted successfully" });
        }

        [HttpGet("UserReview")]
        public IActionResult GetUserReviews()
        {
            List<ReviewDTO> reviews = _reviewRepository.GetReviews();
            return Ok(reviews);
        }
    }
}
