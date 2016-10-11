using System;
using System.Collections.Generic;
using System.Text;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Update;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessNewsletterUnsubscribe : IBusinessLogic
	{
		private EndUser _enduser;

		public ProcessNewsletterUnsubscribe()
		{

		}

		public void Invoke()
		{
			NewsletterUpdateData newsletterupdatedata = new NewsletterUpdateData();
			newsletterupdatedata.EndUser = this.EndUser;
			newsletterupdatedata.Update();
		}

		public EndUser EndUser
		{
			get { return _enduser; }
			set { _enduser = value; }
		}
	}
}
