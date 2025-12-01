using NetCord.Services.Commands;

namespace ChadBot.Modules
{
    public class BirthdayModule : CommandModule<CommandContext>
    {
        [Command("list")]
        public async Task<string> ListAsync()
        {
            return "This is a test for birthdays";
        }
    }
}
