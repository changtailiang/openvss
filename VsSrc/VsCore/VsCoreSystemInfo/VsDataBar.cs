// xdom	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// uzdi	
// dqps	 By downloading, copying, installing or using the software you agree to this license.
// tkeg	 If you do not agree to this license, do not download, install,
// yvuo	 copy or use the software.
// vccg	
// mgri	                          License Agreement
// tmuk	         For OpenVSS - Open Source Video Surveillance System
// tgvu	
// lqeu	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ywnz	
// lquj	Third party copyrights are property of their respective owners.
// qnyp	
// ecou	Redistribution and use in source and binary forms, with or without modification,
// aiao	are permitted provided that the following conditions are met:
// hvor	
// vezm	  * Redistribution's of source code must retain the above copyright notice,
// ojuh	    this list of conditions and the following disclaimer.
// rzqz	
// odvw	  * Redistribution's in binary form must reproduce the above copyright notice,
// lhrg	    this list of conditions and the following disclaimer in the documentation
// nfgq	    and/or other materials provided with the distribution.
// rbud	
// qqnc	  * Neither the name of the copyright holders nor the names of its contributors 
// hwdg	    may not be used to endorse or promote products derived from this software 
// qivg	    without specific prior written permission.
// srye	
// mpfx	This software is provided by the copyright holders and contributors "as is" and
// mecz	any express or implied warranties, including, but not limited to, the implied
// dieq	warranties of merchantability and fitness for a particular purpose are disclaimed.
// yiun	In no event shall the Prince of Songkla University or contributors be liable 
// pqqa	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mnrs	(including, but not limited to, procurement of substitute goods or services;
// zofd	loss of use, data, or profits; or business interruption) however caused
// mlnv	and on any theory of liability, whether in contract, strict liability,
// gbdc	or tort (including negligence or otherwise) arising in any way out of
// vwrm	the use of this software, even if advised of the possibility of such damage.
// noyy	
// smih	Intelligent Systems Laboratory (iSys Lab)
// nhrb	Faculty of Engineering, Prince of Songkla University, THAILAND
// axsy	Project leader by Nikom SUVONVORN
// ynxy	Project website at http://code.google.com/p/openvss/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using NLog; 

namespace Vs.Core.SystemInfo
{
	/// <summary>
	/// Summary description for DataBar.
	/// </summary>
	public class VsDataBar : System.Windows.Forms.UserControl
	{
        static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		int _value;
		Color _colorBar;

		#region Constructor/Dispose
		public VsDataBar()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			BackColor = Color.Silver;

			_value = 0;
			_colorBar = Color.DarkBlue;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Name = "DataBar";
			this.Size = new System.Drawing.Size(128, 16);
		}
		#endregion

		#region "Properties"
		[Description("Gets or sets the current Bar Color in chart"), Category("Appearance")]
		public Color BarColor
		{
			get { return _colorBar; }
			set { _colorBar = value; }
		}

		[Description("Gets or sets the current value in data bar"), Category("Behavior")]
		public int Value
		{
			get { return _value; }
			set
			{
				_value = value;
				Invalidate();
			}
		}
		#endregion

		#region Drawing
		protected override void OnPaint(PaintEventArgs e)
		{
            try
            {
                Rectangle rt = this.ClientRectangle;
                e.Graphics.FillRectangle(new SolidBrush(_colorBar), 0, 0, rt.Width * _value / 100, rt.Height);
            }
            catch { }
				
			base.OnPaint(e);
		}
		#endregion

	}
}
