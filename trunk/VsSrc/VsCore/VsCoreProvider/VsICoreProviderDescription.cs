// njrc	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// slxr	
// pqmx	 By downloading, copying, installing or using the software you agree to this license.
// gqkh	 If you do not agree to this license, do not download, install,
// ockh	 copy or use the software.
// tlfb	
// rgcl	                          License Agreement
// wagk	         For OpenVss - Open Source Video Surveillance System
// jciz	
// scvs	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// jwzj	
// kwnh	Third party copyrights are property of their respective owners.
// mlzb	
// kaac	Redistribution and use in source and binary forms, with or without modification,
// eqkm	are permitted provided that the following conditions are met:
// ilvo	
// jboe	  * Redistribution's of source code must retain the above copyright notice,
// hkol	    this list of conditions and the following disclaimer.
// hsyw	
// lwqv	  * Redistribution's in binary form must reproduce the above copyright notice,
// svzk	    this list of conditions and the following disclaimer in the documentation
// beai	    and/or other materials provided with the distribution.
// cgvc	
// rikx	  * Neither the name of the copyright holders nor the names of its contributors 
// bkzj	    may not be used to endorse or promote products derived from this software 
// ijzb	    without specific prior written permission.
// xnur	
// cdqi	This software is provided by the copyright holders and contributors "as is" and
// zptm	any express or implied warranties, including, but not limited to, the implied
// lknf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// afbb	In no event shall the Prince of Songkla University or contributors be liable 
// oluy	for any direct, indirect, incidental, special, exemplary, or consequential damages
// iaua	(including, but not limited to, procurement of substitute goods or services;
// xgmj	loss of use, data, or profits; or business interruption) however caused
// wxnn	and on any theory of liability, whether in contract, strict liability,
// kigy	or tort (including negligence or otherwise) arising in any way out of
// qncb	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Core.Provider
{
	using System;
	using System.Xml;
    using System.Collections;

	/// <summary>
	/// IVideoSourceDescription interface - description of video source
	/// </summary>
	public interface VsICoreProviderDescription
	{
		/// <summary>
		/// Name property
		/// </summary>
		string Name{get;}

		/// <summary>
		/// Description property
		/// </summary>
		string Description{get;}

		/// <summary>
		/// Return settings page
		/// </summary>
		VsICoreProviderPage GetSettingsPage();

		/// <summary>
		/// Save configuration
		/// </summary>
		void SaveConfiguration(XmlTextWriter writer, object config);

		/// <summary>
		/// Load configuration
		/// </summary>
		object LoadConfiguration(XmlTextReader reader);

        /// <summary>
        /// Load configuration
        /// </summary>
        object LoadConfiguration(Hashtable reader);

		/// <summary>
		/// Create video source object
		/// </summary>
		VsICoreProvider CreateVideoSource(object config);
	}
}
