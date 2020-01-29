using Newtonsoft.Json;

namespace Monday.Client.Models
{
    public class BoardMeta
    {
        public double Position { get; set; }

        [JsonProperty("group_id")] public string GroupId { get; set; }
    }
}