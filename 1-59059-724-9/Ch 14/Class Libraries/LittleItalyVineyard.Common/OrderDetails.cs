using System;
using System.Collections.Generic;
using System.Text;

namespace LittleItalyVineyard.Common
{
	public class OrderDetails
	{
		private int _orderdetailid;
		private int _orderid;
		private int _productid;
		private int _quantity;
		private Product[ ] _products;

		public OrderDetails()
		{
			
		}

		public int OrderDetailID
		{
			get { return _orderdetailid; }
			set { _orderdetailid = value; }
		}
		
		public int OrderID
		{
			get { return _orderid; }
			set { _orderid = value; }
		}
		
		public int ProductID
		{
			get { return _productid; }
			set { _productid = value; }
		}

		public Product[ ] Products
		{
			get { return _products; }
			set { _products = value; }
		}
		
		public int Quantity
		{
			get { return _quantity; }
			set { _quantity = value; }
		}
	}
}
