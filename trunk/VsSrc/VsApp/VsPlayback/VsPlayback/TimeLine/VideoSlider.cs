// slkz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// gwft	
// tqhl	 By downloading, copying, installing or using the software you agree to this license.
// ysnf	 If you do not agree to this license, do not download, install,
// dtad	 copy or use the software.
// jfec	
// mxxp	                          License Agreement
// bxot	         For OpenVSS - Open Source Video Surveillance System
// ygwe	
// rixk	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// lazp	
// orfc	Third party copyrights are property of their respective owners.
// owfm	
// ijpm	Redistribution and use in source and binary forms, with or without modification,
// himi	are permitted provided that the following conditions are met:
// ypsw	
// comr	  * Redistribution's of source code must retain the above copyright notice,
// winu	    this list of conditions and the following disclaimer.
// vqri	
// fpov	  * Redistribution's in binary form must reproduce the above copyright notice,
// rvbe	    this list of conditions and the following disclaimer in the documentation
// rclp	    and/or other materials provided with the distribution.
// qjxj	
// womv	  * Neither the name of the copyright holders nor the names of its contributors 
// idmz	    may not be used to endorse or promote products derived from this software 
// enff	    without specific prior written permission.
// ilqs	
// rhhs	This software is provided by the copyright holders and contributors "as is" and
// trrc	any express or implied warranties, including, but not limited to, the implied
// nnea	warranties of merchantability and fitness for a particular purpose are disclaimed.
// cxbn	In no event shall the Prince of Songkla University or contributors be liable 
// kdyg	for any direct, indirect, incidental, special, exemplary, or consequential damages
// dwac	(including, but not limited to, procurement of substitute goods or services;
// coqd	loss of use, data, or profits; or business interruption) however caused
// qvvf	and on any theory of liability, whether in contract, strict liability,
// ltxj	or tort (including negligence or otherwise) arising in any way out of
// cfpe	the use of this software, even if advised of the possibility of such damage.
// xjhu	
// ylxg	Intelligent Systems Laboratory (iSys Lab)
// mrve	Faculty of Engineering, Prince of Songkla University, THAILAND
// njov	Project leader by Nikom SUVONVORN
// gepf	Project website at http://code.google.com/p/openvss/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace Vs.Playback.TimeLine
{
    // A delegate type for hooking up ValueChanged notifications. 
    public delegate void ValueChangedEventHandler(object Sender);

    [ToolboxBitmap(typeof(TrackBar))]
    [DefaultEvent("Scroll"), DefaultProperty("BarInnerColor")]
    public partial class VideoSlider : UserControl
    {
        private static string exePath = string.Empty;
        private static float zoomFactor = 0.0f;
        private static int _segmentCount = 0;
        private static int totalBarsHeight = 0;
        private static int barIndex = -1;
        private static int fileIndex = -1;

        private static DateTime currentDate;

        private float fBorderWidth = 0.25F;

        private RectangleF barHalfRect;
        private RectangleF barSegRect;
        private RectangleF thumbHalfRect;

        private Color m_chart_color;
        private Color m_back_color;
        private Color m_div_color;
        private Color m_axes_color;
        private Font m_font = new Font("Arial", 12);

        private int m_margin_top;
        private int m_margin_left;
        private int m_margin_bottom;

        private RectangleF m_default_rect;
        private RectangleF m_data_rect;
        private RectangleF m_limits_rect;
        private RectangleF m_screen_rect;
        private string m_x_label;
        private string m_y_label;

        private static int selectStart = 0;
        private static int selectEnd = 0;



        #region "EVENTS"

        /// <summary>
        /// Fires when DataRectangle's X value has changed
        /// </summary>
        [Description("Event fires when the X property changes")]
        [Category("Action")]
        public event EventHandler XChanged;

        /// <summary>
        /// Fires when Slider position has changed
        /// </summary>
        [Description("Event fires when the Value property changes")]
        [Category("Action")]
        public event EventHandler ValueChanged;


        /// <summary>
        /// Fires when user scrolls the Slider
        /// </summary>
        [Description("Event fires when the Slider position is changed")]
        [Category("Behavior")]
        public event ScrollEventHandler Scroll;

        /// <summary>
        /// Fires when thumb moves
        /// </summary>
        public delegate void ThumbMoveHandler(object sender, FireThumbEventArgs e);
        [Description("Event fires when the Thumb moves")]
        [Category("Behavior"), Browsable(false)]
        public event ThumbMoveHandler ThumbMove;

        #endregion "EVENTS"

        public VideoSlider()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw | ControlStyles.Selectable |
            ControlStyles.SupportsTransparentBackColor | ControlStyles.UserMouse |
            ControlStyles.UserPaint, true);

            InitializeComponent();

            //ArrayList m_data_sets = new ArrayList();
            m_div_color = System.Drawing.Color.White;
            m_axes_color = System.Drawing.Color.White;
            m_chart_color = Color.FromArgb(55, 63, 65);
            m_back_color = Color.FromArgb(55, 63, 65);
            m_font = new Font("Arial", 7);

            m_margin_top = 0;
            m_margin_left = 0;      //m_margin_left = m_margin_right
            m_margin_bottom = 20;

            m_x_label = "";
            m_y_label = "";

        }

        private void VideoSlider_Load(object sender, EventArgs e)
        {
            exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            barSelectedPenColor = Color.Orange;
            barSelectedInnerColor = Color.Orange;
            barSelectedOuterColor = Color.Orange;

        }

        #region "SLIDER"



        private static Bars[] bars = null;
        /// <summary>
        /// Gets or sets the color of the file pen.
        /// </summary>
        /// <value>The color of the file pen.</value>
        [Description("Get Bars array")]
        [Category("VideoSlider")]
        public Bars[] Bars
        {
            get { return bars; }
        }

        private bool blockPaint = false;
        /// <summary>
        /// Blocks Painting.
        /// </summary>
        /// <value>The size of the thumb.</value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value is lower than zero or grather than half of appropiate dimension</exception>
        [Description("Blocks Painting")]
        [Category("VideoSlider")]
        [DefaultValue(false)]
        public bool BlockPaint
        {
            get { return blockPaint; }
            set
            {
                blockPaint = value;
                //Invalidate();
            }
        }

        private RectangleF elapsedRect; //bounding rectangle of elapsed area

        private RectangleF selectedRect; //bounding rectangle of selected bar
        [Browsable(false)]
        public RectangleF SelectedRect
        {
            get { return selectedRect; }
        }

        private RectangleF thumbRect; //bounding rectangle of thumb area
        /// <summary>
        /// Gets the thumb rect. Usefull to determine bounding rectangle when creating custom thumb shape.
        /// </summary>
        /// <value>The thumb rect.</value>
        [Browsable(false)]
        public RectangleF ThumbRect
        {
            get { return thumbRect; }
        }

        private int thumbSize = 2;
        /// <summary>
        /// Gets or sets the size of the thumb.
        /// </summary>
        /// <value>The size of the thumb.</value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value is lower than zero or grather than half of appropiate dimension</exception>
        [Description("Set Slider thumb size")]
        [Category("VideoSlider")]
        [DefaultValue(2)]
        public int ThumbSize
        {
            get { return thumbSize; }
            set
            {
                if (value > 0 & value < ClientRectangle.Width)
                    thumbSize = value;
                else
                    throw new ArgumentOutOfRangeException("TrackSize has to be greather than zero and lower than half of Slider width");
                Invalidate();
            }
        }

        private GraphicsPath thumbCustomShape = null;
        /// <summary>
        /// Gets or sets the thumb custom shape. Use ThumbRect property to determine bounding rectangle.
        /// </summary>
        /// <value>The thumb custom shape. null means default shape</value>
        [Description("Set Slider's thumb's custom shape")]
        [Category("VideoSlider")]
        [Browsable(false)]
        [DefaultValue(typeof(GraphicsPath), "null")]
        public GraphicsPath ThumbCustomShape
        {
            get { return thumbCustomShape; }
            set
            {
                thumbCustomShape = value;
                thumbSize = (int)(value.GetBounds().Width) + 1;
                Invalidate();
            }
        }

        private Size thumbRoundRectSize = new Size(2, 2);
        /// <summary>
        /// Gets or sets the size of the thumb round rectangle edges.
        /// </summary>
        /// <value>The size of the thumb round rectangle edges.</value>
        [Description("Set Slider's thumb round rect size")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Size), "2; 2")]
        public Size ThumbRoundRectSize
        {
            get { return thumbRoundRectSize; }
            set
            {
                int h = value.Height, w = value.Width;
                if (h <= 0) h = 1;
                if (w <= 0) w = 1;
                thumbRoundRectSize = new Size(w, h);
                Invalidate();
            }
        }

        private Size borderRoundRectSize = new Size(2, 2);
        /// <summary>
        /// Gets or sets the size of the border round rect.
        /// </summary>
        /// <value>The size of the border round rect.</value>
        [Description("Set Slider's border round rect size")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Size), "2; 2")]
        public Size BorderRoundRectSize
        {
            get { return borderRoundRectSize; }
            set
            {
                int h = value.Height, w = value.Width;
                if (h <= 0) h = 1;
                if (w <= 0) w = 1;
                borderRoundRectSize = new Size(w, h);
                Invalidate();
            }
        }

        private int trackerValue = 0;
        /// <summary>
        /// Gets or sets the value of Slider.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value is outside appropriate range (min, max)</exception>
        [Description("Set Slider value")]
        [Category("ColorSlider")]
        [DefaultValue(50)]
        public int Value
        {
            get { return trackerValue; }
            set
            {
                if (value >= barMinimum & value <= barMaximum)
                {
                    trackerValue = value;
                    if (ValueChanged != null) ValueChanged(this, new EventArgs());
                    Invalidate();
                }
                else trackerValue = 0;//throw new ArgumentOutOfRangeException("Value is outside appropriate range (min, max)");
            }
        }

        private int mouseDownValue = 50;
        /// <summary>
        /// Gets or sets the value of MouseDown in seconds.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value is outside appropriate range (min, max)</exception>
        [Description("Set MouseDown value")]
        [Category("ColorSlider")]
        [DefaultValue(50)]
        public int MouseDownValue
        {
            get { return mouseDownValue; }
            set
            {
                if (value >= barMinimum & value <= barMaximum)
                {
                    mouseDownValue = value;
                    if (ValueChanged != null) ValueChanged(this, new EventArgs());
                    Invalidate();
                }
                else throw new ArgumentOutOfRangeException("Value is outside appropriate range (min, max)");
            }
        }

        private int barMinimum = 0;
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when minimal value is greather than maximal one</exception>
        [Description("Set Slider minimal point")]
        [Category("ColorSlider")]
        [DefaultValue(0)]
        public int Minimum
        {
            get { return barMinimum; }
            set
            {
                if (value < barMaximum)
                {
                    barMinimum = value;
                    if (trackerValue < barMinimum)
                    {
                        trackerValue = barMinimum;
                        if (ValueChanged != null) ValueChanged(this, new EventArgs());
                    }
                    Invalidate();
                }
                else throw new ArgumentOutOfRangeException("Minimal value is greather than maximal one");
            }
        }


        private int barMaximum = 86400;
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when maximal value is lower than minimal one</exception>
        [Description("Set Slider maximal point")]
        [Category("ColorSlider")]
        [DefaultValue(86400)]
        public int Maximum
        {
            get { return barMaximum; }
            set
            {
                if (value > barMinimum)
                {
                    barMaximum = value;
                    if (trackerValue > barMaximum)
                    {
                        trackerValue = barMaximum;
                        if (ValueChanged != null) ValueChanged(this, new EventArgs());
                    }
                    Invalidate();
                }
                else throw new ArgumentOutOfRangeException("Maximal value is lower than minimal one");
            }
        }

        private uint smallChange = 1;
        /// <summary>
        /// Gets or sets trackbar's small change. It affects how to behave when directional keys are pressed
        /// </summary>
        /// <value>The small change value.</value>
        [Description("Set trackbar's small change")]
        [Category("ColorSlider")]
        [DefaultValue(1)]
        public uint SmallChange
        {
            get { return smallChange; }
            set { smallChange = value; }
        }

        private uint largeChange = 5;

        /// <summary>
        /// Gets or sets trackbar's large change. It affects how to behave when PageUp/PageDown keys are pressed
        /// </summary>
        /// <value>The large change value.</value>
        [Description("Set trackbar's large change")]
        [Category("ColorSlider")]
        [DefaultValue(5)]
        public uint LargeChange
        {
            get { return largeChange; }
            set { largeChange = value; }
        }

        private bool drawFocusRectangle = true;
        /// <summary>
        /// Gets or sets a value indicating whether to draw focus rectangle.
        /// </summary>
        /// <value><c>true</c> if focus rectangle should be drawn; otherwise, <c>false</c>.</value>
        [Description("Set whether to draw focus rectangle")]
        [Category("ColorSlider")]
        [DefaultValue(true)]
        public bool DrawFocusRectangle
        {
            get { return drawFocusRectangle; }
            set
            {
                drawFocusRectangle = value;
                Invalidate();
            }
        }

        private bool drawSemitransparentThumb = true;
        /// <summary>
        /// Gets or sets a value indicating whether to draw semitransparent thumb.
        /// </summary>
        /// <value><c>true</c> if semitransparent thumb should be drawn; otherwise, <c>false</c>.</value>
        [Description("Set whether to draw semitransparent thumb")]
        [Category("ColorSlider")]
        [DefaultValue(true)]
        public bool DrawSemitransparentThumb
        {
            get { return drawSemitransparentThumb; }
            set
            {
                drawSemitransparentThumb = value;
                Invalidate();
            }
        }

        private bool mouseEffects = true;
        /// <summary>
        /// Gets or sets whether mouse entry and exit actions have impact on how control look.
        /// </summary>
        /// <value><c>true</c> if mouse entry and exit actions have impact on how control look; otherwise, <c>false</c>.</value>
        [Description("Set whether mouse entry and exit actions have impact on how control look")]
        [Category("ColorSlider")]
        [DefaultValue(true)]
        public bool MouseEffects
        {
            get { return mouseEffects; }
            set
            {
                mouseEffects = value;
                Invalidate();
            }
        }

        private int mouseWheelBarPartitions = 10;
        /// <summary>
        /// Gets or sets the mouse wheel bar partitions.
        /// </summary>
        /// <value>The mouse wheel bar partitions.</value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value isn't greather than zero</exception>
        [Description("Set to how many parts is bar divided when using mouse wheel")]
        [Category("ColorSlider")]
        [DefaultValue(10)]
        public int MouseWheelBarPartitions
        {
            get { return mouseWheelBarPartitions; }
            set
            {
                if (value > 0)
                    mouseWheelBarPartitions = value;
                else throw new ArgumentOutOfRangeException("MouseWheelBarPartitions has to be greather than zero");
            }
        }


        private static int _barCount = 0;
        [Description("Set bar height value")]
        [Category("VideoSlider")]
        [DefaultValue(0)]
        public int barCount
        {
            get { return _barCount; }
            set
            {
                if (value < 0)
                {
                    _barCount = value;
                    if (ValueChanged != null) ValueChanged(this, new EventArgs());
                    //Invalidate();
                }
                else throw new ArgumentOutOfRangeException("Value is outside appropriate range (min, max)");
            }
        }

        private int _barHeight = 60;
        /// <summary>
        /// Gets or sets height of a bar.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value is outside appropriate range (min, max)</exception>
        [Description("Set bar height value")]
        [Category("VideoSlider")]
        [DefaultValue(60)]
        public int barHeight
        {
            get { return _barHeight; }
            set
            {
                if (value >= 10 & value <= 150)
                {
                    _barHeight = value;
                    if (ValueChanged != null) ValueChanged(this, new EventArgs());
                    //Invalidate();
                }
                else throw new ArgumentOutOfRangeException("Value is outside appropriate range (min, max)");
            }
        }

        private bool recTypeSchedule = true;
        /// <summary>
        /// Gets or sets whether to show schedule recordings.
        /// </summary>
        /// <value>True/false setting.</value>
        [Description("Set Slider file pen color")]
        [Category("VideoSlider")]
        [DefaultValue(true)]
        public bool RecTypeSchedule
        {
            get { return recTypeSchedule; }
            set
            {
                recTypeSchedule = value;
                //Invalidate();
            }
        }

        private bool recTypeLive = true;
        /// <summary>
        /// Gets or sets whether to show live recordings.
        /// </summary>
        /// <value>True/false setting.</value>
        [Description("Set Slider file pen color")]
        [Category("VideoSlider")]
        [DefaultValue(true)]
        public bool RecTypeLive
        {
            get { return recTypeLive; }
            set
            {
                recTypeLive = value;
                //Invalidate();
            }
        }

        private bool recTypeAlerts = true;
        /// <summary>
        /// Gets or sets whether to show alert recordings.
        /// </summary>
        /// <value>True/false setting.</value>
        [Description("Set Slider file pen color")]
        [Category("VideoSlider")]
        [DefaultValue(true)]
        public bool RecTypeAlerts
        {
            get { return recTypeAlerts; }
            set
            {
                recTypeAlerts = value;
                //Invalidate();
            }
        }

        private String _displayDate = DateTime.Now.ToShortDateString();
        [Description("Selected search date.")]
        [Category("VideoSlider")]
        [DefaultValue("01/01/2008")]
        public String displayDate
        {
            get { return _displayDate; }
            set
            {
                _displayDate = value;
                //this.LABEL_Date.Text = _displayDate;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Action")]
        [Description("Gets the file index of the selected camera.")]
        public int FileIndex
        {
            get { return fileIndex; }
        }

        static bool isVLCPlaying = false;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Status")]
        [Description("Playing status.")]
        public bool IsVLCPlaying
        {
            get { return isVLCPlaying; }
            set { isVLCPlaying = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Button")]
        [Description("Gets the camera button.")]
        public int BarIndex
        {
            get { return barIndex; }
        }


        #endregion "SLIDER"


        #region "COLOR"

        #region "CHART COLORS"

        /// <summary>
        /// Gets or sets ChartColor.
        /// </summary>
        /// <value>ChartColor.</value>
        [Description("Gets or sets ChartColor.")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "White")]
        [Browsable(false)]
        public Color ChartColor
        {
            get
            {
                return m_chart_color;
            }
            set
            {
                m_chart_color = value;
            }
        }

        /// <summary>
        /// Gets or sets Chart AxesColor.
        /// </summary>
        /// <value>Chart AxesColor.</value>
        [Description("Gets or sets Chart AxesColor")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "White")]
        [Browsable(false)]
        public Color AxesColor
        {
            get
            {
                return m_axes_color;
            }
            set
            {
                m_axes_color = value;
            }
        }

        /// <summary>
        /// Gets or sets Chart DivisionColor.
        /// </summary>
        /// <value>Chart DivisionColor.</value>
        [Description("Gets or sets Chart DivisionColor")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "White")]
        [Browsable(false)]
        public Color DivisionColor
        {
            get
            {
                return m_div_color;
            }
            set
            {
                m_div_color = value;
            }
        }

        /// <summary>
        /// Gets or sets Chart BackgroundColor.
        /// </summary>
        /// <value>Chart BackgroundColor.</value>
        [Description("Gets or sets Chart BackgroundColor")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "Gray")]
        [Browsable(false)]
        public Color BackgroundColor
        {
            get
            {
                return m_back_color;
            }
            set
            {
                m_back_color = value;
                Invalidate();
            }
        }

        #endregion "CHART COLORS"

        #region "thumbOuterColor,thumbInnerColor,thumbPenColor"

        private Color thumbOuterColor = Color.White;
        /// <summary>
        /// Gets or sets the thumb outer color .
        /// </summary>
        /// <value>The thumb outer color.</value>
        [Description("Set Slider thumb outer color")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "White")]
        public Color ThumbOuterColor
        {
            get { return thumbOuterColor; }
            set
            {
                thumbOuterColor = value;
                Invalidate();
            }
        }

        private Color thumbInnerColor = Color.White;
        /// <summary>
        /// Gets or sets the inner color of the thumb.
        /// </summary>
        /// <value>The inner color of the thumb.</value>
        [Description("Set Slider thumb inner color")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "White")]
        public Color ThumbInnerColor
        {
            get { return thumbInnerColor; }
            set
            {
                thumbInnerColor = value;
                Invalidate();
            }
        }

        private Color thumbPenColor = Color.Silver;
        /// <summary>
        /// Gets or sets the color of the thumb pen.
        /// </summary>
        /// <value>The color of the thumb pen.</value>
        [Description("Set Slider thumb pen color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "Silver")]
        public Color ThumbPenColor
        {
            get { return thumbPenColor; }
            set
            {
                thumbPenColor = value;
                Invalidate();
            }
        }

        #endregion "thumbOuterColor,thumbInnerColor,thumbPenColor"

        #region "barOuterColor, barInnerColor, barPenColor"

        private Color barOuterColor = Color.FromArgb(55, 63, 65);
        /// <summary>
        /// Gets or sets the outer color of the bar.
        /// </summary>
        /// <value>The outer color of the bar.</value>
        [Description("Set Slider bar outer color")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "Color.FromArgb(55, 63, 65)")]
        public Color BarOuterColor
        {
            get { return barOuterColor; }
            set
            {
                barOuterColor = value;
                Invalidate();
            }
        }

        //DarkSlateBlue
        private Color barInnerColor = Color.FromArgb(55, 63, 65);
        /// <summary>
        /// Gets or sets the inner color of the bar.
        /// </summary>
        /// <value>The inner color of the bar.</value>
        [Description("Set Slider bar inner color")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "Color.FromArgb(55, 63, 65)")]
        public Color BarInnerColor
        {
            get { return barInnerColor; }
            set
            {
                barInnerColor = value;
                Invalidate();
            }
        }


        private Color barPenColor = Color.White;
        /// <summary>
        /// Gets or sets the color of the bar pen.
        /// </summary>
        /// <value>The color of the bar pen.</value>
        [Description("Set Slider bar pen color")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "White")]
        public Color BarPenColor
        {
            get { return barPenColor; }
            set
            {
                barPenColor = value;
                Invalidate();
            }
        }

        #endregion "barOuterColor, barInnerColor, barPenColor"

        #region "barSelectedOuterColor, barSelectedInnerColor, barSelectedPenColor"

        private Color barSelectedOuterColor = Color.Orange;
        /// <summary>
        /// Gets or sets the outer color of the bar.
        /// </summary>
        /// <value>The outer color of the bar.</value>
        [Description("Set Slider bar outer color")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "Orange")]
        public Color BarSelectedOuterColor
        {
            get { return barSelectedOuterColor; }
            set
            {
                barSelectedOuterColor = value;
                Invalidate();
            }
        }

        private Color barSelectedInnerColor = Color.Orange;
        /// <summary>
        /// Gets or sets the inner color of the bar.
        /// </summary>
        /// <value>The inner color of the bar.</value>
        [Description("Set Slider bar inner color")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "Orange")]
        public Color BarSelectedInnerColor
        {
            get { return barSelectedInnerColor; }
            set
            {
                barSelectedInnerColor = value;
                Invalidate();
            }
        }

        private Color barSelectedPenColor = Color.White;
        /// <summary>
        /// Gets or sets the color of the bar pen.
        /// </summary>
        /// <value>The color of the bar pen.</value>
        [Description("Set Slider bar pen color")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "White")]
        public Color BarSelectedPenColor
        {
            get { return barSelectedPenColor; }
            set
            {
                barSelectedPenColor = value;
                Invalidate();
            }
        }

        #endregion "barSelectedOuterColor, barSelectedInnerColor, barSelectedPenColor"

        #region "barMediaOuterColor, barMediaInnerColor, barMediaPenColor"

        private Color barMediaOuterColor = Color.Lime;
        /// <summary>
        /// Gets or sets the outer color of the bar.
        /// </summary>
        /// <value>The outer color of the bar.</value>
        [Description("Set Slider bar outer color")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "Lime")]
        public Color BarMediaOuterColor
        {
            get { return barMediaOuterColor; }
            set
            {
                barMediaOuterColor = value;
                Invalidate();
            }
        }

        private Color barMediaInnerColor = Color.Lime;
        /// <summary>
        /// Gets or sets the inner color of the bar.
        /// </summary>
        /// <value>The inner color of the bar.</value>
        [Description("Set Slider bar inner color")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "Lime")]
        public Color BarMediaInnerColor
        {
            get { return barMediaInnerColor; }
            set
            {
                barMediaInnerColor = value;
                Invalidate();
            }
        }

        private Color barMediaPenColor = Color.White;
        /// <summary>
        /// Gets or sets the color of the bar pen.
        /// </summary>
        /// <value>The color of the bar pen.</value>
        [Description("Set Slider bar pen color")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "White")]
        public Color BarMediaPenColor
        {
            get { return barMediaPenColor; }
            set
            {
                barMediaPenColor = value;
                Invalidate();
            }
        }

        #endregion "barMediaOuterColor, barMediaInnerColor, barMediaPenColor"



        private Color elapsedOuterColor = Color.DarkGreen;
        /// <summary>
        /// Gets or sets the outer color of the elapsed.
        /// </summary>
        /// <value>The outer color of the elapsed.</value>
        [Description("Set Slider's elapsed part outer color")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "DarkGreen")]
        public Color ElapsedOuterColor
        {
            get { return elapsedOuterColor; }
            set
            {
                elapsedOuterColor = value;
                Invalidate();
            }
        }

        private Color elapsedInnerColor = Color.Chartreuse;
        /// <summary>
        /// Gets or sets the inner color of the elapsed.
        /// </summary>
        /// <value>The inner color of the elapsed.</value>
        [Description("Set Slider's elapsed part inner color")]
        [Category("VideoSlider")]
        [DefaultValue(typeof(Color), "Chartreuse")]
        public Color ElapsedInnerColor
        {
            get { return elapsedInnerColor; }
            set
            {
                elapsedInnerColor = value;
                Invalidate();
            }
        }

        #endregion "COLOR"


        #region "CHART"

        private static float barOffsetY = 0.0f;
        /// <summary>
        /// 24 HRs time display. If false shows am/pm display with 12 hrs.
        /// </summary>
        /// <value>The thumb rect.</value>
        [Browsable(false)]
        public float BarOffsetY
        {
            get
            {
                return barOffsetY;
            }
            set
            {
                barOffsetY = value;
                Invalidate();
            }
        }

        private static float screenOffsetY = 0.0f;
        /// <summary>
        /// 24 HRs time display. If false shows am/pm display with 12 hrs.
        /// </summary>
        /// <value>The thumb rect.</value>
        [Browsable(false)]
        public float ScreenOffsetY
        {
            get
            {
                return screenOffsetY;
            }
            set
            {
                screenOffsetY = value;
                Invalidate();
            }
        }


        private static bool _time24 = true; //24 HRs time display
        /// <summary>
        /// 24 HRs time display. If false shows am/pm display with 12 hrs.
        /// </summary>
        /// <value>The thumb rect.</value>
        [Browsable(false)]
        public bool Time24
        {
            get
            {
                return _time24;
            }
            set
            {
                _time24 = value;
            }
        }


        [Browsable(false)]
        public Font Font
        {
            get
            {
                return m_font;
            }
            set
            {
                m_font = value;
            }
        }

        [Browsable(false)]
        public RectangleF ScreenRect
        {
            get
            {
                return m_screen_rect;
            }
        }

        [Browsable(false)]
        public RectangleF DataRect
        {
            get
            {
                return m_data_rect;
            }
            set
            {
                m_data_rect = value;
            }
        }

        [Browsable(false)]
        public string XLabel
        {
            get
            {
                return m_x_label;
            }
            set
            {
                m_x_label = value;
            }
        }

        [Browsable(false)]
        public string YLabel
        {
            get
            {
                return m_y_label;
            }
            set
            {
                m_y_label = value;
            }
        }

        #endregion "CHART"


        private void VideoSlider_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private RectangleF Offset(RectangleF rect, float x, float y)
        {
            rect.Offset(x, y);
            return rect;
        }

        public virtual string TranslateXValue(float val, int disp_precision)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, Convert.ToInt32(Math.Round(val, 0)), 0);
            if (disp_precision == 1)  //15min
                return string.Format("{0}", ts.Hours.ToString("00"));
            if (disp_precision == 2)  //15min
                return string.Format("{0}:{1}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"));
            if (disp_precision == 3)
                return string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));

            return string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));

        }

        public virtual string TranslateYValue(float val, int disp_precision)
        {
            // Default implementation
            return Math.Round(val, disp_precision).ToString();
        }

        public bool AtMinX()
        {
            return m_data_rect.Left <= m_limits_rect.Left;
        }

        public bool AtMaxX()
        {
            return m_data_rect.Right >= m_limits_rect.Right;
        }

        public bool AtMaxY()
        {
            return m_data_rect.Top <= m_limits_rect.Top;
        }

        public bool AtMinY()
        {
            return m_data_rect.Bottom >= m_limits_rect.Bottom;
        }

        public void Reset()
        {
            m_data_rect = m_limits_rect;
        }

        public void CalcMinMax()
        {
            float min_x;
            float min_y;
            float max_x;
            float max_y;

            min_x = max_x = 0;
            min_y = max_y = 0;

            min_x = 0;
            min_y = 0;
            max_x = 86400;
            max_y = barHeight * this.barCount;

            // Use limits rect for default data rect
            m_limits_rect = new RectangleF(min_x, min_y, max_x - min_x, max_y - min_y);
            m_data_rect = m_limits_rect;

            if (m_data_rect.Width == 0 || m_data_rect.Height == 0)
                throw new InvalidOperationException("Timeline must have non-zero width and height");
        }



        public PointF Transform(RectangleF from, RectangleF to, PointF pt_src)
        {
            PointF pt_dst = new PointF();
            pt_dst.X = (((pt_src.X - from.Left) / from.Width) * to.Width) + to.Left;
            pt_dst.Y = (((pt_src.Y - from.Top) / from.Height) * to.Height) + to.Top;
            return pt_dst;
        }

        public RectangleF Transform(RectangleF from, RectangleF to, RectangleF rt_src)
        {
            PointF pt_dst = new PointF();
            pt_dst.X = (((rt_src.X - from.Left) / from.Width) * to.Width) + to.Left;
            pt_dst.Y = (((rt_src.Y - from.Top) / from.Height) * to.Height) + to.Top;

            SizeF sz_dst = new SizeF();
            sz_dst.Width = (rt_src.Width / from.Width) * to.Width;
            sz_dst.Height = (rt_src.Height / from.Height) * to.Height;

            RectangleF rt_dst = new RectangleF(pt_dst, sz_dst);
            return rt_dst;
        }

        public SizeF Transform(RectangleF from, RectangleF to, SizeF sz_src)
        {
            SizeF sz_dst = new SizeF();
            sz_dst.Width = (sz_src.Width / from.Width) * to.Width;
            sz_dst.Height = (sz_src.Height / from.Height) * to.Height;
            return sz_dst;
        }

        public SizeF TransformY(RectangleF from, RectangleF to, SizeF sz_src)
        {
            SizeF sz_dst = new SizeF();
            sz_dst.Width = (sz_src.Width / from.Width) * to.Width;
            sz_dst.Height = to.Height;
            return sz_dst;
        }

        public void Snap(PointF pt)
        {
            // Correct for inverted y axis
            pt.Y = m_screen_rect.Bottom - pt.Y + m_margin_bottom;

            // Transform into data coordinates
            PointF origin = Transform(m_screen_rect, m_data_rect, pt);

            // Build a new rectangle from scratch
            float min_x, max_x, min_y, max_y;

            min_x = origin.X - (m_data_rect.Width / 2);
            max_x = origin.X + (m_data_rect.Width / 2);
            min_y = origin.Y - (m_data_rect.Height / 2);
            max_y = origin.Y + (m_data_rect.Height / 2);
            m_data_rect = new RectangleF(min_x, min_y, m_data_rect.Width, m_data_rect.Height);
        }

        public void Zoom(float percent)
        {
            zoomFactor = zoomFactor + percent;
            float dx = (percent / 200) * m_data_rect.Width;
            float dy = 0;
            m_data_rect = new RectangleF(m_data_rect.Left + dx,
                                         m_data_rect.Top + dy,
                                         m_data_rect.Width - (dx * 2),
                                         m_data_rect.Height - (dy * 2));
        }

        public void Zoom2(float width)
        {
            float dx = (float)(m_default_rect.Width - width) / m_default_rect.Width;
            float start = (float)trackerValue - width / 2;

            if (start < 0)
                start = 0;

            if (start + width > 86400)
                start = 86400 - width;

            m_data_rect = new RectangleF(start,
                                         m_data_rect.Top,
                                         width,
                                         m_data_rect.Height);
            m_limits_rect = new RectangleF(m_data_rect.Left, m_data_rect.Top, width, m_data_rect.Height);
        }

        public void ZoomRight()
        {
            float start = (float)trackerValue;

            if (start < 0)
                start = 0;

            if (start + m_data_rect.Width > 86400)
                start = 86400 - m_data_rect.Width;

            m_data_rect = new RectangleF(start, m_data_rect.Top, m_data_rect.Width, m_data_rect.Height);

            this.Value = trackerValue;
            Invalidate();

        }

        public void ZoomLeft()
        {
            float start = (float)trackerValue - m_data_rect.Width;

            if (start < 0)
                start = 0;

            if (start + m_data_rect.Width > 86400)
                start = 86400 - m_data_rect.Width;

            m_data_rect = new RectangleF(start, m_data_rect.Top, m_data_rect.Width, m_data_rect.Height);

            this.Value = trackerValue;
            Invalidate();


        }

        private void DrawXLabel(Graphics g)
        {
            Brush brush = new SolidBrush(m_axes_color);
            SizeF size = g.MeasureString(m_x_label, m_font);

            if (size.Width < m_screen_rect.Width)
            {
                g.DrawString(m_x_label, m_font, brush, new PointF(
                    m_screen_rect.Left + ((m_screen_rect.Width - size.Width) / 2),
                    m_screen_rect.Height + (m_margin_top) - size.Height));
            }

        }

        private void DrawYLabel(Graphics g)
        {
            g.RotateTransform(-90);
            Brush brush = new SolidBrush(m_axes_color);
            SizeF size = g.MeasureString(m_y_label, m_font);

            // Only draw if the label would fit on the screen
            if (size.Width < m_screen_rect.Height)
            {
                g.DrawString(m_y_label, m_font, brush,
                    new PointF(-(m_screen_rect.Height + size.Width) / 2 - m_margin_top, 0));
            }

            g.ResetTransform();
        }


        #region --- CalcDivIntervals --------------------------------------

        protected virtual void CalcDivIntervals(float ax_start, float ax_size, out float start_pos, out float major_div,
                                                out float minor_div, out int subdiv_index, out int mag)
        {
            //depends on zoom factor which is the width of m_data_rect
            //mag = Math.Abs(((int)Math.Log10(1 / ax_size)) + 1);
            //major_div = (float)Math.Pow(10, mag);

            mag = 1;
            int _minor_in_major = 10;
            major_div = ax_size / 24;

            if (ax_size == 86400)
            {
                major_div = ax_size / 24;
                _minor_in_major = 4;
            }
            else if (ax_size == 43200)
            {
                major_div = ax_size / 12;
                _minor_in_major = 10;
            }
            else if (ax_size == 21600)
            {
                major_div = ax_size / 6;
                _minor_in_major = 10;
            }
            else if (ax_size == 3600)       //1hr
            {
                major_div = ax_size / 4;
                _minor_in_major = 15;
            }
            else if (ax_size == 900)
            {
                major_div = ax_size / 4;
                _minor_in_major = 10;
            }
            if (ax_size == 60)
            {
                major_div = ax_size / 60;
                _minor_in_major = 10;
            }

            // For fractional extents, we need to take the reciprocal
            if (ax_size < 1)
                major_div = 1 / major_div;

            // Round the start position to an integer multiple of major_div
            start_pos = ((int)(ax_start / major_div)) * major_div;

            // If the initial position is negative, rounding start_pos will
            // increase its value, but start_pos should be <= ax_start
            if (start_pos > ax_start)
                start_pos -= major_div;

            // Calculate how many major divisions would actually get displayed
            // in this data range, and adjust the major division extent accordingly
            int major_divs_displayed = 0;

            while (major_divs_displayed < 3)
            {
                major_divs_displayed = 0;

                for (float test_pos = start_pos; test_pos < ax_start + ax_size;
                    test_pos += major_div)
                {
                    if (test_pos >= ax_start)
                        major_divs_displayed++;
                }

                if (major_divs_displayed > _minor_in_major)
                {
                    major_div *= 5;
                    break;
                }

                if (major_divs_displayed >= 3)
                    break;

                major_div /= _minor_in_major;
            }

            // There are 10 minor divisions to a major division
            minor_div = (float)major_div / _minor_in_major;

            // Now offset start_pos by multiples of minor_div so that it's 
            // just inside the data range.
            subdiv_index = 0;

            if (start_pos > ax_start)
            {
                while (start_pos >= ax_start + minor_div)
                {
                    start_pos -= minor_div;
                    subdiv_index = (subdiv_index + 1) % 10;
                }

                subdiv_index = (_minor_in_major - subdiv_index) % _minor_in_major;
            }
            else
            {
                while (start_pos < ax_start)
                {
                    start_pos += minor_div;
                    subdiv_index = (subdiv_index + 1) % _minor_in_major;
                }
            }
        }

        protected virtual void CalcDivIntervalsFromOrigin(float ax_start,
                                                float ax_size,
                                                out float start_pos,
                                                out float major_div,
                                                out float minor_div,
                                                out int subdiv_index,
                                                out int mag)
        {
            mag = 1;
            major_div = (float)3600;

            if (ax_size < 1)
                major_div = 1 / major_div;

            start_pos = 0;

            if (start_pos > ax_start)
                start_pos -= major_div;

            int major_divs_displayed = 24;

            // There are 4 minor divisions to a major division
            minor_div = (float)major_div / 4;

            // Now offset start_pos by multiples of minor_div so that it's 
            // just inside the data range.
            subdiv_index = 0;

            if (start_pos > ax_start)
            {
                while (start_pos >= ax_start + minor_div)
                {
                    start_pos -= minor_div;
                    subdiv_index = (subdiv_index + 1) % 4;
                }

                subdiv_index = (4 - subdiv_index) % 4;
            }
            else
            {
                while (start_pos < ax_start)
                {
                    start_pos += minor_div;
                    subdiv_index = (subdiv_index + 1) % 4;
                }
            }
        }

        protected virtual void CalcDivIntervals2(float ax_start, float ax_size, out float start_pos, out float major_div,
                                                out float minor_div, out int subdiv_index, out int mag)
        {
            mag = 1;
            major_div = (float)3600;

            if (ax_size < 1)
                major_div = 1 / major_div;

            start_pos = 0;

            if (start_pos > ax_start)
                start_pos -= major_div;

            /////////////////////////////////////////////////////////////////////////////
            major_div = 3600;

            if (ax_size == 86400)           //24hrs
                major_div = 86400 / 6;        //60/10
            else if (ax_size == 43200)      //12hrs
                major_div = 86400 / 12;     //60/5     
            else if (ax_size == 21600)      //6hrs
                major_div = 86400 / 24;     //60  /  60/24
            else if (ax_size == 3600)       //1hr
                major_div = 86400 / 24;      //60  /  60/6  21600
            else if (ax_size == 900)        //15min
                major_div = 900;
            else if (ax_size == 60)         //1min
                major_div = 60;

            /////////////////////////////////////////////////////////////////////////////

            // There are 60 minor divisions to a major division
            minor_div = (float)major_div / 60;

            // Offset start_pos by multiples of minor_div so it's just inside data range.
            subdiv_index = 0;

            if (start_pos > ax_start)
            {
                while (start_pos >= ax_start + minor_div)
                {
                    start_pos -= minor_div;
                    subdiv_index = (subdiv_index + 1) % 60;
                }
                subdiv_index = (60 - subdiv_index) % 60;
            }
            else
            {
                while (start_pos < ax_start)
                {
                    start_pos += minor_div;
                    subdiv_index = (subdiv_index + 1) % 60;
                }
            }
        }

        #endregion --- CalcDivIntervals -----------------------------------

        public void DrawXAxis00(Graphics g)
        {
            int mag, subdiv_index;
            float start_pos, major_div, minor_div;

            CalcDivIntervals(m_data_rect.Left, m_data_rect.Width,
                out start_pos, out major_div, out minor_div,
                out subdiv_index, out mag);

            // Draw the axis line
            Pen pen_axes = new Pen(m_axes_color);
            g.DrawLine(pen_axes, new PointF(m_screen_rect.Left, m_screen_rect.Bottom),
                new PointF(m_screen_rect.Right, m_screen_rect.Bottom));

            // Remember where we last drew a division marker, and use this to
            // decide how closely we should space them
            float last_string_end = Transform(m_data_rect, m_screen_rect,
                new PointF(start_pos - major_div, m_data_rect.Bottom)).X;

            // Draw the divisions
            Brush brush = new SolidBrush(m_div_color);

            for (float d_iter = start_pos; d_iter < m_data_rect.Right; d_iter += minor_div)
            {
                PointF pt = Transform(m_data_rect, m_screen_rect, new PointF(d_iter, m_data_rect.Bottom));

                // If it's a major division, draw a large marker and possibly a
                // division annotation as well
                if (subdiv_index == 0)
                {
                    g.DrawLine(pen_axes, pt, new PointF(pt.X, pt.Y + 5));

                    string str_val = TranslateXValue(d_iter, mag + 1);

                    if (str_val != "")
                    {
                        SizeF size = g.MeasureString(str_val, m_font);
                        PointF string_start = new PointF(pt.X - (size.Width / 2), pt.Y + 7);

                        // Only draw the string if it wouldn't run into a previous annotation
                        if (string_start.X > (last_string_end + 2) || d_iter == start_pos)
                        {
                            g.DrawString(str_val, m_font, brush, string_start);
                            last_string_end = pt.X + (size.Width / 2);
                        }
                    }
                }
                else
                {
                    // Otherwise draw a small marker
                    g.DrawLine(pen_axes, pt, new PointF(pt.X, pt.Y + 2));
                }

                subdiv_index = (subdiv_index + 1) % 10;
            }
        }

        public void DrawXAxis(Graphics g)
        {
            int mag, subdiv_index;
            int mag2, subdiv_index2;
            //float start_pos, major_div, minor_div;
            float start_pos, major_div, minor_div, subminor_div;

            CalcDivIntervals2(m_data_rect.Left, m_data_rect.Width,
                out start_pos, out major_div, out minor_div,
                out subdiv_index, out mag);

            // Draw the axis line
            Pen pen_axes = new Pen(m_axes_color);
            Pen penMajor = new Pen(Color.YellowGreen);
            g.DrawLine(pen_axes, new PointF(m_screen_rect.Left, m_screen_rect.Bottom),
                new PointF(m_screen_rect.Right, m_screen_rect.Bottom));

            // Remember only X-Pos where we last drew a division marker, 
            // and use this to decide how closely we should space them
            float last_string_end = Transform(m_data_rect, m_screen_rect,
                new PointF(start_pos - major_div, m_data_rect.Bottom)).X;

            // Draw the divisions
            Brush brush = new SolidBrush(m_div_color);
            Brush brushMajor = new SolidBrush(Color.YellowGreen);

            #region "LARGE DIVISIONS"
            for (float d_iter = start_pos; d_iter < m_data_rect.Right; d_iter += minor_div)
            {
                string str_val = string.Empty;
                PointF pt = Transform(m_data_rect, m_screen_rect, new PointF(d_iter, m_data_rect.Bottom));

                if (m_data_rect.Width <= 2160)
                {
                    g.DrawLine(pen_axes, pt, new PointF(pt.X, pt.Y + 2));
                }
                if ((subdiv_index == 0) && (m_data_rect.Width > 2160))
                {
                    g.DrawLine(penMajor, pt, new PointF(pt.X, pt.Y + 6));
                    if (m_data_rect.Width > 43200)
                        str_val = TranslateXValue(d_iter, 1);
                    else if (m_data_rect.Width > 21600)
                        str_val = TranslateXValue(d_iter, 2);
                    else
                        str_val = TranslateXValue(d_iter, 3);

                    if (str_val != "")
                    {
                        SizeF size = g.MeasureString(str_val, m_font);
                        PointF string_start = new PointF(pt.X - (size.Width / 2), pt.Y + 7);
                        if (string_start.X > (last_string_end + 2) || d_iter == start_pos)
                        {
                            g.DrawString(str_val, m_font, brush, string_start);
                            last_string_end = pt.X + (size.Width / 2);
                        }
                    }
                }

                if (m_data_rect.Width <= 3600)
                {
                    g.DrawLine(penMajor, pt, new PointF(pt.X, pt.Y + 6));
                    str_val = TranslateXValue(d_iter, 3);
                    if (str_val != "")
                    {
                        SizeF size = g.MeasureString(str_val, m_font);
                        PointF string_start = new PointF(pt.X - (size.Width / 2), pt.Y + 7);
                        if (string_start.X > (last_string_end + 2) || d_iter == start_pos)
                        {
                            g.DrawString(str_val, m_font, brush, string_start);
                            last_string_end = pt.X + (size.Width / 2);
                        }
                    }
                }
                subdiv_index = (subdiv_index + 1) % 15;
            }
            #endregion "LARGE DIVISIONS"


        }


        /// <summary>
        /// Creates the round rect path.
        /// </summary>
        /// <param name="rect">The rectangle on which graphics path will be spanned.</param>
        /// <param name="size">The size of rounded rectangle edges.</param>
        /// <returns></returns>
        public static GraphicsPath CreateRoundRectPath(Rectangle rect, Size size)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(rect.Left + size.Width / 2, rect.Top, rect.Right - size.Width / 2, rect.Top);
            gp.AddArc(rect.Right - size.Width, rect.Top, size.Width, size.Height, 270, 90);

            gp.AddLine(rect.Right, rect.Top + size.Height / 2, rect.Right, rect.Bottom - size.Width / 2);
            gp.AddArc(rect.Right - size.Width, rect.Bottom - size.Height, size.Width, size.Height, 0, 90);

            gp.AddLine(rect.Right - size.Width / 2, rect.Bottom, rect.Left + size.Width / 2, rect.Bottom);
            gp.AddArc(rect.Left, rect.Bottom - size.Height, size.Width, size.Height, 90, 90);

            gp.AddLine(rect.Left, rect.Bottom - size.Height / 2, rect.Left, rect.Top + size.Height / 2);
            gp.AddArc(rect.Left, rect.Top, size.Width, size.Height, 180, 90);
            return gp;
        }

        private string SecondsToString(int seconds)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, seconds, 0);
            return string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
        }
        string SecondsToString(float length)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, Convert.ToInt32(length), 0);
            return string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
        }
        string SecondsToString(double length)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, Convert.ToInt32(length), 0);
            return string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
        }

        #region "OVERRIDDE EVENTS"

        private bool mouseInRegion = false;

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            mouseInRegion = true;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            mouseInRegion = false;
            mouseInThumbRegion = false;
            mouseInSegmentRegion = false;
            mouseInSelectedRegion = false;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            //if (e.Button == MouseButtons.Left)
            //{
            //    ScrollEventType set = ScrollEventType.ThumbPosition;
            //    Point pt = e.Location;
            //    int p = pt.X;

            //    int margin = thumbSize >> 2;
            //    float coef = (float)(m_data_rect.Width) / (float)((ClientSize.Width) - (float)2 * m_margin_left);
            //    float trackerValueF = coef * ((float)pt.X - (float)m_margin_left) + (float)m_data_rect.X;
            //    trackerValue = Convert.ToInt32(trackerValueF);

            //    Capture = true;
            //    if (Scroll != null) Scroll(this, new ScrollEventArgs(ScrollEventType.ThumbTrack, trackerValue));

            //    if (ValueChanged != null) ValueChanged(this, new EventArgs());
            //    OnMouseMove(e);
            //    if (this.ScreenRect.Contains(e.X, e.Y))
            //    {
            //        Invalidate();
            //        mouseDownValue = trackerValue;
            //        selectStart = mouseDownValue;
            //    }
            //}
        }


        private bool mouseInThumbRegion = false;
        private bool mouseInSegmentRegion = false;
        private bool mouseInSelectedRegion = false;
        private bool selectedRegionDrag = false;


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            mouseInThumbRegion = IsPointInRect(e.Location, thumbRect);
            mouseInSelectedRegion = IsPointInRect(e.Location, selectedRect);


            //if (Capture & e.Button == MouseButtons.Left)
            //{
            //    ScrollEventType set = ScrollEventType.ThumbPosition;
            //    Point pt = e.Location;
            //    int p = pt.X;

            //    int margin = thumbSize >> 2;
            //    float coef = (float)(m_data_rect.Width) / (float)((ClientSize.Width) - (float)2 * m_margin_left);
            //    float trackerValueF = coef * ((float)pt.X - (float)m_margin_left) + (float)m_data_rect.X;
            //    trackerValue = Convert.ToInt32(trackerValueF);
            //    if (trackerValue <= barMinimum)
            //    {
            //        trackerValue = barMinimum;
            //        set = ScrollEventType.First;
            //    }
            //    else if (trackerValue >= barMaximum)
            //    {
            //        trackerValue = barMaximum;
            //        set = ScrollEventType.Last;
            //    }
            //    if (Scroll != null) Scroll(this, new ScrollEventArgs(set, trackerValue));
            //    if (ValueChanged != null) ValueChanged(this, new EventArgs());
            //}
            if ((mouseInSelectedRegion) && (Capture & e.Button == MouseButtons.Left))
            {
                selectedRegionDrag = true;
                ScrollEventType set = ScrollEventType.ThumbPosition;
                Point pt = e.Location;
                int p = pt.X;

                int margin = thumbSize >> 2;
                float coef = (float)(m_data_rect.Width) / (float)((ClientSize.Width) - (float)2 * m_margin_left);
                float trackerValueF = coef * ((float)pt.X - (float)m_margin_left) + (float)m_data_rect.X;
                int iTrackerValue = Convert.ToInt32(trackerValueF);
                if (iTrackerValue <= barMinimum)
                {
                    iTrackerValue = barMinimum;
                }
                else if (iTrackerValue >= barMaximum)
                {
                    iTrackerValue = barMaximum;
                }
                if ((barIndex > -1))
                    bars[barIndex].startSeconds = trackerValueF;

                //if (Scroll != null) Scroll(this, new ScrollEventArgs(set, trackerValue));
                //if (ValueChanged != null) ValueChanged(this, new EventArgs());
            }
            else if ((selectedRegionDrag) && (Capture & e.Button == MouseButtons.Left))
            {
                selectedRegionDrag = true;
                ScrollEventType set = ScrollEventType.ThumbPosition;
                Point pt = e.Location;
                int p = pt.X;

                int margin = thumbSize >> 2;
                float coef = (float)(m_data_rect.Width) / (float)((ClientSize.Width) - (float)2 * m_margin_left);
                float trackerValueF = coef * ((float)pt.X - (float)m_margin_left) + (float)m_data_rect.X;
                int iTrackerValue = Convert.ToInt32(trackerValueF);
                if (iTrackerValue <= barMinimum)
                {
                    iTrackerValue = barMinimum;
                }
                else if (iTrackerValue >= barMaximum)
                {
                    iTrackerValue = barMaximum;
                }
                if ((barIndex > -1))
                    bars[barIndex].startSeconds = trackerValueF;

                //if (Scroll != null) Scroll(this, new ScrollEventArgs(set, trackerValue));
                //if (ValueChanged != null) ValueChanged(this, new EventArgs());
            }

            Invalidate();
        }


        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            mouseInThumbRegion = IsPointInRect(e.Location, thumbRect);
            mouseInSelectedRegion = IsPointInRect(e.Location, selectedRect);

            if ((!selectedRegionDrag) && (Capture & e.Button == MouseButtons.Left))
            {
                ScrollEventType set = ScrollEventType.ThumbPosition;
                Point pt = e.Location;
                int p = pt.X;

                int margin = thumbSize >> 2;
                float coef = (float)(m_data_rect.Width) / (float)((ClientSize.Width) - (float)2 * m_margin_left);
                float trackerValueF = coef * ((float)pt.X - (float)m_margin_left) + (float)m_data_rect.X;
                trackerValue = Convert.ToInt32(trackerValueF);
                if (trackerValue <= barMinimum)
                {
                    trackerValue = barMinimum;
                    set = ScrollEventType.First;
                }
                else if (trackerValue >= barMaximum)
                {
                    trackerValue = barMaximum;
                    set = ScrollEventType.Last;
                }
                if (Scroll != null) Scroll(this, new ScrollEventArgs(set, trackerValue));
                if (ValueChanged != null) ValueChanged(this, new EventArgs());
            }
            Invalidate();
            //selectedRegionDrag = false;

        }

        /// <summary>
        /// Raises OnMouseUp Event.
        /// </summary>
        /// <param name="e">A System.Windows.Forms.MouseEventArgs that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Capture = false;
            mouseInThumbRegion = IsPointInRect(e.Location, thumbRect);
            //mouseInSelectedRegion = IsPointInRect(e.Location, selectedRect);

            int margin = thumbSize >> 2;
            float coef = (float)(m_data_rect.Width) / (float)((ClientSize.Width) - (float)2 * m_margin_left);
            float trackerValueF = coef * ((float)e.Location.X - (float)m_margin_left) + (float)m_data_rect.X;
            //trackerValue = Convert.ToInt32(trackerValueF);

            //if (Scroll != null) Scroll(this, new ScrollEventArgs(ScrollEventType.EndScroll, trackerValue));
            //if (ValueChanged != null) ValueChanged(this, new EventArgs());
            //Invalidate();
            //selectEnd = trackerValue;

            if ((selectedRegionDrag) && (barIndex > -1))
            {
                selectedRegionDrag = false;
                bars[barIndex].startSeconds = trackerValueF;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseWheel"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            //int v = e.Delta / 120 * (Maximum - Minimum) / mouseWheelBarPartitions;
            //SetProperValue(Value + v);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyUp"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs"></see> that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Left:
                    SetProperValue(Value - (int)smallChange);
                    if (Scroll != null) Scroll(this, new ScrollEventArgs(ScrollEventType.SmallDecrement, Value));
                    break;
                case Keys.Up:
                case Keys.Right:
                    SetProperValue(Value + (int)smallChange);
                    if (Scroll != null) Scroll(this, new ScrollEventArgs(ScrollEventType.SmallIncrement, Value));
                    break;
                case Keys.Home:
                    Value = barMinimum;
                    break;
                case Keys.End:
                    Value = Maximum;
                    break;
                case Keys.PageDown:
                    SetProperValue(Value - (int)largeChange);
                    if (Scroll != null) Scroll(this, new ScrollEventArgs(ScrollEventType.LargeDecrement, Value));
                    break;
                case Keys.PageUp:
                    SetProperValue(Value + (int)largeChange);
                    if (Scroll != null) Scroll(this, new ScrollEventArgs(ScrollEventType.LargeIncrement, Value));
                    break;
            }
            if (Scroll != null && Value == Minimum) Scroll(this, new ScrollEventArgs(ScrollEventType.First, Value));
            if (Scroll != null && Value == Maximum) Scroll(this, new ScrollEventArgs(ScrollEventType.Last, Value));
            Point pt = PointToClient(Cursor.Position);
            OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, pt.X, pt.Y, 0));
        }

        /// <summary>
        /// Processes a dialog key.
        /// </summary>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"></see> values that represents the key to process.</param>
        /// <returns>
        /// true if the key was processed by the control; otherwise, false.
        /// </returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Tab | ModifierKeys == Keys.Shift)
                return base.ProcessDialogKey(keyData);
            else
            {
                OnKeyDown(new KeyEventArgs(keyData));
                return true;
            }
        }

        #endregion "OVERRIDDE EVENTS"


        #region "Help Routines"

        /// <summary>
        /// Desaturates colors from given array.
        /// </summary>
        /// <param name="colorsToDesaturate">The colors to be desaturated.</param>
        /// <returns></returns>
        public static Color[] DesaturateColors(params Color[] colorsToDesaturate)
        {
            Color[] colorsToReturn = new Color[colorsToDesaturate.Length];
            for (int i = 0; i < colorsToDesaturate.Length; i++)
            {
                //use NTSC weighted avarage
                int gray =
                    (int)(colorsToDesaturate[i].R * 0.3 + colorsToDesaturate[i].G * 0.6 + colorsToDesaturate[i].B * 0.1);
                colorsToReturn[i] = Color.FromArgb(-0x010101 * (255 - gray) - 1);
            }
            return colorsToReturn;
        }

        /// <summary>
        /// Lightens colors from given array.
        /// </summary>
        /// <param name="colorsToLighten">The colors to lighten.</param>
        /// <returns></returns>
        public static Color[] LightenColors(params Color[] colorsToLighten)
        {
            Color[] colorsToReturn = new Color[colorsToLighten.Length];
            for (int i = 0; i < colorsToLighten.Length; i++)
            {
                colorsToReturn[i] = ControlPaint.Light(colorsToLighten[i]);
            }
            return colorsToReturn;
        }

        /// <summary>
        /// Sets the trackbar value so that it wont exceed allowed range.
        /// </summary>
        /// <param name="val">The value.</param>
        private void SetProperValue(int val)
        {
            if (val < Minimum) Value = Minimum;
            else if (val > Maximum) Value = Maximum;
            else Value = val;
        }

        /// <summary>
        /// Determines whether rectangle contains given point.
        /// </summary>
        /// <param name="pt">The point to test.</param>
        /// <param name="rect">The base rectangle.</param>
        /// <returns>
        /// 	<c>true</c> if rectangle contains given point; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsPointInRect(Point pt, Rectangle rect)
        {
            if (pt.X > rect.Left & pt.X < rect.Right & pt.Y > rect.Top & pt.Y < rect.Bottom)
                return true;
            else return false;
        }

        private static bool IsPointInRect(PointF pt, RectangleF rect)
        {
            if (pt.X > rect.Left & pt.X < rect.Right & pt.Y > rect.Top & pt.Y < rect.Bottom)
                return true;
            else return false;
        }

        private static bool IsPointInRect(Point pt, RectangleF rect)
        {
            if ((float)pt.X > rect.Left & (float)pt.X < rect.Right & (float)pt.Y > rect.Top & (float)pt.Y < rect.Bottom)
                return true;
            else return false;
        }

        public void SelectBar(int iBar)
        {
            barIndex = iBar;
            Invalidate();
        }

        private void VideoSlider_Move(object sender, EventArgs e)
        {
            if (this.Top > 0)
                this.Top = 0;

            if (this.Left > 0)
                this.Left = 0;
        }

        #endregion "Help Routines"

        #region "CONTROLS"

        public void SetPosition()
        {
            float ff = this.DataRect.X + this.DataRect.Width;
            Time tt = new Time(Convert.ToInt32(ff));
        }

        private SizeF GetMoveStep()
        {
            // Movement step = 1/20th window size
            SizeF size = new SizeF(Width / 24, Height / 24);
            return Transform(this.ScreenRect, this.DataRect, size);
        }

        private SizeF GetMoveSlider(float s)
        {
            SizeF size = new SizeF(s, s);
            return Transform(this.ScreenRect, this.DataRect, size);
        }


        public void MoveLeft()
        {
            if (this.DataRect.Left <= barMinimum)
                return;
            //if (this.DataRect.Left + this.DataRect.Width >= barMaximum)
            //    return;

            this.DataRect = Offset(this.DataRect, -GetMoveStep().Width, 0);
            Invalidate();

        }

        public void MoveRight()
        {
            //if (this.DataRect.Left <= barMinimum)
            //    return;
            if (this.DataRect.Left + this.DataRect.Width >= barMaximum)
                return;

            this.DataRect = Offset(this.DataRect, GetMoveStep().Width, 0);
            Invalidate();
        }

        public void MoveVertical(float fPosition)
        {
            screenOffsetY += fPosition;
            Invalidate();
        }

        public void MoveUp()
        {
            screenOffsetY += barHeight;
            Invalidate();
        }

        public void MoveDown()
        {
            screenOffsetY -= barHeight;
            Invalidate();
        }

        public void ZoomIn()
        {
            this.Zoom(10);
            Invalidate();
        }

        public void ZoomOut()
        {
            this.Zoom(-10);
            Invalidate();
        }


        private Pen pen;
        private StringFormat format;
        private void XAxis_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int scale;
            int step;
            int small;
            int big;
            int number;
            string unit;
            if ((m_data_rect.Width <= 86400) && (m_data_rect.Width > 86400))
            {
                g.PageUnit = GraphicsUnit.World;
                step = 5;
                small = 10;
                big = 50;
                number = 100;
                scale = 1;
                unit = " Hours";
            }
            else if ((m_data_rect.Width <= 43200) && (m_data_rect.Width > 21600))
            {
                g.PageUnit = GraphicsUnit.World;
                g.PageScale = 1f / 12f;
                step = 1;
                small = 2;
                big = 6;
                number = 12;
                scale = 12;
                unit = "m";
            }
            else if ((m_data_rect.Width <= 21600) && (m_data_rect.Width > 3600))
            {
                g.PageUnit = GraphicsUnit.World;
                g.PageScale = 1f;
                step = 1;
                small = 5;
                big = 10;
                number = 10;
                scale = 10;
                unit = " s.";
            }
            else if ((m_data_rect.Width <= 3600) && (m_data_rect.Width > 900))
            {
                g.PageUnit = GraphicsUnit.World;
                g.PageScale = 1f;
                step = 1;
                small = 5;
                big = 10;
                number = 10;
                scale = 10;
                unit = " s.";
            }
            else if ((m_data_rect.Width <= 900) && (m_data_rect.Width > 0))
            {
                g.PageUnit = GraphicsUnit.World;
                g.PageScale = 1f;
                step = 1;
                small = 5;
                big = 10;
                number = 10;
                scale = 10;
                unit = " s.";
            }
            else
                return;

            PointF[] point = new PointF[] {
				new PointF(2, 2), new PointF(5, 5), new Point(this.Size), this.Location
			};
            g.TransformPoints(CoordinateSpace.World, CoordinateSpace.Device, point);
            float infoDelta = point[0].Y; // point[0].X;
            float stroke = point[1].Y; // point[1].X;
            int length = (int)(point[2].X + point[2].Y);

            //if (!false)
            //{
            //    g.RotateTransform(90, MatrixOrder.Prepend);
            //    g.TranslateTransform(point[2].X, 0, MatrixOrder.Append);
            //}

            for (int i = 0; i < length; i += step)
            {
                float d = 1;
                if (i % small == 0)
                {
                    if (i % big == 0)
                    {
                        d = 3;
                    }
                    else
                    {
                        d = 2;
                    }
                }
                g.DrawLine(this.pen, i, 0f, i, d * stroke);
                if ((i % number) == 0)
                {
                    string text = (i / scale).ToString(CultureInfo.InvariantCulture);
                    SizeF size = g.MeasureString(text, this.Font, length, this.format);
                    g.DrawString(text, this.Font, Brushes.Black, i - size.Width / 2, d * stroke, this.format);
                }
            }
            string info = string.Format(CultureInfo.InvariantCulture,
                "X={0} Y={1} Length={2}{3}",
                Math.Round(point[3].X / scale, 1),
                Math.Round(point[3].Y / scale, 1),
                Math.Round((float)(point[2].X) / scale, 1), unit);
            SizeF infoSize = g.MeasureString(info, this.Font, length, this.format);
            float y = (float)(point[2].Y);
            g.DrawString(info, this.Font, Brushes.Black,
                (y - infoSize.Height) / 2, y - infoSize.Height - infoDelta, this.format
            );
        }

        #endregion "CONTROLS"

        protected override void OnPaint(PaintEventArgs e)
        {
            if ((!blockPaint) && ((bars != null) && (bars.GetLength(0) > 0) && (barCount > 0)))
            {
                // Calculate main drawing region; axis markers will be draw outside of this
                m_screen_rect = e.Graphics.VisibleClipBounds;

                // Reduce rectangle to accommodate the margins
                //m_screen_rect.Inflate(new Size(-m_margin_left, -m_margin_right));
                //    m_screen_rect.Inflate(new Size(-m_margin_left, -m_margin_right));
                m_screen_rect.Size = new SizeF(m_screen_rect.Width - (m_margin_left + m_margin_left), m_screen_rect.Height - (m_margin_top + m_margin_bottom));

                // Draw labels
                //DrawXLabel(e.Graphics);
                //DrawYLabel(e.Graphics);

                // Draw only an XAxis for video control
                DrawXAxis(e.Graphics);
                //DrawYAxis(e.Graphics);

                // Set clipping region, based on any margin settings;
                // the clipping region is inclusive, so we need to inflate it
                RectangleF clip_rect = m_screen_rect;
                clip_rect.Inflate(1, 1);
                e.Graphics.SetClip(clip_rect);

                // Screen origin is top-left, so y-axis needs to be reversed
                float y_offset = m_screen_rect.Bottom + m_margin_bottom + m_margin_top;

                #region "DRAW BARS"

                float zBarHeight = (m_data_rect.Height / barCount);


                //Random ran = new Random(DateTime.Now.Millisecond);

                for (int i = 0; i < bars.Length; i++)
                {
                    //draw bar band 
                    ///////////////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////////////
                    // MUST OFFSET BY RELATIVE AMOUNT SCREEN IS MOVED UP OR DOWN
                    // SINCE WE ARE NOT ZOOMING OR TRANSFORMING IN THE Y DIRECTION
                    //float f1 = 1f;
                    //if (m_default_rect.Height > 0)
                    //    f1 = m_default_rect.Height;

                    float newY = ((float)i * zBarHeight) + screenOffsetY;
                    //float newY = ((float)i * zBarHeight) + screenOffsetY+(m_screen_rect.Height- (float)this.ClientSize.Height);
                    ///////////////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////////////
                    PointF ZP1 = new PointF(m_data_rect.Left, (float)i * zBarHeight);
                    SizeF ZS1 = new SizeF((float)m_data_rect.Width, zBarHeight);
                    PointF ztoF = Transform(m_data_rect, m_screen_rect, ZP1);
                    SizeF ztoR = Transform(m_data_rect, m_screen_rect, ZS1);


                    #region "INNER BARS"
                    if (bars[i].motions != null)
                        for (int j = 0; j < bars[i].motions.Length; j++)
                        {
                            float xStart = 0;
                            float zwidth = 1;


                            xStart = (float)bars[i].motions[j].timeBegin.TimeOfDay.TotalSeconds;
                            zwidth = (float)bars[i].motions[j].timeEnd.TimeOfDay.TotalSeconds - xStart;
                           
                            if (zwidth == 0)
                            {
                                continue;
                            }
                            else if (zwidth < 0)
                            {
                                zwidth = 1;
                            }

                            // xStart = (float)bars[i].startSeconds ;
                            // zwidth = (float)bars[i].FileLength;


                            //barSegRect = new RectangleF(xStart, (i * zBarHeight), zwidth, zBarHeight/3);
                            //newY - we must account for shifting the m_screen_rect up or down
                            barSegRect = new RectangleF(xStart, newY, zwidth, zBarHeight / 3);
                            barSegRect = Transform(m_data_rect, m_screen_rect, barSegRect);
                            //barSegRect = new RectangleF(barSegRect.X, (i * zBarHeight), barSegRect.Width, zBarHeight / 3);
                            barSegRect = new RectangleF(barSegRect.X, newY, barSegRect.Width, zBarHeight / 3);

                            //barOffsetY = 0;
                            if (zBarHeight - (6 * barOffsetY) > 3)
                            {
                                //float xBarHeight = (zBarHeight - (4 * barOffsetY)) / 3;
                                barSegRect = new RectangleF(barSegRect.X, newY, barSegRect.Width, (zBarHeight - (6 * barOffsetY)) / 3);
                            }



                            if (bars[i].goodData)
                            {
                                {
                                    RectangleF barSegRect2 = new RectangleF(barSegRect.X, barSegRect.Y, barSegRect.Width, 3 * barSegRect.Height);
                                    using (LinearGradientBrush lgbBarMedia = new LinearGradientBrush(barSegRect,
                                        barMediaOuterColor, barMediaInnerColor, LinearGradientMode.Horizontal))
                                    {
                                        lgbBarMedia.WrapMode = WrapMode.TileFlipXY;
                                        e.Graphics.FillRectangle(lgbBarMedia, barSegRect2);
                                    }
                                }

                            }

                            if (i == barIndex)
                            {
                                selectedRect = new RectangleF(barSegRect.X, barSegRect.Y, barSegRect.Width, barSegRect.Height);
                                barSegRect = new RectangleF(barSegRect.X, barSegRect.Y, barSegRect.Width, barSegRect.Height);
                                using (LinearGradientBrush lgbBarSelected = new LinearGradientBrush(barSegRect,
                                    barSelectedOuterColor, barSelectedInnerColor, LinearGradientMode.Horizontal))
                                {
                                    lgbBarSelected.WrapMode = WrapMode.TileFlipXY;
                                    e.Graphics.FillRectangle(lgbBarSelected, barSegRect);
                                }
                            }
                            //if (i != this.BarIndex)
                            //{
                            //    barSegRect = new RectangleF(barSegRect.X, barSegRect.Y + (3 * barOffsetY) + (barSegRect.Height), barSegRect.Width, barSegRect.Height);
                            //    barSegRect = new RectangleF(barSegRect.X, barSegRect.Y + 2 * barSegRect.Height, barSegRect.Width, barSegRect.Height);
                            //    barSegRect = new RectangleF(barSegRect.X, barSegRect.Y, barSegRect.Width, 3 * barSegRect.Height);
                            //    using (LinearGradientBrush lgbBarAlert = new LinearGradientBrush(barSegRect,
                            //    barMediaOuterColor, barMediaInnerColor, LinearGradientMode.Horizontal))
                            //    {
                            //        lgbBarAlert.WrapMode = WrapMode.TileFlipXY;
                            //        e.Graphics.FillRectangle(lgbBarAlert, barSegRect);
                            //    }
                            //}
                            //else
                            //{
                            //    barSegRect = new RectangleF(barSegRect.X, barSegRect.Y + (3 * barOffsetY) + (barSegRect.Height), barSegRect.Width, barSegRect.Height);
                            //    barSegRect = new RectangleF(barSegRect.X, barSegRect.Y + 2 * barSegRect.Height, barSegRect.Width, barSegRect.Height);
                            //    barSegRect = new RectangleF(barSegRect.X, barSegRect.Y, barSegRect.Width, 3 * barSegRect.Height);
                            //    using (LinearGradientBrush lgbBarAlert = new LinearGradientBrush(barSegRect,
                            //    barSelectedOuterColor, barSelectedInnerColor, LinearGradientMode.Horizontal))
                            //    {
                            //        lgbBarAlert.WrapMode = WrapMode.TileFlipXY;
                            //        e.Graphics.FillRectangle(lgbBarAlert, barSegRect);
                            //    }
                            //}

                            //////////////////////////////////////////////////////////////////////////////////////////////
                            //if ((selectEnd > selectStart) && (selectStart > 0) && (selectEnd > 0))
                            //{
                            //    RectangleF rect1 = new RectangleF(selectStart, newY, selectEnd - selectStart, zBarHeight / 3);
                            //    rect1 = Transform(m_data_rect, m_screen_rect, rect1);
                            //    rect1 = new RectangleF(rect1.X, newY, rect1.Width, zBarHeight / 3);
                            //    if (RecTypeSchedule && bars[i][j].recordingType == 0)
                            //    {
                            //        using (LinearGradientBrush lgbBarSchedule = new LinearGradientBrush(rect1,
                            //            Color.White, Color.White, LinearGradientMode.Horizontal))
                            //        {
                            //            lgbBarSchedule.WrapMode = WrapMode.TileFlipXY;
                            //            e.Graphics.FillRectangle(lgbBarSchedule, rect1);
                            //        }
                            //    }
                            //}
                            //////////////////////////////////////////////////////////////////////////////////////////////

                        }
                    #endregion "INNER BARS"

                    using (Pen barPen = new Pen(barPenColor, 0.5f))
                    {
                        //newY
                        //e.Graphics.DrawRectangle(barPen, ztoF.X, (float)i * zBarHeight, ztoR.Width, zBarHeight);
                        e.Graphics.DrawRectangle(barPen, ztoF.X, newY, ztoR.Width, zBarHeight);
                    }

                }
                #endregion "DRAW BARS"

                #region "DRAW THUMB"

                //float x_offset = m_screen_rect.Left + m_margin_left;
                //m_data_rect.X = x_offset - m_data_rect.X;

                PointF zbarSegRect2 = Transform(m_data_rect, m_screen_rect, new PointF((float)(trackerValue), (float)0));
                barSegRect = new RectangleF(zbarSegRect2, new SizeF((float)2, (float)this.Height));

                using (LinearGradientBrush lgbBarSchedule = new LinearGradientBrush(barSegRect,
                    thumbOuterColor, thumbInnerColor, LinearGradientMode.Horizontal))
                {
                    lgbBarSchedule.WrapMode = WrapMode.TileFlipXY;
                    e.Graphics.FillRectangle(lgbBarSchedule, barSegRect);
                }

                #endregion "DRAW THUMB"


            }
            else
            {
                base.OnPaint(e);

                //    // Fill in Background (for effieciency only the area that has been clipped)
                //    memGraphics.g.FillRectangle(new SolidBrush(SystemColors.Window), e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width, e.ClipRectangle.Height);

                //    // Draw the object
                //    drawObj.Draw(memGraphics.g);

                //    // Render to the form
                //    memGraphics.Render(e.Graphics);

            }
            // Release resources
            //e.Graphics.Dispose();


        }

        public void MoveLeftRight()
        {
            if (this.DataRect.Left <= barMinimum)
                return;

            if (this.DataRect.Left + this.DataRect.Width >= barMaximum)
                return;

            SizeF size = new SizeF(Width / 24, Height / 24);
            this.DataRect = Offset(this.DataRect, -(Transform(this.ScreenRect, this.DataRect, size)).Width, 0);
            Invalidate();
        }

        private SizeF GetMoveStep2()
        {
            SizeF size = new SizeF(Width / 24, Height / 24);
            return Transform(this.ScreenRect, this.DataRect, size);
        }

        public void MoveSliderH(float newValue)
        {
            m_data_rect = new RectangleF(newValue, m_data_rect.Top, m_data_rect.Width, m_data_rect.Height);
            this.Invalidate();
        }


        public void LoadBarsFromDataSet(object[] data)
        {
            if (data == null)
            {
                bars = new Bars[] { };
                return;
            }
            bars = new Bars[] { };
            DateTime now = DateTime.Now;

            DataSet ds = new DataSet();
            object[] state = (object[])data;
            ds = (DataSet)state[0];
            _barCount = ds.Tables[0].Rows.Count;

            bars = new Bars[_barCount];

            int i = -1;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                i++;
                try
                {
                    bars[i] = new Bars();
                    bars[i].goodData = true;
                    //bars[i].FileID = Convert.ToInt32(row["FileID"].ToString());
                    bars[i].FileName = row["FileName"].ToString();
                    bars[i].FilePath = row["FilePath"].ToString();
                    double dd = (double)Convert.ToDouble(row["Duration"].ToString());
                    bars[i].Duration = dd;
                    bars[i].FileLength = (float)dd;
                    bars[i].FPS = (double)Convert.ToDouble(row["FPS"].ToString());
                    bars[i].startSeconds = (float)0.00f;
                    bars[i].endSeconds = (float)bars[i].startSeconds + (float)bars[i].FileLength;
                    float duration = (float)bars[i].endSeconds - (float)bars[i].startSeconds;
                    bars[i].startRatio = bars[i].startSeconds / (float)86400.000000;
                    bars[i].endRatio = bars[i].endSeconds / (float)86400.000000;
                }
                catch (Exception e2)
                {
                    //bars[i].goodData = false;
                }
            }

            // Bill SerGio: Dispose of DataSet
            ds.Dispose();

            Invalidate();
            m_default_rect = m_data_rect;
            CalcMinMax();

            // Don't allow user to scroll beyond display bounds
            //BTN_MoveLeft.Enabled = !this.AtMinX();
            //BTN_MoveRight.Enabled = !this.AtMaxX();
            //BTN_MoveUp.Enabled = !this.AtMinY();
            //BTN_MoveDown.Enabled = !this.AtMaxY();

        }

        public void LoadBarsFromDataSet(Bars[] b)
        {
            _barCount = b.Length;
            //  bars = new Bars[_barCount];

            bars = b;

            Invalidate();
            m_default_rect = m_data_rect;
            CalcMinMax();
        }
        public void LoadBarsFromDataSet()
        {

            int i = -1;

            _barCount = 4;
            bars = new Bars[_barCount];

            try
            {
                {

                    i++;
                    bars[i] = new Bars();
                    bars[i].goodData = true;
                    //bars[i].FileID = Convert.ToInt32(row["FileID"].ToString());
                    bars[i].FileName = "[Tama-sub]Katanagatari Promo.avi";
                    bars[i].FilePath = "";
                    double dd = 184.9920088;
                    bars[i].Duration = dd;
                    bars[i].FileLength = (float)dd;
                    bars[i].FPS = 0;
                    bars[i].startSeconds = 0;
                    bars[i].endSeconds = (float)bars[i].startSeconds + (float)bars[i].FileLength;
                    float duration = (float)bars[i].endSeconds - (float)bars[i].startSeconds;
                    bars[i].startRatio = bars[i].startSeconds / (float)86400.000000;
                    bars[i].endRatio = bars[i].endSeconds / (float)86400.000000;
                }



                {

                    i++;
                    bars[i] = new Bars();
                    bars[i].goodData = true;
                    //bars[i].FileID = Convert.ToInt32(row["FileID"].ToString());
                    bars[i].FileName = "[Tama-sub]Katanagatari Promo.avi";
                    bars[i].FilePath = "";
                    double dd = 184.9920088;
                    bars[i].Duration = dd;
                    bars[i].FileLength = (float)dd;
                    bars[i].FPS = 12;
                    bars[i].startSeconds = 100;
                    bars[i].endSeconds = (float)bars[i].startSeconds + (float)bars[i].FileLength;
                    float duration = (float)bars[i].endSeconds - (float)bars[i].startSeconds;
                    bars[i].startRatio = bars[i].startSeconds / (float)86400.000000;
                    bars[i].endRatio = bars[i].endSeconds / (float)86400.000000;


                }

                {

                    i++;
                    bars[i] = new Bars();
                    bars[i].goodData = true;
                    //bars[i].FileID = Convert.ToInt32(row["FileID"].ToString());
                    bars[i].FileName = "[Tama-sub]Katanagatari Promo.avi";
                    bars[i].FilePath = "";
                    double dd = 184.9920088;
                    bars[i].Duration = dd;
                    bars[i].FileLength = (float)dd;
                    bars[i].FPS = 12;
                    bars[i].startSeconds = 100;
                    bars[i].endSeconds = (float)bars[i].startSeconds + (float)bars[i].FileLength;
                    float duration = (float)bars[i].endSeconds - (float)bars[i].startSeconds;
                    bars[i].startRatio = bars[i].startSeconds / (float)86400.000000;
                    bars[i].endRatio = bars[i].endSeconds / (float)86400.000000;


                }
                {

                    i++;
                    bars[i] = new Bars();
                    bars[i].goodData = true;
                    //bars[i].FileID = Convert.ToInt32(row["FileID"].ToString());
                    bars[i].FileName = "[Tama-sub]Katanagatari Promo.avi";
                    bars[i].FilePath = "";
                    double dd = 184.9920088;
                    bars[i].Duration = dd;
                    bars[i].FileLength = (float)dd;
                    bars[i].FPS = 12;
                    bars[i].startSeconds = 100;
                    bars[i].endSeconds = (float)bars[i].startSeconds + (float)bars[i].FileLength;
                    float duration = (float)bars[i].endSeconds - (float)bars[i].startSeconds;
                    bars[i].startRatio = bars[i].startSeconds / (float)86400.000000;
                    bars[i].endRatio = bars[i].endSeconds / (float)86400.000000;


                }
            }
            catch (Exception e2)
            {
                //bars[i].goodData = false;
            }



            Invalidate();
            m_default_rect = m_data_rect;
            CalcMinMax();
        }
    }//END OF CLASS



    public class FireThumbEventArgs : EventArgs
    {
        public FireThumbEventArgs(string videoFilename,
                             float startSeconds,
                             float endSeconds,
                             float fileLength,
                             bool inProgress,
                             bool goodData)
        {
            this.videoFilename = videoFilename;
            this.startSeconds = startSeconds;
            this.endSeconds = endSeconds;
            this.fileLength = fileLength;
            this.inProgress = inProgress;
            this.goodData = goodData;
        }

        public string videoFilename;
        public float startSeconds;
        public float endSeconds;
        public float fileLength;
        public bool inProgress;
        public bool goodData;

    }    //end of class FireEventArgs


}

