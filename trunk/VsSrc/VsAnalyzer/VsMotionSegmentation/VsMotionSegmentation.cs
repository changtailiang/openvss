// ilds	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mzfv	
// puol	 By downloading, copying, installing or using the software you agree to this license.
// gonz	 If you do not agree to this license, do not download, install,
// mtfg	 copy or use the software.
// qjna	
// msfp	                          License Agreement
// gqgt	         For OpenVss - Open Source Video Surveillance System
// vbbz	
// kdjq	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// oxcp	
// wksh	Third party copyrights are property of their respective owners.
// aqqj	
// qefy	Redistribution and use in source and binary forms, with or without modification,
// xdft	are permitted provided that the following conditions are met:
// uqoz	
// nvqe	  * Redistribution's of source code must retain the above copyright notice,
// nooi	    this list of conditions and the following disclaimer.
// jprt	
// hxdc	  * Redistribution's in binary form must reproduce the above copyright notice,
// axoq	    this list of conditions and the following disclaimer in the documentation
// zxcq	    and/or other materials provided with the distribution.
// wcbg	
// xqvy	  * Neither the name of the copyright holders nor the names of its contributors 
// jccb	    may not be used to endorse or promote products derived from this software 
// unum	    without specific prior written permission.
// ciza	
// mmqa	This software is provided by the copyright holders and contributors "as is" and
// adtw	any express or implied warranties, including, but not limited to, the implied
// byaq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// szik	In no event shall the Prince of Songkla University or contributors be liable 
// mhkt	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ttje	(including, but not limited to, procurement of substitute goods or services;
// vbim	loss of use, data, or profits; or business interruption) however caused
// dcnq	and on any theory of liability, whether in contract, strict liability,
// ycej	or tort (including negligence or otherwise) arising in any way out of
// lbgu	the use of this software, even if advised of the possibility of such damage.

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

namespace Vs.Analyzer.MotionSegmentation
{
    public class VsMotionSegmentation : VsCoreAnalyzer, IDisposable
    {
        //private string analyserName;
        private bool calculateMotionLevel = false;
		private int		width;	// image width
		private int		height;	// image height
		private double		pixelsChanged;
        private VsCvMotionSegmentation cvAlgo = null;

		// Motion level calculation - calculate or not motion level
		public bool MotionLevelCalculation
		{
			get { return calculateMotionLevel; }
			set { calculateMotionLevel = value; }
		}

		// Constructor
        public VsMotionSegmentation(long syncTimer) : base(syncTimer, 1, 1)
		{
            
		}
		// Constructor
        ~VsMotionSegmentation()
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
                    cvAlgo = new VsCvMotionSegmentation(1, 1, width, height, cvDepth.Depth8U, 3);
                    cvAlgo.VsInit();
                    return;
                }

                cvAlgo.VsConfiguration(int.Parse(AnalyzerConfiguration["ThresholdAlpha"].ToString()),
                    int.Parse(AnalyzerConfiguration["ThresholdSigma"].ToString()));
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
