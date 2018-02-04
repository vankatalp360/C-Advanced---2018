using System;
using System.IO;

namespace _01.ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("Program.cs");

            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    lineNumber++;
                    Console.WriteLine($"Line {lineNumber}: {line}");
                    line = reader.ReadLine();
                }
            }
        }
    }
}
