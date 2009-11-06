// flqd	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ihrq	
// psma	 By downloading, copying, installing or using the software you agree to this license.
// kbeo	 If you do not agree to this license, do not download, install,
// brfn	 copy or use the software.
// mysr	
// ohar	                          License Agreement
// xtjw	         For OpenVss - Open Source Video Surveillance System
// pclx	
// jyxj	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// iqyy	
// guhp	Third party copyrights are property of their respective owners.
// ufwd	
// yorg	Redistribution and use in source and binary forms, with or without modification,
// szoa	are permitted provided that the following conditions are met:
// gatw	
// jplh	  * Redistribution's of source code must retain the above copyright notice,
// qhec	    this list of conditions and the following disclaimer.
// tvev	
// ztlu	  * Redistribution's in binary form must reproduce the above copyright notice,
// zlxs	    this list of conditions and the following disclaimer in the documentation
// wfxb	    and/or other materials provided with the distribution.
// leej	
// kwdi	  * Neither the name of the copyright holders nor the names of its contributors 
// xcpq	    may not be used to endorse or promote products derived from this software 
// jaym	    without specific prior written permission.
// atkd	
// jwgz	This software is provided by the copyright holders and contributors "as is" and
// oubu	any express or implied warranties, including, but not limited to, the implied
// dazd	warranties of merchantability and fitness for a particular purpose are disclaimed.
// sjvm	In no event shall the Prince of Songkla University or contributors be liable 
// dvsw	for any direct, indirect, incidental, special, exemplary, or consequential damages
// rvxx	(including, but not limited to, procurement of substitute goods or services;
// eulz	loss of use, data, or profits; or business interruption) however caused
// mksc	and on any theory of liability, whether in contract, strict liability,
// vtrp	or tort (including negligence or otherwise) arising in any way out of
// xfvp	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Globalization;
using NLog; 

namespace Vs.Core.Image
{
    public class VsImage : IComparable, IDisposable
    {
        static Logger logger = LogManager.GetCurrentClassLogger(); 

        private Bitmap bImage=null;
        private Bitmap aImage = null;
        private DateTime tStamp;
        private bool bDetected = false;
        private bool bAnalyzed = false;
        private String aResult = "";

        // constructor
        public VsImage()
        {

        }

        public VsImage(Bitmap vsImg)
        {
            bImage = vsImg;
            tStamp = DateTime.Now;
        }

        // disposable object
        public void Dispose()
        {
            try
            {
                if (bImage != null)
                {
                    bImage.Dispose();
                    bImage = null;
                }

                if (aImage != null)
                {
                    aImage.Dispose();
                    aImage = null;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
        }

        // Image property
        public Bitmap Image
        {
            set { bImage = value;}
            get { return bImage; }
        }

        // AnalyzedImage property
        public Bitmap AnalyzedImage
        {
            set { aImage = value; }
            get { return aImage;  }
        }
            /*
            {
                if(aImage == null) aImage = (Bitmap)bImage.Clone();
                return aImage;
            }*/

            /*
            if (IsAnalyzed)
            {
                String[] regs = aResult.Split(';');
                if (regs.Length > 1)
                {
                    using (Graphics g = Graphics.FromImage(aImage))
                    {
                        for (int i = 0; i < regs.Length; i++)
                        {
                            String[] reg = regs[i].Split(',');
                            if (reg.Length == 4)
                            {
                                Pen redBox = new Pen(Color.Red);
                                g.DrawRectangle(redBox, float.Parse(reg[0]), float.Parse(reg[1]), float.Parse(reg[2]), float.Parse(reg[3]));
                                redBox.Dispose();
                                redBox = null;
                            }
                        }
                    }
                }
            }
            */

        // TimeStamp property
        public DateTime TimeStamp
        {
            set { tStamp=value; }
            get { return tStamp; }
        }

        // IsDetected property
        public bool IsDetected
        {
            set { bDetected = value; }
            get { return bDetected; }
        }

        // IsAnalyzed property
        public bool IsAnalyzed
        {
            set { bAnalyzed = value; }
            get { return bAnalyzed; }
        }

        // Result property
        public String Result
        {
            set { aResult = value; }
            get { return aResult; }
        }

        // Compares objects of the type
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            VsImage p = (VsImage)obj;
            return (this.tStamp.CompareTo(p.tStamp));
        }

        // methodes
        public VsImage Clone()
        {
            VsImage vsImg = new VsImage();

            try
            {
                vsImg.Image = (Bitmap)bImage.Clone();
                if (aImage != null) vsImg.AnalyzedImage = (Bitmap)aImage.Clone();
                vsImg.TimeStamp = TimeStamp;
                vsImg.IsDetected = IsDetected;
                vsImg.IsAnalyzed = IsAnalyzed;
                vsImg.Result = Result;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);
            }
            
            return vsImg;
        }
    }
}
