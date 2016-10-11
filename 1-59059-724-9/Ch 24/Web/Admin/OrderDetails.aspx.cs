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
using System.Data.SqlTypes;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.BusinessLogic;
using LittleItalyVineyard.Operational;

public partial class Admin_OrderDetails : System.Web.UI.Page
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			LoadOrderStatus();
			LoadOrderDetails();
		}
	}

	private void LoadOrderDetails()
	{
		ProcessGetOrderDetails processdetails = new ProcessGetOrderDetails();
		ProcessGetOrderByID processorder = new ProcessGetOrderByID();

		OrderDetails orderdetails = new OrderDetails();
		orderdetails.OrderID = int.Parse( Request.QueryString[ "OrderID" ] );
		processdetails.OrderDetails = orderdetails;

		Orders orders = new Orders();
		orders.OrderID = int.Parse( Request.QueryString[ "OrderID" ] );
		processorder.Orders = orders;

		try
		{
			processdetails.Invoke();
			processorder.Invoke();
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}
		
		gridviewOrderDetailsProducts.DataSource = processdetails.ResultSet;
		gridviewOrderDetailsProducts.DataBind();

		labelTransactionID.Text = Request.QueryString[ "TransID" ];

		if ( orders.ShipDate != DateTime.MinValue )
		{
			textShippedDate.Text = orders.ShipDate.ToShortDateString();
		}
		textTrackingNumber.Text = orders.TrackingNumber;

		dropdownlistOrderStatus.SelectedIndex = dropdownlistOrderStatus.Items.IndexOf( dropdownlistOrderStatus.Items.FindByValue( orders.OrderStatusID.ToString() ) );
	}

	private void LoadOrderStatus()
	{
		ProcessGetOrderStatus processorderstatus = new ProcessGetOrderStatus();

		try
		{
			processorderstatus.Invoke();
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}

		dropdownlistOrderStatus.DataTextField = "OrderStatusName";
		dropdownlistOrderStatus.DataValueField = "OrderStatusID";
		dropdownlistOrderStatus.DataSource = processorderstatus.ResultSet;
		dropdownlistOrderStatus.DataBind();
	}

	protected void commandUpdate_Click( object sender , EventArgs e )
	{
		Orders orders = new Orders();
		ProcessUpdateOrder updateorder = new ProcessUpdateOrder();

		orders.OrderID = int.Parse( Request.QueryString["OrderID"] );
		orders.OrderStatusID = int.Parse( dropdownlistOrderStatus.SelectedItem.Value );
		orders.ShipDate = Convert.ToDateTime( textShippedDate.Text );
		orders.TrackingNumber = textTrackingNumber.Text;

		updateorder.Orders = orders;

		try
		{
			updateorder.Invoke();

			EmailManager emailmngr = new EmailManager();
			EmailContents mailcontents = new EmailContents();

            mailcontents.To = Request.QueryString[ "Email" ];
			mailcontents.Subject = "Little Italy Vineyard Update - Order ID: " + Request.QueryString["OrderID"];
			mailcontents.Body = "Your order has been updated.  Please log into your account for details.";

			emailmngr.Send( mailcontents );

            if ( !emailmngr.IsSent )
            {
                Response.Redirect("../ErrorPage.aspx");
            }
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}

		Response.Redirect( "Orders.aspx" );
	}

	protected void commandRefund_Click( object sender , EventArgs e )
	{
		PayPalManager paypal = new PayPalManager();
		paypal.RefundTransaction( Request.QueryString[ "TransID" ] );

        Orders orders = new Orders();
		ProcessUpdateOrder updateorder = new ProcessUpdateOrder();

        int refundedstatustype = 3;

		orders.OrderID = int.Parse( Request.QueryString["OrderID"] );
        orders.OrderStatusID = refundedstatustype;
        orders.ShipDate = ( DateTime ) SqlDateTime.Null;
		updateorder.Orders = orders;

        try
        {
            updateorder.Invoke();

            if (paypal.IsSubmissionSuccess)
            {
                EmailManager emailmngr = new EmailManager();
                EmailContents mailcontents = new EmailContents();

                mailcontents.To = Request.QueryString["Email"];
                mailcontents.Subject = "Little Italy Vineyard Update - Order ID: " + Request.QueryString["OrderID"];
                mailcontents.Body = "Your order has been refunded.  Please log into your account for details.";

                emailmngr.Send(mailcontents);

                if (!emailmngr.IsSent)
                {
                    Response.Redirect("../ErrorPage.aspx");
                }
            }
        }
        catch
        {
            Response.Redirect("../ErrorPage.aspx");
        }

        Response.Redirect("Orders.aspx");
	}

	protected void commandReturn_Click( object sender , EventArgs e )
	{
		Response.Redirect( "Orders.aspx" );
	}

	protected void imagebuttonDatePicker_Click( object sender , ImageClickEventArgs e )
	{
		if ( calendarDatePicker.Visible )
		{
			calendarDatePicker.Visible = false;
		}
		else
		{
			calendarDatePicker.Visible = true;
		}
	}

	protected void calendarDatePicker_SelectionChanged( object sender , EventArgs e )
	{
		textShippedDate.Text = calendarDatePicker.SelectedDate.ToShortDateString();
		calendarDatePicker.Visible = false;
	}
}
