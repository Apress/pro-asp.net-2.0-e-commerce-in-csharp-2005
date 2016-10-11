using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class AdminLoginSelectData : DataAccessBase
	{
		private EndUser _enduser;

		public AdminLoginSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.AdminLogin_Select.ToString();
		}

		public DataSet Get()
		{
			DataSet ds;

			AdminLoginSelectDataParameters _adminselectdataparameters = new AdminLoginSelectDataParameters( EndUser );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			ds = dbhelper.Run( base.ConnectionString , _adminselectdataparameters.Parameters );

			return ds;
		}

		public EndUser EndUser
		{
			get { return _enduser; }
			set { _enduser = value; }
		}
	}

	public class AdminLoginSelectDataParameters
	{
		private EndUser _enduser;
		private SqlParameter[] _parameters;

		public AdminLoginSelectDataParameters( EndUser enduser )
		{
			EndUser = enduser;
			Build();
		}

		private void Build()
		{
			SqlParameter[] parameters =
		    {
		        new SqlParameter( "@Email"		, EndUser.ContactInformation.Email ) ,
				new SqlParameter( "@Password"	, EndUser.Password )
		    };

			Parameters = parameters;
		}

		public EndUser EndUser
		{
			get { return _enduser; }
			set { _enduser = value; }
		}

		public SqlParameter[] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
		}
	}
}
