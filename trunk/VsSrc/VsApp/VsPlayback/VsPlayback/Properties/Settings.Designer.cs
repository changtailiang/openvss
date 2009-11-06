// mtlc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ryfa	
// koet	 By downloading, copying, installing or using the software you agree to this license.
// gwhk	 If you do not agree to this license, do not download, install,
// fhwv	 copy or use the software.
// solk	
// tibf	                          License Agreement
// jpjr	         For OpenVss - Open Source Video Surveillance System
// nevp	
// eaky	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// fhps	
// uief	Third party copyrights are property of their respective owners.
// ukwp	
// cfbx	Redistribution and use in source and binary forms, with or without modification,
// iaij	are permitted provided that the following conditions are met:
// warv	
// engb	  * Redistribution's of source code must retain the above copyright notice,
// argf	    this list of conditions and the following disclaimer.
// wxpl	
// zsqk	  * Redistribution's in binary form must reproduce the above copyright notice,
// dwly	    this list of conditions and the following disclaimer in the documentation
// suoh	    and/or other materials provided with the distribution.
// dyhd	
// sabe	  * Neither the name of the copyright holders nor the names of its contributors 
// ptog	    may not be used to endorse or promote products derived from this software 
// ccec	    without specific prior written permission.
// erse	
// qpyp	This software is provided by the copyright holders and contributors "as is" and
// kxfa	any express or implied warranties, including, but not limited to, the implied
// ptck	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zyyc	In no event shall the Prince of Songkla University or contributors be liable 
// jdnv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wkwf	(including, but not limited to, procurement of substitute goods or services;
// ekib	loss of use, data, or profits; or business interruption) however caused
// riub	and on any theory of liability, whether in contract, strict liability,
// bkrn	or tort (including negligence or otherwise) arising in any way out of
// zssu	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Playback.Properties {
    
    
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
        public string VsClient_VsService_VsService {
            get {
                return ((string)(this["VsClient_VsService_VsService"]));
            }
        }
    }
}
