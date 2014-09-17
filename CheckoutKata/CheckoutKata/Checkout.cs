using System;
using System.Collections.Generic;

namespace CheckoutKata
{
	public class Checkout
	{
		private Dictionary<Char, int> priceList = new Dictionary<Char, int>()
			{
				{'A', 50},
				{'B', 30},
				{'C', 20},
				{'D', 15}
			};

		public int BasketScan(String basket)
		{
			int total = 0;
			foreach (char item in basket)
			{
				total += PriceLookup(item);
			}
			return total;
		}

		private int PriceLookup(char item)
		{
			int price;
			if (priceList.TryGetValue(item, out price))
			{
				return price;
			}
			return 0;
		}
	}
}