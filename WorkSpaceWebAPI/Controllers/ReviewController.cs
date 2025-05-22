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

    private ReviewDTO ToDto(Review review)
    {
        return new ReviewDTO
        {
            Id = review.Id,
            Rating = review.Rating,
            Comment = review.Comment,
            CreatedAt = review.CreatedAt,
            UserId = review.UserId,
            RoomId = review.RoomId,
            UserName = review.User?.UserName,
            RoomName = review.Room?.Name
        };
    }

    private Review ToEntity(ReviewDTO dto)
    {
        return new Review
        {
            Rating = dto.Rating,
            Comment = dto.Comment,
            UserId = dto.UserId ?? 0,
            RoomId = dto.RoomId ?? 0,
            CreatedAt = DateTime.UtcNow
        };
    }

    [HttpPost]
    public async Task<IActionResult> AddReview([FromBody] ReviewDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var review = ToEntity(dto);
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Review added successfully!" });
    }

    [HttpGet]
    public async Task<IActionResult> GetReviews()
    {
        var reviews = await _context.Reviews
            .Include(r => r.User)
            .Include(r => r.Room)
            .ToListAsync();

        var dtos = reviews.Select(r => ToDto(r)).ToList();
        return Ok(dtos);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewDTO dto)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review == null)
            return NotFound(new { message = "Review not found" });

        review.Rating = dto.Rating;
        review.Comment = dto.Comment;
        review.UserId = dto.UserId ?? review.UserId;
        review.RoomId = dto.RoomId ?? review.RoomId;
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
