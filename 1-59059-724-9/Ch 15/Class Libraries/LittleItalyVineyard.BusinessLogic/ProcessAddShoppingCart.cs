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

		public bool Invoke()
		{
			bool complete = false;

			try
			{
				ShoppingCartInsertData shoppingcartdata = new ShoppingCartInsertData();
				shoppingcartdata.ShoppingCart = this.ShoppingCart;
				shoppingcartdata.Add();
				
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
