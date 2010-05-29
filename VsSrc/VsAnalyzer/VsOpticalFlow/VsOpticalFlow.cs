// cqjt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// axdt	
// luvt	 By downloading, copying, installing or using the software you agree to this license.
// kayv	 If you do not agree to this license, do not download, install,
// onnb	 copy or use the software.
// dmjq	
// zxhe	                          License Agreement
// ugvz	         For OpenVSS - Open Source Video Surveillance System
// sivo	
// mxhz	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// xlzy	
// okub	Third party copyrights are property of their respective owners.
// drai	
// ftgp	Redistribution and use in source and binary forms, with or without modification,
// hstd	are permitted provided that the following conditions are met:
// pzze	
// zwac	  * Redistribution's of source code must retain the above copyright notice,
// ejiq	    this list of conditions and the following disclaimer.
// fnes	
// nkbo	  * Redistribution's in binary form must reproduce the above copyright notice,
// dgac	    this list of conditions and the following disclaimer in the documentation
// gmtz	    and/or other materials provided with the distribution.
// bfht	
// eejy	  * Neither the name of the copyright holders nor the names of its contributors 
// muzs	    may not be used to endorse or promote products derived from this software 
// krwt	    without specific prior written permission.
// ikcr	
// oocw	This software is provided by the copyright holders and contributors "as is" and
// reaj	any express or implied warranties, including, but not limited to, the implied
// ywym	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cbaz	In no event shall the Prince of Songkla University or contributors be liable 
// cplb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// egfs	(including, but not limited to, procurement of substitute goods or services;
// ljel	loss of use, data, or profits; or business interruption) however caused
// jgtv	and on any theory of liability, whether in contract, strict liability,
// jbkn	or tort (including negligence or otherwise) arising in any way out of
// dlba	the use of this software, even if advised of the possibility of such damage.
// ezzp	
// wnpi	Intelligent Systems Laboratory (iSys Lab)
// rxrs	Faculty of Engineering, Prince of Songkla University, THAILAND
// ybni	Project leader by Nikom SUVONVORN
// ijki	Project website at http://code.google.com/p/openvss/

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

namespace Vs.Analyzer.OpticalFlow
{
    public class VsOpticalFlow : VsCoreAnalyzer, IDisposable
    {
        //private string analyserName;
        private bool calculateMotionLevel = false;
		private int		width;	// image width
		private int		height;	// image height
		private double		pixelsChanged;
        private VsCvOpticalFlow cvAlgo = null;

		// Motion level calculation - calculate or not motion level
		public bool MotionLevelCalculation
		{
			get { return calculateMotionLevel; }
			set { calculateMotionLevel = value; }
		}

		// Constructor
        public VsOpticalFlow(long syncTimer) : base(syncTimer, 1, 1)
		{
            
		}
		// Constructor
        ~VsOpticalFlow()
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
                    cvAlgo = new VsCvOpticalFlow(1, 1, width, height, cvDepth.Depth8U, 3);
                    cvAlgo.VsInit();
                    return;
                }

                cvAlgo.VsConfiguration(int.Parse(AnalyzerConfiguration["ThresholdAlpha"].ToString()),
                    int.Parse(AnalyzerConfiguration["ThresholdSigma"].ToString()));
                lastFrame.Image = cvAlgo.VsProcess(lastFrame.Image);
                lastFrame.Result = cvAlgo.VsResult();
                lastFrame.IsAnalyzed = true;
                lastFrame.IsDetected = true;
            }
            catch { }
    	}
    }
}
