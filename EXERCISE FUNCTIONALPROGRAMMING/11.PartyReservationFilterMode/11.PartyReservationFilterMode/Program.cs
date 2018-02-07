using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterMode
{
    class Program
    {
        private static Dictionary<string, List<string>> Filter = new Dictionary<string, List<string>>();
        static void Main(string[] args)
        {
            var guests = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            ReadCommands(guests);
            Console.WriteLine(string.Join(" ", guests));
        }

        private static void ReadCommands(List<string> guests)
        {
            var line = Console.ReadLine();

            while (line != "Print")
            {
                var lineParts = line
                    .Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var command = lineParts[0];
                var criterion = lineParts[1];
                var pattern = lineParts[2];

                ExecuteCommand(guests, command, criterion, pattern);

                line = Console.ReadLine();
            }

            ApplyFilters(guests);
            
        }

        private static void ApplyFilters(List<string> guests)
        {
            foreach (var list in Filter.Values)
            {
                foreach (string name in list)
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);
                    }
                }
            }
        }

        private static void ExecuteCommand(List<string> guests, string command, string criterion, string pattern)
        {
            var filterdGuest = FilterGuests(guests, criterion, pattern);

            switch (command)
            {
                case "Add filter": AddFilter(filterdGuest, criterion, pattern);
                    break;
                case "Remove filter": RemoveFilter(filterdGuest, criterion, pattern);
                    break;
            }
        }

        private static void AddFilter(List<string> filterdGuest, string criterion, string pattern)
        {
            var filter = criterion + pattern;
            if (!Filter.ContainsKey(filter))
            {
                Filter[filter] = filterdGuest;
            }
        }

        private static void RemoveFilter(List<string> filterdGuest, string criterion, string pattern)
        {
            var filter = criterion + pattern;
            if (Filter.ContainsKey(filter))
            {
                Filter.Remove(filter);
            }
        }

        private static List<string> FilterGuests(List<string> names, string criterion, string pattern)
        {
            Predicate<string> startsWith = x => x.StartsWith(pattern);
            Predicate<string> endsWith = x => x.EndsWith(pattern);
            Predicate<string> Length = x => x.Length == int.Parse(pattern);
            Predicate<string> Contains = x => x.Contains(pattern);

            var filterGuests = new List<string>();

            switch (criterion)
            {
                case "Starts with":
                    filterGuests = names.Where(n => startsWith(n)).ToList();
                    break;
                case "Ends with":
                    filterGuests = names.Where(n => endsWith(n)).ToList();
                    break;
                case "Length":
                    filterGuests = names.Where(n => Length(n)).ToList();
                    break;
                case "Contains":
                    filterGuests = names.Where(n => Contains(n)).ToList();
                    break;
            }
            return filterGuests;
        }
    }
}
