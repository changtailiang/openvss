using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Nolme.WinForms;

using Nolme.Xml;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace TWinForms01_Charts
{
	/// <summary>
	/// Summary description for TWinForms01_ChartsForm.
	/// </summary>
	public class TWinForms01_ChartsForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Nolme.WinForms.ChartLegend m_panelChartLegend;
		private Nolme.WinForms.Chart m_chartSample1;
		private Nolme.WinForms.Chart m_chartSample2;
		private Nolme.WinForms.Chart m_chartSample3;
		private System.Windows.Forms.GroupBox m_groupCumulativeMode;
		private System.Windows.Forms.GroupBox m_groupRenderingMode;
		private System.Windows.Forms.RadioButton m_btnBar3d;
		private System.Windows.Forms.RadioButton m_btnBar3dGradient;
		private System.Windows.Forms.RadioButton m_btnLinear3d;
		private System.Windows.Forms.RadioButton m_btnStartFromLastValue;
		private System.Windows.Forms.RadioButton m_btnStartFrom0;
		private System.Windows.Forms.Timer m_mainTimer;
		private System.Windows.Forms.Button m_btnSaveAll;
		private System.Windows.Forms.Button m_btnSaveToXml;
		private System.Windows.Forms.Button m_btnClearValues;
		private System.Windows.Forms.Button m_btnLoadAllFromXml;
		private System.ComponentModel.IContainer components;

		public TWinForms01_ChartsForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			InitializeComponent2();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.FillInterface ();
			m_mainTimer.Start ();
		}

		void FillInterface ()
		{
			//
			// Chart 1
			//
			ChartColumn	column1 = m_chartSample1.AddColumn (-5000,    0,    0, 2500);
			ChartColumn	column2 = m_chartSample1.AddColumn (    0,    0, 2000,    0);
			ChartColumn	column3 = m_chartSample1.AddColumn (    0,-3000,    0,    0);
			ChartColumn	column4 = m_chartSample1.AddColumn (- 500,-1000,-2508, -500);
			ChartColumn	column5 = m_chartSample1.AddColumn (  100,  250,   45,  800);
			ChartColumn	column6 = m_chartSample1.AddColumn (    0,    0,    0,    0);
			ChartColumn	column7 = m_chartSample1.AddColumn (  753,  200,  120,  475);
			ChartColumn	column8 = m_chartSample1.AddColumn (  753,  200,  120,  475);
			
			column1.Title = "January";
			column2.Title = "February";
			column3.Title = "March";
			column4.Title = "April";
			column5.Title = "May";
			column6.Title = "June";
			column7.Title = "July";
			column8.Title = "August";

			m_chartSample1.ChartDescription.BottomMargin	= 80;
			m_chartSample1.ChartDescription.MainTitle	= "One year evolution";
			m_chartSample1.ChartDescription.RenderingMode = ChartRenderingMode.Linear3d;
			m_chartSample1.ChartDescription.DisplayHiddenSides = false;
			m_chartSample1.CumulativeMode	= ChartCumulativeMode.StartFrom0;

			//
			// Chart 2
			//
			m_chartSample2.AddColumn (-5000,  210,    0,  500);
			m_chartSample2.AddColumn (  500,  210,-2000,  150);
			m_chartSample2.AddColumn ( 3000,  220,  150,  275);
			m_chartSample2.AddColumn (- 500,-1000,-2508,- 500);
			m_chartSample2.AddColumn (  100,  250,   45,  800);
			m_chartSample2.AddColumn (    0,-1000,    0,    0);
			m_chartSample2.AddColumn (    0,    0, 3860,    0);

			m_chartSample2.ChartDescription.RenderingMode = ChartRenderingMode.BarWith3dGradient;
			m_chartSample2.CumulativeMode= ChartCumulativeMode.StartFromLastValue;


			//
			// Chart 3
			//
			m_chartSample3.AddColumn ( 90, 5);
			m_chartSample3.AddColumn ( 50,30);
			m_chartSample3.AddColumn (  5, 5);
			m_chartSample3.AddColumn ( 20,10);
			m_chartSample3.AddColumn ( 85,10);
			m_chartSample3.AddColumn (  0,30);
			m_chartSample3.AddColumn ( 40,20);

			m_chartSample3.ChartDescription.RenderingMode = ChartRenderingMode.BarWith3dGradient;
			m_chartSample3.CumulativeMode= ChartCumulativeMode.StartFromLastValue;
			

			//
			// Legend
			//
			m_panelChartLegend.ChartLegendDescription.MainTitle = "Who's who";
			Color[]	predefinedColors = m_chartSample1.ChartDescription.PredefinedColors;
			string[] legend = {"Man", "Woman", "Boy", "Girl"};
			for (int i = 0; i < m_chartSample1.ChartDescription.NumberOfItemsPerColumn; i++)
			{
				m_panelChartLegend.AddItem (predefinedColors[i], legend [i]);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TWinForms01_ChartsForm));
			this.m_groupCumulativeMode = new System.Windows.Forms.GroupBox();
			this.m_btnStartFromLastValue = new System.Windows.Forms.RadioButton();
			this.m_btnStartFrom0 = new System.Windows.Forms.RadioButton();
			this.m_groupRenderingMode = new System.Windows.Forms.GroupBox();
			this.m_btnBar3dGradient = new System.Windows.Forms.RadioButton();
			this.m_btnBar3d = new System.Windows.Forms.RadioButton();
			this.m_btnLinear3d = new System.Windows.Forms.RadioButton();
			this.m_mainTimer = new System.Windows.Forms.Timer(this.components);
			this.m_btnSaveAll = new System.Windows.Forms.Button();
			this.m_btnSaveToXml = new System.Windows.Forms.Button();
			this.m_btnClearValues = new System.Windows.Forms.Button();
			this.m_btnLoadAllFromXml = new System.Windows.Forms.Button();
			this.m_groupCumulativeMode.SuspendLayout();
			this.m_groupRenderingMode.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_groupCumulativeMode
			// 
			this.m_groupCumulativeMode.Controls.Add(this.m_btnStartFromLastValue);
			this.m_groupCumulativeMode.Controls.Add(this.m_btnStartFrom0);
			this.m_groupCumulativeMode.Location = new System.Drawing.Point(656, 136);
			this.m_groupCumulativeMode.Name = "m_groupCumulativeMode";
			this.m_groupCumulativeMode.Size = new System.Drawing.Size(120, 72);
			this.m_groupCumulativeMode.TabIndex = 8;
			this.m_groupCumulativeMode.TabStop = false;
			this.m_groupCumulativeMode.Text = "Cumulative mode";
			// 
			// m_btnStartFromLastValue
			// 
			this.m_btnStartFromLastValue.Location = new System.Drawing.Point(8, 40);
			this.m_btnStartFromLastValue.Name = "m_btnStartFromLastValue";
			this.m_btnStartFromLastValue.Size = new System.Drawing.Size(104, 28);
			this.m_btnStartFromLastValue.TabIndex = 11;
			this.m_btnStartFromLastValue.Text = "Start From Last Value";
			this.m_btnStartFromLastValue.CheckedChanged += new System.EventHandler(this.m_btnStartFromLastValue_CheckedChanged);
			// 
			// m_btnStartFrom0
			// 
			this.m_btnStartFrom0.Checked = true;
			this.m_btnStartFrom0.Location = new System.Drawing.Point(8, 16);
			this.m_btnStartFrom0.Name = "m_btnStartFrom0";
			this.m_btnStartFrom0.TabIndex = 10;
			this.m_btnStartFrom0.TabStop = true;
			this.m_btnStartFrom0.Text = "Start from 0";
			this.m_btnStartFrom0.CheckedChanged += new System.EventHandler(this.m_btnStartFrom0_CheckedChanged);
			// 
			// m_groupRenderingMode
			// 
			this.m_groupRenderingMode.Controls.Add(this.m_btnBar3dGradient);
			this.m_groupRenderingMode.Controls.Add(this.m_btnBar3d);
			this.m_groupRenderingMode.Controls.Add(this.m_btnLinear3d);
			this.m_groupRenderingMode.Location = new System.Drawing.Point(656, 8);
			this.m_groupRenderingMode.Name = "m_groupRenderingMode";
			this.m_groupRenderingMode.Size = new System.Drawing.Size(120, 128);
			this.m_groupRenderingMode.TabIndex = 9;
			this.m_groupRenderingMode.TabStop = false;
			this.m_groupRenderingMode.Text = "Rendering mode";
			// 
			// m_btnBar3dGradient
			// 
			this.m_btnBar3dGradient.Location = new System.Drawing.Point(8, 68);
			this.m_btnBar3dGradient.Name = "m_btnBar3dGradient";
			this.m_btnBar3dGradient.TabIndex = 10;
			this.m_btnBar3dGradient.Text = "Bar 3d gradient";
			this.m_btnBar3dGradient.CheckedChanged += new System.EventHandler(this.m_btnBar3dGradient_CheckedChanged);
			// 
			// m_btnBar3d
			// 
			this.m_btnBar3d.Location = new System.Drawing.Point(8, 48);
			this.m_btnBar3d.Name = "m_btnBar3d";
			this.m_btnBar3d.TabIndex = 9;
			this.m_btnBar3d.Text = "Bar 3d";
			this.m_btnBar3d.CheckedChanged += new System.EventHandler(this.m_btnBar3d_CheckedChanged);
			// 
			// m_btnLinear3d
			// 
			this.m_btnLinear3d.Checked = true;
			this.m_btnLinear3d.Location = new System.Drawing.Point(8, 24);
			this.m_btnLinear3d.Name = "m_btnLinear3d";
			this.m_btnLinear3d.TabIndex = 8;
			this.m_btnLinear3d.TabStop = true;
			this.m_btnLinear3d.Text = "Linear 3d";
			this.m_btnLinear3d.CheckedChanged += new System.EventHandler(this.m_btnLinear3d_CheckedChanged);
			// 
			// m_mainTimer
			// 
			this.m_mainTimer.Interval = 1000;
			this.m_mainTimer.Tick += new System.EventHandler(this.m_mainTimer_Tick);
			// 
			// m_btnSaveAll
			// 
			this.m_btnSaveAll.Location = new System.Drawing.Point(656, 232);
			this.m_btnSaveAll.Name = "m_btnSaveAll";
			this.m_btnSaveAll.Size = new System.Drawing.Size(120, 24);
			this.m_btnSaveAll.TabIndex = 10;
			this.m_btnSaveAll.Text = "Save All to image";
			this.m_btnSaveAll.Click += new System.EventHandler(this.m_btnSaveAll_Click);
			// 
			// m_btnSaveToXml
			// 
			this.m_btnSaveToXml.Location = new System.Drawing.Point(656, 256);
			this.m_btnSaveToXml.Name = "m_btnSaveToXml";
			this.m_btnSaveToXml.Size = new System.Drawing.Size(120, 24);
			this.m_btnSaveToXml.TabIndex = 11;
			this.m_btnSaveToXml.Text = "Save All to XML";
			this.m_btnSaveToXml.Click += new System.EventHandler(this.m_btnSaveToXml_Click);
			// 
			// m_btnClearValues
			// 
			this.m_btnClearValues.Location = new System.Drawing.Point(656, 208);
			this.m_btnClearValues.Name = "m_btnClearValues";
			this.m_btnClearValues.Size = new System.Drawing.Size(120, 24);
			this.m_btnClearValues.TabIndex = 12;
			this.m_btnClearValues.Text = "Clear values";
			this.m_btnClearValues.Click += new System.EventHandler(this.m_btnClearValues_Click);
			// 
			// m_btnLoadAllFromXml
			// 
			this.m_btnLoadAllFromXml.Location = new System.Drawing.Point(656, 280);
			this.m_btnLoadAllFromXml.Name = "m_btnLoadAllFromXml";
			this.m_btnLoadAllFromXml.Size = new System.Drawing.Size(120, 24);
			this.m_btnLoadAllFromXml.TabIndex = 13;
			this.m_btnLoadAllFromXml.Text = "Load all from XML";
			this.m_btnLoadAllFromXml.Click += new System.EventHandler(this.m_btnLoadAllFromXml_Click);
			// 
			// TWinForms01_ChartsForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(784, 557);
			this.Controls.Add(this.m_btnLoadAllFromXml);
			this.Controls.Add(this.m_btnClearValues);
			this.Controls.Add(this.m_btnSaveToXml);
			this.Controls.Add(this.m_btnSaveAll);
			this.Controls.Add(this.m_groupRenderingMode);
			this.Controls.Add(this.m_groupCumulativeMode);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "TWinForms01_ChartsForm";
			this.Text = "Nolmë Informatique 3D Chart - Vincent DUVERNET 2006";
			this.m_groupCumulativeMode.ResumeLayout(false);
			this.m_groupRenderingMode.ResumeLayout(false);
			this.ResumeLayout(false);

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
			this.m_panelChartLegend.ChartLegendDescription.ItemFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic);
			this.m_panelChartLegend.ChartLegendDescription.ItemLeftMargin = 5;
			this.m_panelChartLegend.ChartLegendDescription.ItemRightMargin = 10;
			this.m_panelChartLegend.ChartLegendDescription.ItemSize = 10;
			this.m_panelChartLegend.ChartLegendDescription.ItemTopMargin = 20;
			this.m_panelChartLegend.ChartLegendDescription.LeftMargin = 20;
			this.m_panelChartLegend.Location = new System.Drawing.Point(476, 8);
			this.m_panelChartLegend.ChartLegendDescription.MainTitle = "Main title";
			this.m_panelChartLegend.ChartLegendDescription.MainTitleFont = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
			this.m_panelChartLegend.Name = "m_panelChartLegend";
			this.m_panelChartLegend.ChartLegendDescription.RightMargin = 20;
			this.m_panelChartLegend.Size = new System.Drawing.Size(176, 304);
			this.m_panelChartLegend.TabIndex = 5;
			this.m_panelChartLegend.ChartLegendDescription.TopMargin = 20;
			// 
			// m_chartSample1
			// 
			this.m_chartSample1.BackColor = System.Drawing.Color.Silver;
			this.m_chartSample1.ChartDescription.BottomMargin = 20;
			this.m_chartSample1.ChartDescription.ColumnFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic);
			this.m_chartSample1.ChartDescription.ColumnTitleFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline);
			this.m_chartSample1.Curvature = 15;
			this.m_chartSample1.ChartDescription.DeltaDepth = 10;
			this.m_chartSample1.ChartDescription.DisplayHiddenSides = true;
			this.m_chartSample1.ChartDescription.DisplayTextOnColumns = true;
			this.m_chartSample1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.m_chartSample1.ChartDescription.LeftMargin = 50;
			this.m_chartSample1.ChartDescription.LegendFont = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
			this.m_chartSample1.Location = new System.Drawing.Point(8, 8);
			this.m_chartSample1.ChartDescription.MainTitle = "Main title";
			this.m_chartSample1.ChartDescription.MainTitleFont = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
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
			// 
			// m_chartSample2
			// 
			this.m_chartSample2.BackColor = System.Drawing.Color.Silver;
			this.m_chartSample2.ChartDescription.BottomMargin = 20;
			this.m_chartSample2.ChartDescription.ColumnFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic);
			this.m_chartSample2.ChartDescription.ColumnTitleFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline);
			this.m_chartSample2.Curvature = 15;
			this.m_chartSample2.ChartDescription.DeltaDepth = 10;
			this.m_chartSample2.ChartDescription.DisplayHiddenSides = true;
			this.m_chartSample2.ChartDescription.DisplayTextOnColumns = true;
			this.m_chartSample2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.m_chartSample2.ChartDescription.LeftMargin = 50;
			this.m_chartSample2.ChartDescription.LegendFont = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
			this.m_chartSample2.Location = new System.Drawing.Point(8, 320);
			this.m_chartSample2.ChartDescription.MainTitle = "Main title";
			this.m_chartSample2.ChartDescription.MainTitleFont = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
			this.m_chartSample2.ChartDescription.MarginBetweenColumn = 20;
			this.m_chartSample2.Name = "m_chartSample2";
			this.m_chartSample2.ChartDescription.RenderingMode = Nolme.WinForms.ChartRenderingMode.Linear3d;
			this.m_chartSample2.ChartDescription.RightMargin = 20;
			this.m_chartSample2.Size = new System.Drawing.Size(456, 232);
			this.m_chartSample2.TabIndex = 10;
			this.m_chartSample2.ChartDescription.TopMargin = 20;
			this.m_chartSample2.ChartDescription.VerticalAxisMaxValue = 10000;
			this.m_chartSample2.ChartDescription.VerticalAxisMinValue = 0;
			this.m_chartSample2.ChartDescription.VerticalAxisStep = 1000;
			// 
			// m_chartSample3
			// 
			this.m_chartSample3.BackColor = System.Drawing.Color.Silver;
			this.m_chartSample3.ChartDescription.BottomMargin = 40;
			this.m_chartSample3.ChartDescription.ColumnFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic);
			this.m_chartSample3.ChartDescription.ColumnTitleFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline);
			this.m_chartSample3.Curvature = 15;
			this.m_chartSample3.ChartDescription.DeltaDepth = 10;
			this.m_chartSample3.ChartDescription.DisplayHiddenSides = true;
			this.m_chartSample3.ChartDescription.DisplayTextOnColumns = true;
			this.m_chartSample3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.m_chartSample3.ChartDescription.LeftMargin = 50;
			this.m_chartSample3.ChartDescription.LegendFont = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
			this.m_chartSample3.Location = new System.Drawing.Point(470, 320);
			this.m_chartSample3.ChartDescription.MainTitle = "Real time";
			this.m_chartSample3.ChartDescription.MainTitleFont = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
			this.m_chartSample3.ChartDescription.MarginBetweenColumn = 10;
			this.m_chartSample3.Name = "m_chartSample3";
			this.m_chartSample3.ChartDescription.RenderingMode = Nolme.WinForms.ChartRenderingMode.Linear3d;
			this.m_chartSample3.ChartDescription.RightMargin = 20;
			this.m_chartSample3.Size = new System.Drawing.Size(300, 232);
			this.m_chartSample3.TabIndex = 10;
			this.m_chartSample3.ChartDescription.TopMargin = 20;
			this.m_chartSample3.ChartDescription.VerticalAxisMaxValue = 100;
			this.m_chartSample3.ChartDescription.VerticalAxisMinValue = 0;
			this.m_chartSample3.ChartDescription.VerticalAxisStep = 10;



			this.Controls.Add(this.m_panelChartLegend);
			this.Controls.Add(this.m_chartSample1);
			this.Controls.Add(this.m_chartSample2);
			this.Controls.Add(this.m_chartSample3);
			
			
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new TWinForms01_ChartsForm());
		}

		private void m_btnLinear3d_CheckedChanged(object sender, System.EventArgs e)
		{
			m_chartSample1.ChartDescription.RenderingMode = ChartRenderingMode.Linear3d;
			m_chartSample1.Invalidate ();
		}

		private void m_btnBar3d_CheckedChanged(object sender, System.EventArgs e)
		{
			m_chartSample1.ChartDescription.RenderingMode = ChartRenderingMode.BarWith3d;
			m_chartSample1.Invalidate ();
		}

		private void m_btnBar3dGradient_CheckedChanged(object sender, System.EventArgs e)
		{
			m_chartSample1.ChartDescription.RenderingMode = ChartRenderingMode.BarWith3dGradient;
			m_chartSample1.Invalidate ();
		}

		private void m_btnStartFrom0_CheckedChanged(object sender, System.EventArgs e)
		{
			m_chartSample1.CumulativeMode = ChartCumulativeMode.StartFrom0;
			m_chartSample1.Invalidate ();
		}

		private void m_btnStartFromLastValue_CheckedChanged(object sender, System.EventArgs e)
		{
			m_chartSample1.CumulativeMode = ChartCumulativeMode.StartFromLastValue;
			m_chartSample1.Invalidate ();
		}

		private void m_mainTimer_Tick(object sender, System.EventArgs e)
		{
			// Shift values
			m_chartSample3.ShiftLeft ();
			m_chartSample3.Invalidate ();

			// Add a new value with random
			if (m_chartSample3.ChartDescription.Columns.Count != 0)
			{
				Random RandomClass = new Random();
				ChartColumn LastColumn = (ChartColumn)m_chartSample3.ChartDescription.Columns [m_chartSample3.ChartDescription.Columns.Count-1];
				int [] newValuesArray = new int [LastColumn.Length];
				for (int i = 0; i < newValuesArray.Length; i++)
				{
					newValuesArray [i] = RandomClass.Next (50);
				}
				LastColumn.AssignValues (newValuesArray);
			}
			else
			{
				// All has been cleared, recreate columns
				m_chartSample3.AddColumn ( 90, 5);
				m_chartSample3.AddColumn ( 50,30);
				m_chartSample3.AddColumn (  5, 5);
				m_chartSample3.AddColumn ( 20,10);
				m_chartSample3.AddColumn ( 85,10);
				m_chartSample3.AddColumn (  0,30);
				m_chartSample3.AddColumn ( 40,20);

				m_chartSample3.ChartDescription.RenderingMode = ChartRenderingMode.BarWith3dGradient;
				m_chartSample3.CumulativeMode= ChartCumulativeMode.StartFromLastValue;
				m_chartSample3.AdjustVerticalAxis ();
			}
		}

		private void m_btnSaveAll_Click(object sender, System.EventArgs e)
		{
			string szPath;
			Bitmap Result;

			szPath = @"./ScreenCapture_chartSample1.bmp";
			Result = m_chartSample1.Capture ();
			Result.Save (szPath);
			MessageBox.Show (szPath, "chartSample1 saved", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

			szPath = @"./ScreenCapture_chartSample2.bmp";
			Result = m_chartSample2.Capture ();
			Result.Save (szPath);
			MessageBox.Show (szPath, "chartSample2 saved", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

			szPath = @"./ScreenCapture_chartSample3.bmp";
			Result = m_chartSample3.Capture ();
			Result.Save (szPath);
			MessageBox.Show (szPath, "chartSample3 saved", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

		}

		private void m_btnSaveToXml_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_chartSample1.Save (@"charSample1.xml");
				m_chartSample2.Save (@"charSample2.xml");
				m_chartSample3.Save (@"charSample3.xml");
				MessageBox.Show ("Save to XML OK", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
			}
			catch (Exception ex)
			{
				string sz = ex.ToString ();
			}
		}

		private void m_btnClearValues_Click(object sender, System.EventArgs e)
		{
			m_chartSample1.InitDefault ();
			m_chartSample1.Invalidate ();
			m_chartSample2.InitDefault ();
			m_chartSample2.Invalidate ();
			m_chartSample3.InitDefault ();
			m_chartSample3.Invalidate ();
		}

		private void m_btnLoadAllFromXml_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_chartSample1.Load (@"charSample1.xml");
				m_chartSample2.Load (@"charSample2.xml");
				m_chartSample3.Load (@"charSample3.xml");

				MessageBox.Show ("Load from XML OK", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

				m_chartSample1.Invalidate ();
				m_chartSample2.Invalidate ();
				m_chartSample3.Invalidate ();
			}
			catch (Exception ex)
			{
				string sz = ex.ToString ();
			}		
		}
	}
}
