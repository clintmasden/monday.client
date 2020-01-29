using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class BoardColumnTextDto
    {
        [JsonProperty("pulse_id")] public int PulseId { get; set; }

        [JsonProperty("text")] public string Text { get; set; }
    }
}