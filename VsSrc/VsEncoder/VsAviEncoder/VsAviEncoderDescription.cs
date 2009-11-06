// tnlz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// xasr	
// bluh	 By downloading, copying, installing or using the software you agree to this license.
// tckl	 If you do not agree to this license, do not download, install,
// jbab	 copy or use the software.
// gson	
// usio	                          License Agreement
// ytym	         For OpenVss - Open Source Video Surveillance System
// liap	
// mgxn	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ovbk	
// drob	Third party copyrights are property of their respective owners.
// nnsg	
// pgqa	Redistribution and use in source and binary forms, with or without modification,
// zyef	are permitted provided that the following conditions are met:
// rdth	
// nhwk	  * Redistribution's of source code must retain the above copyright notice,
// cvyc	    this list of conditions and the following disclaimer.
// emnk	
// rejd	  * Redistribution's in binary form must reproduce the above copyright notice,
// ehbk	    this list of conditions and the following disclaimer in the documentation
// arxf	    and/or other materials provided with the distribution.
// szqo	
// crvk	  * Neither the name of the copyright holders nor the names of its contributors 
// ctwv	    may not be used to endorse or promote products derived from this software 
// vdyr	    without specific prior written permission.
// oqcc	
// tfju	This software is provided by the copyright holders and contributors "as is" and
// oaak	any express or implied warranties, including, but not limited to, the implied
// cihv	warranties of merchantability and fitness for a particular purpose are disclaimed.
// kqsd	In no event shall the Prince of Songkla University or contributors be liable 
// fkam	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qcix	(including, but not limited to, procurement of substitute goods or services;
// hoia	loss of use, data, or profits; or business interruption) however caused
// ijwk	and on any theory of liability, whether in contract, strict liability,
// pvmm	or tort (including negligence or otherwise) arising in any way out of
// pvzb	the use of this software, even if advised of the possibility of such damage.

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
