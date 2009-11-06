using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Globalization;


using System.Drawing;
namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlTranslatorElement.
	/// </summary>
	public class XmlTranslatorElement
	{
		private string		m_InternalName;		// Use this name to get translation
		private int			m_FilePosition;		// Hashtable won't keep file order
		private XmlList		m_LocalizedStrings;

		public XmlTranslatorElement()
		{
			//m_FilePosition		= 0;
			m_InternalName		= string.Empty;
			m_LocalizedStrings	= new XmlList ();
		}

		public XmlTranslatorElement(int filePosition)
		{
			m_FilePosition		= filePosition;
			m_InternalName		= string.Empty;
			m_LocalizedStrings	= new XmlList ();
		}

		public XmlTranslatorElement(string internalName, int filePosition)
		{
			m_FilePosition		= filePosition;
			m_InternalName		= internalName;
			m_LocalizedStrings	= new XmlList ();
		}

		/// <summary>
		/// Main function used to translate words
		/// </summary>
		/// <param name="destinationLanguage">Which language to use fro translation</param>
		/// <returns>Return the translated string mathcing destination language or an error string</returns>
		public string Translate (Language destinationLanguage)
		{
			if (m_LocalizedStrings != null)
			{
				for (int i = 0; i < m_LocalizedStrings.Count; i++)
				{
					XmlTranslatorLocalizedElement CurrentElement = (XmlTranslatorLocalizedElement)m_LocalizedStrings.Items[i];
					if (CurrentElement.LanguageUsed.Language == destinationLanguage)
					{
						return CurrentElement.TranslatedString.String;
					}
				}
			}
			
			return string.Format (CultureInfo.InvariantCulture, "NOT_FOUND_{0}_{1}", this.InternalName, destinationLanguage.ToString());
		}

		/// <summary>
		/// Add or update a word translation in a specific language
		/// </summary>
		/// <param name="destinationLanguage">Destination language</param>
		/// <param name="translatedText">Word translated into destination language</param>
		/// <param name="lastModifyingPerson">Just keep a trace of person who have modified this translation</param>
		/// <param name="lastModificationTime">Keep last modification time</param>
		/// <returns>Return true if an element have been updated, false otherwise</returns>
		public bool AddOrUpdate (Language destinationLanguage, string translatedText, string lastModifyingPerson, DateTime lastModificationTime)
		{
			bool	TranslationUpdated = false;

			if (m_LocalizedStrings	!= null)
			{
				// Add or update
				for (int i = 0; i < m_LocalizedStrings.Count; i++)
				{
					XmlTranslatorLocalizedElement CurrentElement = (XmlTranslatorLocalizedElement)m_LocalizedStrings.Items[i];
					if (CurrentElement.LanguageUsed.Language == destinationLanguage)
					{
						// Update element
						CurrentElement.TranslatedString		= new XmlString (translatedText);
						CurrentElement.LastModifyingPerson	= new XmlString (lastModifyingPerson);
						CurrentElement.LastModified			= new XmlDateTime(lastModificationTime);
						TranslationUpdated					= true;
						break;
					}
				}
			}
			else
			{
				// Create list
				m_LocalizedStrings	= new XmlList ();
			}

			if (!TranslationUpdated)
			{
				// Add new translation
				XmlTranslatorLocalizedElement NewElement = new XmlTranslatorLocalizedElement (destinationLanguage, translatedText, lastModifyingPerson, lastModificationTime);
				m_LocalizedStrings.Add (NewElement);
			}

			return TranslationUpdated;
		}

		#region Properties
		public XmlList		Translations
		{
			get { return m_LocalizedStrings; }
			set { m_LocalizedStrings = value; }
		}

		[System.Xml.Serialization.XmlAttribute ("InternalName")]
		public string		InternalName
		{
			get { return m_InternalName; }
			set { m_InternalName = value; }
		}

		[System.Xml.Serialization.XmlAttribute ("FilePosition")]
		public	int			FilePosition
		{
			get {return m_FilePosition; }
			set { m_FilePosition = value; }
		}
		#endregion
	}
}
