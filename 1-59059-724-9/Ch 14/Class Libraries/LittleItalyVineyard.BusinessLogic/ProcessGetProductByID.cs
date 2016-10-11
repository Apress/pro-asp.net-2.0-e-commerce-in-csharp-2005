using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessGetProductByID : IBusinessLogic
	{
		private Product _product;
		private DataSet _resultset;

		public ProcessGetProductByID()
		{

		}

		public void Invoke()
		{
			try
			{
				ProductSelectByIDData selectproduct = new ProductSelectByIDData();
				selectproduct.Product = Product;
				ResultSet = selectproduct.Get();

				Product.Name = ResultSet.Tables[0].Rows[0]["ProductName"].ToString();
				Product.Description = ResultSet.Tables[0].Rows[0]["Description"].ToString();
				Product.Price = Convert.ToDecimal( ResultSet.Tables[0].Rows[0]["Price"].ToString() );
				Product.ImageID = int.Parse( ResultSet.Tables[0].Rows[0]["ProductImageID"].ToString() );
				Product.ProductCategory.ProductCategoryName = ResultSet.Tables[0].Rows[0]["ProductCategoryName"].ToString();
			}
			catch ( Exception ex )
			{
				throw ex;
			}
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
