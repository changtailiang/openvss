// qqzc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// crua	
// yaht	 By downloading, copying, installing or using the software you agree to this license.
// uzwy	 If you do not agree to this license, do not download, install,
// wxcy	 copy or use the software.
// mupu	
// qfof	                          License Agreement
// onyz	         For OpenVss - Open Source Video Surveillance System
// npsc	
// dfqa	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// nzws	
// hpxu	Third party copyrights are property of their respective owners.
// qach	
// gjtw	Redistribution and use in source and binary forms, with or without modification,
// aelw	are permitted provided that the following conditions are met:
// cplk	
// biff	  * Redistribution's of source code must retain the above copyright notice,
// htvq	    this list of conditions and the following disclaimer.
// gckm	
// xxma	  * Redistribution's in binary form must reproduce the above copyright notice,
// itoo	    this list of conditions and the following disclaimer in the documentation
// krse	    and/or other materials provided with the distribution.
// wwcy	
// tuxx	  * Neither the name of the copyright holders nor the names of its contributors 
// olqz	    may not be used to endorse or promote products derived from this software 
// ksnx	    without specific prior written permission.
// embd	
// ygyc	This software is provided by the copyright holders and contributors "as is" and
// sloi	any express or implied warranties, including, but not limited to, the implied
// bwzk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pajl	In no event shall the Prince of Songkla University or contributors be liable 
// rwwl	for any direct, indirect, incidental, special, exemplary, or consequential damages
// fmyl	(including, but not limited to, procurement of substitute goods or services;
// hmqq	loss of use, data, or profits; or business interruption) however caused
// grky	and on any theory of liability, whether in contract, strict liability,
// qpgq	or tort (including negligence or otherwise) arising in any way out of
// xagi	the use of this software, even if advised of the possibility of such damage.

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
