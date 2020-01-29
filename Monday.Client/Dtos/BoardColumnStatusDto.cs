using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class BoardColumnStatusDto
    {
        [JsonProperty("pulse_id")] public int PulseId { get; set; }

        [JsonProperty("color_index")] public int ColorId { get; set; }
    }
}