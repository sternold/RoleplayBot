using System.IO;

namespace RoleplayBot.Util
{
    public class Config
    {
        private const string Extension = ".conf";

        private string Filename { get; set; }
        
        /// <summary>
		/// Creates/Reads a config file.
		/// </summary>
		/// <param name="filename">Name of the properties file. Do NOT include the extension</param>
        public Config(string filename)
        {
            this.Filename = filename + Extension;

            if(!File.Exists(Filename)){
                File.CreateText(Filename).Dispose();
                
            }
        }

        /// <summary>
        /// Retrieves a value by key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a new Key-Value pair.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Put(string key, string value)
        {
          using(var writer = new StreamWriter(File.Open(Filename, FileMode.Open)))
            {
                writer.WriteLine(key + "=" + value);
            }
        }

    }
}