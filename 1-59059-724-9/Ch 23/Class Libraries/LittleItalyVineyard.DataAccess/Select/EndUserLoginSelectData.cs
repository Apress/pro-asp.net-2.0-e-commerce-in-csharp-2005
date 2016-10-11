using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class EndUserLoginSelectData : DataAccessBase
	{
		private EndUser _enduser;

		public EndUserLoginSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.EndUserLogin_Select.ToString();
		}

		public DataSet Get()
		{
			DataSet ds;

			EndUserLoginSelectDataParameters _enduserselectdataparameters = new EndUserLoginSelectDataParameters( EndUser );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			ds = dbhelper.Run( base.ConnectionString , _enduserselectdataparameters.Parameters );

			return ds;
		}

		public EndUser EndUser
		{
			get { return _enduser; }
			set { _enduser = value; }
		}
	}

	public class EndUserLoginSelectDataParameters
	{
		private EndUser _enduser;
		private SqlParameter[] _parameters;

		public EndUserLoginSelectDataParameters( EndUser enduser )
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
