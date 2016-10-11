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

public partial class ShoppingCart : System.Web.UI.Page
{
	private decimal _totalcounter;

	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			LoadShoppingCart();
		}
	}

	private void LoadShoppingCart()
	{
		LittleItalyVineyard.Common.ShoppingCart shoppingcart = new LittleItalyVineyard.Common.ShoppingCart();
		shoppingcart.CartGUID = CartGUID;

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

	protected void gridviewShoppingCart_RowDataBound( object sender , GridViewRowEventArgs e )
	{
		if ( e.Row.RowType == DataControlRowType.DataRow )
		{
			_totalcounter += Convert.ToDecimal( DataBinder.Eval( e.Row.DataItem , "TotalPrice" ) );
		}
		
		labelTotal.Text = string.Format( "{0:c}" , _totalcounter );
	}

	protected void commandUpdate_Click( object sender , EventArgs e )
	{
		foreach ( GridViewRow row in gridviewShoppingCart.Rows )
		{
			if ( row.RowType == DataControlRowType.DataRow )
			{
				DataKey data = gridviewShoppingCart.DataKeys[ row.DataItemIndex ];

				CheckBox check = ( CheckBox ) row.FindControl( "checkboxDelete" );

				if ( check.Checked )
				{
					Delete( int.Parse( data.Values[ "ShoppingCartID" ].ToString() ) );
				}

				TextBox textNewQuantity = ( TextBox ) row.FindControl( "textQuantity" );
				int integerNewQuantity = int.Parse( textNewQuantity.Text );
				int integerOrigQuantity = int.Parse( gridviewShoppingCart.DataKeys[ row.DataItemIndex ].Value.ToString() );

				if ( integerNewQuantity != integerOrigQuantity )
				{
					Update( int.Parse( data.Values[ "ShoppingCartID" ].ToString() ) , integerNewQuantity );
				}
			}
		}

		LoadShoppingCart();
	}

	private void Update( int id , int newqty )
	{
		ProcessUpdateShoppingCart processupdate = new ProcessUpdateShoppingCart();

		LittleItalyVineyard.Common.ShoppingCart shoppingcart = new LittleItalyVineyard.Common.ShoppingCart();
		shoppingcart.Quantity = newqty;
		shoppingcart.ShoppingCartID = id;
		processupdate.ShoppingCart = shoppingcart;

		try
		{
			processupdate.Invoke();
		}
		catch
		{
			Response.Redirect( "ErrorPage.aspx" );
		}
	}

	private void Delete( int id )
	{
		ProcessDeleteShoppingCart processdelete = new ProcessDeleteShoppingCart();

		LittleItalyVineyard.Common.ShoppingCart shoppingcart = new LittleItalyVineyard.Common.ShoppingCart();
		shoppingcart.ShoppingCartID = id;
		processdelete.ShoppingCart = shoppingcart;

		try
		{
			processdelete.Invoke();
		}
		catch
		{
			Response.Redirect( "ErrorPage.aspx" );
		}
	}

	protected void commandCheckout_Click( object sender , EventArgs e )
	{
		Response.Cookies[ "ReturnURL" ].Value = "CheckOut.aspx";
		Response.Redirect( "Login.aspx" );
	}

	private string CartGUID
	{
		get { return Utilities.GetCartGUID(); }
	}

	protected void commandContinueShopping_Click( object sender , EventArgs e )
	{
		Response.Redirect( "Winery.aspx" );
	}
}
