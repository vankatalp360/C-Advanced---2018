using System;
using System.IO;

namespace _02.LineNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../Resources/text.txt"))
            {
                var lineCounter = 0;

                var line = reader.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(
                        $"Line {++lineCounter}: {line}");
                    line = reader.ReadLine();
                }
            }
        }
    }
}
