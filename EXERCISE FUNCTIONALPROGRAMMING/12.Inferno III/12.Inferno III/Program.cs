using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Inferno_III
{
    class Program
    {
        private static Dictionary<string, List<int>> Filter = new Dictionary<string, List<int>>();
        static void Main(string[] args)
        {
            var gems = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            ReadCommands(gems);
        }
        private static void ReadCommands(List<int> gems)
        {
            var line = Console.ReadLine();

            while (line != "Forge")
            {
                var lineParts = line
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var command = lineParts[0];
                var criterion = lineParts[1];
                var pattern = int.Parse(lineParts[2]);

                ExecuteCommand(gems, command, criterion, pattern);

                line = Console.ReadLine();
            }

            ApplyFilters(gems);
            Console.WriteLine(string.Join(" ", gems));

        }

        private static void ExecuteCommand(List<int> gems, string command, string criterion, int pattern)
        {
            var filter = CreateFilter(gems, criterion, pattern);

            switch (command)
            {
                case "Exclude": Exclude(filter, criterion, pattern);
                    break;
                case "Reverse": Reverse(filter, criterion, pattern);
                    break;
            }
        }

        private static void Reverse(List<int> filter, string criterion, int pattern)
        {
            var filterName = criterion + pattern;
            if (Filter.ContainsKey(filterName))
            {
                Filter.Remove(filterName);
            }
        }

        private static void Exclude(List<int> filter, string criterion, int pattern)
        {
            var filterName = criterion + pattern;
            if (!Filter.ContainsKey(filterName))
            {
                Filter[filterName] = filter;
            }
        }

        private static List<int> CreateFilter(List<int> gems, string criterion, int pattern)
        {
            var filterList = new List<int>();

            switch (criterion)
            {
                case "Sum Left":
                    SumLeft(filterList, gems, pattern);
                    break;
                case "Sum Right":
                    SumRight(filterList, gems, pattern);
                    break;
                case "Sum Left Right":
                    SumLeftRight(filterList, gems, pattern);
                    break;
            }

            return filterList;
        }

        private static void SumLeftRight(List<int> filterList, List<int> gems, int pattern)
        {
            for (int i = 0; i < gems.Count; i++)
            {
                int number = 0;
                if (i == 0 && i < gems.Count - 1)
                {
                    number = gems[i] + gems[i + 1];
                }
                else if (i > 0 && i < gems.Count - 1)
                {
                    number = gems[i] + gems[i + 1] + gems[i - 1];
                    
                }
                else if(i > 0 && i == gems.Count - 1)
                {
                    number = gems[i] + gems[i - 1];
                }
                else if (i == 0 && i == gems.Count - 1)
                {
                    number = gems[i];
                }
                if (number == pattern)
                {
                    filterList.Add(gems[i]);
                }
            }
        }

        private static void SumRight(List<int> filterList, List<int> gems, int pattern)
        {
            for (int i = 0; i < gems.Count; i++)
            {
                var number = 0;
                if (i == gems.Count - 1)
                {
                    number = gems[i];
                }
                else
                {
                    number = gems[i] + gems[i + 1];
                }
                if (number == pattern)
                {
                    filterList.Add(gems[i]);
                }
            }
        }

        private static void SumLeft(List<int> filterList, List<int> gems, int pattern)
        {
            for (int i = 0; i < gems.Count; i++)
            {
                var number = 0;
                if (i == 0)
                {
                    number = gems[i];
                }
                else
                {
                    number = gems[i] + gems[i - 1];
                }
                if (number == pattern)
                {
                    filterList.Add(gems[i]);
                }
            }
        }

        private static void ApplyFilters(List<int> gems)
        {
            foreach (var filter in Filter.Values)
            {
                foreach (int gem in filter)
                {
                    gems.Remove(gem);
                }
            }
        }
    }
}
