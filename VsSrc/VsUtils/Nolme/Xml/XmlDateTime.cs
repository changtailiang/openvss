using System;
using System.Xml;
using System.Xml.Serialization;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlDateTime.
	/// </summary>
	public class XmlDateTime
	{
		private DateTime	m_DateTime;

		public XmlDateTime ()
		{
			this.DateTime = DateTime.MinValue;
		}

		public XmlDateTime (DateTime now)
		{
			this.DateTime = now;
		}

		// Set serialization to ignore this property
		// because the 'Name' property
		// is used instead to serialize the Color as an HTML string.
		[XmlIgnoreAttribute()]
		public DateTime DateTime
		{
			get { return m_DateTime;	}
			set { m_DateTime = value;	}
		}

		// Serializes the time to XML.
		[System.Xml.Serialization.XmlAttribute ("Hour")]
		public int Hours
		{
			get { return m_DateTime.Hour; }
			set { m_DateTime = m_DateTime.AddHours (value); }
		}
		[System.Xml.Serialization.XmlAttribute ("Minute")]
		public int Minute
		{
			get { return m_DateTime.Minute; }
			set { m_DateTime = m_DateTime.AddMinutes (value); }
		}
		[System.Xml.Serialization.XmlAttribute ("Second")]
		public int Second
		{
			get { return m_DateTime.Second; }
			set { m_DateTime = m_DateTime.AddSeconds (value); }
		}
		[System.Xml.Serialization.XmlAttribute ("Millisecond")]
		public int Millisecond
		{
			get { return m_DateTime.Millisecond; }
			set { m_DateTime = m_DateTime.AddMilliseconds (value); }
		}

		[System.Xml.Serialization.XmlAttribute ("DayOfWeek")]
		public System.DayOfWeek DayOfWeek
		{
			get { return m_DateTime.DayOfWeek; }
			//set { m_DateTime.DayOfWeek = value; }
		}
		[System.Xml.Serialization.XmlAttribute ("DayOfYear")]
		public int DayOfYear
		{
			get { return m_DateTime.DayOfYear; }
			//set { m_DateTime.DayOfYear = value; }
		}
		[System.Xml.Serialization.XmlAttribute ("Day")]
		public int Day
		{
			get { return m_DateTime.Day; }
			set { m_DateTime = m_DateTime.AddDays (value); }
		}
		[System.Xml.Serialization.XmlAttribute ("Month")]
		public int Month
		{
			get { return m_DateTime.Month; }
			set { m_DateTime = m_DateTime.AddMonths (value); }
		}
		[System.Xml.Serialization.XmlAttribute ("Year")]
		public int Year
		{
			get { return m_DateTime.Year; }
			set { m_DateTime = m_DateTime.AddYears (value); }
		}
	}
}
