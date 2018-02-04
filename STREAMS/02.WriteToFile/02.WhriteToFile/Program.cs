using System;
using System.IO;

namespace _02.WhriteToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("Program.cs");

            using (reader)
            {
                var whriter = new StreamWriter("reversed.txt");

                using (whriter)
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        for (int i = line.Length - 1; i >= 0; i--)
                        {
                            whriter.Write(line[i]);
                        }
                        whriter.WriteLine();
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
