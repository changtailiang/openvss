// oeqn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// nqic	
// wcjm	 By downloading, copying, installing or using the software you agree to this license.
// xoqw	 If you do not agree to this license, do not download, install,
// rnpq	 copy or use the software.
// exvy	
// arte	                          License Agreement
// wjxw	         For OpenVss - Open Source Video Surveillance System
// dbdi	
// lqjv	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// oxbc	
// fafx	Third party copyrights are property of their respective owners.
// nryo	
// cblq	Redistribution and use in source and binary forms, with or without modification,
// irmw	are permitted provided that the following conditions are met:
// xegn	
// fnjw	  * Redistribution's of source code must retain the above copyright notice,
// khkb	    this list of conditions and the following disclaimer.
// etbh	
// vsta	  * Redistribution's in binary form must reproduce the above copyright notice,
// lvre	    this list of conditions and the following disclaimer in the documentation
// kitb	    and/or other materials provided with the distribution.
// pmat	
// dnyk	  * Neither the name of the copyright holders nor the names of its contributors 
// roxr	    may not be used to endorse or promote products derived from this software 
// rjmf	    without specific prior written permission.
// hxkj	
// aevp	This software is provided by the copyright holders and contributors "as is" and
// xmkb	any express or implied warranties, including, but not limited to, the implied
// nbcx	warranties of merchantability and fitness for a particular purpose are disclaimed.
// thgx	In no event shall the Prince of Songkla University or contributors be liable 
// hqxq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vrqh	(including, but not limited to, procurement of substitute goods or services;
// vbjc	loss of use, data, or profits; or business interruption) however caused
// jlxn	and on any theory of liability, whether in contract, strict liability,
// xjbk	or tort (including negligence or otherwise) arising in any way out of
// rkvr	the use of this software, even if advised of the possibility of such damage.

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
