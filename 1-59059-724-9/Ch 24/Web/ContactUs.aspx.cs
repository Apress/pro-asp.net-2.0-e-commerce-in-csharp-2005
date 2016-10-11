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

using LittleItalyVineyard.Operational;

public partial class ContactUs : System.Web.UI.Page
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			textName.Focus();
		}
	}

	private void SendMessage()
	{
		if ( IsValid )
		{
			EmailContents contents = new EmailContents();
			contents.FromName = textName.Text;
			contents.FromEmailAddress = textEmail.Text;
			contents.Body =  textComment.Text;
			contents.Subject = "Website Feedback";

			EmailManager emailmngr = new EmailManager();
			emailmngr.Send( contents );

			if ( emailmngr.IsSent )
			{
				Response.Redirect( "ContactUsConfirm.aspx" );
			}
		}
	}

	protected void commandSubmit_Click( object sender , EventArgs e )
	{
		SendMessage();
	}

	protected void commandReset_Click( object sender , EventArgs e )
	{
		textName.Text = "";
		textEmail.Text = "";
		textComment.Text = "";
		textName.Focus();
	}
}
