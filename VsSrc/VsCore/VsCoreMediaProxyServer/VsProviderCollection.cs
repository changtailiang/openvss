// nnoa	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rmwe	
// cmqw	 By downloading, copying, installing or using the software you agree to this license.
// cgrs	 If you do not agree to this license, do not download, install,
// kkeo	 copy or use the software.
// rozm	
// cuzp	                          License Agreement
// xzek	         For OpenVSS - Open Source Video Surveillance System
// vrxd	
// xduc	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// eefe	
// arzu	Third party copyrights are property of their respective owners.
// wjnq	
// iwdz	Redistribution and use in source and binary forms, with or without modification,
// ocyx	are permitted provided that the following conditions are met:
// nghc	
// hgbl	  * Redistribution's of source code must retain the above copyright notice,
// iovg	    this list of conditions and the following disclaimer.
// qbkn	
// ivmk	  * Redistribution's in binary form must reproduce the above copyright notice,
// uftn	    this list of conditions and the following disclaimer in the documentation
// locz	    and/or other materials provided with the distribution.
// nypu	
// fxpx	  * Neither the name of the copyright holders nor the names of its contributors 
// wcwu	    may not be used to endorse or promote products derived from this software 
// qolh	    without specific prior written permission.
// ohag	
// mqqs	This software is provided by the copyright holders and contributors "as is" and
// pnci	any express or implied warranties, including, but not limited to, the implied
// nuqt	warranties of merchantability and fitness for a particular purpose are disclaimed.
// dbxk	In no event shall the Prince of Songkla University or contributors be liable 
// zaat	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mmqg	(including, but not limited to, procurement of substitute goods or services;
// zstf	loss of use, data, or profits; or business interruption) however caused
// tlye	and on any theory of liability, whether in contract, strict liability,
// nwnx	or tort (including negligence or otherwise) arising in any way out of
// iwfr	the use of this software, even if advised of the possibility of such damage.
// uhkc	
// mdqo	Intelligent Systems Laboratory (iSys Lab)
// rbio	Faculty of Engineering, Prince of Songkla University, THAILAND
// ggtz	Project leader by Nikom SUVONVORN
// zktx	Project website at http://code.google.com/p/openvss/

namespace Vs.Core.MediaProxyServer
{

    using System;
    using System.Collections;
    using System.IO;
    using System.Reflection;
    //using Vs.Core.Encoder;
    using Vs.Core.Provider;
    using System.Globalization;
    using NLog;

    /// <summary>
    /// VsProviderCollection class - collection of Video Providers
    /// </summary>
    public class VsProviderCollection : CollectionBase
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        // Constructor
        public VsProviderCollection()
        {
        }

        // Get video provider at the specified index
        public VsProvider this[int index]
        {
            get
            {
                try
                {
                    return ((VsProvider)InnerList[index]);
                }
                catch (Exception err)
                {
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
                }
                return null;
            }
        }

        // Get provider by its name
        public VsProvider GetProviderByName(string name)
        {
            try
            {
                foreach (VsProvider provider in InnerList)
                {
                    if (provider.ProviderName == name)
                    {
                        return provider;
                    }
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            return null;
        }

        // Load all video providers
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
                   // VsSplasher.Status = "Load providers : " + f.Name;
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

        // Load assembly and find video provider descriptors there
        private void LoadAssembly(string fname)
        {
            try
            {
                Type typeVideoSourceDesc = typeof(VsICoreProviderDescription);
                Assembly asm = null;

                try
                {
                    // try to load assembly
                    asm = Assembly.LoadFrom(fname);

                    // get types of the assembly
                    Type[] types = asm.GetTypes();

                    // check all types
                    foreach (Type type in types)
                    {
                        // get interfaces ot the type
                        Type[] interfaces = type.GetInterfaces();

                        // check, if the type is inherited from VsICoreProviderDescription
                        if (Array.IndexOf(interfaces, typeVideoSourceDesc) != -1)
                        {
                            VsICoreProviderDescription desc = null;

                            try
                            {
                                // create an instance of the type
                                desc = (VsICoreProviderDescription)Activator.CreateInstance(type);
                                // create provider object
                                InnerList.Add(new VsProvider(desc));
                            }
                            catch (Exception err)
                            {
                                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
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
            catch (Exception err)
            {
                //logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
                Console.WriteLine(err.Message);
            }
        }
    }
}
