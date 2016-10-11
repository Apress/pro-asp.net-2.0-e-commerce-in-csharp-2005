using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Insert
{
	public class ShoppingCartInsertData : DataAccessBase
	{
		private ShoppingCart _shoppingcart;
		private ShoppingCartInsertDataParameters _shoppingcartinsertdataparameters;
		
		public ShoppingCartInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.ShoppingCart_Insert.ToString();
		}

		public void Add()
		{
			_shoppingcartinsertdataparameters = new ShoppingCartInsertDataParameters( ShoppingCart );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			dbhelper.Parameters = _shoppingcartinsertdataparameters.Parameters;
			dbhelper.Run();
		}

		public ShoppingCart ShoppingCart
		{
			get { return _shoppingcart; }
			set { _shoppingcart = value; }
		}
	}

	public class ShoppingCartInsertDataParameters
	{
		private ShoppingCart _shoppingcart;
		private SqlParameter[ ] _parameters;

		public ShoppingCartInsertDataParameters( ShoppingCart shoppingcart )
		{
			ShoppingCart = shoppingcart;
			Build();
		}

		private void Build()
		{
			SqlParameter[ ] parameters =
		    {
		        new SqlParameter( "@CartGUID"  , ShoppingCart.CartGUID ) ,
				new SqlParameter( "@ProductID" , ShoppingCart.ProductID ) ,
				new SqlParameter( "@Quantity"  , ShoppingCart.Quantity )
		    };

			Parameters = parameters;
		}

		public ShoppingCart ShoppingCart
		{
			get { return _shoppingcart; }
			set { _shoppingcart = value; }
		}

		public SqlParameter[] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
		}
	}
}
