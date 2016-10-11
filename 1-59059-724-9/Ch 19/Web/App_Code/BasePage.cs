using System;
using System.Web;

using LittleItalyVineyard.Common;

public class BasePage : System.Web.UI.Page
{
	internal const string KEY_CURRENTUSER		= "Current Logged In User";

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
}
