using System;
using Monday.Client.Extensions;
using Newtonsoft.Json;

namespace Monday.Client.Models
{
    public class BoardColumnValue
    {
        [JsonProperty("cid")] public string CId { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }

        public PulseColumnEnums Type
        {
            get
            {
                if (Enum.TryParse(CId.FirstCharToUpper(), out PulseColumnEnums type)
                    || Enum.TryParse(Title.FirstCharToUpper(), out type))
                {
                    return type;
                }

                return PulseColumnEnums.Other;
            }
        }

        [JsonProperty("value")] public dynamic Value { get; set; }
    }
}