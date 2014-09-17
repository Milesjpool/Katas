using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
	public class CheckoutTests
	{

		private readonly Checkout _checkout = new Checkout();

		[Test]
		public void EmptyBasketTest()
		{
			Assert.That(_checkout.BasketScan(""), Is.EqualTo(0));
		}

		[Test]
		public void ItemABasketTest()
		{
			Assert.That(_checkout.BasketScan("A"), Is.EqualTo(50));
		}

		[Test]
		public void ItemBBasketTest()
		{
			Assert.That(_checkout.BasketScan("B"), Is.EqualTo(30));
		}

		[Test]
		public void ItemCBasketTest()
		{
			Assert.That(_checkout.BasketScan("C"), Is.EqualTo(20));
		}

		[Test]
		public void ItemDBasketTest()
		{
			Assert.That(_checkout.BasketScan("D"), Is.EqualTo(15));
		}

		[Test]
		public void MultiUniqueItemsTest()
		{
			Assert.That(_checkout.BasketScan("ABCD"), Is.EqualTo(115));
		}
	}
}
