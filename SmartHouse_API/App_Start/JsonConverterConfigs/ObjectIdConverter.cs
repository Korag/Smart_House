using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse_API.App_Start.JsonConverterConfigs
{
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