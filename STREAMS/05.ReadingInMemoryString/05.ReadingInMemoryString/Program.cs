using System;
using System.IO;
using System.Text;

namespace _05.ReadingInMemoryString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "In-memory text.";
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            var memoryStream = new MemoryStream(bytes);

            using (memoryStream)
            {
                while (true)
                {
                    int readByte = memoryStream.ReadByte();

                    if (readByte == -1)
                    {
                        break;;
                    }

                    Console.WriteLine((char) readByte);
                }
            }

        }
    }
}
