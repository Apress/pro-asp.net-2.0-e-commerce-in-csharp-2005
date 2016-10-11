using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class OrderStatusSelectData : DataAccessBase
	{
		public OrderStatusSelectData()
		{
			base.StoredProcedureName = StoredProcedure.Name.OrderStatus_Select.ToString();
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
