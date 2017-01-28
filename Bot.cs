using Discord;
using Newtonsoft.Json;
using System;

namespace RoleplayBot
{
    public class Bot
    {
        private DiscordClient client;

        public Bot()
        {

        }

        internal void Run()
        {
            client = new DiscordClient();
            client.ExecuteAndWait(async () => await client.Connect(null /*TODO: Token*/, TokenType.Bot));
        }

    }
}