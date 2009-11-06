using System;

namespace Nolme.Win32
{
	/// <summary>
	/// Summary description for Win32ConsoleUtility.
	/// </summary>
	public sealed class Win32ConsoleUtility
	{
		private Win32ConsoleUtility() {}
		
		public static IntPtr	ConsoleWindow
		{
			get 
			{
				IntPtr hWnd = (IntPtr)ApiNativeMethods.GetConsoleWindow ();
				return hWnd;
			}
		}

		public static bool	HideConsole ()
		{
			bool bResult = User32ApiNativeMethods.ShowWindow ((int)Win32ConsoleUtility.ConsoleWindow, (int)ShowWindow.Hide);
			return bResult;
		}

		public static bool	ShowConsole ()
		{
			bool bResult = User32ApiNativeMethods.ShowWindow ((int)Win32ConsoleUtility.ConsoleWindow, (int)ShowWindow.Show);
			return bResult;
		}
	}
}
