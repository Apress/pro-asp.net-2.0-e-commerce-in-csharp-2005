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

		public void Invoke()
		{
			OrdersAllSelectData ordersall = new OrdersAllSelectData();
			ResultSet = ordersall.Get();
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}
	}
}
