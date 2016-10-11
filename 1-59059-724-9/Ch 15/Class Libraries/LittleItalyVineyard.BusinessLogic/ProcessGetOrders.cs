using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessGetOrders : IBusinessLogic
	{
		private EndUser _enduser;
		private DataSet _resultset;

		public ProcessGetOrders()
		{

		}

		public bool Invoke()
		{
			bool complete = false;

			try
			{
				OrdersSelectData ordersselect = new OrdersSelectData();
				ordersselect.EndUser = this.EndUser;
				ResultSet = ordersselect.Get();

				complete = true;
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
