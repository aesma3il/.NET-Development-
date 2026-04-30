using System;
using System.Collections.Generic;

namespace CommisionStrategyWithSpecificPattern
{
    // =========================
    // Specification Interface
    // =========================
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }

    // =========================
    // Specifications
    // =========================
    public class AmountRangeSpecification : ISpecification<decimal>
    {
        private decimal _min;
        private decimal _max;

        public AmountRangeSpecification(decimal min, decimal max)
        {
            _min = min;
            _max = max;
        }

        public bool IsSatisfiedBy(decimal amount)
        {
            if (amount >= _min && amount < _max)
            {
                return true;
            }
            return false;
        }
    }

    public class GreaterThanOrEqualSpecification : ISpecification<decimal>
    {
        private decimal _value;

        public GreaterThanOrEqualSpecification(decimal value)
        {
            _value = value;
        }

        public bool IsSatisfiedBy(decimal amount)
        {
            if (amount >= _value)
            {
                return true;
            }
            return false;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> _left;
        private ISpecification<T> _right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public bool IsSatisfiedBy(T entity)
        {
            if (_left.IsSatisfiedBy(entity) && _right.IsSatisfiedBy(entity))
            {
                return true;
            }
            return false;
        }
    }

    // =========================
    // Strategy Interface
    // =========================
    public interface ICommissionStrategy
    {
        decimal Calculate(decimal amount);
    }

    // =========================
    // Strategies (ONLY calculation)
    // =========================
    public class LowCommissionStrategy : ICommissionStrategy
    {
        public decimal Calculate(decimal amount)
        {
            return amount * 0.01m;
        }
    }

    public class MidCommissionStrategy : ICommissionStrategy
    {
        public decimal Calculate(decimal amount)
        {
            return amount * 0.015m;
        }
    }

    public class HighCommissionStrategy : ICommissionStrategy
    {
        public decimal Calculate(decimal amount)
        {
            return amount * 0.02m;
        }
    }

    public class PremiumCommissionStrategy : ICommissionStrategy
    {
        public decimal Calculate(decimal amount)
        {
            return amount * 0.025m;
        }
    }

    // =========================
    // Rule (Specification + Strategy)
    // =========================
    public class CommissionRule
    {
        private ISpecification<decimal> _specification;
        private ICommissionStrategy _strategy;

        public CommissionRule(ISpecification<decimal> specification, ICommissionStrategy strategy)
        {
            _specification = specification;
            _strategy = strategy;
        }

        public bool IsMatch(decimal amount)
        {
            return _specification.IsSatisfiedBy(amount);
        }

        public decimal Calculate(decimal amount)
        {
            return _strategy.Calculate(amount);
        }
    }

    // =========================
    // Context
    // =========================
    public class CommissionContext
    {
        private List<CommissionRule> _rules;

        public CommissionContext(List<CommissionRule> rules)
        {
            _rules = rules;
        }

        public decimal Calculate(decimal amount)
        {
            for (int i = 0; i < _rules.Count; i++)
            {
                CommissionRule rule = _rules[i];

                if (rule.IsMatch(amount))
                {
                    return rule.Calculate(amount);
                }
            }

            throw new Exception("No matching rule found.");
        }
    }

    // =========================
    // Program
    // =========================
    class Program
    {
        static void Main(string[] args)
        {
            List<CommissionRule> rules = new List<CommissionRule>();

            rules.Add(new CommissionRule(
                new AmountRangeSpecification(0, 1000),
                new LowCommissionStrategy()));

            rules.Add(new CommissionRule(
                new AmountRangeSpecification(1000, 5000),
                new MidCommissionStrategy()));

            rules.Add(new CommissionRule(
                new AmountRangeSpecification(5000, 10000),
                new HighCommissionStrategy()));

            rules.Add(new CommissionRule(
                new GreaterThanOrEqualSpecification(10000),
                new PremiumCommissionStrategy()));

            CommissionContext context = new CommissionContext(rules);

            decimal amount = 7500;
            decimal commission = context.Calculate(amount);

            Console.WriteLine("Commission: " + commission);

            Console.ReadKey();
        }
    }
}