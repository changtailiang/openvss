using System;
using System.Collections;
using System.Windows.Forms;
using Nolme.Core;

namespace Nolme.Win32
{
	/// <summary>
	/// Summary description for Win32ButtonUtility.
	/// </summary>
	public sealed class Win32ButtonUtility
	{
		private Win32ButtonUtility() {}
		
		#region Get ()
		public static int GetSelectedRadioId (Control container)
		{
			if (container == null)	throw new NolmeArgumentNullException ();

			int			i	 = 0;
			IEnumerator Iter = container.Controls.GetEnumerator ();
			while (Iter.MoveNext ())
			{
				if (((RadioButton)(Iter.Current)).Checked == true)
				{
					break;
				}
				i++;
			}
			return i;
		}

		/*
		public static int GetSelectedRadioId (GroupBox container)
		{
			if (container == null)	throw new NolmeArgumentNullException ();

			int			i	 = 0;
			IEnumerator Iter = container.Controls.GetEnumerator ();
			while (Iter.MoveNext ())
			{
				if (((RadioButton)(Iter.Current)).Checked == true)
				{
					break;
				}
				i++;
			}
			return i;
		}
		*/
		#endregion

		#region Set ()
		public static void SetSelectedRadioId (Control container, int buttonId)
		{
			if (container == null)	throw new NolmeArgumentNullException ();

			((RadioButton)(container.Controls[buttonId])).Checked = true;
		}

		/*
		public static void SetSelectedRadioId (GroupBox container, int buttonId)
		{
			if (container == null)	throw new NolmeArgumentNullException ();

			((RadioButton)(container.Controls[buttonId])).Checked = true;
		}
		*/
		#endregion
	}
}
