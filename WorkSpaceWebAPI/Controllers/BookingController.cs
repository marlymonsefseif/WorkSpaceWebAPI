using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;
using WorkSpaceWebAPI.Repository;

namespace WorkSpaceWebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository bookingRepository;
        public BookingController(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Booking> bookings = bookingRepository.GetAll();
            return Ok(bookings);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            Booking booking = bookingRepository.GetById(id);
            if(booking == null) 
                return NotFound();
            return Ok(booking);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetPending")]
        public IActionResult GetPending()
        {
            List<Booking> bookings = bookingRepository.Get(b => b.status == Status.Pending).ToList();
            if (bookings == null)
                return NotFound();
            return Ok(bookings);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetCancelled")]
        public IActionResult GetCancelled()
        {
            List<Booking> bookings = bookingRepository.Get(b => b.status == Status.Cancelled).ToList();
            if (bookings == null)
                return NotFound();
            return Ok(bookings);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetConfirmed")]
        public IActionResult GetConfirmed()
        {
            List<Booking> bookings = bookingRepository.Get(b => b.status == Status.Confirmed).ToList();
            if (bookings == null)
                return NotFound();
            return Ok(bookings);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetByStartTime")]
        public IActionResult GetByStartTime(TimeOnly startTime)
        {
            List<Booking> bookings = bookingRepository.Get(b => b.StartTime == startTime).ToList();
            if(bookings == null) 
                return NotFound();
            return Ok(bookings);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(BookingDTO bookingDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Booking booking = new Booking
                    {
                        Date = DateTime.Now,
                        Amount = bookingDTO.Amount,
                        StartTime = bookingDTO.StartTime,
                        status = Status.Pending,
                        EndTime = bookingDTO.EndTime,
                        UserId = bookingDTO.UserId,
                        ZoneId = bookingDTO.ZoneId
                    };
                    bookingRepository.Insert(booking);
                    bookingRepository.Save();
                    return Created();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.InnerException.Message);
                }
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id:int}")]
        public IActionResult Edit(int id, BookingDTO bookingDTO)
        {
            if (ModelState.IsValid)
            {
                Booking booking = bookingRepository.GetById(id);
                if (booking == null)
                    return NotFound();
                if (Enum.IsDefined(typeof(Status), bookingDTO.status))
                {
                    try
                    {
                        booking.StartTime = bookingDTO.StartTime;
                        booking.EndTime = bookingDTO.EndTime;
                        booking.Amount = bookingDTO.Amount;
                        booking.status = (Status)Enum.ToObject(typeof(Status), bookingDTO.status);
                        booking.UserId = bookingDTO.UserId;
                        booking.ZoneId = bookingDTO.ZoneId;
                        bookingRepository.Update(booking);
                        bookingRepository.Save();
                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.InnerException.Message);
                    }
                }
                return BadRequest();    
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Booking booking = bookingRepository.GetById(id);
            if(booking == null)
                return NotFound();
            bookingRepository.DeleteById(id);
            bookingRepository.Save();
            return Ok();
        }
    }
}
