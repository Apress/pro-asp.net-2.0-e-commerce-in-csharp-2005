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

		public bool Invoke()
		{
			bool complete = false;

			try
			{
				ProductCategorySelectData productcategorydata = new ProductCategorySelectData();
				ResultSet = productcategorydata.Get();

				complete = true;
			}
			catch ( Exception ex )
			{
				throw ex;
			}

			return complete;
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}
	}
}
