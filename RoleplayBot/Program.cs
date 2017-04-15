using System;
using System.Threading.Tasks;
using RoleplayBot.Bot;
using RoleplayBot.Persistence;
using RoleplayBot.Util;

namespace RoleplayBot
{
	public class Program
	{
		private Config _config;
		private DiscordBot _bot;

		public static void Main(string[] args)
			=> new Program().MainAsync().GetAwaiter().GetResult();

		private async Task MainAsync()
		{
			GenerateAssets();
			try
			{
				_bot = new DiscordBot(_config.GetAsString("Token"));
				await _bot.Run();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			Console.ReadKey();
		}

		private void GenerateAssets()
		{
			_config = new Config("config");
			if (_config.IsNew)
			{
				_config.Put("Token", string.Empty);
				_config.Put("DeleteDatabaseOnRestart", true);
			}

			using (var db = new RoleplayContext())
			{
				if (_config.GetAsBoolean("DeleteDatabaseOnRestart"))
					db.Database.EnsureDeleted();
				db.Database.EnsureCreated();
			}
		}
	}
}
