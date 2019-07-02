using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AzureApiApp.Models
{
    public class CompetentiaDoc
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MongoId { get; set; }

        [BsonElement("Id")]
        public string Id { get; set; }

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