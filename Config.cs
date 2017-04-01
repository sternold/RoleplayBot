using System.IO;

namespace RoleplayBot
{
    public class Config
    {
        private string Filename { get; set; }
        
        /// <summary>
		/// Creates/Reads a config file.
		/// </summary>
		/// <param name="filename">Name of the properties file. The filename includes it's extension.</param>
        public Config(string filename)
        {
            this.Filename = filename;

            if(!File.Exists(filename)){
                File.CreateText(filename).Dispose();
                
            }
        }

        public string Get(string key)
        {
            using(var reader = new StreamReader(File.Open(Filename, FileMode.Open)))
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
          using(var writer = new StreamWriter(File.Open(Filename, FileMode.Open)))
            {
                writer.WriteLine(key + "=" + value);
            }
        }

    }
}