using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class BoardColumnPersonDto
    {
        [JsonProperty("pulse_id")] public int PulseId { get; set; }

        [JsonProperty("user_id")] public int UserId { get; set; }
    }
}