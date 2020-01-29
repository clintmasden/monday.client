using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class BoardColumnDateDto
    {
        [JsonProperty("pulse_id")] public int PulseId { get; set; }

        [JsonProperty("date_str")] public string Date { get; set; }
    }
}