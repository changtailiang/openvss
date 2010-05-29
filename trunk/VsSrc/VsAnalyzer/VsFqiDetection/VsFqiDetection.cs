// iprn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lllz	
// fphf	 By downloading, copying, installing or using the software you agree to this license.
// vvyl	 If you do not agree to this license, do not download, install,
// pnys	 copy or use the software.
// fqsp	
// hxtq	                          License Agreement
// qprt	         For OpenVSS - Open Source Video Surveillance System
// jblk	
// upzd	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// quwa	
// izbm	Third party copyrights are property of their respective owners.
// pxtw	
// snys	Redistribution and use in source and binary forms, with or without modification,
// wcfo	are permitted provided that the following conditions are met:
// rvip	
// xnvu	  * Redistribution's of source code must retain the above copyright notice,
// jnqa	    this list of conditions and the following disclaimer.
// ovck	
// usgh	  * Redistribution's in binary form must reproduce the above copyright notice,
// vgbs	    this list of conditions and the following disclaimer in the documentation
// wvbv	    and/or other materials provided with the distribution.
// dtor	
// jklv	  * Neither the name of the copyright holders nor the names of its contributors 
// lgcv	    may not be used to endorse or promote products derived from this software 
// dhdb	    without specific prior written permission.
// htix	
// lnxd	This software is provided by the copyright holders and contributors "as is" and
// wysk	any express or implied warranties, including, but not limited to, the implied
// uqtb	warranties of merchantability and fitness for a particular purpose are disclaimed.
// laqq	In no event shall the Prince of Songkla University or contributors be liable 
// zzqd	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jgzn	(including, but not limited to, procurement of substitute goods or services;
// pleo	loss of use, data, or profits; or business interruption) however caused
// dzlc	and on any theory of liability, whether in contract, strict liability,
// nejp	or tort (including negligence or otherwise) arising in any way out of
// wkvl	the use of this software, even if advised of the possibility of such damage.
// sbbv	
// nbjd	Intelligent Systems Laboratory (iSys Lab)
// qmch	Faculty of Engineering, Prince of Songkla University, THAILAND
// cenf	Project leader by Nikom SUVONVORN
// ojnk	Project website at http://code.google.com/p/openvss/

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
