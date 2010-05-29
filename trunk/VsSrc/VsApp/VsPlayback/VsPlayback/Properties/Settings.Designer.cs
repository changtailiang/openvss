// cxsw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// inff	
// fukz	 By downloading, copying, installing or using the software you agree to this license.
// zlgo	 If you do not agree to this license, do not download, install,
// sdde	 copy or use the software.
// lqtq	
// mrup	                          License Agreement
// nrun	         For OpenVSS - Open Source Video Surveillance System
// exjs	
// yspw	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// yoge	
// mhgj	Third party copyrights are property of their respective owners.
// lcwm	
// eszl	Redistribution and use in source and binary forms, with or without modification,
// ecjr	are permitted provided that the following conditions are met:
// sqro	
// awuc	  * Redistribution's of source code must retain the above copyright notice,
// cnqa	    this list of conditions and the following disclaimer.
// nhfx	
// jodf	  * Redistribution's in binary form must reproduce the above copyright notice,
// lkel	    this list of conditions and the following disclaimer in the documentation
// uhjl	    and/or other materials provided with the distribution.
// xyow	
// jydi	  * Neither the name of the copyright holders nor the names of its contributors 
// wseq	    may not be used to endorse or promote products derived from this software 
// mdhx	    without specific prior written permission.
// lwyx	
// nbbp	This software is provided by the copyright holders and contributors "as is" and
// ydfi	any express or implied warranties, including, but not limited to, the implied
// mgts	warranties of merchantability and fitness for a particular purpose are disclaimed.
// miee	In no event shall the Prince of Songkla University or contributors be liable 
// zuqp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dxbr	(including, but not limited to, procurement of substitute goods or services;
// jnsh	loss of use, data, or profits; or business interruption) however caused
// dhzy	and on any theory of liability, whether in contract, strict liability,
// jmyw	or tort (including negligence or otherwise) arising in any way out of
// wyxf	the use of this software, even if advised of the possibility of such damage.
// svwq	
// ymde	Intelligent Systems Laboratory (iSys Lab)
// zdxr	Faculty of Engineering, Prince of Songkla University, THAILAND
// fjuq	Project leader by Nikom SUVONVORN
// akgl	Project website at http://code.google.com/p/openvss/

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
        public string VsPlayback_VsService_VsService {
            get {
                return ((string)(this["VsPlayback_VsService_VsService"]));
            }
        }
    }
}
