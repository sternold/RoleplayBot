using Discord;
using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

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
                if (!eventargs.Message.IsAuthor && eventargs.Message.Text[0] == '!')
                {
                    await eventargs.Channel.SendTTSMessage("Hello!");
                } 
            };

            client.ExecuteAndWait(async () => await client.Connect(null, TokenType.Bot));
        }
    }
}