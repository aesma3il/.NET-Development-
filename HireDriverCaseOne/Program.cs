using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireDriverCaseOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = ReadInteger("Enter your age:");
            bool hasDriverLicense = ReadBoolean("Do you have a driver license?");

            var hiring = new Hiring(age, hasDriverLicense);
            hiring.PrintStatus();

            Console.ReadKey();
        }

        static int ReadInteger(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                    return number;

                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static bool ReadBoolean(string prompt)
        {
            while (true)
            {
                Console.WriteLine($"{prompt} (yes/no)");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (input == "yes" || input == "y")
                    return true;

                if (input == "no" || input == "n")
                    return false;

                Console.WriteLine("Invalid input. Please enter yes or no.");
            }
        }
    }

    public static class Settings
    {
        public const int AgeConstraint = 18;
    }

    public enum HireStatus
    {
        Hired,
        Rejected
    }

    public class Hiring
    {
        private readonly int _age;
        private readonly bool _hasDriverLicense;
        private readonly HireStatus _status;

        public Hiring(int age, bool hasDriverLicense)
        {
            _age = age;
            _hasDriverLicense = hasDriverLicense;
            _status = Evaluate();
        }

        private HireStatus Evaluate()
        {
            return (_age >= Settings.AgeConstraint && _hasDriverLicense)
                ? HireStatus.Hired
                : HireStatus.Rejected;
        }

        public void PrintStatus()
        {
            Console.WriteLine(_status);
        }
    }


}
