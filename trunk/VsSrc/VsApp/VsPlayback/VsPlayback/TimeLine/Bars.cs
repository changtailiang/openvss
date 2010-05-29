// kxfe	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// guia	
// kihb	 By downloading, copying, installing or using the software you agree to this license.
// wlwh	 If you do not agree to this license, do not download, install,
// aksw	 copy or use the software.
// koiz	
// jhtz	                          License Agreement
// rivm	         For OpenVSS - Open Source Video Surveillance System
// rmvv	
// qrjd	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// dcuq	
// wwuu	Third party copyrights are property of their respective owners.
// mmpp	
// rjbv	Redistribution and use in source and binary forms, with or without modification,
// ofvy	are permitted provided that the following conditions are met:
// biib	
// mujk	  * Redistribution's of source code must retain the above copyright notice,
// pbrj	    this list of conditions and the following disclaimer.
// aoth	
// urdn	  * Redistribution's in binary form must reproduce the above copyright notice,
// mznf	    this list of conditions and the following disclaimer in the documentation
// sgvi	    and/or other materials provided with the distribution.
// lzgk	
// vlcu	  * Neither the name of the copyright holders nor the names of its contributors 
// tseb	    may not be used to endorse or promote products derived from this software 
// mkel	    without specific prior written permission.
// ugoc	
// qtbw	This software is provided by the copyright holders and contributors "as is" and
// cilb	any express or implied warranties, including, but not limited to, the implied
// vdjg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zbzp	In no event shall the Prince of Songkla University or contributors be liable 
// uhnp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// myob	(including, but not limited to, procurement of substitute goods or services;
// nbac	loss of use, data, or profits; or business interruption) however caused
// uckl	and on any theory of liability, whether in contract, strict liability,
// rsrr	or tort (including negligence or otherwise) arising in any way out of
// ykhn	the use of this software, even if advised of the possibility of such damage.
// zazq	
// jxcl	Intelligent Systems Laboratory (iSys Lab)
// loqn	Faculty of Engineering, Prince of Songkla University, THAILAND
// tyqs	Project leader by Nikom SUVONVORN
// ezjb	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Vs.Playback.VsService;

namespace Vs.Playback.TimeLine
{
    public class Bars
    {
        static Bars()
        {
        }

        public Bars()
        {
        }

        //private int _fileId = -1;
        //public int FileID
        //{
        //    get { return _fileId; }
        //    set { _fileId = value; }
        //}

        public VsMotion[] motions;



        private String _videoFileName = string.Empty;
        public String FileName
        {
            get { return _videoFileName; }
            set { _videoFileName = value; }
        }

        private String _videoFilePath = string.Empty;
        public String FilePath
        {
            get { return _videoFilePath; }
            set { _videoFilePath = value; }
        }

        private float _fileLength = 86400.000000f;
        public float FileLength
        {
            get { return _fileLength; }
            set { _fileLength = value; }
        }

        private double _fps = 0.00d;
        public double FPS
        {
            get { return _fps; }
            set { _fps = value; }
        }

        private double _duration = 0.00d;
        public double Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        ///////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////

        private bool _goodData = true;
        public bool goodData
        {
            get { return _goodData; }
            set { _goodData = value; }
        }

        private RectangleF _recordingRect = new RectangleF();
        public RectangleF recordingRect
        {
            get { return _recordingRect; }
            set { _recordingRect = value; }
        }

        private float _startSeconds = 0.000000f;
        public float startSeconds
        {
            get { return _startSeconds; }
            set { _startSeconds = value; }
        }

        private float _endSeconds = 86400.000000f;
        public float endSeconds
        {
            get { return _endSeconds; }
            set { _endSeconds = value; }
        }

        private Size _size = new Size();
        public Size size
        {
            get { return _size; }
            set { _size = value; }
        }

        private float _startRatio = 1.000000f;
        public float startRatio
        {
            get { return _startRatio; }
            set { _startRatio = value; }
        }

        private float _endRatio = 1.000000f;
        public float endRatio
        {
            get { return _endRatio; }
            set { _endRatio = value; }
        }


    }



}
