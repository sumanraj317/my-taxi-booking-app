using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaxiBookingApi.Models;

namespace TaxiBookingApi.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<TaxiBooking> Bookings => _database.GetCollection<TaxiBooking>("TaxiBookings");
    }

    public class MongoSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
