// lveq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ouhs	
// epnn	 By downloading, copying, installing or using the software you agree to this license.
// mdxo	 If you do not agree to this license, do not download, install,
// ocbp	 copy or use the software.
// brbz	
// yupa	                          License Agreement
// ragl	         For OpenVSS - Open Source Video Surveillance System
// lzzd	
// wjvr	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// puzo	
// jhvv	Third party copyrights are property of their respective owners.
// prvs	
// zizt	Redistribution and use in source and binary forms, with or without modification,
// ueru	are permitted provided that the following conditions are met:
// fgae	
// iccm	  * Redistribution's of source code must retain the above copyright notice,
// dtre	    this list of conditions and the following disclaimer.
// gjag	
// smqr	  * Redistribution's in binary form must reproduce the above copyright notice,
// ztlz	    this list of conditions and the following disclaimer in the documentation
// enlc	    and/or other materials provided with the distribution.
// afjr	
// sbmi	  * Neither the name of the copyright holders nor the names of its contributors 
// tvgh	    may not be used to endorse or promote products derived from this software 
// fisv	    without specific prior written permission.
// armp	
// isbh	This software is provided by the copyright holders and contributors "as is" and
// naul	any express or implied warranties, including, but not limited to, the implied
// vbzu	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qzlx	In no event shall the Prince of Songkla University or contributors be liable 
// jzme	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xsnw	(including, but not limited to, procurement of substitute goods or services;
// filq	loss of use, data, or profits; or business interruption) however caused
// bpzn	and on any theory of liability, whether in contract, strict liability,
// bvui	or tort (including negligence or otherwise) arising in any way out of
// ebdr	the use of this software, even if advised of the possibility of such damage.
// gams	
// vmrg	Intelligent Systems Laboratory (iSys Lab)
// wula	Faculty of Engineering, Prince of Songkla University, THAILAND
// ehsq	Project leader by Nikom SUVONVORN
// eecf	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Nolme.WinForms;
using System.Globalization;
using NLog;

namespace Vs.Playback
{
    public partial class VsChartPresent : UserControl
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        private Nolme.WinForms.ChartLegend m_panelChartLegend;
        private Nolme.WinForms.Chart m_chartSample1;
        private Nolme.WinForms.Chart m_chartSample2;
        private Nolme.WinForms.Chart m_chartSample3;

        public VsChartPresent()
        {
            InitializeComponent();
           // InitializeComponent2();
            //FillInterface();

            //ChartModel model = new ChartModel();
            //model.exData();
            //updateChartModel(model);

        }

        public void updateChartModel(VsChartModel model)
        {
            //MessageBox.Show(System.IO.Directory.GetCurrentDirectory());
            try
            {
                m_chartSample1.ChartDescription.Columns.Clear();
                m_panelChartLegend.ChartLegendDescription.Items.Clear();
                if (model.dataModel.Count > 0)
                {
                    //MessageBox.Show("this" +model.dataModel.Count );


                    //list<colum<value>>
                    List<List<int>> data = new List<List<int>>();
                    List<string> cams = new List<string>();

                    foreach (string head in model.headerNsme)
                    {
                        data.Add(new List<int>());
                    }


                    foreach (KeyValuePair<string, List<int>> kvp in model.dataModel)
                    {

                        //ChartColumn column = m_chartSample1.AddColumn(kvp);
                        int sum = 0;
                        int c = 0;
                        bool zeroValue = true;

                        foreach (int v in kvp.Value)
                        {
                            if (v > 0)
                            {
                                zeroValue = false;
                                break;
                            }
                        }

                        if (zeroValue)//debuggg
                        {
                            //c = 0;
                            foreach (int v in kvp.Value)
                            {
                                data[c].Add(v + 1);
                                sum =0;
                                c++;
                            }

                            //MessageBox.Show("rero");  

                        }
                        else
                        {
                            foreach (int v in kvp.Value)
                            {


                                data[c].Add(v);
                                //MessageBox.Show(">0");
                                sum += v;
                                c++;
                            }
                        }

                        cams.Add(kvp.Key);

                    }
                    int cc = 0;
                    foreach (string head in model.headerNsme)
                    {
                        ChartColumn column = m_chartSample1.AddColumn(data[cc].ToArray());
                        cc++;
                        column.Title = head;
                    }

                    Color[] predefinedColors = m_chartSample1.ChartDescription.PredefinedColors;

                    for (int i = 0; i < m_chartSample1.ChartDescription.NumberOfItemsPerColumn; i++)
                    {
                        m_panelChartLegend.AddItem(predefinedColors[i], cams[i]);
                    }

                    this.m_chartSample1.ChartDescription.VerticalAxisStep = 10000;//for auto set when step over
                    m_chartSample1.ChartDescription.BottomMargin = 80;

                    m_chartSample1.ChartDescription.MainTitle = model.mainTitle;
                    //m_chartSample1.ChartDescription.RenderingMode = ChartRenderingMode.Linear3d;
                    m_chartSample1.ChartDescription.DisplayHiddenSides = false;
                    m_chartSample1.CumulativeMode = ChartCumulativeMode.StartFrom0;

                    this.m_chartSample1.ChartDescription.VerticalAxisMinValue = 1;//for buggggggggggg?????????


                }
                m_panelChartLegend.Invalidate();
                m_chartSample1.Invalidate();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }


        private void InitializeComponent2()
        {
            this.components = new System.ComponentModel.Container();
            this.m_panelChartLegend = new Nolme.WinForms.ChartLegend(this.components);
            this.m_chartSample1 = new Nolme.WinForms.Chart(this.components);
            this.m_chartSample2 = new Nolme.WinForms.Chart(this.components);
            this.m_chartSample3 = new Nolme.WinForms.Chart(this.components);

            this.SuspendLayout();
            // 
            // m_panelChartLegend
            // 
            this.m_panelChartLegend.BackColor = System.Drawing.SystemColors.Info;
            this.m_panelChartLegend.ChartLegendDescription.BottomMargin = 20;
            this.m_panelChartLegend.Curvature = 15;
            this.m_panelChartLegend.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.m_panelChartLegend.ChartLegendDescription.ItemBottomMargin = 30;
            this.m_panelChartLegend.ChartLegendDescription.ItemFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular | FontStyle.Bold);
            this.m_panelChartLegend.ChartLegendDescription.ItemLeftMargin = 5;
            this.m_panelChartLegend.ChartLegendDescription.ItemRightMargin = 10;
            this.m_panelChartLegend.ChartLegendDescription.ItemSize = 10;
            this.m_panelChartLegend.ChartLegendDescription.ItemTopMargin = 20;
            this.m_panelChartLegend.ChartLegendDescription.LeftMargin = 20;
            this.m_panelChartLegend.Location = new System.Drawing.Point(8, 8);
            this.m_panelChartLegend.ChartLegendDescription.MainTitle = "รายการกล้องที่สนใจ";
            this.m_panelChartLegend.ChartLegendDescription.MainTitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular | FontStyle.Bold);
            this.m_panelChartLegend.Name = "m_panelChartLegend";
            this.m_panelChartLegend.ChartLegendDescription.RightMargin = 20;
            this.m_panelChartLegend.Size = new System.Drawing.Size(176, 304);
            this.m_panelChartLegend.TabIndex = 5;
            this.m_panelChartLegend.ChartLegendDescription.TopMargin = 20;
            // 
            // m_chartSample1
            // 
            this.m_chartSample1.BackColor = System.Drawing.Color.Silver;
            this.m_chartSample1.ChartDescription.BottomMargin = 80;
            this.m_chartSample1.ChartDescription.ColumnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular | FontStyle.Bold);
            this.m_chartSample1.ChartDescription.ColumnTitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular | FontStyle.Bold);
            this.m_chartSample1.Curvature = 15;
            this.m_chartSample1.ChartDescription.DeltaDepth = 10;
            this.m_chartSample1.ChartDescription.DisplayHiddenSides = true;
            this.m_chartSample1.ChartDescription.DisplayTextOnColumns = true;
            this.m_chartSample1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.m_chartSample1.ChartDescription.LeftMargin = 50;
            this.m_chartSample1.ChartDescription.LegendFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular | FontStyle.Bold);
            this.m_chartSample1.Location = new System.Drawing.Point(8, 8);
            this.m_chartSample1.ChartDescription.MainTitle = "แสดงกราฟเหตุการณ์";
            this.m_chartSample1.ChartDescription.MainTitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular | FontStyle.Bold);
            this.m_chartSample1.ChartDescription.MarginBetweenColumn = 20;
            this.m_chartSample1.Name = "m_chartSample1";
            this.m_chartSample1.ChartDescription.RenderingMode = Nolme.WinForms.ChartRenderingMode.Linear3d;
            this.m_chartSample1.ChartDescription.RightMargin = 20;
            this.m_chartSample1.Size = new System.Drawing.Size(456, 304);
            this.m_chartSample1.TabIndex = 4;
            this.m_chartSample1.ChartDescription.TopMargin = 20;
            this.m_chartSample1.ChartDescription.VerticalAxisMaxValue = 10000;
            this.m_chartSample1.ChartDescription.VerticalAxisMinValue = 0;
            this.m_chartSample1.ChartDescription.VerticalAxisStep = 1000;
            this.m_chartSample1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChartLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            
            this.panel1.Controls.Add(this.m_chartSample1);
            this.panel3.Controls.Add(this.m_panelChartLegend);

            this.ResumeLayout(false);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                m_chartSample1.ChartDescription.RenderingMode = ChartRenderingMode.Linear3d;
                m_chartSample1.Invalidate();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                m_chartSample1.ChartDescription.RenderingMode = ChartRenderingMode.BarWith3d;
                m_chartSample1.Invalidate();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }
    }
}
