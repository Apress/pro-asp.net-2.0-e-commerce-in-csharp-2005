using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessGetOrderStatus : IBusinessLogic
	{
		private DataSet _resultset;

		public ProcessGetOrderStatus()
		{

		}

		public bool Invoke()
		{
			bool complete = false;

			try
			{
				OrderStatusSelectData orderstatusdata = new OrderStatusSelectData();
				ResultSet = orderstatusdata.Get();
				
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
