// waft	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// odxe	
// ntmx	 By downloading, copying, installing or using the software you agree to this license.
// dawf	 If you do not agree to this license, do not download, install,
// zbkg	 copy or use the software.
// vyno	
// uqnf	                          License Agreement
// jwll	         For OpenVSS - Open Source Video Surveillance System
// yyul	
// imvq	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// pcbk	
// npsx	Third party copyrights are property of their respective owners.
// aody	
// lcwx	Redistribution and use in source and binary forms, with or without modification,
// mqyx	are permitted provided that the following conditions are met:
// qruq	
// haze	  * Redistribution's of source code must retain the above copyright notice,
// glxn	    this list of conditions and the following disclaimer.
// fuqs	
// xdbe	  * Redistribution's in binary form must reproduce the above copyright notice,
// yqev	    this list of conditions and the following disclaimer in the documentation
// tnzv	    and/or other materials provided with the distribution.
// bwyr	
// nyax	  * Neither the name of the copyright holders nor the names of its contributors 
// ilcm	    may not be used to endorse or promote products derived from this software 
// qnrp	    without specific prior written permission.
// qqsr	
// leaj	This software is provided by the copyright holders and contributors "as is" and
// ptya	any express or implied warranties, including, but not limited to, the implied
// nyxu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bedj	In no event shall the Prince of Songkla University or contributors be liable 
// mgzh	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ttkl	(including, but not limited to, procurement of substitute goods or services;
// bool	loss of use, data, or profits; or business interruption) however caused
// yofc	and on any theory of liability, whether in contract, strict liability,
// uijx	or tort (including negligence or otherwise) arising in any way out of
// wpct	the use of this software, even if advised of the possibility of such damage.
// zakk	
// nhll	Intelligent Systems Laboratory (iSys Lab)
// jidk	Faculty of Engineering, Prince of Songkla University, THAILAND
// qlys	Project leader by Nikom SUVONVORN
// toib	Project website at http://code.google.com/p/openvss/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace VsCoreMobile
{
    public interface VsInterface
    {
        

        void VsMWlogin();
        void getCameraList();
        void Live();
        void LiveJpeg();
        void WorkerThread();
        void motionSelected();
    }
}
