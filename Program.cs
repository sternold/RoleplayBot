using System;

namespace RoleplayBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting RoleplayBot");
            var bot = new Bot();
            bot.Run();
        }
    }
}
