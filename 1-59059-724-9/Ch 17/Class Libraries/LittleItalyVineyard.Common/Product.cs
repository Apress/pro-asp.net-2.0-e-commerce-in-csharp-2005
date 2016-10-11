using System;
using System.Collections.Generic;
using System.Text;

namespace LittleItalyVineyard.Common
{
	public class Product
	{
		private int _productid;
		private int _productcategoryid;
		private ProductCategory _productcategory;
		private string _name;
		private string _description;
		private int _quantity;
		private int _imageid;
		private byte[] _imagedata;
		private decimal _price;

		public Product()
		{
			_productcategory = new ProductCategory();
		}

		public int ProductID
		{
			get { return _productid; }
			set { _productid = value; }
		}

		public int ProductCategoryID
		{
			get { return _productcategoryid; }
			set { _productcategoryid = value; }
		}

		public ProductCategory ProductCategory
		{
			get { return _productcategory; }
			set { _productcategory = value; }
		}
		
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		public int Quantity
		{
			get { return _quantity; }
			set { _quantity = value; }
		}

		public int ImageID
		{
			get { return _imageid; }
			set { _imageid = value; }
		}
		
		public byte[] ImageData
		{
			get { return _imagedata; }
			set { _imagedata = value; }
		}
		
		public decimal Price
		{
			get { return _price; }
			set { _price = value; }
		}
	}
}
