using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiBookingApi.Models;
using TaxiBookingApi.Data;

namespace TaxiBookingApi.Services
{
    public class BookingService
    {
        private readonly MongoDBContext _context;

        public BookingService(MongoDBContext context)
        {
            _context = context;
        }

        public async Task<List<TaxiBooking>> GetUserBookings(string userId)
        {
            return await _context.Bookings.Find(b => b.UserId == userId).ToListAsync();
        }

        public async Task<TaxiBooking> BookTaxi(TaxiBooking booking)
        {
            await _context.Bookings.InsertOneAsync(booking);
            return booking;
        }
    }
}
