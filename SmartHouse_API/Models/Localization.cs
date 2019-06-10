using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using SmartHouse_API.App_Start.JsonConverterConfigs;

namespace SmartHouse_API.Models
{
    public class Localization
    {
        [BsonId]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}