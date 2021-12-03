using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoStoreAPI.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get; set;}   

        [BsonRequired]
        [BsonElement("Email")]
        public string Email {get; set;}

        [BsonRequired]
        [BsonElement("Password")]
        public string Password {get; set;}
    }
}