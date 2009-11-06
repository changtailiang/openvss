// sxuw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// apmy	
// lpfx	 By downloading, copying, installing or using the software you agree to this license.
// orvy	 If you do not agree to this license, do not download, install,
// welh	 copy or use the software.
// kcju	
// cxcn	                          License Agreement
// fjsw	         For OpenVss - Open Source Video Surveillance System
// rveq	
// arpg	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// roro	
// uwcj	Third party copyrights are property of their respective owners.
// trgz	
// obfp	Redistribution and use in source and binary forms, with or without modification,
// nauc	are permitted provided that the following conditions are met:
// nysb	
// wifs	  * Redistribution's of source code must retain the above copyright notice,
// meye	    this list of conditions and the following disclaimer.
// pfpv	
// kuzg	  * Redistribution's in binary form must reproduce the above copyright notice,
// vtuo	    this list of conditions and the following disclaimer in the documentation
// dthp	    and/or other materials provided with the distribution.
// qocz	
// xnss	  * Neither the name of the copyright holders nor the names of its contributors 
// wprl	    may not be used to endorse or promote products derived from this software 
// qkwo	    without specific prior written permission.
// scki	
// ljft	This software is provided by the copyright holders and contributors "as is" and
// angu	any express or implied warranties, including, but not limited to, the implied
// ddyd	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bpcy	In no event shall the Prince of Songkla University or contributors be liable 
// cygc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mwzu	(including, but not limited to, procurement of substitute goods or services;
// copl	loss of use, data, or profits; or business interruption) however caused
// wgvb	and on any theory of liability, whether in contract, strict liability,
// iyeg	or tort (including negligence or otherwise) arising in any way out of
// jjzj	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Reflection;
using Vs.Core.Encoder;
using System.Globalization;
using NLog; 

namespace Vs.Core
{
    /// <summary>
    /// VsEncoderCollection class - collection of Video Providers
    /// </summary>
    public class VsEncoderCollection : CollectionBase
    {
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        // Constructor
        public VsEncoderCollection()
        {
        }

        // Get video encoder at the specified index
        public VsEncoder this[int index]
        {
            get
            {
                try
                {
                    return ((VsEncoder)InnerList[index]);
                }
                catch (Exception err)
                {
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
                }

                return null;
            }
        }

        // Get encoder by its name
        public VsEncoder GetEncoderByName(string name)
        {
            try
            {
                foreach (VsEncoder encoder in InnerList)
                {
                    if (encoder.EncoderName == name)
                    {
                        return encoder;
                    }
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }

        // Load all video encoder
        public void Load(string path)
        {
            try
            {
                // create directory info
                DirectoryInfo dir = new DirectoryInfo(path);

                // get all dll files from the directory
                FileInfo[] files = dir.GetFiles("*.dll");

                // walk through all files
                foreach (FileInfo f in files)
                {
                    LoadAssembly(Path.Combine(path, f.Name));
                    VsSplasher.Status = "Load encoders : " + f.Name;
                }

                // sort providers list
                InnerList.Sort();
            }
            catch (Exception err)
            {
                //logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
                Console.WriteLine(err.Message);
            }
        }

        // Load assembly and find video encoder descriptors there
        private void LoadAssembly(string fname)
        {

            try
            {
                Type typeVideoSourceDesc = typeof(VsICoreEncoderDescription);
                Assembly asm = null;

                // try to load assembly
                asm = Assembly.LoadFrom(fname);

                // get types of the assembly
                Type[] types = asm.GetTypes();

                // check all types
                foreach (Type type in types)
                {
                    // get interfaces ot the type
                    Type[] interfaces = type.GetInterfaces();

                    // check, if the type is inherited from VsICoreEncoderDescription
                    if (Array.IndexOf(interfaces, typeVideoSourceDesc) != -1)
                    {
                        VsICoreEncoderDescription desc = null;

                        try
                        {
                            // create an instance of the type
                            desc = (VsICoreEncoderDescription)Activator.CreateInstance(type);
                            // create encoder object
                            InnerList.Add(new VsEncoder(desc));
                        }
                        catch (Exception err)
                        {
                            // something failed during instance creatinion
                            Console.WriteLine(err.Message);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                //logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
                Console.WriteLine(err.Message);
            }
        }
    }
}
