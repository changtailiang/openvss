// wxrv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mwtd	
// xjdu	 By downloading, copying, installing or using the software you agree to this license.
// acku	 If you do not agree to this license, do not download, install,
// tsva	 copy or use the software.
// bpqn	
// ssxf	                          License Agreement
// gves	         For OpenVss - Open Source Video Surveillance System
// hbjo	
// dafk	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// hzzh	
// padc	Third party copyrights are property of their respective owners.
// snnr	
// ftyh	Redistribution and use in source and binary forms, with or without modification,
// gedu	are permitted provided that the following conditions are met:
// yoxb	
// fkmy	  * Redistribution's of source code must retain the above copyright notice,
// swrt	    this list of conditions and the following disclaimer.
// mktc	
// qjxr	  * Redistribution's in binary form must reproduce the above copyright notice,
// oumt	    this list of conditions and the following disclaimer in the documentation
// hmno	    and/or other materials provided with the distribution.
// cciy	
// xllt	  * Neither the name of the copyright holders nor the names of its contributors 
// cxcf	    may not be used to endorse or promote products derived from this software 
// oekw	    without specific prior written permission.
// vtfu	
// awrx	This software is provided by the copyright holders and contributors "as is" and
// hlgd	any express or implied warranties, including, but not limited to, the implied
// bdtt	warranties of merchantability and fitness for a particular purpose are disclaimed.
// xxwp	In no event shall the Prince of Songkla University or contributors be liable 
// ntwb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// yzas	(including, but not limited to, procurement of substitute goods or services;
// gsdj	loss of use, data, or profits; or business interruption) however caused
// kqxn	and on any theory of liability, whether in contract, strict liability,
// gsog	or tort (including negligence or otherwise) arising in any way out of
// llql	the use of this software, even if advised of the possibility of such damage.

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

namespace Vs.Analyzer.MotionHistory
{
    public class VsMotionHistory : VsCoreAnalyzer, IDisposable
    {
        //private string analyserName;
        private bool calculateMotionLevel = false;
		private int		width;	// image width
		private int		height;	// image height
		private double		pixelsChanged;
        private VsCvMotionHistory cvAlgo = null;

		// Motion level calculation - calculate or not motion level
		public bool MotionLevelCalculation
		{
			get { return calculateMotionLevel; }
			set { calculateMotionLevel = value; }
		}

		// Constructor
        public VsMotionHistory(long syncTimer) : base(syncTimer, 1, 1)
		{
            
		}
		// Constructor
        ~VsMotionHistory()
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
                    cvAlgo = new VsCvMotionHistory(1, 1, width, height, cvDepth.Depth8U, 3);
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
