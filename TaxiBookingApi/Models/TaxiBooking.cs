using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TaxiBookingApi.Models
{
    public class TaxiBooking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("pickupLocation")]
        public string PickupLocation { get; set; }

        [BsonElement("dropLocation")]
        public string DropLocation { get; set; }

        [BsonElement("pickupTime")]
        public DateTime PickupTime { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }
    }
}
