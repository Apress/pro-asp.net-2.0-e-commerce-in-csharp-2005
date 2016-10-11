using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Insert
{
	public class OrderInsertData : DataAccessBase
	{
		private Orders _orders;
		private OrderInsertDataParameters _orderinsertdataparameters;

		public OrderInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Order_Insert.ToString();
		}

		public void Add( SqlTransaction transaction )
		{
			_orderinsertdataparameters = new OrderInsertDataParameters( Orders );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			object id = dbhelper.RunScalar( transaction , _orderinsertdataparameters.Parameters );
			Orders.OrderID = int.Parse( id.ToString() );
		}

		public Orders Orders
		{
			get { return _orders; }
			set { _orders = value; }
		}
	}

	public class OrderInsertDataParameters
	{
		private Orders _orders;
		private SqlParameter[] _parameters;

		public OrderInsertDataParameters( Orders orders )
		{
			Orders = orders;
			Build();
		}

		private void Build()
		{
			SqlParameter[] parameters =
		    {
				new SqlParameter( "@EndUserID"		, Orders.EndUserID ) ,
				new SqlParameter( "@TransactionID"	, Orders.TransactionID ) 
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
