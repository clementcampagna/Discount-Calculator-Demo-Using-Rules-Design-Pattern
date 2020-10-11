using System;

namespace Discount_Calculator_Demo_Using_Rules_Design_Pattern.Rules
{
	class CustomerBirthdayDiscountRule : IDiscountRule
	{
		public int RuleOrder => 3;

		public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
		{
			if (customer.DateOfBirth <= DateTime.Today)
			{
				if (customer.DateOfBirth.Value.Month == DateTime.Today.Month &&
					  customer.DateOfBirth.Value.Day == DateTime.Today.Day)
				{
					return currentDiscount + .10m;
				}
			}

			return currentDiscount;
		}
	}
}
