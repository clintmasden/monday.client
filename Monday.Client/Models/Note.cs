using System;
using Newtonsoft.Json;

namespace Monday.Client.Models
{
    public class Note
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        [JsonProperty("project_id")] public string ProjectId { get; set; }

        public string Permissions { get; set; }

        [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")] public DateTime UpdatedAt { get; set; }
    }
}