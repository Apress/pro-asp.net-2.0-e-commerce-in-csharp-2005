using System;
using System.Collections.Generic;
using System.Text;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Insert;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessAddProduct : IBusinessLogic
	{
		private Product _product;

		public ProcessAddProduct()
		{

		}

		public void Invoke()
		{
			ProductInsertData productdata = new ProductInsertData();
			productdata.Product = this.Product;
			productdata.Add();
		}

		public Product Product
		{
			get { return _product; }
			set { _product = value; }
		}

	}
}
