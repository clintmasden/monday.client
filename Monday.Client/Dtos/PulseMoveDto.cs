using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class PulseMoveDto
    {
        [JsonProperty("user_id")] public int UserId { get; set; }

        [JsonProperty("dest_board_id")] public int DestinationBoardId { get; set; }

        [JsonProperty("group_id")] public string GroupId { get; set; }

        [JsonProperty("pulse_ids")] public string PulseIds { get; set; }

        [JsonProperty("force_move_to_board")] public bool Force { get; set; }
    }
}