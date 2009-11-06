// avur	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tdqy	
// sags	 By downloading, copying, installing or using the software you agree to this license.
// nyju	 If you do not agree to this license, do not download, install,
// xfyk	 copy or use the software.
// yvvk	
// tkzu	                          License Agreement
// ccyw	         For OpenVss - Open Source Video Surveillance System
// mpfv	
// kmwj	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// omqg	
// ypkb	Third party copyrights are property of their respective owners.
// cmqk	
// rfae	Redistribution and use in source and binary forms, with or without modification,
// zkxi	are permitted provided that the following conditions are met:
// ewvq	
// cjgx	  * Redistribution's of source code must retain the above copyright notice,
// snkl	    this list of conditions and the following disclaimer.
// jovl	
// eple	  * Redistribution's in binary form must reproduce the above copyright notice,
// axsp	    this list of conditions and the following disclaimer in the documentation
// lofg	    and/or other materials provided with the distribution.
// pawa	
// onfs	  * Neither the name of the copyright holders nor the names of its contributors 
// radp	    may not be used to endorse or promote products derived from this software 
// jmio	    without specific prior written permission.
// cfbd	
// jozk	This software is provided by the copyright holders and contributors "as is" and
// ztig	any express or implied warranties, including, but not limited to, the implied
// dgeo	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ezis	In no event shall the Prince of Songkla University or contributors be liable 
// rjwv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jdue	(including, but not limited to, procurement of substitute goods or services;
// lvvo	loss of use, data, or profits; or business interruption) however caused
// odmf	and on any theory of liability, whether in contract, strict liability,
// mbwa	or tort (including negligence or otherwise) arising in any way out of
// ambv	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Diagnostics;
using System.Management;
using System.Globalization;
using NLog; 

namespace Vs.Core.SystemInfo
{
	/// <summary>
	/// Summary description for SystemData.
	/// </summary>
	public class VsSystemData
	{
        static Logger logger = LogManager.GetCurrentClassLogger();

		#region "Constructor"
		public VsSystemData()
		{
            try
            {
                PerformanceCounterCategory cat = new PerformanceCounterCategory("Network Interface");
                _instanceNames = cat.GetInstanceNames();

                _netRecvCounters = new PerformanceCounter[_instanceNames.Length];
                for (int i = 0; i < _instanceNames.Length; i++)
                    _netRecvCounters[i] = new PerformanceCounter();

                _netSentCounters = new PerformanceCounter[_instanceNames.Length];
                for (int i = 0; i < _instanceNames.Length; i++)
                    _netSentCounters[i] = new PerformanceCounter();

                _compactFormat = false;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }
		#endregion

		#region "Properties"
		public bool CompactFormat
		{
			get { return _compactFormat; }
			set { _compactFormat = value; }
		}
		#endregion

		#region "Public Methods"
		public string GetProcessorData()
		{
			double d = GetCounterValue(_cpuCounter, "Processor", "% Processor Time", "_Total");
			return _compactFormat? (int)d +"%": d.ToString("F") +"%";
		}

		public string GetMemoryVData()
		{
			string str;
			double d = GetCounterValue(_memoryCounter, "Memory", "% Committed Bytes In Use", null);
			str = d.ToString("F") +"% (";

			d = GetCounterValue(_memoryCounter, "Memory", "Committed Bytes", null);
			str += FormatBytes(d) +" / ";

			d = GetCounterValue(_memoryCounter, "Memory", "Commit Limit", null);
			return str +FormatBytes(d) +") ";	
		}

		public string GetMemoryPData()
		{
			string s = QueryComputerSystem("totalphysicalmemory");
			double totalphysicalmemory = Convert.ToDouble(s);

			double d = GetCounterValue(_memoryCounter, "Memory", "Available Bytes", null);
			d = totalphysicalmemory - d;

			s = _compactFormat? "%": "% (" + FormatBytes(d) +" / " +FormatBytes(totalphysicalmemory) +")";
			d /= totalphysicalmemory;
			d *= 100;
			return _compactFormat? (int)d +s: d.ToString("F") + s;
		}

		public enum DiskData {ReadAndWrite, Read, Write};

		public double GetDiskData(DiskData dd)
		{
			return	dd==DiskData.Read? 
						GetCounterValue(_diskReadCounter, "PhysicalDisk", "Disk Read Bytes/sec", "_Total"):
					dd==DiskData.Write? 
						GetCounterValue(_diskWriteCounter, "PhysicalDisk", "Disk Write Bytes/sec", "_Total"):
					dd==DiskData.ReadAndWrite? 
						GetCounterValue(_diskReadCounter, "PhysicalDisk", "Disk Read Bytes/sec", "_Total")+
						GetCounterValue(_diskWriteCounter, "PhysicalDisk", "Disk Write Bytes/sec", "_Total"):
					0;
		}

		public enum NetData {ReceivedAndSent, Received, Sent};

		public double GetNetData(NetData nd)
		{
			if (_instanceNames.Length==0) 
				return 0;

			double d =0;
			for (int i=0; i<_instanceNames.Length; i++)
			{
				d += nd==NetData.Received? 
						GetCounterValue(_netRecvCounters[i], "Network Interface", "Bytes Received/sec", _instanceNames[i]):
					nd==NetData.Sent? 
						GetCounterValue(_netSentCounters[i], "Network Interface", "Bytes Sent/sec", _instanceNames[i]):
					nd==NetData.ReceivedAndSent? 
						GetCounterValue(_netRecvCounters[i], "Network Interface", "Bytes Received/sec", _instanceNames[i]) +
						GetCounterValue(_netSentCounters[i], "Network Interface", "Bytes Sent/sec", _instanceNames[i]):
					0;
			}

			return d;
		}

		enum Unit {B, KB, MB, GB, ER}
		public string FormatBytes(double bytes)
		{
			int unit = 0;
			while (bytes>1024) 
			{
				bytes /= 1024;
				++unit;
			}

			string s = _compactFormat? ((int)bytes).ToString(): bytes.ToString("F") +" ";
			return s +((Unit)unit).ToString();
		}

		public string QueryComputerSystem(string type)
		{
			string str = null;
			ManagementObjectSearcher objCS = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
			foreach ( ManagementObject objMgmt in objCS.Get() )
			{
				str = objMgmt[type].ToString();
			}
			return str;
		}

		public string QueryEnvironment(string type)
		{
			return Environment.ExpandEnvironmentVariables(type);
		}

		public string LogicalDisk()
		{
			string diskSpace = string.Empty;
			object device, space;
			ManagementObjectSearcher objCS = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk");
			foreach ( ManagementObject objMgmt in objCS.Get() )
			{
				device = objMgmt["DeviceID"];		// C:
				if (null !=device)
				{
					space = objMgmt["FreeSpace"];	// C:10.32 GB, D:5.87GB
					if (null!=space)
						diskSpace += device.ToString() +FormatBytes(double.Parse(space.ToString())) +", ";
				}
			}

			diskSpace =  diskSpace.Substring(0, diskSpace.Length-2);
			return diskSpace;
		}

		#endregion

		#region "Private Helpers"
		double GetCounterValue(PerformanceCounter pc, string categoryName, string counterName, string instanceName)
		{
			pc.CategoryName = categoryName;
			pc.CounterName = counterName;
			pc.InstanceName = instanceName;
			return pc.NextValue();	
		}

		#endregion

		#region "Members"
		bool _compactFormat;

		PerformanceCounter _memoryCounter = new PerformanceCounter();	
		PerformanceCounter _cpuCounter = new PerformanceCounter();	
		PerformanceCounter _diskReadCounter = new PerformanceCounter();	
		PerformanceCounter _diskWriteCounter = new PerformanceCounter();	

		string[] _instanceNames;
		PerformanceCounter[] _netRecvCounters;	
		PerformanceCounter[] _netSentCounters;	

		#endregion
	}

	public delegate void OnLogicalDiskProc(string s);
}
		

