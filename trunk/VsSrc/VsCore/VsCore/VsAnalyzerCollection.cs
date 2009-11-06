// catv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ejqr	
// vedn	 By downloading, copying, installing or using the software you agree to this license.
// bdlq	 If you do not agree to this license, do not download, install,
// zavk	 copy or use the software.
// cirj	
// ojlg	                          License Agreement
// tcwk	         For OpenVss - Open Source Video Surveillance System
// awtk	
// lhbk	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ycnn	
// qnda	Third party copyrights are property of their respective owners.
// iiwh	
// zfnu	Redistribution and use in source and binary forms, with or without modification,
// jkgv	are permitted provided that the following conditions are met:
// xjxt	
// hsme	  * Redistribution's of source code must retain the above copyright notice,
// jbfs	    this list of conditions and the following disclaimer.
// ykla	
// uesb	  * Redistribution's in binary form must reproduce the above copyright notice,
// fkyl	    this list of conditions and the following disclaimer in the documentation
// fplv	    and/or other materials provided with the distribution.
// jzaa	
// agno	  * Neither the name of the copyright holders nor the names of its contributors 
// etfx	    may not be used to endorse or promote products derived from this software 
// ayrh	    without specific prior written permission.
// ceio	
// tmzf	This software is provided by the copyright holders and contributors "as is" and
// rfpm	any express or implied warranties, including, but not limited to, the implied
// kmns	warranties of merchantability and fitness for a particular purpose are disclaimed.
// hrvj	In no event shall the Prince of Songkla University or contributors be liable 
// aers	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xxva	(including, but not limited to, procurement of substitute goods or services;
// zvah	loss of use, data, or profits; or business interruption) however caused
// tqib	and on any theory of liability, whether in contract, strict liability,
// hwbx	or tort (including negligence or otherwise) arising in any way out of
// aviv	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Reflection;
using Vs.Core.Analyzer;
using System.Globalization;
using NLog; 

namespace Vs.Core
{
    /// <summary>
    /// VsAnalyzerCollection class - collection of Video Providers
    /// </summary>
    public class VsAnalyzerCollection : CollectionBase
    {
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        // Constructor
        public VsAnalyzerCollection()
        {
        }

        // Get video analyzer at the specified index
        public VsAnalyzer this[int index]
        {
            get
            {
                try
                {
                    return ((VsAnalyzer)InnerList[index]);
                }
                catch (Exception err)
                {
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
                }
                return null;
            }
        }

        // Get analyzer by its name
        public VsAnalyzer GetAnalyserByName(string name)
        {
            try
            {
                foreach (VsAnalyzer analyzer in InnerList)
                {
                    if (analyzer.AnalyserName == name)
                    {
                        return analyzer;
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
                    VsSplasher.Status = "Load analyzers : " + f.Name;
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

        // Load assembly and find video analyzer descriptors there
        private void LoadAssembly(string fname)
        {
            try
            {
                Type typeVideoSourceDesc = typeof(VsICoreAnalyzerDescription);
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

                    // check, if the type is inherited from VsICoreAnalyzerDescription
                    if (Array.IndexOf(interfaces, typeVideoSourceDesc) != -1)
                    {
                        VsICoreAnalyzerDescription desc = null;

                        try
                        {
                            // create an instance of the type
                            desc = (VsICoreAnalyzerDescription)Activator.CreateInstance(type);
                            // create analyzer object
                            InnerList.Add(new VsAnalyzer(desc));
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
