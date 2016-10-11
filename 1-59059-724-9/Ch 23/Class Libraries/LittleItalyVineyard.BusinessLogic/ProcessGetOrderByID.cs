using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessGetOrderByID
	{
		private Orders _orders;
		private DataSet _resultset;

		public ProcessGetOrderByID()
		{

		}

		public void Invoke()
		{
			OrderSelectByIDData orderbyid = new OrderSelectByIDData();
			orderbyid.Orders = this.Orders;
			ResultSet = orderbyid.Get();

			if ( ResultSet.Tables[0].Rows.Count > 0 )
			{
				if ( ResultSet.Tables[0].Rows[0]["ShipDate"].ToString() != "" )
				{
					Orders.ShipDate = Convert.ToDateTime( ResultSet.Tables[0].Rows[0]["ShipDate"].ToString() );
				}
				Orders.TrackingNumber = ResultSet.Tables[0].Rows[0]["TrackingNumber"].ToString();
				Orders.OrderStatusID = int.Parse( ResultSet.Tables[0].Rows[0]["OrderStatusID"].ToString() );
			}
		}

		public Orders Orders
		{
			get { return _orders; }
			set { _orders = value; }
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}
	}
}
