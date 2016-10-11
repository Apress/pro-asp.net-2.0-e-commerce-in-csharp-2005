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

public partial class AddToCart : System.Web.UI.Page
{
	protected void Page_Load( object sender , EventArgs e )
	{
		LittleItalyVineyard.Common.ShoppingCart shoppingcart = new LittleItalyVineyard.Common.ShoppingCart();
		shoppingcart.ProductID = int.Parse( Request.QueryString["ProductID"] );
		shoppingcart.CartGUID = CartGUID;
		shoppingcart.Quantity = 1;

		ProcessAddShoppingCart procshoppingcart = new ProcessAddShoppingCart();
		procshoppingcart.ShoppingCart = shoppingcart;

		try
		{
			procshoppingcart.Invoke();
		}
		catch
		{
			Response.Redirect( "ErrorPage.aspx" );
		}

		Response.Redirect( "ShoppingCart.aspx?ProductID=" + Request.QueryString["ProductID"] );
	}

	private string CartGUID
	{
		get { return Utilities.GetCartGUID(); }
	}
}
