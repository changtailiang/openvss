// bkex	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mzqq	
// ixjc	 By downloading, copying, installing or using the software you agree to this license.
// lgsa	 If you do not agree to this license, do not download, install,
// pouo	 copy or use the software.
// jrjb	
// gglc	                          License Agreement
// ntea	         For OpenVSS - Open Source Video Surveillance System
// huey	
// uwmm	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ajpk	
// afxl	Third party copyrights are property of their respective owners.
// gnzq	
// lzaj	Redistribution and use in source and binary forms, with or without modification,
// bcqg	are permitted provided that the following conditions are met:
// nndo	
// tiur	  * Redistribution's of source code must retain the above copyright notice,
// ctfs	    this list of conditions and the following disclaimer.
// chnz	
// bzbb	  * Redistribution's in binary form must reproduce the above copyright notice,
// jawz	    this list of conditions and the following disclaimer in the documentation
// tnpi	    and/or other materials provided with the distribution.
// tuxs	
// fgzm	  * Neither the name of the copyright holders nor the names of its contributors 
// gars	    may not be used to endorse or promote products derived from this software 
// kgin	    without specific prior written permission.
// igoe	
// lbhb	This software is provided by the copyright holders and contributors "as is" and
// bpxn	any express or implied warranties, including, but not limited to, the implied
// revf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tmxh	In no event shall the Prince of Songkla University or contributors be liable 
// vmmv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// hasa	(including, but not limited to, procurement of substitute goods or services;
// hjqc	loss of use, data, or profits; or business interruption) however caused
// riqm	and on any theory of liability, whether in contract, strict liability,
// ykws	or tort (including negligence or otherwise) arising in any way out of
// nvrq	the use of this software, even if advised of the possibility of such damage.
// jlvc	
// flzy	Intelligent Systems Laboratory (iSys Lab)
// jarv	Faculty of Engineering, Prince of Songkla University, THAILAND
// utwl	Project leader by Nikom SUVONVORN
// igus	Project website at http://code.google.com/p/openvss/

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

namespace Vs.Analyzer.LineDetection
{
    public class VsLineDetection : VsCoreAnalyzer, IDisposable
    {
		private int		width;	// image width
		private int		height;	// image height
        private VsCvLineDetection cvAlgo = null;

		// Constructor
        public VsLineDetection(long syncTimer) : base(syncTimer, 1, 1)
		{
            
		}
		// Constructor
        ~VsLineDetection()
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
                    cvAlgo = new VsCvLineDetection(1, 1, width, height, cvDepth.Depth8U, 3);
                    cvAlgo.VsInit();
                    return;
                }

                cvAlgo.VsConfiguration(int.Parse(AnalyzerConfiguration["ThresholdStrong"].ToString()),
                    int.Parse(AnalyzerConfiguration["ThresholdWeak"].ToString()),
                    int.Parse(AnalyzerConfiguration["ThresholdHough"].ToString()));
                lastFrame.Image = cvAlgo.VsProcess(lastFrame.Image);
                lastFrame.Result = cvAlgo.VsResult();
                lastFrame.IsAnalyzed = true;
                lastFrame.IsDetected = true;
            }
            catch { }
    	}
    }
}
