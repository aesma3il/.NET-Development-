using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{

    public enum ConfirmResult
    {
        Confirmed,
        Cancelled
    }





    internal class Program
    {
        static void Main(string[] args)
        {
            ConfirmResult result = ShowDialog("Are you want to delete this record");

            if(result == ConfirmResult.Confirmed)
            {
                Console.WriteLine("Record is Deleted successfully");
            }
            else
            {
                Console.WriteLine("Cannclled");
            }



                Console.ReadKey();
        }

        static ConfirmResult ShowDialog(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("[y] Confirm");
            Console.WriteLine("[n] Cancelled");
           
            string choice;
            Console.WriteLine("Enter your Choice:");
            choice = Console.ReadLine();
            if (choice == "c" || choice == "C")
            {
                return ConfirmResult.Confirmed;
            }
          
            return ConfirmResult.Cancelled;
        }
    }
}
