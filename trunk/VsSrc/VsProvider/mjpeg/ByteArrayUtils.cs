// dlna	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// nhte	
// jdaf	 By downloading, copying, installing or using the software you agree to this license.
// egzu	 If you do not agree to this license, do not download, install,
// frqj	 copy or use the software.
// giiw	
// myrx	                          License Agreement
// ktck	         For OpenVss - Open Source Video Surveillance System
// bmcq	
// kyue	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// dobr	
// ldxb	Third party copyrights are property of their respective owners.
// yjmv	
// ymyv	Redistribution and use in source and binary forms, with or without modification,
// crop	are permitted provided that the following conditions are met:
// pvtq	
// aqds	  * Redistribution's of source code must retain the above copyright notice,
// dikg	    this list of conditions and the following disclaimer.
// xlfr	
// grli	  * Redistribution's in binary form must reproduce the above copyright notice,
// aqya	    this list of conditions and the following disclaimer in the documentation
// ghlo	    and/or other materials provided with the distribution.
// ngnt	
// kfoh	  * Neither the name of the copyright holders nor the names of its contributors 
// vkqv	    may not be used to endorse or promote products derived from this software 
// zexp	    without specific prior written permission.
// zgyn	
// ghol	This software is provided by the copyright holders and contributors "as is" and
// ggoz	any express or implied warranties, including, but not limited to, the implied
// xtjt	warranties of merchantability and fitness for a particular purpose are disclaimed.
// epew	In no event shall the Prince of Songkla University or contributors be liable 
// vqws	for any direct, indirect, incidental, special, exemplary, or consequential damages
// wxwv	(including, but not limited to, procurement of substitute goods or services;
// aqiw	loss of use, data, or profits; or business interruption) however caused
// siaa	and on any theory of liability, whether in contract, strict liability,
// jxhg	or tort (including negligence or otherwise) arising in any way out of
// scnd	the use of this software, even if advised of the possibility of such damage.

namespace Vs.Provider.Mjpeg
{
	using System;

	/// <summary>
	/// Some array utilities
	/// </summary>
	internal class ByteArrayUtils
	{
		// Check if the array contains needle on specified position
		public static bool Compare(byte[] array, byte[] needle, int startIndex)
		{
			int	needleLen = needle.Length;
			// compare
			for (int i = 0, p = startIndex; i < needleLen; i++, p++)
			{
				if (array[p] != needle[i])
				{
					return false;
				}
			}
			return true;
		}

		// Find subarray in array
		public static int Find(byte[] array, byte[] needle, int startIndex, int count)
		{
			int	needleLen = needle.Length;
			int	index;

			while (count >= needleLen)
			{
				index = Array.IndexOf(array, needle[0], startIndex, count - needleLen + 1);

				if (index == -1)
					return -1;

				int i, p;
				// check for needle
				for (i = 0, p = index; i < needleLen; i++, p++)
				{
					if (array[p] != needle[i])
					{
						break;
					}
				}

				if (i == needleLen)
				{
					// found needle
					return index;
				}

				count -= (index - startIndex + 1);
				startIndex = index + 1;
			}
			return -1;
		}
	}
}
