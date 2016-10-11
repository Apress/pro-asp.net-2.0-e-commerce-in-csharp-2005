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
			try
			{
				SqlHelper.ExecuteNonQuery( transaction , CommandType.StoredProcedure , StoredProcedureName , Parameters );
			}
			catch ( Exception ex )
			{
				throw ex;
			}
		}

		public void Run( SqlTransaction transaction , SqlParameter[] parameters )
		{
			try
			{
				SqlHelper.ExecuteNonQuery( transaction , CommandType.StoredProcedure , StoredProcedureName , parameters );
			}
			catch ( Exception ex )
			{
				throw ex;
			}
		}

		public DataSet Run( string connectionstring , SqlParameter[ ] parameters )
		{
			DataSet ds;

			try
			{
				ds = SqlHelper.ExecuteDataset( connectionstring , StoredProcedureName , parameters );
			}
			catch ( Exception ex )
			{
				throw ex;
			}

			return ds;
		}

		public object RunScalar( string connectionstring , SqlParameter[ ] parameters )
		{
			object obj;

			try
			{
				obj = SqlHelper.ExecuteScalar( connectionstring , StoredProcedureName , parameters );
			}
			catch ( Exception ex )
			{
				throw ex;
			}

			return obj;
		}

		public object RunScalar( SqlTransaction transaction , SqlParameter[] parameters )
		{
			object obj;

			try
			{
				obj = SqlHelper.ExecuteScalar( transaction , StoredProcedureName , parameters );
			}
			catch ( Exception ex )
			{
				throw ex;
			}

			return obj;
		}

		public DataSet Run( string connectionstring )
		{
			DataSet ds;

			try
			{
				ds = SqlHelper.ExecuteDataset( connectionstring , CommandType.StoredProcedure , StoredProcedureName );
			}
			catch ( Exception ex )
			{
				throw ex;
			}

			return ds;
		}

		public void Run()
		{
			try
			{
				SqlHelper.ExecuteNonQuery( base.ConnectionString , CommandType.StoredProcedure , StoredProcedureName , Parameters );
			}
			catch ( Exception ex )
			{
				throw ex;
			}
		}

		public SqlDataReader Run( SqlParameter[ ] parameters )
		{
			SqlDataReader dr;

			try
			{
				dr = SqlHelper.ExecuteReader( base.ConnectionString , CommandType.StoredProcedure , StoredProcedureName , parameters );
			}
			catch ( Exception ex )
			{
				throw ex;
			}

			return dr;
		}

		public SqlParameter[ ] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
		}
	}
}
