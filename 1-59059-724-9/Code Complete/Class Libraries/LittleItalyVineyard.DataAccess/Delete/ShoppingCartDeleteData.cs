using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Delete
{
	public class ShoppingCartDeleteData : DataAccessBase
	{
		private ShoppingCart _shoppingcart;
		private ShoppingCartDeleteDataParameters _shoppingcartdeletedataparameters;

		public ShoppingCartDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.ShoppingCart_Delete.ToString();
		}

		public void Delete()
		{
			_shoppingcartdeletedataparameters = new ShoppingCartDeleteDataParameters( ShoppingCart );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			dbhelper.Parameters = _shoppingcartdeletedataparameters.Parameters;
			dbhelper.Run();
		}

		public ShoppingCart ShoppingCart
		{
			get { return _shoppingcart; }
			set { _shoppingcart = value; }
		}
	}

	public class ShoppingCartDeleteDataParameters
	{
		private ShoppingCart _shoppingcart;
		private SqlParameter[] _parameters;

		public ShoppingCartDeleteDataParameters( ShoppingCart shoppingcart )
		{
			ShoppingCart = shoppingcart;
			Build();
		}

		private void Build()
		{
			SqlParameter[] parameters =
		    {
		        new SqlParameter( "@ShoppingCartID"  , ShoppingCart.ShoppingCartID )
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
