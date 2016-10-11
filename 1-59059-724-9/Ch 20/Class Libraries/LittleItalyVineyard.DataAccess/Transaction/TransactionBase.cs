using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LittleItalyVineyard.DataAccess.Transaction
{
	public class TransactionBase
	{
		protected SqlTransaction transaction = null;
		protected SqlConnection connection = null;
		protected SqlCommand command = null;

		public TransactionBase()
		{
			connection = new SqlConnection( ConfigurationManager.ConnectionStrings[ "SQLCONN" ].ToString() );
			connection.Open();
			command = connection.CreateCommand();
		}
	}
}
