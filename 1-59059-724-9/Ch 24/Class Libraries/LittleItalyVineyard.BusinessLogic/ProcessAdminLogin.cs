using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessAdminLogin : IBusinessLogic
	{
		private EndUser _enduser;
		private DataSet _resultset;
		private bool _isauthenticated;

		public ProcessAdminLogin()
		{

		}

		public void Invoke()
		{
			AdminLoginSelectData adminlogin = new AdminLoginSelectData();
			adminlogin.EndUser = this.EndUser;
			ResultSet = adminlogin.Get();

			if ( ResultSet.Tables[ 0 ].Rows.Count != 0 )
			{
				IsAuthenticated = true;
			}
			else
			{
				IsAuthenticated = false;
			}
		}

		public EndUser EndUser
		{
			get { return _enduser; }
			set { _enduser = value; }
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}

		public bool IsAuthenticated
		{
			get { return _isauthenticated; }
			set { _isauthenticated = value; }
		}
	}
}
