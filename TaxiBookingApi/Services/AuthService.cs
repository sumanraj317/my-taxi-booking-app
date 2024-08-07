using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;
using TaxiBookingApi.Models;
using TaxiBookingApi.Data;

namespace TaxiBookingApi.Services
{
    public class AuthService
    {
        private readonly MongoDBContext _context;

        public AuthService(MongoDBContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User user)
        {
            var existingUser = _context.Users.Find(u => u.Email == user.Email).FirstOrDefault();
            if (existingUser != null)
            {
                return null; // User already exists
            }

            await _context.Users.InsertOneAsync(user);
            return user;
        }

        public User Login(string email, string password)
        {
            return _context.Users.Find(u => u.Email == email && u.Password == password).FirstOrDefault();
        }
    }
}
