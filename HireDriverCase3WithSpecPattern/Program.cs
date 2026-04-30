using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireDriverCase3WithSpecPattern
{
    public static class Settings
    {
        public const int AgeConstraint = 18;
        public const int ExperienceConstraint = 4;
    }

    public enum HireStatus
    {
        Hired,
        Rejected
    }

    public interface IHiringRule
    {
        bool IsSatisfied();
    }

     
    public class RecommendationRule : IHiringRule
    {
        private readonly bool _hasRecommendation;

        public RecommendationRule(bool hasRecommendation)
        {
            _hasRecommendation = hasRecommendation;
        }

        public bool IsSatisfied() => _hasRecommendation;
    }

    
    public class AgeAndLicenseRule : IHiringRule
    {
        private readonly int _age;
        private readonly bool _hasDriverLicense;

        public AgeAndLicenseRule(int age, bool hasDriverLicense)
        {
            _age = age;
            _hasDriverLicense = hasDriverLicense;
        }

        public bool IsSatisfied()
        {
            return _age >= Settings.AgeConstraint && _hasDriverLicense;
        }
    }

    
    public class ExperienceRule : IHiringRule
    {
        private readonly int _years;

        public ExperienceRule(int years)
        {
            _years = years;
        }

        public bool IsSatisfied()
        {
            return _years > Settings.ExperienceConstraint;
        }
    }

    public class Hiring
    {
        private readonly HireStatus _status;

        public Hiring(int age, bool hasDriverLicense, bool hasRecommendation, int experience)
        {
           
            if (new RecommendationRule(hasRecommendation).IsSatisfied())
            {
                _status = HireStatus.Hired;
                return;
            }

           
            var requirements = new List<IHiringRule>
            {
                new AgeAndLicenseRule(age, hasDriverLicense),
                new ExperienceRule(experience)
            };

            _status = requirements.All(r => r.IsSatisfied())
                ? HireStatus.Hired
                : HireStatus.Rejected;
        }

        public void PrintStatus()
        {
            Console.WriteLine(_status);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int age = ReadInteger("Enter your age:");
            bool hasDriverLicense = ReadBoolean("Do you have a driver license?");
            bool hasRecommendation = ReadBoolean("Do you have a recommendation?");
            int experience = ReadInteger("Enter years of experience:");

            var hiring = new Hiring(age, hasDriverLicense, hasRecommendation, experience);
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
}
