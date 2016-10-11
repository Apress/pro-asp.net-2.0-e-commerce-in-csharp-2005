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

public partial class Login : BasePage
{
	protected void Page_Load( object sender , EventArgs e )
	{
		textUsername.Focus();
	}

	protected void commandLogin_Click( object sender , EventArgs e )
	{
		if ( IsValid )
		{
			EndUser enduser = new EndUser();
			ProcessEndUserLogin processlogin = new ProcessEndUserLogin();

			enduser.ContactInformation.Email = textUsername.Text;
			enduser.Password				 = textPassword.Text;
			processlogin.EndUser = enduser;

			try
			{
				processlogin.Invoke();
			}
			catch
			{
				Response.Redirect( "ErrorPage.aspx" );
			}

			if ( processlogin.IsAuthenticated )
			{
				Response.Cookies["Authenticated"].Value = "True";

				base.CurrentEndUser = processlogin.EndUser;

				if ( Request.Cookies["ReturnURL"] != null )
				{
					Response.Redirect( Request.Cookies["ReturnURL"].Value );
				}
				else
				{
					Response.Redirect( "Account/CustomerOrders.aspx" );
				}
			}
			else
			{
			    labelMessage.Text = "Invalid login!";
			}
		}
	}
}
