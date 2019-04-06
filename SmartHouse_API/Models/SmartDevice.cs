using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartHouse_API.Models
{
    public class SmartDevice
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public Type Type { get; set; }
        public string Name { get; set; }
        public State State{ get; set; }
        public Localization Localization { get; set; }
        public bool Disabled { get; set; }
    }
}