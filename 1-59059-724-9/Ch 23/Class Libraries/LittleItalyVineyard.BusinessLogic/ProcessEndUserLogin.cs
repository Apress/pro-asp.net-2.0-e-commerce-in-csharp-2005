using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessEndUserLogin : IBusinessLogic
	{
		private EndUser _enduser;
		private DataSet _resultset;
		private bool _isauthenticated;

		public ProcessEndUserLogin()
		{

		}

		public void Invoke()
		{
			EndUserLoginSelectData enduserlogin = new EndUserLoginSelectData();
			enduserlogin.EndUser = this.EndUser;
			ResultSet = enduserlogin.Get();

			if ( ResultSet.Tables[0].Rows.Count != 0 )
			{
				IsAuthenticated = true;

				EndUser.EndUserID				= int.Parse( ResultSet.Tables[0].Rows[0]["EndUserID"].ToString() );
				EndUser.EndUserTypeID			= int.Parse( ResultSet.Tables[0].Rows[0]["EndUserTypeID"].ToString() );
				EndUser.FirstName				= ResultSet.Tables[ 0 ].Rows[ 0 ][ "Firstname" ].ToString();
				EndUser.LastName				= ResultSet.Tables[ 0 ].Rows[ 0 ][ "LastName" ].ToString();
				EndUser.AddressID				= int.Parse( ResultSet.Tables[0].Rows[0]["AddressID"].ToString() );
				EndUser.ContactInformationID	= int.Parse( ResultSet.Tables[0].Rows[0]["ContactInformationID"].ToString() );
				EndUser.Password				= ResultSet.Tables[0].Rows[0][ "Password" ].ToString();

				// Obtain the Address information.
				ProcessGetAddress getaddress = new ProcessGetAddress();
				getaddress.Address.AddressID = EndUser.AddressID;

				getaddress.Invoke();
				EndUser.Address = getaddress.Address;
				
				// Obtain the ContactInformation information.
				ProcessGetContactInformation getcontactinfo = new ProcessGetContactInformation();
				getcontactinfo.ContactInformation.ContactInformationID = EndUser.ContactInformationID;

				getcontactinfo.Invoke(); 
				
				EndUser.ContactInformation = getcontactinfo.ContactInformation;
			}
			else
			{
				IsAuthenticated = false;
				EndUser = null;
			}
		}

		public EndUser EndUser
		{
			get { return _enduser; }
			set { _enduser = value; }
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}

		public bool IsAuthenticated
		{
			get { return _isauthenticated; }
			set { _isauthenticated = value; }
		}
	}
}
