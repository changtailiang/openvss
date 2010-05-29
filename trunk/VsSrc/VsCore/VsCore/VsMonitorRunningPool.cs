// hmxi	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// oirs	
// ajvx	 By downloading, copying, installing or using the software you agree to this license.
// owoc	 If you do not agree to this license, do not download, install,
// bsmd	 copy or use the software.
// lysz	
// vhsi	                          License Agreement
// ozyl	         For OpenVSS - Open Source Video Surveillance System
// wayy	
// scgb	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// tqeo	
// gzmj	Third party copyrights are property of their respective owners.
// ncmw	
// tyoi	Redistribution and use in source and binary forms, with or without modification,
// uxng	are permitted provided that the following conditions are met:
// qjda	
// kjao	  * Redistribution's of source code must retain the above copyright notice,
// xpky	    this list of conditions and the following disclaimer.
// lkjv	
// tdsw	  * Redistribution's in binary form must reproduce the above copyright notice,
// vjul	    this list of conditions and the following disclaimer in the documentation
// nbsy	    and/or other materials provided with the distribution.
// lpev	
// pzlk	  * Neither the name of the copyright holders nor the names of its contributors 
// ndew	    may not be used to endorse or promote products derived from this software 
// yyly	    without specific prior written permission.
// snlj	
// otoq	This software is provided by the copyright holders and contributors "as is" and
// eqlh	any express or implied warranties, including, but not limited to, the implied
// ornj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rcch	In no event shall the Prince of Songkla University or contributors be liable 
// lpjl	for any direct, indirect, incidental, special, exemplary, or consequential damages
// yzhq	(including, but not limited to, procurement of substitute goods or services;
// zwyw	loss of use, data, or profits; or business interruption) however caused
// xwtz	and on any theory of liability, whether in contract, strict liability,
// pijs	or tort (including negligence or otherwise) arising in any way out of
// bnqy	the use of this software, even if advised of the possibility of such damage.
// oevv	
// puev	Intelligent Systems Laboratory (iSys Lab)
// vemd	Faculty of Engineering, Prince of Songkla University, THAILAND
// ezko	Project leader by Nikom SUVONVORN
// lyri	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Globalization;
using NLog; 

namespace Vs.Core
{
	/// <summary>
	/// VsMonitorRunningPool
	/// </summary>
	public class VsMonitorRunningPool : CollectionBase
	{
        static Logger logger = LogManager.GetCurrentClassLogger(); 

		// Configuration
		public VsMonitorRunningPool()
		{
		}

		// Get group at the specified index
		public VsCamera this[int index]
		{
			get
			{
                try
                {
                    return ((VsCamera)InnerList[index]);
                }
                catch (Exception err)
                {
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
                }
                return null;
			}
		}

		// Add new camera to the collection and run it
		public bool Add(VsCamera camera)
		{
            try
            {
                // create video
                if (camera.CreateVideoSource())
                {
                    // add to the pool
                    InnerList.Add(camera);

                    // crate analyzer source
                    camera.CreateAnalyserSource();

                    // create encoder source
                    camera.CreateEncoderSource();

                    // start camera
                    camera.Start();

                    return true;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
			return false;
		}

		// Remove camera from the collection and signal to stop it
		public void Remove(VsCamera camera)
		{
            try
            {
                InnerList.Remove(camera);

                // signal to stop
                camera.SignalToStop();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
		}
	}
}
