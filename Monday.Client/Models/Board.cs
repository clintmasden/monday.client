using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Monday.Client.Models
{
    public class Board
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<BoardColumn> Columns { get; set; }

        [JsonProperty("board_kind")] public string BoardKind { get; set; }

        public List<BoardGroup> Groups { get; set; }

        [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")] public DateTime UpdatedAt { get; set; }
    }
}