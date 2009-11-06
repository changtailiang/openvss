// tlqo	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// qoha	
// hujz	 By downloading, copying, installing or using the software you agree to this license.
// fdqg	 If you do not agree to this license, do not download, install,
// rsqv	 copy or use the software.
// ozno	
// pyyg	                          License Agreement
// godl	         For OpenVss - Open Source Video Surveillance System
// wxek	
// zwtt	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// scbw	
// ohez	Third party copyrights are property of their respective owners.
// prui	
// vytt	Redistribution and use in source and binary forms, with or without modification,
// xbzr	are permitted provided that the following conditions are met:
// qbut	
// rxdh	  * Redistribution's of source code must retain the above copyright notice,
// yggu	    this list of conditions and the following disclaimer.
// yxcl	
// xrai	  * Redistribution's in binary form must reproduce the above copyright notice,
// uzqp	    this list of conditions and the following disclaimer in the documentation
// tvqx	    and/or other materials provided with the distribution.
// dkny	
// xbcr	  * Neither the name of the copyright holders nor the names of its contributors 
// iifq	    may not be used to endorse or promote products derived from this software 
// dwaj	    without specific prior written permission.
// kzjx	
// vhvf	This software is provided by the copyright holders and contributors "as is" and
// brxr	any express or implied warranties, including, but not limited to, the implied
// keav	warranties of merchantability and fitness for a particular purpose are disclaimed.
// gfeo	In no event shall the Prince of Songkla University or contributors be liable 
// tixw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// uldp	(including, but not limited to, procurement of substitute goods or services;
// mjex	loss of use, data, or profits; or business interruption) however caused
// zhet	and on any theory of liability, whether in contract, strict liability,
// lscw	or tort (including negligence or otherwise) arising in any way out of
// ohwg	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Vs.Core.Image
{
    // New Image delegate
    public delegate void VsDataEventHandler(object sender, VsDataEventArgs e);

    /// <summary>
    /// Camera event arguments
    /// </summary>
    public class VsDataEventArgs : EventArgs
    {
        private VsData vsdata;

        // Constructor
        public VsDataEventArgs(VsData dt)
        {
            vsdata = dt;
        }

        // Image property
        public VsData Data
        {
            get { return vsdata; }
        }
    }
}
