// xdka	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tshb	
// mfhy	 By downloading, copying, installing or using the software you agree to this license.
// zond	 If you do not agree to this license, do not download, install,
// saxu	 copy or use the software.
// yhif	
// wgqz	                          License Agreement
// fupp	         For OpenVss - Open Source Video Surveillance System
// rniu	
// jilr	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ushq	
// vwpr	Third party copyrights are property of their respective owners.
// kzly	
// prkp	Redistribution and use in source and binary forms, with or without modification,
// vedm	are permitted provided that the following conditions are met:
// bhvr	
// qrgl	  * Redistribution's of source code must retain the above copyright notice,
// fsuj	    this list of conditions and the following disclaimer.
// ogaf	
// aska	  * Redistribution's in binary form must reproduce the above copyright notice,
// rypg	    this list of conditions and the following disclaimer in the documentation
// jqaa	    and/or other materials provided with the distribution.
// ctze	
// ezqn	  * Neither the name of the copyright holders nor the names of its contributors 
// xqzd	    may not be used to endorse or promote products derived from this software 
// pemr	    without specific prior written permission.
// fbkj	
// rfod	This software is provided by the copyright holders and contributors "as is" and
// tduc	any express or implied warranties, including, but not limited to, the implied
// sphz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rgil	In no event shall the Prince of Songkla University or contributors be liable 
// tpeo	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qmik	(including, but not limited to, procurement of substitute goods or services;
// shkn	loss of use, data, or profits; or business interruption) however caused
// mxbi	and on any theory of liability, whether in contract, strict liability,
// grix	or tort (including negligence or otherwise) arising in any way out of
// fwkb	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

using System.Runtime.InteropServices;
using System.Threading;

using Vs.Core.Analyzer;
using Vs.Core.Image;

using VsOpenCV;

namespace Vs.Analyzer.ObjectDetection
{
    public class VsObjectDetection : VsCoreAnalyzer, IDisposable
    {
        //private string analyserName;
        private bool calculateMotionLevel = false;
		private int		width;	// image width
		private int		height;	// image height
		private double		pixelsChanged;
        private VsCvObjectDetection cvAlgo = null;

		// Motion level calculation - calculate or not motion level
		public bool MotionLevelCalculation
		{
			get { return calculateMotionLevel; }
			set { calculateMotionLevel = value; }
		}

		// Constructor
        public VsObjectDetection(long syncTimer) : base(syncTimer, 1, 1)
		{
            
		}
		// Constructor
        ~VsObjectDetection()
        {
            cvAlgo.Dispose();
        }

        
		// Reset detector to initial state
		public void Reset( )
		{
		}

		// Process new frame
        public override void process_Frame1(VsImage lastFrame)
        {
            try
            {
                if (cvAlgo == null)
                {
                    width = lastFrame.Image.Width;
                    height = lastFrame.Image.Height;
                    cvAlgo = new VsCvObjectDetection(1, 1, width, height, cvDepth.Depth8U, 3);
                    cvAlgo.VsInit();
                    return;
                }

                cvAlgo.VsConfiguration(int.Parse(AnalyzerConfiguration["SelectedObject"].ToString()));
                lastFrame.Image = cvAlgo.VsProcess(lastFrame.Image);
                lastFrame.Result = cvAlgo.VsResult();
                lastFrame.IsAnalyzed = true;
                if (lastFrame.Result.Length > 1) lastFrame.IsDetected = true;
                else lastFrame.IsDetected = false;
            }
            catch { }
    	}
    }
}
