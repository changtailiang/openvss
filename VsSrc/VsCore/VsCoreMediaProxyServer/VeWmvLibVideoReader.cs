// wfhn	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// okga	
// mxul	 By downloading, copying, installing or using the software you agree to this license.
// urcc	 If you do not agree to this license, do not download, install,
// laln	 copy or use the software.
// bmuq	
// uwvo	                          License Agreement
// uktr	         For OpenVSS - Open Source Video Surveillance System
// rhhk	
// wmji	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// cabd	
// jtwo	Third party copyrights are property of their respective owners.
// hnpc	
// npzj	Redistribution and use in source and binary forms, with or without modification,
// krtr	are permitted provided that the following conditions are met:
// prgc	
// edtn	  * Redistribution's of source code must retain the above copyright notice,
// jrfy	    this list of conditions and the following disclaimer.
// qckb	
// krha	  * Redistribution's in binary form must reproduce the above copyright notice,
// zhgg	    this list of conditions and the following disclaimer in the documentation
// uqec	    and/or other materials provided with the distribution.
// hxzf	
// tstk	  * Neither the name of the copyright holders nor the names of its contributors 
// tzzf	    may not be used to endorse or promote products derived from this software 
// zjep	    without specific prior written permission.
// hqmk	
// eyyt	This software is provided by the copyright holders and contributors "as is" and
// jssh	any express or implied warranties, including, but not limited to, the implied
// lzhn	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zrgl	In no event shall the Prince of Songkla University or contributors be liable 
// safx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// jahl	(including, but not limited to, procurement of substitute goods or services;
// sbbq	loss of use, data, or profits; or business interruption) however caused
// crze	and on any theory of liability, whether in contract, strict liability,
// etyi	or tort (including negligence or otherwise) arising in any way out of
// zgva	the use of this software, even if advised of the possibility of such damage.
// alzt	
// slgi	Intelligent Systems Laboratory (iSys Lab)
// ctxg	Faculty of Engineering, Prince of Songkla University, THAILAND
// load	Project leader by Nikom SUVONVORN
// qnbi	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using Vs.Encoder.WmvLib.WMFSDKWrapper;

namespace Vs.Core.MediaProxyServer
{
    public class VeWmvLibVideoReader
    {
        WmvReader wmvReader = new WmvReader();

        WM_MEDIA_TYPE mediaType = new WM_MEDIA_TYPE();
        Guid subtype = MediaSubTypes.WMMEDIASUBTYPE_RGB24;
        VideoInfoHeader outputVideoInfoHeader = new VideoInfoHeader();
        VideoInfoHeader inputVideoInfoHeader = new VideoInfoHeader();


        public int outputFrameInterval = 0;//min sec//famerate = 1000/outputFrameInterval
        public int inputFrameInterval = 0;

        public ulong currentPosition = 0;
        private Bitmap currentImg;

        public VeWmvLibVideoReader(string videoFilePath)
        {
            wmvReader.Open(videoFilePath);

            wmvReader.FindVideoOutputFormat(0, ref  mediaType, ref  subtype, ref  inputVideoInfoHeader);
            //wmvReader.FindVideoInfo(ref  mediaType, ref  outputVideoInfoHeader);
            outputVideoInfoHeader = inputVideoInfoHeader;

            if (currentImg == null)
            {
                getNextFrame(out currentImg);
            }
            outputFrameInterval = inputFrameInterval;
        }

        public VeWmvLibVideoReader(string videoPath, int outputFrameInterval)
        {
            wmvReader.Open(videoPath);

            wmvReader.FindVideoOutputFormat(0, ref  mediaType, ref  subtype, ref  inputVideoInfoHeader);
            //wmvReader.FindVideoInfo(ref  mediaType, ref  outputVideoInfoHeader);

            outputVideoInfoHeader = inputVideoInfoHeader;
            this.outputFrameInterval = outputFrameInterval;

            if (currentImg == null)
            {
                getNextFrame(out currentImg);
            }
        }


        public VeWmvLibVideoReader(string videoPath, int outputFrameInterval,Size videoSize)
        {
            wmvReader.Open(videoPath);

            wmvReader.FindVideoOutputFormat(0, ref  mediaType, ref  subtype, ref  inputVideoInfoHeader);
            //wmvReader.FindVideoInfo(ref  mediaType, ref  outputVideoInfoHeader);

            outputVideoInfoHeader.bmiHeader.biWidth = (uint)videoSize.Width;
            outputVideoInfoHeader.bmiHeader.biHeight = (uint)videoSize.Height;

            this.outputFrameInterval = outputFrameInterval;

            if (currentImg == null)
            {
                getNextFrame(out currentImg);
            }
        }


        ulong sampleTime, sampleDuration;
        uint flags, outputNum;
        ushort streamNum;
        INSSBuffer sample = null;

        uint streamsRead = 0;

        public bool getNextFrame(out Bitmap frameOutput)
        {
            if (streamsRead < wmvReader.ReaderStreamCount)
            {
                try
                {
                    streamNum = 0;

                    wmvReader.Reader.GetNextSample(0, out sample, out sampleTime, out sampleDuration, out flags, out outputNum, out streamNum);

                    frameOutput = wmvReader.GetBitmapFromSample(sample, subtype, inputVideoInfoHeader, outputVideoInfoHeader);

                    currentImg = frameOutput;

                    this.inputFrameInterval = (int)(outputVideoInfoHeader.AvgTimePerFrame / sampleDuration);

                    return true;
                }
                catch (COMException ec)
                {
                    if (ec.ErrorCode == Constants.NS_E_NO_MORE_SAMPLES)
                    {
                        streamsRead++;
                        return getNextFrame(out frameOutput);//recursive
                    }
                    else
                        throw;
                }
            }
            else
            {
                frameOutput = null;
                return false;
            }
        }

        //outputFrameInterval must >0
        public bool getNextFrameAsInterval(out Bitmap frameOutput)
        { 
            bool result = false;

            ulong samplePosition = sampleTime / sampleDuration;
            ulong nextSamplePosition = samplePosition + (ulong)inputFrameInterval;
           

            if (currentPosition <= nextSamplePosition)
            {
                if (currentImg == null)
                {
                    result = getNextFrame(out currentImg);
                }
                else
                    result = true;
            }
            else
                while (currentPosition > nextSamplePosition)
                {
                    if (!getNextFrame(out currentImg))
                    {
                        break;
                    }
                    result = true;

                    samplePosition = sampleTime / sampleDuration;
                    nextSamplePosition = samplePosition + (ulong)inputFrameInterval;
                }

            frameOutput = currentImg;
            currentPosition += (ulong)outputFrameInterval;
            return result;
            //frameOutput = null;

        }

        public void Close()
        {
            wmvReader.Reader.Close();
            GC.SuppressFinalize(this);
        }
    }
}
