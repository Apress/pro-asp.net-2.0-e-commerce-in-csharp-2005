using System;
using System.Collections.Generic;
using System.Text;

namespace LittleItalyVineyard.Common
{
	public class CreditCard
	{
		private string _number;
		private string _cardtype;
		private Address _address;
		private string _securitycode;
		private int _expmonth;
		private int _expyear;

		public CreditCard()
		{
			_address = new Address();
		}

		public string Number
		{
			get { return _number; }
			set { _number = value; }
		}

		public string CardType
		{
			get { return _cardtype; }
			set { _cardtype = value; }
		}

		public Address Address
		{
			get { return _address; }
			set { _address = value; }
		}

		public string SecurityCode
		{
			get { return _securitycode; }
			set { _securitycode = value; }
		}

		public int ExpMonth
		{
			get { return _expmonth; }
			set { _expmonth = value; }
		}

		public int ExpYear
		{
			get { return _expyear; }
			set { _expyear = value; }
		}
	}
}
