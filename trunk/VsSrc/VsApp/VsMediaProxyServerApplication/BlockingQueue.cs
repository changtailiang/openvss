// cdbw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// deou	
// safl	 By downloading, copying, installing or using the software you agree to this license.
// uycs	 If you do not agree to this license, do not download, install,
// abzp	 copy or use the software.
// aecf	
// fdmd	                          License Agreement
// rkdy	         For OpenVSS - Open Source Video Surveillance System
// euoo	
// awko	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// wazc	
// kwwj	Third party copyrights are property of their respective owners.
// uqom	
// qvry	Redistribution and use in source and binary forms, with or without modification,
// awra	are permitted provided that the following conditions are met:
// rldi	
// wgga	  * Redistribution's of source code must retain the above copyright notice,
// knsd	    this list of conditions and the following disclaimer.
// qltz	
// eaui	  * Redistribution's in binary form must reproduce the above copyright notice,
// hcib	    this list of conditions and the following disclaimer in the documentation
// wrij	    and/or other materials provided with the distribution.
// dqne	
// fkwl	  * Neither the name of the copyright holders nor the names of its contributors 
// xrfe	    may not be used to endorse or promote products derived from this software 
// pwzh	    without specific prior written permission.
// xkwe	
// crta	This software is provided by the copyright holders and contributors "as is" and
// bito	any express or implied warranties, including, but not limited to, the implied
// dblf	warranties of merchantability and fitness for a particular purpose are disclaimed.
// yxxt	In no event shall the Prince of Songkla University or contributors be liable 
// znyf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// oicn	(including, but not limited to, procurement of substitute goods or services;
// uqsk	loss of use, data, or profits; or business interruption) however caused
// dadm	and on any theory of liability, whether in contract, strict liability,
// vdgl	or tort (including negligence or otherwise) arising in any way out of
// xmcw	the use of this software, even if advised of the possibility of such damage.
// rhhv	
// fzfr	Intelligent Systems Laboratory (iSys Lab)
// zfhk	Faculty of Engineering, Prince of Songkla University, THAILAND
// lqpu	Project leader by Nikom SUVONVORN
// ofgl	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VsMediaProxyServerApplication
{
    public class BlockingQueue<T>
    {
        readonly int _Size = 1;
        readonly Queue<T> _Queue = new Queue<T>();
        readonly object _Key = new object();
        bool _Quit = false;

        public T[] getElement()
        {
            lock (_Key)
            {
                return _Queue.ToArray<T>();
            }
        }

        public BlockingQueue()//(int size)
        {
            //_Size = size;
        }

        public int numQ()
        {
            lock (_Key)
            {
                return _Queue.Count;
            }
        }

        public void Start()
        {
            lock (_Key)
            {
                _Quit = false;

                Monitor.PulseAll(_Key);
            }
        }


        public void Quit()
        {
            lock (_Key)
            {
                _Quit = true;

                Monitor.PulseAll(_Key);
            }
        }

        public bool Enqueue(T t)
        {
            lock (_Key)
            {
                // while (!_Quit )//&& _Queue.Count >= _Size)
                //Monitor.Wait(_Key);

                if (_Quit) return false;

                _Queue.Enqueue(t);

                Monitor.PulseAll(_Key);
            }

            return true;
        }

        public bool Dequeue(out T t)
        {
            t = default(T);

            lock (_Key)
            {
                while (!_Quit && _Queue.Count == 0) Monitor.Wait(_Key);

                if (_Queue.Count == 0) return false;

                t = _Queue.Dequeue();

                Monitor.PulseAll(_Key);
            }

            return true;
        }

        public bool GetObj(out T t)
        {
            t = default(T);

            lock (_Key)
            {
                while (!_Quit && _Queue.Count == 0) Monitor.Wait(_Key);

                if (_Queue.Count == 0) return false;

                t = _Queue.ElementAt(_Queue.Count - 1);

                Monitor.PulseAll(_Key);
            }

            return true;
        }
        public bool SetObj(T t)
        {
            lock (_Key)
            {
                // while (!_Quit )//&& _Queue.Count >= _Size)
                //Monitor.Wait(_Key);

                if (_Quit) return false;

                if (_Queue.Count >= _Size)
                {
                    _Queue.Dequeue();
                }

                _Queue.Enqueue(t);

                Monitor.PulseAll(_Key);
            }

            return true;
        }

    }
}
