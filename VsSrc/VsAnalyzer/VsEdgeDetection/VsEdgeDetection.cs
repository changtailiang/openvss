// vgpu	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ydbl	
// pgpu	 By downloading, copying, installing or using the software you agree to this license.
// vymq	 If you do not agree to this license, do not download, install,
// hiaa	 copy or use the software.
// xoer	
// yned	                          License Agreement
// jqpc	         For OpenVss - Open Source Video Surveillance System
// fgja	
// kxki	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// bqni	
// wzcb	Third party copyrights are property of their respective owners.
// sbwj	
// qfpg	Redistribution and use in source and binary forms, with or without modification,
// cyvl	are permitted provided that the following conditions are met:
// zycy	
// rmoo	  * Redistribution's of source code must retain the above copyright notice,
// omgj	    this list of conditions and the following disclaimer.
// ysyh	
// awvz	  * Redistribution's in binary form must reproduce the above copyright notice,
// kdlh	    this list of conditions and the following disclaimer in the documentation
// tgmz	    and/or other materials provided with the distribution.
// qcyl	
// cyjd	  * Neither the name of the copyright holders nor the names of its contributors 
// norj	    may not be used to endorse or promote products derived from this software 
// komf	    without specific prior written permission.
// vmky	
// higf	This software is provided by the copyright holders and contributors "as is" and
// dvbv	any express or implied warranties, including, but not limited to, the implied
// mufk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zoym	In no event shall the Prince of Songkla University or contributors be liable 
// ouhz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jutl	(including, but not limited to, procurement of substitute goods or services;
// flpw	loss of use, data, or profits; or business interruption) however caused
// rflg	and on any theory of liability, whether in contract, strict liability,
// vosh	or tort (including negligence or otherwise) arising in any way out of
// wsih	the use of this software, even if advised of the possibility of such damage.

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

namespace Vs.Analyzer.EdgeDetection
{
    public class VsEdgeDetection : VsCoreAnalyzer, IDisposable
    {
        //private string analyserName;
        private bool calculateMotionLevel = false;
		private int		width;	// image width
		private int		height;	// image height
		private double		pixelsChanged;
        private VsCvEdgeDetection cvAlgo = null;

		// Motion level calculation - calculate or not motion level
		public bool MotionLevelCalculation
		{
			get { return calculateMotionLevel; }
			set { calculateMotionLevel = value; }
		}

		// Constructor
        public VsEdgeDetection(long syncTimer) : base(syncTimer, 1, 1)
		{
            
		}
		// Constructor
        ~VsEdgeDetection()
        {
            if(cvAlgo!=null) cvAlgo.Dispose();
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
                    cvAlgo = new VsCvEdgeDetection(1, 1, width, height, cvDepth.Depth8U, 3);
                    cvAlgo.VsInit();
                    return;
                }

                cvAlgo.VsConfiguration(int.Parse(AnalyzerConfiguration["ThresholdStrong"].ToString()),
                    int.Parse(AnalyzerConfiguration["ThresholdWeak"].ToString()));
                lastFrame.Image = cvAlgo.VsProcess(lastFrame.Image);
                lastFrame.Result = cvAlgo.VsResult();
                lastFrame.IsAnalyzed = true;
                lastFrame.IsDetected = true;
            }
            catch { }
    	}
    }
}
