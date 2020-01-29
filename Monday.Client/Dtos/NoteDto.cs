using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class NoteDto
    {
        [JsonProperty("user_id")] public int UserId { get; set; }

        [JsonProperty("title")] public string NoteTitle { get; set; }

        [JsonProperty("content")] public string NoteText { get; set; }

        [JsonProperty("owners_only")] public bool Locked { get; set; }

        [JsonProperty("create_update")] public bool CreateUpdate { get; set; }
    }
}