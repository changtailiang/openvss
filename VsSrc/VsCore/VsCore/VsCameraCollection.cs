// lqsz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// iwmx	
// ejyh	 By downloading, copying, installing or using the software you agree to this license.
// pare	 If you do not agree to this license, do not download, install,
// vszj	 copy or use the software.
// xfup	
// lnkd	                          License Agreement
// djzo	         For OpenVss - Open Source Video Surveillance System
// exwe	
// qbil	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// vwbd	
// ptqm	Third party copyrights are property of their respective owners.
// jyyy	
// rzzg	Redistribution and use in source and binary forms, with or without modification,
// vcnu	are permitted provided that the following conditions are met:
// mjtv	
// kkdr	  * Redistribution's of source code must retain the above copyright notice,
// dnnu	    this list of conditions and the following disclaimer.
// joob	
// eqzs	  * Redistribution's in binary form must reproduce the above copyright notice,
// xxte	    this list of conditions and the following disclaimer in the documentation
// kaxe	    and/or other materials provided with the distribution.
// yqin	
// onzl	  * Neither the name of the copyright holders nor the names of its contributors 
// cfsf	    may not be used to endorse or promote products derived from this software 
// pyjw	    without specific prior written permission.
// kepc	
// lxcf	This software is provided by the copyright holders and contributors "as is" and
// cvxo	any express or implied warranties, including, but not limited to, the implied
// qpkk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// nztn	In no event shall the Prince of Songkla University or contributors be liable 
// fzfv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pczy	(including, but not limited to, procurement of substitute goods or services;
// xucy	loss of use, data, or profits; or business interruption) however caused
// owtg	and on any theory of liability, whether in contract, strict liability,
// kusa	or tort (including negligence or otherwise) arising in any way out of
// nclt	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Globalization;
using NLog; 

namespace Vs.Core
{
	/// <summary>
	/// VsCameraCollection class
	/// </summary>
	public class VsCameraCollection : CollectionBase
	{
        static Logger logger = LogManager.GetCurrentClassLogger(); 

		// Constructor
		public VsCameraCollection()
		{
		}

		// Get came at the specified index
		public VsCamera this[int index]
		{
			get 
            { 
                try
                {
                    return ((VsCamera) InnerList[index]);
                }
                catch (Exception err)
                {
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
                }
                return null;
            }
		}

		// Add new camera to the collection
		public void Add(VsCamera camera)
		{
            try
            {
                InnerList.Add(camera);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
		}

		// Remove camera from the collection
		public void Remove(VsCamera camera)
		{
            try
            {
                InnerList.Remove(camera);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
		}

		// Get camera with specified name
		public VsCamera GetCameraByName(string name)
		{
            try
            {
                // find the camera
                foreach (VsCamera camera in InnerList)
                {
                    if (camera.CameraName == name)
                        return camera;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

			return null;
		}

		// Get camera with specified ID
		public VsCamera GetCameraByID(int cameraID)
		{
            try
            {
                // find the camera
                foreach (VsCamera camera in InnerList)
                {
                    if (camera.CameraID == cameraID)
                        return camera;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

			return null;
		}

        // Get camera with ip number
        public VsCamera GetCameraByIP(string ip)
        {
            try
            {
                // find the camera
                foreach (VsCamera camera in InnerList)
                {
                    if (camera.CameraIP == ip)
                        return camera;
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
