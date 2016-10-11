using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;

namespace LittleItalyVineyard.Operational
{
	public class Utilities
	{
		public static string FormatText( string text , bool allow )
		{
			string formatted = "";

			StringBuilder sb = new StringBuilder( text );
			sb.Replace( "  " , " &nbsp;" );
			
			if ( !allow )
			{
				sb.Replace( "<br>" , Environment.NewLine );
				sb.Replace( "&nbsp;" , " " );
				formatted = sb.ToString();
			}
			else
			{
				StringReader sr = new StringReader( sb.ToString() );
				StringWriter sw = new StringWriter();
				
				while ( sr.Peek() > -1 )
				{
					string temp = sr.ReadLine();
					sw.Write( temp + "<br>" );
				}

				formatted = sw.GetStringBuilder().ToString();
			}
			
			return formatted;
		}

		public static void LogException( Exception ex )
		{
			using ( StreamWriter sw = new StreamWriter( HttpContext.Current.Server.MapPath( @"ExceptionLog\LogFile.txt" ) , true ) )
			{
				sw.WriteLine( DateTime.Now.ToShortDateString() + Environment.NewLine + ex.InnerException.ToString() + Environment.NewLine + Environment.NewLine );
			}
		}
	}
}
