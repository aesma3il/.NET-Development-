using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CalculatorCSharpOOPPerfect
{


    public struct ProjectDetails
    {
        public string ProjectName;
        public string ProjectAuthor;
        public void PrintProjectDetails()
        {
            Console.WriteLine("Project Name:" + this.ProjectName);
            Console.WriteLine("Project Author: " + this.ProjectAuthor);
        }
    }




    internal class Program
    {
        static void Main(string[] args)
        { 
            ProjectDetails project;
            project.ProjectName = "Perfect Calculator with Good Concepts";
            project.ProjectAuthor = "Abdullah Esmail";
            project.PrintProjectDetails();

            // Menu
            Dictionary<int, string> menu = new Dictionary<int, string>()
    {
        {1, "Add"},
        {2, "Subtract"},
        {3, "Multiply"},
        {4, "Divide"},
        {5, "Mod"},
        {6, "Show History"},
        {7, "Exit"}
    };

            // Operations (OOP)
            Dictionary<int, IOperation> operations = new Dictionary<int, IOperation>()
    {
        {1, new AddOperation()},
        {2, new SubtractOperation()},
        {3, new Multiplication()},
        {4, new DivisionOperation()},
        {5, new ModOperation()}
    };

            ILoggerService logger = new FileLogger();
            HistoryService historyService = new HistoryService();

            logger.LogInfo("Application started");

            while (true)
            {
                WriteLine("\n===== MENU =====");

                foreach (var item in menu)
                {
                    WriteLine($"{item.Key} - {item.Value}");
                }

                WriteLine("=============================");

                int choice = ReadChoice(menu);

                if (choice == 7)
                {
                    WriteLine("Program exiting...");
                    logger.LogInfo("Application stopped");
                    break;
                }

                // 📜 Show History
                if (choice == 6)
                {
                    WriteLine("===== HISTORY =====");

                    var history = historyService.GetAll();

                    if (history.Count == 0)
                        WriteLine("No calculations yet.");
                    else
                        history.ForEach(h => WriteLine(h));

                    continue;
                }

                int firstNumber = ReadNumber("Enter First Number");
                int secondNumber = ReadNumber("Enter Second Number");

                try
                {
                    var operation = operations[choice];

                    int result = operation.Execute(firstNumber, secondNumber);

                    string record = $"{firstNumber} {operation.Name} {secondNumber} = {result}";

                    WriteLine("Result: " + result);

                    historyService.Save(record);
                    logger.LogInfo(record);
                }
                catch (Exception ex)
                {
                    WriteLine("Error: " + ex.Message);
                    logger.LogError(ex.Message);
                }
            }

            ReadKey();
        }

        static int ReadNumber(string prompt)
        {
            int n;

            while (true)
            {
                WriteLine(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out n))
                {
                    return n;
                }
                WriteLine("Invalid input! Please enter a valid number.");


            }

        }


        static int ReadChoice(Dictionary<int, string> menu)
        {
            int choice;
            while (true)
            {
                Console.WriteLine("Enter your choice");
                string input;
                input = ReadLine();

                if (int.TryParse(input, out choice) && menu.ContainsKey(choice))
                {
                    return choice;
                }
                WriteLine("Invalid choice! Try again.");
            }
        }

        public interface IOperation
        {
            string Name { get; }
            int Execute(int a, int b);

        }

        public class AddOperation : IOperation
        {
            public string Name => "Add";

            public int Execute(int a, int b)
            {
                return a + b;
            }
        }

        public class SubtractOperation : IOperation
        {
            public string Name => "Subtract";

            public int Execute(int a, int b)
            {
                return a - b;
            }

        }

        public class Multiplication : IOperation
        {
            public string Name => "Multiply";
            public int Execute(int a, int b)
            {
                return a * b;
            }
        }


        public class DivisionOperation : IOperation
        {
            public string Name => "Division";

            public int Execute(int a, int b)
            {
                if (b == 0)
                {
                    throw new Exception("Can divide by zero");
                }

                return a / b;
            }
        }


        public class ModOperation : IOperation
        {
            public string Name => "Modulo";
            public int Execute(int a, int b)
            {
                if (b == 0)
                    throw new Exception("Can not divide by zero");

                return a % b;
            }
        }



        public interface ILoggerService
        {
            void LogInfo(string message);
            void LogError(string message);
        }


        public class FileLogger : ILoggerService
        {
            private readonly string filePath = "log.txt";

            public void LogInfo(string message)
            {
                File.AppendAllText(filePath, $"[INFO] {DateTime.Now}: {message}\n");
            }

            public void LogError(string message)
            {
                File.AppendAllText(filePath, $"[ERROR] {DateTime.Now}: {message}\n");
            }
        }

        public class HistoryService
        {
            private readonly string filePath = "history.txt";

            public void Save(string record)
            {
                File.AppendAllText(filePath, record + "\n");
            }

            public List<string> GetAll()
            {
                if (!File.Exists(filePath))
                    return new List<string>();

                return File.ReadAllLines(filePath).ToList();
            }
        }

        static int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        static int Subtract(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }
        static int Multiply(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }
        static int Divide(int firstNumber, int secondNumber)
        {
            return firstNumber / secondNumber;
        }
        static int Mod(int firstNumber, int secondNumber)
        {
            return firstNumber % secondNumber;
        }
    }
}
