using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Update
{
	public class ShoppingCartUpdateData : DataAccessBase
	{
		private ShoppingCart _shoppingcart;
		private ShoppingCartUpdateDataParameters _shoppingcartupdatedataparameters;

		public ShoppingCartUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.ShoppingCart_Update.ToString();
		}

		public void Update()
		{
			_shoppingcartupdatedataparameters = new ShoppingCartUpdateDataParameters( ShoppingCart );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			dbhelper.Parameters = _shoppingcartupdatedataparameters.Parameters;
			dbhelper.Run();
		}

		public ShoppingCart ShoppingCart
		{
			get { return _shoppingcart; }
			set { _shoppingcart = value; }
		}
	}

	public class ShoppingCartUpdateDataParameters
	{
		private ShoppingCart _shoppingcart;
		private SqlParameter[] _parameters;

		public ShoppingCartUpdateDataParameters( ShoppingCart shoppingcart )
		{
			ShoppingCart = shoppingcart;
			Build();
		}

		private void Build()
		{
			SqlParameter[] parameters =
		    {
		        new SqlParameter( "@Quantity"		, ShoppingCart.Quantity ) ,
				new SqlParameter( "@ShoppingCartID" , ShoppingCart.ShoppingCartID )
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
