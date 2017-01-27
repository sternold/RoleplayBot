using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
	    List<int> list = new List<int>();
            //this is placeholder code until we start working on this.
            while(true){
                list.Add(new Random().Next(100));
		foreach(int i in list){
		   Console.Write(i);
		}
            }
        }
    }
}
