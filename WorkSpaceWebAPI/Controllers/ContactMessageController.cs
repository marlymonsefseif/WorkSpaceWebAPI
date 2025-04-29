using Microsoft.AspNetCore.Mvc;
using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMessageController : ControllerBase
    {
        private readonly WorkSpaceDbContext _context;

        public ContactMessageController(WorkSpaceDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ContactMessageDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var message = new ContactMessage
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Subject = dto.Subject,
                Message = dto.Message,
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            };

            _context.ContactMessages.Add(message);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Message sent successfully!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            var messages = _context.ContactMessages.ToList();
            return Ok(messages);
        }
    }
}
