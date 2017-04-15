using RoleplayBot.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RoleplayBot.Character.Models;

namespace RoleplayBot.Character
{
    public static class CharactersheetRepository
    {
        private static readonly RoleplayContext Db = new RoleplayContext();

        public static void CreateCharactersheet(Charactersheet entity)
        {
            Db.Charactersheets.Add(entity);
            Db.SaveChanges();
        }

	    public static void UpdateCharactersheet(Charactersheet entity)
	    {
		    Db.Charactersheets.Update(entity);
		    Db.SaveChanges();
	    }

        public static Charactersheet GetCharactersheetByName(string name)
        {
            return Db.Charactersheets.FirstOrDefault(y => y.Name == name);
        }
    }
}
