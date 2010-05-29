// skxk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// pzlj	
// hxed	 By downloading, copying, installing or using the software you agree to this license.
// demu	 If you do not agree to this license, do not download, install,
// gmop	 copy or use the software.
// iaqs	
// muex	                          License Agreement
// irqq	         For OpenVSS - Open Source Video Surveillance System
// flrr	
// epvf	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ranv	
// igrj	Third party copyrights are property of their respective owners.
// ruxs	
// fwps	Redistribution and use in source and binary forms, with or without modification,
// teyu	are permitted provided that the following conditions are met:
// unbp	
// hnys	  * Redistribution's of source code must retain the above copyright notice,
// muqr	    this list of conditions and the following disclaimer.
// qjyh	
// nvkf	  * Redistribution's in binary form must reproduce the above copyright notice,
// dugo	    this list of conditions and the following disclaimer in the documentation
// uxli	    and/or other materials provided with the distribution.
// wzyz	
// rakd	  * Neither the name of the copyright holders nor the names of its contributors 
// zynu	    may not be used to endorse or promote products derived from this software 
// izxx	    without specific prior written permission.
// efbv	
// xhey	This software is provided by the copyright holders and contributors "as is" and
// usrz	any express or implied warranties, including, but not limited to, the implied
// hnuj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cpwm	In no event shall the Prince of Songkla University or contributors be liable 
// wraq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// zuio	(including, but not limited to, procurement of substitute goods or services;
// hpxe	loss of use, data, or profits; or business interruption) however caused
// xiko	and on any theory of liability, whether in contract, strict liability,
// vplo	or tort (including negligence or otherwise) arising in any way out of
// uaey	the use of this software, even if advised of the possibility of such damage.
// ikwm	
// dest	Intelligent Systems Laboratory (iSys Lab)
// dkbm	Faculty of Engineering, Prince of Songkla University, THAILAND
// flwd	Project leader by Nikom SUVONVORN
// zpqf	Project website at http://code.google.com/p/openvss/

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
