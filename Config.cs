using System;
using System.IO;

namespace RoleplayBot
{
    public class Config
    {
        private string filename;
        public Config(string filename)
        {
            this.filename = filename;

            if(!File.Exists(filename)){
                using(File.CreateText(filename))
                {

                }
            }
        }

        public string Get(string key)
        {
            using(var reader = new StreamReader(File.Open(filename, FileMode.Open)))
            {
                while(!reader.EndOfStream)
                {
                    string[] pair = reader.ReadLine().Split('=');
                    if(pair[0] == key)
                    {
                        return pair[1];
                    }
                }
            }
            return null;
        }

        public void Put(string key, string value)
        {
          using(var writer = new StreamWriter(File.Open(filename, FileMode.Open)))
            {
                writer.WriteLine(key + "=" + value);
            }
        }

    }
}