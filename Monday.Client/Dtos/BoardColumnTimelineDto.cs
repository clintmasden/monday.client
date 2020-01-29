using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class BoardColumnTimelineDto
    {
        [JsonProperty("pulse_id")] public int PulseId { get; set; }

        [JsonProperty("from")] public string InDate { get; set; }

        [JsonProperty("to")] public string OutDate { get; set; }
    }
}