// gypt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// qoka	
// hymu	 By downloading, copying, installing or using the software you agree to this license.
// viwo	 If you do not agree to this license, do not download, install,
// kkql	 copy or use the software.
// yvxx	
// hxuc	                          License Agreement
// lvos	         For OpenVss - Open Source Video Surveillance System
// yxvo	
// hgdo	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// eody	
// ubga	Third party copyrights are property of their respective owners.
// cpwz	
// toll	Redistribution and use in source and binary forms, with or without modification,
// aslt	are permitted provided that the following conditions are met:
// tipm	
// jtvy	  * Redistribution's of source code must retain the above copyright notice,
// mhhe	    this list of conditions and the following disclaimer.
// gbgj	
// rzdg	  * Redistribution's in binary form must reproduce the above copyright notice,
// ruzw	    this list of conditions and the following disclaimer in the documentation
// zpzk	    and/or other materials provided with the distribution.
// lkoo	
// ukuw	  * Neither the name of the copyright holders nor the names of its contributors 
// zroa	    may not be used to endorse or promote products derived from this software 
// ginv	    without specific prior written permission.
// istr	
// hcta	This software is provided by the copyright holders and contributors "as is" and
// pfcz	any express or implied warranties, including, but not limited to, the implied
// itnu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ukmb	In no event shall the Prince of Songkla University or contributors be liable 
// tsjv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hkja	(including, but not limited to, procurement of substitute goods or services;
// lczj	loss of use, data, or profits; or business interruption) however caused
// genh	and on any theory of liability, whether in contract, strict liability,
// vhdi	or tort (including negligence or otherwise) arising in any way out of
// rnzp	the use of this software, even if advised of the possibility of such damage.

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
