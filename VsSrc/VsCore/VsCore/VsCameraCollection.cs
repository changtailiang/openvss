// jlwb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tmka	
// cgqf	 By downloading, copying, installing or using the software you agree to this license.
// qkst	 If you do not agree to this license, do not download, install,
// uvhm	 copy or use the software.
// txly	
// cgvk	                          License Agreement
// fikd	         For OpenVSS - Open Source Video Surveillance System
// mijj	
// hluy	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// nosx	
// ggwl	Third party copyrights are property of their respective owners.
// mcdd	
// vetm	Redistribution and use in source and binary forms, with or without modification,
// ayyn	are permitted provided that the following conditions are met:
// rzvt	
// vmti	  * Redistribution's of source code must retain the above copyright notice,
// bjli	    this list of conditions and the following disclaimer.
// bjye	
// forw	  * Redistribution's in binary form must reproduce the above copyright notice,
// jkyc	    this list of conditions and the following disclaimer in the documentation
// fhih	    and/or other materials provided with the distribution.
// oxij	
// mhho	  * Neither the name of the copyright holders nor the names of its contributors 
// tybt	    may not be used to endorse or promote products derived from this software 
// mokc	    without specific prior written permission.
// qvcm	
// gogl	This software is provided by the copyright holders and contributors "as is" and
// gcdg	any express or implied warranties, including, but not limited to, the implied
// asoo	warranties of merchantability and fitness for a particular purpose are disclaimed.
// emtd	In no event shall the Prince of Songkla University or contributors be liable 
// acvu	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bklh	(including, but not limited to, procurement of substitute goods or services;
// nxjv	loss of use, data, or profits; or business interruption) however caused
// awmj	and on any theory of liability, whether in contract, strict liability,
// ewba	or tort (including negligence or otherwise) arising in any way out of
// qxck	the use of this software, even if advised of the possibility of such damage.
// dana	
// jmpz	Intelligent Systems Laboratory (iSys Lab)
// ugbo	Faculty of Engineering, Prince of Songkla University, THAILAND
// zikv	Project leader by Nikom SUVONVORN
// czyi	Project website at http://code.google.com/p/openvss/

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
