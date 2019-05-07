/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
Copyright © 2019 chibayuki@foxmail.com

调色板 (ColorPalette)
Version 1.0.1905.0.R1.190425-0000

This file is part of "调色板" (ColorPalette)

"调色板" (ColorPalette) is released under the GPLv3 license
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace WinFormApp
{
    public partial class HTrackBar : UserControl
    {
        #region 私有成员与内部成员

        private Color[] _Colors = new Color[0];

        private double _Minimum = 0;
        private double _Maximum = 100;
        private double _Delta = 5;
        private double _Value = 0;

        //

        private Bitmap _TrackBarImage = null;

        private bool _MousePressed = false;

        private RectangleF _WholeBounds => new RectangleF(new PointF(0, 0), Panel_Main.Size);
        private RectangleF _TrackBarBounds
        {
            get
            {
                RectangleF wholeBounds = _WholeBounds; return new RectangleF(new PointF(0.25F * wholeBounds.Height, 0.15F * wholeBounds.Height), new SizeF(Math.Max(0, Panel_Main.Width - 0.5F * wholeBounds.Height - 1), Math.Max(0, 0.7F * wholeBounds.Height - 1)));
            }
        }

        private Color _MeaningfulBackColor
        {
            get
            {
                Control Ctrl = this;

                while (Ctrl.BackColor.A == 0 && Ctrl.Parent != null)
                {
                    Ctrl = Ctrl.Parent;
                }

                return Ctrl.BackColor;
            }
        }

        private void _UpdateTrackBarImage()
        {
            if (_TrackBarImage != null)
            {
                _TrackBarImage.Dispose();
            }

            RectangleF wholeBounds = _WholeBounds;
            RectangleF trackBarBounds = _TrackBarBounds;

            _TrackBarImage = new Bitmap(Math.Max(1, (int)wholeBounds.Width), Math.Max(1, (int)wholeBounds.Height));

            using (Graphics Grap = Graphics.FromImage(_TrackBarImage))
            {
                Color meaningfulBackColor = _MeaningfulBackColor;

                //

                Grap.SmoothingMode = SmoothingMode.AntiAlias;

                Grap.Clear(meaningfulBackColor);

                //

                int ColorNum = (_Colors == null ? 0 : _Colors.Length);

                //

                RectangleF BarImgBounds = new RectangleF(trackBarBounds.Location, new SizeF(Math.Max(1, trackBarBounds.Width), Math.Max(1, trackBarBounds.Height)));

                //

                Color BarBorderColor = Com.ColorManipulation.ShiftLightnessByHSL(meaningfulBackColor, -0.5);

                using (Pen Pn = new Pen(Color.FromArgb(64, BarBorderColor), 2))
                {
                    Grap.DrawRectangles(Pn, new RectangleF[] { new RectangleF(new PointF(BarImgBounds.X - 1, BarImgBounds.Y - 1), new SizeF(BarImgBounds.Width + 2, BarImgBounds.Height + 2)) });
                }

                using (Pen Pn = new Pen(Color.FromArgb(128, BarBorderColor), 2))
                {
                    Grap.DrawRectangles(Pn, new RectangleF[] { BarImgBounds });
                }

                //

                if (ColorNum > 0)
                {
                    if (ColorNum == 1)
                    {
                        using (SolidBrush Br = new SolidBrush(_Colors[0]))
                        {
                            Grap.FillRectangle(Br, BarImgBounds);
                        }
                    }
                    else
                    {
                        SizeF SubImgSize = new SizeF(BarImgBounds.Width / (ColorNum - 1) + 0.5F, BarImgBounds.Height);

                        for (int i = 1; i < ColorNum; i++)
                        {
                            RectangleF SubImgBounds = new RectangleF(new PointF(BarImgBounds.X + BarImgBounds.Width * (i - 1) / (ColorNum - 1), BarImgBounds.Y), SubImgSize);

                            using (LinearGradientBrush Br = new LinearGradientBrush(new PointF(SubImgBounds.Left - 0.5F, SubImgBounds.Top), new PointF(SubImgBounds.Right + 0.5F, SubImgBounds.Top), _Colors[i - 1], _Colors[i]))
                            {
                                Grap.FillRectangle(Br, SubImgBounds);
                            }
                        }
                    }
                }

                //

                if (Com.Geometry.CursorIsInControl(Panel_Main) || _MousePressed)
                {
                    using (SolidBrush Br = new SolidBrush(Color.FromArgb(64, Color.White)))
                    {
                        Grap.FillRectangle(Br, BarImgBounds);
                    }
                }

                //

                Color SliderBorderColor = BarBorderColor;

                Color SliderColor;

                if (ColorNum > 0)
                {
                    if (ColorNum == 1)
                    {
                        SliderColor = _Colors[0];
                    }
                    else
                    {
                        double Pct = (_Value - _Minimum) / (_Maximum - _Minimum);

                        int ColorIndex = (int)Math.Ceiling(Pct * (ColorNum - 1));

                        if (ColorIndex == 0)
                        {
                            ColorIndex = 1;
                        }

                        double SubPct = (double)(ColorIndex - 1) / (ColorNum - 1);

                        double Prop = (Pct - SubPct) * (ColorNum - 1);

                        SliderColor = Com.ColorManipulation.BlendByRGB(_Colors[ColorIndex], _Colors[ColorIndex - 1], Prop);
                    }
                }
                else
                {
                    SliderColor = meaningfulBackColor;
                }

                SliderColor = Com.ColorManipulation.ShiftLightnessByHSL(SliderColor, +0.5);

                float SliderX = (_Minimum == _Maximum ? trackBarBounds.X : (float)(trackBarBounds.X + (_Value - _Minimum) / (_Maximum - _Minimum) * trackBarBounds.Width));
                float SliderHeight = 0.2F * wholeBounds.Height;

                PointF[] PolygonTop = new PointF[] {
                    new PointF(SliderX, wholeBounds.Y + 1 + SliderHeight),
                    new PointF(SliderX - SliderHeight, wholeBounds.Y + 1),
                    new PointF(SliderX + SliderHeight, wholeBounds.Y + 1)
                };
                PointF[] PolygonBottom = new PointF[] {
                    new PointF(SliderX, wholeBounds.Bottom - 1 - SliderHeight),
                    new PointF(SliderX - SliderHeight, wholeBounds.Bottom - 1),
                    new PointF(SliderX + SliderHeight, wholeBounds.Bottom - 1)
                };

                using (Pen Pn = new Pen(Color.FromArgb(128, SliderBorderColor), 3))
                {
                    Grap.DrawLine(Pn, new PointF(SliderX, trackBarBounds.Y), new PointF(SliderX, trackBarBounds.Bottom));
                }

                using (Pen Pn = new Pen(Color.FromArgb(128, SliderBorderColor), 2))
                {
                    Grap.DrawPolygon(Pn, PolygonTop);
                    Grap.DrawPolygon(Pn, PolygonBottom);
                }

                using (Pen Pn = new Pen(SliderColor, 1))
                {
                    Grap.DrawLine(Pn, new PointF(SliderX, trackBarBounds.Y), new PointF(SliderX, trackBarBounds.Bottom));
                }

                using (SolidBrush Br = new SolidBrush(SliderColor))
                {
                    Grap.FillPolygon(Br, PolygonTop);
                    Grap.FillPolygon(Br, PolygonBottom);
                }
            }
        }

        private void _RepaintTrackBarImage()
        {
            _UpdateTrackBarImage();

            if (_TrackBarImage != null)
            {
                Panel_Main.CreateGraphics().DrawImage(_TrackBarImage, new Point(0, 0));
            }
        }

        //

        private EventHandlerList _Events = new EventHandlerList(); // 事件委托列表。

        private static class EventKey // 事件键值。
        {
            public static readonly object ValueChanged = new object(); // ValueChanged 事件键值。

            public static readonly object Scroll = new object(); // Scroll 事件键值。

            public static readonly object Click = new object(); // Click 事件键值。
        }

        private void _TrigEvent(object eventKey) // 引发事件。
        {
            EventHandler Method = _Events[eventKey] as EventHandler;

            if (Method != null)
            {
                Method(this, EventArgs.Empty);
            }
        }

        private void _OnValueChanged() // 引发 ValueChanged 事件。
        {
            _TrigEvent(EventKey.ValueChanged);
        }

        private void _OnScroll() // 引发 Scroll 事件。
        {
            _TrigEvent(EventKey.Scroll);
        }

        private void _OnClick() // 引发 Click 事件。
        {
            _TrigEvent(EventKey.Click);
        }

        #endregion

        #region 回调函数

        private void HTrackBar_Load(object sender, EventArgs e)
        {
            _RepaintTrackBarImage();
        }

        private void HTrackBar_SizeChanged(object sender, EventArgs e)
        {
            _RepaintTrackBarImage();
        }

        //

        private void Panel_Main_Paint(object sender, PaintEventArgs e)
        {
            if (_TrackBarImage == null)
            {
                _UpdateTrackBarImage();
            }

            if (_TrackBarImage != null)
            {
                e.Graphics.DrawImage(_TrackBarImage, new Point(0, 0));
            }
        }

        private void Panel_Main_MouseEnter(object sender, EventArgs e)
        {
            _RepaintTrackBarImage();
        }

        private void Panel_Main_MouseLeave(object sender, EventArgs e)
        {
            _RepaintTrackBarImage();
        }

        private void Panel_Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _MousePressed = true;

                Panel_Main_MouseMove(sender, e);
            }
        }

        private void Panel_Main_MouseUp(object sender, MouseEventArgs e)
        {
            if (_MousePressed)
            {
                _MousePressed = false;

                if (e.Button == MouseButtons.Left)
                {
                    _OnClick();
                }
            }
        }

        private void Panel_Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (_MousePressed)
            {
                RectangleF trackBarBounds = _TrackBarBounds;

                if (trackBarBounds.Width <= 0 || _Minimum == _Maximum)
                {
                    _Value = _Minimum;
                }
                else
                {
                    _Value = Math.Max(_Minimum, Math.Min(_Minimum + (Com.Geometry.GetCursorPositionOfControl(Panel_Main).X - trackBarBounds.X) / trackBarBounds.Width * (_Maximum - _Minimum), _Maximum));
                }

                _RepaintTrackBarImage();

                _OnValueChanged();
            }
        }

        private void Panel_Main_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_Minimum == _Maximum)
            {
                _Value = _Minimum;
            }
            else
            {
                if (e.Delta > 0)
                {
                    if ((_Value - _Minimum) % _Delta == 0)
                    {
                        _Value = Math.Min(_Maximum, _Value + _Delta);
                    }
                    else
                    {
                        _Value = Math.Min(_Maximum, _Value - (_Value - _Minimum) % _Delta + _Delta);
                    }
                }
                else if (e.Delta < 0)
                {
                    if ((_Value - _Minimum) % _Delta == 0)
                    {
                        _Value = Math.Max(_Minimum, _Value - _Delta);
                    }
                    else
                    {
                        _Value = Math.Max(_Minimum, _Value - (_Value - _Minimum) % _Delta);
                    }
                }
            }

            _RepaintTrackBarImage();

            _OnValueChanged();
            _OnScroll();
        }

        #endregion

        #region 构造函数

        public HTrackBar()
        {
            InitializeComponent();
        }

        #endregion

        #region 属性

        // 获取或设置此 TrackBar 的颜色。
        public Color[] Colors
        {
            get
            {
                return _Colors;
            }

            set
            {
                if (value != null && value.Length > 0)
                {
                    _Colors = new Color[value.Length];

                    Array.Copy(value, _Colors, value.Length);
                }
                else
                {
                    _Colors = new Color[0];
                }

                _UpdateTrackBarImage();
                _RepaintTrackBarImage();
            }
        }

        // 获取或设置此 TrackBar 的最小值。
        public double Minimum
        {
            get
            {
                return _Minimum;
            }

            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                {
                    throw new ArgumentException();
                }

                //

                _Minimum = value;

                if (_Maximum < _Minimum)
                {
                    _Maximum = _Minimum;
                }

                if (_Value < _Minimum)
                {
                    _Value = _Minimum;

                    _RepaintTrackBarImage();

                    _OnValueChanged();
                }
                else if (_Value > _Maximum)
                {
                    _Value = _Maximum;

                    _RepaintTrackBarImage();

                    _OnValueChanged();
                }
            }
        }

        // 获取或设置此 TrackBar 的最大值。
        public double Maximum
        {
            get
            {
                return _Maximum;
            }

            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                {
                    throw new ArgumentException();
                }

                //

                _Maximum = value;

                if (_Minimum > _Maximum)
                {
                    _Minimum = _Maximum;
                }

                if (_Value < _Minimum)
                {
                    _Value = _Minimum;

                    _RepaintTrackBarImage();

                    _OnValueChanged();
                }
                else if (_Value > _Maximum)
                {
                    _Value = _Maximum;

                    _RepaintTrackBarImage();

                    _OnValueChanged();
                }
            }
        }

        // 获取或设置通过鼠标滚轮或键盘方向键修改此 TrackBar 的值的步长。
        public double Delta
        {
            get
            {
                return _Delta;
            }

            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                {
                    throw new ArgumentException();
                }

                if (value < _Minimum || value > _Maximum)
                {
                    throw new ArgumentOutOfRangeException();
                }

                //

                _Delta = value;
            }
        }

        // 获取或设置此 TrackBar 的值。
        public double Value
        {
            get
            {
                return _Value;
            }

            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                {
                    throw new ArgumentException();
                }

                if (value < _Minimum || value > _Maximum)
                {
                    throw new ArgumentOutOfRangeException();
                }

                //

                _Value = value;

                _RepaintTrackBarImage();

                _OnValueChanged();
            }
        }

        #endregion

        #region 事件

        // 在此 TrackBar 的值发生改变时发生。
        public event EventHandler ValueChanged
        {
            add
            {
                if (value != null)
                {
                    _Events.AddHandler(EventKey.ValueChanged, value);
                }
            }

            remove
            {
                if (value != null)
                {
                    _Events.RemoveHandler(EventKey.ValueChanged, value);
                }
            }
        }

        // 在通过鼠标滚轮或键盘方向键修改此 TrackBar 的值时发生。
        public new event EventHandler Scroll
        {
            add
            {
                if (value != null)
                {
                    _Events.AddHandler(EventKey.Scroll, value);
                }
            }

            remove
            {
                if (value != null)
                {
                    _Events.RemoveHandler(EventKey.Scroll, value);
                }
            }
        }

        // 在鼠标单击此 TrackBar 时发生。
        public new event EventHandler Click
        {
            add
            {
                if (value != null)
                {
                    _Events.AddHandler(EventKey.Click, value);
                }
            }

            remove
            {
                if (value != null)
                {
                    _Events.RemoveHandler(EventKey.Click, value);
                }
            }
        }

        #endregion
    }
}