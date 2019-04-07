using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SmartHouse_API.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Localization
    {
        loc1,
        loc2,
        loc3,
        loc4
    }
}