using System;
using System.Collections.Generic;
using System.Text;

namespace LittleItalyVineyard.DataAccess
{
	public class StoredProcedure
	{
		public enum Name
		{
			ProductByID_Select ,
			Products_Select ,
			ProductImage_Select ,
			Products_SelectSearch ,
			ShoppingCart_Insert ,
            ShoppingCart_Select ,
            ShoppingCart_Update ,
            ShoppingCart_Delete ,
			Order_Insert ,
			OrderDetails_Insert ,
			Product_Insert ,
			Product_Update ,
			AdminLogin_Select ,
			ProductCategory_Select
		}
	}
}
