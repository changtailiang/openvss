// lrtz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ffci	
// muui	 By downloading, copying, installing or using the software you agree to this license.
// jthe	 If you do not agree to this license, do not download, install,
// afhl	 copy or use the software.
// owzq	
// qkvc	                          License Agreement
// xqes	         For OpenVSS - Open Source Video Surveillance System
// nnkp	
// kkvd	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// nebf	
// wkxu	Third party copyrights are property of their respective owners.
// nqiw	
// vtup	Redistribution and use in source and binary forms, with or without modification,
// rdjv	are permitted provided that the following conditions are met:
// jakw	
// qcuv	  * Redistribution's of source code must retain the above copyright notice,
// jsup	    this list of conditions and the following disclaimer.
// jdxk	
// uuuf	  * Redistribution's in binary form must reproduce the above copyright notice,
// naph	    this list of conditions and the following disclaimer in the documentation
// hiwt	    and/or other materials provided with the distribution.
// svxh	
// baun	  * Neither the name of the copyright holders nor the names of its contributors 
// tfpt	    may not be used to endorse or promote products derived from this software 
// pblv	    without specific prior written permission.
// wtnr	
// wkux	This software is provided by the copyright holders and contributors "as is" and
// idhi	any express or implied warranties, including, but not limited to, the implied
// kdoi	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fbco	In no event shall the Prince of Songkla University or contributors be liable 
// unoi	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jkqp	(including, but not limited to, procurement of substitute goods or services;
// ebql	loss of use, data, or profits; or business interruption) however caused
// ptko	and on any theory of liability, whether in contract, strict liability,
// ufxi	or tort (including negligence or otherwise) arising in any way out of
// aayy	the use of this software, even if advised of the possibility of such damage.
// tlcp	
// qhnn	Intelligent Systems Laboratory (iSys Lab)
// yxbj	Faculty of Engineering, Prince of Songkla University, THAILAND
// eehl	Project leader by Nikom SUVONVORN
// tftg	Project website at http://code.google.com/p/openvss/

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

namespace Vs.Analyzer.MatchImage
{
    public class VsMatchImage : VsCoreAnalyzer, IDisposable
    {
		private int		width;	// image width
		private int		height;	// image height
        private VsCvMatchImage cvAlgo = null;

		// Constructor
        public VsMatchImage(long syncTimer) : base(syncTimer, 2, 1)
		{
            
		}
		// Constructor
        ~VsMatchImage()
        {
            cvAlgo.Dispose();
        }

        
		// Reset detector to initial state
		public void Reset( )
		{
		}

		// Process new frame
        public override void process_Frame2(VsImage lastFrame1, VsImage lastFrame2)
        {
            try
            {
                if (cvAlgo == null)
                {
                    width = lastFrame1.Image.Width;
                    height = lastFrame1.Image.Height;
                    cvAlgo = new VsCvMatchImage(2, 1, width, height, cvDepth.Depth8U, 3);
                    cvAlgo.VsInit();
                    return;
                }

                cvAlgo.VsConfiguration(int.Parse(AnalyzerConfiguration["ThresholdStrong"].ToString()));
                lastFrame1.Image = cvAlgo.VsProcess(lastFrame1.Image, lastFrame2.Image);
                lastFrame1.Result = cvAlgo.VsResult();
                lastFrame1.IsAnalyzed = true;
                lastFrame1.IsDetected = true;
            }
            catch { }
    	}
    }
}
