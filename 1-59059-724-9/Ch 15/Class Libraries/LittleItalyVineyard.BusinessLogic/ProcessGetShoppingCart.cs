using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessGetShoppingCart : IBusinessLogic
	{
		private DataSet _resultset;
		private ShoppingCart _shoppingcart;

		public ProcessGetShoppingCart()
		{

		}

		public bool Invoke()
		{
			bool complete = false;

			ShoppingCartSelectData shoppingcartdata = new ShoppingCartSelectData();
			shoppingcartdata.ShoppingCart = ShoppingCart;
			ResultSet = shoppingcartdata.Get();
			complete = true;

			return complete;
		}

		public ShoppingCart ShoppingCart
		{
			get { return _shoppingcart; }
			set { _shoppingcart = value; }
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}
	}
}
