using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class OrderDetailsSelectData : DataAccessBase
	{
		private OrderDetails _orderdetails;

		public OrderDetailsSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.OrderDetails_Select.ToString();
		}

		public DataSet Get()
		{
			DataSet ds;

			OrderDetailsSelectDataParameters _orderdetailsselectdataparameters = new OrderDetailsSelectDataParameters( OrderDetails );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			ds = dbhelper.Run( base.ConnectionString , _orderdetailsselectdataparameters.Parameters );

			return ds;
		}

		public OrderDetails OrderDetails
		{
			get { return _orderdetails; }
			set { _orderdetails = value; }
		}
	}

	public class OrderDetailsSelectDataParameters
	{
		private OrderDetails _orderdetails;
		private SqlParameter[] _parameters;

		public OrderDetailsSelectDataParameters( OrderDetails orderdetails )
		{
			OrderDetails = orderdetails;
			Build();
		}

		private void Build()
		{
			SqlParameter[] parameters =
		    {
		        new SqlParameter( "@OrderID" , OrderDetails.OrderID ) ,
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
