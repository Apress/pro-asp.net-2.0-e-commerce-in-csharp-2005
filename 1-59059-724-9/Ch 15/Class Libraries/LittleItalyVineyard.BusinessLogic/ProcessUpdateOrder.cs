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

		public bool Invoke()
		{
			bool complete = false;

			try
			{
				OrderUpdateData orderupdate = new OrderUpdateData();
				orderupdate.Orders = this.Orders;
				orderupdate.Update();
				
				complete = true;
			}
			catch ( Exception ex )
			{
				throw ex;
			}

			return complete;
		}

		public Orders Orders
		{
			get { return _orders; }
			set { _orders = value; }
		}
	}
}
