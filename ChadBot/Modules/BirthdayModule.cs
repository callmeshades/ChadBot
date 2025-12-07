using ChadBot.Core;
using Microsoft.EntityFrameworkCore;
using NetCord;
using NetCord.Services.Commands;

namespace ChadBot.Modules
{
    public class BirthdayModule : CommandModule<MainCommandContext>
    {
        [Command("list")]
        public async Task<string> ListAsync()
        {
            var user = (GuildUser)Context.User;
            if (user == null)
            {
                return "Failed to fetch your information";
            }


            return $"Who run it";
        }
    }
}
