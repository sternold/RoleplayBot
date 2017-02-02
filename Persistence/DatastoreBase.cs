using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RoleplayBot.Persistence
{
    public abstract class DatastoreBase<T>
    {
        protected string Name { get; set; }
        List<T> items = new List<T>();

        public void Initialize()
        {
            if(!File.Exists(Name))
            {
                using(File.CreateText(Name))
                {
                    System.Console.WriteLine("New Datastore Created.");
                }
            }
        }

        public void Load()
        {
            string json = null;
            using(var reader = new StreamReader(File.Open(Name, FileMode.Open)))
            {
                json = reader.ReadToEnd();
            }

            items = JsonConvert.DeserializeObject<List<T>>(json);
        }

        public void Commit()
        {
            File.Delete(Name);
            using(File.CreateText(Name))
            {

            }
            string json = JsonConvert.SerializeObject(items);

            using(var writer = new StreamWriter(File.Open(Name, FileMode.Open)))
            {
                writer.Write(json);
                writer.Flush();
            }
        }
    }
}