using System;
using System.IO;

namespace RoleplayBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting RoleplayBot");

            Config config = new Config("config.conf");
            if(config.Get("Token") == null)
            {
                Console.WriteLine("The config file does not contain the 'Token' key. Add a token to the config file to continue...");
                config.Put("Token", string.Empty);
                Console.ReadKey();
                System.Environment.Exit(0);
            }else
            {
                var bot = new Bot(config.Get("Token"));
                bot.Run();
            }
        }
    }
}
