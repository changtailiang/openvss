// ardt	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ndkd	
// glfn	 By downloading, copying, installing or using the software you agree to this license.
// cnfw	 If you do not agree to this license, do not download, install,
// pvnf	 copy or use the software.
// sdni	
// dcvz	                          License Agreement
// mncp	         For OpenVSS - Open Source Video Surveillance System
// luqi	
// cbyf	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// jfqi	
// jbdn	Third party copyrights are property of their respective owners.
// szqu	
// ectw	Redistribution and use in source and binary forms, with or without modification,
// evpk	are permitted provided that the following conditions are met:
// ilqt	
// iqch	  * Redistribution's of source code must retain the above copyright notice,
// xxto	    this list of conditions and the following disclaimer.
// wiwn	
// neyb	  * Redistribution's in binary form must reproduce the above copyright notice,
// zign	    this list of conditions and the following disclaimer in the documentation
// wiki	    and/or other materials provided with the distribution.
// aueg	
// lnxy	  * Neither the name of the copyright holders nor the names of its contributors 
// oxzs	    may not be used to endorse or promote products derived from this software 
// yvpv	    without specific prior written permission.
// fbxw	
// ggiz	This software is provided by the copyright holders and contributors "as is" and
// wnlz	any express or implied warranties, including, but not limited to, the implied
// ecwa	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fugc	In no event shall the Prince of Songkla University or contributors be liable 
// sndi	for any direct, indirect, incidental, special, exemplary, or consequential damages
// lyyq	(including, but not limited to, procurement of substitute goods or services;
// efcd	loss of use, data, or profits; or business interruption) however caused
// sliu	and on any theory of liability, whether in contract, strict liability,
// lobu	or tort (including negligence or otherwise) arising in any way out of
// lejx	the use of this software, even if advised of the possibility of such damage.
// cxtl	
// azne	Intelligent Systems Laboratory (iSys Lab)
// pncs	Faculty of Engineering, Prince of Songkla University, THAILAND
// yoki	Project leader by Nikom SUVONVORN
// irur	Project website at http://code.google.com/p/openvss/

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

namespace Vs.Analyzer.ObjectDetection
{
    public class VsObjectDetection : VsCoreAnalyzer, IDisposable
    {
        //private string analyserName;
        private bool calculateMotionLevel = false;
		private int		width;	// image width
		private int		height;	// image height
		private double		pixelsChanged;
        private VsCvObjectDetection cvAlgo = null;

		// Motion level calculation - calculate or not motion level
		public bool MotionLevelCalculation
		{
			get { return calculateMotionLevel; }
			set { calculateMotionLevel = value; }
		}

		// Constructor
        public VsObjectDetection(long syncTimer) : base(syncTimer, 1, 1)
		{
            
		}
		// Constructor
        ~VsObjectDetection()
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
                    cvAlgo = new VsCvObjectDetection(1, 1, width, height, cvDepth.Depth8U, 3);
                    cvAlgo.VsInit();
                    return;
                }

                cvAlgo.VsConfiguration(int.Parse(AnalyzerConfiguration["SelectedObject"].ToString()));
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
