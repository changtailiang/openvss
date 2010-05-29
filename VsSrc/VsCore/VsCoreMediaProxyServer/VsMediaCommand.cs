// qmvm	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mxjl	
// ehyn	 By downloading, copying, installing or using the software you agree to this license.
// pems	 If you do not agree to this license, do not download, install,
// bmez	 copy or use the software.
// dtjf	
// ggsg	                          License Agreement
// fsxg	         For OpenVSS - Open Source Video Surveillance System
// exvj	
// kehk	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// zien	
// xnlm	Third party copyrights are property of their respective owners.
// oayy	
// cyqx	Redistribution and use in source and binary forms, with or without modification,
// cpff	are permitted provided that the following conditions are met:
// fdfm	
// ksjs	  * Redistribution's of source code must retain the above copyright notice,
// jdhw	    this list of conditions and the following disclaimer.
// fuau	
// owis	  * Redistribution's in binary form must reproduce the above copyright notice,
// vgsf	    this list of conditions and the following disclaimer in the documentation
// tzdg	    and/or other materials provided with the distribution.
// gygu	
// ybfv	  * Neither the name of the copyright holders nor the names of its contributors 
// cscf	    may not be used to endorse or promote products derived from this software 
// etdk	    without specific prior written permission.
// sbsi	
// xwig	This software is provided by the copyright holders and contributors "as is" and
// hnky	any express or implied warranties, including, but not limited to, the implied
// kasl	warranties of merchantability and fitness for a particular purpose are disclaimed.
// odll	In no event shall the Prince of Songkla University or contributors be liable 
// wnxd	for any direct, indirect, incidental, special, exemplary, or consequential damages
// oesv	(including, but not limited to, procurement of substitute goods or services;
// tcob	loss of use, data, or profits; or business interruption) however caused
// dhms	and on any theory of liability, whether in contract, strict liability,
// gvik	or tort (including negligence or otherwise) arising in any way out of
// pzml	the use of this software, even if advised of the possibility of such damage.
// rglc	
// arrb	Intelligent Systems Laboratory (iSys Lab)
// isoe	Faculty of Engineering, Prince of Songkla University, THAILAND
// dpus	Project leader by Nikom SUVONVORN
// dnnf	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace Vs.Core.MediaProxyServer
{
    public enum SourceType
    {
        File,
        Live,
    }

    public enum StreamType
    {
        Jpeg,
        MJpeg,
        File
    }

    public class VsMediaCommand
    {

        public HTTPRequestStruct HTTPRequest;

        public SourceType sourceType;
        public StreamType streamType;

        public string urlSource;

        public string fileName;
        public int framRate;
        public Size videoSize;
        public int videoQuanlity;

        public VsMediaCommand(HTTPRequestStruct HTTPRequest)
        {
            this.HTTPRequest = HTTPRequest;
            if (!processCommand(HTTPRequest))
            {
                throw new Exception("command can not process");
            }
        }

        private bool processCommand(HTTPRequestStruct HTTPRequest)
        {
            string[] httpUrl = HTTPRequest.URL.ToLower().Split('/');

            #region source type
            if ("vs-live".Equals(httpUrl[1]))
            {
                sourceType = SourceType.Live;
            }
            else if ("vs-file".Equals(httpUrl[1]))
            {
                sourceType = SourceType.File;
            }
            else
            {
                return false;
            }
            #endregion

            #region streaming type
            if ("jpeg".Equals(httpUrl[2]))
            {
                streamType = StreamType.Jpeg;
            }
            else if ("mjpg".Equals(httpUrl[2]))
            {
                streamType = StreamType.MJpeg;
            }
            else if ("file".Equals(httpUrl[2]))
            {
                streamType = StreamType.File;
            }
            else
            {
                return false;
            }
            #endregion

            #region urlSource

            if (httpUrl.Length > 3)
            {
                for (int i = 3; i < httpUrl.Length; i++)
                {
                    urlSource += httpUrl[i] + "\\";
                }
                urlSource = urlSource.Remove(urlSource.Length - 1);
            }
            else
            {
                return false;
            }
            #endregion

            #region Parameter
            try
            {
                //resolution WxH
                if (HTTPRequest.Args!=null&&HTTPRequest.Args["size"] != null)
                {
                    string[] s = HTTPRequest.Args["size"].ToString().Split('x');
                    videoSize = new Size(int.Parse(s[0]), int.Parse(s[1]));
                }
                else
                {
                    videoSize = new Size(640, 480);
                }

                //frame per sec
                if (HTTPRequest.Args != null && HTTPRequest.Args["fps"] != null)
                {
                    framRate = int.Parse(HTTPRequest.Args["fps"].ToString());
                }
                else
                {
                    framRate = 4;
                }

                //compression %
                if (HTTPRequest.Args != null && HTTPRequest.Args["quanlity"] != null)
                {
                    videoQuanlity = int.Parse(HTTPRequest.Args["quanlity"].ToString());
                }
                else
                {
                    videoQuanlity = 80;
                }
            }
            catch
            {
                return false;
                //throw Exception();
            }
            #endregion

            return true;
        }
    }
}
