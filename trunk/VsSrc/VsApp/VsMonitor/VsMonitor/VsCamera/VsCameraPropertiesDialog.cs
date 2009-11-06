// qwll	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// cxmd	
// uimw	 By downloading, copying, installing or using the software you agree to this license.
// hbwk	 If you do not agree to this license, do not download, install,
// orzn	 copy or use the software.
// ijoe	
// omcg	                          License Agreement
// nrbs	         For OpenVss - Open Source Video Surveillance System
// wbdv	
// eojw	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// btto	
// cxkc	Third party copyrights are property of their respective owners.
// clne	
// kmyh	Redistribution and use in source and binary forms, with or without modification,
// ihwq	are permitted provided that the following conditions are met:
// vgpc	
// htzg	  * Redistribution's of source code must retain the above copyright notice,
// xaga	    this list of conditions and the following disclaimer.
// icmo	
// pacr	  * Redistribution's in binary form must reproduce the above copyright notice,
// cadb	    this list of conditions and the following disclaimer in the documentation
// exhk	    and/or other materials provided with the distribution.
// cwnx	
// rsbu	  * Neither the name of the copyright holders nor the names of its contributors 
// drhi	    may not be used to endorse or promote products derived from this software 
// xdeb	    without specific prior written permission.
// fnwh	
// akrh	This software is provided by the copyright holders and contributors "as is" and
// ffov	any express or implied warranties, including, but not limited to, the implied
// coxk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// lpdb	In no event shall the Prince of Songkla University or contributors be liable 
// njip	for any direct, indirect, incidental, special, exemplary, or consequential damages
// brky	(including, but not limited to, procurement of substitute goods or services;
// ttty	loss of use, data, or profits; or business interruption) however caused
// vcwr	and on any theory of liability, whether in contract, strict liability,
// aaks	or tort (including negligence or otherwise) arising in any way out of
// efrm	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Vs.Core;
using Vs.Core.Server;

namespace Vs.Monitor
{
	public class VsCameraPropertiesDialog : VsDialogWizard
	{
        private VsCoreServer vsCoreMonitor;
		private VsCameraDescription	    vsCameraDescription = new VsCameraDescription();
		private VsCameraSettings		vsCameraSetting = new VsCameraSettings();
        private VsAnalyzerSettings      vsAnalyzerSetting = new VsAnalyzerSettings();
        private VsEncoderSettings       vsEncoderSetting = new VsEncoderSettings();

		// Construction
        public VsCameraPropertiesDialog(VsCoreServer vsCore)
		{
			this.AddPage(vsCameraDescription);
			this.AddPage(vsCameraSetting);
            this.AddPage(vsAnalyzerSetting);
            this.AddPage(vsEncoderSetting);
            this.Text = "Add New Camera";

            // set current core
            vsCoreMonitor = vsCore;
            vsCameraDescription.CoreMonitor = vsCore;
            vsCameraSetting.CoreMonitor = vsCore;
            vsAnalyzerSetting.CoreMonitor = vsCore;
            vsEncoderSetting.CoreMonitor = vsCore;
        }

	}
}

