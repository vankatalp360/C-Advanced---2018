using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HitList
{
    class Program
    {
        private static Dictionary<string, Dictionary<string, string>> Information = new Dictionary<string, Dictionary<string, string>>();
        static void Main(string[] args)
        {
            var targetInfo = int.Parse(Console.ReadLine());

            ReadCommands(targetInfo);
        }

        private static void ReadCommands(int targeInfo)
        {
            string line = "";
            while ((line = Console.ReadLine()) != "end transmissions")
            {
                var inputParts = line.Split(new[] {'=', ':', ';'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = inputParts[0];
                if (!Information.ContainsKey(name))
                {
                    Information[name] = new Dictionary<string, string>();
                }

                for (int i = 1; i < inputParts.Length; i+=2)
                {
                    var key = inputParts[i];
                    var value = inputParts[i + 1];
                    if (!Information[name].ContainsKey(key))
                    {
                        Information[name][key] = value;
                    }
                    Information[name][key] = value;
                }
            }
            line = Console.ReadLine();
            KillPerson(line, targeInfo);
        }

        private static void KillPerson(string line, int targetInfo)
        {
            var parts = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var name = parts[1];

            var person = Information[name];

            var infoSum = 0;
            person = person.OrderBy(a => a.Key).ToDictionary(a => a.Key, o => o.Value);
            Console.WriteLine($"Info on {name}:");
            foreach (var inf in person)
            {
                infoSum += inf.Key.Length;
                infoSum += inf.Value.Length;
                Console.WriteLine($"---{inf.Key}: {inf.Value}");
            }

            if (infoSum >= targetInfo)
            {
                Console.WriteLine($"Info index: {infoSum}");
                Console.WriteLine("Proceed");
            }
            else
            {
                var needed = targetInfo - infoSum;
                Console.WriteLine($"Info index: {infoSum}");
                Console.WriteLine($"Need {needed} more info.");
            }
        }
    }
}
