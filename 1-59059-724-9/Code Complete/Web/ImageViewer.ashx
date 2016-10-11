<%@ WebHandler Language="C#" Class="ImageViewer" %>

using System;
using System.Web;
using System.IO;

using LittleItalyVineyard.BusinessLogic;
using LittleItalyVineyard.Common;

public class ImageViewer : IHttpHandler 
{
    public void ProcessRequest ( HttpContext context ) 
    {
        Product product = new Product();
        product.ImageID = int.Parse( context.Request.QueryString[ "ImageID" ] );
 
        ProcessGetProductImage processget = new ProcessGetProductImage();
        processget.Product = product;

        Stream stream = null;

        processget.Invoke();
        
        context.Response.ContentType = "image/jpeg";
        context.Response.Cache.SetCacheability( HttpCacheability.Public );
        context.Response.BufferOutput = false;

        int buffersize = 1024 * 16;
        byte[] buffer = new byte[ buffersize ];

        stream = processget.ImageStream;
        int count = stream.Read(buffer, 0, buffersize);
        
        while ( count > 0 )
        {
            context.Response.OutputStream.Write( buffer , 0 , count );
            count = stream.Read( buffer , 0 , buffersize );
        }
    }
 
    public bool IsReusable 
    {
        get { return false; }
    }
}