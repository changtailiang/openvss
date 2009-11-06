#region Using directives

using System;
using System.Text;
using Vs.Encoder.WmvLib.WMFSDKWrapper;

#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	public class WMStreamConfig
	{
		private IWMStreamConfig _streamConfig = null;
		public IWMStreamConfig StreamConfig
		{
			get
			{
				return _streamConfig;
			}
		}

		public uint Bitrate
		{
			get
			{
				uint res;
				_streamConfig.GetBitrate(out res);
				return res;
			}
			set
			{
				_streamConfig.SetBitrate(value);
			}
		}

		public uint BufferWindow
		{
			get
			{
				uint res;
				_streamConfig.GetBufferWindow(out res);
				return res;
			}
			set
			{
				_streamConfig.SetBufferWindow(value);
			}
		}

		public string ConnectionName
		{
			get
			{
				StringBuilder name;
				ushort namelen = 0;
				_streamConfig.GetConnectionName(null, ref namelen);
				name = new StringBuilder(namelen);
				_streamConfig.GetConnectionName(name, ref namelen);
				return name.ToString();
			}
			set
			{
				_streamConfig.SetConnectionName(value);
			}
		}

		public string StreamName
		{
			get
			{
				StringBuilder name;
				ushort namelen = 0;
				_streamConfig.GetStreamName(null, ref namelen);
				name = new StringBuilder(namelen);
				_streamConfig.GetStreamName(name, ref namelen);
				return name.ToString();
			}
			set
			{
				_streamConfig.SetStreamName(value);
			}
		}

		public ushort StreamNumber
		{
			get
			{
				ushort res;
				_streamConfig.GetStreamNumber(out res);
				return res;
			}
			set
			{
				_streamConfig.SetStreamNumber(value);
			}
		}

		public Guid StreamType
		{
			get
			{
				Guid res;
				_streamConfig.GetStreamType(out res);
				return res;
			}
		}

		public WMStreamConfig(IWMStreamConfig config)
		{
			_streamConfig = config;
		}
	}
}
