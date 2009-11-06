using System;
using System.Globalization;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for SystemErrors.
	/// </summary>
	public class SystemErrors : XmlTranslator
	{
		static private SystemErrors	g_ErrorObject;
		static private string		g_ErrorsFileName = @"./datas/Errors.xml";

		public SystemErrors()
		{
			if (g_ErrorObject != null)
			{
				throw new ArgumentNullException ("Constructor", string.Format (CultureInfo.InvariantCulture, "Global pointer NOT Null"));
			}
			g_ErrorObject = this;
		}

		~SystemErrors()
		{
			if (g_ErrorObject == null)
			{
				throw new ArgumentNullException ("Destructor", string.Format (CultureInfo.InvariantCulture, "Global pointer Null"));
			}
			g_ErrorObject = null;
		}
		#region Properties
		static public SystemErrors	Instance
		{
			get { return SystemErrors.g_ErrorObject; }
		}
		static public string ErrorsFileName
		{
			get { return SystemErrors.g_ErrorsFileName; }
			set { SystemErrors.g_ErrorsFileName = value; }
		}
		#endregion
		
		static public string TranslateError (string internalName)
		{
			if (g_ErrorObject == null)
			{
				// Allocate error object
				g_ErrorObject = new SystemErrors ();
#if DEBUG
				SystemErrors.GenerateFile ();
#endif
			}

			return SystemErrors.Instance.Translate (internalName);
		}

#if DEBUG
		static public void GenerateFile ()
		{
			XmlTranslatorElement element;

			// Argument NULL
			element = new XmlTranslatorElement ("ArgumentNull", 0);
			element.AddOrUpdate (Language.French, "Argument définit à Null", "Vincent", DateTime.Now);
			element.AddOrUpdate (Language.English, "Argument set to Null", "Vincent", DateTime.Now);
			SystemErrors.Instance.AddOrUpdateContainer (element);

			// Bad URL, remote file not found
			element = new XmlTranslatorElement ("UriFormatException", 0);
			element.AddOrUpdate (Language.French, "Format d'Url incorrect ou fichier absent", "Vincent", DateTime.Now);
			element.AddOrUpdate (Language.English, "Bad Uri or file missing", "Vincent", DateTime.Now);
			SystemErrors.Instance.AddOrUpdateContainer (element);


			// Save file
			SystemErrors.Instance.Save (SystemErrors.ErrorsFileName);
		}
#endif

	}
}
