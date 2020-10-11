using System;
using System.Collections.Generic;
using System.Linq;

namespace Discount_Calculator_Demo_Using_Rules_Design_Pattern
{
	public class DiscountCalculator
	{
		public decimal CalculateDiscountPercentage(Customer customer)
		{
			/*We can add each rule class individually to make a list of rules to calculate the discount ratio.
			  But this is far from being efficient, and prone to mistakes (we may forgot to add a rule for example)*/

			/*var rules = new List<IDiscountRule>();

			rules.Add(new Rules.FirstTimeCustomerDiscountRule());
			rules.Add(new Rules.LoyalCustomerDiscountRule());
			rules.Add(new Rules.CustomerBirthdayDiscountRule());
			rules.Add(new Rules.VeteranDiscountRule());
			rules.Add(new Rules.SeniorDiscountRule());

			var engine = new DiscountRuleEngine(rules);

			return engine.CalculateDiscountPercentage(customer);*/

			//--------------------------------------------------------------

			/*Or we can use a simple reflection technique to automatically discover discount rules used 
			  to calculate the correct discount ratio (the rules order is important!) */

			var ruleType = typeof(IDiscountRule);

			IEnumerable<IDiscountRule> rules = this.GetType().Assembly.GetTypes()
				.Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface)
				.Select(r => Activator.CreateInstance(r) as IDiscountRule)
				.OrderBy(p => p.RuleOrder);

			var engine = new DiscountRuleEngine(rules);

			return engine.CalculateDiscountPercentage(customer);
		}
	}
}
