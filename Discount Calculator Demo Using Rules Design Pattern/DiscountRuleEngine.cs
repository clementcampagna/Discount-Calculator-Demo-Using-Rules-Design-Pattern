using System;
using System.Collections.Generic;

namespace Discount_Calculator_Demo_Using_Rules_Design_Pattern
{
	public class DiscountRuleEngine
	{
		readonly List<IDiscountRule> _rules = new List<IDiscountRule>();

		public DiscountRuleEngine(IEnumerable<IDiscountRule> rules)
		{
			_rules.AddRange(rules);
		}

		public decimal CalculateDiscountPercentage(Customer customer)
		{
			decimal discount = 0m;

			foreach (var rule in _rules)
			{
				discount = Math.Max(discount, rule.CalculateDiscount(customer, discount));
			}

			return discount;
		}
	}
}
