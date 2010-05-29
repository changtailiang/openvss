// juit	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// jygj	
// ulgk	 By downloading, copying, installing or using the software you agree to this license.
// dvpf	 If you do not agree to this license, do not download, install,
// sddd	 copy or use the software.
// jmmf	
// qlyn	                          License Agreement
// hbcn	         For OpenVSS - Open Source Video Surveillance System
// bitf	
// vyfw	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// veeo	
// dmeh	Third party copyrights are property of their respective owners.
// pfek	
// laxw	Redistribution and use in source and binary forms, with or without modification,
// iccx	are permitted provided that the following conditions are met:
// zsct	
// isju	  * Redistribution's of source code must retain the above copyright notice,
// bkku	    this list of conditions and the following disclaimer.
// xhhf	
// ixbe	  * Redistribution's in binary form must reproduce the above copyright notice,
// hrxb	    this list of conditions and the following disclaimer in the documentation
// wsca	    and/or other materials provided with the distribution.
// kwws	
// wiwc	  * Neither the name of the copyright holders nor the names of its contributors 
// clgk	    may not be used to endorse or promote products derived from this software 
// cjff	    without specific prior written permission.
// vkmd	
// tsol	This software is provided by the copyright holders and contributors "as is" and
// byqi	any express or implied warranties, including, but not limited to, the implied
// vawq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qikf	In no event shall the Prince of Songkla University or contributors be liable 
// osxp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// kecx	(including, but not limited to, procurement of substitute goods or services;
// rqby	loss of use, data, or profits; or business interruption) however caused
// lsgl	and on any theory of liability, whether in contract, strict liability,
// fyhr	or tort (including negligence or otherwise) arising in any way out of
// hlqx	the use of this software, even if advised of the possibility of such damage.
// rohb	
// optu	Intelligent Systems Laboratory (iSys Lab)
// yard	Faculty of Engineering, Prince of Songkla University, THAILAND
// mxtp	Project leader by Nikom SUVONVORN
// prtk	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Encoder;

namespace Vs.Encoder.Avi
{
    class VsRawEncoderDescription : VsICoreEncoderDescription
    {
        private string encoderName;

        public VsRawEncoderDescription()
        {
            encoderName = "VsAviEncoderDescription";
        }

        VsICoreEncoder VsICoreEncoderDescription.CreateEncoder(long syncTimer, object config)
        {
            VsRawEncoderConfiguration cfg = (VsRawEncoderConfiguration)config;

            if (cfg != null)
            {
                VsRawEncoder encoder = new VsRawEncoder(syncTimer);

                encoder.EncoderName = cfg.CodecsName;

                return (VsRawEncoder)encoder;
            }
            return null;
        }

        string VsICoreEncoderDescription.Description
        {
            get { return encoderName; }
        }

        VsICoreEncoderPage VsICoreEncoderDescription.GetSettingsPage()
        {
            return new VsRawEncoderSetupPage(); 
        }

        object VsICoreEncoderDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsRawEncoderConfiguration config = new VsRawEncoderConfiguration();

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
            VsRawEncoderConfiguration config = new VsRawEncoderConfiguration();

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
            get { return "Raw Encoder"; }
        }

        void VsICoreEncoderDescription.SaveConfiguration(System.Xml.XmlTextWriter writer, object config)
        {
            VsRawEncoderConfiguration cfg = (VsRawEncoderConfiguration)config;

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
