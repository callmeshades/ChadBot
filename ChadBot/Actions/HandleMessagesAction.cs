using ChadBot.Core;
using ChadBot.Core.Data;
using NetCord.Gateway;
using NetCord.Services;
using NetCord.Services.Commands;

namespace ChadBot.Actions
{
    public class HandleMessagesAction
    {
        /// <summary>
        /// HandleMessageAction will execute and handle messages as they are created.
        /// It checks that the message is intended for the bot.
        /// If we fail to find a command or execute a command, we return the error that occured.
        /// </summary>
        public static void Execute(ApplicationConfig config, GatewayClient client, CommandService<MainCommandContext> service, MainContext context)
        {
            client.MessageCreate += async message =>
            {
                /**
                 * Check if the message is a command with the specific prefix.
                 * Also check the message is not from a bot
                 */
                if (!message.Content.StartsWith(config.BotPrefix) || message.Author.IsBot)
                    return;

                /**
                 * Execute the command
                 */
                var result = await service.ExecuteAsync(prefixLength: 1, new MainCommandContext(client, message, context));

                /*
                 * Check if the execution failed
                 */
                if (result is not IFailResult failResult)
                    return;

                /**
                 * Return the error message to the user if the execution failed
                 */
                try
                {
                    await message.ReplyAsync(failResult.Message);
                }
                catch
                {
                }
            };
        }
    }
}
