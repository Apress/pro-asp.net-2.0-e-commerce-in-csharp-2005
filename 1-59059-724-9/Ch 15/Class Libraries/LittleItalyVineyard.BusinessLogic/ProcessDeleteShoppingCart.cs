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

		public bool Invoke()
		{
			bool complete = false;

			try
			{
				ShoppingCartDeleteData shoppingcartdata = new ShoppingCartDeleteData();
				shoppingcartdata.ShoppingCart = this.ShoppingCart;
				shoppingcartdata.Delete();

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
