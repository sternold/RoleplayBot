using Discord;
using System;
using System.Text.RegularExpressions;

namespace RoleplayBot
{
    public class Bot
    {
        private DiscordClient client;
        private string token = null;

        public Bot(string token)
        {
            this.token = token;
        }

        public void Run()
        {
            client = new DiscordClient();

            client.MessageReceived += async (sender, eventargs) =>
            {
                if (!eventargs.Message.IsAuthor && eventargs.Message.Text.Split(' ')[0] == "!roll")
                {
                    String[] splitString = eventargs.Message.Text.Split(' ');
                    String message = "You rolled: ";
                    if (splitString.Length == 1)
                    {
                        message = message + new Random().Next(1, 20);
                    }
                    else if (splitString.Length > 1) 
                    {
                        Regex regex = new Regex("\\d+d\\d+");
                        String arguments = eventargs.Message.Text.Split(' ')[1].Trim();
                        Match match = regex.Match(arguments);
                        // Below code might not work due to equals vs ==
                        if (!match.Equals(Match.Empty))
                        {
                            String substring = match.ToString();
                            int dice = Int32.Parse(new Regex("\\d+").Matches(substring)[0].ToString());
                            int capacity = Int32.Parse(new Regex("\\d+").Matches(substring)[1].ToString());

                            if (dice > 500 || capacity > 1000) 
                            {
                                message = "Error! You may only roll a maximum of 500d1000.";
                            } 
                            else 
                            {
                                int total = 0;
                                Random random = new Random();

                                for (int i = 0; i < dice; i++) 
                                {
                                    int newRoll = random.Next(1, capacity);
                                    total += newRoll;
                                    message += newRoll + " ";
                                }

                                message += "; Total: " + total;
                            }
                        }
                        else 
                        {
                            message = message + new Random().Next(1, 20);
                        }
                    }
                    await eventargs.Channel.SendMessage(message);
                }
            };

            client.ExecuteAndWait(async () => await client.Connect(token, TokenType.Bot));
        }
    }
}
