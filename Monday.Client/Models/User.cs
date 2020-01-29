using System;
using Newtonsoft.Json;

namespace Monday.Client.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Url { get; set; }

        [JsonProperty("photo_url")] public string PhotoUrl { get; set; }

        public object Title { get; set; }

        public object Position { get; set; }

        public string Phone { get; set; }

        public object Location { get; set; }

        public object Status { get; set; }

        public object Birthday { get; set; }

        [JsonProperty("is_guest")] public bool IsGuest { get; set; }

        [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")] public DateTime UpdatedAt { get; set; }
    }
}