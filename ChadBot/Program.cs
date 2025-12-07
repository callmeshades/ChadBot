using NetCord;
using NetCord.Gateway;
using NetCord.Logging;
using NetCord.Services.Commands;
using dotenv.net;
using ChadBot.Actions;
using ChadBot.Core;
using ChadBot.Core.Data;

DotEnv.Load();

string? botToken = Environment.GetEnvironmentVariable("BOT_TOKEN");
string? botPrefix = Environment.GetEnvironmentVariable("BOT_PREFIX");

if (botToken == null)
{
    throw new NullReferenceException("The BOT_TOKEN is required");
}

if (botPrefix == null)
{
    throw new NullReferenceException("The BOT_PREFIX is required");
}

var config = new ApplicationConfig
{
    BotPrefix = botPrefix,
    BotToken = botToken
};


/**
 * Create the GatewayClient for Discord
 */
GatewayClient client = new GatewayClient(
    new BotToken(botToken),
    new GatewayClientConfiguration
    {
        Intents = GatewayIntents.GuildMessages | GatewayIntents.DirectMessages | GatewayIntents.MessageContent,
        Logger = new ConsoleLogger()
    }
);

/**
 * Create the CommandService and add all modules found throughout the application
 */
var commandService = new CommandService<MainCommandContext>();
commandService.AddModules(typeof(Program).Assembly);

using var mainContext = new MainContext();

/**
 * Action to handle commands as they come in
 */
HandleMessagesAction.Execute(config, client, commandService, mainContext);

await client.StartAsync();
await Task.Delay(-1);
