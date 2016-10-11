//****************************************************************************
//	IMPORTANT!	This web form needs to be processed through a Secure Socket
//				Layer certificate (SSL) on the webserver as a result of the
//				credit card data being entered.
//
//****************************************************************************

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

public partial class CheckOut : BasePage
{
	private decimal _totalcounter;

	protected void Page_Load( object sender , EventArgs e )
	{
		// ====== This can be commented when working in the development environment ====
        //if (!Request.IsSecureConnection)
        //{
        //    Response.Redirect(base.UrlBaseSSL);
        //}
		// ==============================================================================

		if ( ! IsPostBack )
		{
			LoadShoppingCart();
			LoadInformation();
		}
	}

	private void LoadInformation()
	{
		textFirstname.Text	= base.CurrentEndUser.FirstName;
		textLastname.Text	= base.CurrentEndUser.LastName;

		// Populate shipping address information.
		textAddress.Text	= base.CurrentEndUser.Address.AddressLine;
		textAddress2.Text	= base.CurrentEndUser.Address.AddressLine2;
		textCity.Text		= base.CurrentEndUser.Address.City;
		textState.Text		= base.CurrentEndUser.Address.State;
		textPostalCode.Text = base.CurrentEndUser.Address.PostalCode;
	}

	protected void gridviewShoppingCart_RowDataBound( object sender , GridViewRowEventArgs e )
	{
		if ( e.Row.RowType == DataControlRowType.DataRow )
		{
			_totalcounter += Convert.ToDecimal( DataBinder.Eval( e.Row.DataItem , "TotalPrice" ) );
		}

		labelSubTotal.Text = string.Format( "{0:c}" , _totalcounter );
		labelTax.Text = string.Format( "{0:c}" , ( CalculationManager.CalcSalesTax( _totalcounter ) ) );
	}

	private void LoadShoppingCart()
	{
		LittleItalyVineyard.Common.ShoppingCart shoppingcart = new LittleItalyVineyard.Common.ShoppingCart();
		shoppingcart.CartGUID = Utilities.GetCartGUID();

		ProcessGetShoppingCart processgetcart = new ProcessGetShoppingCart();
		processgetcart.ShoppingCart = shoppingcart;

		try
		{
			processgetcart.Invoke();
			gridviewShoppingCart.DataSource = processgetcart.ResultSet;
			gridviewShoppingCart.DataBind();
		}
		catch
		{
			Response.Redirect( "ErrorPage.aspx" );
		}
	}

	protected void commandSubmit_Click( object sender , EventArgs e )
	{
		if ( IsValid )
		{
			base.CurrentEndUser.FirstName				= textFirstname.Text;
			base.CurrentEndUser.LastName				= textLastname.Text;
			base.CurrentEndUser.Address.AddressLine		= textAddress.Text;
			base.CurrentEndUser.Address.AddressLine2	= textAddress2.Text;
			base.CurrentEndUser.Address.City			= textCity.Text;
			base.CurrentEndUser.Address.State			= textState.Text;
			base.CurrentEndUser.Address.PostalCode		= textPostalCode.Text;

			base.CurrentOrder = new Orders();

			base.CurrentOrder.EndUser.FirstName = textFirstname.Text;
			base.CurrentOrder.EndUser.LastName = textLastname.Text;

			base.CurrentOrder.ShippingAddress.AddressLine = textAddress.Text;
			base.CurrentOrder.ShippingAddress.AddressLine2 = textAddress2.Text;
			base.CurrentOrder.ShippingAddress.City = textCity.Text;
			base.CurrentOrder.ShippingAddress.State = textState.Text;
			base.CurrentOrder.ShippingAddress.PostalCode = textPostalCode.Text;

			//====== Test Credit Card Information =====================
			//base.CurrentOrder.CreditCard.CardType = "Visa";				
			//base.CurrentOrder.CreditCard.Number = "4719294777609143";	
			//base.CurrentOrder.CreditCard.SecurityCode = "585";			
			//base.CurrentOrder.CreditCard.ExpMonth = 12;					
			//base.CurrentOrder.CreditCard.ExpYear = 2007;				
			// ========================================================

			base.CurrentOrder.CreditCard.CardType = "Visa";				// dropdownlistCreditCardType.SelectedItem.Value;
			base.CurrentOrder.CreditCard.Number = "4719294777609143";	// textCreditCardNumber.Text;
			base.CurrentOrder.CreditCard.SecurityCode = "585";			//textSecurityCode.Text;
			base.CurrentOrder.CreditCard.ExpMonth = 12;					// int.Parse( dropdownlistExpMonth.SelectedItem.Text );
			base.CurrentOrder.CreditCard.ExpYear = 2007;				// int.Parse( dropdownlistExpYear.SelectedItem.Text );

			base.CurrentOrder.CreditCard.Address.AddressLine = textBillingAddress.Text;
			base.CurrentOrder.CreditCard.Address.AddressLine2 = textBillingAddress2.Text;
			base.CurrentOrder.CreditCard.Address.City = textBillingCity.Text;
			base.CurrentOrder.CreditCard.Address.State = textBillingState.Text;
			base.CurrentOrder.CreditCard.Address.PostalCode = textBillingPostalCode.Text;

			labelTax.Text = labelTax.Text.Replace( "$" , "" );
			base.CurrentOrder.Tax = Convert.ToDecimal( labelTax.Text );

			labelSubTotal.Text = labelSubTotal.Text.Replace( "$" , "" );
			base.CurrentOrder.SubTotal = Convert.ToDecimal( labelSubTotal.Text );

			base.CurrentOrder.ShippingTotal = Convert.ToDecimal( dropdownlistShippingOption.SelectedItem.Value );

			Response.Redirect( "CheckOutConfirm.aspx" );
		}
	}

	protected void checkboxVerify_CheckedChanged( object sender , EventArgs e )
	{
		commandSubmit.Enabled = checkboxVerify.Checked;
	}
}
