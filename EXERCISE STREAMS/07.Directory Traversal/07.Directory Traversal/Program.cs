using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07.Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Console.ReadLine();

            var filesDictionary = new Dictionary<string, List<FileInfo>>();

            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                string extention = fileInfo.Extension;

                if (!filesDictionary.ContainsKey(extention))
                {
                    filesDictionary[extention] = new List<FileInfo>();
                }
                filesDictionary[extention].Add(fileInfo);
            }
            filesDictionary = filesDictionary
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var outputFile = $"{desktopPath}/report.txt";

            using (var writer = new StreamWriter(outputFile))
            {
                foreach (var kvp in filesDictionary)
                {
                    writer.WriteLine(kvp.Key);

                    foreach (var file in kvp.Value.OrderBy(x => x.Length))
                    {
                        var fileSize = file.Length / 1024;
                        writer.WriteLine($"--{file.Name} - {fileSize}kb");
                    }
                }
            }
        }
    }
}
