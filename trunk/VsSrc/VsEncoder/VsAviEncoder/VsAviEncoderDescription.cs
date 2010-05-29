// oxpk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// noyx	
// xibv	 By downloading, copying, installing or using the software you agree to this license.
// bszz	 If you do not agree to this license, do not download, install,
// peur	 copy or use the software.
// iwat	
// ybad	                          License Agreement
// tlaj	         For OpenVSS - Open Source Video Surveillance System
// dfaw	
// oofe	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// bogo	
// blrk	Third party copyrights are property of their respective owners.
// tpkz	
// ptjs	Redistribution and use in source and binary forms, with or without modification,
// wwlm	are permitted provided that the following conditions are met:
// nudm	
// isrw	  * Redistribution's of source code must retain the above copyright notice,
// rclb	    this list of conditions and the following disclaimer.
// zppu	
// pmrn	  * Redistribution's in binary form must reproduce the above copyright notice,
// jqke	    this list of conditions and the following disclaimer in the documentation
// batk	    and/or other materials provided with the distribution.
// vias	
// csrg	  * Neither the name of the copyright holders nor the names of its contributors 
// kufj	    may not be used to endorse or promote products derived from this software 
// tvsq	    without specific prior written permission.
// dizz	
// dpck	This software is provided by the copyright holders and contributors "as is" and
// eycw	any express or implied warranties, including, but not limited to, the implied
// kzkh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// yhbj	In no event shall the Prince of Songkla University or contributors be liable 
// csyg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// yikv	(including, but not limited to, procurement of substitute goods or services;
// giuo	loss of use, data, or profits; or business interruption) however caused
// xtas	and on any theory of liability, whether in contract, strict liability,
// bthf	or tort (including negligence or otherwise) arising in any way out of
// fpne	the use of this software, even if advised of the possibility of such damage.
// quwk	
// jykm	Intelligent Systems Laboratory (iSys Lab)
// ujok	Faculty of Engineering, Prince of Songkla University, THAILAND
// ksbu	Project leader by Nikom SUVONVORN
// fhdw	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Encoder;

namespace Vs.Encoder.Avi
{
    class VsAviEncoderDescription : VsICoreEncoderDescription
    {
        private string encoderName;

        public VsAviEncoderDescription()
        {
            encoderName = "VsAviEncoderDescription";
        }

        VsICoreEncoder VsICoreEncoderDescription.CreateEncoder(long syncTimer, object config)
        {
            VsAviEncoderConfiguration cfg = (VsAviEncoderConfiguration)config;

            if (cfg != null)
            {
                VsAviEncoder encoder = new VsAviEncoder(syncTimer);

                encoder.EncoderName = cfg.CodecsName;

                return (VsAviEncoder)encoder;
            }
            return null;
        }

        string VsICoreEncoderDescription.Description
        {
            get { return encoderName; }
        }

        VsICoreEncoderPage VsICoreEncoderDescription.GetSettingsPage()
        {
            return new VsAviEncoderSetupPage(); 
        }

        object VsICoreEncoderDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsAviEncoderConfiguration config = new VsAviEncoderConfiguration();

            try
            {
                config.ImageWidth = int.Parse(reader.GetAttribute("ImageWidth"));
                config.ImageHeight = int.Parse(reader.GetAttribute("ImageHeight"));
                config.CodecsName = reader.GetAttribute("CodecsName");
                config.Quality = int.Parse(reader.GetAttribute("Quality"));
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

        object VsICoreEncoderDescription.LoadConfiguration(Hashtable reader)
        {
            VsAviEncoderConfiguration config = new VsAviEncoderConfiguration();

            try
            {
                config.ImageWidth = int.Parse((string)reader["ImageWidth"]);
                config.ImageHeight = int.Parse((string)reader["ImageHeight"]);
                config.CodecsName = (string)reader["CodecsName"];
                config.Quality = int.Parse((string)reader["Quality"]);
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

        string VsICoreEncoderDescription.Name
        {
            get { return "AVI Encoder"; }
        }

        void VsICoreEncoderDescription.SaveConfiguration(System.Xml.XmlTextWriter writer, object config)
        {
            VsAviEncoderConfiguration cfg = (VsAviEncoderConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("ImageWidth", cfg.ImageWidth.ToString());
                writer.WriteAttributeString("ImageHeight", cfg.ImageHeight.ToString());
                writer.WriteAttributeString("CodecsName", cfg.CodecsName);
                writer.WriteAttributeString("Quality", cfg.Quality.ToString());
            }
        }
    }
}
