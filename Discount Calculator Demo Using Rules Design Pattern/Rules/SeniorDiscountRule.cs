using System;

namespace Discount_Calculator_Demo_Using_Rules_Design_Pattern.Rules
{
	class SeniorDiscountRule : IDiscountRule
	{
		public int RuleOrder => 5;

		public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
		{
			if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
			{
				return .05m;
			}

			return 0;
		}
	}
}
