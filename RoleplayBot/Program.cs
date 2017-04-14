using System;
using RoleplayBot.Util;
using RoleplayBot.Bot;
using System.Threading.Tasks;
using Discord;

namespace RoleplayBot
{
    public class Program
    {
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            Console.WriteLine("Starting RoleplayBot...");

            //Creates a config file containing the Discord token
            var config = new Config("config");
            if(config.Get("Token") == null)
            {
                Console.WriteLine("The config file does not contain the 'Token' key. Add a token to the config file to continue...");
                config.Put("Token", string.Empty);
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                var bot = new DiscordBot(config.Get("Token"));
                await bot.Run();
            }
        }
    }
}
