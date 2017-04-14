using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RoleplayBot.Character.Models;

namespace RoleplayBot.Character.Persistence
{
    public class CharactersheetDatastore : DatastoreBase<Charactersheet>
    {
        public CharactersheetDatastore()
        {
            Name = "Charactersheets.json";
        }

        public override void Create(Charactersheet entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Charactersheet> Read()
        {
            throw new NotImplementedException();
        }

        public override Charactersheet Read(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Charactersheet entity)
        {
            throw new NotImplementedException();
        }
    }
}