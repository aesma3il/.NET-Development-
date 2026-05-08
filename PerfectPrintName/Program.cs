using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectPrintName
{

    public static class InputMessages
    {
        public static string EnterYourName = "Enter your name:";
        public static char Delimiter = ':';
    }

    public static class OutputMessages
    {
        public static string YourNameIs = "Your Name Is ";
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            string[] prompt = { "Enter your name:", "Your name is " };

            string myName = ReadName(InputMessages.EnterYourName);
            if (myName == null || myName == "")
            {
                Console.WriteLine("You Does not entered a string");
            }

            PrintName(myName, OutputMessages.YourNameIs);

            Console.ReadKey();
        }


        static string ReadName(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine() ?? "";
        }

        static void PrintName(string name, string title = null, char delimiter = ':')
        {
            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine(name);
            }
            else
            {
                Console.WriteLine(title + delimiter + name);
            }
        }



    }
}
