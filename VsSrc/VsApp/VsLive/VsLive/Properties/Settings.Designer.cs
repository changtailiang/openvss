// klio	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// qscs	
// iprh	 By downloading, copying, installing or using the software you agree to this license.
// acnz	 If you do not agree to this license, do not download, install,
// psyp	 copy or use the software.
// dgxv	
// xhqz	                          License Agreement
// bjom	         For OpenVSS - Open Source Video Surveillance System
// jatu	
// mjru	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// pvcd	
// rryr	Third party copyrights are property of their respective owners.
// xeju	
// celd	Redistribution and use in source and binary forms, with or without modification,
// nmqi	are permitted provided that the following conditions are met:
// bdqy	
// bfxa	  * Redistribution's of source code must retain the above copyright notice,
// itmf	    this list of conditions and the following disclaimer.
// bdzh	
// euef	  * Redistribution's in binary form must reproduce the above copyright notice,
// jycx	    this list of conditions and the following disclaimer in the documentation
// atjf	    and/or other materials provided with the distribution.
// opga	
// sjsm	  * Neither the name of the copyright holders nor the names of its contributors 
// fdcl	    may not be used to endorse or promote products derived from this software 
// uyjd	    without specific prior written permission.
// sdtz	
// edzs	This software is provided by the copyright holders and contributors "as is" and
// ilzd	any express or implied warranties, including, but not limited to, the implied
// atyh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wslt	In no event shall the Prince of Songkla University or contributors be liable 
// nmnr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// lnca	(including, but not limited to, procurement of substitute goods or services;
// sslk	loss of use, data, or profits; or business interruption) however caused
// pyfx	and on any theory of liability, whether in contract, strict liability,
// zkbk	or tort (including negligence or otherwise) arising in any way out of
// pnrh	the use of this software, even if advised of the possibility of such damage.
// kpll	
// fupb	Intelligent Systems Laboratory (iSys Lab)
// mppf	Faculty of Engineering, Prince of Songkla University, THAILAND
// pcor	Project leader by Nikom SUVONVORN
// bzap	Project website at http://code.google.com/p/openvss/

namespace Vs.Monitor.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost/vsservice/Service.asmx")]
        public string VsLive_VsService_VsService {
            get {
                return ((string)(this["VsLive_VsService_VsService"]));
            }
        }
    }
}
