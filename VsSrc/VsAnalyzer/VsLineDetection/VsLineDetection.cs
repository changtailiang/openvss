// okiu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// brai	
// ngni	 By downloading, copying, installing or using the software you agree to this license.
// bent	 If you do not agree to this license, do not download, install,
// sgrv	 copy or use the software.
// ipme	
// wbap	                          License Agreement
// gown	         For OpenVss - Open Source Video Surveillance System
// krpm	
// ccbg	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// xwrd	
// ejnu	Third party copyrights are property of their respective owners.
// zcmx	
// hkoy	Redistribution and use in source and binary forms, with or without modification,
// yeyz	are permitted provided that the following conditions are met:
// qlcy	
// jaxj	  * Redistribution's of source code must retain the above copyright notice,
// pbrq	    this list of conditions and the following disclaimer.
// flyl	
// yjzn	  * Redistribution's in binary form must reproduce the above copyright notice,
// ngpd	    this list of conditions and the following disclaimer in the documentation
// czfa	    and/or other materials provided with the distribution.
// dqnx	
// ebpm	  * Neither the name of the copyright holders nor the names of its contributors 
// uste	    may not be used to endorse or promote products derived from this software 
// lefy	    without specific prior written permission.
// lvsw	
// ldao	This software is provided by the copyright holders and contributors "as is" and
// eklk	any express or implied warranties, including, but not limited to, the implied
// vywk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// uxfy	In no event shall the Prince of Songkla University or contributors be liable 
// ntme	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vmqg	(including, but not limited to, procurement of substitute goods or services;
// qvbj	loss of use, data, or profits; or business interruption) however caused
// brrg	and on any theory of liability, whether in contract, strict liability,
// hjoa	or tort (including negligence or otherwise) arising in any way out of
// qztt	the use of this software, even if advised of the possibility of such damage.

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
