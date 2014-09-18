using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
	public class Checkout
	{
		private Dictionary<Char, Item> ShopInventory = new Dictionary<Char, Item>()
			{
				{'A', new Item('A', 50)},
				{'B', new Item('B', 30)},
				{'C', new Item('C', 20)},
				{'D', new Item('D', 15)}
			};

		private List<Offer> AvailableOffers = new List<Offer>()
			{
				{new Offer(3, 'A', 130)},
				{new Offer(2, 'B', 45)}
			};


		public int GoShopping(String shoppingList)
		{
			var basket = FillBasket(shoppingList);
			int price = CheckoutBasket(basket);
			return price;
		}


		private List<Item> FillBasket(string shoppingList)
		{
			var basket = new List<Item>();

			foreach (char ingredient in shoppingList)
			{
				var item = FindItem(ingredient);
				if (item != null) basket.Add(item);
			}
			return basket;
		}


		private Item FindItem(char ingredient)
		{
			Item item;
			if (ShopInventory.TryGetValue(ingredient, out item))
			{
				return item;
			}
			return null;
		}


		private int CheckoutBasket(List<Item> basket)
		{
			int total = 0;
			total += CheckoutOffers(basket);
			total += CheckoutRest(basket);
			return total;
		}


		private int CheckoutOffers(List<Item> basket)
		{
			int total = 0;
			foreach (Offer offer in AvailableOffers)
			{
				int instancesOfOffer = GetNumInstancesOfOffer(basket, offer);
				total += instancesOfOffer*offer.OfferPrice;
				basket = RemoveFromBasket(basket, offer.EligibleItem, instancesOfOffer*offer.Quantity);
			}
			return total;
		}


		private int GetNumInstancesOfOffer(List<Item> basket, Offer offer)
		{
			return (basket.Count(i => i.Name == offer.EligibleItem))/(offer.Quantity);
		}


		private int CheckoutRest(List<Item> basket)
		{
			int total = 0;
			foreach (Item scannedItem in basket)
			{
				total += scannedItem.Price;
			}
			basket.Clear();
			return total;
		}

		private List<Item> RemoveFromBasket(List<Item> basket, char itemName, int quantity)
		{
			for (int i = 0; i < quantity; i++)
			{
				basket.Remove(FindItem(itemName));
			}
			return basket;
		}
	}


	internal class Item
	{
		public char Name { get; private set; }
		public int Price { get; private set; }

		public Item(char name, int price)
		{
			Name = name;
			Price = price;
		}
	}


	internal class Offer
	{
		public Char EligibleItem { get; private set; }
		public int Quantity { get; private set; }
		public int OfferPrice { get; private set; }

		public Offer(int quantity, char eligibleItem, int offerPrice)
		{
			Quantity = quantity;
			EligibleItem = eligibleItem;
			OfferPrice = offerPrice;
		}
	}
}