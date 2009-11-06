using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Globalization;

namespace Nolme.Xml
{
	public class XmlConfiguration
	{
		private Hashtable	m_InternalHashTable;

		public XmlConfiguration()
		{
			this.Clear ();
		}

		public void Clear ()
		{
			if (m_InternalHashTable != null)
				m_InternalHashTable.Clear ();
			
			CaseInsensitiveHashCodeProvider	HashCodeProvider= new CaseInsensitiveHashCodeProvider (CultureInfo.InvariantCulture);
			CaseInsensitiveComparer			Comparer		= new CaseInsensitiveComparer (CultureInfo.InvariantCulture);

			m_InternalHashTable		= new Hashtable (HashCodeProvider, Comparer);
		}

		public object AddOrUpdateContainer (string internalName)
		{
			object Result = this.AddOrUpdateContainer (internalName, new XmlConfigurationNode (internalName));
			return Result;
		}

		public object AddOrUpdateContainer (string internalName, object elementToAdd)
		{
			if (m_InternalHashTable.ContainsKey (internalName))
			{
				m_InternalHashTable [internalName] = elementToAdd;
			}
			else
			{
				m_InternalHashTable.Add(internalName, elementToAdd);
			}

			return elementToAdd;
		}

		public object this[ string category]
		{
			get { return m_InternalHashTable[category]; }
			set { m_InternalHashTable[category] = value; }
		}

		public string GetContainer( string category)
		{
			return (string) m_InternalHashTable[category];
		}

		public void DeleteContainer ( string category)
		{
			m_InternalHashTable.Remove( category );
		}

		public IDictionaryEnumerator GetEnumerator()
		{
			return m_InternalHashTable.GetEnumerator();
		}

		#region Load / Save
		public static Type[] GetXmlTypes ()
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

		public virtual Type[] GetExtraTypes ()
		{
			return XmlConfiguration.GetXmlTypes ();
		}

		public virtual void Load (string outputFileName)
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
					m_InternalHashTable.Add(currentObject.InternalName, currentObject);
				}

				// Close handle
				fs.Close();
			}
		}

		public virtual void Save(string outputFileName)
		{
			// Create an instance of Contact array, and copy the content of the hash table to this array
			object[] objects = new object[m_InternalHashTable.Count];
			m_InternalHashTable.Values.CopyTo( objects, 0 );

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
