namespace Discount_Calculator_Demo_Using_Rules_Design_Pattern.Rules
{
	class FirstTimeCustomerDiscountRule : IDiscountRule
	{
		public int RuleOrder => 1;

		public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
		{
			if (!customer.DateOfFirstPurchase.HasValue) // Gives a 15% discount to a first-time customer
			{
				return .15m;
			}

			return 0;
		}
	}
}
