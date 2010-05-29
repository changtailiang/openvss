// hkuy	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// zgii	
// ttzz	 By downloading, copying, installing or using the software you agree to this license.
// bpar	 If you do not agree to this license, do not download, install,
// dhum	 copy or use the software.
// agjt	
// gwee	                          License Agreement
// hksg	         For OpenVSS - Open Source Video Surveillance System
// ceca	
// hbwb	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// tgzy	
// rzav	Third party copyrights are property of their respective owners.
// oaqr	
// fqta	Redistribution and use in source and binary forms, with or without modification,
// aasd	are permitted provided that the following conditions are met:
// bdbj	
// bsxx	  * Redistribution's of source code must retain the above copyright notice,
// majb	    this list of conditions and the following disclaimer.
// lssu	
// glcg	  * Redistribution's in binary form must reproduce the above copyright notice,
// wjpg	    this list of conditions and the following disclaimer in the documentation
// uaal	    and/or other materials provided with the distribution.
// lcah	
// itap	  * Neither the name of the copyright holders nor the names of its contributors 
// eqxz	    may not be used to endorse or promote products derived from this software 
// bdio	    without specific prior written permission.
// qogm	
// yyto	This software is provided by the copyright holders and contributors "as is" and
// ylgs	any express or implied warranties, including, but not limited to, the implied
// ouoa	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rlmk	In no event shall the Prince of Songkla University or contributors be liable 
// absr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// scpp	(including, but not limited to, procurement of substitute goods or services;
// ocft	loss of use, data, or profits; or business interruption) however caused
// abqf	and on any theory of liability, whether in contract, strict liability,
// unnm	or tort (including negligence or otherwise) arising in any way out of
// jljw	the use of this software, even if advised of the possibility of such damage.
// mhbk	
// cwhp	Intelligent Systems Laboratory (iSys Lab)
// qyop	Faculty of Engineering, Prince of Songkla University, THAILAND
// vouv	Project leader by Nikom SUVONVORN
// idav	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InsertAssemblyInfo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VsInseartAssemblyInfo());
        }
    }
}
