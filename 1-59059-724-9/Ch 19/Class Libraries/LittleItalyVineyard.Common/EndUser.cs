using System;
using System.Collections.Generic;
using System.Text;

namespace LittleItalyVineyard.Common
{
	public class EndUser
	{
		private int _enduserid;
		private int _endusertypeid;
		private string _firstname;
		private string _lastname;
		private Address _address;
		private int _addressid;
		private ContactInformation _contactinformation;
		private int _contactinformationid;
		private string _password;
		private bool _issubscribed;

		public EndUser()
		{
			_address = new Address();
			_contactinformation = new ContactInformation();
		}

		public int EndUserID
		{
			get { return _enduserid; }
			set { _enduserid = value; }
		}

		public int EndUserTypeID
		{
			get { return _endusertypeid; }
			set { _endusertypeid = value; }
		}
		
		public string FirstName
		{
			get { return _firstname; }
			set { _firstname = value; }
		}
		
		public string LastName
		{
			get { return _lastname; }
			set { _lastname = value; }
		}

		public Address Address
		{
			get { return _address; }
			set { _address = value; }
		}
		
		public int AddressID
		{
			get { return _addressid; }
			set { _addressid = value; }
		}

		public ContactInformation ContactInformation
		{
			get { return _contactinformation; }
			set { _contactinformation = value; }
		}

		public int ContactInformationID
		{
			get { return _contactinformationid; }
			set { _contactinformationid = value; }
		}
		
		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}
		
		public bool IsSubscribed
		{
			get { return _issubscribed; }
			set { _issubscribed = value; }
		}
	}
}
