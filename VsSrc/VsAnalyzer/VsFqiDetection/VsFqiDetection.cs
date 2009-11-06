// xvaq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// euvr	
// yysg	 By downloading, copying, installing or using the software you agree to this license.
// iaqs	 If you do not agree to this license, do not download, install,
// wftz	 copy or use the software.
// bwns	
// ggtn	                          License Agreement
// lcdz	         For OpenVss - Open Source Video Surveillance System
// cnvr	
// kstt	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ddtl	
// twmi	Third party copyrights are property of their respective owners.
// qwag	
// ecsa	Redistribution and use in source and binary forms, with or without modification,
// ihjy	are permitted provided that the following conditions are met:
// ahgv	
// vsdv	  * Redistribution's of source code must retain the above copyright notice,
// fzid	    this list of conditions and the following disclaimer.
// mavy	
// dcyj	  * Redistribution's in binary form must reproduce the above copyright notice,
// tlxo	    this list of conditions and the following disclaimer in the documentation
// bxuz	    and/or other materials provided with the distribution.
// uujc	
// jvtv	  * Neither the name of the copyright holders nor the names of its contributors 
// xxpb	    may not be used to endorse or promote products derived from this software 
// trdr	    without specific prior written permission.
// nxue	
// guwg	This software is provided by the copyright holders and contributors "as is" and
// izeo	any express or implied warranties, including, but not limited to, the implied
// krty	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xdbk	In no event shall the Prince of Songkla University or contributors be liable 
// qgtr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gaag	(including, but not limited to, procurement of substitute goods or services;
// mxqb	loss of use, data, or profits; or business interruption) however caused
// ifbe	and on any theory of liability, whether in contract, strict liability,
// cpsz	or tort (including negligence or otherwise) arising in any way out of
// yctj	the use of this software, even if advised of the possibility of such damage.

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

namespace Vs.Analyzer.FqiDetection
{
    public class VsFqiDetection : VsCoreAnalyzer, IDisposable
    {
		private int		width;	// image width
		private int		height;	// image height
        private VsCvFqiDetection cvAlgo = null;

		// Constructor
        public VsFqiDetection(long syncTimer) : base(syncTimer, 1, 1)
		{
            
		}
		// Constructor
        ~VsFqiDetection()
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
                    cvAlgo = new VsCvFqiDetection(1, 1, width, height, cvDepth.Depth8U, 3);
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
