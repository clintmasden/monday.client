using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class BoardColumnNumericDto
    {
        [JsonProperty("pulse_id")] public int PulseId { get; set; }

        [JsonProperty("value")] public int Value { get; set; }
    }
}