using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Microsoft.ApplicationBlocks.Data;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class ProductSelectData : DataAccessBase
	{
		public ProductSelectData()
		{
			base.StoredProcedureName = StoredProcedure.Name.Products_Select.ToString();
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
