using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class OrdersAllSelectData : DataAccessBase
	{
		public OrdersAllSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.OrdersAll_Select.ToString();
		}

		public DataSet Get()
		{
			DataSet ds;

			DataBaseHelper dbhelper = new DataBaseHelper( base.StoredProcedureName );
			ds = dbhelper.Run( base.ConnectionString );

			return ds;
		}
	}
}
