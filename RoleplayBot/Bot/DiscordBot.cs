using Discord;
using System;
using RoleplayBot.Dice;
using System.Threading.Tasks;
using Discord.WebSocket;
using RoleplayBot.Character;

namespace RoleplayBot.Bot
{
    public class DiscordBot
    {
        private DiscordSocketClient _client;
	    private readonly string _token;

        /// <summary>
        /// RPB's main parsing class.
        /// </summary>
        /// <param name="token">The token recieved from Discord</param>
        public DiscordBot(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Start listening to messages on discord.
        /// </summary>
        public async Task Run()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;
            _client.MessageReceived += async (message) =>
            {
                if (!message.Author.IsBot)
                {
                    await Log(new LogMessage(LogSeverity.Info, message.Author.Username, message.Content));
                    await ParseQuery(message);
                }
            };

            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        public async Task ParseQuery(SocketMessage message)
        {
            string[] args = message.Content.Split(' ');
	        try
	        {
		        switch (args[0].ToLower())
		        {
			        case "!roll":
				        var roll = DiceRoller.GenerateRollString(args);
				        await message.Channel.SendMessageAsync(roll);
				        break;
			        case "!char":
				        var query = args[1].Split(':');
				        if (query.Length > 1)
				        {					        
							var action = query[1].Split('=');
							var character = CharactersheetRepository.GetCharactersheetByName(query[0]);
							if (action.Length > 1)
					        {
						        character.SetAttribute(action[0], Convert.ToInt32(action[1]));
					        }
							CharactersheetRepository.UpdateCharactersheet(character);
							await message.Channel.SendMessageAsync("The value of " + action[0] + " is " + CharactersheetRepository.GetCharactersheetByName(query[0])
								.GetAttribute(action[0]));
				        }
				        else
				        {
					        CharactersheetRepository.CreateCharactersheet(new Character.Models.Charactersheet(args[1]));
					        await message.Channel.SendMessageAsync(CharactersheetRepository.GetCharactersheetByName(args[1]).Name + " exists!" ??
					                                               "Could not save character.");
				        }
				        break;
		        }
	        }
	        catch (Exception e)
	        {
		        await Log(new LogMessage(LogSeverity.Error, "Bot", e.Message));
		        await message.Channel.SendMessageAsync(e.Message);
	        }		
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
