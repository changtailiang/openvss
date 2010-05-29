// clza	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// dpav	
// lbio	 By downloading, copying, installing or using the software you agree to this license.
// bdno	 If you do not agree to this license, do not download, install,
// csfw	 copy or use the software.
// bwtc	
// swps	                          License Agreement
// kbvr	         For OpenVSS - Open Source Video Surveillance System
// uyzb	
// kozo	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// elzv	
// nieu	Third party copyrights are property of their respective owners.
// bkzp	
// hyxf	Redistribution and use in source and binary forms, with or without modification,
// swhh	are permitted provided that the following conditions are met:
// zilj	
// gqtc	  * Redistribution's of source code must retain the above copyright notice,
// dldn	    this list of conditions and the following disclaimer.
// trrp	
// xxpk	  * Redistribution's in binary form must reproduce the above copyright notice,
// ruqa	    this list of conditions and the following disclaimer in the documentation
// cgkw	    and/or other materials provided with the distribution.
// bujo	
// hrow	  * Neither the name of the copyright holders nor the names of its contributors 
// appx	    may not be used to endorse or promote products derived from this software 
// ocrq	    without specific prior written permission.
// hmvq	
// ghhu	This software is provided by the copyright holders and contributors "as is" and
// gxqf	any express or implied warranties, including, but not limited to, the implied
// slhz	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fxbj	In no event shall the Prince of Songkla University or contributors be liable 
// cogc	for any direct, indirect, incidental, special, exemplary, or consequential damages
// cvpi	(including, but not limited to, procurement of substitute goods or services;
// hsvo	loss of use, data, or profits; or business interruption) however caused
// dasp	and on any theory of liability, whether in contract, strict liability,
// kupt	or tort (including negligence or otherwise) arising in any way out of
// mohj	the use of this software, even if advised of the possibility of such damage.
// ajdp	
// hprq	Intelligent Systems Laboratory (iSys Lab)
// bins	Faculty of Engineering, Prince of Songkla University, THAILAND
// gtnl	Project leader by Nikom SUVONVORN
// szno	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;

namespace Vs.Analyzer
{
    public class VsColorRGB
    {
       /// <summary>
        /// Index of red component.
        /// </summary>
        public const short R = 2;

        /// <summary>
        /// Index of green component.
        /// </summary>
        public const short G = 1;
        
        /// <summary>
        /// Index of blue component.
        /// </summary>
        public const short B = 0;

        /// <summary>
        /// Red component.
        /// </summary>
        public byte Red;

        /// <summary>
        /// Green component.
        /// </summary>
        public byte Green;

        /// <summary>
        /// Blue component.
        /// </summary>
        public byte Blue;

        /// <summary>
        /// <see cref="System.Drawing.Color">Color</see> value of the class.
        /// </summary>
        public System.Drawing.Color Color
        {
            get 
            {
                return System.Drawing.Color.FromArgb( Red, Green, Blue ); 
            }
            set
            {
                Red   = value.R;
                Green = value.G;
                Blue  = value.B;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VkColorRGB"/> class.
        /// </summary>
        public VsColorRGB() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VkColorRGB"/> class.
        /// </summary>
        /// 
        /// <param name="red">Red component.</param>
        /// <param name="green">Green component.</param>
        /// <param name="blue">Blue component.</param>
        /// 
        public VsColorRGB( byte red, byte green, byte blue )
        {
            this.Red   = red;
            this.Green = green;
            this.Blue  = blue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VkColorRGB"/> class.
        /// </summary>
        /// 
        /// <param name="color">Initialize from specified <see cref="System.Drawing.Color">color.</see></param>
        /// 
        public VsColorRGB( System.Drawing.Color color )
        {
            this.Red   = color.R;
            this.Green = color.G;
            this.Blue  = color.B;
        }
    }
}
