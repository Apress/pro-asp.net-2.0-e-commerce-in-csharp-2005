using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessGetContactInformation : IBusinessLogic
	{
		private DataSet _resultset;
		private ContactInformation _contactinformation;

		public ProcessGetContactInformation()
		{
			_contactinformation = new ContactInformation();
		}

		public void Invoke()
		{
			bool complete = false;

			ContactInformationSelectData contactdata = new ContactInformationSelectData();
			contactdata.ContactInformation = this.ContactInformation;
			ResultSet = contactdata.Get();

			ContactInformation.ContactInformationID = int.Parse( ResultSet.Tables[0].Rows[0]["ContactInformationID"].ToString() );
			ContactInformation.Phone = ResultSet.Tables[0].Rows[0]["Phone"].ToString();
			ContactInformation.Phone2 = ResultSet.Tables[0].Rows[0]["Phone2"].ToString();
			ContactInformation.Fax = ResultSet.Tables[0].Rows[0]["Fax"].ToString();
			ContactInformation.Email = ResultSet.Tables[0].Rows[0]["Email"].ToString();

			complete = true;

			
		}

		public ContactInformation ContactInformation
		{
			get { return _contactinformation; }
			set { _contactinformation = value; }
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}
	}
}
