using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;
using Microsoft.ApplicationBlocks.Data;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class AddressSelectData : DataAccessBase
	{
		private Address _address;

		public AddressSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Address_Select.ToString();
		}

		public DataSet Get()
		{
			DataSet ds;

			AddressSelectDataParameters _addressselectdataparameters = new AddressSelectDataParameters( Address );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			ds = dbhelper.Run( base.ConnectionString , _addressselectdataparameters.Parameters );

			return ds;
		}

		public Address Address
		{
			get { return _address; }
			set { _address = value; }
		}
	}

	public class AddressSelectDataParameters
	{
		private Address _address;
		private SqlParameter[] _parameters;

		public AddressSelectDataParameters( Address address )
		{
			Address = address;
			Build();
		}

		private void Build()
		{
			SqlParameter[] parameters =
		    {
		        new SqlParameter( "@AddressID" , Address.AddressID )
		    };

			Parameters = parameters;
		}

		public Address Address
		{
			get { return _address; }
			set { _address = value; }
		}

		public SqlParameter[] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
		}
	}
}
