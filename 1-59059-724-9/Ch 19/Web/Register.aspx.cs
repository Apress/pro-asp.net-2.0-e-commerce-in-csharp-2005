using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.BusinessLogic;

public partial class Register : BasePage
{
	protected void Page_Load( object sender , EventArgs e )
	{
		textFirstname.Focus();
	}

	protected void commandRegister_Click( object sender , EventArgs e )
	{
		EndUser enduser = new EndUser();
		ProcessAddEndUser processuser = new ProcessAddEndUser();

		if ( IsValid )
		{
			enduser.EndUserTypeID				= ( int ) Enums.EndUserType.CUSTOMER;
			enduser.FirstName					= textFirstname.Text;
			enduser.LastName					= textLastname.Text;
			enduser.Address.AddressLine			= textAddress.Text;
			enduser.Address.AddressLine2		= textAddress2.Text;
			enduser.Address.City				= textCity.Text;
			enduser.Address.State				= textState.Text;
			enduser.Address.PostalCode			= textPostalCode.Text;
			enduser.Password					= textPassword.Text;
			enduser.ContactInformation.Email	= textEmail.Text;
			enduser.ContactInformation.Phone	= textPhone.Text;
			enduser.ContactInformation.Phone2	= textPhone2.Text;
			enduser.ContactInformation.Fax		= textFax.Text;
			enduser.IsSubscribed				= checkboxNewsletter.Checked;

			processuser.EndUser = enduser;

			try
			{
				processuser.Invoke();
			}
			catch
			{
				Response.Redirect( "ErrorPage.aspx" );
			}
			
			CurrentEndUser = processuser.EndUser;

			if ( Request.Cookies[ "ReturnURL" ].Value != null )
			{
				Response.Redirect( Request.Cookies[ "ReturnURL" ].Value );
			}
			else
			{
				Response.Redirect( "Login.aspx" );
			}
		}
	}
}
