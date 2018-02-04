using System;
using System.Collections.Generic;
using System.IO;

namespace _05.SlicingFile
{
    class Program
    {
        private const int BufferSize = 4096;
        static void Main(string[] args)
        {
            var sourceFile = "../../Resources/sliceMe.mp4";
            var destinationFolder = "../../Resources/";
            var parts = int.Parse(Console.ReadLine());

            var files = new List<string>()
            {
                "Part-0.mp4",
                "Part-1.mp4",
                "Part-2.mp4",
                "Part-3.mp4",
                "Part-4.mp4",
            };

            Slice(sourceFile, destinationFolder, parts);
            Assemble(files, destinationFolder);
        }

        private static void Assemble(List<string> files, string destinationFolder)
        {
            var extension = files[0].Substring(files[0].LastIndexOf('.') + 1);
            var fileName = $"{destinationFolder}Assembled.{extension}";

            using (var writer = new FileStream(fileName, FileMode.Create))
            {
                var buffer = new byte[BufferSize];
                foreach (var file in files)
                {
                    using (var reader = new FileStream(destinationFolder + file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, BufferSize) == BufferSize)
                        {
                            writer.Write(buffer, 0, BufferSize);
                        }
                    }
                }
            }
        }

        private static void Slice(string sourceFile, string destinationFolder, int parts)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                var extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

                long pieceSize = (long) Math.Ceiling((double) reader.Length / parts);
                
                for (int i = 0; i < parts; i++)
                {
                    var currentPieceSize = 0;
                    var currentPart = destinationFolder + $"Part-{i}.{extension}";

                    using (var writer = new FileStream(currentPart, FileMode.Create))
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
