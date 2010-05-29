// kiht	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ubpq	
// smrn	 By downloading, copying, installing or using the software you agree to this license.
// dfgn	 If you do not agree to this license, do not download, install,
// empf	 copy or use the software.
// syof	
// iqww	                          License Agreement
// etmt	         For OpenVSS - Open Source Video Surveillance System
// jsmu	
// parz	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// kxlc	
// wpot	Third party copyrights are property of their respective owners.
// hxev	
// cpzm	Redistribution and use in source and binary forms, with or without modification,
// tcke	are permitted provided that the following conditions are met:
// fsmz	
// axdl	  * Redistribution's of source code must retain the above copyright notice,
// smyd	    this list of conditions and the following disclaimer.
// vqvv	
// mljt	  * Redistribution's in binary form must reproduce the above copyright notice,
// bcog	    this list of conditions and the following disclaimer in the documentation
// pqru	    and/or other materials provided with the distribution.
// taan	
// pmtr	  * Neither the name of the copyright holders nor the names of its contributors 
// kmcy	    may not be used to endorse or promote products derived from this software 
// ldav	    without specific prior written permission.
// zazl	
// udzi	This software is provided by the copyright holders and contributors "as is" and
// trcc	any express or implied warranties, including, but not limited to, the implied
// dfkj	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fjrs	In no event shall the Prince of Songkla University or contributors be liable 
// mkoi	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wdka	(including, but not limited to, procurement of substitute goods or services;
// jkhy	loss of use, data, or profits; or business interruption) however caused
// cthp	and on any theory of liability, whether in contract, strict liability,
// rgap	or tort (including negligence or otherwise) arising in any way out of
// aruy	the use of this software, even if advised of the possibility of such damage.
// krof	
// bstc	Intelligent Systems Laboratory (iSys Lab)
// lijo	Faculty of Engineering, Prince of Songkla University, THAILAND
// mqpr	Project leader by Nikom SUVONVORN
// tyzi	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Vs.Core.Analyzer;

namespace Vs.Analyzer.ObjectDetection
{
    class VsObjectDetectionConfiguration : VsICoreAnalyzerConfiguration
    {
        public int SelectedObject;

        public VsObjectDetectionConfiguration()
        {
            SelectedObject = 0;
        }

        public Hashtable GetConfiguration()
        {
            Hashtable config = new Hashtable();
            config.Add("SelectedObject", SelectedObject);
            return config;
        }

        public void LoadConfiguration(Hashtable config)
        {
            SelectedObject = int.Parse(config["SelectedObject"].ToString());
        }
    }
}
