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

public partial class Admin_EditProduct : System.Web.UI.Page
{
	private const string SAVEDPRODUCTIMAGEID = "SavedProductImageID";

	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			textName.Focus();
			LoadCategories();
			LoadProduct();
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

	private void LoadProduct()
	{
		Product prod = new Product();
		prod.ProductID = int.Parse( Request.QueryString["ProductID"] );

		ProcessGetProductByID getProduct = new ProcessGetProductByID();
		getProduct.Product = prod;

        try
        {
            getProduct.Invoke();

            textName.Text = getProduct.Product.Name;
            textDescription.Text = getProduct.Product.Description;
            textPrice.Text = getProduct.Product.Price.ToString();
            imageProductDetail.ImageUrl = "../ImageViewer.ashx?ImageID=" + getProduct.Product.ImageID.ToString();
            dropdownlistCategory.SelectedIndex = dropdownlistCategory.Items.IndexOf(dropdownlistCategory.Items.FindByText(getProduct.Product.ProductCategory.ProductCategoryName));

            // Save product image id in case user does not want to update image.
            SavedProductImageID = getProduct.Product.ImageID;
        }
        catch
        {
            Response.Redirect( "../ErrorPage.aspx" );
        }
	}

	protected void commandUpdate_Click( object sender , EventArgs e )
	{
		if ( IsValid )
		{
			Product prod = new Product();
			prod.ProductID = int.Parse( Request.QueryString["ProductID"] );
			prod.Name = textName.Text;
			prod.Description = textDescription.Text;
			prod.Price = Convert.ToDecimal( textPrice.Text );
			prod.ProductCategoryID = int.Parse( dropdownlistCategory.SelectedItem.Value );
			prod.ImageID = SavedProductImageID;

			if ( fileuploadProductImage.HasFile )
			{
				prod.ImageData = fileuploadProductImage.FileBytes;
			}
			else
			{
				ProcessGetProductImage processgetimg = new ProcessGetProductImage();
				processgetimg.Product = prod;

				try
				{
					processgetimg.Invoke();
				}
				catch
				{
					Response.Redirect( "../ErrorPage.aspx" );
				}

				prod.ImageData = processgetimg.Product.ImageData;
			}

			ProcessUpdateProduct processupdate = new ProcessUpdateProduct();
			processupdate.Product = prod;

			try
			{
				processupdate.Invoke();
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

	private int SavedProductImageID
	{
		get { return ( int ) ViewState[ SAVEDPRODUCTIMAGEID ]; }
		set { ViewState[ SAVEDPRODUCTIMAGEID ] = value; }
	}
}
