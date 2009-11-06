#region Using directives

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	public struct Marker
	{
		public string Name;
		public ulong Time; // 100 nsec units

		public Marker(string name, ulong time)
		{
			this.Name = name;
			this.Time = time;
		}
	}

	public struct Script
	{
		public string Type;
		public string Command;
		public ulong Time; // 100 nsec units

		public Script(string type, string command, ulong time)
		{
			this.Type = type;
			this.Command = command;
			this.Time = time;
		}
	}

	public class WMHeaderInfo
	{
		#region Public properties

		private IWMHeaderInfo _headerInfo;
		public IWMHeaderInfo HeaderInfo
		{
			get
			{
				return _headerInfo;
			}
		}

		[IndexerName("Attributes")]
		public WM_ATTR this[int index]
		{
			get
			{
				return GetAttribute(index);
			}
		}

		[IndexerName("Attributes")]
		public WM_ATTR this[string name]
		{
			get
			{
				return GetAttribute(name);
			}
			set
			{
				SetAttribute(value);
			}
		}

		public int ScriptCount
		{
			get
			{
				ushort res;

				_headerInfo.GetScriptCount(out res);

				return res;
			}
		}

		public int MarkerCount
		{
			get
			{
				ushort res;

				_headerInfo.GetMarkerCount(out res);

				return res;
			}
		}

		#endregion

		public WMHeaderInfo(IWMHeaderInfo headerInfo)
		{
			_headerInfo = headerInfo;
		}

		public void AddMarker(Marker m)
		{
			_headerInfo.AddMarker(m.Name, m.Time);
		}

		public Marker GetMarker(int index)
		{
			ulong time;
			ushort namelen = 0;
			StringBuilder name;

			_headerInfo.GetMarker((ushort)index, null, ref namelen, out time);
			
			name = new StringBuilder(namelen);
			
			_headerInfo.GetMarker((ushort)index, name, ref namelen, out time);
			
			return new Marker(name.ToString(), time);
		}

		public void RemoveMarker(int index)
		{
			_headerInfo.RemoveMarker((ushort)index);
		}

		public void AddScript(Script s)
		{
			_headerInfo.AddScript(s.Type, s.Command, s.Time);
		}

		public Script GetScript(int index)
		{
			ushort commandlen = 0, typelen = 0;
			ulong time;
			StringBuilder command, type;

			_headerInfo.GetScript((ushort)index, null, ref typelen, null, ref commandlen, out time);
			
			command = new StringBuilder(commandlen);
			type = new StringBuilder(typelen);
			
			_headerInfo.GetScript((ushort)index, type, ref typelen, command, ref commandlen, out time);
			
			return new Script(type.ToString(), command.ToString(), time);
		}

		public void RemoveScript(int index)
		{
			_headerInfo.RemoveScript((ushort)index);
		}

		public int AttributeCount(int streamNumber)
		{
			ushort res;

			_headerInfo.GetAttributeCount((ushort)streamNumber, out res);

			return res;
		}

		public int AttributeCount()
		{
			return AttributeCount(0);
		}

		public WM_ATTR GetAttribute(int streamNumber, int index)
		{
			WMT_ATTR_DATATYPE type;
			StringBuilder name;
			object obj;
			ushort stream = (ushort)streamNumber;
			ushort namelen = 0;
			ushort datalen = 0;

			_headerInfo.GetAttributeByIndex((ushort)index, ref stream, null, ref namelen, out type, IntPtr.Zero, ref datalen);
			
			name = new StringBuilder(namelen);
			
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
					throw new InvalidOperationException(string.Format("Not supported data type: {0}", type.ToString()));
			}
			
			GCHandle h = GCHandle.Alloc(obj, GCHandleType.Pinned);
			
			try
			{
				IntPtr ptr = h.AddrOfPinnedObject();
			
				_headerInfo.GetAttributeByIndex((ushort)index, ref stream, name, ref namelen, out type, ptr, ref datalen);
				
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

		public WM_ATTR GetAttribute(int index)
		{
			return GetAttribute(0, index);
		}

		public WM_ATTR GetAttribute(int streamNumber, string name)
		{
			ushort stream = (ushort)streamNumber;
			ushort datalen = 0;
			object obj;
			WMT_ATTR_DATATYPE type;

			_headerInfo.GetAttributeByName(ref stream, name, out type, IntPtr.Zero, ref datalen);

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
					throw new InvalidOperationException(string.Format("Not supported data type: {0}", type.ToString()));
			}

			GCHandle h = GCHandle.Alloc(obj, GCHandleType.Pinned);
			
			try
			{
				IntPtr ptr = h.AddrOfPinnedObject();
			
				_headerInfo.GetAttributeByName(ref stream, name, out type, ptr, ref datalen);
				
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

		public WM_ATTR GetAttribute(string name)
		{
			return GetAttribute(0, name);
		}

		public void SetAttribute(int streamNumber, WM_ATTR attr)
		{
			object obj;
			ushort size;

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
					throw new ArgumentException("Invalid data type", "attr");
			}
			
			GCHandle h = GCHandle.Alloc(obj, GCHandleType.Pinned);

			try
			{
				_headerInfo.SetAttribute((ushort)streamNumber, attr.Name, attr.DataType, h.AddrOfPinnedObject(), size);
			}
			finally
			{
				h.Free();
			}
		}

		public void SetAttribute(WM_ATTR attr)
		{
			SetAttribute(0, attr);
		}
	}
}
