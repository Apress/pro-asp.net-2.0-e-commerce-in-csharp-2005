using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessGetProductsSearch : IBusinessLogic
	{
		private DataSet _resultset;
		private string _searchcriteria;

		public ProcessGetProductsSearch()
		{

		}

		public bool Invoke()
		{
			bool complete = false;

			ProductSelectSearchData productdatasearch = new ProductSelectSearchData();
			productdatasearch.SearchCriteria = this.SearchCriteria;
			ResultSet = productdatasearch.Get();
			complete = true;

			return complete;
		}

		public string SearchCriteria
		{
			get { return _searchcriteria; }
			set { _searchcriteria = value; }
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}
	}
}
