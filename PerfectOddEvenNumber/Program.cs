using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectOddEvenNumber
{
    public enum Language
    {
        Arabic = 1,
        English = 2
    }

    public static class EnMessages
    {
        public const string EnterNumber = "Enter number";
        public const string ItIsEven = "It is Even Number";
        public const string ItIsOdd = "It Is Odd Number";
        public const string InvalidNumber = "Invalid Number! Please enter a valid number.";
        public const string NumberOutOfRange = "Number is out of range. Please enter a number between {0} and {1}.";
        public const string ErrorOccurred = "An error occurred: ";
    }

    public static class ArMessages
    {
        public const string EnterNumber = "ادخل الرقم";
        public const string ItIsEven = "الرقم زوجي";
        public const string ItIsOdd = "الرقم فردي";
        public const string InvalidNumber = "رقم غير صالح! يرجى إدخال رقم صحيح.";
        public const string NumberOutOfRange = "الرقم خارج النطاق. يرجى إدخال رقم بين {0} و {1}.";
        public const string ErrorOccurred = "حدث خطأ: ";
    }

    public static class ErrorCodes
    {
        public const string InValidNumber = "INV-Number:001";
        public const string CouldNotConvertToNumber = "INV:002";
        public const string NumberOutOfRange = "INV:003";
    }

    public static class GeneralConstants
    {
        public const int One = 1;
        public const int Zero = 0;
        public const int NegativeOne = -1;
        public const int Two = 2;
    }

    public static class NumberConstant
    {
        public const int MinAllowed = 1;
        public const int MaxAllowed = 32000;
    }

    public static class MathHelper
    {
        public static int Mod(int number, int divisor)
        {
            return number % divisor;
        }
    }

    public static class ValidationHelper
    {
        public static bool AreTheyMatch(int number, int eq)
        {
            return number == eq;
        }

        public static bool IsEven(int number)
        {
            return MathHelper.Mod(number, GeneralConstants.Two) == GeneralConstants.Zero;
        }

        public static bool IsWithinRange(int number)
        {
            return number >= NumberConstant.MinAllowed && number <= NumberConstant.MaxAllowed;
        }

        public static bool IsValidNumber(string input, out int number)
        {
            return int.TryParse(input, out number);
        }
    }

    public static class InputHelper
    {
        public static int GetNumberFromUser(Language language)
        {
            // Debug output to verify language
            Console.WriteLine($"[DEBUG] Current language: {language}");

            string message = language == Language.Arabic ? ArMessages.EnterNumber : EnMessages.EnterNumber;
            int number = GeneralConstants.Zero;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write($"{message}: ");

                try
                {
                    string input = Console.ReadLine();

                    if (!ValidationHelper.IsValidNumber(input, out number))
                    {
                        string errorMsg = language == Language.Arabic ? ArMessages.InvalidNumber : EnMessages.InvalidNumber;
                        Console.WriteLine($"{ErrorCodes.CouldNotConvertToNumber} - {errorMsg}");
                        continue;
                    }

                    if (!ValidationHelper.IsWithinRange(number))
                    {
                        string errorMsg = language == Language.Arabic ?
                            string.Format(ArMessages.NumberOutOfRange, NumberConstant.MinAllowed, NumberConstant.MaxAllowed) :
                            string.Format(EnMessages.NumberOutOfRange, NumberConstant.MinAllowed, NumberConstant.MaxAllowed);
                        Console.WriteLine($"{ErrorCodes.NumberOutOfRange} - {errorMsg}");
                        continue;
                    }

                    isValid = true;
                }
                catch (Exception ex)
                {
                    string errorMsg = language == Language.Arabic ? ArMessages.ErrorOccurred : EnMessages.ErrorOccurred;
                    Console.WriteLine($"{errorMsg}{ex.Message}");
                }
            }

            return number;
        }

        public static Language GetUserLanguage()
        {
            Console.WriteLine("Select Language / اختر اللغة:");
            Console.WriteLine("1. English");
            Console.WriteLine("2. العربية");
            Console.Write("Enter your choice (1 or 2): ");

            string input = Console.ReadLine();

            // Check if input is valid
            if (int.TryParse(input, out int choice))
            {
                if (choice == 1)
                {
                    Console.WriteLine("[DEBUG] English selected");
                    return Language.English;
                }
                else if (choice == 2)
                {
                    Console.WriteLine("[DEBUG] Arabic selected");
                    return Language.Arabic;
                }
            }

            Console.WriteLine("Invalid choice! Defaulting to English.");
            return Language.English;
        }
    }

    public static class OutputHelper
    {
        public static void Print(int messageTitle, string messageDescription, object value)
        {
            Console.WriteLine($"======= {messageTitle} =======");
            Console.WriteLine($"{messageDescription}: {value}");
            Console.WriteLine(new string('=', 30));
        }

        public static void PrintResult(int number, bool isEven, Language language)
        {
            // Debug output
            Console.WriteLine($"[DEBUG] PrintResult - Language: {language}");

            string resultMessage;
            if (language == Language.Arabic)
            {
                resultMessage = isEven ? ArMessages.ItIsEven : ArMessages.ItIsOdd;
                Console.WriteLine($"[DEBUG] Using Arabic message: {resultMessage}");
            }
            else
            {
                resultMessage = isEven ? EnMessages.ItIsEven : EnMessages.ItIsOdd;
                Console.WriteLine($"[DEBUG] Using English message: {resultMessage}");
            }

            Print(GeneralConstants.One, "Result", resultMessage);
            Console.WriteLine($"Number: {number} {(isEven ? "(Even)" : "(Odd)")}");
            Console.WriteLine();
        }

        public static void PrintWelcomeMessage(Language language)
        {
            Console.Clear();
            Console.WriteLine(new string('*', 50));

            if (language == Language.Arabic)
            {
                Console.WriteLine("   مرحباً بك في برنامج التحقق من الأرقام");
                Console.WriteLine($"[DEBUG] Welcome in Arabic");
            }
            else
            {
                Console.WriteLine("   Welcome to Number Checker Program");
                Console.WriteLine($"[DEBUG] Welcome in English");
            }

            Console.WriteLine(new string('*', 50));
            Console.WriteLine();
        }

        public static void PrintExitMessage(Language language)
        {
            Console.WriteLine();

            if (language == Language.Arabic)
            {
                Console.WriteLine("شكراً لاستخدام البرنامج. وداعاً!");
            }
            else
            {
                Console.WriteLine("Thank you for using the program. Goodbye!");
            }

            Console.WriteLine(new string('*', 50));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // FIX: Set console to support Unicode (Arabic) characters
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // FIX: Set the console font to support Arabic (optional but recommended)
            try
            {
                Console.Title = "Number Checker - Perfect Odd/Even";
                // Don't set foreground color globally, it might affect readability
                // Console.ForegroundColor = ConsoleColor.Cyan;
            }
            catch { /* Ignore if console doesn't support color changes */ }

            try
            {
                Language selectedLanguage = InputHelper.GetUserLanguage();
                Console.WriteLine($"[DEBUG] Selected language: {selectedLanguage}");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

                bool continueProgram = true;

                while (continueProgram)
                {
                    OutputHelper.PrintWelcomeMessage(selectedLanguage);

                    int number = InputHelper.GetNumberFromUser(selectedLanguage);
                    bool isEven = ValidationHelper.IsEven(number);

                    OutputHelper.PrintResult(number, isEven, selectedLanguage);

                    Console.Write(selectedLanguage == Language.Arabic ? "هل تريد التحقق من رقم آخر؟ (ن/لا): " : "Do you want to check another number? (y/n): ");
                    string response = Console.ReadLine()?.ToLower();

                    if (response == "n" || response == "لا")
                    {
                        continueProgram = false;
                    }
                }

                OutputHelper.PrintExitMessage(selectedLanguage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}