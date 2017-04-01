using System;

namespace RoleplayBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting RoleplayBot...");

            //Creates a config file containing the Discord token
            var config = new Config("config.conf");
            if(config.Get("Token") == null)
            {
                Console.WriteLine("The config file does not contain the 'Token' key. Add a token to the config file to continue...");
                config.Put("Token", string.Empty);
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                var bot = new Bot(config.Get("Token"));
                bot.Run();
            }
        }
    }
}
