using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Update
{
	public class ProductUpdateData : DataAccessBase
	{
		private Product _product;
		private ProductUpdateDataParameters _productupdatedataparameters;

		public ProductUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Product_Update.ToString();
		}

		public void Update()
		{
			_productupdatedataparameters = new ProductUpdateDataParameters( Product );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			dbhelper.Parameters = _productupdatedataparameters.Parameters;
			dbhelper.Run();
		}

		public Product Product
		{
			get { return _product; }
			set { _product = value; }
		}
	}

	public class ProductUpdateDataParameters
	{
		private Product _product;
		private SqlParameter[] _parameters;

		public ProductUpdateDataParameters( Product product )
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
				new SqlParameter( "@ProductImageID"		, Product.ImageID ) ,
				new SqlParameter( "@ProductImage"		, Product.ImageData ) ,
				new SqlParameter( "@Description"		, Product.Description ) ,
				new SqlParameter( "@Price"				, Product.Price ) ,
				new SqlParameter( "@ProductID"			, Product.ProductID )
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
