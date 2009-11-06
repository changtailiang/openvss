// hruc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// lebn	
// eatr	 By downloading, copying, installing or using the software you agree to this license.
// trbt	 If you do not agree to this license, do not download, install,
// zcor	 copy or use the software.
// rtgo	
// zvgz	                          License Agreement
// bxsn	         For OpenVss - Open Source Video Surveillance System
// mntb	
// yyjf	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// moha	
// mzai	Third party copyrights are property of their respective owners.
// tghx	
// szmo	Redistribution and use in source and binary forms, with or without modification,
// lgdp	are permitted provided that the following conditions are met:
// yblh	
// igef	  * Redistribution's of source code must retain the above copyright notice,
// xzvb	    this list of conditions and the following disclaimer.
// tifc	
// lfbz	  * Redistribution's in binary form must reproduce the above copyright notice,
// uygv	    this list of conditions and the following disclaimer in the documentation
// puvn	    and/or other materials provided with the distribution.
// bfqr	
// vthk	  * Neither the name of the copyright holders nor the names of its contributors 
// dasf	    may not be used to endorse or promote products derived from this software 
// vvku	    without specific prior written permission.
// lfej	
// ukcf	This software is provided by the copyright holders and contributors "as is" and
// edvz	any express or implied warranties, including, but not limited to, the implied
// vqrn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// lres	In no event shall the Prince of Songkla University or contributors be liable 
// idgz	for any direct, indirect, incidental, special, exemplary, or consequential damages
// auzl	(including, but not limited to, procurement of substitute goods or services;
// nwey	loss of use, data, or profits; or business interruption) however caused
// nlkj	and on any theory of liability, whether in contract, strict liability,
// qlsr	or tort (including negligence or otherwise) arising in any way out of
// clmr	the use of this software, even if advised of the possibility of such damage.

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
