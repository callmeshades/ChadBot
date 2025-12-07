using ChadBot.Core.Data;
using NetCord.Gateway;
using NetCord.Services.Commands;

namespace ChadBot.Core
{
    public class MainCommandContext : CommandContext
    {
        public MainContext Main { get; }

        public MainCommandContext(GatewayClient client, Message message, MainContext main) : base(message, client)
        {
            Main = main;
        }
    }
}
