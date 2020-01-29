using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Monday.Client.Models
{
    public class Pulse
    {
        public int Id { get; set; }

        [JsonProperty("board_id")] public int BoardId { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public List<User> Subscribers { get; set; }

        [JsonProperty("updates_count")] public int UpdatesCount { get; set; }

        [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")] public DateTime UpdatedAt { get; set; }
    }
}