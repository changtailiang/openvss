#region Using directives

using System;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	public struct WM_ATTR
	{
		private WMT_ATTR_DATATYPE _dataType;
		private object _value;
		private string _name;

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public WMT_ATTR_DATATYPE DataType
		{
			get
			{
				return _dataType;
			}
		}

		public object Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = ConvertDataType(_dataType, value);
			}
		}

		public WM_ATTR(string name, WMT_ATTR_DATATYPE type, object val)
		{
			_name = name;
			_dataType = type;
			_value = ConvertDataType(type, val);
		}

		private static object ConvertDataType(WMT_ATTR_DATATYPE type, object val)
		{
			object value = null;

			switch (type)
			{
				case WMT_ATTR_DATATYPE.WMT_TYPE_BINARY:
					value = (byte[])val;
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_BOOL:
					value = (bool)val;
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_DWORD:
					value = (uint)val;
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_GUID:
					value = (Guid)val;
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_QWORD:
					value = (ulong)val;
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_STRING:
					value = (string)val;
					break;
				case WMT_ATTR_DATATYPE.WMT_TYPE_WORD:
					value = (ushort)val;
					break;
				default:
					throw new ArgumentException("Invalid data type.", "type");
			}

			return value;
		}

		public override string ToString()
		{
			return string.Format("{0} = {1}", _name, _value);
		}

		#region Type conversion operators

		public static explicit operator string(WM_ATTR attr)
		{
			if (attr._dataType == WMT_ATTR_DATATYPE.WMT_TYPE_STRING)
			{
				return (string)attr._value;
			}
			else
			{
				throw new InvalidCastException();
			}
		}

		public static explicit operator bool(WM_ATTR attr)
		{
			if (attr._dataType == WMT_ATTR_DATATYPE.WMT_TYPE_BOOL)
			{
				return (bool)attr._value;
			}
			else
			{
				throw new InvalidCastException();
			}
		}

		public static explicit operator Guid(WM_ATTR attr)
		{
			if (attr._dataType == WMT_ATTR_DATATYPE.WMT_TYPE_GUID)
			{
				return (Guid)attr._value;
			}
			else
			{
				throw new InvalidCastException();
			}
		}

		public static explicit operator byte[](WM_ATTR attr)
		{
			if (attr._dataType == WMT_ATTR_DATATYPE.WMT_TYPE_BINARY)
			{
				return (byte[])attr._value;
			}
			else
			{
				throw new InvalidCastException();
			}
		}

		public static explicit operator ulong(WM_ATTR attr)
		{
			switch (attr._dataType)
			{
				case WMT_ATTR_DATATYPE.WMT_TYPE_DWORD:
				case WMT_ATTR_DATATYPE.WMT_TYPE_QWORD:
				case WMT_ATTR_DATATYPE.WMT_TYPE_WORD:
					return (ulong)attr._value;
				default:
					throw new InvalidCastException();
			}
		}

		public static explicit operator long(WM_ATTR attr)
		{
			return (long)(ulong)attr;
		}

		public static explicit operator int(WM_ATTR attr)
		{
			return (int)(ulong)attr;
		}

		public static explicit operator uint(WM_ATTR attr)
		{
			return (uint)(ulong)attr;
		}

		public static explicit operator ushort(WM_ATTR attr)
		{
			return (ushort)(ulong)attr;
		}

		#endregion
	}
}
