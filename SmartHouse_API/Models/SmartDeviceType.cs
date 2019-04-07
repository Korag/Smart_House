using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SmartHouse_API.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Type
    {
        type1,
        type2,
        type3,
        type4
    }
}