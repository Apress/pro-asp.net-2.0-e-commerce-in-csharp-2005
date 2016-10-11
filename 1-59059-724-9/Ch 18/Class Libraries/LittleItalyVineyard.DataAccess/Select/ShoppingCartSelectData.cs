using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;
using Microsoft.ApplicationBlocks.Data;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class ShoppingCartSelectData : DataAccessBase
	{
		private ShoppingCart _shoppingcart;

		public ShoppingCartSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.ShoppingCart_Select.ToString();
		}

		public DataSet Get()
		{
			DataSet ds;

			ShoppingCartSelectDataParameters _shoppingcartselectdataparameters = new ShoppingCartSelectDataParameters( ShoppingCart );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			ds = dbhelper.Run( base.ConnectionString , _shoppingcartselectdataparameters.Parameters );

			return ds;
		}

		public ShoppingCart ShoppingCart
		{
			get { return _shoppingcart; }
			set { _shoppingcart = value; }
		}
	}

	public class ShoppingCartSelectDataParameters
	{
		private ShoppingCart _shoppingcart;
		private SqlParameter[ ] _parameters;

		public ShoppingCartSelectDataParameters( ShoppingCart shoppingcart )
		{
			ShoppingCart = shoppingcart;
			Build();
		}

		private void Build()
		{
			SqlParameter[ ] parameters =
		    {
		        new SqlParameter( "@CartGUID" , ShoppingCart.CartGUID )
		    };

			Parameters = parameters;
		}

		public ShoppingCart ShoppingCart
		{
			get { return _shoppingcart; }
			set { _shoppingcart = value; }
		}

		public SqlParameter[ ] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
		}
	}
}
