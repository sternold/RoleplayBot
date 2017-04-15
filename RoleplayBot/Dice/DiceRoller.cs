using System;
using System.Text.RegularExpressions;
using RoleplayBot.Character;

namespace RoleplayBot.Dice
{
    public static class DiceRoller
    {
        /// <summary>
        /// Parses a "!roll" query.
        /// </summary>
        /// <param name="splitString">An unparsed message.</param>
        /// <returns></returns>
        public static string GenerateRollString(string[] splitString)
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
                        regex = new Regex("(-|\\+)");
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
	                        int value = 0;
	                        if (!Int32.TryParse(arguments.Split('+', '-')[1], out value))
	                        {
		                        string[] trychar = arguments.Split('-', '+')[1].Split(':');
		                        if (trychar.Length > 1)
		                        {
			                        value = CharactersheetRepository.GetCharactersheetByName(trychar[0]).GetAttribute(trychar[1]);
		                        }

	                        }
	                        modifier = value;
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