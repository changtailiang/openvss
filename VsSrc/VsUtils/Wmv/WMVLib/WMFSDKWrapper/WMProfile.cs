#region Using directives
using System.Text;
#endregion

namespace Vs.Encoder.WmvLib.WMFSDKWrapper
{
	public class WMProfile
	{
		private IWMProfile _profile = null;
		public IWMProfile Profile
		{
			get
			{
				return _profile;
			}
		}

		public WMT_VERSION Version
		{
			get
			{
				WMT_VERSION version;
				_profile.GetVersion(out version);
				return version;
			}
		}

		public string Name
		{
			get
			{
				uint len = 0;
				StringBuilder s;
				_profile.GetName(null, ref len);
				s = new StringBuilder((int)len);
				_profile.GetName(s, ref len);
				return s.ToString();
			}
			set
			{
				_profile.SetName(value);
			}
		}

		public string Description
		{
			get
			{
				uint len = 0;
				StringBuilder s;
				_profile.GetDescription(null, ref len);
				s = new StringBuilder((int)len);
				_profile.GetName(s, ref len);
				return s.ToString();
			}
			set
			{
				_profile.SetDescription(value);
			}
		}

		public string ProfileData
		{
			get
			{
				uint len = 0;
				StringBuilder s;
				Helpers.ProfileManager.SaveProfile(_profile, null, ref len);
				s = new StringBuilder((int)len);
				Helpers.ProfileManager.SaveProfile(_profile, s, ref len);
				return s.ToString();
			}
		}

		public uint StreamCount
		{
			get
			{
				uint res;
				_profile.GetStreamCount(out res);
				return res;
			}
		}

		public WMProfile(IWMProfile profile)
		{
			_profile = profile;
		}

		public IWMStreamConfig GetStream(int index)
		{
			IWMStreamConfig res;
			_profile.GetStream((uint)index, out res);
			return res;
		}

		public IWMStreamConfig GetStreamByNumber(int number)
		{
			IWMStreamConfig res;
			_profile.GetStreamByNumber((ushort)number, out res);
			return res;
		}

		public void RemoveStream(IWMStreamConfig strconfig)
		{
			_profile.RemoveStream(strconfig);
		}

		public void RemoveStreamByNumber(int number)
		{
			_profile.RemoveStreamByNumber((ushort)number);
		}

		public void ReconfigStream(IWMStreamConfig strconfig)
		{
			_profile.ReconfigStream(strconfig);
		}
	}
}
