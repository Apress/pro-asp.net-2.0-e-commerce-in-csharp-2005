using System;
using System.Collections.Generic;
using System.Text;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Update;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessUpdateProduct : IBusinessLogic
	{
		private Product _product;

		public ProcessUpdateProduct()
		{

		}

		public bool Invoke()
		{
			bool complete = false;

			try
			{
				ProductUpdateData productdata = new ProductUpdateData();
				productdata.Product = this.Product;
				productdata.Update();

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
