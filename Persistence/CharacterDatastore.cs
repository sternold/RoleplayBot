using System;
using System.Collections.Generic;
using RoleplayBot.Models;

namespace RoleplayBot.Persistence
{
    public class CharacterDatastore : DatastoreBase, IRepository<Character>
    {
        public void Create(Character entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Character> Read()
        {
            throw new NotImplementedException();
        }

        public Character Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Character entity)
        {
            throw new NotImplementedException();
        }
    }
}