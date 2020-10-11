namespace Discount_Calculator_Demo_Using_Rules_Design_Pattern
{
	public interface IDiscountRule
	{
		int RuleOrder { get; }

		decimal CalculateDiscount(Customer customer, decimal currentDiscount);
	}
}
