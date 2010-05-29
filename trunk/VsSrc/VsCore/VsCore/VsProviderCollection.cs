// jbov	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// bqtm	
// aych	 By downloading, copying, installing or using the software you agree to this license.
// rfss	 If you do not agree to this license, do not download, install,
// jjoi	 copy or use the software.
// mcde	
// cejb	                          License Agreement
// aiwx	         For OpenVSS - Open Source Video Surveillance System
// xtty	
// yfel	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// yuaq	
// cmxi	Third party copyrights are property of their respective owners.
// jeeq	
// dupg	Redistribution and use in source and binary forms, with or without modification,
// yksw	are permitted provided that the following conditions are met:
// gsmr	
// cejx	  * Redistribution's of source code must retain the above copyright notice,
// lutd	    this list of conditions and the following disclaimer.
// eckr	
// cmbq	  * Redistribution's in binary form must reproduce the above copyright notice,
// hbrw	    this list of conditions and the following disclaimer in the documentation
// efud	    and/or other materials provided with the distribution.
// dman	
// nieg	  * Neither the name of the copyright holders nor the names of its contributors 
// hinx	    may not be used to endorse or promote products derived from this software 
// czwp	    without specific prior written permission.
// kala	
// kyel	This software is provided by the copyright holders and contributors "as is" and
// jbof	any express or implied warranties, including, but not limited to, the implied
// aqmw	warranties of merchantability and fitness for a particular purpose are disclaimed.
// jftz	In no event shall the Prince of Songkla University or contributors be liable 
// tgqw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ydjt	(including, but not limited to, procurement of substitute goods or services;
// yenh	loss of use, data, or profits; or business interruption) however caused
// eble	and on any theory of liability, whether in contract, strict liability,
// tutf	or tort (including negligence or otherwise) arising in any way out of
// ioel	the use of this software, even if advised of the possibility of such damage.
// tyfr	
// vqox	Intelligent Systems Laboratory (iSys Lab)
// fxve	Faculty of Engineering, Prince of Songkla University, THAILAND
// kpbg	Project leader by Nikom SUVONVORN
// okme	Project website at http://code.google.com/p/openvss/

namespace Vs.Core
{
	using System;
	using System.Collections;
	using System.IO;
	using System.Reflection;
	using Vs.Core.Encoder;
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
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
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
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
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
                    VsSplasher.Status = "Load providers : " + f.Name;
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
                                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
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
