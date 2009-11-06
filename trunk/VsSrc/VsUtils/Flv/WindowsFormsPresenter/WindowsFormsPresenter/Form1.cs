using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsPresenter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.screenCaptureControl1.EncodingParameters.SourceBytesPerPixel = 4;
            this.screenCaptureControl1.EncodingParameters.FileParams.FilePath = "c:\\file.fly";
            this.screenCaptureControl1.ConnectionParameters = new object[] { "this.usernameTextBox.Text", "this.fullName",
                "epresenceUrl.Host","epresenceUrl.Path","" +"epresenceUrl.Port","cpf.ConferencePassword"};
            this.screenCaptureControl1.EncodeToFile = true;
            this.screenCaptureControl1.start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.screenCaptureControl1.stop();
        }
    }
}
