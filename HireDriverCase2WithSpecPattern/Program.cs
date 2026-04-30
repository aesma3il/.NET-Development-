using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireDriverCase2WithSpecPattern
{
    public static class Settings
    {
        public static readonly int AgeConstraint = 18;

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

        public RecommendationRule(bool hasReco)
        {
            _hasRecommendation = hasReco;
        }

        public bool IsSatisfied()
        {
            return _hasRecommendation;
        }

    }

    public class AgeAndLicenseRule : IHiringRule
    {
        private readonly int _age;
        private readonly bool _hasDriverLicense;


        public AgeAndLicenseRule(int age, bool hasDriv)
        {
            _age = age;
            _hasDriverLicense = hasDriv;
        }

        public bool IsSatisfied()
        {
            return _age >= Settings.AgeConstraint && this._hasDriverLicense;
        }
    }



    public class Hiring
    {
        private readonly HireStatus _status;

        public Hiring(int age, bool hasDriv, bool hasRecommendation)
        {
            var rules = new List<IHiringRule>
           {
               new RecommendationRule(hasRecommendation),
               new AgeAndLicenseRule(age, hasDriv)
           };

            _status = rules.Any(r => r.IsSatisfied()) ? HireStatus.Hired : HireStatus.Rejected;

        }

        /*
         bool isAccepted = false;

            foreach (var r in rules)
            {
                if (r.IsSatisfied())
                {
                    isAccepted = true;
                    break;
                }
            }


         */

        public void PrintStatus()
        {
            Console.WriteLine(_status);
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {

            int age = ReadInteger("Enter your age");

            bool hasDriverLicense = ReadBoolean("Do you have DriverLicense?");
            bool hasRecommendation = ReadBoolean("Do you have REcommendation?");

            Hiring hi = new Hiring(age, hasDriverLicense, hasRecommendation);
            hi.PrintStatus();






            Console.ReadKey();

        }

        static int ReadInteger(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                int number;
                if (int.TryParse(input, out number))
                {
                    return number;
                }
                Console.WriteLine("Invalid Input");
            }
        }


        static bool ReadBoolean(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt + "(yes, no)");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (input == "yes" || input == "y")
                {
                    return true;
                }

                if (input == "no" || input == "n")
                    return false;


                Console.WriteLine("Invalid Input");
            }
        }
    }


}
