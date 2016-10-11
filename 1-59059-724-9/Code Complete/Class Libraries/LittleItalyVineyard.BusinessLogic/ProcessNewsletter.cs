using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessNewsletter : IBusinessLogic
	{
		private DataSet _resultset;

		public ProcessNewsletter()
		{

		}

		public void Invoke()
		{
			NewsletterSelectData newsletterdata = new NewsletterSelectData();
			ResultSet = newsletterdata.Get();
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}
	}
}
