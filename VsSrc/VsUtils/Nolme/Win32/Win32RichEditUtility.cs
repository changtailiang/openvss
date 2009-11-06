using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;	// for DllImport, MarshalAs, HandleRef, etc
using Nolme.Core;

namespace Nolme.Win32
{
	/// <summary>
	/// Summary description for Win32RichEditUtility.
	/// </summary>
	public sealed class Win32RichEditUtility
	{
		private static int updating;
		private static int oldEventMask;
    
		// Constants from the Platform SDK
		private const int EM_SETEVENTMASK			= 1073;
		private const int EM_GETPARAFORMAT			= 1085;
		private const int EM_SETPARAFORMAT			= 1095;
		private const int EM_SETTYPOGRAPHYOPTIONS	= 1226;
		private const int WM_SETREDRAW				= 11;
		private const int TO_ADVANCEDTYPOGRAPHY		= 1;
		private const int PFM_ALIGNMENT				= 8;
		private const int SCF_SELECTION				= 1;

		private Win32RichEditUtility() {}

		/// <summary>
		/// Maintains performance while updating.
		/// </summary>
		/// <remarks>
		/// <para>
		/// It is recommended to call this method before doing
		/// any major updates that you do not wish the user to
		/// see. Remember to call EndUpdate when you are finished
		/// with the update. Nested calls are supported.
		/// </para>
		/// <para>
		/// Calling this method will prevent redrawing. It will
		/// also setup the event mask of the underlying richedit
		/// control so that no events are sent.
		/// </para>
		/// </remarks>
		public static void BeginUpdate(Control sourceRichEdit)
		{
			if (sourceRichEdit == null)		throw new NolmeArgumentNullException ();

			// Deal with nested calls
			++updating;
			if ( updating > 1 )
				return;
        
			// Prevent the control from raising any events
			oldEventMask = User32ApiNativeMethods.SendMessage( new HandleRef(sourceRichEdit, sourceRichEdit.Handle), EM_SETEVENTMASK, 0, 0 );
        
			// Prevent the control from redrawing itself
			User32ApiNativeMethods.SendMessage( new HandleRef(sourceRichEdit, sourceRichEdit.Handle), WM_SETREDRAW, 0, 0 );
		}
    
		/// <summary>
		/// Resumes drawing and event handling.
		/// </summary>
		/// <remarks>
		/// This method should be called every time a call is made
		/// made to BeginUpdate. It resets the event mask to it's
		/// original value and enables redrawing of the control.
		/// </remarks>
		public static void EndUpdate(Control sourceRichEdit)
		{
			if (sourceRichEdit == null)	throw new NolmeArgumentNullException ();

			// Deal with nested calls
			--updating;
			if ( updating > 0 )
				return;
        
			// Allow the control to redraw itself
			User32ApiNativeMethods.SendMessage( new HandleRef(sourceRichEdit, sourceRichEdit.Handle), WM_SETREDRAW, 1, 0 );
        
			// Allow the control to raise event messages
			User32ApiNativeMethods.SendMessage( new HandleRef(sourceRichEdit, sourceRichEdit.Handle), EM_SETEVENTMASK, 0, oldEventMask );
		}

		
		public static void LoadText (TextBoxBase sourceRichEdit, string fileName, bool excludeEmptyLines)
		{
			if (sourceRichEdit == null)	throw new NolmeArgumentNullException ();

			sourceRichEdit.Clear ();
			
			//Win32RichEditUtility.BeginUpdate (sourceRichEdit);
			if (File.Exists (fileName))
			{
				string [] aszAllLines = FileUtility.ReadAllLines (fileName, excludeEmptyLines,true);
				string szBuffer = String.Concat (aszAllLines);
				sourceRichEdit.AppendText (szBuffer);
			}
			//Win32RichEditUtility.EndUpdate (sourceRichEdit);
		}

		public static void LoadText (TextBoxBase sourceRichEdit, ArrayList arrayList)
		{
			if (sourceRichEdit == null)	throw new NolmeArgumentNullException ();
			if (arrayList == null)		throw new NolmeArgumentNullException ();

			sourceRichEdit.Clear ();

			//Win32RichEditUtility.BeginUpdate (sourceRichEdit);
			for (int i = 0; i < arrayList.Count; i++)
			{
				sourceRichEdit.AppendText (arrayList[i].ToString ());
				sourceRichEdit.AppendText (StringUtility.CreateLinefeedString ());
				//Win32RichEditUtility.AddTextLine (sourceRichEdit, arrayList[i].ToString (), Color.Black, 8, false, false, false, false);
			}
			//Win32RichEditUtility.EndUpdate (sourceRichEdit);
		}

		public static void LoadText (TextBoxBase sourceRichEdit, string []lineArray)
		{
			if (sourceRichEdit == null)	throw new NolmeArgumentNullException ();
			if (lineArray == null)		throw new NolmeArgumentNullException ();

			sourceRichEdit.Clear ();

			for (int i = 0; i < lineArray.Length; i++)
			{
				sourceRichEdit.AppendText (lineArray[i]);
				sourceRichEdit.AppendText (StringUtility.CreateLinefeedString ());
			}
		}

		public static void LoadText (TextBoxBase sourceRichEdit, Stream stream)
		{
			if (sourceRichEdit == null)	throw new NolmeArgumentNullException ();
			if (stream == null)		throw new NolmeArgumentNullException ();

			byte []aBytes;
			sourceRichEdit.Clear ();

			aBytes = new byte [stream.Length + 1];
			stream.Read (aBytes, 0, (int)stream.Length);

			ASCIIEncoding	oObj	= new ASCIIEncoding ();
			string			szBuffer= oObj.GetString (aBytes,0,aBytes.GetLength(0));

			sourceRichEdit.AppendText (szBuffer);
		}

		public static void AddText (RichTextBox sourceRichEdit, string text, Color color, float size, bool bold, bool italic, bool strikeout, bool underline)
		{
			if (sourceRichEdit == null)	throw new NolmeArgumentNullException ();

			FontStyle	oFontStyle;
			float		fSize;

			// Set size
			if (size == -1)	fSize	= sourceRichEdit.Font.Size;
			else			fSize	= size;

			// Set italice/bold/underline...
			oFontStyle	= FontStyle.Regular;
			if (bold)			oFontStyle |= FontStyle.Bold;
			if (italic)		oFontStyle |= FontStyle.Italic;
			if (strikeout)	oFontStyle |= FontStyle.Strikeout;
			if (underline)	oFontStyle |= FontStyle.Underline;

			// Create font
			Font Police = new Font(sourceRichEdit.Font.FontFamily, fSize, oFontStyle);
			
			// Assign to richdit
			sourceRichEdit.SelectionFont		= Police;
			sourceRichEdit.SelectionColor		= color;
			sourceRichEdit.AppendText (text);
		}

		public static void AddTextLine (RichTextBox sourceRichEdit, string text, Color color, float size, bool bold, bool italic, bool strikeout, bool underline)
		{
			Win32RichEditUtility.AddText(sourceRichEdit, text + StringUtility.CreateLinefeedString (), color, size, bold, italic, strikeout, underline);
		}

		public static void AddTextLine(RichTextBox sourceRichEdit, string text, Color color)
		{
			if (sourceRichEdit == null)	throw new NolmeArgumentNullException ();

			sourceRichEdit.SelectionColor		= color;
			sourceRichEdit.AppendText (text+ StringUtility.CreateLinefeedString ());

			/*
			// Don't use AppendText which don't work with .NET 2005 Beta1
			int iOffset = sourceRichEdit.TextLength;
			sourceRichEdit.SelectionColor = color;
			//sourceRichEdit.Select ();
			sourceRichEdit.Text = sourceRichEdit.Text + text + StringUtility.CreateLineFeedString ();
			//sourceRichEdit.Select (iOffset, iOffset + text.Length + 1);
			*/
		}
	}
}
