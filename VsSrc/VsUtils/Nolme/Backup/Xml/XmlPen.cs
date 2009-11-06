using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;

namespace Nolme.Xml
{
	/// <summary>
	/// Summary description for XmlPen.
	/// </summary>
	public class XmlPen : IDisposable
	{
		private Pen			m_Pen;

		public XmlPen()
		{
			
		}

		public XmlPen(Color color)
		{
			m_Pen = new Pen (color);
		}

		public XmlPen(Color color, float width)
		{
			m_Pen = new Pen (color, width);
		}

		public XmlPen(Pen newPen)
		{
			m_Pen = newPen;
		}

		#region IDisposable implementation
		// Track whether Dispose has been called.
		private bool disposed;
		public void Dispose()
		{
			Dispose(true);
			// This object will be cleaned up by the Dispose method.
			// Therefore, you should call GC.SupressFinalize to
			// take this object off the finalization queue 
			// and prevent finalization code for this object
			// from executing a second time.
			GC.SuppressFinalize(this);
		}

		// Dispose(bool disposing) executes in two distinct scenarios.
		// If disposing equals true, the method has been called directly
		// or indirectly by a user's code. Managed and unmanaged resources
		// can be disposed.
		// If disposing equals false, the method has been called by the 
		// runtime from inside the finalizer and you should not reference 
		// other objects. Only unmanaged resources can be disposed.
		private void Dispose(bool disposing)
		{
			// Check to see if Dispose has already been called.
			if(!this.disposed)
			{
				// If disposing equals true, dispose all managed 
				// and unmanaged resources.
				if(disposing)
				{
					// Dispose managed resources.
					// Nothing to dispose : component.Dispose();
				}
             
				// Call the appropriate methods to clean up 
				// unmanaged resources here.
				// If disposing is false, 
				// only the following code is executed.
				if ( m_Pen != null ) 
				{
					m_Pen.Dispose ();
					Marshal.ReleaseComObject( m_Pen );
					m_Pen = null;
				}
			}
			disposed = true;
		}
		#endregion
		
		#region Properties
		[System.Xml.Serialization.XmlIgnore ()]
		public Pen Pen
		{
			get { return this.m_Pen; }
			set { this.m_Pen = value; }
		}

		[System.Xml.Serialization.XmlElement ("Color")]
		public XmlColor XmlColor
		{
			get { return new XmlColor (this.Pen.Color); }
			set { if (value == null) throw new ArgumentNullException ("set_XmlColor", string.Format (CultureInfo.InvariantCulture, "Argument NULL"));
				if (this.m_Pen == null)
					this.m_Pen = new Pen (value.Color);
				else
					this.m_Pen.Color = value.Color; 
			}
		}

		[System.Xml.Serialization.XmlElement ("Width")]
		public float Width
		{
			get { return this.Pen.Width; }
			set { 
				if (this.m_Pen == null)
					this.m_Pen = new Pen (Color.WhiteSmoke, value);	// Use a default color
				else
					this.m_Pen.Width = value; 
				}
		}

		[System.Xml.Serialization.XmlElement ("Brush")]
		public XmlBrush Brush
		{
			get { return XmlBrush.AllocateXmlBrush (this.Pen.Brush);}
			set { if (value == null) throw new ArgumentNullException ("set_Brush", string.Format (CultureInfo.InvariantCulture, "Argument NULL"));
					this.Pen.Brush = value.Brush; }
		}
		#endregion
	}
}
