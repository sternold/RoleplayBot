using Discord;
using System;
using System.Text.RegularExpressions;
using RoleplayBot.Character.Persistence;
using RoleplayBot.Dice;
using System.Threading.Tasks;

namespace RoleplayBot.Bot
{
    public class DiscordBot
    {
        private DiscordClient client;
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
        public void Run()
        {
            client = new DiscordClient();

            client.MessageReceived += async (sender, eventargs) =>
            {
                if (!eventargs.Message.IsAuthor)
                {
                    Console.WriteLine("Recieved: " + eventargs.Message.Text);
                    await ParseQuery(eventargs);
                }
            };

            client.ExecuteAndWait(async () => await client.Connect(token, TokenType.Bot));
        }

        public async Task<Message> ParseQuery(MessageEventArgs eventargs)
        {
            string[] args = eventargs.Message.Text.Split(' ');
            if(args.Length < 1)
            {
                return null;
            }
            switch (args[0].ToLower())
            {
                case "!roll":
                    var roll = DiceRoller.GenerateRollString(args);
                    return await eventargs.Channel.SendMessage(roll);
                case "!char":
                    return await eventargs.Channel.SendMessage("Character " + args[1] + ((CharactersheetController.AddCharactersheet(args[1])) ? " created!" : " could not be created"));
                default:
                    return null;                     
            }
        }
    }
}
