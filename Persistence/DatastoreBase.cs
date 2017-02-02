using System.IO;
using Newtonsoft.Json;

namespace RoleplayBot.Persistence
{
    public abstract class DatastoreBase
    {
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
                       
        }

        public void Commit()
        {

        }
    }
}