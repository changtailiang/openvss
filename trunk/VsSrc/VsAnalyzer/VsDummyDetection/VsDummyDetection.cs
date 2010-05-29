// pvmg	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// gbpn	
// qxzk	 By downloading, copying, installing or using the software you agree to this license.
// qmsv	 If you do not agree to this license, do not download, install,
// ggqw	 copy or use the software.
// gkir	
// jbha	                          License Agreement
// itoc	         For OpenVSS - Open Source Video Surveillance System
// dstb	
// jmxk	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// bzrq	
// knjn	Third party copyrights are property of their respective owners.
// wkiz	
// fipe	Redistribution and use in source and binary forms, with or without modification,
// nuwe	are permitted provided that the following conditions are met:
// upex	
// iwhx	  * Redistribution's of source code must retain the above copyright notice,
// tqlu	    this list of conditions and the following disclaimer.
// jgvg	
// trhv	  * Redistribution's in binary form must reproduce the above copyright notice,
// stdy	    this list of conditions and the following disclaimer in the documentation
// kpxv	    and/or other materials provided with the distribution.
// doop	
// pspm	  * Neither the name of the copyright holders nor the names of its contributors 
// vthn	    may not be used to endorse or promote products derived from this software 
// gluf	    without specific prior written permission.
// yopy	
// nikv	This software is provided by the copyright holders and contributors "as is" and
// nama	any express or implied warranties, including, but not limited to, the implied
// lgmt	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zltf	In no event shall the Prince of Songkla University or contributors be liable 
// cweq	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rila	(including, but not limited to, procurement of substitute goods or services;
// jtpg	loss of use, data, or profits; or business interruption) however caused
// zxaw	and on any theory of liability, whether in contract, strict liability,
// zziv	or tort (including negligence or otherwise) arising in any way out of
// dsco	the use of this software, even if advised of the possibility of such damage.
// fpbo	
// hoou	Intelligent Systems Laboratory (iSys Lab)
// spdb	Faculty of Engineering, Prince of Songkla University, THAILAND
// jyhe	Project leader by Nikom SUVONVORN
// wklt	Project website at http://code.google.com/p/openvss/

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
