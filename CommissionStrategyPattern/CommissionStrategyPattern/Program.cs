using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionStrategyPattern
{

    /*
     * 
     * this is the fix and violate the concepts
     * 
     if (amount >= 0 && amount < 1000)
    commission = amount * 0.01;
    else if (amount >= 1000 && amount < 5000)
    commission = amount * 0.015;
    else if (amount >= 5000 && amount < 10000)
    commission = amount * 0.02;
    else
    commission = amount * 0.025;
     
     
     */
    public interface ICommissionStrategy
    {
        bool IsApplicable(decimal amount);
        decimal Calculate(decimal amount);
    }

    public class LowCommissionStrategy : ICommissionStrategy
    {
        public bool IsApplicable(decimal amount)
            => amount >= 0 && amount < 1000;

        public decimal Calculate(decimal amount)
            => amount * 0.01m;
    }

    public class MidCommissionStrategy : ICommissionStrategy
    {
        public bool IsApplicable(decimal amount)
            => amount >= 1000 && amount < 5000;

        public decimal Calculate(decimal amount)
            => amount * 0.015m;
    }

    public class HighCommissionStrategy : ICommissionStrategy
    {
        public bool IsApplicable(decimal amount)
            => amount >= 5000 && amount < 10000;

        public decimal Calculate(decimal amount)
            => amount * 0.02m;
    }

    public class PremiumCommissionStrategy : ICommissionStrategy
    {
        public bool IsApplicable(decimal amount)
            => amount >= 10000;

        public decimal Calculate(decimal amount)
            => amount * 0.025m;
    }

    public class CommissionContext
    {
        private readonly IEnumerable<ICommissionStrategy> _strategies;

        public CommissionContext(IEnumerable<ICommissionStrategy> strategies)
        {
            _strategies = strategies;
        }

        public decimal Calculate(decimal amount)
        {
            var strategy = _strategies
                .FirstOrDefault(s => s.IsApplicable(amount));

            if (strategy == null)
                throw new InvalidOperationException("No commission strategy found.");

            return strategy.Calculate(amount);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            var strategies = new List<ICommissionStrategy>
{
    new LowCommissionStrategy(),
    new MidCommissionStrategy(),
    new HighCommissionStrategy(),
    new PremiumCommissionStrategy()
};

            var context = new CommissionContext(strategies);

            decimal amount = 7500;
            decimal commission = context.Calculate(amount);

            Console.WriteLine($"Commission: {commission}");


            Console.ReadKey();
        }
    }
}
