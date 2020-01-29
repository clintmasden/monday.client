using System;
using Monday.Client.Extensions;
using Newtonsoft.Json;

namespace Monday.Client.Models
{
    public class BoardColumn
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("type")] public string Value { get; set; }

        public BoardColumnEnums Type
        {
            get
            {
                BoardColumnEnums type;

                if (Enum.TryParse(Value.FirstCharToUpper(), out type))
                {
                    return type;
                }

                return BoardColumnEnums.Other;
            }
        }

        [JsonProperty("labels")] public dynamic Labels { get; set; }

        [JsonProperty("width")] public float Width { get; set; }

        [JsonProperty("unit")] public BoardUnit Unit { get; set; }
    }
}