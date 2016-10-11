using System;
using System.Collections.Generic;
using System.Text;

namespace LittleItalyVineyard.Common
{
	public class ProductCategory
	{
		private int _productcategoryid;
		private string _productcategoryname;

		public ProductCategory()
		{

		}

		public int ProductCategoryID
		{
			get { return _productcategoryid; }
			set { _productcategoryid = value; }
		}
		
		public string ProductCategoryName
		{
			get { return _productcategoryname; }
			set { _productcategoryname = value; }
		}
	}
}
