// tnen	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// idgb	
// unus	 By downloading, copying, installing or using the software you agree to this license.
// cyla	 If you do not agree to this license, do not download, install,
// ptlk	 copy or use the software.
// zibx	
// mbiq	                          License Agreement
// beoj	         For OpenVSS - Open Source Video Surveillance System
// kmyf	
// wnii	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ldwh	
// vfvm	Third party copyrights are property of their respective owners.
// qruv	
// brdl	Redistribution and use in source and binary forms, with or without modification,
// lhah	are permitted provided that the following conditions are met:
// vqap	
// ykhq	  * Redistribution's of source code must retain the above copyright notice,
// afeb	    this list of conditions and the following disclaimer.
// lcyv	
// ltbg	  * Redistribution's in binary form must reproduce the above copyright notice,
// gvzj	    this list of conditions and the following disclaimer in the documentation
// jsit	    and/or other materials provided with the distribution.
// intp	
// nanv	  * Neither the name of the copyright holders nor the names of its contributors 
// dhil	    may not be used to endorse or promote products derived from this software 
// yeml	    without specific prior written permission.
// nsky	
// tias	This software is provided by the copyright holders and contributors "as is" and
// ftbz	any express or implied warranties, including, but not limited to, the implied
// qqfg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// coin	In no event shall the Prince of Songkla University or contributors be liable 
// lool	for any direct, indirect, incidental, special, exemplary, or consequential damages
// pdse	(including, but not limited to, procurement of substitute goods or services;
// kqib	loss of use, data, or profits; or business interruption) however caused
// jowr	and on any theory of liability, whether in contract, strict liability,
// ikza	or tort (including negligence or otherwise) arising in any way out of
// nbkt	the use of this software, even if advised of the possibility of such damage.
// znem	
// bcij	Intelligent Systems Laboratory (iSys Lab)
// wzzy	Faculty of Engineering, Prince of Songkla University, THAILAND
// eyiq	Project leader by Nikom SUVONVORN
// pvhp	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections;
using System.Globalization;
using NLog; 

namespace Vs.Core
{
	/// <summary>
	/// PageCollection class
	/// </summary>
	public class VsPageCollection : CollectionBase
	{
        static Logger logger = LogManager.GetCurrentClassLogger(); 

		// Constructor
		public VsPageCollection()
		{
		}

		// Get page at the specified index
		public VsPage this[int index]
		{
			get 
            {
                try
                {
                    return ((VsPage)InnerList[index]);
                }
                catch (Exception err)
                {
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
                }
                return null;
            }
		}

		// Add new page to the collection
		public void Add(VsPage page)
		{
            try
            {
                InnerList.Add(page);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
		}

		// Remove page from the collection
		public void Remove(VsPage page)
		{
            try
            {
                InnerList.Remove(page);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
		}

		// Get page with specified name
		public VsPage GetPage(string name)
		{
            try
            {
                // find the page
                foreach (VsPage page in InnerList)
                {
                    if (page.PageName == name)
                        return page;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

			return null;
		}

        // Get page with specified ID
        public VsPage GetPage(int pageID)
        {
            try
            {
                // find the page
                foreach (VsPage page in InnerList)
                {
                    if (page.PageID == pageID)
                        return page;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }

            return null;
        }
    }
}
