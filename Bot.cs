using Discord;
using System;

namespace RoleplayBot
{
    public class Bot
    {
        private DiscordClient client;

        public Bot()
        {

        }

        public void Run()
        {
            client = new DiscordClient();

            client.MessageReceived += async (sender, eventargs) =>
            {
                if (!eventargs.Message.IsAuthor && eventargs.Message.Text.Split(' ')[0] == "!roll")
                {
                    await eventargs.Channel.SendMessage("You rolled a " + new Random().Next(1,20));
                }
            };

            client.ExecuteAndWait(async () => await client.Connect(null , TokenType.Bot));
        }
    }
}
