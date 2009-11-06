using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Management; 
using System.Globalization;

namespace Nolme.Core
{
	/// <summary>
	/// Summary description for SystemUtility.
	/// </summary>
	public sealed class SystemUtility
	{
		private SystemUtility()	{}

		/// <summary>
		/// Permet de vérifier si le paramètre reçu correspond à un entier.
		/// </summary>
		/// <param name="valueToManage">Valeur à tester.</param>
		/// <returns>Retourne un booléen indiquant s'il s'agit d'un entier.</returns>
		public static bool IsNumber(string valueToManage)
		{
			if (valueToManage == null)
			{
				throw new ArgumentNullException (string.Format (CultureInfo.InvariantCulture, "Null reference argument"));
			}

			Regex numregex = new Regex("\\d{" + valueToManage.Length + "}");
			Match m = numregex.Match(valueToManage);
			return m.Success;
		}
		/// <summary>
		/// Permet de vérifier si la chaîne de caractères recue 
		/// en paramètre correspond à une date.
		/// </summary>
		/// <param name="valueToManage">Valeur à tester.</param>
		/// <returns>Retourne un booléen indiquant s'il s'agit d'une date.</returns>
		public static bool IsDateTime(string valueToManage)
		{
			if (valueToManage == null)
			{
				throw new ArgumentNullException (string.Format (CultureInfo.InvariantCulture, "Null reference argument"));
			}

			try
			{
				DateTime.Parse (valueToManage, CultureInfo.InvariantCulture);
				return true;
			}
			catch (FormatException)
			{
				return false;
			}
		}

		/// <summary>
		/// Return the SID associated to a username
		/// </summary>
		/// <param name="userName">SID of username to get.</param>
		/// <returns>Return a string like S-1-5-21-1844237615-73586283-725345543-1003</returns>
		public static string GetUserSid (string userName) 
		{ 
			ManagementObjectSearcher	query; 
			ManagementObjectCollection	queryCollection; 

			// local scope 
			ConnectionOptions co	= new ConnectionOptions(); 
			co.Username				= userName; 
			ManagementScope msc		= new ManagementScope ("\\root\\cimv2",co); 
			string queryString		= "SELECT * FROM Win32_UserAccount where name='" +co.Username  +"'"; 
			SelectQuery q			= new SelectQuery (queryString); 
			query					= new ManagementObjectSearcher(msc, q); 
			queryCollection			= query.Get(); 
			
			/*
			string res				= StringUtility.CreateEmptyString (); 
			foreach(ManagementObject mo in queryCollection)
			{ 
				// there should be only one here! 
				res+= mo["SID"].ToString(); 
			} 
			*/
			StringBuilder LocalStringBuilder = new StringBuilder();
			foreach(ManagementObject mo in queryCollection)
			{
				LocalStringBuilder.Append (mo["SID"].ToString ());
			}
			
			return LocalStringBuilder.ToString ();
		} 
	}
}
