// lqhl	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// sghe	
// xgxm	 By downloading, copying, installing or using the software you agree to this license.
// qcjo	 If you do not agree to this license, do not download, install,
// jpfn	 copy or use the software.
// cdsv	
// bfds	                          License Agreement
// raig	         For OpenVSS - Open Source Video Surveillance System
// dyhi	
// fppd	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// asce	
// xgsp	Third party copyrights are property of their respective owners.
// pevp	
// nmni	Redistribution and use in source and binary forms, with or without modification,
// ymjm	are permitted provided that the following conditions are met:
// donx	
// xris	  * Redistribution's of source code must retain the above copyright notice,
// ubiu	    this list of conditions and the following disclaimer.
// acmj	
// anxu	  * Redistribution's in binary form must reproduce the above copyright notice,
// nndn	    this list of conditions and the following disclaimer in the documentation
// ftsr	    and/or other materials provided with the distribution.
// kykt	
// fczl	  * Neither the name of the copyright holders nor the names of its contributors 
// fegg	    may not be used to endorse or promote products derived from this software 
// xzuo	    without specific prior written permission.
// vapl	
// zdhk	This software is provided by the copyright holders and contributors "as is" and
// oozp	any express or implied warranties, including, but not limited to, the implied
// lase	warranties of merchantability and fitness for a particular purpose are disclaimed.
// zrhw	In no event shall the Prince of Songkla University or contributors be liable 
// qoox	for any direct, indirect, incidental, special, exemplary, or consequential damages
// cbdw	(including, but not limited to, procurement of substitute goods or services;
// hrxn	loss of use, data, or profits; or business interruption) however caused
// spre	and on any theory of liability, whether in contract, strict liability,
// dgsg	or tort (including negligence or otherwise) arising in any way out of
// qzfq	the use of this software, even if advised of the possibility of such damage.
// ckaf	
// mbgg	Intelligent Systems Laboratory (iSys Lab)
// ryxh	Faculty of Engineering, Prince of Songkla University, THAILAND
// lriy	Project leader by Nikom SUVONVORN
// alcw	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Vs.Core.MediaProxyServer
{
    public class ffMpegFileConvert
    {

        string _ffExe = "ffmpeg\\ffmpeg";
        static string _tempDir = "TempFile";
        string AppPath = null;


        public ffMpegFileConvert(string AppPath)
        {
            this.AppPath = AppPath;
        }


        #region GetVideoInfo
        public VideoFile GetVideoInfo(MemoryStream inputFile, string Filename)
        {
            string tempfile = Path.Combine(this.AppPath, System.Guid.NewGuid().ToString() + Path.GetExtension(Filename));
            FileStream fs = File.Create(tempfile);
            inputFile.WriteTo(fs);
            fs.Flush();
            fs.Close();
            GC.Collect();

            VideoFile vf = null;
            try
            {
                vf = new VideoFile(tempfile);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            GetVideoInfo(vf);

            try
            {
                File.Delete(tempfile);
            }
            catch (Exception)
            {

            }

            return vf;
        }
        public VideoFile GetVideoInfo(string inputPath)
        {
            VideoFile vf = null;
            try
            {
                vf = new VideoFile(inputPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            GetVideoInfo(vf);
            return vf;
        }
        public void GetVideoInfo(VideoFile input)
        {
            //set up the parameters for video info
            string Params = string.Format("-i {0}", input.Path);
            string output = RunProcess(Params);
            input.RawInfo = output;

            //get duration
            Regex re = new Regex("[D|d]uration:.((\\d|:|\\.)*)");
            Match m = re.Match(input.RawInfo);

            if (m.Success)
            {
                string duration = m.Groups[1].Value;
                string[] timepieces = duration.Split(new char[] { ':', '.' });
                if (timepieces.Length == 4)
                {
                    input.Duration = new TimeSpan(0, Convert.ToInt16(timepieces[0]), Convert.ToInt16(timepieces[1]), Convert.ToInt16(timepieces[2]), Convert.ToInt16(timepieces[3]));
                }
            }

            //get audio bit rate
            re = new Regex("[B|b]itrate:.((\\d|:)*)");
            m = re.Match(input.RawInfo);
            double kb = 0.0;
            if (m.Success)
            {
                Double.TryParse(m.Groups[1].Value, out kb);
            }
            input.BitRate = kb;

            //get the audio format
            re = new Regex("[A|a]udio:.*");
            m = re.Match(input.RawInfo);
            if (m.Success)
            {
                input.AudioFormat = m.Value;
            }

            //get the video format
            re = new Regex("[V|v]ideo:.*");
            m = re.Match(input.RawInfo);
            if (m.Success)
            {
                input.VideoFormat = m.Value;
            }

            //get the video format
            re = new Regex("(\\d{2,3})x(\\d{2,3})");
            m = re.Match(input.RawInfo);
            if (m.Success)
            {
                int width = 0; int height = 0;
                int.TryParse(m.Groups[1].Value, out width);
                int.TryParse(m.Groups[2].Value, out height);
                input.Width = width;
                input.Height = height;
            }
            input.infoGathered = true;
        }
        #endregion

        #region Run the process
        private string RunProcess(string Parameters)
        {
            //create a process info
            string final_ff_path = Path.Combine(this.AppPath, this._ffExe);

            ProcessStartInfo oInfo = new ProcessStartInfo(final_ff_path, Parameters);
            oInfo.UseShellExecute = false;
            oInfo.CreateNoWindow = true;
            oInfo.RedirectStandardOutput = true;
            oInfo.RedirectStandardError = true;

            //Create the output and streamreader to get the output
            string output = null; StreamReader srOutput = null;

            //try the process
            try
            {
                //run the process
                Process proc = System.Diagnostics.Process.Start(oInfo);

                proc.WaitForExit();

                //get the output
                srOutput = proc.StandardError;

                //now put it in a string
                output = srOutput.ReadToEnd();

                proc.Close();
            }
            catch (Exception)
            {
                output = string.Empty;
            }
            finally
            {
                //now, if we succeded, close out the streamreader
                if (srOutput != null)
                {
                    srOutput.Close();
                    srOutput.Dispose();
                }
            }
            return output;
        }
        #endregion

        #region LoadMemoryStream
        public static MemoryStream LoadMemoryStreamFromFile(string fileName)
        {
            MemoryStream ms = null;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open,
            FileAccess.Read))
            {
                byte[] fil;
                fil = new byte[fileStream.Length];
                fileStream.Read(fil, 0, fil.Length);
                fileStream.Close();
                ms = new MemoryStream(fil);
            }
            GC.Collect();
            return ms;
        }
        public static MemoryStream LoadMemoryStreamFromFile(FileStream fs)
        {
            MemoryStream ms = null;
            using (FileStream fileStream = fs)
            {
                byte[] fil;
                fil = new byte[fileStream.Length];
                fileStream.Read(fil, 0, fil.Length);
                fileStream.Close();
                ms = new MemoryStream(fil);
            }
            GC.Collect();
            return ms;
        }
        #endregion

        public OutputVideo ConvertToWmv(VideoFile input)
        {
            if (!input.infoGathered)
            {
                GetVideoInfo(input);
            }
            OutputVideo ou = new OutputVideo();

            //set up the parameters for getting a previewimage

            string filename = System.Guid.NewGuid().ToString() + ".flv";
            string finalpath = Path.Combine(this.AppPath, filename);

            string Params =string.Format("-i {0} -y -ar 22050 -ab 64 -f flv {1}", input.Path, finalpath);
        //   
            ou.RawOutput = RunProcess(Params);

            if (File.Exists(finalpath))
            {
                ou.VideoStream = LoadMemoryStreamFromFile(finalpath);
                try
                {
                    File.Delete(finalpath);
                }
                catch (Exception) { }
            }
            return ou;
        }
        public OutputVideo ConvertToWmv(string input)
        {
           
            OutputVideo ou = new OutputVideo();

            //set up the parameters for getting a previewimage

            string filename = System.Guid.NewGuid().ToString() + ".wmv";
            string finalpath = Path.Combine(this.AppPath, filename);

            string Params = string.Format(" -i \"{0}\" -s 160x120 -b 1000k -vcodec wmv2 -ar 22050 -acodec wmav2 -ab 56k -ac 2 -y \"{1}\"", input, finalpath);
            ou.RawOutput = RunProcess(Params);

            if (File.Exists(finalpath))
            {
                ou.VideoStream = LoadMemoryStreamFromFile(finalpath);
                try
                {
                    File.Delete(finalpath);
                }
                catch (Exception) { }
            }
            return ou;
        }

        public OutputVideo ConvertToWmv(string input,Size size)
        {
            return ConvertToWmv(input, size.Width, size.Height);
        }

        public OutputVideo ConvertToWmv(string input, int w, int h)
        {

            OutputVideo ou = new OutputVideo();

            //set up the parameters for getting a previewimage

            string filename = System.Guid.NewGuid().ToString() + ".wmv";
            string finalpath = Path.Combine(this.AppPath, filename);

            string size = string.Format("{0}x{1}", w.ToString(), h.ToString());//

            string Params = string.Format(" -i \"{0}\" -s {1} -vcodec wmv2 -ar 22050 -acodec wmav2 -ab 56k -ac 2 -y \"{2}\"", input, size, finalpath);
            ou.RawOutput = RunProcess(Params);

            if (File.Exists(finalpath))
            {
                ou.VideoStream = LoadMemoryStreamFromFile(finalpath);
                try
                {
                    File.Delete(finalpath);
                }
                catch (Exception) { }
            }
            return ou;
        }

    }
    public class VideoFile
    {
        #region Properties
        private string _Path;
        public string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;
            }
        }

        public TimeSpan Duration { get; set; }
        public double BitRate { get; set; }
        public string AudioFormat { get; set; }
        public string VideoFormat { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string RawInfo { get; set; }
        public bool infoGathered { get; set; }
        #endregion

        #region Constructors
        public VideoFile(string path)
        {
            _Path = path;
            Initialize();
        }
        #endregion

        #region Initialization
        private void Initialize()
        {
            this.infoGathered = false;
            //first make sure we have a value for the video file setting
            if (string.IsNullOrEmpty(_Path))
            {
                throw new Exception("Could not find the location of the video file");
            }

            //Now see if the video file exists
            if (!File.Exists(_Path))
            {
                throw new Exception("The video file " + _Path + " does not exist.");
            }
        }
        #endregion
    }

    public class OutputVideo
    {
        public MemoryStream VideoStream { get; set; }
        public System.Drawing.Image PreviewImage { get; set; }
        public string RawOutput { get; set; }
        public bool Success { get; set; }
    }
}
