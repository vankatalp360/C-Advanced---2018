using System;
using System.IO;
using System.IO.Compression;

namespace _06.ZippingSlicedFiles
{
    class Program
    {
        private const int BufferSize = 4096;
        static void Main(string[] args)
        {
            var sourceFile = "../../Resources/sliceMe.mp4";
            var destinationFolder = "../../Resources/";
            var parts = int.Parse(Console.ReadLine());
            
            Slice(sourceFile, destinationFolder, parts);
        }
        private static void Slice(string sourceFile, string destinationFolder, int parts)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                var extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    var currentPieceSize = 0;
                    var currentPart = destinationFolder + $"Part-{i}.{extension}.gz";

                    using (var writer = new GZipStream(new FileStream(currentPart, FileMode.Create), CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[BufferSize];
                        while (reader.Read(buffer, 0, BufferSize) == BufferSize)
                        {
                            writer.Write(buffer, 0, BufferSize);
                            currentPieceSize += BufferSize;

                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
