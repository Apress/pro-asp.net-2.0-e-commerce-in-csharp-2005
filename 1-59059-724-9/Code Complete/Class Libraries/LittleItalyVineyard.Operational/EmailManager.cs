using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Web;
using System.Data;

namespace LittleItalyVineyard.Operational
{
	public class EmailManager
	{
		private bool _issent;

		public EmailManager()
		{

		}

		public void Send( EmailContents emailcontents )
		{
			SmtpClient client = new SmtpClient( SMTPServerName );
			client.UseDefaultCredentials = true;
			MailAddress from = new MailAddress( emailcontents.FromEmailAddress , emailcontents.FromName );
			MailAddress to = new MailAddress( ToAddress );

			MailMessage message = new MailMessage( from , to );

			message.Subject = emailcontents.Subject;
			message.Body = emailcontents.Body;
			message.IsBodyHtml = true;

			try
			{
				client.Send( message );
				IsSent = true;
			}
			catch ( Exception ex )
			{
				throw ex;
			}
		}

		public bool IsSent
		{
			get { return _issent; }
			set { _issent = value; }
		}

		private string SMTPServerName
		{
			get { return ConfigurationManager.AppSettings[ "SMTPServer" ]; }
		}

		private string ToAddress
		{
			get { return ConfigurationManager.AppSettings[ "ToAddress" ]; }
		}
	}

	public struct EmailContents
	{
		public string To;
		public string FromName;
		public string FromEmailAddress;
		public string Subject;
		public string Body;
	}

	public class NewsletterManager
	{
		private DataSet _userdata;
		private string _messagebody;

		public NewsletterManager()
		{

		}

		public void SendNewsletter()
		{
			string unsubscr = string.Empty;
			string msgbody = string.Empty;
			EmailManager mailmanager = new EmailManager();
			EmailContents mailcontents = new EmailContents();
		
			using ( StreamReader sr = new StreamReader( HttpContext.Current.Server.MapPath( "~/Admin/EmailTemplates/CustomerNewsletter.htm" ) ) )
			{
				string stringBody = sr.ReadToEnd();

				foreach ( DataRow dr in UserData.Tables[0].Rows )
				{
					msgbody = stringBody;

					unsubscr = "<a href=\"http://www.littleitalyvineyards.com/Admin/Unsubscribe.aspx?EndUserID=" + 
						dr["EndUserID"].ToString() + "?FullName=" + dr["FirstName"].ToString() + " " + dr["LastName"].ToString() + 
						"\"Target=\"_blank\"\">Click here</a>";

					msgbody = msgbody.Replace( "`+Name+" , dr["FirstName"].ToString() + " " + dr["LastName"].ToString() );
					msgbody = msgbody.Replace( "`+MessageBody+" , MessageBody );
					msgbody = msgbody.Replace( "`+Clickhere+" , unsubscr );
					
					mailcontents.To = "psarknas@sarknasoft.com"; // dr["Email"].ToString();
					mailcontents.FromName = "Little Italy Vineyards";
					mailcontents.FromEmailAddress = "info@littleitalyvineyards.com";
					mailcontents.Subject = "Newsletter";
					mailcontents.Body = msgbody;

					mailmanager.Send( mailcontents );
				}
			}
		}

		public string MessageBody
		{
			get { return _messagebody; }
			set { _messagebody = value; }
		}

		public DataSet UserData
		{
			get { return _userdata; }
			set { _userdata = value; }
		}
	}
}
