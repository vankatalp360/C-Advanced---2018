using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFilePath = "../../Resources/copyMe.png";
            var copyFilePath = "../../Resources/imageCopy.png";

            using (var sourceFile = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (var copyFile = new FileStream(copyFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = sourceFile.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }

                        copyFile.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
        
    }
}
