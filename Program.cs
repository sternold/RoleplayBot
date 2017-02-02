using System;
using System.IO;
using System.Xml;

namespace RoleplayBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting RoleplayBot");
            
            if(!File.Exists("config.xml")){
                Console.WriteLine("config.xml does not exist. Creating...");
                
                using(File.Create("config.xml"))
                {
                    Console.WriteLine("File Created.");
                }
                
                using(XmlWriter write = XmlWriter.Create(File.Open("config.xml", FileMode.Open)))
                {
                    write.WriteStartDocument();
                    write.WriteStartElement("token");
                    write.WriteString(string.Empty);
                    write.WriteEndElement();  
                }                 
            }

            XmlReader read = XmlReader.Create(File.Open("config.xml", FileMode.Open));

            string token = null;
            if((token = read.GetAttribute("token")) == null)
            {
                Console.WriteLine("element 'token' does not exist. Shutting down...");
                System.Environment.Exit(0);
            }
            

            var bot = new Bot(token);
            bot.Run();
        }
    }
}
