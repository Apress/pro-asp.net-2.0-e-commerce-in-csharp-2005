using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessGetOrderDetails : IBusinessLogic
	{
		private OrderDetails _orderdetails;
		private DataSet _resultset;

		public ProcessGetOrderDetails()
		{

		}

		public bool Invoke()
		{
			bool complete = false;

			try
			{
				OrderDetailsSelectData orderdetailsselect = new OrderDetailsSelectData();
				orderdetailsselect.OrderDetails = this.OrderDetails;
				ResultSet = orderdetailsselect.Get();

				complete = true;
			}
			catch ( Exception ex )
			{
				throw ex;
			}

			return complete;
		}

		public OrderDetails OrderDetails
		{
			get { return _orderdetails; }
			set { _orderdetails = value; }
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}
	}
}
