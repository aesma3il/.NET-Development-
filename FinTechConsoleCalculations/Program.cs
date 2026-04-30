using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace FinTechConsoleCalculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Customer
            Accounts
            Transactions
            Deposit
            withdrawal
            transfer
            fees

             
             */


       


            ReadKey();
        }
    }




    /*
     * CodeISO
NumericCode
Name
Nativename
Symbol
SymoalPostion
DecimalDigits
Minorunit
SmallestDenomination
RoudingMode
RoundingIncrement
DecimalSeparator
FormatPttern
IsActive
IsBaseCurrency
IsDefault
     
     
     */

    public class Currency
    {

        public int Id;
        public string Code;
        public short NumericCode;
        public string Name;
        public string NativeName;
        public string Symbol;
        public byte DecimalDigits;
        public byte MinorUnit;
        public decimal SmallestDenomination;

        public decimal RoundingIncrement;
        public char DecimalSeparator;
        public string FormatPattern;


        public bool IsActive;
        public bool IsDefault;
        public bool IsAllowedForTransactions;
        public bool IsBaseCurrency;
        //SymbolPosition
        enum SymbolPosition
        {
            Before,
            After
        }

        enum enRoundingMode
        {
            Up,
            Down,
            HalfUp,
            HalfDown,
            Ceiling,
            Floor,
            HalfEven
        }
    }




    public class Item
    {
        public int ItemID;
        public char[] Code = new char[3];
        public string Name;
        public string Description;
        public bool IsActive = false;
        public int Quantity;
        public decimal UnitPrice;
        public decimal FixedDiscount;
        public decimal PercentageDiscount;
        public decimal Tax;
    }

    public struct Discount
    {

    }

    public class OrderLine
    {
        int Id;
        int ItemID;
        int Qty;
        decimal Discount;
        decimal Tax;
        decimal Fees;
        decimal UnitPrice;
        decimal Subtotal;
        decimal NetAmount;

    }
}
