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

public partial class CheckOutReceipt : BasePage
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			SubmitOrder();
		}
	}

	private void SubmitOrder()
	{
		PayPalManager paypal = new PayPalManager();
		PayPalInformation _paypalinformation = new PayPalInformation();

		_paypalinformation.Order = CurrentOrder;
		paypal.ProcessDirectPayment( _paypalinformation );

		// If payment successful - add Order to database and display.
		if ( paypal.IsSubmissionSuccess )
		{
			panelSuccess.Visible = true;
			labelOrderTotal.Text = string.Format( "{0:c}" , _paypalinformation.Order.OrderTotal );
			labelTransactionID.Text = CurrentOrder.TransactionID;
			
			ProcessAddOrder addorder = new ProcessAddOrder();
			addorder.Orders = CurrentOrder;

			try
			{
				addorder.Invoke();
			}
			catch
			{
				Response.Redirect( "ErrorPage.aspx" );
			}
		}
		else
		{
			panelFailure.Visible = true;
			labelErrorMessage.Text = paypal.SubmissionError;
		}
	}
}
