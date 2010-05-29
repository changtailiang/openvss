// xmac	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// gruz	
// djpb	 By downloading, copying, installing or using the software you agree to this license.
// qpdz	 If you do not agree to this license, do not download, install,
// cvfm	 copy or use the software.
// mvkk	
// ltiw	                          License Agreement
// tefr	         For OpenVSS - Open Source Video Surveillance System
// ddus	
// xjxi	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// mkik	
// icmy	Third party copyrights are property of their respective owners.
// fmhs	
// gdrb	Redistribution and use in source and binary forms, with or without modification,
// bpqm	are permitted provided that the following conditions are met:
// ixfz	
// exyn	  * Redistribution's of source code must retain the above copyright notice,
// vlcs	    this list of conditions and the following disclaimer.
// xxac	
// maci	  * Redistribution's in binary form must reproduce the above copyright notice,
// hkrg	    this list of conditions and the following disclaimer in the documentation
// wmkz	    and/or other materials provided with the distribution.
// lsqi	
// tkzo	  * Neither the name of the copyright holders nor the names of its contributors 
// ejgk	    may not be used to endorse or promote products derived from this software 
// ezdu	    without specific prior written permission.
// kpvj	
// doob	This software is provided by the copyright holders and contributors "as is" and
// mhey	any express or implied warranties, including, but not limited to, the implied
// gydr	warranties of merchantability and fitness for a particular purpose are disclaimed.
// mybc	In no event shall the Prince of Songkla University or contributors be liable 
// utym	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xlxd	(including, but not limited to, procurement of substitute goods or services;
// urei	loss of use, data, or profits; or business interruption) however caused
// gwvg	and on any theory of liability, whether in contract, strict liability,
// rbww	or tort (including negligence or otherwise) arising in any way out of
// epvl	the use of this software, even if advised of the possibility of such damage.
// fbif	
// goyg	Intelligent Systems Laboratory (iSys Lab)
// xbaq	Faculty of Engineering, Prince of Songkla University, THAILAND
// qilr	Project leader by Nikom SUVONVORN
// rkhu	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Threading;

namespace Vs.Core.DbDelete
{
    class FileManage
    {
        public FileManage()
        {

        }
        public FileManage(int timeWait,int roundDelete)
        {
            this.timeWait = timeWait;
            this.roundDelete = roundDelete;
        }

        private  int timeWait = 5000;//5 วิ
        private  int roundDelete = 6;

        private delegate void Target(Object obj);
        //สร้าง thread ขั้นมาเพื่อรอลบ file หรือ dir ทียังลบไม่ได้
        private  void tryDelete(Target target, string str)
        {
            Thread tryDeleteThread = new Thread(new ParameterizedThreadStart(target));
            tryDeleteThread.Start(str);
        }

        //  วนลบ file เดิมตามจำนวนรอบและการหน่วงเวลาที่กำหนด
        public  void tryDeleteFile(Object obj)
        {
            string fileFullName = obj.ToString();

            FileInfo file = new FileInfo(fileFullName);

            for (int i = 0; i < roundDelete; i++)
            {
                if (file.Exists)
                {
                   
                    try
                    {
                        file.Delete();
                    }
                    catch (Exception ex)
                    {
                        if (VsDbDelete.setmsg != null)
                        VsDbDelete.setmsg("ex", "in deletefile " + file.Name + ex.Message + " " + ex.StackTrace);

                        Thread.Sleep(timeWait);
                        continue;
                    }


                    if (!File.Exists(fileFullName))
                    {
                        if (VsDbDelete.setmsg != null)
                        VsDbDelete.setmsg("msg", "deleted: " + file.FullName);
                        
                        deleteEmtyDir(file.Directory, "*" + file.Extension);

                        Thread.Sleep(timeWait);
                        return;
                    }
                    else
                    {
                        if (VsDbDelete.setmsg != null)
                        VsDbDelete.setmsg("err", " can not deleted: " + file.FullName);

                        Thread.Sleep(timeWait);
                        continue;
                    }
                }
                else
                {
                    if (VsDbDelete.setmsg != null)
                    VsDbDelete.setmsg("msg", "deleted: " + file.FullName);
                }
            }
            if (VsDbDelete.setmsg != null)
            VsDbDelete.setmsg("msg", "cancel delete: " + file.FullName);
        }
        //วนลบ dir เดิมตามจำนวนรอบและการหน่วงเวลาที่กำหนด
        private  void tryDeleteDir(Object obj)
        {
            string dirName = obj.ToString();
            DirectoryInfo dir = new DirectoryInfo(dirName);
            for (int i = 0; i < roundDelete; i++)
            {
                
                try
                {
                    dir.Delete(true);

                    if (VsDbDelete.setmsg != null)
                    VsDbDelete.setmsg("msg", "deleted: " + dirName);

                    //ถ้าสามารถลบ dir ของกล้องได้ครบทุกกล้อง
                    if (dir.Parent.Exists && dir.Parent.GetDirectories().Length == 0)
                    {
                        for (int j = 0; j < roundDelete; i++)
                        {     
                            try
                            {
                                dir.Parent.Delete(true);

                                if (VsDbDelete.setmsg != null)
                                VsDbDelete.setmsg("msg", "deleted: " + dir.Parent.FullName);
                               
                                return;
                            }

                            catch (Exception ex)
                            {
                                if (VsDbDelete.setmsg != null)
                                VsDbDelete.setmsg("ex", "in deletedir " + dir.Parent.Name + ex.Message + " " + ex.StackTrace);

                                Thread.Sleep(timeWait);
                            }  
                            
                        }
                        if (VsDbDelete.setmsg != null)
                        VsDbDelete.setmsg("msg", "cancel delete: " + dir.Parent.Name);

                    }
                    Thread.Sleep(timeWait);
                    return;
                }
                catch (Exception ex)
                {
                    if (VsDbDelete.setmsg != null)
                    VsDbDelete.setmsg("ex", "in deletedir " + dirName + ex.Message + " " + ex.StackTrace);

                }
            }
            if (VsDbDelete.setmsg != null)
            VsDbDelete.setmsg("msg", "cancel delete: " + dirName);
        }

        public void tryDeleteDir(string dirPath)
        {
            tryDelete(tryDeleteDir, dirPath);
        }

        //ลบ array ของ file ที่ต้องการ
        public  int deleteFile(string[] fileFullNames)
        {
            int falseNum = 0; ;

            foreach (string fileFullName in fileFullNames)
            {
                FileInfo file = new FileInfo(fileFullName);
                if (file.Exists)
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (Exception ex)
                    {
                        if (VsDbDelete.setmsg != null)
                        VsDbDelete.setmsg("ex", "in deletefile " + file.Name + ex.Message + " " + ex.StackTrace);
                        
                        tryDelete(tryDeleteFile, fileFullName);
                        continue;
                    }


                    if (!File.Exists(fileFullName))
                    {
                        falseNum++;

                        if (VsDbDelete.setmsg != null)
                        VsDbDelete.setmsg("msg", "deleted: " + file.FullName);
                    }
                    else
                    {
                        if (VsDbDelete.setmsg != null)
                        VsDbDelete.setmsg("err", " can not deleted: " + file.FullName);
                      
                        tryDelete(tryDeleteFile, fileFullName);
                    }
                }
                else
                {
                    if (VsDbDelete.setmsg != null)
                    VsDbDelete.setmsg("err", " don't exist file:" + file.FullName);
                }
                deleteEmtyDir(file.Directory, "*" + file.Extension);
            }
            return falseNum;
        }

        /* ตรวจสอบว่ามี directory หรือไม่
         * ตรวจสอบว่ามี file อยู่ภายในหรือไม่
         * ลบfile ภายในทั้งหมด
         * ทำการลบ 
         */
        public  bool deleteEmtyDir(DirectoryInfo dir, string filePatern)
        {
            if (dir.Exists && dir.GetFiles(filePatern).Length == 0)
            {
                try
                {
                    dir.Delete(true);

                    if (VsDbDelete.setmsg != null)
                    VsDbDelete.setmsg("msg", "deleted: " + dir.FullName);
                }
                catch (Exception ex)
                {
                    if (VsDbDelete.setmsg != null)
                    VsDbDelete.setmsg("ex", "in deletedir " + dir.Name + ex.Message + " " + ex.StackTrace);
                    
                    tryDelete(tryDeleteDir, dir.FullName);
            
                }

                if (dir.Parent.Exists && dir.Parent.GetDirectories().Length == 0)
                {
                    try
                    {
                        dir.Parent.Delete(true);

                        if (VsDbDelete.setmsg != null)
                        VsDbDelete.setmsg("msg", "deleted: " + dir.Parent.FullName);
                    }
                    catch (Exception ex)
                    {
                        VsDbDelete.setmsg("ex", "in deletedir " + dir.Parent.Name + ex.Message + " " + ex.StackTrace);
                        tryDelete(tryDeleteDir, dir.Parent.FullName);

                    }

                }

                return true;
            }

            return false;
        }

        public  long getSumOfFileSize(string[] files)
        {
            long sumOfSize = 0;
            FileInfo file;

            foreach (string fileName in files)
            {
                file = new FileInfo(fileName);
                if (file.Exists)
                {
                    sumOfSize += file.Length;
                }
            }
            return sumOfSize;
        }

        /* ตรวจสอบว่ามี dir นั้นหรือไม่ 
         * ทำการลบ file ทั้งหมด ใน dir 
         * ตรวจสอบว่ายังมี file อยู่ภายในหรือไม่
         */
        //public static bool deleteAllFileInDir(string dirPath)
        //{
        //    return false;
        //}



    }
}
