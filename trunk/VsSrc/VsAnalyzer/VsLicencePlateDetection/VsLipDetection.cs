// bpsv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cqph	
// jszm	 By downloading, copying, installing or using the software you agree to this license.
// onay	 If you do not agree to this license, do not download, install,
// qzsy	 copy or use the software.
// frle	
// nlon	                          License Agreement
// hada	         For OpenVSS - Open Source Video Surveillance System
// wbbw	
// psod	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// utps	
// cydl	Third party copyrights are property of their respective owners.
// xfiu	
// hugk	Redistribution and use in source and binary forms, with or without modification,
// eohr	are permitted provided that the following conditions are met:
// bcaj	
// pypm	  * Redistribution's of source code must retain the above copyright notice,
// mdjx	    this list of conditions and the following disclaimer.
// kodm	
// bsbp	  * Redistribution's in binary form must reproduce the above copyright notice,
// idpb	    this list of conditions and the following disclaimer in the documentation
// sisc	    and/or other materials provided with the distribution.
// vqsb	
// lxcs	  * Neither the name of the copyright holders nor the names of its contributors 
// sfdd	    may not be used to endorse or promote products derived from this software 
// iqyt	    without specific prior written permission.
// wkjs	
// quil	This software is provided by the copyright holders and contributors "as is" and
// msix	any express or implied warranties, including, but not limited to, the implied
// mzrg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fnrv	In no event shall the Prince of Songkla University or contributors be liable 
// kimn	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mluv	(including, but not limited to, procurement of substitute goods or services;
// oyhr	loss of use, data, or profits; or business interruption) however caused
// eveh	and on any theory of liability, whether in contract, strict liability,
// yzlb	or tort (including negligence or otherwise) arising in any way out of
// ihps	the use of this software, even if advised of the possibility of such damage.
// oefs	
// oxxu	Intelligent Systems Laboratory (iSys Lab)
// zcio	Faculty of Engineering, Prince of Songkla University, THAILAND
// ywgf	Project leader by Nikom SUVONVORN
// zmwn	Project website at http://code.google.com/p/openvss/

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
