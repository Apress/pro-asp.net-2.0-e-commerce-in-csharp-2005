using System;
using System.Collections.Generic;
using System.Text;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Insert;

namespace LittleItalyVineyard.DataAccess.Transaction
{
	public class OrderInsertTransaction : TransactionBase
	{
		public OrderInsertTransaction()
		{

		}

		public bool Begin( Orders orders )
		{
			bool transactioncomplete = false;

			command = connection.CreateCommand();
			transaction = connection.BeginTransaction( "OrderInsert" );
			command.Connection = connection;
			command.Transaction = transaction;

			OrderInsertData orderadd = new OrderInsertData();
			OrderDetailsInsertData orderdetailsadd = new OrderDetailsInsertData();

			try
			{
				// Insert Order.
				orderadd.Orders = orders;
				orderadd.Add( transaction );

				// Insert Order Details.
				for ( int i = 0 ; i < orders.OrderDetails.Products.Length ; i++ )
				{
					orderdetailsadd.OrderDetails.OrderID = orders.OrderID;
					orderdetailsadd.OrderDetails.ProductID = orders.OrderDetails.Products[i].ProductID;
					orderdetailsadd.OrderDetails.Quantity = orders.OrderDetails.Products[i].Quantity;

					orderdetailsadd.Add( transaction );
				}

				transactioncomplete = true;
				transaction.Commit();
			}
			catch ( Exception ex )
			{
				transaction.Rollback( "OrderInsert" );
			    throw ex;
			}

			return transactioncomplete;
		}
	}
}
