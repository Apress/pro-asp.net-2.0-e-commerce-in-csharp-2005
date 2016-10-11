using System;
using System.Collections.Generic;
using System.Text;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Update;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessUpdateShoppingCart : IBusinessLogic
	{
		private ShoppingCart _shoppingcart;

		public ProcessUpdateShoppingCart()
		{

		}

		public void Invoke()
		{
			ShoppingCartUpdateData shoppingcartdata = new ShoppingCartUpdateData();
			shoppingcartdata.ShoppingCart = this.ShoppingCart;
			shoppingcartdata.Update();
		}

		public ShoppingCart ShoppingCart
		{
			get { return _shoppingcart; }
			set { _shoppingcart = value; }
		}
	}
}
