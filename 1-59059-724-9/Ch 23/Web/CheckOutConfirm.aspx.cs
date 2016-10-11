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

public partial class CheckOutConfirm : BasePage
{
	protected void Page_Load( object sender , EventArgs e )
	{
		// ====== This can be commented when working in the development environment ====
		//if ( ! Request.IsSecureConnection )
		//{
		//    Response.Redirect( base.UrlBaseSSL );
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
		labelFirstname.Text = base.CurrentEndUser.FirstName;
		labelLastname.Text = base.CurrentEndUser.LastName;
		labelAddress.Text = base.CurrentEndUser.Address.AddressLine;
		labelAddress2.Text = base.CurrentEndUser.Address.AddressLine2;
		labelCity.Text = base.CurrentEndUser.Address.City;
		labelState.Text = base.CurrentEndUser.Address.State;
		labelPostalCode.Text = base.CurrentEndUser.Address.PostalCode;

		labelCreditCardType.Text = base.CurrentOrder.CreditCard.CardType;
		labelCreditCardNumber.Text = base.CurrentOrder.CreditCard.Number;
		labelCreditCardSecurityCode.Text = base.CurrentOrder.CreditCard.SecurityCode;
		labelExpirationDate.Text = base.CurrentOrder.CreditCard.ExpMonth.ToString() + " / " + base.CurrentOrder.CreditCard.ExpYear.ToString();

		labelBillingAddress.Text = base.CurrentOrder.CreditCard.Address.AddressLine;
		labelBillingAddress2.Text = base.CurrentOrder.CreditCard.Address.AddressLine2;
		labelBillingCity.Text = base.CurrentOrder.CreditCard.Address.City;
		labelBillingState.Text = base.CurrentOrder.CreditCard.Address.State;
		labelBillingPostalCode.Text = base.CurrentOrder.CreditCard.Address.PostalCode;

		labelSubTotal.Text		= string.Format( "{0:c}" , base.CurrentOrder.SubTotal );
		labelTax.Text			= string.Format( "{0:c}" , base.CurrentOrder.Tax );
		labelShippingCost.Text	= string.Format( "{0:c}" , base.CurrentOrder.ShippingTotal );

		labelTotal.Text			= string.Format( "{0:c}" , Convert.ToDecimal( base.CurrentOrder.SubTotal ) + base.CurrentOrder.Tax + base.CurrentOrder.ShippingTotal );
	}

	private void LoadShoppingCart()
	{
		LittleItalyVineyard.Common.ShoppingCart shoppingcart = new LittleItalyVineyard.Common.ShoppingCart();
		shoppingcart.CartGUID = Utilities.GetCartGUID();

		ProcessGetShoppingCart processgetcart = new ProcessGetShoppingCart();
		processgetcart.ShoppingCart = shoppingcart;

		processgetcart.Invoke();
		gridviewShoppingCart.DataSource = processgetcart.ResultSet;
		gridviewShoppingCart.DataBind();
	}

	protected void commandConfirm_Click( object sender , EventArgs e )
	{
		Product[] prods = new Product[ gridviewShoppingCart.Rows.Count ];

		foreach ( GridViewRow grow in gridviewShoppingCart.Rows )
		{
			if ( grow.RowType == DataControlRowType.DataRow )
			{
				Product prod = new Product();

				DataKey data = gridviewShoppingCart.DataKeys[ grow.DataItemIndex ];

				prod.ProductID = int.Parse( data.Values["ProductID"].ToString() );
				
				Label labelProductName = ( Label ) grow.FindControl( "labelProductName" );
				prod.Name = labelProductName.Text;

				Label labelQuantity = ( Label ) grow.FindControl( "labelQuantity" );
				prod.Quantity = int.Parse( labelQuantity.Text );
				
				Label labelUnitPrice = ( Label ) grow.FindControl( "labelUnitPrice" );
				labelUnitPrice.Text = labelUnitPrice.Text.Replace( "$" , "" );
				prod.Price = Convert.ToDecimal( labelUnitPrice.Text );

				prods.SetValue( prod , grow.DataItemIndex );
			}
		}

		CurrentOrder.OrderDetails.Products = prods;

		// Order Total.
		labelTotal.Text = labelTotal.Text.Replace( "$" , "" );
		CurrentOrder.OrderTotal = Convert.ToDecimal( labelTotal.Text );
		CurrentOrder.EndUserID = CurrentEndUser.EndUserID;

		string URL = "CheckOutReceipt.aspx";
		Response.Redirect( "Loading.aspx?Page=" + URL );
	}

	protected void commandEdit_Click( object sender , EventArgs e )
	{
		// Navigate back to the previous page.
		Response.Redirect( "CheckOut.aspx" );
	}
}
