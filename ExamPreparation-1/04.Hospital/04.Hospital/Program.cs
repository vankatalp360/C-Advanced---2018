using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var departments = new Dictionary<string, List<string>>();
            var doctors = new Dictionary<string, List<string>>();

            ReadInputs(departments, doctors);

            ReadOutputCommands(departments, doctors);
        }

        private static void ReadOutputCommands(Dictionary<string, List<string>> departments, Dictionary<string, List<string>> doctors)
        {
            string line;

            while ((line = Console.ReadLine()) != "End")
            {
                var lineParts = line.Split();
                var roomNumber = 0;
                if (lineParts.Length == 1)
                {
                    var department = lineParts[0];
                    PrintPatiensFromDepartment(department, departments);
                }
                else if(int.TryParse(lineParts[1], out roomNumber))
                {
                    var department = lineParts[0];
                    PrintRoom(departments, department, roomNumber);
                }
                else
                {
                    var doctor = (lineParts[0] + " " + lineParts[1]).Trim();
                    PrintDoctorsPatients(doctors, doctor);
                }
            }
        }

        private static void PrintDoctorsPatients(Dictionary<string, List<string>> doctors, string doctor)
        {
            foreach (var patient in doctors[doctor].OrderBy(p => p))
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintRoom(Dictionary<string, List<string>> departments, string department, int roomNumber)
        {
            var skip = 3 * (roomNumber - 1);
            var patients = departments[department].Skip(skip).Take(3);

            foreach (var patient in patients.OrderBy(p => p))
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintPatiensFromDepartment(string department, Dictionary<string, List<string>> departments)
        {
            foreach (var patient in departments[department])
            {
                Console.WriteLine(patient);   
            }
        }

        private static void ReadInputs(Dictionary<string, List<string>> departments, Dictionary<string, List<string>> doctors)
        {
            string input;

            while ((input = Console.ReadLine()) != "Output")
            {
                var inputParts = input.Split();
                var department = inputParts[0];
                var doctor = inputParts[1] + " " + inputParts[2];
                var patient = inputParts[3];

                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<string>();
                }
                departments[department].Add(patient);

                if (!doctors.ContainsKey(doctor))
                {
                    doctors[doctor] = new List<string>();
                }
                doctors[doctor].Add(patient);
            }
        }
        
    }
}
