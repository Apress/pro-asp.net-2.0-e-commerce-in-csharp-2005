using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Update
{
	public class OrderUpdateData : DataAccessBase
	{
		private Orders _orders;
		private OrderUpdateDataParameters _orderupdatedataparameters;

		public OrderUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Orders_Update.ToString();
		}

		public void Update()
		{
			_orderupdatedataparameters = new OrderUpdateDataParameters( Orders );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			dbhelper.Parameters = _orderupdatedataparameters.Parameters;
			dbhelper.Run();
		}

		public Orders Orders
		{
			get { return _orders; }
			set { _orders = value; }
		}
	}

	public class OrderUpdateDataParameters
	{
		private Orders _orders;
		private SqlParameter[] _parameters;

		public OrderUpdateDataParameters( Orders orders )
		{
			Orders = orders;
			Build();
		}

		private void Build()
		{
			SqlParameter[] parameters =
		    {
		        new SqlParameter( "@OrderID"		, Orders.OrderID ) ,
				new SqlParameter( "@OrderStatusID"	, Orders.OrderStatusID ) ,
				new SqlParameter( "@ShipDate"		, Orders.ShipDate ) ,
				new SqlParameter( "@TrackingNumber"	, Orders.TrackingNumber ) 
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
