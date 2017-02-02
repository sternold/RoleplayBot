using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RoleplayBot.Persistence
{
    public abstract class DatastoreBase<T>
    {

        List<T> items = new List<T>();

        public void Initialize()
        {
            if(!File.Exists("Datastore.json"))
            {
                using(File.CreateText("Datastore.Json"))
                {
                    System.Console.WriteLine("New Datastore Created.");
                }
            }
        }

        public void Load()
        {
            items = JsonConvert.DeserializeObject<List<T>>
        }

        public void Commit()
        {

        }
    }
}