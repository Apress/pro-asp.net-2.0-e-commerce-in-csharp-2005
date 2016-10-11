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

public partial class Admin_Newsletter : BasePage
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			textMessageBody.Focus();
		}
	}

	protected void commandSend_Click( object sender , EventArgs e )
	{
		string URL = "NewsletterConfirmation.aspx";
		base.NewsletterBody = Utilities.FormatText( textMessageBody.Text , true );
		Response.Redirect( "SendingNewsletter.aspx?Page=" + URL );
	}
}
