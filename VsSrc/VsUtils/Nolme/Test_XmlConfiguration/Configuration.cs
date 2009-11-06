using System;
using System.Drawing;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Nolme.Xml;

namespace Test_XmlConfiguration
{
	/// <summary>
	/// Summary description for TestConfiguration.
	/// </summary>
	public class TestConfiguration
	{
		private int						m_MyInt;
		private float					m_MyFloat;
		private string					m_MyString;
		private XmlString				m_MyXmlString;
		private ArrayList				m_MyArrayList;
		private XmlList					m_MyXmlList;
		private XmlDateTime				m_MyXmlDateTime;
		private XmlColor				m_MyXmlColor;
		private XmlSizeF2d				m_MyXmlSizeF2d;
		private XmlItemKeyAndValue		m_MyXmlItemKeyAndValue;
		private XmlTranslatorElement	m_MyXmlTranslatorElement;
		private XmlHashtable			m_MyXmlHashtable;
		private XmlPen					m_MyXmlPen;

		public TestConfiguration()
		{
			this.InitDefault ();
		}

		public void InitDefault ()
		{
			m_MyInt			= 69;
			m_MyString		= "This is a test string";
			m_MyXmlString	= new XmlString ("Native XML string object");
			m_MyFloat		= 3.14f;

			m_MyXmlDateTime				= new XmlDateTime (DateTime.Now);
			m_MyXmlColor				= new XmlColor	(Color.BurlyWood);
			m_MyXmlSizeF2d				= new XmlSizeF2d (452.62f, 895.7989f);
			m_MyXmlItemKeyAndValue		= new XmlItemKeyAndValue ("KeyNameToUse", m_MyXmlColor);
			m_MyXmlTranslatorElement	= new XmlTranslatorElement ("MyInternalName", 0);
			m_MyXmlTranslatorElement.AddOrUpdate (Language.English, "My translated text", "The last modifiying person", DateTime.Now);
			m_MyXmlTranslatorElement.AddOrUpdate (Language.German, "My translated text in German", "The last modifiying person", DateTime.Now);

			m_MyXmlPen			= new XmlPen (Color.Violet, 20);

			m_MyArrayList		= new ArrayList ();
			m_MyArrayList.Add (this.MyInt);
			m_MyArrayList.Add (this.MyFloat);
			m_MyArrayList.Add (this.MyString);
			m_MyArrayList.Add (this.MyXmlString);
			
			m_MyXmlList			= new XmlList ();
			m_MyXmlList.Add (this.MyInt);
			m_MyXmlList.Add (this.MyFloat);
			m_MyXmlList.Add (this.MyString);
			m_MyXmlList.Add (this.MyXmlString);

			m_MyXmlHashtable	= new XmlHashtable ();
			m_MyXmlHashtable.Add ("HashElement1", m_MyInt);
			m_MyXmlHashtable.Add ("HashElement2", m_MyString);
			m_MyXmlHashtable.Add ("HashElement3", m_MyXmlString);
			m_MyXmlHashtable.Add ("HashElement4", m_MyFloat);
			m_MyXmlHashtable.Add ("HashElement5", m_MyXmlList);
		}

		#region Properties
		[System.Xml.Serialization.XmlElement ("MyIntInXmlFile")]
		public int			MyInt
		{
			get { return m_MyInt; }
			set { m_MyInt = value; }
		}

		[System.Xml.Serialization.XmlElement ("MyFloatInXmlFile")]
		public float		MyFloat
		{
			get { return m_MyFloat; }
			set { m_MyFloat = value; }
		}

		[System.Xml.Serialization.XmlElement ("MyStringInXmlFile")]
		public string	MyString
		{
			get { return m_MyString; }
			set { m_MyString = value; }
		}

		[System.Xml.Serialization.XmlElement ("MyXmlStringInXmlFile")]
		public XmlString	MyXmlString
		{
			get { return m_MyXmlString; }
			set { m_MyXmlString = value; }
		}

		[System.Xml.Serialization.XmlElement ("MyXmlPenInXmlFile")]
		public XmlPen	MyXmlPen
		{
			get { return m_MyXmlPen; }
			set { m_MyXmlPen = value; }
		}

		[System.Xml.Serialization.XmlElement ("MyArrayListInXmlFile")]
		public ArrayList	MyArrayList
		{
			get { return m_MyArrayList; }
			set { m_MyArrayList = value; }
		}

		[System.Xml.Serialization.XmlElement ("MyXmlListInXmlFile")]
		public XmlList		MyXmlList
		{
			get { return m_MyXmlList; }
			set { m_MyXmlList = value; }
		}
		[System.Xml.Serialization.XmlElement ("MyXmlHashtableInXmlFile")]
		public XmlHashtable		MyXmlHashtable
		{
			get { return m_MyXmlHashtable; }
			set { m_MyXmlHashtable = value; }
		}

		[System.Xml.Serialization.XmlElement ("MyXmlDateTimeInXmlFile")]
		public XmlDateTime	MyXmlDateTime
		{
			get { return m_MyXmlDateTime; }
			set { m_MyXmlDateTime = value; }
		}

		[System.Xml.Serialization.XmlElement ("MyXmlColorInXmlFile")]
		public XmlColor	MyXmlColor
		{
			get { return m_MyXmlColor; }
			set { m_MyXmlColor = value; }
		}

		[System.Xml.Serialization.XmlElement ("MyXmlSizeF2dInXmlFile")]
		public XmlSizeF2d	MyXmlSizeF2d
		{
			get { return m_MyXmlSizeF2d; }
			set { m_MyXmlSizeF2d = value; }
		}

		[System.Xml.Serialization.XmlElement ("MyXmlItemKeyAndValueInXmlFile")]
		public XmlItemKeyAndValue	MyXmlItemKeyAndValue
		{
			get { return m_MyXmlItemKeyAndValue; }
			set { m_MyXmlItemKeyAndValue = value; }
		}

		[System.Xml.Serialization.XmlElement ("MyXmlTranslatorElementInXmlFile")]
		public XmlTranslatorElement	MyXmlTranslatorElement
		{
			get { return m_MyXmlTranslatorElement; }
			set { m_MyXmlTranslatorElement = value; }
		}
		
		#endregion

		public static Type[] GetExtraTypes ()
		{
			Type [] BaseTypes = XmlConfiguration.GetXmlTypes ();
			Type [] ExtraTypes= new Type[BaseTypes.Length + 1];

			BaseTypes.CopyTo (ExtraTypes, 0);
			ExtraTypes[BaseTypes.Length + 0] = typeof(TestConfiguration);

			return ExtraTypes;
		}

		public void Save (string outputFileName)
		{
			// Init extra type
			Type [] ExtraTypes= TestConfiguration.GetExtraTypes ();

			StreamWriter objStreamWriter = new StreamWriter(outputFileName);
			XmlSerializer x = new XmlSerializer(this.GetType (), ExtraTypes);
			x.Serialize(objStreamWriter, this);
			objStreamWriter.Close();
		}

		public static TestConfiguration Load (string inputFileName)
		{
			Type []				ExtraTypes= TestConfiguration.GetExtraTypes ();
			TestConfiguration	Result;

			StreamReader objStreamReader = new StreamReader(inputFileName);
			XmlSerializer x2 = new XmlSerializer(typeof (TestConfiguration), ExtraTypes);
			Result = (TestConfiguration)x2.Deserialize(objStreamReader);
			objStreamReader.Close();

			return Result;
		}
	}
}
