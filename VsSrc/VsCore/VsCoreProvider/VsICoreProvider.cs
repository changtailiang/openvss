// qxal	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ewnb	
// zgda	 By downloading, copying, installing or using the software you agree to this license.
// fvdm	 If you do not agree to this license, do not download, install,
// cxfs	 copy or use the software.
// btsi	
// vhon	                          License Agreement
// nowp	         For OpenVSS - Open Source Video Surveillance System
// jfwg	
// yfea	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// bmll	
// grev	Third party copyrights are property of their respective owners.
// ehys	
// zppx	Redistribution and use in source and binary forms, with or without modification,
// frqx	are permitted provided that the following conditions are met:
// iaok	
// jnqa	  * Redistribution's of source code must retain the above copyright notice,
// yxow	    this list of conditions and the following disclaimer.
// sfrp	
// igcd	  * Redistribution's in binary form must reproduce the above copyright notice,
// dtif	    this list of conditions and the following disclaimer in the documentation
// peqt	    and/or other materials provided with the distribution.
// pzag	
// phsb	  * Neither the name of the copyright holders nor the names of its contributors 
// xbbs	    may not be used to endorse or promote products derived from this software 
// aewh	    without specific prior written permission.
// tczu	
// yapy	This software is provided by the copyright holders and contributors "as is" and
// pmtp	any express or implied warranties, including, but not limited to, the implied
// rjuf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wxkz	In no event shall the Prince of Songkla University or contributors be liable 
// whhl	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mqrg	(including, but not limited to, procurement of substitute goods or services;
// fjdz	loss of use, data, or profits; or business interruption) however caused
// wbmn	and on any theory of liability, whether in contract, strict liability,
// ewvp	or tort (including negligence or otherwise) arising in any way out of
// kcqc	the use of this software, even if advised of the possibility of such damage.
// ndjo	
// gwvd	Intelligent Systems Laboratory (iSys Lab)
// txkl	Faculty of Engineering, Prince of Songkla University, THAILAND
// vohi	Project leader by Nikom SUVONVORN
// iitf	Project website at http://code.google.com/p/openvss/

namespace Vs.Core.Provider
{
	using System;
    using Vs.Core.Image;

	/// <summary>
	/// IVideoSource interface
	/// </summary>
	public interface VsICoreProvider
	{
		/// <summary>
		/// New frame event - notify client about the new frame
		/// </summary>
		event VsImageEventHandler FrameOut;

		/// <summary>
		/// Video source property
		/// </summary>
		string VideoSource{get; set;}

        /// <summary>
        /// Video source property
        /// </summary>
        //string CameraSource { get; set;}

		/// <summary>
		/// Login property
		/// </summary>
		string Login{get; set;}

		/// <summary>
		/// Password property
		/// </summary>
		string Password{get; set;}

		/// <summary>
		/// FramesReceived property
		/// get number of frames the video source received from the last
		/// access to the property
		/// </summary>
		int FramesReceived{get;}

		/// <summary>
		/// BytesReceived property
		/// get number of bytes the video source received from the last
		/// access to the property
		/// </summary>
		int BytesReceived{get;}

		/// <summary>
		/// UserData property
		/// allows to associate user data with an object
		/// </summary>
		object UserData{get; set;}

		/// <summary>
		/// Get state of video source
		/// </summary>
		bool Running{get;}

		/// <summary>
		/// Start receiving video frames
		/// </summary>
		void Start();

		/// <summary>
		/// Stop receiving video frames
		/// </summary>
		void SignalToStop();

		/// <summary>
		/// Wait for stop
		/// </summary>
		void WaitForStop();

		/// <summary>
		/// Stop work
		/// </summary>
		void Stop();

        /// <summary>
        /// test if the current camera is a PTZ
        /// </summary>
        /// <returns></returns>
        bool IsPanTiltZoom();

        /// <summary>
        /// 
        /// </summary>
        void GoHome();

        /// <summary>
        /// Pan Left
        /// </summary>
        void PanLeft();

        /// <summary>
        /// Pan Right
        /// </summary>
        void PanRight();

        /// <summary>
        /// Tilt Up
        /// </summary>
        void TiltUp();

        /// <summary>
        /// Tilt Down
        /// </summary>
        void TiltDown();

        /// <summary>
        /// Zoom In
        /// </summary>
        void ZoomIn();

        /// <summary>
        /// Zoom Out
        /// </summary>
        void ZoomOut();

        /// <summary>
        /// Zoom at a factor
        /// </summary>
        /// <param name="factor"></param>
        void ZoomAt(int factor);

        /// <summary>
        /// Pan and Tilt to a specific point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void PanTilt(int x, int y);
	}
}
