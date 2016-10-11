using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessGetProducts : IBusinessLogic
	{
		private DataSet _resultset;

		public ProcessGetProducts()
		{

		}

		public void Invoke()
		{
			ProductSelectData productdata = new ProductSelectData();
			ResultSet = productdata.Get();
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}
	}
}
