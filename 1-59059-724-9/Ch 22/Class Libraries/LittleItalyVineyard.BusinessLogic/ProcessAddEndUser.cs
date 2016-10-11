using System;
using System.Collections.Generic;
using System.Text;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Insert;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessAddEndUser : IBusinessLogic
	{
		private EndUser _enduser;

		public ProcessAddEndUser()
		{

		}

		public void Invoke()
		{
			EndUserInsertData enduserdata = new EndUserInsertData();
			enduserdata.EndUser = this.EndUser;
			enduserdata.Add();
			this.EndUser.EndUserID = enduserdata.EndUser.EndUserID;
		}

		public EndUser EndUser
		{
			get { return _enduser; }
			set { _enduser = value; }
		}
	}
}
