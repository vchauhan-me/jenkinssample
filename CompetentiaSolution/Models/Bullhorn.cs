using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CompetentiaSolution.Models
{
    public class Bullhorn
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Key]
        [BsonElement("BullhornId")]
        public string BullhornId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Mobile")]
        public string Mobile { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("JobTitle")]
        public string JobTitle { get; set; }

        [BsonElement("CurrentCompany")]
        public string CurrentCompany { get; set; }

        [BsonElement("DateAvailable")]
        public string DateAvailable { get; set; }
    }
}