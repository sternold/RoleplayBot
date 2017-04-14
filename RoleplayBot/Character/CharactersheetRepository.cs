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
        private static RoleplayContext db = new RoleplayContext();

        public static void CreateCharactersheet(Charactersheet entity)
        {
            db.Charactersheets.Add(entity);
            db.SaveChanges();
        }

        public static Charactersheet GetCharactersheetByName(string name)
        {
            return db.Charactersheets.Where(y => y.Name == name).FirstOrDefault();
        }
    }
}
