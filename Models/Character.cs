using System.Collections.Generic;

namespace RoleplayBot.Models
{
    public class Character
    {
        public string Name { get; set; }
        private Dictionary<string, int> Attributes { get; set; }

        public Character(string name)
        {
	        Name = name;
            Attributes = new Dictionary<string, int>();
        }

		/// <summary>
		/// Sets an attribute for the character.
		/// </summary>
		/// <param name="name">Name/Key of the attribute.</param>
		/// <param name="value">Value of the attribute.</param>
        public void SetAttribute(string name, int value)
        {
            Attributes.Add(name, value);
        }

        /// <summary>
		/// Gets an attribute from the character.
		/// </summary>
		/// <param name="name"></param>
        /// <returns>If the attribute exists, it's value. Otherwise, 0.</returns>
        public int GetAttribute(string name)
        {
            int value = 0;
            if(Attributes.TryGetValue(name, out value))
            {
                return value;
            }
            return 0;
        }
    }
}