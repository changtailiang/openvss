using System;
using System.Drawing;
using System.Collections;
using System.Xml.Serialization;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlList.
	/// </summary>
	public class XmlList
	{
		private XmlCollection m_Items = new XmlCollection();

		public XmlList ()
		{}

		public XmlList (object[] array)
		{
			if (array == null) throw new NolmeXmlArgumentNullException ();

			m_Items.Clear ();
			for (int i = 0; i < array.Length; i++)
			{
				m_Items.Add (array [i]);
			}
		}

		public XmlList (int[] array)
		{
			if (array == null) throw new NolmeXmlArgumentNullException ();

			m_Items.Clear ();
			for (int i = 0; i < array.Length; i++)
			{
				m_Items.Add (array [i]);
			}
		}

		public XmlList (float[] array)
		{
			if (array == null) throw new NolmeXmlArgumentNullException ();

			m_Items.Clear ();
			for (int i = 0; i < array.Length; i++)
			{
				m_Items.Add (array [i]);
			}
		}

		public XmlList (Color[] array)
		{
			if (array == null) throw new NolmeXmlArgumentNullException ();

			m_Items.Clear ();
			for (int i = 0; i < array.Length; i++)
			{
				m_Items.Add (new XmlColor (array [i]));
			}
		}

		[System.Xml.Serialization.XmlAttribute ("Count")] 
		public int Count
		{
			get { return m_Items.Count; }
			//set { /* Nothing to do, count updated during load */ }
		}

		[System.Xml.Serialization.XmlElement ("Item")] 
		public XmlCollection Items
		{
			get { return m_Items;  }
			set { m_Items = value; }
		}

		public void Add (object newElement)
		{
			m_Items.Add (newElement);
		}
	}
}
