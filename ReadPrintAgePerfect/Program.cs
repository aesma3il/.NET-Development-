using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadPrintAgePerfect
{

    /*
=========================================================
Concepts Demonstrated in This Code
=========================================================

1) Separation of Concerns (SoC)
--------------------------------
- The code is divided into logical parts:
  • Input        → handles user input
  • Output       → handles displaying results
  • Validator    → contains validation logic
  • Messages     → stores text constants
  • Formatting   → stores shared formatting rules
- Each class has a single responsibility → cleaner, maintainable design

---------------------------------------------------------

2) Use of Static Classes
------------------------
- All helper classes are static because:
  • No object state is needed
  • Methods are utility-like
- This avoids unnecessary object creation

---------------------------------------------------------

3) Nullable Value Types (int?)
------------------------------
- `int?` means the value can be:
  • a valid integer
  • or null (no value / invalid input)
- Used here to safely represent failed parsing instead of using magic numbers

---------------------------------------------------------

4) Safe Parsing with TryParse
-----------------------------
- `int.TryParse()` is used instead of `int.Parse()`
- Prevents runtime exceptions (no crash on invalid input)
- Returns:
  • true  → valid number
  • false → invalid input

---------------------------------------------------------

5) Input Validation Layer
-------------------------
- Validation logic is separated into `Validator` class
- Example:
    IsPositive(int number)
- Encourages reusable and testable validation rules

---------------------------------------------------------

6) Pattern Matching (Modern C#)
-------------------------------
- This line:
    if (age is int validAge && Validator.IsPositive(validAge))
- Combines:
  • null check
  • type check
  • value extraction
- Avoids unsafe usage of `.Value`

---------------------------------------------------------

7) Avoiding Null Reference Issues
--------------------------------
- Instead of:
    age.Value
- The code uses pattern matching to ensure:
  • value exists
  • safe to use
- This reduces runtime errors

---------------------------------------------------------

8) String Interpolation
-----------------------
- Uses:
    $"{title} {Formatting.Delimiter} {value}"
- Cleaner and more readable than string concatenation

---------------------------------------------------------

9) Reusable Configuration
-------------------------
- Formatting (Delimiter) is centralized:
    Formatting.Delimiter
- Makes it easy to change output format globally

---------------------------------------------------------

10) Clean Main Flow (Readable Logic)
------------------------------------
- Main method reads like a simple story:
  1. Read input
  2. Validate input
  3. Print result OR show error
- Improves maintainability and clarity

---------------------------------------------------------

11) Defensive Programming
-------------------------
- The program handles invalid input safely:
  • No crashes
  • Clear fallback ("Invalid input")

---------------------------------------------------------

12) Scalability Mindset
-----------------------
- Even though the program is simple,
  the structure supports scaling:
  • Adding more validations
  • Supporting more inputs
  • Changing output format easily

=========================================================
Summary:
This code teaches how to write clean, safe, and modular C# 
code using modern practices (nullable types, pattern matching,
and separation of concerns).
=========================================================
*/

    public static class InputMessages
    {
        public static string EnterYourAge = "Enter your Age";
    }

    public static class OutputMessages
    {
        public static string YourAgeIs = "Your Age Is ";
    }

    public static class Formatting
    {
        public static char Delimiter = ':';
    }

    public static class Validator
    {
        public static bool IsPositive(int number)
        {
            return number > 0;
        }
    }

    public static class Input
    {
        public static int? ReadNumber(string prompt)
        {
            Console.WriteLine(prompt);
            int number;
            if (int.TryParse(Console.ReadLine(), out number))
                return number;


            return null;
        }
    }

    public static class Output
    {
        public static void Print(string title, int value)
        {
            Console.WriteLine($"{title} {Formatting.Delimiter} {value}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int? age = Input.ReadNumber(InputMessages.EnterYourAge);

            //if (age == null || !Validator.IsPositive(age.Value))
            //{
            //    Console.WriteLine("Invalid input");
            //    return;
            //}

            //Output.Print(OutputMessages.YourAgeIs, age.Value);



            if (age is int validAge && Validator.IsPositive(validAge))
            {
                Output.Print(OutputMessages.YourAgeIs, validAge);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }


            Console.ReadKey();

        }
    }
}
