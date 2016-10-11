using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace LittleItalyVineyard.DataAccess
{
	public class DataAccessBase
	{
		private string _storedprocedureName;

		protected string StoredProcedureName
		{
			get { return _storedprocedureName; }
			set { _storedprocedureName = value; }
		}

		protected string ConnectionString
		{
			get { return ConfigurationManager.ConnectionStrings[ "SQLCONN" ].ToString(); }
		}
	}
}
