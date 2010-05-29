// mbba	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rdhb	
// gsme	 By downloading, copying, installing or using the software you agree to this license.
// agrc	 If you do not agree to this license, do not download, install,
// bufx	 copy or use the software.
// roam	
// vwbj	                          License Agreement
// jfhy	         For OpenVSS - Open Source Video Surveillance System
// nswl	
// hgce	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// lmhf	
// aien	Third party copyrights are property of their respective owners.
// fusr	
// stoy	Redistribution and use in source and binary forms, with or without modification,
// aoev	are permitted provided that the following conditions are met:
// cyrb	
// knqi	  * Redistribution's of source code must retain the above copyright notice,
// kguu	    this list of conditions and the following disclaimer.
// sbme	
// gulm	  * Redistribution's in binary form must reproduce the above copyright notice,
// rndp	    this list of conditions and the following disclaimer in the documentation
// nqgu	    and/or other materials provided with the distribution.
// dxks	
// bgbn	  * Neither the name of the copyright holders nor the names of its contributors 
// vgun	    may not be used to endorse or promote products derived from this software 
// rwdz	    without specific prior written permission.
// zxzr	
// hksf	This software is provided by the copyright holders and contributors "as is" and
// drep	any express or implied warranties, including, but not limited to, the implied
// ubnu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hwen	In no event shall the Prince of Songkla University or contributors be liable 
// vctl	for any direct, indirect, incidental, special, exemplary, or consequential damages
// zyiz	(including, but not limited to, procurement of substitute goods or services;
// ayuu	loss of use, data, or profits; or business interruption) however caused
// jepp	and on any theory of liability, whether in contract, strict liability,
// qoms	or tort (including negligence or otherwise) arising in any way out of
// ffoj	the use of this software, even if advised of the possibility of such damage.
// clst	
// safu	Intelligent Systems Laboratory (iSys Lab)
// rqdx	Faculty of Engineering, Prince of Songkla University, THAILAND
// eori	Project leader by Nikom SUVONVORN
// csfe	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Globalization;
using NLog; 

namespace Vs.Core
{
	/// <summary>
	/// ViewCollection class
	/// </summary>
	public class VsChannelCollection : CollectionBase
	{
        static Logger logger = LogManager.GetCurrentClassLogger(); 

		// Constructor
		public VsChannelCollection()
		{
		}

		// Get channel at the specified index
		public VsChannel this[int index]
		{
			get 
            {
                try
                {
                    return ((VsChannel)InnerList[index]);
                }
                catch (Exception err)
                {
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
                }

                return null;
            }
		}

		// Add new channel to the collection
		public void Add(VsChannel channel)
		{
            try
            {
                InnerList.Add(channel);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
		}

		// Remove channel from the collection
		public void Remove(VsChannel channel)
		{
            try
            {
                InnerList.Remove(channel);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
		}

		// Get channel with specified name
		public VsChannel GetChannel(string name)
		{
            try
            {
                // find the channel
                foreach (VsChannel channel in InnerList)
                {
                    if (channel.ChannelName == name)
                        return channel;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

			return null;
		}

        // Get channel with specified ID
        public VsChannel GetChannel(int channelID)
        {
            try
            {
                // find the channel
                foreach (VsChannel channel in InnerList)
                {
                    if (channel.ChannelID == channelID)
                        return channel;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }
	}
}
