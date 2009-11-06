namespace WindowsFormsPresenter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NetFLVScreenEncoder.FLVEncoderParams flvEncoderParams4 = new NetFLVScreenEncoder.FLVEncoderParams();
            NetFLVScreenEncoder.FLVFileParams flvFileParams4 = new NetFLVScreenEncoder.FLVFileParams();
            NetFLVScreenEncoder.FLVStreamingParams flvStreamingParams4 = new NetFLVScreenEncoder.FLVStreamingParams();
            this.screenCaptureControl1 = new ScreenCaptureControl.ScreenCaptureControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // screenCaptureControl1
            // 
            this.screenCaptureControl1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.screenCaptureControl1.ConnectionParameters = null;
            this.screenCaptureControl1.EncodeLive = false;
            this.screenCaptureControl1.EncodeToFile = false;
            flvEncoderParams4.CompressionLevel = 5;
            flvFileParams4.FilePath = null;
            flvEncoderParams4.FileParams = flvFileParams4;
            flvEncoderParams4.KeyFrameFrequency = 20;
            flvEncoderParams4.SourceBytesPerPixel = ((byte)(4));
            flvStreamingParams4.ApplicationName = null;
            flvStreamingParams4.Port = 0;
            flvStreamingParams4.Protocol = "rtmp";
            flvStreamingParams4.PublishName = null;
            flvStreamingParams4.Record = false;
            flvStreamingParams4.ServerURL = null;
            flvStreamingParams4.StreamName = null;
            flvStreamingParams4.SWFUrl = null;
            flvEncoderParams4.StreamingParams = flvStreamingParams4;
            flvEncoderParams4.VideoHeight = 0;
            flvEncoderParams4.VideoWidth = 0;
            this.screenCaptureControl1.EncodingParameters = flvEncoderParams4;
            this.screenCaptureControl1.EventID = null;
            this.screenCaptureControl1.Location = new System.Drawing.Point(12, 12);
            this.screenCaptureControl1.Name = "screenCaptureControl1";
            this.screenCaptureControl1.Size = new System.Drawing.Size(268, 102);
            this.screenCaptureControl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(108, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 182);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.screenCaptureControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ScreenCaptureControl.ScreenCaptureControl screenCaptureControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

