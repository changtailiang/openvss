// snrj	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rxks	
// flpm	 By downloading, copying, installing or using the software you agree to this license.
// fkzm	 If you do not agree to this license, do not download, install,
// kbxp	 copy or use the software.
// qlvd	
// xbkw	                          License Agreement
// hdyr	         For OpenVss - Open Source Video Surveillance System
// bibm	
// cfms	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// myux	
// gwhi	Third party copyrights are property of their respective owners.
// vzrs	
// pnnh	Redistribution and use in source and binary forms, with or without modification,
// somp	are permitted provided that the following conditions are met:
// mnlc	
// nxkx	  * Redistribution's of source code must retain the above copyright notice,
// imjf	    this list of conditions and the following disclaimer.
// ofds	
// qxxb	  * Redistribution's in binary form must reproduce the above copyright notice,
// tcai	    this list of conditions and the following disclaimer in the documentation
// lgbo	    and/or other materials provided with the distribution.
// vtuo	
// twfy	  * Neither the name of the copyright holders nor the names of its contributors 
// nski	    may not be used to endorse or promote products derived from this software 
// lkzi	    without specific prior written permission.
// qldk	
// juqu	This software is provided by the copyright holders and contributors "as is" and
// rkwk	any express or implied warranties, including, but not limited to, the implied
// mcqh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vvco	In no event shall the Prince of Songkla University or contributors be liable 
// sumr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// zefy	(including, but not limited to, procurement of substitute goods or services;
// nopj	loss of use, data, or profits; or business interruption) however caused
// crsa	and on any theory of liability, whether in contract, strict liability,
// crea	or tort (including negligence or otherwise) arising in any way out of
// dzxi	the use of this software, even if advised of the possibility of such damage.

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
