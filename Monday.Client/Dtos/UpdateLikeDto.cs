using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class UpdateLikeDto
    {
        [JsonProperty("user")] public int UserId { get; set; }
    }
}