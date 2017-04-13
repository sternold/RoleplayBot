using Discord;
using System;
using System.Text.RegularExpressions;
using RoleplayBot.Character.Persistence;
using RoleplayBot.Dice;

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
                    ParseQuery(eventargs);
                }
            };

            client.ExecuteAndWait(async () => await client.Connect(token, TokenType.Bot));
        }

        public async void ParseQuery(MessageEventArgs eventargs)
        {
            string[] args = eventargs.Message.Text.Split(' ');

            switch (args[0].ToLower())
            {
                case "!roll":
                    var roll = DiceRoller.GenerateRollString(args);
                    await eventargs.Channel.SendMessage(roll);
                    break;
                case "!char":
                    if (CharactersheetController.AddCharactersheet(args[1]))
                    {
                        await eventargs.Channel.SendMessage("Character " + args[1] + " created!");
                    }
                    break;
            }
        }
    }
}
