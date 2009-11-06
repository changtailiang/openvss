using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace Nolme.Xml
{
	public class XmlTranslator
	{
		private Language	m_DefaultLanguage = Language.English;
		private Language	m_CurrentLanguage = Language.English;
		private Hashtable	m_InternalLanguageHashTable;
		private int			m_InstanceCounter;

		public XmlTranslator()
		{
			this.Clear ();
		}

		public void Clear ()
		{
			m_DefaultLanguage = Language.English;
			m_CurrentLanguage = Language.English;
			m_InstanceCounter = 0;

			if (m_InternalLanguageHashTable != null)
				m_InternalLanguageHashTable.Clear ();
			
			CaseInsensitiveHashCodeProvider	HashCodeProvider= new CaseInsensitiveHashCodeProvider (CultureInfo.InvariantCulture);
			CaseInsensitiveComparer			Comparer		= new CaseInsensitiveComparer (CultureInfo.InvariantCulture);

			m_InternalLanguageHashTable		= new Hashtable (HashCodeProvider, Comparer);
		}

		public int ComputeInstanceCounter ()
		{
			m_InstanceCounter++;
			return m_InstanceCounter;
		}


		/// <summary>
		/// Main function to call to translate a text
		/// </summary>
		/// <param name="internalName">internal name to use for searching translation</param>
		/// <returns>Return the transalated string or an error string</returns>
		public string Translate (string internalName)
		{
			if (m_InternalLanguageHashTable.ContainsKey (internalName))
			{
				XmlTranslatorElement oCurrentElement		= m_InternalLanguageHashTable [internalName] as XmlTranslatorElement;
				return oCurrentElement.Translate (this.CurrentLanguage);
			}
			return string.Format (CultureInfo.InvariantCulture, "NOT_FOUND_{0}", internalName);
		}

		public XmlTranslatorElement CreateContainer (string internalName)
		{
			XmlTranslatorElement element = new XmlTranslatorElement (internalName, this.ComputeInstanceCounter ());

			return element;
		}

		public void AddOrUpdateContainer (XmlTranslatorElement objectToAdd)
		{
			if( objectToAdd == null)
			{
				throw new ArgumentNullException ("objectToAdd", SystemErrors.TranslateError ("ArgumentNull"));
			}

			if (m_InternalLanguageHashTable.ContainsKey (objectToAdd.InternalName))
			{
				m_InternalLanguageHashTable [objectToAdd.InternalName] = objectToAdd;
			}
			else
			{
				m_InternalLanguageHashTable.Add(objectToAdd.InternalName, objectToAdd);
			}
		}

		public string this[ string category]
		{
			get { return (string) m_InternalLanguageHashTable[category]; }
			set { m_InternalLanguageHashTable[category] = value; }
		}

		public string GetContainer( string category)
		{
			return (string) m_InternalLanguageHashTable[category];
		}

		public void DeleteContainer ( string category)
		{
			m_InternalLanguageHashTable.Remove( category );
		}

		public IDictionaryEnumerator GetEnumerator()
		{
			return m_InternalLanguageHashTable.GetEnumerator();
		}

		#region Properties
		public Language	DefaultLanguage
		{
			get { return m_DefaultLanguage; }
			set { m_DefaultLanguage = value; }
		}

		public Language	CurrentLanguage
		{
			get { return m_CurrentLanguage; }
			set { m_CurrentLanguage = value; }
		}
		#endregion

		#region Load / Save
		public virtual Type[] GetExtraTypes ()
		{
			Type [] extraTypes= new Type[21];
			extraTypes[0] = typeof(XmlBrush);
			extraTypes[1] = typeof(XmlSolidBrush);
			extraTypes[2] = typeof(XmlTextureBrush);
			extraTypes[3] = typeof(XmlLinearGradientBrush);
			extraTypes[4] = typeof(XmlCollection);
			extraTypes[5] = typeof(XmlColor);
			extraTypes[6] = typeof(XmlColorBlend);
			extraTypes[7] = typeof(XmlDateTime);
			extraTypes[8] = typeof(XmlFont);
			extraTypes[9] = typeof(XmlHashtable);
			extraTypes[10]= typeof(XmlImage);
			extraTypes[11]= typeof(XmlItemKeyAndValue);
			extraTypes[12] = typeof(XmlLanguage);
			extraTypes[13] = typeof(XmlList);
			extraTypes[14] = typeof(XmlPen);
			extraTypes[15] = typeof(XmlPointF2d);
			extraTypes[16] = typeof(XmlSizeF2d);
			extraTypes[17] = typeof(XmlString);
			extraTypes[18] = typeof(XmlConfigurationNode);
			extraTypes[19] = typeof(XmlTranslatorLocalizedElement);
			extraTypes[20] = typeof(XmlTranslatorElement);

			return extraTypes;
		}

		public void Load (string outputFileName)
		{
			// Clear all previous translations
			this.Clear ();

			// Init extra type
			Type [] extraTypes= this.GetExtraTypes ();

			// Create an instance of the XmlSerializer class of type Contact array        
			XmlSerializer x = new XmlSerializer( typeof(object[]), extraTypes);

			// Read the XML file if it exists ---
			FileStream fs = new FileStream( outputFileName, FileMode.Open );
			if (fs != null)
			{
				// Deserialize the content of the XML file to a Contact array utilizing XMLReader
				XmlReader reader = new XmlTextReader(fs);         
				object[] objects = (object[]) x.Deserialize( reader );

				// Add each member of the Contact array to the hash table
				for ( int i = 0; i < objects.Length; i++ )
				{
					XmlTranslatorElement currentObject = (XmlTranslatorElement) objects[i];
					m_InternalLanguageHashTable.Add(currentObject.InternalName, currentObject);

					// Incease instance counter
					this.ComputeInstanceCounter ();
				}

				// Close handle
				fs.Close();
			}
		}

		public void Save(string outputFileName)
		{
			// Create an instance of Contact array, and copy the content of the hash table to this array
			object[] objects = new object[m_InternalLanguageHashTable.Count];
			m_InternalLanguageHashTable.Values.CopyTo( objects, 0 );

			// Init extra type
			Type [] extraTypes= this.GetExtraTypes ();

			// Serialize the content of the Contact array to a XML file
			XmlSerializer x = new XmlSerializer( typeof(object[]), extraTypes);
			TextWriter writer = new StreamWriter(outputFileName);
			x.Serialize( writer, objects);
			writer.Close ();
		}
		#endregion
	}
}