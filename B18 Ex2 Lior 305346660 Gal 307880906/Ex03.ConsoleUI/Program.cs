using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            IEnumerable<string> lines = File.ReadAllLines("WheelsModels.txt");
            foreach(string str in lines)
            {
                Console.WriteLine(str);
            }

            Console.ReadKey();
        }
    }
}
