using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class PulseDto
    {
        [JsonProperty("id")] public int PulseId { get; set; }

        [JsonProperty("user_id")] public int UserId { get; set; }

        [JsonProperty("pulse")] public PulseProperties Pulse { get; set; }

        [JsonProperty("update")] public UpdateProperties Update { get; set; }

        [JsonProperty("group_id")] public string GroupId { get; set; }

        [JsonProperty("add_to_bottom")] public bool AddToBottom { get; set; }

        public class PulseProperties
        {
            [JsonProperty("name")] public string Name { get; set; }

            // 500 Error on Server
            //[JsonProperty("photo_from_url")]
            //public string PhotoUrl { get; set; }
        }

        public class UpdateProperties
        {
            [JsonProperty("text")] public string Text { get; set; }
        }
    }
}