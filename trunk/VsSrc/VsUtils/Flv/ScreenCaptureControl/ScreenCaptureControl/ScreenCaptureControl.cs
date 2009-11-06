using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Win32Capture;
using NetFLVScreenEncoder;

namespace ScreenCaptureControl
{
    public partial class ScreenCaptureControl : UserControl
    {

        private CaptureControl cc = new CaptureControl();
        private FLVScreenEncoder encoder;
        private FLVEncoderParams par;
        private bool broadcasting = false;
        private string eventID;
        private bool fileEncode = false;
        private bool liveEncode = false;

        private object[] connection_params;

        public bool EncodeToFile
        {
            get
            {
                return this.fileEncode;
            }
            set
            {
                this.fileEncode = value;
            }
        }

        public object[] ConnectionParameters
        {
            get
            {
                return connection_params;

            }
            set
            {
                connection_params = value;
            }
        }

        public bool EncodeLive
        {
            get
            {
                return this.liveEncode;
            }
            set
            {
                this.liveEncode = value;
            }
        }

        public FLVEncoderParams EncodingParameters
        {
            get
            {
                return this.par;
            }
            set
            {
                this.par = value;
            }
        }

        public string EventID
        {
            get
            {
                return this.eventID;
            }
            set
            {
                this.eventID = value;
            }
        }

        public bool IsBroadcasting
        {
            get
            {
                return this.broadcasting;
            }
        }
        
        public ScreenCaptureControl()
        {
            InitializeComponent();
            par = new FLVEncoderParams();
        }

    

        public void timerTick(Object o, EventArgs e)
        {
            byte[] frame = cc.captureDesktopBytes();
            try
            {           
                encoder.EncodeFrame(frame);
            }
            catch
            {
                this.captureTimer.Stop();
                this.broadcasting = false;
                //error occured.
            }
        }

        public void start()
        {
            par.StreamingParams.Record = true;
            Bitmap b = cc.captureDesktopBitmap();
            par.VideoWidth = b.Width;
            par.VideoHeight = b.Height;
            encoder = new FLVScreenEncoder(par);
            if (connection_params == null)
                connection_params = new object[0];
            string[] connect_params = new string[2+ connection_params.Length];
            connect_params[0] = "broadcaster";
            connect_params[1] = this.eventID;

            for(int i = 0; i < connection_params.Length;i++)
            {
                connect_params[2 + i] = connection_params[i].ToString();
            }

            if (this.liveEncode)
                encoder.BeginLiveStream(connect_params);
            if (this.fileEncode)
                encoder.BeginFileEncode();
          
            broadcasting = true;
            this.captureTimer.Interval = 3000 / this.trackBar1.Value;
            this.captureTimer.Tick += timerTick;
            this.captureTimer.Start();
            encoder.call("setDesktopStreamDimensions", new object[] { b.Width, b.Height });

        }

        public void stop()
        {
            this.captureTimer.Stop();
            this.encoder.EndEncode();
            this.broadcasting = false;
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.captureTimer.Interval = 3000 / this.trackBar1.Value;
        }
    }
}