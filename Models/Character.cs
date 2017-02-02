using System.Collections.Generic;

namespace RoleplayBot.Models
{
    public class Character
    {
        public string Name { get; set; }
        private Dictionary<string, int?> Attributes { get; set; }

        public Character()
        {
            Attributes = new Dictionary<string, int?>();
        }

        public void putAttribute(string key, int? value)
        {
            Attributes.Add(key, value);
        }

        public int? getAttribute(string key)
        {
            int? value = null;
            Attributes.TryGetValue(key, out value);
            return value;
        }
    }
}