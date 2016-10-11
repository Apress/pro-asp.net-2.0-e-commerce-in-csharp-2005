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

		public bool Invoke()
		{
			bool complete = false;

			try
			{
				ShoppingCartUpdateData shoppingcartdata = new ShoppingCartUpdateData();
				shoppingcartdata.ShoppingCart = this.ShoppingCart;
				shoppingcartdata.Update();

				complete = true;
			}
			catch ( Exception ex )
			{
				throw ex;
			}

			return complete;
		}

		public ShoppingCart ShoppingCart
		{
			get { return _shoppingcart; }
			set { _shoppingcart = value; }
		}
	}
}
