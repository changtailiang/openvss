using System;
using System.Collections;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlHashtable.
	/// </summary>
	public class XmlHashtable
	{
		private Hashtable table = new Hashtable();

		public XmlHashtable()
		{
		}

		public void Add (string key, object value)
		{
			table.Add (key, value);
		}

		[System.Xml.Serialization.XmlAttribute ("Count")] 
		public int Count
		{
			get { return table.Count; }
			set { System.Diagnostics.Debug.Assert (value == table.Count); /* Nothing to do, count updated during load, keep it for serialization */ }
		}

		[System.Xml.Serialization.XmlElement ("HashItem")] 
		public XmlCollection Elements
		{
			get
			{
				XmlCollection	Result = new XmlCollection ();

				// Loop throw all hashtable elements
				IEnumerator Iterator = table.GetEnumerator ();
				while (Iterator.MoveNext ())
				{
					DictionaryEntry		Entry		= (DictionaryEntry)Iterator.Current;
					XmlItemKeyAndValue	NewElement	= new XmlItemKeyAndValue ((string)Entry.Key, Entry.Value);
					Result.Add (NewElement);
				}
				return Result;
			}
			set 
			{
				if (value == null)
				{
					throw new ArgumentNullException("value", SystemErrors.TranslateError ("ArgumentNull"));
				}

				// Reset hashtable
				table.Clear ();

				// Add each member of the Contact array to the hash table
				int iCount = value.Count;
				for ( int i = 0; i < iCount; i++ )
				{
					XmlItemKeyAndValue NewElement = (XmlItemKeyAndValue)value[i];
					table.Add( NewElement.Key, NewElement.Value);
				}
			}
		}
	}
}
