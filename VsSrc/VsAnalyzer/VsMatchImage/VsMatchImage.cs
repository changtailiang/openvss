// uini	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// vnzg	
// rjit	 By downloading, copying, installing or using the software you agree to this license.
// tfmk	 If you do not agree to this license, do not download, install,
// kmwg	 copy or use the software.
// zwmy	
// fxhk	                          License Agreement
// scrp	         For OpenVss - Open Source Video Surveillance System
// vaqp	
// jprn	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// egdp	
// dttk	Third party copyrights are property of their respective owners.
// tfsy	
// uhox	Redistribution and use in source and binary forms, with or without modification,
// vody	are permitted provided that the following conditions are met:
// gpop	
// stys	  * Redistribution's of source code must retain the above copyright notice,
// pwau	    this list of conditions and the following disclaimer.
// ujcs	
// sxul	  * Redistribution's in binary form must reproduce the above copyright notice,
// exqm	    this list of conditions and the following disclaimer in the documentation
// jsun	    and/or other materials provided with the distribution.
// lsuv	
// mtgo	  * Neither the name of the copyright holders nor the names of its contributors 
// soxk	    may not be used to endorse or promote products derived from this software 
// vavw	    without specific prior written permission.
// fxel	
// fwfy	This software is provided by the copyright holders and contributors "as is" and
// uruj	any express or implied warranties, including, but not limited to, the implied
// zcfz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ykgw	In no event shall the Prince of Songkla University or contributors be liable 
// cfib	for any direct, indirect, incidental, special, exemplary, or consequential damages
// cnae	(including, but not limited to, procurement of substitute goods or services;
// zkqd	loss of use, data, or profits; or business interruption) however caused
// bthm	and on any theory of liability, whether in contract, strict liability,
// ojip	or tort (including negligence or otherwise) arising in any way out of
// mwau	the use of this software, even if advised of the possibility of such damage.

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
