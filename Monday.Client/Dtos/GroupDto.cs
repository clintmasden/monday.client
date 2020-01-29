using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class GroupDto
    {
        [JsonProperty("group_id")] public string GroupId { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("color")] public string Color { get; set; }
    }
}