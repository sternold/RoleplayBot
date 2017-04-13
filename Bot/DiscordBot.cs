using Discord;
using System;
using System.Text.RegularExpressions;
using RoleplayBot.Character.Persistence;

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
                    var roll = GenerateRollString(args);
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

        /// <summary>
        /// Parses a "!roll" query.
        /// </summary>
        /// <param name="splitString">An unparsed message.</param>
        /// <returns></returns>
        private string GenerateRollString(string[] splitString)
        {
            string message = "You rolled: ";
            if (splitString.Length == 1)
            {
                message = message + new Random().Next(1, 21);
            }
            else if (splitString.Length > 1)
            {
                Regex regex = new Regex("\\d+d\\d+");
                string arguments = splitString[1].Trim();
                Match match = regex.Match(arguments);

                if (!match.Equals(Match.Empty))
                {
                    string substring = match.ToString();
                    int dice = Int32.Parse(new Regex("\\d+").Matches(substring)[0].ToString());
                    int capacity = Int32.Parse(new Regex("\\d+").Matches(substring)[1].ToString()) + 1;

                    if (dice > 500 || capacity > 1000)
                    {
                        message = "Error! You may only roll a maximum of 500d1000.";
                    }
                    else
                    {
                        regex = new Regex("(-|\\+)\\d+");
                        Match modifierMatch = regex.Match(arguments);
                        int modifier = 0;
                        bool positiveModifier = true;

                        if (!modifierMatch.Equals(Match.Empty))
                        {
                            string sign = new Regex("(-|\\+)").Match(arguments).ToString();
                            if (sign.Equals("-"))
                            {
                                positiveModifier = false;
                            }
                            modifier = Int32.Parse(new Regex("\\d+").Matches(arguments)[2].ToString());
                        }
                        if (!positiveModifier)
                        {
                            modifier *= -1;
                        }

                        int total = 0;
                        Random random = new Random();

                        for (int i = 0; i < dice - 1; i++)
                        {
                            int newRoll = random.Next(1, capacity);
                            total += newRoll;
                            message += newRoll + " ";
                        }

                        int lastRoll = random.Next(1, capacity);
                        total += lastRoll;
                        message += lastRoll;
                        total += modifier;

                        message += "; Total: " + total;

                        
                        if (modifier != 0) {
                            message += " (with modifier " + modifier + ")";
                        }
                    }
                }
                else
                {
                    message = message + new Random().Next(1, 20);
                }
            }
            return message;
        }
    }
}
