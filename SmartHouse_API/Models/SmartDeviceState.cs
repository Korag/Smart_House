using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SmartHouse_API.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum State
    {
        state1,
        state2,
        state3,
        state4,
        state5
    }
}