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

        public void SetAttribute(string name, int? value)
        {
            Attributes.Add(name, value);
        }

        public int? GetAttribute(string name)
        {
            int? value = null;
            Attributes.TryGetValue(name, out value);
            return value;
        }
    }
}