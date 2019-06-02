using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SmartHouse_API.Models
{
    public class SmartDevice
    {
        [BsonId]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Localization { get; set; }
        public bool Disabled { get; set; }

        public string State { get; set; }
    }

    public class ObjectIdConverter : JsonConverter
    {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is ObjectId)
            {
                var objectId = (ObjectId)value;

                writer.WriteValue(objectId != ObjectId.Empty ? objectId.ToString() : String.Empty);
            }
            else
            {
                throw new Exception("Expected ObjectId value.");
            }

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;
            return String.IsNullOrEmpty(value) ? ObjectId.Empty : new ObjectId(value);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ObjectId).IsAssignableFrom(objectType);
            //return true;
        }


    }
}