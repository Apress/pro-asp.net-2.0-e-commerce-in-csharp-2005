using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessGetPromotions : IBusinessLogic
	{
		private DataSet _resultset;
		private Product _product;

		public ProcessGetPromotions()
		{

		}

		public void Invoke()
		{
			ProductPromotionSelectData promotiondata = new ProductPromotionSelectData();
			promotiondata.Product = this.Product;
			ResultSet = promotiondata.Get();
		}

		public Product Product
		{
			get { return _product; }
			set { _product = value; }
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}
	}
}
