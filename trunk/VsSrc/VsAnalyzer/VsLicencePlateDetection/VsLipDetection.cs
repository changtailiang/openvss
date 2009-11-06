// tnly	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// majd	
// rpuh	 By downloading, copying, installing or using the software you agree to this license.
// jelm	 If you do not agree to this license, do not download, install,
// rwag	 copy or use the software.
// exqi	
// lbkh	                          License Agreement
// vjlv	         For OpenVss - Open Source Video Surveillance System
// klpq	
// idcn	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// natb	
// xcrb	Third party copyrights are property of their respective owners.
// yvnm	
// iapv	Redistribution and use in source and binary forms, with or without modification,
// wcnk	are permitted provided that the following conditions are met:
// qchh	
// dyxy	  * Redistribution's of source code must retain the above copyright notice,
// pvdn	    this list of conditions and the following disclaimer.
// tntd	
// epli	  * Redistribution's in binary form must reproduce the above copyright notice,
// kija	    this list of conditions and the following disclaimer in the documentation
// wzmk	    and/or other materials provided with the distribution.
// vutg	
// qswl	  * Neither the name of the copyright holders nor the names of its contributors 
// smyy	    may not be used to endorse or promote products derived from this software 
// fsmd	    without specific prior written permission.
// sasv	
// glrh	This software is provided by the copyright holders and contributors "as is" and
// qeai	any express or implied warranties, including, but not limited to, the implied
// thld	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mncv	In no event shall the Prince of Songkla University or contributors be liable 
// cwxb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qiks	(including, but not limited to, procurement of substitute goods or services;
// rndr	loss of use, data, or profits; or business interruption) however caused
// vfiv	and on any theory of liability, whether in contract, strict liability,
// hrdk	or tort (including negligence or otherwise) arising in any way out of
// dlql	the use of this software, even if advised of the possibility of such damage.

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

namespace Vs.Analyzer.LipDetection
{
    public class VsLipDetection : VsCoreAnalyzer, IDisposable
    {
		private int		width;	// image width
		private int		height;	// image height
        private VsCvLipDetection cvAlgo = null;

		// Constructor
        public VsLipDetection(long syncTimer) : base(syncTimer, 1, 1)
		{
            
		}
		// Constructor
        ~VsLipDetection()
        {
            //cvAlgo.Dispose();
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
                    cvAlgo = new VsCvLipDetection(1, 1, width, height, cvDepth.Depth8U, 3);
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
