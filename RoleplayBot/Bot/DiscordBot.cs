using Discord;
using System;
using System.Text.RegularExpressions;
using RoleplayBot.Character.Persistence;
using RoleplayBot.Dice;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Rest;

namespace RoleplayBot.Bot
{
    public class DiscordBot
    {
        private DiscordSocketClient client;
        private string token = null;

        /// <summary>
        /// RPB's main parsing class.
        /// </summary>
        /// <param name="token">The token recieved from Discord</param>
        public DiscordBot(string token)
        {
            this.token = token;
        }

        /// <summary>
        /// Start listening to messages on discord.
        /// </summary>
        public async Task Run()
        {
            client = new DiscordSocketClient();

            client.Log += Log;
            client.MessageReceived += async (message) =>
            {
                if (!message.Author.IsBot)
                {
                    await Log(new LogMessage(LogSeverity.Info, message.Author.Username, message.Content));
                    await ParseQuery(message);
                }
            };

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            await Task.Delay(-1);
        }

        public async Task ParseQuery(SocketMessage message)
        {
            string[] args = message.Content.Split(' ');
            switch (args[0].ToLower())
            {
                case "!roll":
                    var roll = DiceRoller.GenerateRollString(args);
                    await message.Channel.SendMessageAsync(roll);
                    break;
                case "!char":
                    await message.Channel.SendMessageAsync("Character " + args[1] + ((CharactersheetController.AddCharactersheet(args[1])) ? " created!" : " could not be created"));
                    break;
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}