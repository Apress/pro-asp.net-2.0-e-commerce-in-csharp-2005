using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class ProductPromotionSelectData : DataAccessBase
	{
		private Product _product;

		public ProductPromotionSelectData()
		{
			base.StoredProcedureName = StoredProcedure.Name.ProductPromotion_Select.ToString();
		}

		public DataSet Get()
		{
			DataSet ds;

			ProductPromotionSelectDataParameters _productpromotion = new ProductPromotionSelectDataParameters( Product );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			ds = dbhelper.Run( base.ConnectionString , _productpromotion.Parameters );

			return ds;
		}

		public Product Product
		{
			get { return _product; }
			set { _product = value; }
		}
	}

	public class ProductPromotionSelectDataParameters
	{
		private Product _product;
		private SqlParameter[] _parameters;

		public ProductPromotionSelectDataParameters( Product product )
		{
			Product = product;
			Build();
		}

		private void Build()
		{
			SqlParameter[ ] parameters =
		    {
		        new SqlParameter( "@ProductID" , Product.ProductID )
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
