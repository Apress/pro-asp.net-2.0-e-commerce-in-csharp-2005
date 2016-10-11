using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Security.Cryptography.X509Certificates;

using LittleItalyVineyard.Common;
using LittleItalyVineyard.Operational.PayPalAPI.Sandbox;

namespace LittleItalyVineyard.Operational
{
	public class PayPalManager
	{
		private PayPalAPIAASoapBinding PPInterface = new PayPalAPIAASoapBinding();
		private PayPalAPISoapBinding service = new PayPalAPISoapBinding();
		private bool _issubmissionsuccess;
		private string _submissionerror;

		public PayPalManager()
		{
			UserIdPasswordType user = new UserIdPasswordType();

			//set api credentials
			user.Username = ConfigurationManager.AppSettings["PayPalAPIUsername"];  //set this to your API username
			user.Password = ConfigurationManager.AppSettings["PayPalAPIPassword"];  //set this to your API password

			PPInterface.Url = ConfigurationManager.AppSettings["PayPalAPIURL"];
			PPInterface.RequesterCredentials = new CustomSecurityHeaderType();
			PPInterface.RequesterCredentials.Credentials = new UserIdPasswordType();
			PPInterface.RequesterCredentials.Credentials = user;

			service.Url = ConfigurationManager.AppSettings["PayPalAPIURL"];
			service.RequesterCredentials = new CustomSecurityHeaderType();
			service.RequesterCredentials.Credentials = new UserIdPasswordType();
			service.RequesterCredentials.Credentials = user;

			//this is .NET 2.0 specific portion of the code that
			//allows us to have the .p12 on the filesystem and
			//not have to register it with WinHttpCertCfg
			//uses X509Certificate2 class.
			FileStream fstream = File.Open( CertPath , FileMode.Open , FileAccess.Read );
			byte[] buffer = new byte[fstream.Length];

			int count = fstream.Read( buffer , 0 , buffer.Length );

			fstream.Close();

			//use .NET 2.0  X509Certificate2 class to read .p12 from filesystem
			// where "12345678" is the private key password

			X509Certificate2 cert = new X509Certificate2( buffer , CertPassword );
			PPInterface.ClientCertificates.Add( cert );
			service.ClientCertificates.Add( cert );
		}

		public void ProcessDirectPayment( PayPalInformation paypalinformation )
		{
			DoDirectPaymentRequestType DoDirectPmtReqType = new DoDirectPaymentRequestType();
			DoDirectPmtReqType.DoDirectPaymentRequestDetails = new DoDirectPaymentRequestDetailsType();

			// Set payment action
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentAction = PaymentActionCodeType.Sale;

			// Set IP
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.IPAddress = HttpContext.Current.Request.UserHostAddress;

			// Set CreditCard info.
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard = new CreditCardDetailsType();
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CreditCardNumber = paypalinformation.Order.CreditCard.Number;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CreditCardType = ( CreditCardTypeType ) StringToEnum( typeof( CreditCardTypeType ) , paypalinformation.Order.CreditCard.CardType );

			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CVV2 = paypalinformation.Order.CreditCard.SecurityCode;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.ExpMonth = paypalinformation.Order.CreditCard.ExpMonth;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.ExpYear = paypalinformation.Order.CreditCard.ExpYear;

			// Set the billing address
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner = new PayerInfoType();
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerName = new PersonNameType();
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerName.FirstName = paypalinformation.Order.EndUser.FirstName;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerName.LastName = paypalinformation.Order.EndUser.LastName;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address = new AddressType();
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Street1 = paypalinformation.Order.CreditCard.Address.AddressLine;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Street2 = paypalinformation.Order.CreditCard.Address.AddressLine2;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.CityName = paypalinformation.Order.CreditCard.Address.City;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.StateOrProvince = paypalinformation.Order.CreditCard.Address.State;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.PostalCode = paypalinformation.Order.CreditCard.Address.PostalCode;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.CountrySpecified = true;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Country = CountryCodeType.US;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Phone = paypalinformation.Order.EndUser.ContactInformation.Phone;

			PaymentDetailsItemType[] itemArray = new PaymentDetailsItemType[paypalinformation.Order.OrderDetails.Products.Length];
			PaymentDetailsItemType items = null;

			// Loop through all items that were added to the shopping cart.
			for ( int i = 0 ; i < paypalinformation.Order.OrderDetails.Products.Length ; i++ )
			{
				items = new PaymentDetailsItemType();
				items.Amount = new BasicAmountType();
				items.Amount.Value = paypalinformation.Order.OrderDetails.Products[i].Price.ToString();
				items.Amount.currencyID = CurrencyCodeType.USD;
				items.Quantity = paypalinformation.Order.OrderDetails.Products[i].Quantity.ToString();

				items.Name = paypalinformation.Order.OrderDetails.Products[i].Name;
				items.Number = paypalinformation.Order.OrderDetails.Products[i].ProductID.ToString();

				itemArray.SetValue( items , i );
			}

			// set payment Details
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails = new PaymentDetailsType();
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.Custom = System.DateTime.Now.ToLongTimeString();
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.OrderDescription = "";

			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.PaymentDetailsItem = new PaymentDetailsItemType[itemArray.Length];
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.PaymentDetailsItem = itemArray;

			for ( int ii = 0 ; ii < itemArray.Length ; ii++ )
			{
				DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.PaymentDetailsItem.SetValue( itemArray[ii] , ii );
			}

			// Order summary.
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal = new BasicAmountType();
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal.currencyID = CurrencyCodeType.USD;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal.Value = paypalinformation.Order.OrderTotal.ToString();
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShippingTotal = new BasicAmountType();
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShippingTotal.currencyID = CurrencyCodeType.USD;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShippingTotal.Value = paypalinformation.Order.ShippingTotal.ToString();
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.TaxTotal = new BasicAmountType();
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.TaxTotal.currencyID = CurrencyCodeType.USD;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.TaxTotal.Value = paypalinformation.Order.Tax.ToString();
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ItemTotal = new BasicAmountType();
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ItemTotal.currencyID = CurrencyCodeType.USD;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ItemTotal.Value = paypalinformation.Order.SubTotal.ToString();

			//set ship to address
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShipToAddress = new AddressType();
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShipToAddress.Name = paypalinformation.Order.EndUser.FirstName + " " + paypalinformation.Order.EndUser.LastName;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShipToAddress.Street1 = paypalinformation.Order.ShippingAddress.AddressLine;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShipToAddress.CityName = paypalinformation.Order.ShippingAddress.City;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShipToAddress.StateOrProvince = paypalinformation.Order.ShippingAddress.State;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShipToAddress.PostalCode = paypalinformation.Order.ShippingAddress.PostalCode;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShipToAddress.CountrySpecified = true;
			DoDirectPmtReqType.DoDirectPaymentRequestDetails.PaymentDetails.ShipToAddress.Country = CountryCodeType.US;

			// credentials
			DoDirectPaymentReq DoDPReq = new DoDirectPaymentReq();
			DoDPReq.DoDirectPaymentRequest = DoDirectPmtReqType;
			DoDPReq.DoDirectPaymentRequest.Version = "2.20";

			try
			{
				//make call return response
				DoDirectPaymentResponseType DPRes = new DoDirectPaymentResponseType();
				DPRes = PPInterface.DoDirectPayment( DoDPReq );
				string errors = CheckForErrors( DPRes );

				if ( errors == string.Empty )
				{
					IsSubmissionSuccess = true;
					paypalinformation.Order.TransactionID = DPRes.TransactionID;
				}
				else
				{
					IsSubmissionSuccess = false;
					SubmissionError = errors;
				}
			}
			catch ( Exception ex )
			{
				throw ex;
			}
		}

		public void GetTransactionDetails( Orders order )
		{
			GetTransactionDetailsRequestType detailRequest = new GetTransactionDetailsRequestType();
			detailRequest.TransactionID = order.TransactionID;
			detailRequest.Version = "2.0";
			GetTransactionDetailsReq request = new GetTransactionDetailsReq();
			request.GetTransactionDetailsRequest = detailRequest;

			GetTransactionDetailsResponseType response = service.GetTransactionDetails( request );

			string sErrors = this.CheckForErrors( response );

			if ( sErrors == string.Empty )
			{
				PaymentInfoType payment = response.PaymentTransactionDetails.PaymentInfo;

				order.OrderTotal = GetAmountValue( payment.GrossAmount );
				order.Tax = GetAmountValue( payment.TaxAmount );
				IsSubmissionSuccess = true;
			}
			else
			{
				IsSubmissionSuccess = false;
			}
		}

		private decimal GetAmountValue( BasicAmountType amount )
		{
			decimal sOut;

			try
			{
				sOut = Convert.ToDecimal( amount.Value );
				amount.currencyID = CurrencyCodeType.USD;
			}
			catch
			{
				sOut = 0;
			}

			return sOut;
		}

		private static object StringToEnum( Type typ , string val )
		{
			object objectOut = null;

			foreach ( System.Reflection.FieldInfo fieldinfo in typ.GetFields() )
			{
				if ( fieldinfo.Name == val )
				{
					objectOut = fieldinfo.GetValue( null );
				}
			}

			return objectOut;
		}

		private string CertPath
		{
			get { return HttpContext.Current.Server.MapPath( ConfigurationManager.AppSettings["CertificatePath"] ); }
		}

		private string CertPassword
		{
			get { return ConfigurationManager.AppSettings["CertificatePassword"]; }
		}

		public bool IsSubmissionSuccess
		{
			get { return _issubmissionsuccess; }
			set { _issubmissionsuccess = value; }
		}

		public string SubmissionError
		{
			get { return _submissionerror; }
			set { _submissionerror = value; }
		}

		private string CheckForErrors( AbstractResponseType abstractResponse )
		{
			bool errorsExist = false;
			string errorList = "";

			// First, check if Ack is not Success
			if ( !abstractResponse.Ack.Equals( AckCodeType.Success ) )
			{
				errorsExist = true;
			}

			// Check for nothing in the Errors Collection
			if ( abstractResponse.Errors != null )
			{
				if ( abstractResponse.Errors.Length > 0 )
				{
					errorsExist = true;
					errorList = "ERROR: ";
					for ( int i = 0 ; i < abstractResponse.Errors.Length ; i++ )
					{
						errorList += abstractResponse.Errors[i].LongMessage + " (" + abstractResponse.Errors[i].ErrorCode + ")" +
							Environment.NewLine;
					}
				}
			}

			return errorList;
		}
	}

	public struct PayPalInformation
	{
		public Orders Order;
	}
}
