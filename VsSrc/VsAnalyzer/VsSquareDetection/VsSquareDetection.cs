// yhjn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jqsh	
// wyie	 By downloading, copying, installing or using the software you agree to this license.
// vfra	 If you do not agree to this license, do not download, install,
// fkai	 copy or use the software.
// xiub	
// gray	                          License Agreement
// kycr	         For OpenVss - Open Source Video Surveillance System
// wbgm	
// vkcg	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// wlpz	
// jsnc	Third party copyrights are property of their respective owners.
// xnco	
// dotq	Redistribution and use in source and binary forms, with or without modification,
// mihr	are permitted provided that the following conditions are met:
// qtwy	
// vqhu	  * Redistribution's of source code must retain the above copyright notice,
// yffv	    this list of conditions and the following disclaimer.
// itml	
// tusn	  * Redistribution's in binary form must reproduce the above copyright notice,
// eybx	    this list of conditions and the following disclaimer in the documentation
// wonh	    and/or other materials provided with the distribution.
// ipzn	
// ckqc	  * Neither the name of the copyright holders nor the names of its contributors 
// pqes	    may not be used to endorse or promote products derived from this software 
// ktdr	    without specific prior written permission.
// iggk	
// chws	This software is provided by the copyright holders and contributors "as is" and
// qtns	any express or implied warranties, including, but not limited to, the implied
// szbg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// dami	In no event shall the Prince of Songkla University or contributors be liable 
// grsx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// cjwc	(including, but not limited to, procurement of substitute goods or services;
// qadl	loss of use, data, or profits; or business interruption) however caused
// ujop	and on any theory of liability, whether in contract, strict liability,
// idfa	or tort (including negligence or otherwise) arising in any way out of
// thwj	the use of this software, even if advised of the possibility of such damage.

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

namespace Vs.Analyzer.SquareDetection
{
    public class VsSquareDetection : VsCoreAnalyzer, IDisposable
    {
		private int		width;	// image width
		private int		height;	// image height
        private VsCvSquareDetection cvAlgo = null;

		// Constructor
        public VsSquareDetection(long syncTimer) : base(syncTimer, 1, 1)
		{
            
		}
		// Constructor
        ~VsSquareDetection()
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
                    cvAlgo = new VsCvSquareDetection(1, 1, width, height, cvDepth.Depth8U, 3);
                    cvAlgo.VsInit();
                    return;
                }

                cvAlgo.VsConfiguration(int.Parse(AnalyzerConfiguration["Threshold"].ToString()));
                lastFrame.Image = cvAlgo.VsProcess(lastFrame.Image);
                lastFrame.Result = cvAlgo.VsResult();
                lastFrame.IsAnalyzed = true;
                lastFrame.IsDetected = true;
            }
            catch { }
    	}
    }
}
