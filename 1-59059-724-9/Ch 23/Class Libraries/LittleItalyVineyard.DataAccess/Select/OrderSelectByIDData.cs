using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class OrderSelectByIDData : DataAccessBase
	{
		private Orders _orders;

		public OrderSelectByIDData()
		{
			StoredProcedureName = StoredProcedure.Name.OrdersByID_Select.ToString();
		}

		public DataSet Get()
		{
			DataSet ds;

			OrderSelectByIDDataParameters _orderselectbyiddataparameters = new OrderSelectByIDDataParameters( Orders );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			ds = dbhelper.Run( base.ConnectionString , _orderselectbyiddataparameters.Parameters );

			return ds;
		}

		public Orders Orders
		{
			get { return _orders; }
			set { _orders = value; }
		}
	}

	public class OrderSelectByIDDataParameters
	{
		private Orders _orders;
		private SqlParameter[] _parameters;

		public OrderSelectByIDDataParameters( Orders orders )
		{
			Orders = orders;
			Build();
		}

		private void Build()
		{
			SqlParameter[] parameters =
		    {
		        new SqlParameter( "@OrderID" , Orders.OrderID )
		    };

			Parameters = parameters;
		}

		public Orders Orders
		{
			get { return _orders; }
			set { _orders = value; }
		}

		public SqlParameter[] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
		}
	}
}
