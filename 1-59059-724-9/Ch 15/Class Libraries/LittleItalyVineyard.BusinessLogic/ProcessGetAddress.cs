using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessGetAddress : IBusinessLogic
	{
		private DataSet _resultset;
		private Address _address;

		public ProcessGetAddress()
		{
			_address = new Address();
		}

		public bool Invoke()
		{
			bool complete = false;

			AddressSelectData addressdata = new AddressSelectData();
			addressdata.Address = this.Address;
			ResultSet = addressdata.Get();

			Address.AddressID		= int.Parse( ResultSet.Tables[0].Rows[0]["AddressID"].ToString() );
			Address.AddressLine		= ResultSet.Tables[0].Rows[0]["AddressLine"].ToString();
			Address.AddressLine2	= ResultSet.Tables[0].Rows[0]["AddressLine2"].ToString();
			Address.City			= ResultSet.Tables[0].Rows[0]["City"].ToString();
			Address.State			= ResultSet.Tables[0].Rows[0]["State"].ToString();
			Address.PostalCode		= ResultSet.Tables[0].Rows[0]["PostalCode"].ToString();

			complete = true;

			return complete;
		}

		public Address Address
		{
			get { return _address; }
			set { _address = value; }
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}
	}
}
