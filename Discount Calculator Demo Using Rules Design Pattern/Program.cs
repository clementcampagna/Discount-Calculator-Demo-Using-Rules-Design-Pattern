using System;

namespace Discount_Calculator_Demo_Using_Rules_Design_Pattern
{
	class Program
	{
		static void Main(string[] args)
		{
			Customer customer = new Customer(name: "Joe", isVeteran:false)
			{
				DateOfBirth = new DateTime(1980, 10, 09),
				DateOfFirstPurchase = new DateTime(2018, 11, 22)
			};

			DiscountCalculator discountCalc = new DiscountCalculator();
			Console.WriteLine("Customer's name: " + customer.Name);
			Console.WriteLine("Customer's discount rate: " + discountCalc.CalculateDiscountPercentage(customer));

			//Please check TestClass.cs for examples of what can be expected from this demo
		}
	}
}
