using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiBookingApi.Models;
using TaxiBookingApi.Services;

namespace TaxiBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookTaxi([FromBody] TaxiBooking booking)
        {
            var newBooking = await _bookingService.BookTaxi(booking);
            return Ok(newBooking);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserBookings(string userId)
        {
            var bookings = await _bookingService.GetUserBookings(userId);
            return Ok(bookings);
        }
    }
}
