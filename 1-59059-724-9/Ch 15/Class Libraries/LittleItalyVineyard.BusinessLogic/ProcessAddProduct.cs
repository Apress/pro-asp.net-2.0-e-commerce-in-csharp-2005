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

		public bool Invoke()
		{
			bool complete = false;

			try
			{
				ProductInsertData productdata = new ProductInsertData();
				productdata.Product = this.Product;
				productdata.Add();
				
				complete = true;
			}
			catch ( Exception ex )
			{
				throw ex;
			}

			return complete;
		}

		public Product Product
		{
			get { return _product; }
			set { _product = value; }
		}

	}
}
