using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class UpdateDto
    {
        [JsonProperty("user")] public int UserId { get; set; }

        [JsonProperty("pulse")] public int PulseId { get; set; }

        [JsonProperty("update_text")] public string Text { get; set; }
    }
}