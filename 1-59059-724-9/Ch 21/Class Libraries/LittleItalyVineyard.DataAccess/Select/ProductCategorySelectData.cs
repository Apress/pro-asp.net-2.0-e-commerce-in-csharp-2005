using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class ProductCategorySelectData : DataAccessBase
	{
		public ProductCategorySelectData()
		{
			base.StoredProcedureName = StoredProcedure.Name.ProductCategory_Select.ToString();
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
