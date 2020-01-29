using Newtonsoft.Json;

namespace Monday.Client.Models
{
    public class BoardGroup
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        [JsonProperty("board_id")] public int BoardId { get; set; }

        public bool Deleted { get; set; }

        public bool Archived { get; set; }
    }
}