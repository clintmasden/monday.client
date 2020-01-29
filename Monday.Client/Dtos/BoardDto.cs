using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class BoardDto
    {
        public enum BoardTypes
        {
            Public,
            Shareable,
            Private
        }

        [JsonProperty("user_id")] public int UserId { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        public BoardTypes BoardType { get; set; }

        [JsonProperty("board_kind")] private string BoardKind => BoardType.ToString();
    }
}