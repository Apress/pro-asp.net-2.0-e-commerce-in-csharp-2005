using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class ContactInformationSelectData : DataAccessBase
	{
		private ContactInformation _contactinformation;

		public ContactInformationSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.ContactInformation_Select.ToString();
		}

		public DataSet Get()
		{
			DataSet ds;

			ContactInformationSelectDataParameters _contactinformationselectdataparameters = new ContactInformationSelectDataParameters( ContactInformation );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			ds = dbhelper.Run( base.ConnectionString , _contactinformationselectdataparameters.Parameters );

			return ds;
		}

		public ContactInformation ContactInformation
		{
			get { return _contactinformation; }
			set { _contactinformation = value; }
		}
	}

	public class ContactInformationSelectDataParameters
	{
		private ContactInformation _contactinformation;
		private SqlParameter[] _parameters;

		public ContactInformationSelectDataParameters( ContactInformation contactinformation )
		{
			ContactInformation = contactinformation;
			Build();
		}

		private void Build()
		{
			SqlParameter[] parameters =
		    {
		        new SqlParameter( "@ContactInformationID" , ContactInformation.ContactInformationID ) 
		    };

			Parameters = parameters;
		}

		public ContactInformation ContactInformation
		{
			get { return _contactinformation; }
			set { _contactinformation = value; }
		}

		public SqlParameter[] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
		}
	}
}
