using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;

namespace LittleItalyVineyard.DataAccess.Select
{
	public class ProductSelectSearchData : DataAccessBase
	{
		private string _searchcriteria;

		public ProductSelectSearchData()
		{
			base.StoredProcedureName = StoredProcedure.Name.Products_SelectSearch.ToString();
		}

		public DataSet Get()
		{
			DataSet ds;

			ProductSelectSearchDataParameters _productselectsearchdataparameters = new ProductSelectSearchDataParameters( SearchCriteria );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			ds = dbhelper.Run( base.ConnectionString , _productselectsearchdataparameters.Parameters );

			return ds;
		}

		public string SearchCriteria
		{
			get { return _searchcriteria; }
			set { _searchcriteria = value; }
		}
	}

	public class ProductSelectSearchDataParameters
	{
		private string _searchcriteria;
		private SqlParameter[ ] _parameters;

		public ProductSelectSearchDataParameters( string searchcriteria )
		{
			SearchCriteria = searchcriteria;
			Build();
		}

		private void Build()
		{
			SqlParameter[ ] parameters =
		    {
		        new SqlParameter( "@SearchCriteria" , SearchCriteria )
		    };

			Parameters = parameters;
		}

		public string SearchCriteria
		{
			get { return _searchcriteria; }
			set { _searchcriteria = value; }
		}

		public SqlParameter[ ] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
		}
	}
}
