//#define DEBUG_CODECINFO

#region Using directives

using System;
using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	public class WMCodecInfo
	{
		#region Public properties

        private Guid _mediaType = Guid.Empty;

		private IWMCodecInfo3 _codecInfo = null;
		public IWMCodecInfo3 CodecInfo
		{
			get
			{
				return _codecInfo;
			}
		}

		public int CodecInfoCount
		{
			get
			{
				uint res;

                _codecInfo.GetCodecInfoCount(ref _mediaType, out res);

				return (int)res;
			}
		}
        
        #endregion

        public WMCodecInfo(Guid mediaType, IWMCodecInfo3 codecInfo)
		{
            _mediaType = mediaType;
			_codecInfo = codecInfo;
		}

        public string GetCodecName(int index)
        {
        	StringBuilder name;
            uint namelen = 0;

            _codecInfo.GetCodecName(ref _mediaType, (uint)index, null, ref namelen);
            
            name = new StringBuilder((int)namelen);

            _codecInfo.GetCodecName(ref _mediaType, (uint)index, name, ref namelen);

            return name.ToString();
        }

        public WM_ATTR GetCodecEnumerationSetting(int index, string name)
		{
			WMT_ATTR_DATATYPE type;
			object obj;
			uint datalen = 0;

#if DEBUG && DEBUG_CODECINFO
			Logger.WriteLogMessage("Get property[" + index + "], name [" + name + "].");
#endif

			_codecInfo.GetCodecEnumerationSetting(ref _mediaType, (uint)index, name, out type, IntPtr.Zero, ref datalen);
						
			switch (type)
			{
				case WMT_ATTR_DATATYPE.WMT_TYPE_BOOL:
				case WMT_ATTR_DATATYPE.WMT_TYPE_DWORD:
					obj = (uint)0;
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_GUID:
					obj = Guid.NewGuid();
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_QWORD:
					obj = (ulong)0;
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_WORD:
					obj = (ushort)0;
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_STRING:
				case WMT_ATTR_DATATYPE.WMT_TYPE_BINARY:
					obj = new byte[datalen];
					break;
				default:
					throw new InvalidOperationException(String.Format("Not supported data type: {0}.", type.ToString()));
			}
			
        	GCHandle h = GCHandle.Alloc(obj, GCHandleType.Pinned);
			
			try
			{
				IntPtr ptr = h.AddrOfPinnedObject();

                _codecInfo.GetCodecEnumerationSetting(ref _mediaType, (uint)index, name, out type, ptr, ref datalen);
				
				switch (type)
				{
					case WMT_ATTR_DATATYPE.WMT_TYPE_STRING:
						obj = Marshal.PtrToStringUni(ptr);
						break;
					case WMT_ATTR_DATATYPE.WMT_TYPE_BOOL:
						obj = ((uint)obj != 0);
						break;
				}
			}
			finally
			{
				h.Free();
			}

			return new WM_ATTR(name, type, obj);
		}
	}
}

