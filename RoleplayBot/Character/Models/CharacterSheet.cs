using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RoleplayBot.Character.Models
{
	public class Charactersheet
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }
		public string Attributes { get; set; }

		public Charactersheet()
		{
		}

		public Charactersheet(string name)
		{
			Name = name;
			Attributes = JsonConvert.SerializeObject(new Dictionary<string, int>());
		}

		/// <summary>
		///     Sets an attribute for the character.
		/// </summary>
		/// <param name="name">Name/Key of the attribute.</param>
		/// <param name="value">Value of the attribute.</param>
		public void SetAttribute(string name, int value)
		{
			var dict = JsonConvert.DeserializeObject<Dictionary<string, int>>(Attributes);
			dict.Add(name, value);
			Attributes = JsonConvert.SerializeObject(dict);
		}

		/// <summary>
		///     Gets an attribute from the character.
		/// </summary>
		/// <param name="name"></param>
		/// <returns>If the attribute exists, it's value. Otherwise, 0.</returns>
		public int GetAttribute(string name)
		{
			var dict = JsonConvert.DeserializeObject<Dictionary<string, int>>(Attributes);
			dict.TryGetValue(name, out int result);
			return result;
		}
	}
}