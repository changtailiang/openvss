using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlTranslatorLocalizedElement.
	/// </summary>
	public class XmlTranslatorLocalizedElement
	{
		private	XmlDateTime	m_LastModified;
		private	XmlString	m_LastModifyingPerson;
		private XmlLanguage	m_LanguageUsed;
		private XmlString	m_TranslatedString;

		public XmlTranslatorLocalizedElement()
		{
			this.Clear ();
		}

		public XmlTranslatorLocalizedElement(Language destinationLanguage, string translatedText, string lastModifyingPerson, DateTime lastModificationTime)
		{
			this.Clear ();
			this.Update (destinationLanguage, translatedText, lastModifyingPerson, lastModificationTime);
		}

		public void Clear ()
		{
			m_LastModified			= new XmlDateTime	(DateTime.MinValue);
			m_LastModifyingPerson	= new XmlString		(String.Empty);
			m_LanguageUsed			= new XmlLanguage	();
			m_TranslatedString		= new XmlString		(String.Empty);
		}

		/// <summary>
		/// Update a translated word for it's associated language
		/// </summary>
		/// <param name="destinationLanguage">Destination language</param>
		/// <param name="translatedText">Word translated into destination language</param>
		/// <param name="lastModifyingPerson">Just keep a trace of person who have modified this translation</param>
		/// <param name="lastModificationTime">Keep last modification time</param>
		public void Update (Language destinationLanguage, string translatedText, string lastModifyingPerson, DateTime lastModificationTime)
		{
			if (lastModificationTime != DateTime.MinValue)
				m_LastModified			= new XmlDateTime (lastModificationTime);

			if ((lastModifyingPerson != null) && (lastModifyingPerson.Length != 0))
				m_LastModifyingPerson	= new XmlString (lastModifyingPerson);

			if (destinationLanguage != Language.Invalid)
			{
				m_LanguageUsed			= new XmlLanguage ();
				m_LanguageUsed.Language = destinationLanguage;
			}

			if ((translatedText != null) && (translatedText.Length != 0))
				m_TranslatedString		= new XmlString (translatedText);
		}

		#region Properties
		public	XmlDateTime	LastModified
		{
			get {return m_LastModified; }
			set {m_LastModified = value ;}
		}

		public	XmlString		LastModifyingPerson
		{
			get {return m_LastModifyingPerson; }
			set {m_LastModifyingPerson = value ;}
		}

		public XmlLanguage		LanguageUsed
		{
			get {return m_LanguageUsed; }
			set {m_LanguageUsed = value ;}
		}

		public XmlString		TranslatedString
		{
			get {return m_TranslatedString; }
			set {m_TranslatedString = value ;}
		}
		#endregion
	}
}
