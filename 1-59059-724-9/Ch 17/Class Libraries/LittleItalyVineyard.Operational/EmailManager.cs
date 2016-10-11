using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Configuration;

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
			message.Body = Utilities.FormatText( emailcontents.Body , true );
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
}
