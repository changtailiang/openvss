// ykva	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lhgq	
// bfcw	 By downloading, copying, installing or using the software you agree to this license.
// ekxu	 If you do not agree to this license, do not download, install,
// cguf	 copy or use the software.
// ueki	
// tkqz	                          License Agreement
// howh	         For OpenVss - Open Source Video Surveillance System
// jvpa	
// odpw	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// bavn	
// pysc	Third party copyrights are property of their respective owners.
// nnad	
// dabt	Redistribution and use in source and binary forms, with or without modification,
// zmha	are permitted provided that the following conditions are met:
// rgjm	
// iuni	  * Redistribution's of source code must retain the above copyright notice,
// vxgz	    this list of conditions and the following disclaimer.
// rxet	
// jxtv	  * Redistribution's in binary form must reproduce the above copyright notice,
// snmt	    this list of conditions and the following disclaimer in the documentation
// otdi	    and/or other materials provided with the distribution.
// uvab	
// wofu	  * Neither the name of the copyright holders nor the names of its contributors 
// rieu	    may not be used to endorse or promote products derived from this software 
// kjhp	    without specific prior written permission.
// hamg	
// whjb	This software is provided by the copyright holders and contributors "as is" and
// tlid	any express or implied warranties, including, but not limited to, the implied
// upyp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rfoz	In no event shall the Prince of Songkla University or contributors be liable 
// wecc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rjbb	(including, but not limited to, procurement of substitute goods or services;
// tyki	loss of use, data, or profits; or business interruption) however caused
// gwmo	and on any theory of liability, whether in contract, strict liability,
// gxmm	or tort (including negligence or otherwise) arising in any way out of
// mzik	the use of this software, even if advised of the possibility of such damage.

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
