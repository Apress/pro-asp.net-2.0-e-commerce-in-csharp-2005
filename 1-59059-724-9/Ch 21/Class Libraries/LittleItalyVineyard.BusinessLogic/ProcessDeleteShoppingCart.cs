using System;
using System.Collections.Generic;
using System.Text;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Delete;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessDeleteShoppingCart : IBusinessLogic
	{
		private ShoppingCart _shoppingcart;

		public ProcessDeleteShoppingCart()
		{

		}

		public void Invoke()
		{
			ShoppingCartDeleteData shoppingcartdata = new ShoppingCartDeleteData();
			shoppingcartdata.ShoppingCart = this.ShoppingCart;
			shoppingcartdata.Delete();
		}

		public ShoppingCart ShoppingCart
		{
			get { return _shoppingcart; }
			set { _shoppingcart = value; }
		}
	}
}
