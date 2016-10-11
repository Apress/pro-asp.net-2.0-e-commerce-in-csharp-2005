using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class ProductSelectData : DataAccessBase
	{
		public ProductSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Products_Select.ToString();
		}

		public DataSet Get()
		{
			DataSet ds;

			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			ds = dbhelper.Run( ConnectionString );

			return ds;
		}
	}
}
