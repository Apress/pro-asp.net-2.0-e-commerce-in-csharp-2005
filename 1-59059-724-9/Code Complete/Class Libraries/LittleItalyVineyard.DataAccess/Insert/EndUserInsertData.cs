using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Insert
{
	public class EndUserInsertData : DataAccessBase
	{
		private EndUser _enduser;
		private EndUserInsertDataParameters _enduserinsertdataparameters;

		public EndUserInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.EndUser_Insert.ToString();
		}

		public void Add()
		{
			_enduserinsertdataparameters = new EndUserInsertDataParameters( EndUser );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			object id = dbhelper.RunScalar( base.ConnectionString , _enduserinsertdataparameters.Parameters );
			this.EndUser.EndUserID = int.Parse( id.ToString() );
		}

		public EndUser EndUser
		{
			get { return _enduser; }
			set { _enduser = value; }
		}
	}

	public class EndUserInsertDataParameters
	{
		private EndUser _enduser;
		private SqlParameter[ ] _parameters;

		public EndUserInsertDataParameters( EndUser enduser )
		{
			EndUser = enduser;
			Build();
		}

		private void Build()
		{
			SqlParameter[ ] parameters =
		    {
				new SqlParameter( "@FirstName"		, EndUser.FirstName ) ,
				new SqlParameter( "@LastName"		, EndUser.LastName ) ,
				new SqlParameter( "@AddressLine"	, EndUser.Address.AddressLine ) ,
				new SqlParameter( "@AddressLine2"	, EndUser.Address.AddressLine2 ) ,
				new SqlParameter( "@City"			, EndUser.Address.City ) ,
				new SqlParameter( "@State"			, EndUser.Address.State ) ,
				new SqlParameter( "@PostalCode"		, EndUser.Address.PostalCode ) ,
				new SqlParameter( "@Phone"			, EndUser.ContactInformation.Phone ) ,
				new SqlParameter( "@Phone2"			, EndUser.ContactInformation.Phone2 ) ,
				new SqlParameter( "@Fax"			, EndUser.ContactInformation.Fax ) ,
				new SqlParameter( "@Email"			, EndUser.ContactInformation.Email ) ,
				new SqlParameter( "@EndUserTypeID"	, EndUser.EndUserTypeID ) ,
				new SqlParameter( "@Password"		, EndUser.Password ) ,
				new SqlParameter( "@IsSubscribed"	, EndUser.IsSubscribed )
		    };

			Parameters = parameters;
		}

		public EndUser EndUser
		{
			get { return _enduser; }
			set { _enduser = value; }
		}

		public SqlParameter[ ] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
		}
	}
}
