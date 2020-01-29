using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class BoardColumnTagDto
    {
        [JsonProperty("pulse_id")] public int PulseId { get; set; }

        [JsonProperty("tags")] public string Tags { get; set; }
    }
}