using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class OrdersSelectData : DataAccessBase
	{
		private EndUser _enduser;

		public OrdersSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Orders_Select.ToString();
		}

		public DataSet Get()
		{
			DataSet ds;

			OrdersSelectDataParameters _ordersselectdataparameters = new OrdersSelectDataParameters( EndUser );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			ds = dbhelper.Run( base.ConnectionString , _ordersselectdataparameters.Parameters );

			return ds;
		}

		public EndUser EndUser
		{
			get { return _enduser; }
			set { _enduser = value; }
		}
	}

	public class OrdersSelectDataParameters
	{
		private EndUser _enduser;
		private SqlParameter[] _parameters;

		public OrdersSelectDataParameters( EndUser enduser )
		{
			EndUser = enduser;
			Build();
		}

		private void Build()
		{
			SqlParameter[] parameters =
		    {
		        new SqlParameter( "@EndUserID"		, EndUser.EndUserID )
		    };

			Parameters = parameters;
		}

		public EndUser EndUser
		{
			get { return _enduser; }
			set { _enduser = value; }
		}

		public SqlParameter[] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
		}
	}
}
