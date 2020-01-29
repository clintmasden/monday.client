using Newtonsoft.Json;

namespace Monday.Client.Models
{
    public class BoardUnit
    {
        public string Symbol { get; set; }

        [JsonProperty("custom_unit")] public string CustomUnit { get; set; }

        public string Direction { get; set; }
    }
}