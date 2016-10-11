using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Insert
{
	public class ProductInsertData : DataAccessBase
	{
		private Product _product;
		private ProductInsertDataParameters _productinsertdataparameters;

		public ProductInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Product_Insert.ToString();
		}

		public void Add()
		{
			_productinsertdataparameters = new ProductInsertDataParameters( Product );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			dbhelper.Parameters = _productinsertdataparameters.Parameters;
			dbhelper.Run();
		}

		public Product Product
		{
			get { return _product; }
			set { _product = value; }
		}
	}

	public class ProductInsertDataParameters
	{
		private Product _product;
		private SqlParameter[] _parameters;

		public ProductInsertDataParameters( Product product )
		{
			Product = product;
			Build();
		}

		private void Build()
		{
			SqlParameter[] parameters =
		    {
				new SqlParameter( "@ProductCategoryID"	, Product.ProductCategoryID ) ,
				new SqlParameter( "@ProductName"		, Product.Name ) ,
				new SqlParameter( "@ProductImage"		, Product.ImageData ) ,
				new SqlParameter( "@Description"		, Product.Description ) ,
				new SqlParameter( "@Price"				, Product.Price )
		    };

			Parameters = parameters;
		}

		public Product Product
		{
			get { return _product; }
			set { _product = value; }
		}

		public SqlParameter[] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
		}
	}
}
