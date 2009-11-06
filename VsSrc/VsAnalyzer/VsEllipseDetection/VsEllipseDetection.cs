// huqv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vvxz	
// gvfq	 By downloading, copying, installing or using the software you agree to this license.
// zzrt	 If you do not agree to this license, do not download, install,
// kaow	 copy or use the software.
// qupu	
// wmht	                          License Agreement
// jgir	         For OpenVss - Open Source Video Surveillance System
// kfsg	
// jugd	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// nasf	
// swjh	Third party copyrights are property of their respective owners.
// wzha	
// khnn	Redistribution and use in source and binary forms, with or without modification,
// ewzi	are permitted provided that the following conditions are met:
// neqz	
// mnft	  * Redistribution's of source code must retain the above copyright notice,
// hlkq	    this list of conditions and the following disclaimer.
// tljq	
// bkba	  * Redistribution's in binary form must reproduce the above copyright notice,
// cawj	    this list of conditions and the following disclaimer in the documentation
// zhhd	    and/or other materials provided with the distribution.
// rebn	
// vypi	  * Neither the name of the copyright holders nor the names of its contributors 
// jssf	    may not be used to endorse or promote products derived from this software 
// qpzl	    without specific prior written permission.
// pqhy	
// yxlu	This software is provided by the copyright holders and contributors "as is" and
// uyfn	any express or implied warranties, including, but not limited to, the implied
// ihaf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fcbd	In no event shall the Prince of Songkla University or contributors be liable 
// kxvv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vagi	(including, but not limited to, procurement of substitute goods or services;
// swkm	loss of use, data, or profits; or business interruption) however caused
// blui	and on any theory of liability, whether in contract, strict liability,
// aifu	or tort (including negligence or otherwise) arising in any way out of
// sgsw	the use of this software, even if advised of the possibility of such damage.

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

namespace Vs.Analyzer.EllipseDetection
{
    public class VsEllipseDetection : VsCoreAnalyzer, IDisposable
    {
		private int		width;	// image width
		private int		height;	// image height
        private VsCvEllipseDetection cvAlgo = null;

		// Constructor
        public VsEllipseDetection(long syncTimer) : base(syncTimer, 1, 1)
		{
            
		}
		// Constructor
        ~VsEllipseDetection()
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
                    cvAlgo = new VsCvEllipseDetection(1, 1, width, height, cvDepth.Depth8U, 3);
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
