using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;

namespace LittleItalyVineyard.DataAccess
{
	public class DataBaseHelper : DataAccessBase
	{
		private SqlParameter[ ] _parameters;

		public DataBaseHelper( string storedprocedurename )
		{
			StoredProcedureName = storedprocedurename;
		}

		public void Run( SqlTransaction transaction )
		{
			SqlHelper.ExecuteNonQuery( transaction , CommandType.StoredProcedure , StoredProcedureName , Parameters );
		}

		public void Run( SqlTransaction transaction , SqlParameter[] parameters )
		{
			SqlHelper.ExecuteNonQuery( transaction , CommandType.StoredProcedure , StoredProcedureName , parameters );
		}

		public DataSet Run( string connectionstring , SqlParameter[ ] parameters )
		{
			DataSet ds;
			ds = SqlHelper.ExecuteDataset( connectionstring , StoredProcedureName , parameters );
			return ds;
		}

		public object RunScalar( string connectionstring , SqlParameter[ ] parameters )
		{
			object obj;
			obj = SqlHelper.ExecuteScalar( connectionstring , StoredProcedureName , parameters );
			return obj;
		}

		public object RunScalar( SqlTransaction transaction , SqlParameter[] parameters )
		{
			object obj;
			obj = SqlHelper.ExecuteScalar( transaction , StoredProcedureName , parameters );
			return obj;
		}

		public DataSet Run( string connectionstring )
		{
			DataSet ds;
			ds = SqlHelper.ExecuteDataset( connectionstring , CommandType.StoredProcedure , StoredProcedureName );
			return ds;
		}

		public void Run()
		{
			SqlHelper.ExecuteNonQuery( base.ConnectionString , CommandType.StoredProcedure , StoredProcedureName , Parameters );
		}

		public SqlDataReader Run( SqlParameter[ ] parameters )
		{
			SqlDataReader dr;
			dr = SqlHelper.ExecuteReader( base.ConnectionString , CommandType.StoredProcedure , StoredProcedureName , parameters );
			return dr;
		}

		public SqlParameter[ ] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
		}
	}
}
