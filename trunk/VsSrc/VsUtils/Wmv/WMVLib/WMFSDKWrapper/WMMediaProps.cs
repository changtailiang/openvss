#region Using directives

using System;
using System.Runtime.InteropServices;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	public class WMMediaProps
	{
		private IWMMediaProps _mediaProps = null;
		public IWMMediaProps MediaProps
		{
			get
			{
				return _mediaProps;
			}
		}

		public WM_MEDIA_TYPE MediaType
		{
			get
			{
				uint cbType = 0;
				WM_MEDIA_TYPE mediaType;

				_mediaProps.GetMediaType(IntPtr.Zero, ref cbType);

				IntPtr buffer = Marshal.AllocCoTaskMem((int)cbType);

				try
				{
					_mediaProps.GetMediaType(buffer, ref cbType);

					mediaType = (WM_MEDIA_TYPE)Marshal.PtrToStructure(buffer, typeof(WM_MEDIA_TYPE));
				}
				finally
				{
					Marshal.FreeCoTaskMem(buffer);
				}

				return mediaType;
			}
			set
			{
				_mediaProps.SetMediaType(ref value);
			}
		}

		public WMMediaProps(IWMMediaProps mediaProps)
		{
			_mediaProps = mediaProps;
		}
	}
}
