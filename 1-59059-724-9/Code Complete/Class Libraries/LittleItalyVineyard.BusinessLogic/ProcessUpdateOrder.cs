using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Update;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessUpdateOrder : IBusinessLogic
	{
		private Orders _orders;

		public ProcessUpdateOrder()
		{

		}

		public void Invoke()
		{
			OrderUpdateData orderupdate = new OrderUpdateData();
			orderupdate.Orders = this.Orders;
			orderupdate.Update();
		}

		public Orders Orders
		{
			get { return _orders; }
			set { _orders = value; }
		}
	}
}
