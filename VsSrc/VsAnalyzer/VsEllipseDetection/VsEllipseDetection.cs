// bcwp	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ieuu	
// zcyg	 By downloading, copying, installing or using the software you agree to this license.
// rizy	 If you do not agree to this license, do not download, install,
// ipaz	 copy or use the software.
// pomy	
// nfsp	                          License Agreement
// dszq	         For OpenVSS - Open Source Video Surveillance System
// aupo	
// eycr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// pcgd	
// akgi	Third party copyrights are property of their respective owners.
// tepz	
// zncn	Redistribution and use in source and binary forms, with or without modification,
// qybc	are permitted provided that the following conditions are met:
// merh	
// cigw	  * Redistribution's of source code must retain the above copyright notice,
// tltj	    this list of conditions and the following disclaimer.
// mjjm	
// hiyd	  * Redistribution's in binary form must reproduce the above copyright notice,
// zjwy	    this list of conditions and the following disclaimer in the documentation
// czrm	    and/or other materials provided with the distribution.
// rbyg	
// wzel	  * Neither the name of the copyright holders nor the names of its contributors 
// lzas	    may not be used to endorse or promote products derived from this software 
// ekph	    without specific prior written permission.
// lfmp	
// dqgh	This software is provided by the copyright holders and contributors "as is" and
// aydd	any express or implied warranties, including, but not limited to, the implied
// hsfd	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qtes	In no event shall the Prince of Songkla University or contributors be liable 
// mmnm	for any direct, indirect, incidental, special, exemplary, or consequential damages
// exbi	(including, but not limited to, procurement of substitute goods or services;
// ifzp	loss of use, data, or profits; or business interruption) however caused
// uonw	and on any theory of liability, whether in contract, strict liability,
// mbib	or tort (including negligence or otherwise) arising in any way out of
// vrgx	the use of this software, even if advised of the possibility of such damage.
// wbds	
// uwbk	Intelligent Systems Laboratory (iSys Lab)
// fwuz	Faculty of Engineering, Prince of Songkla University, THAILAND
// szlf	Project leader by Nikom SUVONVORN
// oyyu	Project website at http://code.google.com/p/openvss/

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
