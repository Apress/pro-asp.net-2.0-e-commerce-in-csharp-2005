using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessGetProductCategory : IBusinessLogic
	{
		private DataSet _resultset;

		public ProcessGetProductCategory()
		{

		}

		public void Invoke()
		{
			ProductCategorySelectData productcategorydata = new ProductCategorySelectData();
			ResultSet = productcategorydata.Get();
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}
	}
}
