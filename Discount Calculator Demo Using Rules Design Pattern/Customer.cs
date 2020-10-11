using System;

namespace Discount_Calculator_Demo_Using_Rules_Design_Pattern
{
	public class Customer
	{
		public String Name { get; set; }
		public DateTime? DateOfFirstPurchase { get; set; } // ? after the return type indicates that the return can be null
		public Nullable<DateTime> DateOfBirth { get; set; } // <Nullable> can also be used instead of ? for the same purpose
		public bool IsVeteran { get; set; }

		public Customer(string name, bool isVeteran)
		{
			Name = name;
			IsVeteran = isVeteran;
		}

		public Customer(string name, DateTime? dateOfFirstPurchase, bool isVeteran)
		{
			Name = name;
			DateOfFirstPurchase = dateOfFirstPurchase;
			IsVeteran = isVeteran;
		}

		public Customer(string name, DateTime? dateOfFirstPurchase, DateTime? dateOfBirth, bool isVeteran)
		{
			Name = name;
			DateOfFirstPurchase = dateOfFirstPurchase;
			DateOfBirth = dateOfBirth;
			IsVeteran = isVeteran;
		}

		public Customer(int age, DateTime? dateOfFirstPurchase)
		{
			DateOfBirth = DateTime.Today.AddYears(age);
			DateOfFirstPurchase = dateOfFirstPurchase;
		}
	}
}
