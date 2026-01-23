using ChadBot.Core;
using ChadBot.Models.WatchParty;
using Microsoft.Extensions.DependencyInjection;
using NetCord.Services.Commands;
using System.Text.Json;

namespace ChadBot.Modules
{
    [Command("watchparty")]
    public class WatchPartyModule : CommandModule<MainCommandContext>
    {
        private const string Url = "https://www.watchparty.me";

        [Command("create")]
        public async Task<string> GetAsync()
        {
            var httpClient = Context.Services.GetRequiredService<HttpClient>();

            var resp = await httpClient.PostAsync($"{Url}/createRoom", null);
            var content = await resp.Content.ReadAsStreamAsync();
            var json = await JsonSerializer.DeserializeAsync<CreateRoomResponse>(content);

            if (json == null)
            {
                return "Failed to create a room :(";
            }

            var finalUrl = $"{Url}/watch{json.Name}";

            return $"Created the room for you. Here you are: {finalUrl}";
        }
    }
}
