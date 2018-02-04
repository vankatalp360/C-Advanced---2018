using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var linesCounter = 0;

            using (var reader = new StreamReader("../../Resources/text.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (linesCounter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    line = reader.ReadLine();
                    linesCounter++;
                }
            }
        }
    }
}
