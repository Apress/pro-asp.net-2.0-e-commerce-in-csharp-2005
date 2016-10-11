using System;
using System.Collections.Generic;
using System.Text;

namespace LittleItalyVineyard.Common
{
	public class Address
	{
		private int _addressid;
		private string _addressline;
		private string _addressline2;
		private string _city;
		private string _state;
		private string _postalcode;

		public Address()
		{

		}

		public int AddressID
		{
			get { return _addressid; }
			set { _addressid = value; }
		}

		public string AddressLine
		{
			get { return _addressline; }
			set { _addressline = value; }
		}

		public string AddressLine2
		{
			get { return _addressline2; }
			set { _addressline2 = value; }
		}

		public string City
		{
			get { return _city; }
			set { _city = value; }
		}

		public string State
		{
			get { return _state; }
			set { _state = value; }
		}

		public string PostalCode
		{
			get { return _postalcode; }
			set { _postalcode = value; }
		}
	}
}
