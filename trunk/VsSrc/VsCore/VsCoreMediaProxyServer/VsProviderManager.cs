// uwob	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// wmfh	
// oabc	 By downloading, copying, installing or using the software you agree to this license.
// ujyf	 If you do not agree to this license, do not download, install,
// cotv	 copy or use the software.
// beos	
// cjxh	                          License Agreement
// cnxy	         For OpenVSS - Open Source Video Surveillance System
// dixx	
// sifz	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// yjzq	
// zgux	Third party copyrights are property of their respective owners.
// howl	
// qxvp	Redistribution and use in source and binary forms, with or without modification,
// hvym	are permitted provided that the following conditions are met:
// oyeb	
// cdzm	  * Redistribution's of source code must retain the above copyright notice,
// lbmt	    this list of conditions and the following disclaimer.
// itxs	
// fxtw	  * Redistribution's in binary form must reproduce the above copyright notice,
// pzzo	    this list of conditions and the following disclaimer in the documentation
// qmif	    and/or other materials provided with the distribution.
// nipx	
// ktlz	  * Neither the name of the copyright holders nor the names of its contributors 
// eyov	    may not be used to endorse or promote products derived from this software 
// hhmg	    without specific prior written permission.
// bdcw	
// ackj	This software is provided by the copyright holders and contributors "as is" and
// ccxp	any express or implied warranties, including, but not limited to, the implied
// zqkp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vtzd	In no event shall the Prince of Songkla University or contributors be liable 
// lpjp	for any direct, indirect, incidental, special, exemplary, or consequential damages
// ixng	(including, but not limited to, procurement of substitute goods or services;
// jxph	loss of use, data, or profits; or business interruption) however caused
// nsmn	and on any theory of liability, whether in contract, strict liability,
// klfk	or tort (including negligence or otherwise) arising in any way out of
// yfuh	the use of this software, even if advised of the possibility of such damage.
// wvao	
// ozan	Intelligent Systems Laboratory (iSys Lab)
// ijvl	Faculty of Engineering, Prince of Songkla University, THAILAND
// unnc	Project leader by Nikom SUVONVORN
// odae	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using Vs.Core.Provider;
using Vs.Core.Image;
using System.Threading;

namespace Vs.Core.MediaProxyServer
{
    public class VsProviderManager
    {
        VsICoreProvider coreProvider;

        Hashtable providerProp = new Hashtable();
        VsImage img;

        string size = "640x480";
        string stype = "1";
        int interval = 100;

        bool provicerRuningState = false;

        int timeToStopProvider = 10000;
        int lastGetResultImage;
        int checkForStopProviderInterval = 1000;
        System.Timers.Timer checkForStopProviderTimer;

        public VsProviderManager(Hashtable reader, VsProvider provider)
        {
            providerProp["source"] = reader["source"];
            providerProp["login"] = reader["login"];
            providerProp["password"] = reader["password"];


            providerProp["size"] = size;
            providerProp["stype"] = stype;
            providerProp["interval"] = interval.ToString();

            createCoreProvider(provider);

        }

        public VsProviderManager(string source, string login, string password, VsProvider provider)
        {
            providerProp["source"] = source;
            providerProp["login"] = login;
            providerProp["password"] = password;


            providerProp["size"] = size;
            providerProp["stype"] = stype;
            providerProp["interval"] = interval.ToString();

            createCoreProvider(provider);

        }

        public VsProviderManager(string camID, VsProvider provider)
        {
            //????????????
        }

        private void createCoreProvider(VsProvider provider)
        {
            coreProvider = provider.CreateVideoSource(provider.LoadConfiguration(providerProp));

            coreProvider.FrameOut += new VsImageEventHandler(framedOut);

            // timer
            checkForStopProviderTimer = new System.Timers.Timer();
            checkForStopProviderTimer.Interval = checkForStopProviderInterval;
            checkForStopProviderTimer.SynchronizingObject = null;
            checkForStopProviderTimer.Elapsed += new System.Timers.ElapsedEventHandler(checkForStopProvider);
        }

        private void framedOut(object sender, VsImageEventArgs e)
        {

            //if (BQueue != null)
            //{
            img = (VsImage)e.Image.Clone();
            //Monitor.PulseAll(this);
            //    BQueue.Enqueue(img);
            //}

            //  bmp = img.Image;

            //MessageBox.Show("grameout");
            //((MultimodeVideoSource)coreProvider).FrameOut -= new VsImageEventHandler(framedOut);
            //  coreProvider.Stop();
        }

        public VsImage getResultImage()
        {  
            lock (this)
            {
                VsImage image = img;

                if (!provicerRuningState)
                {
                    StartProvider();
                }

                while (image == null || image.Image == null)
                {
                    //Monitor.Wait(this);
                    Thread.Sleep(interval);
                    image = img;

                    lock (checkForStopProviderTimer)
                    {
                        lastGetResultImage = 0;
                    }
                }

                lock (checkForStopProviderTimer)
                {
                    lastGetResultImage = 0;
                }

                return image.Clone();
            }
        }

        public void StartProvider()
        {
            lock (this)
            {
                coreProvider.Start();
                checkForStopProviderTimer.Start();
                provicerRuningState = true;
            }
        }

        public void StopProvider()
        {
            lock (this)
            {
                coreProvider.Stop();
                coreProvider.WaitForStop();
                img = null;
                provicerRuningState = false;
            }
        }
          // Process new frame
     
        private void checkForStopProvider(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (lastGetResultImage > timeToStopProvider)
            {
                StopProvider();
                checkForStopProviderTimer.Stop();
            }
            else
            {
                lock (checkForStopProviderTimer)
                {
                    lastGetResultImage = lastGetResultImage + checkForStopProviderInterval;
                }
            }
        
        }
    }
}
