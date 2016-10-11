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

		public ProcessAdminLogin()
		{

		}

		public bool Invoke()
		{
			bool complete = false;

			try
			{
				AdminLoginSelectData adminlogin = new AdminLoginSelectData();
				adminlogin.EndUser = this.EndUser;
				ResultSet = adminlogin.Get();

				if ( ResultSet.Tables[ 0 ].Rows.Count != 0 )
				{
					complete = true;
				}
				else
				{
					complete = false;
				}
			}
			catch ( Exception ex )
			{
				throw ex;
			}

			return complete;
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
	}
}
