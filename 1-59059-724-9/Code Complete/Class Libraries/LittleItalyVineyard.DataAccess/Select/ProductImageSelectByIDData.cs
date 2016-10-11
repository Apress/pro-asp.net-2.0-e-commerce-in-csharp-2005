using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class ProductImageSelectByIDData : DataAccessBase
	{
		private Product _product;

		public ProductImageSelectByIDData()
		{
			StoredProcedureName = StoredProcedure.Name.ProductImage_Select.ToString();
		}

		public object Get()
		{
			object imagedata;

			ProductImageSelectByIDDataParameters _productimgselectbyiddataparameters = new ProductImageSelectByIDDataParameters( Product );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			imagedata = dbhelper.RunScalar( base.ConnectionString , _productimgselectbyiddataparameters.Parameters );

			return imagedata;
		}

		public Product Product
		{
			get { return _product; }
			set { _product = value; }
		}
	}

	public class ProductImageSelectByIDDataParameters
	{
		private Product _product;
		private SqlParameter[ ] _parameters;

		public ProductImageSelectByIDDataParameters( Product product )
		{
			Product = product;
			Build();
		}

		private void Build()
		{

			SqlParameter[] parameters =
			{
			    new SqlParameter( "@ProductImageID" , Product.ImageID )
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
