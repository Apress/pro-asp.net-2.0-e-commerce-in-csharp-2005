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

public partial class Admin_Login : System.Web.UI.Page
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
			ProcessAdminLogin processlogin = new ProcessAdminLogin();

			enduser.ContactInformation.Email = textUsername.Text;
			enduser.Password = textPassword.Text;
			processlogin.EndUser = enduser;

			try
			{
				processlogin.Invoke();

				if ( processlogin.IsAuthenticated )
				{
					FormsAuthentication.RedirectFromLoginPage( textUsername.Text , false );
				}
				else
				{
					labelMessage.Text = "Invalid login!";
				}
			}
			catch
			{
				Response.Redirect( "../ErrorPage.aspx" );
			}
		}
	}
}
