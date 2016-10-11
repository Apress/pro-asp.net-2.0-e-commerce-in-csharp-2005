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
using LittleItalyVineyard.BusinessLogic;

public partial class Admin_NewsletterConfirmation : BasePage
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			SendNewsletters();
		}
	}

	private void SendNewsletters()
	{
		ProcessNewsletter processnewsletter = new ProcessNewsletter();
		NewsletterManager newslettermngr = new NewsletterManager();

		try
		{
			processnewsletter.Invoke();
			newslettermngr.MessageBody = base.NewsletterBody;
			newslettermngr.UserData = processnewsletter.ResultSet;
			newslettermngr.SendNewsletter();
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}
	}
}
