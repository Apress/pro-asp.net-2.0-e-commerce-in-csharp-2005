using System;
using System.Collections.Generic;
using System.Text;

namespace LittleItalyVineyard.Common
{
	public class Orders
	{
		private int _orderid;
		private int _enduserid;
		private DateTime _orderdate;
		private DateTime _shipdate;
		private int _orderstatusid;
		private decimal _shippingtotal;
		private string _trackingnumber;
		private decimal _tax;
		private EndUser _enduser;
		private Address _shippingaddress;
		private CreditCard _creditcard;
		private OrderDetails _orderdetails;
		private string _transactionid;
		private decimal _ordertotal;
		private decimal _subtotal;

		public Orders()
		{
			_creditcard = new CreditCard();
			_orderdetails = new OrderDetails();
			_enduser = new EndUser();
			_shippingaddress = new Address();
		}

		public int OrderID
		{
			get { return _orderid; }
			set { _orderid = value; }
		}
		
		public int EndUserID
		{
			get { return _enduserid; }
			set { _enduserid = value; }
		}

		public EndUser EndUser
		{
			get { return _enduser; }
			set { _enduser = value; }
		}

		public Address ShippingAddress
		{
			get { return _shippingaddress; }
			set { _shippingaddress = value; }
		}

		public DateTime OrderDate
		{
			get { return _orderdate; }
			set { _orderdate = value; }
		}

		public int OrderStatusID
		{
			get { return _orderstatusid; }
			set { _orderstatusid = value; }
		}

		public DateTime ShipDate
		{
			get { return _shipdate; }
			set { _shipdate = value; }
		}

		public decimal Tax
		{
			get { return _tax; }
			set { _tax = value; }
		}

		public decimal ShippingTotal
		{
			get { return _shippingtotal; }
			set { _shippingtotal = value; }
		}

		public string TrackingNumber
		{
			get { return _trackingnumber; }
			set { _trackingnumber = value; }
		}

		public CreditCard CreditCard
		{
			get { return _creditcard; }
			set { _creditcard = value; }
		}

		public OrderDetails OrderDetails
		{
			get { return _orderdetails; }
			set { _orderdetails = value; }
		}

		public string TransactionID
		{
			get { return _transactionid; }
			set { _transactionid = value; }
		}

		public decimal OrderTotal
		{
			get { return _ordertotal; }
			set { _ordertotal = value; }
		}

		public decimal SubTotal
		{
			get { return _subtotal; }
			set { _subtotal = value; }
		}
	}
}
