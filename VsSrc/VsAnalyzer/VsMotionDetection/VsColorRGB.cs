// hqmr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wamj	
// fllv	 By downloading, copying, installing or using the software you agree to this license.
// ietw	 If you do not agree to this license, do not download, install,
// xkqy	 copy or use the software.
// vobx	
// nwej	                          License Agreement
// ymud	         For OpenVss - Open Source Video Surveillance System
// uakx	
// uqxe	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// pbym	
// umhe	Third party copyrights are property of their respective owners.
// wzlk	
// axut	Redistribution and use in source and binary forms, with or without modification,
// opez	are permitted provided that the following conditions are met:
// wdls	
// qhbh	  * Redistribution's of source code must retain the above copyright notice,
// tvbh	    this list of conditions and the following disclaimer.
// mmju	
// ppca	  * Redistribution's in binary form must reproduce the above copyright notice,
// pzmy	    this list of conditions and the following disclaimer in the documentation
// bjdw	    and/or other materials provided with the distribution.
// grjf	
// lxil	  * Neither the name of the copyright holders nor the names of its contributors 
// qgvn	    may not be used to endorse or promote products derived from this software 
// lzka	    without specific prior written permission.
// ydxo	
// oaez	This software is provided by the copyright holders and contributors "as is" and
// mdkw	any express or implied warranties, including, but not limited to, the implied
// rmqg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// debc	In no event shall the Prince of Songkla University or contributors be liable 
// mwwp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dxej	(including, but not limited to, procurement of substitute goods or services;
// tppp	loss of use, data, or profits; or business interruption) however caused
// olay	and on any theory of liability, whether in contract, strict liability,
// mpif	or tort (including negligence or otherwise) arising in any way out of
// njsh	the use of this software, even if advised of the possibility of such damage.

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
