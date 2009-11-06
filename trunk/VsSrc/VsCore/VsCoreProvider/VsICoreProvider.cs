// vqpc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ikmk	
// xviy	 By downloading, copying, installing or using the software you agree to this license.
// ludj	 If you do not agree to this license, do not download, install,
// dttc	 copy or use the software.
// eymq	
// zpfy	                          License Agreement
// nzjj	         For OpenVss - Open Source Video Surveillance System
// zsqn	
// vehu	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// dlrx	
// eewe	Third party copyrights are property of their respective owners.
// idby	
// sqmw	Redistribution and use in source and binary forms, with or without modification,
// dzct	are permitted provided that the following conditions are met:
// fnwy	
// lyyt	  * Redistribution's of source code must retain the above copyright notice,
// dpny	    this list of conditions and the following disclaimer.
// lyzt	
// gplu	  * Redistribution's in binary form must reproduce the above copyright notice,
// sapk	    this list of conditions and the following disclaimer in the documentation
// xkqj	    and/or other materials provided with the distribution.
// ftjv	
// bopp	  * Neither the name of the copyright holders nor the names of its contributors 
// otlf	    may not be used to endorse or promote products derived from this software 
// gdas	    without specific prior written permission.
// pdnt	
// qspo	This software is provided by the copyright holders and contributors "as is" and
// niaf	any express or implied warranties, including, but not limited to, the implied
// ymaa	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ionk	In no event shall the Prince of Songkla University or contributors be liable 
// grww	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jjen	(including, but not limited to, procurement of substitute goods or services;
// dgop	loss of use, data, or profits; or business interruption) however caused
// zxuu	and on any theory of liability, whether in contract, strict liability,
// xwsn	or tort (including negligence or otherwise) arising in any way out of
// dvit	the use of this software, even if advised of the possibility of such damage.

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
