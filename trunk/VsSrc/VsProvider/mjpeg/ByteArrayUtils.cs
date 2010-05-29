// srkz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// bnks	
// quyz	 By downloading, copying, installing or using the software you agree to this license.
// yqep	 If you do not agree to this license, do not download, install,
// mrcc	 copy or use the software.
// jlcx	
// woja	                          License Agreement
// trgc	         For OpenVSS - Open Source Video Surveillance System
// glvk	
// xfbo	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// hjqo	
// oplx	Third party copyrights are property of their respective owners.
// plvn	
// xjuh	Redistribution and use in source and binary forms, with or without modification,
// pmdn	are permitted provided that the following conditions are met:
// ejyy	
// nvsn	  * Redistribution's of source code must retain the above copyright notice,
// vtrh	    this list of conditions and the following disclaimer.
// pnva	
// unjg	  * Redistribution's in binary form must reproduce the above copyright notice,
// clli	    this list of conditions and the following disclaimer in the documentation
// vsfw	    and/or other materials provided with the distribution.
// qnvk	
// bokx	  * Neither the name of the copyright holders nor the names of its contributors 
// lras	    may not be used to endorse or promote products derived from this software 
// wxbw	    without specific prior written permission.
// uoyj	
// numb	This software is provided by the copyright holders and contributors "as is" and
// dxks	any express or implied warranties, including, but not limited to, the implied
// yqdu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// pvxi	In no event shall the Prince of Songkla University or contributors be liable 
// xgfb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dxod	(including, but not limited to, procurement of substitute goods or services;
// nqjf	loss of use, data, or profits; or business interruption) however caused
// kpnh	and on any theory of liability, whether in contract, strict liability,
// uwjw	or tort (including negligence or otherwise) arising in any way out of
// auhe	the use of this software, even if advised of the possibility of such damage.
// drzv	
// ofda	Intelligent Systems Laboratory (iSys Lab)
// atyn	Faculty of Engineering, Prince of Songkla University, THAILAND
// iwgq	Project leader by Nikom SUVONVORN
// fjnm	Project website at http://code.google.com/p/openvss/

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
