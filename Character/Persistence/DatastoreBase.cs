using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RoleplayBot.Character.Persistence
{
    public abstract class DatastoreBase<T> : ICRUD<T>
    {
        protected string Name { get; set; }
        List<T> items = new List<T>();

        /// <summary>
        /// Create a new datastore. Name is required.
        /// </summary>
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

        /// <summary>
        /// Load objects from the datastore.
        /// </summary>
        public void Load()
        {
            string json = null;
            using(var reader = new StreamReader(File.Open(Name, FileMode.Open)))
            {
                json = reader.ReadToEnd();
            }

            items = JsonConvert.DeserializeObject<List<T>>(json);
        }

        /// <summary>
        /// Save the current objects to the datastore.
        /// </summary>
        public void Commit()
        {
            File.Delete(Name);
            File.CreateText(Name).Dispose();
            string json = JsonConvert.SerializeObject(items);

            using(var writer = new StreamWriter(File.Open(Name, FileMode.Open)))
            {
                writer.Write(json);
                writer.Flush();
            }
        }

        public abstract void Create(T entity);
        public abstract IEnumerable<T> Read();
        public abstract T Read(int id);
        public abstract void Update(T entity);
        public abstract void Delete(int id);
    }
}