using System;

namespace Discount_Calculator_Demo_Using_Rules_Design_Pattern.Rules
{
	class LoyalCustomerDiscountRule : IDiscountRule
	{
		public int RuleOrder => 2;

		public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
		{
			if (customer.DateOfFirstPurchase.HasValue)
			{
				if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-15))
				{
					return .15m;
				}

				if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
				{
					return .12m;
				}

				if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
				{
					return .10m;
				}

				if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-2))
				{
					return .08m;
				}

				if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1))
				{
					return .05m;
				}
			}

			return 0;
		}
	}
}
