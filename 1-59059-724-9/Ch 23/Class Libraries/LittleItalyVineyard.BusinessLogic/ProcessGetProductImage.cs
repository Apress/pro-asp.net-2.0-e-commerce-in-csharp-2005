using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.DataAccess.Select;

namespace LittleItalyVineyard.BusinessLogic
{
	public class ProcessGetProductImage : IBusinessLogic
	{
		private Product _product;
		private Stream _imagestream;

		public ProcessGetProductImage()
		{

		}

		public void Invoke()
		{
			try
			{
				ProductImageSelectByIDData selectproductimage = new ProductImageSelectByIDData();
				selectproductimage.Product = this.Product;
				Product.ImageData = ( byte[] ) selectproductimage.Get();
				ImageStream = new MemoryStream( ( byte[] ) Product.ImageData );
			}
			catch ( Exception ex )
			{
				throw ex;
			}
		}

		public Stream ImageStream
		{
			get { return _imagestream; }
			set { _imagestream = value; }
		}

		public Product Product
		{
			get { return _product; }
			set { _product = value; }
		}
	}
}
