using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class PulseDuplicateDto
    {
        [JsonProperty("id")] public int PulseId { get; set; }

        [JsonProperty("user_id")] public int UserId { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("photo_from_url")] public string PhotoUrl { get; set; }

        [JsonProperty("text")] public int Text { get; set; }

        [JsonProperty("group_id")] public string GroupId { get; set; }

        [JsonProperty("add_to_bottom")] public bool AddToBottom { get; set; }
    }
}