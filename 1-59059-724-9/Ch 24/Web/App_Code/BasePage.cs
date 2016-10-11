using System;
using System.Web;

using LittleItalyVineyard.Common;

public class BasePage : System.Web.UI.Page
{
	internal const string KEY_CURRENTUSER		= "Current Logged In User";
	internal const string KEY_CURRENTORDER		= "Current Order";
	internal const string KEY_NEWSLETTERBODY	= "Newsletter Message Body";

	public EndUser CurrentEndUser
	{
		get
		{
			try
			{
				return ( EndUser ) ( Session[ KEY_CURRENTUSER ] );
			}
			catch
			{
				return ( null );  // for design time
			}
		}

		set
		{
			if ( value == null )
			{
				Session.Remove( KEY_CURRENTUSER );
			}
			else
			{
				Session[ KEY_CURRENTUSER ] = value;
			}
		}
	}

	public Orders CurrentOrder
	{
		get
		{
			try
			{
				return ( Orders ) ( Session[ KEY_CURRENTORDER ] );
			}
			catch
			{
				return ( null );  // for design time
			}
		}

		set
		{
			if ( value == null )
			{
				Session.Remove( KEY_CURRENTORDER );
			}
			else
			{
				Session[ KEY_CURRENTORDER ] = value;
			}
		}
	}

	public string NewsletterBody
	{
		get
		{
			try
			{
				return ( string ) ( Session[KEY_NEWSLETTERBODY] );
			}
			catch
			{
				return ( null );  // for design time
			}
		}

		set
		{
			if ( value == null )
			{
				Session.Remove( KEY_NEWSLETTERBODY );
			}
			else
			{
				Session[KEY_NEWSLETTERBODY] = value;
			}
		}
	}

	public string UrlBaseSSL
	{
		get { return Request.Url.AbsoluteUri.Replace( @"http://" , @"https://" ); }
	}
}
