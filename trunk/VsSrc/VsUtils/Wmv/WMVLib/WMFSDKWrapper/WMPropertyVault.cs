#region Using directives

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Vs.Encoder.WmvLib.WMFSDKWrapper;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	public class WMPropertyVault
	{
		#region Public properties

		private IWMPropertyVault _propertyVault = null;
		public IWMPropertyVault PropertyVault
		{
			get
			{
				return _propertyVault;
			}
		}

		[IndexerName("Properties")]
		public WM_ATTR this[int index]
		{
			get
			{
				return GetProperty(index);
			}
		}

		[IndexerName("Properties")]
		public WM_ATTR this[string name]
		{
			get
			{
				return GetProperty(name);
			}
			set
			{
				SetProperty(value);
			}
		}

		public int PropertyCount
		{
			get
			{
				uint res;

				_propertyVault.GetPropertyCount(out res);

				return (int)res;
			}
		}

		#endregion

		public WMPropertyVault(IWMPropertyVault propertyVault)
		{
			_propertyVault = propertyVault;
		}

		public WM_ATTR GetProperty(int index)
		{
			WMT_ATTR_DATATYPE type;
			StringBuilder name;
			object obj;
			uint namelen = 0;
			uint datalen = 0;

			Logger.WriteLogMessage("Get property[" + index + "].");

			_propertyVault.GetPropertyByIndex((uint)index, null, ref namelen, out type, IntPtr.Zero, ref datalen);
			
			name = new StringBuilder((int)namelen);
			
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
			
				_propertyVault.GetPropertyByIndex((uint)index, name, ref namelen, out type, ptr, ref datalen);
				
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

			return new WM_ATTR(name.ToString(), type, obj);
		}

		public WM_ATTR GetProperty(string name)
		{
			uint datalen = 0;
			object obj;
			WMT_ATTR_DATATYPE type;

			Logger.WriteLogMessage("Get property[" + name + "].");
			
			_propertyVault.GetPropertyByName(name, out type, IntPtr.Zero, ref datalen);

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
			
				_propertyVault.GetPropertyByName(name, out type, ptr, ref datalen);
				
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

		public void SetProperty(WM_ATTR attr)
		{
			object obj;
			uint size;

			Logger.WriteLogMessage("Set property[" + attr.Name + "].");

			switch (attr.DataType)
			{
				case WMT_ATTR_DATATYPE.WMT_TYPE_STRING:
					byte[] arr = Encoding.Unicode.GetBytes((string)attr.Value + (char)0);
					obj = arr;
					size = (ushort)arr.Length;
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_BOOL:
					obj = (uint)((bool)attr ? 1 : 0);
					size = 4;
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_BINARY:
					obj = (byte[])attr.Value;
					size = (ushort)((byte[])obj).Length;
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_DWORD:
					obj = (uint)attr;
					size = 4;
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_QWORD:
					obj = (ulong)attr;
					size = 8;
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_WORD:
					obj = (ushort)attr;
					size = 2;
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_GUID:
					obj = (Guid)attr;
					size = (ushort)Marshal.SizeOf(typeof(Guid));
					break;
				default:
					throw new ArgumentException("Invalid data type.", "attr");
			}
			
			GCHandle h = GCHandle.Alloc(obj, GCHandleType.Pinned);

			try
			{
				_propertyVault.SetProperty(attr.Name, attr.DataType, h.AddrOfPinnedObject(), size);
			}
			finally
			{
				h.Free();
			}
		}
	}
}
