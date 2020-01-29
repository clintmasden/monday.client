using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class GroupMoveDto
    {
        [JsonProperty("user_id")] public int UserId { get; set; }

        [JsonProperty("dest_board_id")] public int DestinationBoardId { get; set; }
    }
}