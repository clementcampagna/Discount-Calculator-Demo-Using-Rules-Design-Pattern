using FluentAssertions; // To install from Project > Manage NuGet Packages... > FluentAssertions
using System;
using Xunit; // To install from Project > Manage NuGet Packages... > xunit and xunit.runner.visualstudio

namespace Discount_Calculator_Demo_Using_Rules_Design_Pattern
{
	public class TestClass
	{
		private readonly DiscountCalculator _calculator = new DiscountCalculator();
		const string DEFAULT_NAME = "Joe";
		const int DEFAULT_AGE = 30;

		[Fact]
		public void Returns15PctForFirstTimeCustomers()
		{
			var customer = new Customer(name: DEFAULT_NAME, dateOfFirstPurchase: null, isVeteran: false);

			var result = _calculator.CalculateDiscountPercentage(customer);

			result.Should().Be(.15m);
		}

		[Theory]
		[InlineData(0, .0)]
		[InlineData(1, .05)]
		[InlineData(2, .08)]
		[InlineData(5, .10)]
		[InlineData(10, .12)]
		[InlineData(15, .15)]
		[InlineData(20, .15)]
		public void ReturnsCorrectPctDiscountForLoyalCustomers(int yearsAsCustomer, decimal expectedDiscount)
		{
			var customer = new Customer(age: DEFAULT_AGE, dateOfFirstPurchase: DateTime.Today.AddYears(-yearsAsCustomer).AddDays(-1));

			var result = _calculator.CalculateDiscountPercentage(customer);

			result.Should().Be(expectedDiscount);
		}

		[Theory]
		[InlineData(0, .10)]
		[InlineData(1, .15)]
		[InlineData(2, .18)]
		[InlineData(5, .20)]
		[InlineData(10, .22)]
		[InlineData(15, .25)]
		[InlineData(20, .25)]
		public void ReturnsCorrectLoyaltyDiscountForLoyalCustomersOnTheirBirthday(int yearsAsCustomer, decimal expectedDiscount)
		{
			var customer = new Customer(name: DEFAULT_NAME, dateOfFirstPurchase: DateTime.Today.AddYears(-yearsAsCustomer), dateOfBirth: DateTime.Today, isVeteran: false);

			var result = _calculator.CalculateDiscountPercentage(customer);

			result.Should().Be(expectedDiscount);
		}

		[Theory]
		[InlineData(0, .10)]
		[InlineData(1, .10)]
		[InlineData(2, .10)]
		[InlineData(5, .10)]
		[InlineData(10, .12)]
		[InlineData(15, .15)]
		[InlineData(20, .15)]
		//The 10 and 15 year loyal customer discounts (12 and 15 % respectively) are better than the veteran discount (10%), these customers should therefore benefit from it
		public void ReturnsCorrectPctDiscountForVeteransWhoAreAlsoLoyalCustomers(int yearsAsCustomer, decimal expectedDiscount)
		{
			var customer = new Customer(name: DEFAULT_NAME, dateOfFirstPurchase: DateTime.Today.AddYears(-yearsAsCustomer).AddDays(-1), isVeteran: true);

			var result = _calculator.CalculateDiscountPercentage(customer);

			result.Should().Be(expectedDiscount);
		}

		[Fact]
		public void Returns5PctForSeniorCustomers() //Senior customers are the ones aged 65 and over
		{
			var customer = new Customer(name: DEFAULT_NAME, dateOfFirstPurchase: DateTime.Today, dateOfBirth: new DateTime(1950, 08, 23), isVeteran: false);

			var result = _calculator.CalculateDiscountPercentage(customer);

			result.Should().Be(.05m);
		}

		[Fact]
		public void Returns0PctForBasicCustomers() //Customers who do not fit any of the criteria above have no discount applied
		{
			var customer = new Customer(age: DEFAULT_AGE, dateOfFirstPurchase: DateTime.Today.AddDays(-1));

			var result = _calculator.CalculateDiscountPercentage(customer);

			result.Should().Be(.0m);
		}
	}
}
