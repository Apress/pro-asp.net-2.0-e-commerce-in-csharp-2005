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

public partial class Admin_Products : System.Web.UI.Page
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			LoadProducts();
		}
	}

	private void LoadProducts()
	{
		ProcessGetProducts processproducts = new ProcessGetProducts();

		try
		{
			processproducts.Invoke();
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}

	    datalistProducts.DataSource = processproducts.ResultSet;
		datalistProducts.DataBind();
	}

	protected void commandAddProduct_Click( object sender , EventArgs e )
	{
		Response.Redirect( "AddProduct.aspx" );
	}
}
