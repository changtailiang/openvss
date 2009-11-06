using System;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using Nolme.Core;

namespace Nolme.Win32
{
	/// <summary>
	/// Summary description for Win32ListViewUtility.
	/// </summary>
	public sealed class Win32ListViewUtility
	{
		private Win32ListViewUtility() {}
		
		public static ListViewItem InsertColumns (ListView listView, int numberOfColumns)
		{
			if (listView == null)
			{
				throw new NolmeArgumentNullException ();
			}

			string			oEmptyString	= StringUtility.CreateEmptyString ();
			ListViewItem	oItem			= listView.Items.Add (oEmptyString);
			for (int i = 1; i < numberOfColumns; i++)
			{
				oItem.SubItems.Add (oEmptyString);
			}
			return oItem;
		}

		public static void AddColumns (ListViewItem listViewItem, int numberOfColumns)
		{
			if (listViewItem == null)
			{
				throw new NolmeArgumentNullException ();
			}

			string			oEmptyString	= StringUtility.CreateEmptyString ();
			for (int i = 0; i < numberOfColumns; i++)
			{
				listViewItem.SubItems.Add (oEmptyString);
			}
		}

	}
}
