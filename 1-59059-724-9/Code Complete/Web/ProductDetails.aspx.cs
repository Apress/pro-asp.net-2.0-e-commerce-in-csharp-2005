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
using LittleItalyVineyard.Common;

public partial class ProductDetails : System.Web.UI.Page
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			LoadProduct();
		}
	}

	private void LoadProduct()
	{
		Product prod = new Product();
		prod.ProductID = int.Parse( Request.QueryString[ "ProductID" ] );

		ProcessGetProductByID getProduct = new ProcessGetProductByID();
		getProduct.Product = prod;

		try
		{
			getProduct.Invoke();
		}
		catch
		{
			Response.Redirect( "ErrorPage.aspx" );
		}

		labelProductName.Text		= getProduct.Product.Name;
		labelDescription.Text		= getProduct.Product.Description;
        labelPrice.Text             = string.Format("{0:c}", getProduct.Product.Price);
		imageProductDetail.ImageUrl = "ImageViewer.ashx?ImageID=" + getProduct.Product.ImageID.ToString();
		labelCategory.Text			= getProduct.Product.ProductCategory.ProductCategoryName;
		
	}
}
