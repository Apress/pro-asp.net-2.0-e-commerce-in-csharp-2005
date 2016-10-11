using System;
using System.Collections.Generic;
using System.Text;

namespace LittleItalyVineyard.Common
{
	public class ShoppingCart
	{
		private int _shoppingcartid;
		private string _cartguid;
		private int _quantity;
		private int _productid;
		private DateTime _datecreated;

		public ShoppingCart()
		{

		}

		public int ShoppingCartID
		{
			get { return _shoppingcartid; }
			set { _shoppingcartid = value; }
		}

		public string CartGUID
		{
			get { return _cartguid; }
			set { _cartguid = value; }
		}

		public int Quantity
		{
			get { return _quantity; }
			set { _quantity = value; }
		}
		
		public int ProductID
		{
			get { return _productid; }
			set { _productid = value; }
		}
		
		public DateTime DateCreated
		{
			get { return _datecreated; }
			set { _datecreated = value; }
		}
	}
}
