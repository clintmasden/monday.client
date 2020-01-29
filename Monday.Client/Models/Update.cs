using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Monday.Client.Models
{
    public class Update
    {
        public int Id { get; set; }

        [JsonProperty("pulse_id")] public int PulseId { get; set; }

        [JsonProperty("user_id")] public int UserId { get; set; }

        public User User { get; set; }

        public string Url { get; set; }

        public string Body { get; set; }

        public string Kind { get; set; }

        [JsonProperty("has_assets")] public bool HasAssets { get; set; }

        public List<object> Assets { get; set; }

        [JsonProperty("body_text")] public string BodyText { get; set; }

        public List<object> Replies { get; set; }

        [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")] public DateTime UpdatedAt { get; set; }
    }
}