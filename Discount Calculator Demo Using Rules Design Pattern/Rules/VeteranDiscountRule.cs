namespace Discount_Calculator_Demo_Using_Rules_Design_Pattern.Rules
{
	class VeteranDiscountRule : IDiscountRule
	{
		public int RuleOrder => 4;

		public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
		{
			if (customer.IsVeteran)
			{
				return .10m;
			}

			return 0;
		}
	}
}
