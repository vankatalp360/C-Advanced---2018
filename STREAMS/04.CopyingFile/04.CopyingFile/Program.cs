using System;
using System.IO;

namespace _04.CopyingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new FileStream("darksiders.jpg", FileMode.Open);

            using (source)
            {
                var destination = new FileStream("darksiders-copy.jpg", FileMode.Create);

                using (destination)
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
