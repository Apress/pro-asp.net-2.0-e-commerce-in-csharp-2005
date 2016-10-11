using System;
using System.Collections.Generic;
using System.Text;

namespace LittleItalyVineyard.Common
{
	public class EndUserType
	{
		private int _endusertypeid;
		private string _endusername;

		public EndUserType()
		{

		}
		
		public int EndUserTypeID
		{
			get { return _endusertypeid; }
			set { _endusertypeid = value; }
		}
		
		public string EndUsername
		{
			get { return _endusername; }
			set { _endusername = value; }
		}
	}
}
