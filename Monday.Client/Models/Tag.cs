﻿using System;
using Newtonsoft.Json;

namespace Monday.Client.Models
{
    public class Tag
    {
        public string Url { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")] public DateTime UpdatedAt { get; set; }
    }
}