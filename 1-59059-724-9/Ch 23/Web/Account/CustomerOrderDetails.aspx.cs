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
using LittleItalyVineyard.Operational;

public partial class Account_CustomerOrderDetails : BasePage
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			Label labelWelcome = ( Label ) Master.FindControl( "labelWelcome" );
			labelWelcome.Text = "Welcome, " + base.CurrentEndUser.FirstName + " " + base.CurrentEndUser.LastName;

			LoadOrderDetails();
		}
	}

	private void LoadOrderDetails()
	{
		ProcessGetOrderDetails processdetails = new ProcessGetOrderDetails();
		
		OrderDetails orderdetails = new OrderDetails();
		orderdetails.OrderID = int.Parse( Request.QueryString["OrderID"] );
		processdetails.OrderDetails = orderdetails;

		try
		{
			processdetails.Invoke();
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}
		
		gridviewOrderDetailsProducts.DataSource = processdetails.ResultSet;
		gridviewOrderDetailsProducts.DataBind();

		labelTransactionID.Text = Request.QueryString[ "TransID" ];

		PayPalManager paypal = new PayPalManager();
		Orders ord = new Orders();

		ord.TransactionID = Request.QueryString[ "TransID" ];
		paypal.GetTransactionDetails( ord );

		if ( paypal.IsSubmissionSuccess )
		{
			labelOrderTotal.Text = ord.OrderTotal.ToString( "c" );
			labelTax.Text = ord.Tax.ToString( "c" );
		}
		else
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}
	}

	protected void commandReturn_Click( object sender , EventArgs e )
	{
		Response.Redirect( "CustomerOrders.aspx" );
	}
}
