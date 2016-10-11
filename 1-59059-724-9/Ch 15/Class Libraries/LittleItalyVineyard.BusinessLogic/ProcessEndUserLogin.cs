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

		public ProcessEndUserLogin()
		{

		}

		public bool Invoke()
		{
			bool complete = false;

			try
			{
				EndUserLoginSelectData enduserlogin = new EndUserLoginSelectData();
				enduserlogin.EndUser = this.EndUser;
				ResultSet = enduserlogin.Get();

				if ( ResultSet.Tables[0].Rows.Count != 0 )
				{
					EndUser.EndUserID				= int.Parse( ResultSet.Tables[0].Rows[0]["EndUserID"].ToString() );
					EndUser.EndUserTypeID			= int.Parse( ResultSet.Tables[0].Rows[0]["EndUserTypeID"].ToString() );
					EndUser.FirstName				= ResultSet.Tables[ 0 ].Rows[ 0 ][ "Firstname" ].ToString();
					EndUser.LastName				= ResultSet.Tables[ 0 ].Rows[ 0 ][ "LastName" ].ToString();
					EndUser.AddressID				= int.Parse( ResultSet.Tables[0].Rows[0]["AddressID"].ToString() );
					EndUser.ContactInformtationID	= int.Parse( ResultSet.Tables[0].Rows[0]["ContactInformationID"].ToString() );
					EndUser.Password				= ResultSet.Tables[0].Rows[0][ "Password" ].ToString();

					// Obtain the Address information.
					ProcessGetAddress getaddress = new ProcessGetAddress();
					getaddress.Address.AddressID = EndUser.AddressID;

					if ( getaddress.Invoke() )
					{
						EndUser.Address = getaddress.Address;
					}

					// Obtain the ContactInformation information.
					ProcessGetContactInformation getcontactinfo = new ProcessGetContactInformation();
					getcontactinfo.ContactInformation.ContactInformationID = EndUser.ContactInformtationID;

					if ( getcontactinfo.Invoke() )
					{
						EndUser.ContactInformation = getcontactinfo.ContactInformation;
					}

					complete = true;
				}
				else
				{
					complete = false;
				}
			}
			catch ( Exception ex )
			{
				throw ex;
			}

			return complete;
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
	}
}
