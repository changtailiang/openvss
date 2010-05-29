// hquq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cjmk	
// yfqh	 By downloading, copying, installing or using the software you agree to this license.
// hihy	 If you do not agree to this license, do not download, install,
// aloa	 copy or use the software.
// zqql	
// mppr	                          License Agreement
// accp	         For OpenVSS - Open Source Video Surveillance System
// odmi	
// omhs	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ubao	
// avkr	Third party copyrights are property of their respective owners.
// rdvt	
// lsrr	Redistribution and use in source and binary forms, with or without modification,
// aidn	are permitted provided that the following conditions are met:
// uvkw	
// date	  * Redistribution's of source code must retain the above copyright notice,
// vzjn	    this list of conditions and the following disclaimer.
// evfy	
// pblr	  * Redistribution's in binary form must reproduce the above copyright notice,
// eyax	    this list of conditions and the following disclaimer in the documentation
// giew	    and/or other materials provided with the distribution.
// lvig	
// iuyz	  * Neither the name of the copyright holders nor the names of its contributors 
// reka	    may not be used to endorse or promote products derived from this software 
// cfvs	    without specific prior written permission.
// thpp	
// mtby	This software is provided by the copyright holders and contributors "as is" and
// xmiv	any express or implied warranties, including, but not limited to, the implied
// vnqu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vxsz	In no event shall the Prince of Songkla University or contributors be liable 
// qcfk	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xggl	(including, but not limited to, procurement of substitute goods or services;
// qkpz	loss of use, data, or profits; or business interruption) however caused
// chdy	and on any theory of liability, whether in contract, strict liability,
// tojr	or tort (including negligence or otherwise) arising in any way out of
// ukiw	the use of this software, even if advised of the possibility of such damage.
// lcee	
// nqfe	Intelligent Systems Laboratory (iSys Lab)
// mvbr	Faculty of Engineering, Prince of Songkla University, THAILAND
// cesf	Project leader by Nikom SUVONVORN
// mphn	Project website at http://code.google.com/p/openvss/

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

namespace Vs.Analyzer.EdgeDetection
{
    public class VsEdgeDetection : VsCoreAnalyzer, IDisposable
    {
        //private string analyserName;
        private bool calculateMotionLevel = false;
		private int		width;	// image width
		private int		height;	// image height
		private double		pixelsChanged;
        private VsCvEdgeDetection cvAlgo = null;

		// Motion level calculation - calculate or not motion level
		public bool MotionLevelCalculation
		{
			get { return calculateMotionLevel; }
			set { calculateMotionLevel = value; }
		}

		// Constructor
        public VsEdgeDetection(long syncTimer) : base(syncTimer, 1, 1)
		{
            
		}
		// Constructor
        ~VsEdgeDetection()
        {
            if(cvAlgo!=null) cvAlgo.Dispose();
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
                    cvAlgo = new VsCvEdgeDetection(1, 1, width, height, cvDepth.Depth8U, 3);
                    cvAlgo.VsInit();
                    return;
                }

                cvAlgo.VsConfiguration(int.Parse(AnalyzerConfiguration["ThresholdStrong"].ToString()),
                    int.Parse(AnalyzerConfiguration["ThresholdWeak"].ToString()));
                lastFrame.Image = cvAlgo.VsProcess(lastFrame.Image);
                lastFrame.Result = cvAlgo.VsResult();
                lastFrame.IsAnalyzed = true;
                lastFrame.IsDetected = true;
            }
            catch { }
    	}
    }
}
