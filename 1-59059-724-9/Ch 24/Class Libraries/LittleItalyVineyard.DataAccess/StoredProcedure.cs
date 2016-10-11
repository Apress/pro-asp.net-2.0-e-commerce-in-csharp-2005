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
            Address_Select ,
            ContactInformation_Select ,
			Order_Insert ,
            EndUserLogin_Select ,
			OrderDetails_Insert ,
			Product_Insert ,
			Product_Update ,
			AdminLogin_Select ,
			ProductCategory_Select ,
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
