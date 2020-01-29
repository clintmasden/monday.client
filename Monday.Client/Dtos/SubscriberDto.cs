using Newtonsoft.Json;

namespace Monday.Client.Dtos
{
    public class SubscriberDto
    {
        [JsonProperty("user_id")] public int UserId { get; set; }

        [JsonProperty("as_admin")] public int AsAdmin { get; set; }
    }
}