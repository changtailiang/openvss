#region Using directives

using System;
using System.Runtime.InteropServices;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	public class NSSBuffer
	{
		private INSSBuffer _buffer;
		public INSSBuffer Buffer
		{
			get
			{
				return _buffer;
			}
		}

		private uint _maxLength;
		private IntPtr _bufferPtr;

		private uint _length;
		public uint Length
		{
			get
			{
				return _length;
			}
			set
			{
				if (value <= _maxLength)
				{
					_buffer.SetLength(value);
					_length = value;

					if (_position > _length)
						_position = _length;
				}
				else
				{
					throw new ArgumentOutOfRangeException("Length", value, "Invalid uint parameter.");
				}
			}
		}

		private uint _position = 0;
		public uint Position
		{
			get
			{
				return _position;
			}
			set
			{
				if (value <= _length)
				{
					_position = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("Position", value, "Invalid uint parameter.");
				}
			}
		}
		
		public NSSBuffer(INSSBuffer buff)
		{
			if (buff == null)
				throw new ArgumentNullException("buff", "Invalid INSSBuffer parameter.");

			_buffer = buff;

			_buffer.GetBufferAndLength(out _bufferPtr, out _length);
			_buffer.GetMaxLength(out _maxLength);
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
				throw new ArgumentNullException("buffer", "Invalid byte[] parameter.");

			if (_position >= _length)
				return 0;
				
			IntPtr src = (IntPtr)(_bufferPtr.ToInt32() + _position);
			int toCopy = Math.Min(count, (int)(this.Length - this.Position));
			
			Marshal.Copy(src, buffer, offset, toCopy);
			
			_position += (uint)toCopy;
			
			return toCopy;
		}

		public void Write(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
				throw new ArgumentNullException("buffer", "Invalid byte[] parameter.");
			
			if (offset < 0)
				throw new ArgumentOutOfRangeException("offset", offset, "Invalid int parameter.");

			if ((count <= 0) || ((_position + count) > _length))
				throw new ArgumentOutOfRangeException("count", count, "Invalid int parameter.");

			IntPtr dest = (IntPtr)(_bufferPtr.ToInt32() + _position);
			
			Marshal.Copy(buffer, offset, dest, count);
			
			_position += (uint)count;
		}
	}

	internal class ManBuffer : INSSBuffer
	{
		#region Private fields

		private uint _usedLength;
		private uint _maxLength;
		private byte[] _buffer = null;
		private GCHandle handle;

		#endregion

		public uint UsedLength
		{
			get
			{
				return _usedLength;
			}
			set
			{
				if (value > _maxLength)
					throw new ArgumentException("Invalid uint parameter.", "UsedLength");

				_usedLength = value;
			}
		}

		public uint MaxLength
		{
			get
			{
				return _maxLength;
			}
		}

		public byte[] Buffer
		{
			get
			{
				return _buffer;
			}
		}

		public ManBuffer(uint size)
		{
			_buffer = new byte[size];
			_maxLength = _usedLength = size;

			handle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
		}

		~ManBuffer()
		{
			handle.Free();
		}

		#region INSSBuffer Members

		public void GetLength(out uint pdwLength)
		{
			pdwLength = _usedLength;
		}

		public void SetLength(uint dwLength)
		{
			UsedLength = dwLength;
		}

		public void GetMaxLength(out uint pdwLength)
		{
			pdwLength = _maxLength;
		}

		public void GetBuffer(out IntPtr ppdwBuffer)
		{
			ppdwBuffer = handle.AddrOfPinnedObject();
		}

		public void GetBufferAndLength(out IntPtr ppdwBuffer, out uint pdwLength)
		{
			ppdwBuffer = handle.AddrOfPinnedObject();
			pdwLength = _usedLength;
		}

		#endregion
	}
}
