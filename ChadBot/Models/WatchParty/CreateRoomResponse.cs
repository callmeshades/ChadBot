using System.Text.Json.Serialization;

namespace ChadBot.Models.WatchParty
{
    public class CreateRoomResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;
    }
}
