using System;
using System.Collections.Generic;
using System.Text;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Transaction;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessAddOrder : IBusinessLogic
	{
		private Orders _orders;

		public ProcessAddOrder()
		{

		}

		public bool Invoke()
		{
			bool complete = false;

			try
			{
				OrderInsertTransaction ordertransaction = new OrderInsertTransaction();
				ordertransaction.Begin( this.Orders );
				
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
