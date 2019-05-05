using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace SmartHouse_API.Models
{
    public class SmartDevice
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Localization { get; set; }
        public bool Disabled { get; set; }

        public string State { get; set; }
        public ICollection<string> AvailableActions { get; set; }
    }
}