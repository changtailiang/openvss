// iung	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// dtfv	
// vmbp	 By downloading, copying, installing or using the software you agree to this license.
// ixkw	 If you do not agree to this license, do not download, install,
// stpm	 copy or use the software.
// fste	
// fgym	                          License Agreement
// hdkf	         For OpenVss - Open Source Video Surveillance System
// stnm	
// wdwr	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// weou	
// cyyy	Third party copyrights are property of their respective owners.
// xgqx	
// xnkp	Redistribution and use in source and binary forms, with or without modification,
// bjax	are permitted provided that the following conditions are met:
// usor	
// bwwp	  * Redistribution's of source code must retain the above copyright notice,
// kxao	    this list of conditions and the following disclaimer.
// wypb	
// ezcg	  * Redistribution's in binary form must reproduce the above copyright notice,
// hapb	    this list of conditions and the following disclaimer in the documentation
// nnif	    and/or other materials provided with the distribution.
// ixln	
// cywe	  * Neither the name of the copyright holders nor the names of its contributors 
// pwsg	    may not be used to endorse or promote products derived from this software 
// bjoz	    without specific prior written permission.
// gbbz	
// xjlb	This software is provided by the copyright holders and contributors "as is" and
// htpu	any express or implied warranties, including, but not limited to, the implied
// dndo	warranties of merchantability and fitness for a particular purpose are disclaimed.
// nqgn	In no event shall the Prince of Songkla University or contributors be liable 
// mmlx	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bllh	(including, but not limited to, procurement of substitute goods or services;
// gvfy	loss of use, data, or profits; or business interruption) however caused
// mqul	and on any theory of liability, whether in contract, strict liability,
// liiz	or tort (including negligence or otherwise) arising in any way out of
// ljgj	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.Threading;
using System.Globalization;
using NLog; 

namespace Vs.Core
{
	/// <summary>
	/// VsMonitorStoppingPool
	/// </summary>
	public class VsMonitorStoppingPool : CollectionBase
	{
        static Logger logger = LogManager.GetCurrentClassLogger(); 

		private Thread	thread;
		private ManualResetEvent stopEvent = null;

		// Constructor
		public VsMonitorStoppingPool()
		{
		}

		// Start the pool
		public void Start()
		{
            try
            {
                // create events
                stopEvent = new ManualResetEvent(false);

                // create and start new thread
                thread = new Thread(new ThreadStart(WorkerThread));
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
		}

		// Stop the pool
		public void Stop()
		{
            try
            {
                if (thread != null)
                {
                    // signal to stop
                    stopEvent.Set();
                    // wait for thread stop
                    thread.Join();

                    thread = null;

                    // release events
                    stopEvent.Close();
                    stopEvent = null;
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
		}

		// Thread entry point
		private void WorkerThread()
		{
			while (!stopEvent.WaitOne(0, true))
			{
				// lock
				Monitor.Enter(this);

                try
                {
                    int n = InnerList.Count;

                    // check each camera
                    for (int i = 0; i < n; i++)
                    {
                        VsCamera camera = (VsCamera)InnerList[i];

                        if (!camera.Running)
                        {
                            camera.CloseVideoSource();
                            camera.CloseAnalyserSource();
                            camera.CloseEncoderSource();
                            InnerList.RemoveAt(i);
                            i--;
                            n--;
                        }
                    }
                }
                catch (Exception err)
                {
                    logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
                }
                finally
                {
                    // unlock
                    Monitor.Exit(this);
                }

				// sleep for a while
				Thread.Sleep(300);
			}

            try
            {
                // Exiting, so kill'em all
                foreach (VsCamera camera in InnerList)
                {
                    camera.Stop();
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
		}

		// Add new camera to the collection and run it
		public void Add(VsCamera camera)
		{
			// lock
			Monitor.Enter(this);
            try
            {
                // add to the pool
                InnerList.Add(camera);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            finally
            {
                // unlock
                Monitor.Exit(this);
            }
		}

		// Ensure the camera is stopped
		public void Remove(VsCamera camera)
		{
			// lock
			Monitor.Enter(this);

            try
            {
                int n = InnerList.Count;
                for (int i = 0; i < n; i++)
                {
                    if (InnerList[i] == camera)
                    {
                        if (camera.Running)
                            camera.Stop();
                        camera.CloseVideoSource();
                        camera.CloseAnalyserSource();
                        camera.CloseEncoderSource();
                        InnerList.RemoveAt(i);
                        break;
                    }
                }
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace);;
            }
            finally
            {
                // unlock
                Monitor.Exit(this);
            }
		}
	}
}
