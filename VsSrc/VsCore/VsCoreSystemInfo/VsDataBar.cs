// fozv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ycxf	
// jqgg	 By downloading, copying, installing or using the software you agree to this license.
// tdnt	 If you do not agree to this license, do not download, install,
// semr	 copy or use the software.
// wqkg	
// jxzr	                          License Agreement
// hsdt	         For OpenVss - Open Source Video Surveillance System
// esxv	
// ooil	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// ahph	
// yvxf	Third party copyrights are property of their respective owners.
// qufw	
// cvpo	Redistribution and use in source and binary forms, with or without modification,
// esla	are permitted provided that the following conditions are met:
// cfxq	
// nmca	  * Redistribution's of source code must retain the above copyright notice,
// gred	    this list of conditions and the following disclaimer.
// wbqp	
// bcho	  * Redistribution's in binary form must reproduce the above copyright notice,
// atbm	    this list of conditions and the following disclaimer in the documentation
// mgqj	    and/or other materials provided with the distribution.
// dirv	
// diiu	  * Neither the name of the copyright holders nor the names of its contributors 
// jyum	    may not be used to endorse or promote products derived from this software 
// twzy	    without specific prior written permission.
// pcab	
// eanb	This software is provided by the copyright holders and contributors "as is" and
// lxzj	any express or implied warranties, including, but not limited to, the implied
// eleg	warranties of merchantability and fitness for a particular purpose are disclaimed.
// vsxx	In no event shall the Prince of Songkla University or contributors be liable 
// ajzo	for any direct, indirect, incidental, special, exemplary, or consequential damages
// swgd	(including, but not limited to, procurement of substitute goods or services;
// ivud	loss of use, data, or profits; or business interruption) however caused
// udwj	and on any theory of liability, whether in contract, strict liability,
// gped	or tort (including negligence or otherwise) arising in any way out of
// vpkg	the use of this software, even if advised of the possibility of such damage.

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
