using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessGetAllOrders : IBusinessLogic
	{
		private DataSet _resultset;

		public ProcessGetAllOrders()
		{

		}

		public bool Invoke()
		{
			bool complete = false;

			try
			{
				OrdersAllSelectData ordersall = new OrdersAllSelectData();
				ResultSet = ordersall.Get();
				
				complete = true;
			}
			catch ( Exception ex )
			{
				throw ex;
			}

			return complete;
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}
	}
}
