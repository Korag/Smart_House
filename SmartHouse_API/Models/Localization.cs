using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartHouse_API.Models
{
    public class Localization
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}