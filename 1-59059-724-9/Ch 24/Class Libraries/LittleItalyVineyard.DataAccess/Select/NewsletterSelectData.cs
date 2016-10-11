using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class NewsletterSelectData: DataAccessBase
	{
		public NewsletterSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Newsletter_Select.ToString();
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
