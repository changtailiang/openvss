// vdmm	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// adyq	
// hlxq	 By downloading, copying, installing or using the software you agree to this license.
// ivxq	 If you do not agree to this license, do not download, install,
// pfrl	 copy or use the software.
// rzuv	
// fmpt	                          License Agreement
// uqrw	         For OpenVss - Open Source Video Surveillance System
// cwcv	
// xkur	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// xfvo	
// lioi	Third party copyrights are property of their respective owners.
// qnbt	
// mlov	Redistribution and use in source and binary forms, with or without modification,
// iqgo	are permitted provided that the following conditions are met:
// newq	
// ubnl	  * Redistribution's of source code must retain the above copyright notice,
// sbte	    this list of conditions and the following disclaimer.
// lanl	
// egkx	  * Redistribution's in binary form must reproduce the above copyright notice,
// yhdh	    this list of conditions and the following disclaimer in the documentation
// pykq	    and/or other materials provided with the distribution.
// igng	
// dfdt	  * Neither the name of the copyright holders nor the names of its contributors 
// jeuk	    may not be used to endorse or promote products derived from this software 
// ucpo	    without specific prior written permission.
// uwil	
// ycqc	This software is provided by the copyright holders and contributors "as is" and
// gjqg	any express or implied warranties, including, but not limited to, the implied
// bpbv	warranties of merchantability and fitness for a particular purpose are disclaimed.
// rxcm	In no event shall the Prince of Songkla University or contributors be liable 
// ombf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xuba	(including, but not limited to, procurement of substitute goods or services;
// lzdv	loss of use, data, or profits; or business interruption) however caused
// rons	and on any theory of liability, whether in contract, strict liability,
// pysf	or tort (including negligence or otherwise) arising in any way out of
// qlau	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Vs.Core.Encoder;

namespace Vs.Encoder.Wmv
{
    class VsWmvEncoderDescription : VsICoreEncoderDescription
    {
        private string encoderName;

        public VsWmvEncoderDescription()
        {
            this.encoderName = "VsWmvEncoderDescription";
        }

        #region VsICoreEncoderDescription Members

        VsICoreEncoder VsICoreEncoderDescription.CreateEncoder(long syncTimer, object config)
        {
            VsWmvEncoderConfiguration cfg = (VsWmvEncoderConfiguration)config;

            if (cfg != null)
            {
                VsWmvEncoder encoder = new VsWmvEncoder(syncTimer);

                encoder.EncoderName = cfg.CodecsName;

                return (VsWmvEncoder)encoder;
            }
            return null;
        }

        string VsICoreEncoderDescription.Description
        {
            get { return encoderName; }
        }

        VsICoreEncoderPage VsICoreEncoderDescription.GetSettingsPage()
        {
            return new VsWmvSetupPage(); 
        }

        object VsICoreEncoderDescription.LoadConfiguration(System.Xml.XmlTextReader reader)
        {
            VsWmvEncoderConfiguration config = new VsWmvEncoderConfiguration();

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
            VsWmvEncoderConfiguration config = new VsWmvEncoderConfiguration();

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
            get { return "Windows Media Encoder"; }
        }

        void VsICoreEncoderDescription.SaveConfiguration(System.Xml.XmlTextWriter writer, object config)
        {
            VsWmvEncoderConfiguration cfg = (VsWmvEncoderConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("ImageWidth", cfg.ImageWidth.ToString());
                writer.WriteAttributeString("ImageHeight", cfg.ImageHeight.ToString());
                writer.WriteAttributeString("CodecsName", cfg.CodecsName);
                writer.WriteAttributeString("Quality", cfg.Quality.ToString());
            }
        }

        #endregion
    }
}
