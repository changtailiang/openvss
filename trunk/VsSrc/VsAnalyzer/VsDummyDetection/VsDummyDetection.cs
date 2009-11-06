// zjoq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// tsni	
// tysj	 By downloading, copying, installing or using the software you agree to this license.
// nbvi	 If you do not agree to this license, do not download, install,
// knds	 copy or use the software.
// uetx	
// iylx	                          License Agreement
// byex	         For OpenVss - Open Source Video Surveillance System
// uavu	
// cube	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// sisv	
// tnur	Third party copyrights are property of their respective owners.
// pnbi	
// fxju	Redistribution and use in source and binary forms, with or without modification,
// prhu	are permitted provided that the following conditions are met:
// hqgu	
// uupn	  * Redistribution's of source code must retain the above copyright notice,
// fbgq	    this list of conditions and the following disclaimer.
// lzal	
// lxdu	  * Redistribution's in binary form must reproduce the above copyright notice,
// etio	    this list of conditions and the following disclaimer in the documentation
// wvrx	    and/or other materials provided with the distribution.
// qael	
// mgwb	  * Neither the name of the copyright holders nor the names of its contributors 
// cyaz	    may not be used to endorse or promote products derived from this software 
// yhln	    without specific prior written permission.
// glwg	
// xyjs	This software is provided by the copyright holders and contributors "as is" and
// omqo	any express or implied warranties, including, but not limited to, the implied
// irxz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// crxf	In no event shall the Prince of Songkla University or contributors be liable 
// wvdf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// cyjn	(including, but not limited to, procurement of substitute goods or services;
// wewx	loss of use, data, or profits; or business interruption) however caused
// huhl	and on any theory of liability, whether in contract, strict liability,
// ylas	or tort (including negligence or otherwise) arising in any way out of
// rmwa	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using Vs.Core.Analyzer;
using Vs.Core.Image;

namespace Vs.Analyzer.DummyDetection
{
    public class VsDummyDetection : VsCoreAnalyzer, IDisposable
    {
		// Constructor
        public VsDummyDetection(long syncTimer)
            : base(syncTimer, 1, 1)
		{
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(true);
        }

        // Process new frame
        public override void process_Frame1(VsImage lastFrame)
        {
            lastFrame.Result = "";
            lastFrame.IsAnalyzed = true;
            lastFrame.IsDetected = true;
        }
    }
}
