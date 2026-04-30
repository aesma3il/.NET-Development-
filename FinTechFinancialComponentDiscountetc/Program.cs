using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechFinancialComponentDiscountetc
{



    public enum CalculationType
    {
        Fixed,
        Percentage
    }


    public enum AmountDirection
    {
        Add,
        Subtract
    }

    public enum Scope
    {
        Line,
        Document
    }

    public enum BaseType
    {
        Subtotal,
        UnitPrice,
        Quantity,
        NetAmount
    }


    public class FinancialComponent
    {
        public string Name { get; protected set; }
        public decimal Value { get; protected set; }

        public CalculationType Type { get; protected set; }
        public BaseType BaseType { get; protected set; }
        public AmountDirection Direction { get; protected set; }
        public Scope Scope { get; protected set; }
        public int Priority { get; protected set; }

        protected FinancialComponent(
    string name,
    CalculationType type,
    decimal value,
    BaseType baseType,
    AmountDirection direction,
    Scope scope,
    int priority)
        {
            Name = name;
            Type = type;
            Value = value;
            BaseType = baseType;
            Direction = direction;
            Scope = scope;
            Priority = priority;
        }

        public virtual decimal Calculate(decimal baseAmount)
        {

            decimal result;

            switch (Type)
            {
                case CalculationType.Fixed:
                    result = Value;
                    break;

                case CalculationType.Percentage:
                    result = baseAmount * Value;
                    break;

                default:
                    result = 0;
                    break;
            }

            return Direction == AmountDirection.Subtract ? -result : result;


        }

    }


    public class Discount : FinancialComponent
    {
        public decimal? MaxCap { get; private set; }


        public Discount(decimal value, CalculationType type, decimal? maxCap = null) : base("", type, value, BaseType.Subtotal, AmountDirection.Subtract, Scope.Document, 1)
        {

            MaxCap = maxCap;
        }

        public override decimal Calculate(decimal baseAmount)
        {
            var result = base.Calculate(baseAmount);

            if (MaxCap.HasValue && Math.Abs(result) > MaxCap.Value)
                return -MaxCap.Value;

            return result;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
