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

using LittleItalyVineyard.BusinessLogic;

public partial class Account_CustomerOrders : BasePage
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			Label labelWelcome = ( Label ) Master.FindControl( "labelWelcome" );
			labelWelcome.Text = "Welcome, " + base.CurrentEndUser.FirstName + " " + base.CurrentEndUser.LastName;
			LoadOrders();
		}
	}

	private void LoadOrders()
	{
		ProcessGetOrders getorders = new ProcessGetOrders();
		getorders.EndUser = CurrentEndUser;

		try
		{
			getorders.Invoke();
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}
		
		gridviewOrders.DataSource = getorders.ResultSet;
		gridviewOrders.DataBind();
	}
}
