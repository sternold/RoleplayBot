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
            if(config.Get("Token") == null){
                config.Put("Token", string.Empty);
                System.Environment.Exit(0);
            }else{
                var bot = new Bot(config.Get("Token"));
            bot.Run();
            }
        }
    }
}
