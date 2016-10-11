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

public partial class Winery : System.Web.UI.Page
{
	protected void Page_Load( object sender , EventArgs e )
	{
		if ( !IsPostBack )
		{
			LoadProducts();
		}

		this.Form.DefaultButton = commandSearch.UniqueID;
		this.textSearch.Focus();
	}

	private void LoadProducts()
	{
		ProcessGetProducts processproducts = new ProcessGetProducts();

		processproducts.Invoke();

		datalistProducts.DataSource = processproducts.ResultSet;
		datalistProducts.DataBind();
	}

	private void LoadProducts( string searchcriteria )
    {
       ProcessGetProductsSearch processsearch = new ProcessGetProductsSearch();
       processsearch.SearchCriteria = searchcriteria;

	   processsearch.Invoke();
       
       if ( processsearch.ResultSet.Tables[0].Rows.Count > 0 )
       {
            panelResults.Visible = false;
            datalistProducts.DataSource = processsearch.ResultSet;
            datalistProducts.DataBind();
       }
       else
       {
            panelResults.Visible = true;
            datalistProducts.DataBind();
       }
    }

	protected void commandSearch_Click( object sender , EventArgs e )
	{
		LoadProducts( textSearch.Text );
	}
}
