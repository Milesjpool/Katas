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
			Assert.That(_checkout.GoShopping(""), Is.EqualTo(0));
		}

		[Test]
		public void ItemABasketTest()
		{
			Assert.That(_checkout.GoShopping("A"), Is.EqualTo(50));
		}

		[Test]
		public void ItemBBasketTest()
		{
			Assert.That(_checkout.GoShopping("B"), Is.EqualTo(30));
		}

		[Test]
		public void ItemCBasketTest()
		{
			Assert.That(_checkout.GoShopping("C"), Is.EqualTo(20));
		}

		[Test]
		public void ItemDBasketTest()
		{
			Assert.That(_checkout.GoShopping("D"), Is.EqualTo(15));
		}

		[Test]
		public void MultiUniqueItemsTest()
		{
			Assert.That(_checkout.GoShopping("ABCD"), Is.EqualTo(115));
		}

		[Test]
		public void MulibuyATest()
		{
			Assert.That(_checkout.GoShopping("AAA"), Is.EqualTo(130));
		}

		[Test]
		public void MulibuyBTest()
		{
			Assert.That(_checkout.GoShopping("BB"), Is.EqualTo(45));
		}

		[Test]
		public void MulitipleMultibuysTest()
		{
			Assert.That(_checkout.GoShopping("ABABABB"), Is.EqualTo(220));
		}

		[Test]
		public void BigBasketTest1()
		{
			Assert.That(_checkout.GoShopping("ABABABCCD"), Is.EqualTo(260));
		}
	}
}
