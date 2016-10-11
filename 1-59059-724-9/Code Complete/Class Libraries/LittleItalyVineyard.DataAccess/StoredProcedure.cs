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
			EndUser_Insert ,
			EndUserLogin_Select ,
			Address_Select ,
			ContactInformation_Select ,
			Product_Insert ,
			AdminLogin_Select ,
			ProductCategory_Select ,
			Product_Update ,
			Order_Insert ,
			OrderDetails_Insert ,
			Orders_Select ,
			OrderDetails_Select ,
			OrdersByID_Select ,
			OrdersAll_Select ,
			Orders_Update ,
			OrderStatus_Select ,
			ProductPromotion_Select ,
			Newsletter_Select ,
			NewsletterUnsubscribe_Update
		}
	}
}
