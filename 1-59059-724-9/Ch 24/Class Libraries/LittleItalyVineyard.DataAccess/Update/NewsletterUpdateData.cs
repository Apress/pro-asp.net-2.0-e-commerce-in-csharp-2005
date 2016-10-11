using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using LittleItalyVineyard.Common;

namespace LittleItalyVineyard.DataAccess.Update
{
	public class NewsletterUpdateData : DataAccessBase
	{
		private EndUser _enduser;
		private NewsletterUpdateDataParameters _newsletterupdatedataparameters;

		public NewsletterUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.NewsletterUnsubscribe_Update.ToString();
		}

		public void Update()
		{
			_newsletterupdatedataparameters = new NewsletterUpdateDataParameters( EndUser );
			DataBaseHelper dbhelper = new DataBaseHelper( StoredProcedureName );
			dbhelper.Parameters = _newsletterupdatedataparameters.Parameters;
			dbhelper.Run();
		}

		public EndUser EndUser
		{
			get { return _enduser; }
			set { _enduser = value; }
		}
	}

	public class NewsletterUpdateDataParameters
	{
		private EndUser _enduser;
		private SqlParameter[] _parameters;

		public NewsletterUpdateDataParameters( EndUser enduser )
		{
			EndUser = enduser;
			Build();
		}

		private void Build()
		{
			SqlParameter[] parameters =
		    {
		        new SqlParameter( "@EndUserID" , EndUser.EndUserID )
		    };

			Parameters = parameters;
		}

		public EndUser EndUser
		{
			get { return _enduser; }
			set { _enduser = value; }
		}

		public SqlParameter[] Parameters
		{
			get { return _parameters; }
			set { _parameters = value; }
		}
	}
}
