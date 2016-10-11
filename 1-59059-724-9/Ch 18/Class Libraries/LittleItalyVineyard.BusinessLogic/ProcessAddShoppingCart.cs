using System;
using System.Collections.Generic;
using System.Text;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Insert;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessAddShoppingCart : IBusinessLogic
	{
		private ShoppingCart _shoppingcart;

		public ProcessAddShoppingCart()
		{

		}

		public void Invoke()
		{
			ShoppingCartInsertData shoppingcartdata = new ShoppingCartInsertData();
			shoppingcartdata.ShoppingCart = this.ShoppingCart;
			shoppingcartdata.Add();
		}

		public ShoppingCart ShoppingCart
		{
			get { return _shoppingcart; }
			set { _shoppingcart = value; }
		}
	}
}
