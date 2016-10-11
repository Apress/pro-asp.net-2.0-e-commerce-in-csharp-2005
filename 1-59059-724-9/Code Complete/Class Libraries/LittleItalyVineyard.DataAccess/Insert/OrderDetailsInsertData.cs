using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Insert
{
	public class OrderDetailsInsertData : DataAccessBase
	{
		private OrderDetails _orderdetails;
		private OrderDetailsInsertDataParameters _orderdetailsinsertdataparameters;

		public OrderDetailsInsertData()
		{
			OrderDetails = new OrderDetails();
			StoredProcedureName = StoredProcedure.Name.OrderDetails_Insert.ToString();
		}

		public void Add( SqlTransaction transaction )
		{
			_orderdetailsinsertdataparameters = new OrderDetailsInsertDataParameters( OrderDetails );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			dbhelper.Run( transaction , _orderdetailsinsertdataparameters.Parameters );
		}

		public OrderDetails OrderDetails
		{
			get { return _orderdetails; }
			set { _orderdetails = value; }
		}
	}

	public class OrderDetailsInsertDataParameters
	{
		private OrderDetails _orderdetails;
		private SqlParameter[] _parameters;

		public OrderDetailsInsertDataParameters( OrderDetails orderdetails )
		{
			OrderDetails = orderdetails;
			Build();
		}

		private void Build()
		{
			SqlParameter[] parameters =
		    {
				new SqlParameter( "@OrderID"	, OrderDetails.OrderID ) ,
				new SqlParameter( "@ProductID"	, OrderDetails.ProductID ) ,
				new SqlParameter( "@Quantity"	, OrderDetails.Quantity )
		    };

			Parameters = parameters;
		}

		public OrderDetails OrderDetails
		{
			get { return _orderdetails; }
			set { _orderdetails = value; }
		}

		public SqlParameter[] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
		}
	}
}
