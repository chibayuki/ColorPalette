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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;

namespace WinFormApp
{
    public partial class Form_Main : Form
    {
        #region 私有成员与内部成员

        private Com.ColorX _BackColor;

        private enum _ColorTags
        {
            BackColor
        }

        private _ColorTags _ColorTag = _ColorTags.BackColor;

        //

        private Hashtable _ColorsTable = new Hashtable();

        private const int _ColorsNum = 11;

        private static class _ColorsKey
        {
            public static readonly object Opacity = new object();
            public static readonly object Alpha = new object();

            public static readonly object RGB_R = new object();
            public static readonly object RGB_G = new object();
            public static readonly object RGB_B = new object();

            public static readonly object HSV_H = new object();
            public static readonly object HSV_S = new object();
            public static readonly object HSV_V = new object();

            public static readonly object HSL_H = new object();
            public static readonly object HSL_S = new object();
            public static readonly object HSL_L = new object();

            public static readonly object CMYK_C = new object();
            public static readonly object CMYK_M = new object();
            public static readonly object CMYK_Y = new object();
            public static readonly object CMYK_K = new object();

            public static readonly object LAB_L = new object();
            public static readonly object LAB_A = new object();
            public static readonly object LAB_B = new object();

            public static readonly object YUV_Y = new object();
            public static readonly object YUV_U = new object();
            public static readonly object YUV_V = new object();
        }

        #endregion

        #region 窗体构造

        private Com.WinForm.FormManager Me;

        public Com.WinForm.FormManager FormManager
        {
            get
            {
                return Me;
            }
        }

        private void _Ctor(Com.WinForm.FormManager owner)
        {
            InitializeComponent();

            //

            if (owner != null)
            {
                Me = new Com.WinForm.FormManager(this, owner);
            }
            else
            {
                Me = new Com.WinForm.FormManager(this);
            }

            //

            FormDefine();
        }

        public Form_Main()
        {
            _Ctor(null);
        }

        public Form_Main(Com.WinForm.FormManager owner)
        {
            _Ctor(owner);
        }

        private void FormDefine()
        {
            Me.Caption = Application.ProductName;
            Me.FormStyle = Com.WinForm.FormStyle.Sizable;
            Me.EnableFullScreen = false;
            Me.Theme = Com.WinForm.Theme.Black;
            Me.ThemeColor = Com.ColorManipulation.GetRandomColorX();
            Me.MinimumSize = new Size(820, 405 + Me.CaptionBarHeight);

            Me.Loaded += LoadedEvents;
            Me.Resize += ResizeEvents;
            Me.SizeChanged += SizeChangedEvents;
            Me.ThemeChanged += ThemeColorChangedEvents;
            Me.ThemeColorChanged += ThemeColorChangedEvents;
        }

        #endregion

        #region 窗体事件

        // 在窗体加载后发生。
        private void LoadedEvents(object sender, EventArgs e)
        {
            Me.OnSizeChanged();
            Me.OnThemeChanged();

            //

            _ColorsTable.Add(_ColorsKey.Opacity, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.Alpha, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.RGB_R, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.RGB_G, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.RGB_B, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.HSV_H, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.HSV_S, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.HSV_V, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.HSL_H, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.HSL_S, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.HSL_L, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.CMYK_C, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.CMYK_M, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.CMYK_Y, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.CMYK_K, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.LAB_L, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.LAB_A, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.LAB_B, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.YUV_Y, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.YUV_U, new Color[_ColorsNum]);
            _ColorsTable.Add(_ColorsKey.YUV_V, new Color[_ColorsNum]);

            //

            HTrackBar_Opacity.Minimum = 0;
            HTrackBar_Opacity.Maximum = 100;
            HTrackBar_Opacity.Delta = 2;
            HTrackBar_Alpha.Minimum = 0;
            HTrackBar_Alpha.Maximum = 255;
            HTrackBar_Alpha.Delta = 4;

            HTrackBar_RGB_R.Minimum = 0;
            HTrackBar_RGB_R.Maximum = 255;
            HTrackBar_RGB_R.Delta = 4;
            HTrackBar_RGB_G.Minimum = 0;
            HTrackBar_RGB_G.Maximum = 255;
            HTrackBar_RGB_G.Delta = 4;
            HTrackBar_RGB_B.Minimum = 0;
            HTrackBar_RGB_B.Maximum = 255;
            HTrackBar_RGB_B.Delta = 4;

            HTrackBar_HSV_H.Minimum = 0;
            HTrackBar_HSV_H.Maximum = 360;
            HTrackBar_HSV_H.Delta = 5;
            HTrackBar_HSV_S.Minimum = 0;
            HTrackBar_HSV_S.Maximum = 100;
            HTrackBar_HSV_S.Delta = 2;
            HTrackBar_HSV_V.Minimum = 0;
            HTrackBar_HSV_V.Maximum = 100;
            HTrackBar_HSV_V.Delta = 2;

            HTrackBar_HSL_H.Minimum = 0;
            HTrackBar_HSL_H.Maximum = 360;
            HTrackBar_HSL_H.Delta = 5;
            HTrackBar_HSL_S.Minimum = 0;
            HTrackBar_HSL_S.Maximum = 100;
            HTrackBar_HSL_S.Delta = 2;
            HTrackBar_HSL_L.Minimum = 0;
            HTrackBar_HSL_L.Maximum = 100;
            HTrackBar_HSL_L.Delta = 2;

            HTrackBar_CMYK_C.Minimum = 0;
            HTrackBar_CMYK_C.Maximum = 100;
            HTrackBar_CMYK_C.Delta = 2;
            HTrackBar_CMYK_M.Minimum = 0;
            HTrackBar_CMYK_M.Maximum = 100;
            HTrackBar_CMYK_M.Delta = 2;
            HTrackBar_CMYK_Y.Minimum = 0;
            HTrackBar_CMYK_Y.Maximum = 100;
            HTrackBar_CMYK_Y.Delta = 2;
            HTrackBar_CMYK_K.Minimum = 0;
            HTrackBar_CMYK_K.Maximum = 100;
            HTrackBar_CMYK_K.Delta = 2;

            HTrackBar_LAB_L.Minimum = 0;
            HTrackBar_LAB_L.Maximum = 100;
            HTrackBar_LAB_L.Delta = 2;
            HTrackBar_LAB_A.Minimum = -128;
            HTrackBar_LAB_A.Maximum = 128;
            HTrackBar_LAB_A.Delta = 4;
            HTrackBar_LAB_B.Minimum = -128;
            HTrackBar_LAB_B.Maximum = 128;
            HTrackBar_LAB_B.Delta = 4;

            HTrackBar_YUV_Y.Minimum = 0;
            HTrackBar_YUV_Y.Maximum = 1;
            HTrackBar_YUV_Y.Delta = 0.02;
            HTrackBar_YUV_U.Minimum = -0.5;
            HTrackBar_YUV_U.Maximum = 0.5;
            HTrackBar_YUV_U.Delta = 0.02;
            HTrackBar_YUV_V.Minimum = -0.5;
            HTrackBar_YUV_V.Maximum = 0.5;
            HTrackBar_YUV_V.Delta = 0.02;

            //

            CurrentColor = Me.ThemeColor;

            RegisterEvents();
        }

        // 在窗体的大小调整时发生。
        private void ResizeEvents(object sender, EventArgs e)
        {
            Panel_LeftArea.Height = Panel_Main.Height;
            Panel_RightArea.Height = Panel_Main.Height;

            Panel_LeftArea.Width = Math.Min(980, Panel_Main.Width - Panel_RightArea.Width);

            Panel_LeftArea.Left = Math.Max(0, (Panel_Main.Width - Panel_LeftArea.Width - Panel_RightArea.Width) / 2);
            Panel_RightArea.Left = Panel_LeftArea.Right;

            Panel_ColorSpaces.Width = Panel_LeftArea.Width - 20;
            Panel_Transparency.Width = Panel_ColorSpaces.Width - 2 * Panel_RGB.Left;
            Panel_RGB.Width = Panel_Transparency.Width;
            Panel_HSV.Width = Panel_Transparency.Width;
            Panel_HSL.Width = Panel_Transparency.Width;
            Panel_CMYK.Width = Panel_Transparency.Width;
            Panel_LAB.Width = Panel_Transparency.Width;
            Panel_YUV.Width = Panel_Transparency.Width;
        }

        // 在窗体的大小更改时发生。
        private void SizeChangedEvents(object sender, EventArgs e)
        {
            ResizeEvents(sender, e);

            HTrackBar_Opacity.Width = Panel_Transparency.Width - HTrackBar_Opacity.Left - 20;
            HTrackBar_Alpha.Width = HTrackBar_Opacity.Width;

            HTrackBar_RGB_R.Width = Panel_RGB.Width - HTrackBar_RGB_R.Left - 20;
            HTrackBar_RGB_G.Width = HTrackBar_RGB_R.Width;
            HTrackBar_RGB_B.Width = HTrackBar_RGB_R.Width;

            HTrackBar_HSV_H.Width = Panel_HSV.Width - HTrackBar_HSV_H.Left - 20;
            HTrackBar_HSV_S.Width = HTrackBar_HSV_H.Width;
            HTrackBar_HSV_V.Width = HTrackBar_HSV_H.Width;

            HTrackBar_HSL_H.Width = Panel_HSL.Width - HTrackBar_HSL_H.Left - 20;
            HTrackBar_HSL_S.Width = HTrackBar_HSL_H.Width;
            HTrackBar_HSL_L.Width = HTrackBar_HSL_H.Width;

            HTrackBar_CMYK_C.Width = Panel_CMYK.Width - HTrackBar_CMYK_C.Left - 20;
            HTrackBar_CMYK_M.Width = HTrackBar_CMYK_C.Width;
            HTrackBar_CMYK_Y.Width = HTrackBar_CMYK_C.Width;
            HTrackBar_CMYK_K.Width = HTrackBar_CMYK_C.Width;

            HTrackBar_LAB_L.Width = Panel_LAB.Width - HTrackBar_LAB_L.Left - 20;
            HTrackBar_LAB_A.Width = HTrackBar_LAB_L.Width;
            HTrackBar_LAB_B.Width = HTrackBar_LAB_L.Width;

            HTrackBar_YUV_Y.Width = Panel_YUV.Width - HTrackBar_YUV_Y.Left - 20;
            HTrackBar_YUV_U.Width = HTrackBar_YUV_Y.Width;
            HTrackBar_YUV_V.Width = HTrackBar_YUV_Y.Width;
        }

        // 在窗体的主题色更改时发生。
        private void ThemeColorChangedEvents(object sender, EventArgs e)
        {

        }

        #endregion

        #region 通用功能

        private void RegisterEvents()
        {
            HTrackBar_Opacity.ValueChanged += HTrackBar_ValueChanged;
            HTrackBar_Alpha.ValueChanged += HTrackBar_ValueChanged;

            HTrackBar_RGB_R.ValueChanged += HTrackBar_ValueChanged;
            HTrackBar_RGB_G.ValueChanged += HTrackBar_ValueChanged;
            HTrackBar_RGB_B.ValueChanged += HTrackBar_ValueChanged;

            HTrackBar_HSV_H.ValueChanged += HTrackBar_ValueChanged;
            HTrackBar_HSV_S.ValueChanged += HTrackBar_ValueChanged;
            HTrackBar_HSV_V.ValueChanged += HTrackBar_ValueChanged;

            HTrackBar_HSL_H.ValueChanged += HTrackBar_ValueChanged;
            HTrackBar_HSL_S.ValueChanged += HTrackBar_ValueChanged;
            HTrackBar_HSL_L.ValueChanged += HTrackBar_ValueChanged;

            HTrackBar_CMYK_C.ValueChanged += HTrackBar_ValueChanged;
            HTrackBar_CMYK_M.ValueChanged += HTrackBar_ValueChanged;
            HTrackBar_CMYK_Y.ValueChanged += HTrackBar_ValueChanged;
            HTrackBar_CMYK_K.ValueChanged += HTrackBar_ValueChanged;

            HTrackBar_LAB_L.ValueChanged += HTrackBar_ValueChanged;
            HTrackBar_LAB_A.ValueChanged += HTrackBar_ValueChanged;
            HTrackBar_LAB_B.ValueChanged += HTrackBar_ValueChanged;

            HTrackBar_YUV_Y.ValueChanged += HTrackBar_ValueChanged;
            HTrackBar_YUV_U.ValueChanged += HTrackBar_ValueChanged;
            HTrackBar_YUV_V.ValueChanged += HTrackBar_ValueChanged;
        }

        private void UnregisterEvents()
        {
            HTrackBar_Opacity.ValueChanged -= HTrackBar_ValueChanged;
            HTrackBar_Alpha.ValueChanged -= HTrackBar_ValueChanged;

            HTrackBar_RGB_R.ValueChanged -= HTrackBar_ValueChanged;
            HTrackBar_RGB_G.ValueChanged -= HTrackBar_ValueChanged;
            HTrackBar_RGB_B.ValueChanged -= HTrackBar_ValueChanged;

            HTrackBar_HSV_H.ValueChanged -= HTrackBar_ValueChanged;
            HTrackBar_HSV_S.ValueChanged -= HTrackBar_ValueChanged;
            HTrackBar_HSV_V.ValueChanged -= HTrackBar_ValueChanged;

            HTrackBar_HSL_H.ValueChanged -= HTrackBar_ValueChanged;
            HTrackBar_HSL_S.ValueChanged -= HTrackBar_ValueChanged;
            HTrackBar_HSL_L.ValueChanged -= HTrackBar_ValueChanged;

            HTrackBar_CMYK_C.ValueChanged -= HTrackBar_ValueChanged;
            HTrackBar_CMYK_M.ValueChanged -= HTrackBar_ValueChanged;
            HTrackBar_CMYK_Y.ValueChanged -= HTrackBar_ValueChanged;
            HTrackBar_CMYK_K.ValueChanged -= HTrackBar_ValueChanged;

            HTrackBar_LAB_L.ValueChanged -= HTrackBar_ValueChanged;
            HTrackBar_LAB_A.ValueChanged -= HTrackBar_ValueChanged;
            HTrackBar_LAB_B.ValueChanged -= HTrackBar_ValueChanged;

            HTrackBar_YUV_Y.ValueChanged -= HTrackBar_ValueChanged;
            HTrackBar_YUV_U.ValueChanged -= HTrackBar_ValueChanged;
            HTrackBar_YUV_V.ValueChanged -= HTrackBar_ValueChanged;
        }

        private void UpdateTrackBar(Com.ColorX color)
        {
            for (int i = 0; i < _ColorsNum; i++)
            {
                double Pct = (double)i / (_ColorsNum - 1);

                (_ColorsTable[_ColorsKey.Opacity] as Color[])[i] = color.AtOpacity(Pct * 100).ToColor();
                (_ColorsTable[_ColorsKey.Alpha] as Color[])[i] = color.AtAlpha(Pct * 255).ToColor();
                (_ColorsTable[_ColorsKey.RGB_R] as Color[])[i] = color.AtRed(Pct * 255).ToColor();
                (_ColorsTable[_ColorsKey.RGB_G] as Color[])[i] = color.AtGreen(Pct * 255).ToColor();
                (_ColorsTable[_ColorsKey.RGB_B] as Color[])[i] = color.AtBlue(Pct * 255).ToColor();
                (_ColorsTable[_ColorsKey.HSV_H] as Color[])[i] = color.AtHue_HSV(Pct * 360).ToColor();
                (_ColorsTable[_ColorsKey.HSV_S] as Color[])[i] = color.AtSaturation_HSV(Pct * 100).ToColor();
                (_ColorsTable[_ColorsKey.HSV_V] as Color[])[i] = color.AtBrightness(Pct * 100).ToColor();
                (_ColorsTable[_ColorsKey.HSL_H] as Color[])[i] = color.AtHue_HSL(Pct * 360).ToColor();
                (_ColorsTable[_ColorsKey.HSL_S] as Color[])[i] = color.AtSaturation_HSL(Pct * 100).ToColor();
                (_ColorsTable[_ColorsKey.HSL_L] as Color[])[i] = color.AtLightness_HSL(Pct * 100).ToColor();
                (_ColorsTable[_ColorsKey.CMYK_C] as Color[])[i] = color.AtCyan(Pct * 100).ToColor();
                (_ColorsTable[_ColorsKey.CMYK_M] as Color[])[i] = color.AtMagenta(Pct * 100).ToColor();
                (_ColorsTable[_ColorsKey.CMYK_Y] as Color[])[i] = color.AtYellow(Pct * 100).ToColor();
                (_ColorsTable[_ColorsKey.CMYK_K] as Color[])[i] = color.AtBlack(Pct * 100).ToColor();
                (_ColorsTable[_ColorsKey.LAB_L] as Color[])[i] = color.AtLightness_LAB(Pct * 100).ToColor();
                (_ColorsTable[_ColorsKey.LAB_A] as Color[])[i] = color.AtGreenRed(-128 + Pct * 256).ToColor();
                (_ColorsTable[_ColorsKey.LAB_B] as Color[])[i] = color.AtBlueYellow(-128 + Pct * 256).ToColor();
                (_ColorsTable[_ColorsKey.YUV_Y] as Color[])[i] = color.AtLuminance(Pct * 1.0).ToColor();
                (_ColorsTable[_ColorsKey.YUV_U] as Color[])[i] = color.AtChrominanceBlue(-0.5 + Pct * 1.0).ToColor();
                (_ColorsTable[_ColorsKey.YUV_V] as Color[])[i] = color.AtChrominanceRed(-0.5 + Pct * 1.0).ToColor();
            }

            HTrackBar_Opacity.Colors = _ColorsTable[_ColorsKey.Opacity] as Color[];
            HTrackBar_Alpha.Colors = _ColorsTable[_ColorsKey.Alpha] as Color[];
            HTrackBar_RGB_R.Colors = _ColorsTable[_ColorsKey.RGB_R] as Color[];
            HTrackBar_RGB_G.Colors = _ColorsTable[_ColorsKey.RGB_G] as Color[];
            HTrackBar_RGB_B.Colors = _ColorsTable[_ColorsKey.RGB_B] as Color[];
            HTrackBar_HSV_H.Colors = _ColorsTable[_ColorsKey.HSV_H] as Color[];
            HTrackBar_HSV_S.Colors = _ColorsTable[_ColorsKey.HSV_S] as Color[];
            HTrackBar_HSV_V.Colors = _ColorsTable[_ColorsKey.HSV_V] as Color[];
            HTrackBar_HSL_H.Colors = _ColorsTable[_ColorsKey.HSL_H] as Color[];
            HTrackBar_HSL_S.Colors = _ColorsTable[_ColorsKey.HSL_S] as Color[];
            HTrackBar_HSL_L.Colors = _ColorsTable[_ColorsKey.HSL_L] as Color[];
            HTrackBar_CMYK_C.Colors = _ColorsTable[_ColorsKey.CMYK_C] as Color[];
            HTrackBar_CMYK_M.Colors = _ColorsTable[_ColorsKey.CMYK_M] as Color[];
            HTrackBar_CMYK_Y.Colors = _ColorsTable[_ColorsKey.CMYK_Y] as Color[];
            HTrackBar_CMYK_K.Colors = _ColorsTable[_ColorsKey.CMYK_K] as Color[];
            HTrackBar_LAB_L.Colors = _ColorsTable[_ColorsKey.LAB_L] as Color[];
            HTrackBar_LAB_A.Colors = _ColorsTable[_ColorsKey.LAB_A] as Color[];
            HTrackBar_LAB_B.Colors = _ColorsTable[_ColorsKey.LAB_B] as Color[];
            HTrackBar_YUV_Y.Colors = _ColorsTable[_ColorsKey.YUV_Y] as Color[];
            HTrackBar_YUV_U.Colors = _ColorsTable[_ColorsKey.YUV_U] as Color[];
            HTrackBar_YUV_V.Colors = _ColorsTable[_ColorsKey.YUV_V] as Color[];

            HTrackBar_Opacity.Value = color.Opacity;
            HTrackBar_Alpha.Value = color.Alpha;
            HTrackBar_RGB_R.Value = color.Red;
            HTrackBar_RGB_G.Value = color.Green;
            HTrackBar_RGB_B.Value = color.Blue;
            HTrackBar_HSV_H.Value = color.Hue_HSV;
            HTrackBar_HSV_S.Value = color.Saturation_HSV;
            HTrackBar_HSV_V.Value = color.Brightness;
            HTrackBar_HSL_H.Value = color.Hue_HSL;
            HTrackBar_HSL_S.Value = color.Saturation_HSL;
            HTrackBar_HSL_L.Value = color.Lightness_HSL;
            HTrackBar_CMYK_C.Value = color.Cyan;
            HTrackBar_CMYK_M.Value = color.Magenta;
            HTrackBar_CMYK_Y.Value = color.Yellow;
            HTrackBar_CMYK_K.Value = color.Black;
            HTrackBar_LAB_L.Value = color.Lightness_LAB;
            HTrackBar_LAB_A.Value = color.GreenRed;
            HTrackBar_LAB_B.Value = color.BlueYellow;
            HTrackBar_YUV_Y.Value = color.Luminance;
            HTrackBar_YUV_U.Value = color.ChrominanceBlue;
            HTrackBar_YUV_V.Value = color.ChrominanceRed;
        }

        private Com.ColorX CurrentColor
        {
            get
            {
                switch (_ColorTag)
                {
                    case _ColorTags.BackColor: return _BackColor;
                    default: return Com.ColorX.Empty;
                }
            }

            set
            {
                switch (_ColorTag)
                {
                    case _ColorTags.BackColor: _BackColor = value; break;
                }

                Label_Preview.BackColor = value.ToColor();

                UpdateTrackBar(value);
            }
        }

        private void ChoseColor(_ColorTags colorTag)
        {
            _ColorTag = colorTag;

            UpdateTrackBar(CurrentColor);
        }

        #endregion

        #region 分量调节

        private void HTrackBar_ValueChanged(object sender, EventArgs e)
        {
            HTrackBar trackBar = sender as HTrackBar;

            if (trackBar != null)
            {
                UnregisterEvents();

                Com.ColorX color = CurrentColor;

                double channel = trackBar.Value;

                if (trackBar == HTrackBar_Opacity)
                {
                    color.Opacity = channel;
                }
                else if (trackBar == HTrackBar_Alpha)
                {
                    color.Alpha = channel;
                }
                else if (trackBar == HTrackBar_RGB_R)
                {
                    color.Red = channel;
                }
                else if (trackBar == HTrackBar_RGB_G)
                {
                    color.Green = channel;
                }
                else if (trackBar == HTrackBar_RGB_B)
                {
                    color.Blue = channel;
                }
                else if (trackBar == HTrackBar_HSV_H)
                {
                    color.Hue_HSV = channel;
                }
                else if (trackBar == HTrackBar_HSV_S)
                {
                    color.Saturation_HSV = channel;
                }
                else if (trackBar == HTrackBar_HSV_V)
                {
                    color.Brightness = channel;
                }
                else if (trackBar == HTrackBar_HSL_H)
                {
                    color.Hue_HSL = channel;
                }
                else if (trackBar == HTrackBar_HSL_S)
                {
                    color.Saturation_HSL = channel;
                }
                else if (trackBar == HTrackBar_HSL_L)
                {
                    color.Lightness_HSL = channel;
                }
                else if (trackBar == HTrackBar_CMYK_C)
                {
                    color.Cyan = channel;
                }
                else if (trackBar == HTrackBar_CMYK_M)
                {
                    color.Magenta = channel;
                }
                else if (trackBar == HTrackBar_CMYK_Y)
                {
                    color.Yellow = channel;
                }
                else if (trackBar == HTrackBar_CMYK_K)
                {
                    color.Black = channel;
                }
                else if (trackBar == HTrackBar_LAB_L)
                {
                    color.Lightness_LAB = channel;
                }
                else if (trackBar == HTrackBar_LAB_A)
                {
                    color.GreenRed = channel;
                }
                else if (trackBar == HTrackBar_LAB_B)
                {
                    color.BlueYellow = channel;
                }
                else if (trackBar == HTrackBar_YUV_Y)
                {
                    color.Luminance = channel;
                }
                else if (trackBar == HTrackBar_YUV_U)
                {
                    color.ChrominanceBlue = channel;
                }
                else if (trackBar == HTrackBar_YUV_V)
                {
                    color.ChrominanceRed = channel;
                }

                CurrentColor = color;

                RegisterEvents();
            }
        }

        #endregion
    }
}