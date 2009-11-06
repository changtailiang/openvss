/**************************************************************************
*
* Filename:     ShellShortcut.cs
* Author:       Mattias Sjögren (mattias@mvps.org)
*               http://www.msjogren.net/dotnet/
*
* Description:  Defines a .NET friendly class, ShellShortcut, for reading
*               and writing shortcuts.
*               Define the conditional compilation symbol UNICODE to use
*               IShellLinkW internally.
*
* Public types: class ShellShortcut
*
*
* Dependencies: ShellLinkNative.cs
*
*
* Copyright ©2001-2002, Mattias Sjögren
* 
**************************************************************************/

using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Nolme.Core;

namespace Nolme.Win32
{
	/// <remarks>
	///   .NET friendly wrapper for the ShellLink class
	/// </remarks>
	public class ShellShortcut : IDisposable
	{
		private const int INFOTIPSIZE = 1024;

#if UNICODE
		private IShellLinkW m_Link;
#else
		private IShellLinkA m_Link;
#endif
		private string m_sPath;
		
		// Track whether Dispose has been called.
		private bool disposed;

		///
		/// <param name='linkPath'>
		///   Path to new or existing shortcut file (.lnk).
		/// </param>
		///
		public ShellShortcut()
		{
			m_sPath = StringUtility.CreateEmptyString ();
		}

		// Use C# destructor syntax for finalization code.
		// This destructor will run only if the Dispose method 
		// does not get called.
		// It gives your base class the opportunity to finalize.
		// Do not provide destructors in types derived from this class.
		~ShellShortcut()      
		{
			// Do not re-create Dispose clean-up code here.
			// Calling Dispose(false) is optimal in terms of
			// readability and maintainability.
			Dispose(false);
		}
			
		public bool Init (string linkPath)
		{
			if (linkPath == null)	throw new NolmeArgumentNullException ();

			IPersistFile pf;
			bool bResult;

			m_sPath = linkPath.ToLower (CultureInfo.InvariantCulture);
			if (!m_sPath.EndsWith (".lnk"))	// Not a link file
				return false;

#if UNICODE
			m_Link = (IShellLinkW) new ShellLink();
#else
			m_Link = (IShellLinkA) new ShellLink();
#endif

			bResult =  File.Exists( linkPath );
			if (bResult) 
			{
				pf = (IPersistFile)m_Link;
				pf.Load( linkPath, 0 );
			}
			return bResult;
		}

		//
		//  IDisplosable implementation
		//
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
				if ( m_Link != null ) 
				{
					Marshal.ReleaseComObject( m_Link );
					m_Link = null;
				}
			}
			disposed = true;         
		}

		/// <value>
		///   Gets or sets the argument list of the shortcut.
		/// </value>
		public string Arguments
		{
			get
			{
				StringBuilder sb = new StringBuilder( INFOTIPSIZE );
				m_Link.GetArguments( sb, sb.Capacity );
				return sb.ToString();
			}
			set { m_Link.SetArguments( value ); }
		}

		/// <value>
		///   Gets or sets a description of the shortcut.
		/// </value>
		public string Description
		{
			get
			{
				StringBuilder sb = new StringBuilder( INFOTIPSIZE );
				m_Link.GetDescription( sb, sb.Capacity );
				return sb.ToString();
			}
			set { m_Link.SetDescription( value ); }
		}

		/// <value>
		///   Gets or sets the working directory (aka start in directory) of the shortcut.
		/// </value>
		public string WorkingDirectory
		{
			get
			{
				StringBuilder sb = new StringBuilder( DirectoryUtility.MaxPath );
				m_Link.GetWorkingDirectory( sb, sb.Capacity );
				return sb.ToString();
			}
			set { m_Link.SetWorkingDirectory( value ); }
		}

		//
		// If Path returns an empty string, the shortcut is associated with
		// a PIDL instead, which can be retrieved with IShellLink.GetIDList().
		// This is beyond the scope of this wrapper class.
		//
		/// <value>
		///   Gets or sets the target path of the shortcut.
		/// </value>
		public string Path
		{
			get
			{
#if UNICODE
				Win32FindDataWide wfd = new Win32FindDataWide();
#else
				Win32FindDataAnsi wfd = new Win32FindDataAnsi();
#endif
				StringBuilder sb = new StringBuilder( DirectoryUtility.MaxPath );

				m_Link.GetPath( sb, sb.Capacity, out wfd, ShellLinkPaths.UniversalNamingConventionPriority );
				return sb.ToString();
			}
			set { m_Link.SetPath( value ); }
		}

		/// <value>
		///   Gets or sets the path of the <see cref="Icon"/> assigned to the shortcut.
		/// </value>
		/// <summary>
		///   <seealso cref="IconIndex"/>
		/// </summary>
		public string IconPath
		{
			get
			{
				StringBuilder sb = new StringBuilder( DirectoryUtility.MaxPath );
				int nIconIdx;
				m_Link.GetIconLocation( sb, sb.Capacity, out nIconIdx );
				return sb.ToString();
			}
			set { m_Link.SetIconLocation( value, IconIndex ); }
		}

		/// <value>
		///   Gets or sets the index of the <see cref="Icon"/> assigned to the shortcut.
		///   Set to zero when the <see cref="IconPath"/> property specifies a .ICO file.
		/// </value>
		/// <summary>
		///   <seealso cref="IconPath"/>
		/// </summary>
		public int IconIndex
		{
			get
			{
				StringBuilder sb = new StringBuilder( DirectoryUtility.MaxPath );
				int nIconIdx;
				m_Link.GetIconLocation( sb, sb.Capacity, out nIconIdx );
				return nIconIdx;
			}
			set { m_Link.SetIconLocation( IconPath, value ); }
		}

		/// <value>
		///   Retrieves the Icon of the shortcut as it will appear in Explorer.
		///   Use the <see cref="IconPath"/> and <see cref="IconIndex"/>
		///   properties to change it.
		/// </value>
		public Icon Icon
		{
			get
			{
				StringBuilder sb = new StringBuilder( DirectoryUtility.MaxPath );
				int nIconIdx;
				IntPtr hIcon, hInst;
				Icon ico, clone;


				m_Link.GetIconLocation( sb, sb.Capacity, out nIconIdx );
				hInst = Marshal.GetHINSTANCE( this.GetType().Module );
				hIcon = (IntPtr)ShellApiNativeMethods.ExtractIcon( (int)hInst, sb.ToString(), nIconIdx );
				if ( hIcon == IntPtr.Zero )
					return null;

				// Return a cloned Icon, because we have to free the original ourselves.
				ico = Icon.FromHandle( hIcon );
				clone = (Icon)ico.Clone();
				ico.Dispose();
				ShellApiNativeMethods.DestroyIcon( (int)hIcon );
				return clone;
			}
		}

		/// <value>
		///   Gets or sets the System.Diagnostics.ProcessWindowStyle value
		///   that decides the initial show state of the shortcut target. Note that
		///   ProcessWindowStyle.Hidden is not a valid property value.
		/// </value>
		public ProcessWindowStyle WindowStyle
		{
			get
			{
				int nWS;
				m_Link.GetShowCommand( out nWS );

				switch ( nWS ) 
				{
					case (int)ShowWindow.ShowMinimized:
					case (int)ShowWindow.ShowMinimizedNoActive:
						return ProcessWindowStyle.Minimized;
          
					case (int)ShowWindow.ShowMaximized:
						return ProcessWindowStyle.Maximized;

					default:
						return ProcessWindowStyle.Normal;
				}
			}
			set
			{
				int nWS;

				switch ( value ) 
				{
					case ProcessWindowStyle.Normal:
						nWS = (int)ShowWindow.ShowNormal;
						break;

					case ProcessWindowStyle.Minimized:
						nWS = (int)ShowWindow.ShowMinimizedNoActive;
						break;

					case ProcessWindowStyle.Maximized:
						nWS = (int)ShowWindow.ShowMaximized;
						break;

					default: // ProcessWindowStyle.Hidden
						throw new NolmeArgumentNullException (string.Format (CultureInfo.InvariantCulture, "Unsupported ProcessWindowStyle value."));
				}

				m_Link.SetShowCommand( nWS );
      
			}
		}

		/// <value>
		///   Gets or sets the hotkey for the shortcut.
		/// </value>
		public Keys Hotkey
		{
			get
			{
				short wHotkey;
				int dwHotkey;

				m_Link.GetHotkey( out wHotkey );

				//
				// Convert from IShellLink 16-bit format to Keys enumeration 32-bit value
				// IShellLink: 0xMMVK
				// Keys:  0x00MM00VK        
				//   MM = Modifier (Alt, Control, Shift)
				//   VK = Virtual key code
				//       
				dwHotkey = ((wHotkey & 0xFF00) << 8) | (wHotkey & 0xFF);
				return (Keys) dwHotkey;
			}
			set
			{
				short wHotkey;

				if ( (value & Keys.Modifiers) == 0 )
					throw new NolmeArgumentNullException (string.Format (CultureInfo.InvariantCulture, "Hotkey must include a modifier key."));

				//    
				// Convert from Keys enumeration 32-bit value to IShellLink 16-bit format
				// IShellLink: 0xMMVK
				// Keys:  0x00MM00VK        
				//   MM = Modifier (Alt, Control, Shift)
				//   VK = Virtual key code
				//       
				wHotkey = unchecked((short) ( ((int) (value & Keys.Modifiers) >> 8) | (int) (value & Keys.KeyCode) ));
				m_Link.SetHotkey( wHotkey );

			}
		}

		/// <summary>
		///   Saves the shortcut to disk.
		/// </summary>
		public void Save()
		{
			IPersistFile pf = (IPersistFile) m_Link;
			pf.Save( m_sPath, true );
		}

		/// <summary>
		///   Returns a reference to the internal ShellLink object,
		///   which can be used to perform more advanced operations
		///   not supported by this wrapper class, by using the
		///   IShellLink interface directly.
		/// </summary>
		public object ShellLink
		{
			get { return m_Link; }
		}



	}
}
