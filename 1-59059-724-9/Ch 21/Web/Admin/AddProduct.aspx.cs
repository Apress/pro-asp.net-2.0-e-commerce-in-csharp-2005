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

public partial class Admin_AddProduct : System.Web.UI.Page
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			textProductName.Focus();
			LoadCategories();
		}
	}

	private void LoadCategories()
	{
		ProcessGetProductCategory processgetcategory = new ProcessGetProductCategory();

		try
		{
			processgetcategory.Invoke();
		}
		catch
		{
			Response.Redirect( "../ErrorPage.aspx" );
		}
		
		dropdownlistCategory.DataTextField = "ProductCategoryName";
		dropdownlistCategory.DataValueField = "ProductCategoryID";
		dropdownlistCategory.DataSource = processgetcategory.ResultSet;
		dropdownlistCategory.DataBind();
	}

	protected void commandAdd_Click( object sender , EventArgs e )
	{
		if ( IsValid )
		{
			ProcessAddProduct addproduct = new ProcessAddProduct();
			Product prod = new Product();

			prod.ProductCategoryID = int.Parse( dropdownlistCategory.SelectedItem.Value );
			prod.Name = textProductName.Text;
			prod.Description = textDescription.Text;
			prod.ImageData = fileuploadImage.FileBytes;
			prod.Price = Convert.ToDecimal( textPrice.Text );
			addproduct.Product = prod;

			try
			{
				addproduct.Invoke();
			}
			catch
			{
				Response.Redirect( "../ErrorPage.aspx" );
			}
			
			Response.Redirect( "Products.aspx" );
		}
	}

	protected void commandCancel_Click( object sender , EventArgs e )
	{
		Response.Redirect( "Products.aspx" );
	}
}
