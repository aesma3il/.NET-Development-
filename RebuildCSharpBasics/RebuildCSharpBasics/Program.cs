using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebuildCSharpBasics
{
    internal class Program
    {

        /*
         Print your name on console
        read your name and print it
        read a number and print it
        read a number and check if its postive
        read a number and check if its postive or negative
        read a number and check if its zero or one
        read a number and check if its odd or even
        read a number and check if its greater than 18
        read a number and check if its less than 18
         
         
         */

        //enum (hired, rejected
        //employeePolicy(minAgeAllowed = 18)
        //specification pattern for the employeeeing conditions
        //HiringResult, RejectionResult, HiringPolicy
        //employee entity

        // program to read age, driver license, has recommmendation and do the following
        // if they has a recommendation, then it is hired, else
        // if t he age is greater than 18 and has driver license, hired, else, rejected

        static void Main(string[] args)
        {

            Console.WriteLine("My name is : Abdulllah");
            string prompt = "Enter Your name:";
            string outputMessage = "Your Name is: ";
            Console.WriteLine(prompt);
            string name = Console.ReadLine();

            int length = name.Length;
            string trimedName = name.Trim();

            char letter = ' ';
            for(int i = 0; i <=name.Length; i++)
            {

            }
            Console.WriteLine($"{outputMessage}{name}");


            Console.ReadKey();
        }
    }
}
