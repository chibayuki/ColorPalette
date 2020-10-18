/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
Copyright © 2019 chibayuki@foxmail.com

调色板 (ColorPalette)
Version 1.0.2000.0.R1.190525-0000

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

using System.Text.RegularExpressions;

namespace WinFormApp
{
    public partial class NumEditor : UserControl
    {
        #region 私有成员与内部成员

        private double _Minimum = 0;
        private double _Maximum = 100;
        private int _Precision = 0;
        private double _Value = 0;

        private Color _ForeColor;
        private Color _BackColor;
        private Color _BorderColor = Color.Black;

        private Font _Font;

        //

        private string _LastValidText = string.Empty;

        //

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

        //

        private bool _Validate(out double value)
        {
            value = 0;

            Regex regex;

            if (_Precision > 0)
            {
                if (_Minimum >= 0)
                {
                    regex = new Regex(@"^(0?|0\.\d*|[1-9]\d*|[1-9]\d*\.\d*)$"); // 正小数
                }
                else
                {
                    if (_Maximum > 0)
                    {
                        regex = new Regex(@"^(-?(0?|0\.\d*|[1-9]\d*|[1-9]\d*\.\d*))$"); // 小数
                    }
                    else
                    {
                        regex = new Regex(@"^(-?|0?|-(0?|0\.\d*|[1-9]\d*|[1-9]\d*\.\d*))$"); // 负小数
                    }
                }
            }
            else
            {
                if (_Minimum >= 0)
                {
                    regex = new Regex(@"^(0?|[1-9]\d*)$"); // 正整数
                }
                else
                {
                    if (_Maximum > 0)
                    {
                        regex = new Regex(@"^(-?(0?|[1-9]\d*))$"); // 整数
                    }
                    else
                    {
                        regex = new Regex(@"^(-?|0?|-(0?|[1-9]\d*))$"); // 负整数
                    }
                }
            }

            string text = TextBox_Num.Text;

            bool flag = regex.IsMatch(text);

            if (flag && _Precision > 0)
            {
                int dotId = text.IndexOf('.');

                if (dotId > 0)
                {
                    flag = (text.Length - 1 - dotId <= _Precision);
                }
            }

            if (flag)
            {
                value = _GetValue();

                flag = (value >= _Minimum && value <= _Maximum);
            }

            return flag;
        }

        private double _GetValue()
        {
            string text = TextBox_Num.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                return 0;
            }
            else
            {
                if (double.TryParse(text, out double val))
                {
                    return val;
                }
                else
                {
                    return 0;
                }
            }
        }

        //

        private EventHandlerList _Events = new EventHandlerList(); // 事件委托列表。

        private static class EventKey // 事件键值。
        {
            public static readonly object TextChanged = new object(); // TextChanged 事件键值。

            public static readonly object ValueChanged = new object(); // ValueChanged 事件键值。
        }

        private void _TrigEvent(object eventKey) // 引发事件。
        {
            EventHandler Method = _Events[eventKey] as EventHandler;

            if (Method != null)
            {
                Method(this, EventArgs.Empty);
            }
        }

        private void _OnTextChanged() // 引发 TextChanged 事件。
        {
            _TrigEvent(EventKey.TextChanged);
        }

        private void _OnValueChanged() // 引发 ValueChanged 事件。
        {
            _TrigEvent(EventKey.ValueChanged);
        }

        #endregion

        #region 回调函数

        private void NumEditor_Load(object sender, EventArgs e)
        {
            NumEditor_SizeChanged(sender, e);
        }

        private void NumEditor_SizeChanged(object sender, EventArgs e)
        {
            this.SizeChanged -= NumEditor_SizeChanged;

            TextBox_Num.Width = Math.Max(1, this.Width - 2 * TextBox_Num.Left);
            TextBox_Num.Top = (this.Height - TextBox_Num.Height) / 2;

            this.SizeChanged += NumEditor_SizeChanged;
        }

        //

        private void Panel_Main_Paint(object sender, PaintEventArgs e)
        {
            using (Pen Pn = new Pen(Color.FromArgb(64, _BorderColor), 2))
            {
                e.Graphics.DrawRectangles(Pn, new RectangleF[] { new RectangleF(new PointF(TextBox_Num.Left - 2, TextBox_Num.Top - 2), new SizeF(TextBox_Num.Width + 4, TextBox_Num.Height + 4)) });
            }

            using (Pen Pn = new Pen(Color.FromArgb(128, _BorderColor), 2))
            {
                e.Graphics.DrawRectangles(Pn, new RectangleF[] { new RectangleF(new PointF(TextBox_Num.Left - 1, TextBox_Num.Top - 1), new SizeF(TextBox_Num.Width + 2, TextBox_Num.Height + 2)) });
            }

            using (Pen Pn = new Pen(TextBox_Num.BackColor, 1))
            {
                e.Graphics.DrawRectangle(Pn, new Rectangle(new Point(TextBox_Num.Left - 1, TextBox_Num.Top - 1), new Size(TextBox_Num.Width + 1, TextBox_Num.Height + 1)));
            }
        }

        //

        private void TextBox_Num_TextChanged(object sender, EventArgs e)
        {
            TextBox_Num.TextChanged -= TextBox_Num_TextChanged;

            if (_Validate(out double val))
            {
                if (_LastValidText != TextBox_Num.Text)
                {
                    _LastValidText = TextBox_Num.Text;

                    _OnTextChanged();
                }

                if (_Value != val)
                {
                    _Value = val;

                    _OnValueChanged();
                }
            }
            else
            {
                TextBox_Num.Text = _LastValidText;
            }

            TextBox_Num.SelectionStart = TextBox_Num.TextLength;
            TextBox_Num.SelectionLength = 0;

            TextBox_Num.TextChanged += TextBox_Num_TextChanged;
        }

        private void TextBox_Num_SizeChanged(object sender, EventArgs e)
        {
            TextBox_Num.Top = (this.Height - TextBox_Num.Height) / 2;
        }

        #endregion

        #region 构造函数

        public NumEditor()
        {
            InitializeComponent();

            //

            _ForeColor = TextBox_Num.ForeColor;
            _BackColor = TextBox_Num.BackColor;

            _Font = TextBox_Num.Font;
        }

        #endregion

        #region 属性

        public new string Text
        {
            get
            {
                return TextBox_Num.Text;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                //

                TextBox_Num.Text = value;
            }
        }

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
                    Value = _Minimum;
                }
                else if (_Value > _Maximum)
                {
                    Value = _Maximum;
                }
            }
        }

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
                    Value = _Minimum;
                }
                else if (_Value > _Maximum)
                {
                    Value = _Maximum;
                }
            }
        }

        public int Precision
        {
            get
            {
                return _Precision;
            }

            set
            {
                if (Precision < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                //

                _Precision = value;

                string text = TextBox_Num.Text;

                int dotId = text.IndexOf('.');

                if (dotId > 0)
                {
                    if (_Precision > 0)
                    {
                        TextBox_Num.Text = text.Substring(0, Math.Min(dotId + 1 + _Precision, text.Length));
                    }
                    else
                    {
                        TextBox_Num.Text = text.Substring(0, dotId);
                    }
                }
            }
        }

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

                string text = value.ToString();

                int dotId = text.IndexOf('.');

                if (dotId > 0)
                {
                    if (_Precision > 0)
                    {
                        TextBox_Num.Text = text.Substring(0, Math.Min(dotId + 1 + _Precision, text.Length));
                    }
                    else
                    {
                        TextBox_Num.Text = text.Substring(0, dotId);
                    }
                }
                else
                {
                    TextBox_Num.Text = text;
                }
            }
        }

        public new Color ForeColor
        {
            get
            {
                return _ForeColor;
            }

            set
            {
                _ForeColor = value;

                TextBox_Num.ForeColor = _ForeColor;
            }
        }

        public new Color BackColor
        {
            get
            {
                return _BackColor;
            }

            set
            {
                _BackColor = value;

                Color meaningfulBackColor = _BackColor;

                if (meaningfulBackColor.A == 0)
                {
                    meaningfulBackColor = _MeaningfulBackColor;
                }

                TextBox_Num.BackColor = Color.FromArgb(meaningfulBackColor.R, meaningfulBackColor.G, meaningfulBackColor.B);
            }
        }

        public Color BorderColor
        {
            get
            {
                return _BorderColor;
            }

            set
            {
                _BorderColor = value;

                Panel_Main.Refresh();
            }
        }

        public new Font Font
        {
            get
            {
                return _Font;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                //

                _Font = value;

                TextBox_Num.Font = _Font;
            }
        }

        #endregion

        #region 事件

        // 在此 NumEditor 的文本发生改变时发生。
        public new event EventHandler TextChanged
        {
            add
            {
                if (value != null)
                {
                    _Events.AddHandler(EventKey.TextChanged, value);
                }
            }

            remove
            {
                if (value != null)
                {
                    _Events.RemoveHandler(EventKey.TextChanged, value);
                }
            }
        }

        // 在此 NumEditor 的值发生改变时发生。
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

        #endregion
    }
}
