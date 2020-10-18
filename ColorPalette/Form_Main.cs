/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
Copyright © 2020 chibayuki@foxmail.com

调色板 (ColorPalette)
Version 1.0.66.1000.M1.201017-0000

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
using System.Diagnostics;
using System.Drawing.Drawing2D;

using ColorManipulation = Com.ColorManipulation;
using ColorX = Com.ColorX;
using Geometry = Com.Geometry;
using ControlSubstitution = Com.WinForm.ControlSubstitution;
using FormManager = Com.WinForm.FormManager;
using FormStyle = Com.WinForm.FormStyle;
using Theme = Com.WinForm.Theme;

namespace ColorPalette
{
    public partial class Form_Main : Form
    {
        #region 私有成员与内部成员

        private const int _BuiltinColorsNum = 252;
        private const int _BuiltinColorsNumX = 18;
        private const int _BuiltinColorsNumY = 14;
        private ColorX[] _BuiltinColors = new ColorX[_BuiltinColorsNum];

        private const int _CustomizeColorsNum = 36;
        private const int _CustomizeColorsNumX = 18;
        private const int _CustomizeColorsNumY = 2;
        private ColorX[] _CustomizeColors = new ColorX[_CustomizeColorsNum];

        private ColorX _BlendColor1;
        private ColorX _BlendColor2;

        private ColorX _BackgroundColor;
        private ColorX _LabelColor;
        private ColorX _BorderColor;
        private ColorX _TextColor;

        private ColorX _ThemeColor;

        // 颜色标签
        private enum _ColorTags
        {
            None = -1,

            Grayscale,
            Complementary,
            Invert,

            BuiltinFirst,
            BuiltinLast = BuiltinFirst + _BuiltinColorsNum - 1,

            CustomizeFirst,
            CustomizeLast = CustomizeFirst + _CustomizeColorsNum - 1,

            BlendColor1,
            BlendColor2,
            BlendResultRGB,
            BlendResultHSV,
            BlendResultHSL,
            BlendResultCMYK,
            BlendResultLAB,
            BlendResultYUV,

            Background,
            Label,
            Border,
            Text,

            ThemeColor
        }

        private _ColorTags _ColorTag = _ColorTags.None;

        //

        private const int _HTrackBarColorsNum = 11;

        private enum _HTrackBarColorsKey
        {
            Opacity,
            Alpha,

            RGB_R,
            RGB_G,
            RGB_B,

            HSV_H,
            HSV_S,
            HSV_V,

            HSL_H,
            HSL_S,
            HSL_L,

            CMYK_C,
            CMYK_M,
            CMYK_Y,
            CMYK_K,

            LAB_L,
            LAB_A,
            LAB_B,

            YUV_Y,
            YUV_U,
            YUV_V,
        }

        private Dictionary<_HTrackBarColorsKey, Color[]> _HTrackBarColorsTable = null;

        #endregion

        #region 窗体构造

        private FormManager Me;

        public FormManager FormManager
        {
            get
            {
                return Me;
            }
        }

        private void _Ctor(FormManager owner)
        {
            InitializeComponent();

            //

            if (owner != null)
            {
                Me = new FormManager(this, owner);
            }
            else
            {
                Me = new FormManager(this);
            }

            //

            FormDefine();
        }

        public Form_Main()
        {
            _Ctor(null);
        }

        public Form_Main(FormManager owner)
        {
            _Ctor(owner);
        }

        private void FormDefine()
        {
            Me.Caption = Application.ProductName;
            Me.FormStyle = FormStyle.Sizable;
            Me.EnableFullScreen = false;
            Me.Theme = Theme.White;
            Me.ThemeColor = Color.Gray;
            Me.MinimumSize = new Size(1020, 290 + Me.CaptionBarHeight);

            Me.Loading += LoadingEvents;
            Me.Loaded += LoadedEvents;
            Me.Resize += ResizeEvents;
            Me.SizeChanged += SizeChangedEvents;
            Me.ThemeChanged += ThemeColorChangedEvents;
            Me.ThemeColorChanged += ThemeColorChangedEvents;
        }

        #endregion

        #region 窗体事件

        private void LoadingEvents(object sender, EventArgs e)
        {
            _HTrackBarColorsTable = new Dictionary<_HTrackBarColorsKey, Color[]>();

            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.Opacity, new Color[2]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.Alpha, new Color[2]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.RGB_R, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.RGB_G, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.RGB_B, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.HSV_H, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.HSV_S, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.HSV_V, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.HSL_H, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.HSL_S, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.HSL_L, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.CMYK_C, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.CMYK_M, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.CMYK_Y, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.CMYK_K, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.LAB_L, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.LAB_A, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.LAB_B, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.YUV_Y, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.YUV_U, new Color[_HTrackBarColorsNum]);
            _HTrackBarColorsTable.Add(_HTrackBarColorsKey.YUV_V, new Color[_HTrackBarColorsNum]);

            //

            string[] webColorHex = { "00", "33", "66", "99", "CC", "FF" };
            /*string[] grayscaleColorHex = {
                "FF", "F0", "E0", "D0", "C0", "B0", "A0", "90", "80",
                "00", "10", "20", "30", "40", "50", "60", "70" };*/
            string[] grayscaleColorHex = {
                "FF", "F0", "E0", "C0", "A0", "80",
                "60", "40", "20", "10", "00" };

            for (int i = 0; i < _BuiltinColorsNum; i++)
            {
                if (i < 216)
                {
                    int x = i % _BuiltinColorsNumX, y = i / _BuiltinColorsNumX;
                    int blockX = x / 6, blockY = y / 6;

                    int r, g, b;

                    if (blockX == 0 && blockY == 1) r = 0;
                    else if (blockX == 0 && blockY == 0) r = 1;
                    else if (blockX == 1 && blockY == 0) r = 2;
                    else if (blockX == 1 && blockY == 1) r = 3;
                    else if (blockX == 2 && blockY == 1) r = 4;
                    else r = 5;

                    if (x < 6) g = x;
                    else if (x < 12) g = 11 - x;
                    else g = x - 12;

                    if (y < 6) b = y;
                    else if (y < 12) b = 11 - y;
                    else b = y - 12;

                    _BuiltinColors[i] = ColorX.FromHexCode(webColorHex[r] + webColorHex[g] + webColorHex[b]);
                }
                /*else if (i < 216 + 18)
                {
                    int index;

                    if (i < 216 + 9)
                    {
                        index = i;
                    }
                    else
                    {
                        index = i + 9;
                    }*/
                else if (i < 216 + 24)
                {
                    int index;

                    if (i < 216 + 12)
                    {
                        index = i;
                    }
                    else
                    {
                        index = i + 6;
                    }

                    switch (i - 216)
                    {
                        /*case 0: _BuiltinColors[index] = ColorX.FromRGB(255, 0, 0); break;
                        case 1: _BuiltinColors[index] = ColorX.FromRGB(255, 85, 0); break;
                        case 2: _BuiltinColors[index] = ColorX.FromRGB(255, 170, 0); break;

                        case 3: _BuiltinColors[index] = ColorX.FromRGB(255, 255, 0); break;
                        case 4: _BuiltinColors[index] = ColorX.FromRGB(170, 255, 0); break;
                        case 5: _BuiltinColors[index] = ColorX.FromRGB(85, 255, 0); break;

                        case 6: _BuiltinColors[index] = ColorX.FromRGB(0, 255, 0); break;
                        case 7: _BuiltinColors[index] = ColorX.FromRGB(0, 255, 85); break;
                        case 8: _BuiltinColors[index] = ColorX.FromRGB(0, 255, 170); break;

                        case 9: _BuiltinColors[index] = ColorX.FromRGB(0, 255, 255); break;
                        case 10: _BuiltinColors[index] = ColorX.FromRGB(0, 170, 255); break;
                        case 11: _BuiltinColors[index] = ColorX.FromRGB(0, 85, 255); break;

                        case 12: _BuiltinColors[index] = ColorX.FromRGB(0, 0, 255); break;
                        case 13: _BuiltinColors[index] = ColorX.FromRGB(85, 0, 255); break;
                        case 14: _BuiltinColors[index] = ColorX.FromRGB(170, 0, 255); break;

                        case 15: _BuiltinColors[index] = ColorX.FromRGB(255, 0, 255); break;
                        case 16: _BuiltinColors[index] = ColorX.FromRGB(255, 0, 170); break;
                        case 17: _BuiltinColors[index] = ColorX.FromRGB(255, 0, 85); break;*/

                        case 0: _BuiltinColors[index] = ColorX.FromRGB(255, 0, 0); break;
                        case 1: _BuiltinColors[index] = ColorX.FromRGB(255, 64, 0); break;
                        case 2: _BuiltinColors[index] = ColorX.FromRGB(255, 128, 0); break;
                        case 3: _BuiltinColors[index] = ColorX.FromRGB(255, 192, 0); break;

                        case 4: _BuiltinColors[index] = ColorX.FromRGB(255, 255, 0); break;
                        case 5: _BuiltinColors[index] = ColorX.FromRGB(192, 255, 0); break;
                        case 6: _BuiltinColors[index] = ColorX.FromRGB(128, 255, 0); break;
                        case 7: _BuiltinColors[index] = ColorX.FromRGB(64, 255, 0); break;

                        case 8: _BuiltinColors[index] = ColorX.FromRGB(0, 255, 0); break;
                        case 9: _BuiltinColors[index] = ColorX.FromRGB(0, 255, 64); break;
                        case 10: _BuiltinColors[index] = ColorX.FromRGB(0, 255, 128); break;
                        case 11: _BuiltinColors[index] = ColorX.FromRGB(0, 255, 192); break;

                        case 12: _BuiltinColors[index] = ColorX.FromRGB(0, 255, 255); break;
                        case 13: _BuiltinColors[index] = ColorX.FromRGB(0, 192, 255); break;
                        case 14: _BuiltinColors[index] = ColorX.FromRGB(0, 128, 255); break;
                        case 15: _BuiltinColors[index] = ColorX.FromRGB(0, 64, 255); break;

                        case 16: _BuiltinColors[index] = ColorX.FromRGB(0, 0, 255); break;
                        case 17: _BuiltinColors[index] = ColorX.FromRGB(64, 0, 255); break;
                        case 18: _BuiltinColors[index] = ColorX.FromRGB(128, 0, 255); break;
                        case 19: _BuiltinColors[index] = ColorX.FromRGB(192, 0, 255); break;

                        case 20: _BuiltinColors[index] = ColorX.FromRGB(255, 0, 255); break;
                        case 21: _BuiltinColors[index] = ColorX.FromRGB(255, 0, 192); break;
                        case 22: _BuiltinColors[index] = ColorX.FromRGB(255, 0, 128); break;
                        case 23: _BuiltinColors[index] = ColorX.FromRGB(255, 0, 64); break;
                    }
                }
                /*else if (i < 216 + 18 + grayscaleColorHex.Length)
                {
                    string grayscale = grayscaleColorHex[i - 216 - 18];

                    int index;

                    if (i < 216 + 18 + 9)
                    {
                        index = i - 9;
                    }
                    else
                    {
                        index = i;
                    }*/
                else if (i < 216 + 24 + grayscaleColorHex.Length)
                {
                    string grayscale = grayscaleColorHex[i - 216 - 24];

                    int index;

                    if (i < 216 + 24 + 6)
                    {
                        index = i - 12;
                    }
                    else
                    {
                        index = i;
                    }

                    _BuiltinColors[index] = ColorX.FromHexCode(grayscale + grayscale + grayscale);
                }
                else
                {
                    _BuiltinColors[i] = ColorX.Transparent;
                }
            }

            for (int i = 0; i < _CustomizeColorsNum; i++)
            {
                _CustomizeColors[i] = Color.White;
            }

            _BackgroundColor = Me.RecommendColors.Background_INC;
            _LabelColor = Me.RecommendColors.Button;
            _BorderColor = Me.RecommendColors.Border_INC;
            _TextColor = Me.RecommendColors.Text_INC;

            _BlendColor1 = ColorManipulation.GetRandomColorX();
            _BlendColor2 = _BlendColor1.AtHue_HSV(_BlendColor1.Hue_HSV >= 120 ? _BlendColor1.Hue_HSV - 120 : _BlendColor1.Hue_HSV + 120);

            _ThemeColor = Me.ThemeColor;
        }

        private void LoadedEvents(object sender, EventArgs e)
        {
            Me.OnSizeChanged();
            Me.OnThemeChanged();

            //

            Label_BuiltinColors = new Label[_BuiltinColorsNum];

            const int Lab_B_Sz_W = 24, Lab_B_Sz_H = 24;

            Panel_Colors_Builtin.Height = Lab_B_Sz_H * _BuiltinColorsNumY + 10;

            int Lab_B_Off_X = (Panel_Colors_Builtin.Width - Lab_B_Sz_W * _BuiltinColorsNumX) / 2, Lab_B_Off_Y = (Panel_Colors_Builtin.Height - Lab_B_Sz_H * _BuiltinColorsNumY) / 2;

            for (int i = 0; i < _BuiltinColorsNum; i++)
            {
                int x = i % _BuiltinColorsNumX;
                int y = i / _BuiltinColorsNumX;

                Label l = new Label();

                l.BackColor = Color.Transparent;
                l.Location = new Point(Lab_B_Off_X + x * Lab_B_Sz_W + 1, Lab_B_Off_Y + y * Lab_B_Sz_H + 1);
                l.Size = new Size(Lab_B_Sz_W - 1, Lab_B_Sz_H - 1);
                l.TabIndex = 0;
                l.MouseDown += Label_BuiltinColors_MouseDown;
                l.MouseUp += Label_BuiltinColors_MouseUp;

                Panel_Colors_Builtin.Controls.Add(l);

                Label_BuiltinColors[y * _BuiltinColorsNumX + x] = l;
            }

            //

            Label_CustomizeColors = new Label[_CustomizeColorsNum];

            const int Lab_C_Sz_W = 24, Lab_C_Sz_H = 24;

            Panel_Colors_Customize.Height = Lab_C_Sz_H * _CustomizeColorsNumY + 10;

            int Lab_C_Off_X = (Panel_Colors_Customize.Width - Lab_C_Sz_W * _CustomizeColorsNumX) / 2, Lab_C_Off_Y = (Panel_Colors_Customize.Height - Lab_C_Sz_H * _CustomizeColorsNumY) / 2;

            for (int i = 0; i < _CustomizeColorsNum; i++)
            {
                int x = i % _CustomizeColorsNumX;
                int y = i / _CustomizeColorsNumX;

                Label l = new Label();

                l.BackColor = Color.Transparent;
                l.Location = new Point(Lab_C_Off_X + x * Lab_C_Sz_W, Lab_C_Off_Y + y * Lab_C_Sz_H);
                l.Size = new Size(Lab_C_Sz_W, Lab_C_Sz_H);
                l.Cursor = Cursors.Hand;
                l.TabIndex = 0;
                l.MouseDown += Label_CustomizeColors_MouseDown;
                l.MouseUp += Label_CustomizeColors_MouseUp;

                Panel_Colors_Customize.Controls.Add(l);

                Label_CustomizeColors[y * _CustomizeColorsNumX + x] = l;
            }

            //

            Label_Colors_Customize.Top = Panel_Colors_Builtin.Bottom + 10;
            Panel_Colors_Customize.Top = Label_Colors_Customize.Bottom;
            Panel_Colors_Contents.Height = Panel_Colors_Customize.Bottom + 10;
            Panel_Colors.Height = Panel_Colors_Contents.Bottom;
            Panel_Blend.Top = Panel_Colors.Bottom + 15;
            Panel_View.Top = Panel_Blend.Bottom + 15;
            Panel_Appearance.Top = Panel_View.Bottom + 15;
            Panel_About.Top = Panel_Appearance.Bottom + 15;
            Panel_EditingColors.Height = Panel_About.Bottom + 20;

            //

            Label_Background_Val.BackColor = Color.Transparent;
            Label_Label_Val.BackColor = Color.Transparent;
            Label_Border_Val.BackColor = Color.Transparent;
            Label_Text_Val.BackColor = Color.Transparent;

            //

            Label_BlendColor1_Val.BackColor = Color.Transparent;
            Label_BlendColor2_Val.BackColor = Color.Transparent;
            Label_BlendResultRGB_Val.BackColor = Color.Transparent;
            Label_BlendResultHSV_Val.BackColor = Color.Transparent;
            Label_BlendResultHSL_Val.BackColor = Color.Transparent;
            Label_BlendResultCMYK_Val.BackColor = Color.Transparent;
            Label_BlendResultLAB_Val.BackColor = Color.Transparent;
            Label_BlendResultYUV_Val.BackColor = Color.Transparent;

            NumEditor_Blend.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            NumEditor_Blend.Minimum = 0;
            NumEditor_Blend.Maximum = 100;
            NumEditor_Blend.Precision = 3;

            HTrackBar_Blend.Colors = new Color[] { Color.Transparent, _BlendColor1.ToColor() };

            NumEditor_Blend.ValueChanged += NumEditor_Blend_ValueChanged;
            HTrackBar_Blend.ValueChanged += HTrackBar_Blend_ValueChanged;

            //

            ComboBox_Theme.SelectedIndexChanged -= ComboBox_Theme_SelectedIndexChanged;
            ComboBox_Theme.SelectedIndex = (int)Me.Theme;
            ComboBox_Theme.SelectedIndexChanged += ComboBox_Theme_SelectedIndexChanged;

            RadioButton_ThemeColor_Customize.CheckedChanged -= RadioButton_ThemeColor_Customize_CheckedChanged;
            RadioButton_ThemeColor_EditingColor.CheckedChanged -= RadioButton_ThemeColor_EditingColor_CheckedChanged;
            RadioButton_ThemeColor_Windows.CheckedChanged -= RadioButton_ThemeColor_Windows_CheckedChanged;
            RadioButton_ThemeColor_Customize.Checked = true;
            RadioButton_ThemeColor_Customize.CheckedChanged += RadioButton_ThemeColor_Customize_CheckedChanged;
            RadioButton_ThemeColor_EditingColor.CheckedChanged += RadioButton_ThemeColor_EditingColor_CheckedChanged;
            RadioButton_ThemeColor_Windows.CheckedChanged += RadioButton_ThemeColor_Windows_CheckedChanged;

            Label_ThemeColor_Customize.BackColor = Color.Transparent;

            //

            Label_AppName.Text = Application.ProductName;
            Label_AppVersion.Text = Application.ProductVersion;

            Label_AppVersion.Left = Label_AppName.Right + 10;

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

            Font numEditorFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);

            NumEditor_Opacity.Font = numEditorFont;
            NumEditor_Opacity.Minimum = 0;
            NumEditor_Opacity.Maximum = 100;
            NumEditor_Opacity.Precision = 3;
            NumEditor_Alpha.Font = numEditorFont;
            NumEditor_Alpha.Minimum = 0;
            NumEditor_Alpha.Maximum = 255;
            NumEditor_Alpha.Precision = 3;

            NumEditor_RGB_R.Font = numEditorFont;
            NumEditor_RGB_R.Minimum = 0;
            NumEditor_RGB_R.Maximum = 255;
            NumEditor_RGB_R.Precision = 3;
            NumEditor_RGB_G.Font = numEditorFont;
            NumEditor_RGB_G.Minimum = 0;
            NumEditor_RGB_G.Maximum = 255;
            NumEditor_RGB_G.Precision = 3;
            NumEditor_RGB_B.Font = numEditorFont;
            NumEditor_RGB_B.Minimum = 0;
            NumEditor_RGB_B.Maximum = 255;
            NumEditor_RGB_B.Precision = 3;

            NumEditor_HSV_H.Font = numEditorFont;
            NumEditor_HSV_H.Minimum = 0;
            NumEditor_HSV_H.Maximum = 360;
            NumEditor_HSV_H.Precision = 3;
            NumEditor_HSV_S.Font = numEditorFont;
            NumEditor_HSV_S.Minimum = 0;
            NumEditor_HSV_S.Maximum = 100;
            NumEditor_HSV_S.Precision = 3;
            NumEditor_HSV_V.Font = numEditorFont;
            NumEditor_HSV_V.Minimum = 0;
            NumEditor_HSV_V.Maximum = 100;
            NumEditor_HSV_V.Precision = 3;

            NumEditor_HSL_H.Font = numEditorFont;
            NumEditor_HSL_H.Minimum = 0;
            NumEditor_HSL_H.Maximum = 360;
            NumEditor_HSL_H.Precision = 3;
            NumEditor_HSL_S.Font = numEditorFont;
            NumEditor_HSL_S.Minimum = 0;
            NumEditor_HSL_S.Maximum = 100;
            NumEditor_HSL_S.Precision = 3;
            NumEditor_HSL_L.Font = numEditorFont;
            NumEditor_HSL_L.Minimum = 0;
            NumEditor_HSL_L.Maximum = 100;
            NumEditor_HSL_L.Precision = 3;

            NumEditor_CMYK_C.Font = numEditorFont;
            NumEditor_CMYK_C.Minimum = 0;
            NumEditor_CMYK_C.Maximum = 100;
            NumEditor_CMYK_C.Precision = 3;
            NumEditor_CMYK_M.Font = numEditorFont;
            NumEditor_CMYK_M.Minimum = 0;
            NumEditor_CMYK_M.Maximum = 100;
            NumEditor_CMYK_M.Precision = 3;
            NumEditor_CMYK_Y.Font = numEditorFont;
            NumEditor_CMYK_Y.Minimum = 0;
            NumEditor_CMYK_Y.Maximum = 100;
            NumEditor_CMYK_Y.Precision = 3;
            NumEditor_CMYK_K.Font = numEditorFont;
            NumEditor_CMYK_K.Minimum = 0;
            NumEditor_CMYK_K.Maximum = 100;
            NumEditor_CMYK_K.Precision = 3;

            NumEditor_LAB_L.Font = numEditorFont;
            NumEditor_LAB_L.Minimum = 0;
            NumEditor_LAB_L.Maximum = 100;
            NumEditor_LAB_L.Precision = 3;
            NumEditor_LAB_A.Font = numEditorFont;
            NumEditor_LAB_A.Minimum = -128;
            NumEditor_LAB_A.Maximum = 128;
            NumEditor_LAB_A.Precision = 3;
            NumEditor_LAB_B.Font = numEditorFont;
            NumEditor_LAB_B.Minimum = -128;
            NumEditor_LAB_B.Maximum = 128;
            NumEditor_LAB_B.Precision = 3;

            NumEditor_YUV_Y.Font = numEditorFont;
            NumEditor_YUV_Y.Minimum = 0;
            NumEditor_YUV_Y.Maximum = 1;
            NumEditor_YUV_Y.Precision = 3;
            NumEditor_YUV_U.Font = numEditorFont;
            NumEditor_YUV_U.Minimum = -0.5;
            NumEditor_YUV_U.Maximum = 0.5;
            NumEditor_YUV_U.Precision = 3;
            NumEditor_YUV_V.Font = numEditorFont;
            NumEditor_YUV_V.Minimum = -0.5;
            NumEditor_YUV_V.Maximum = 0.5;
            NumEditor_YUV_V.Precision = 3;

            //

            RegisterEvents();

            //

            ChoseColor(_ColorTags.CustomizeFirst);

            //

            Panel_Main.Visible = true;

            //

            Me.OnThemeChanged();
        }

        private void ResizeEvents(object sender, EventArgs e)
        {
            if (Panel_LeftArea.Height >= Panel_EditingColors.Height)
            {
                Panel_LeftArea.Width = Panel_EditingColors.Width;
            }
            else
            {
                Panel_LeftArea.Width = Panel_EditingColors.Width + 20;
            }

            if (Panel_RightArea.Height >= Panel_ColorSpaces.Height)
            {
                Panel_ColorSpaces.Width = Panel_RightArea.Width;
            }
            else
            {
                Panel_ColorSpaces.Width = Panel_RightArea.Width - 20;
            }

            Panel_RightArea.Height = Panel_Main.Height;
            Panel_LeftArea.Height = Panel_Main.Height;

            Panel_RightArea.Width = Math.Min(1040, Panel_Main.Width - Panel_LeftArea.Width);

            Panel_LeftArea.Left = Math.Max(0, (Panel_Main.Width - Panel_RightArea.Width - Panel_LeftArea.Width) / 2);
            Panel_RightArea.Left = Panel_LeftArea.Right;

            //

            int spaceContainerWidth = Panel_ColorSpaces.Width - 2 * Panel_RGB.Left;

            Panel_Transparency_Contents.Width = Panel_Transparency.Width = spaceContainerWidth;
            Panel_RGB_Contents.Width = Panel_RGB.Width = spaceContainerWidth;
            Panel_HSV_Contents.Width = Panel_HSV.Width = spaceContainerWidth;
            Panel_HSL_Contents.Width = Panel_HSL.Width = spaceContainerWidth;
            Panel_CMYK_Contents.Width = Panel_CMYK.Width = spaceContainerWidth;
            Panel_LAB_Contents.Width = Panel_LAB.Width = spaceContainerWidth;
            Panel_YUV_Contents.Width = Panel_YUV.Width = spaceContainerWidth;

            //

            _RepaintEditingColorsShadowImage();
            _RepaintColorSpacesShadowImage();
        }

        private void SizeChangedEvents(object sender, EventArgs e)
        {
            ResizeEvents(sender, e);

            HTrackBar_Opacity.Width = Panel_Transparency.Width - HTrackBar_Opacity.Left - 20;
            HTrackBar_Alpha.Width = HTrackBar_Opacity.Width;

            HTrackBar_RGB_R.Width = Panel_RGB_Contents.Width - HTrackBar_RGB_R.Left - 20;
            HTrackBar_RGB_G.Width = HTrackBar_RGB_R.Width;
            HTrackBar_RGB_B.Width = HTrackBar_RGB_R.Width;

            HTrackBar_HSV_H.Width = Panel_HSV_Contents.Width - HTrackBar_HSV_H.Left - 20;
            HTrackBar_HSV_S.Width = HTrackBar_HSV_H.Width;
            HTrackBar_HSV_V.Width = HTrackBar_HSV_H.Width;

            HTrackBar_HSL_H.Width = Panel_HSL_Contents.Width - HTrackBar_HSL_H.Left - 20;
            HTrackBar_HSL_S.Width = HTrackBar_HSL_H.Width;
            HTrackBar_HSL_L.Width = HTrackBar_HSL_H.Width;

            HTrackBar_CMYK_C.Width = Panel_CMYK_Contents.Width - HTrackBar_CMYK_C.Left - 20;
            HTrackBar_CMYK_M.Width = HTrackBar_CMYK_C.Width;
            HTrackBar_CMYK_Y.Width = HTrackBar_CMYK_C.Width;
            HTrackBar_CMYK_K.Width = HTrackBar_CMYK_C.Width;

            HTrackBar_LAB_L.Width = Panel_LAB_Contents.Width - HTrackBar_LAB_L.Left - 20;
            HTrackBar_LAB_A.Width = HTrackBar_LAB_L.Width;
            HTrackBar_LAB_B.Width = HTrackBar_LAB_L.Width;

            HTrackBar_YUV_Y.Width = Panel_YUV_Contents.Width - HTrackBar_YUV_Y.Left - 20;
            HTrackBar_YUV_U.Width = HTrackBar_YUV_Y.Width;
            HTrackBar_YUV_V.Width = HTrackBar_YUV_Y.Width;
        }

        private void ThemeColorChangedEvents(object sender, EventArgs e)
        {
            Panel_Main.BackColor = Me.RecommendColors.Background_DEC.ToColor();

            //

            Color folderBackColor = Me.RecommendColors.Background.ToColor();

            Panel_Info_Contents.BackColor = folderBackColor;
            Panel_Colors_Contents.BackColor = folderBackColor;
            Panel_Blend_Contents.BackColor = folderBackColor;
            Panel_View_Contents.BackColor = folderBackColor;
            Panel_Appearance_Contents.BackColor = folderBackColor;

            Panel_Transparency_Contents.BackColor = folderBackColor;
            Panel_RGB_Contents.BackColor = folderBackColor;
            Panel_HSV_Contents.BackColor = folderBackColor;
            Panel_HSL_Contents.BackColor = folderBackColor;
            Panel_CMYK_Contents.BackColor = folderBackColor;
            Panel_LAB_Contents.BackColor = folderBackColor;
            Panel_YUV_Contents.BackColor = folderBackColor;

            Color folderButtonForeColor = Me.RecommendColors.Text_INC.ToColor();

            Button_Info.ForeColor = folderButtonForeColor;
            Button_Colors.ForeColor = folderButtonForeColor;
            Button_Blend.ForeColor = folderButtonForeColor;
            Button_View.ForeColor = folderButtonForeColor;
            Button_Appearance.ForeColor = folderButtonForeColor;

            Button_Transparency.ForeColor = folderButtonForeColor;
            Button_RGB.ForeColor = folderButtonForeColor;
            Button_HSV.ForeColor = folderButtonForeColor;
            Button_HSL.ForeColor = folderButtonForeColor;
            Button_CMYK.ForeColor = folderButtonForeColor;
            Button_LAB.ForeColor = folderButtonForeColor;
            Button_YUV.ForeColor = folderButtonForeColor;

            Color folderButtonBackColor = Me.RecommendColors.Button.ToColor();

            Button_Info.BackColor = folderButtonBackColor;
            Button_Colors.BackColor = folderButtonBackColor;
            Button_Blend.BackColor = folderButtonBackColor;
            Button_View.BackColor = folderButtonBackColor;
            Button_Appearance.BackColor = folderButtonBackColor;

            Button_Transparency.BackColor = folderButtonBackColor;
            Button_RGB.BackColor = folderButtonBackColor;
            Button_HSV.BackColor = folderButtonBackColor;
            Button_HSL.BackColor = folderButtonBackColor;
            Button_CMYK.BackColor = folderButtonBackColor;
            Button_LAB.BackColor = folderButtonBackColor;
            Button_YUV.BackColor = folderButtonBackColor;

            Color folderButtonBorderColor = Me.RecommendColors.Button.ToColor();

            Button_Info.FlatAppearance.BorderColor = folderButtonBorderColor;
            Button_Colors.FlatAppearance.BorderColor = folderButtonBorderColor;
            Button_Blend.FlatAppearance.BorderColor = folderButtonBorderColor;
            Button_View.FlatAppearance.BorderColor = folderButtonBorderColor;
            Button_Appearance.FlatAppearance.BorderColor = folderButtonBorderColor;

            Button_Transparency.FlatAppearance.BorderColor = folderButtonBorderColor;
            Button_RGB.FlatAppearance.BorderColor = folderButtonBorderColor;
            Button_HSV.FlatAppearance.BorderColor = folderButtonBorderColor;
            Button_HSL.FlatAppearance.BorderColor = folderButtonBorderColor;
            Button_CMYK.FlatAppearance.BorderColor = folderButtonBorderColor;
            Button_LAB.FlatAppearance.BorderColor = folderButtonBorderColor;
            Button_YUV.FlatAppearance.BorderColor = folderButtonBorderColor;

            Color folderButtonMouseOverBackColor = Me.RecommendColors.Button_DEC.ToColor();

            Button_Info.FlatAppearance.MouseOverBackColor = folderButtonMouseOverBackColor;
            Button_Colors.FlatAppearance.MouseOverBackColor = folderButtonMouseOverBackColor;
            Button_Blend.FlatAppearance.MouseOverBackColor = folderButtonMouseOverBackColor;
            Button_View.FlatAppearance.MouseOverBackColor = folderButtonMouseOverBackColor;
            Button_Appearance.FlatAppearance.MouseOverBackColor = folderButtonMouseOverBackColor;

            Button_Transparency.FlatAppearance.MouseOverBackColor = folderButtonMouseOverBackColor;
            Button_RGB.FlatAppearance.MouseOverBackColor = folderButtonMouseOverBackColor;
            Button_HSV.FlatAppearance.MouseOverBackColor = folderButtonMouseOverBackColor;
            Button_HSL.FlatAppearance.MouseOverBackColor = folderButtonMouseOverBackColor;
            Button_CMYK.FlatAppearance.MouseOverBackColor = folderButtonMouseOverBackColor;
            Button_LAB.FlatAppearance.MouseOverBackColor = folderButtonMouseOverBackColor;
            Button_YUV.FlatAppearance.MouseOverBackColor = folderButtonMouseOverBackColor;

            Color folderButtonMouseDownBackColor = Me.RecommendColors.Button.ToColor();

            Button_Info.FlatAppearance.MouseDownBackColor = folderButtonMouseDownBackColor;
            Button_Colors.FlatAppearance.MouseDownBackColor = folderButtonMouseDownBackColor;
            Button_Blend.FlatAppearance.MouseDownBackColor = folderButtonMouseDownBackColor;
            Button_View.FlatAppearance.MouseDownBackColor = folderButtonMouseDownBackColor;
            Button_Appearance.FlatAppearance.MouseDownBackColor = folderButtonMouseDownBackColor;

            Button_Transparency.FlatAppearance.MouseDownBackColor = folderButtonMouseDownBackColor;
            Button_RGB.FlatAppearance.MouseDownBackColor = folderButtonMouseDownBackColor;
            Button_HSV.FlatAppearance.MouseDownBackColor = folderButtonMouseDownBackColor;
            Button_HSL.FlatAppearance.MouseDownBackColor = folderButtonMouseDownBackColor;
            Button_CMYK.FlatAppearance.MouseDownBackColor = folderButtonMouseDownBackColor;
            Button_LAB.FlatAppearance.MouseDownBackColor = folderButtonMouseDownBackColor;
            Button_YUV.FlatAppearance.MouseDownBackColor = folderButtonMouseDownBackColor;

            //

            Label_Name.ForeColor = Me.RecommendColors.Text_DEC.ToColor();
            Label_Type.ForeColor = Me.RecommendColors.Text_DEC.ToColor();
            Label_Grayscale.ForeColor = Me.RecommendColors.Text_DEC.ToColor();
            Label_Complementary.ForeColor = Me.RecommendColors.Text_DEC.ToColor();
            Label_Invert.ForeColor = Me.RecommendColors.Text_DEC.ToColor();

            Label_Name_Val.ForeColor = Me.RecommendColors.Text.ToColor();
            Label_Type_Val.ForeColor = Me.RecommendColors.Text.ToColor();
            Label_Grayscale_Val2.ForeColor = Me.RecommendColors.Text.ToColor();

            //

            Label_Colors_Builtin.ForeColor = Me.RecommendColors.Text_DEC.ToColor();
            Label_Colors_Customize.ForeColor = Me.RecommendColors.Text_DEC.ToColor();

            //

            Label_BlendColor1.ForeColor = Me.RecommendColors.Text_DEC.ToColor();
            Label_BlendColor2.ForeColor = Me.RecommendColors.Text_DEC.ToColor();
            Label_BlendResult.ForeColor = Me.RecommendColors.Text_DEC.ToColor();
            Label_BlendColor1Proportion.ForeColor = Me.RecommendColors.Text_DEC.ToColor();

            Label_BlendResultRGB.ForeColor = Me.RecommendColors.Text.ToColor();
            Label_BlendResultHSV.ForeColor = Me.RecommendColors.Text.ToColor();
            Label_BlendResultHSL.ForeColor = Me.RecommendColors.Text.ToColor();
            Label_BlendResultCMYK.ForeColor = Me.RecommendColors.Text.ToColor();
            Label_BlendResultLAB.ForeColor = Me.RecommendColors.Text.ToColor();
            Label_BlendResultYUV.ForeColor = Me.RecommendColors.Text.ToColor();

            NumEditor_Blend.ForeColor = Me.RecommendColors.Text.ToColor();
            NumEditor_Blend.BackColor = Me.RecommendColors.Background_DEC.ToColor();
            NumEditor_Blend.BorderColor = Me.RecommendColors.Border.ToColor();

            HTrackBar_Blend.Refresh();

            //

            Label_Background.ForeColor = Me.RecommendColors.Text_DEC.ToColor();
            Label_Label.ForeColor = Me.RecommendColors.Text_DEC.ToColor();
            Label_Border.ForeColor = Me.RecommendColors.Text_DEC.ToColor();
            Label_Text.ForeColor = Me.RecommendColors.Text_DEC.ToColor();

            //

            Label_Theme.ForeColor = Me.RecommendColors.Text_DEC.ToColor();
            Label_ThemeColor.ForeColor = Me.RecommendColors.Text_DEC.ToColor();

            ComboBox_Theme.ForeColor = Me.RecommendColors.MenuItemText.ToColor();
            ComboBox_Theme.BackColor = Me.RecommendColors.MenuItemBackground.ToColor();

            RadioButton_ThemeColor_Customize.ForeColor = Me.RecommendColors.Text.ToColor();
            RadioButton_ThemeColor_EditingColor.ForeColor = Me.RecommendColors.Text.ToColor();
            RadioButton_ThemeColor_Windows.ForeColor = Me.RecommendColors.Text.ToColor();

            //

            Label_AppName.ForeColor = Me.RecommendColors.Text_DEC.ToColor();
            Label_AppVersion.ForeColor = Me.RecommendColors.Text.ToColor();
            Label_Copyright.ForeColor = Me.RecommendColors.Text.ToColor();
            Label_GitHub_Part1.ForeColor = Label_GitHub_Base.ForeColor = Label_GitHub_Part2.ForeColor = Label_GitHub_Release.ForeColor = Me.RecommendColors.Text.ToColor();

            ControlSubstitution.LabelAsButton(Label_GitHub_Base, Label_GitHub_Base_Click, Color.Transparent, Me.RecommendColors.Button_DEC.ToColor(), Me.RecommendColors.Button_INC.ToColor(), new Font("微软雅黑", 9.75F, FontStyle.Underline, GraphicsUnit.Point, 134), new Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 134), new Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 134));
            ControlSubstitution.LabelAsButton(Label_GitHub_Release, Label_GitHub_Release_Click, Color.Transparent, Me.RecommendColors.Button_DEC.ToColor(), Me.RecommendColors.Button_INC.ToColor(), new Font("微软雅黑", 9.75F, FontStyle.Underline, GraphicsUnit.Point, 134), new Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 134), new Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 134));

            //

            Color channelAbbrForeColor = Me.RecommendColors.Text_DEC.ToColor();

            Label_Abbr_Opacity.ForeColor = channelAbbrForeColor;
            Label_Abbr_Alpha.ForeColor = channelAbbrForeColor;
            Label_Abbr_RGB_R.ForeColor = channelAbbrForeColor;
            Label_Abbr_RGB_G.ForeColor = channelAbbrForeColor;
            Label_Abbr_RGB_B.ForeColor = channelAbbrForeColor;
            Label_Abbr_HSV_H.ForeColor = channelAbbrForeColor;
            Label_Abbr_HSV_S.ForeColor = channelAbbrForeColor;
            Label_Abbr_HSV_V.ForeColor = channelAbbrForeColor;
            Label_Abbr_HSL_H.ForeColor = channelAbbrForeColor;
            Label_Abbr_HSL_S.ForeColor = channelAbbrForeColor;
            Label_Abbr_HSL_L.ForeColor = channelAbbrForeColor;
            Label_Abbr_CMYK_C.ForeColor = channelAbbrForeColor;
            Label_Abbr_CMYK_M.ForeColor = channelAbbrForeColor;
            Label_Abbr_CMYK_Y.ForeColor = channelAbbrForeColor;
            Label_Abbr_CMYK_K.ForeColor = channelAbbrForeColor;
            Label_Abbr_LAB_L.ForeColor = channelAbbrForeColor;
            Label_Abbr_LAB_A.ForeColor = channelAbbrForeColor;
            Label_Abbr_LAB_B.ForeColor = channelAbbrForeColor;
            Label_Abbr_YUV_Y.ForeColor = channelAbbrForeColor;
            Label_Abbr_YUV_U.ForeColor = channelAbbrForeColor;
            Label_Abbr_YUV_V.ForeColor = channelAbbrForeColor;

            Color channelForeColor = Me.RecommendColors.Text.ToColor();

            Label_Opacity.ForeColor = channelForeColor;
            Label_Alpha.ForeColor = channelForeColor;
            Label_RGB_R.ForeColor = channelForeColor;
            Label_RGB_G.ForeColor = channelForeColor;
            Label_RGB_B.ForeColor = channelForeColor;
            Label_HSV_H.ForeColor = channelForeColor;
            Label_HSV_S.ForeColor = channelForeColor;
            Label_HSV_V.ForeColor = channelForeColor;
            Label_HSL_H.ForeColor = channelForeColor;
            Label_HSL_S.ForeColor = channelForeColor;
            Label_HSL_L.ForeColor = channelForeColor;
            Label_CMYK_C.ForeColor = channelForeColor;
            Label_CMYK_M.ForeColor = channelForeColor;
            Label_CMYK_Y.ForeColor = channelForeColor;
            Label_CMYK_K.ForeColor = channelForeColor;
            Label_LAB_L.ForeColor = channelForeColor;
            Label_LAB_A.ForeColor = channelForeColor;
            Label_LAB_B.ForeColor = channelForeColor;
            Label_YUV_Y.ForeColor = channelForeColor;
            Label_YUV_U.ForeColor = channelForeColor;
            Label_YUV_V.ForeColor = channelForeColor;

            //

            Color numEditorForeColor = Me.RecommendColors.Text.ToColor();

            NumEditor_Opacity.ForeColor = numEditorForeColor;
            NumEditor_Alpha.ForeColor = numEditorForeColor;
            NumEditor_RGB_R.ForeColor = numEditorForeColor;
            NumEditor_RGB_G.ForeColor = numEditorForeColor;
            NumEditor_RGB_B.ForeColor = numEditorForeColor;
            NumEditor_HSV_H.ForeColor = numEditorForeColor;
            NumEditor_HSV_S.ForeColor = numEditorForeColor;
            NumEditor_HSV_V.ForeColor = numEditorForeColor;
            NumEditor_HSL_H.ForeColor = numEditorForeColor;
            NumEditor_HSL_S.ForeColor = numEditorForeColor;
            NumEditor_HSL_L.ForeColor = numEditorForeColor;
            NumEditor_CMYK_C.ForeColor = numEditorForeColor;
            NumEditor_CMYK_M.ForeColor = numEditorForeColor;
            NumEditor_CMYK_Y.ForeColor = numEditorForeColor;
            NumEditor_CMYK_K.ForeColor = numEditorForeColor;
            NumEditor_LAB_L.ForeColor = numEditorForeColor;
            NumEditor_LAB_A.ForeColor = numEditorForeColor;
            NumEditor_LAB_B.ForeColor = numEditorForeColor;
            NumEditor_YUV_Y.ForeColor = numEditorForeColor;
            NumEditor_YUV_U.ForeColor = numEditorForeColor;
            NumEditor_YUV_V.ForeColor = numEditorForeColor;

            Color numEditorBackColor = Me.RecommendColors.Background_DEC.ToColor();

            NumEditor_Opacity.BackColor = numEditorBackColor;
            NumEditor_Alpha.BackColor = numEditorBackColor;
            NumEditor_RGB_R.BackColor = numEditorBackColor;
            NumEditor_RGB_G.BackColor = numEditorBackColor;
            NumEditor_RGB_B.BackColor = numEditorBackColor;
            NumEditor_HSV_H.BackColor = numEditorBackColor;
            NumEditor_HSV_S.BackColor = numEditorBackColor;
            NumEditor_HSV_V.BackColor = numEditorBackColor;
            NumEditor_HSL_H.BackColor = numEditorBackColor;
            NumEditor_HSL_S.BackColor = numEditorBackColor;
            NumEditor_HSL_L.BackColor = numEditorBackColor;
            NumEditor_CMYK_C.BackColor = numEditorBackColor;
            NumEditor_CMYK_M.BackColor = numEditorBackColor;
            NumEditor_CMYK_Y.BackColor = numEditorBackColor;
            NumEditor_CMYK_K.BackColor = numEditorBackColor;
            NumEditor_LAB_L.BackColor = numEditorBackColor;
            NumEditor_LAB_A.BackColor = numEditorBackColor;
            NumEditor_LAB_B.BackColor = numEditorBackColor;
            NumEditor_YUV_Y.BackColor = numEditorBackColor;
            NumEditor_YUV_U.BackColor = numEditorBackColor;
            NumEditor_YUV_V.BackColor = numEditorBackColor;

            Color numEditorBorderColor = Me.RecommendColors.Border.ToColor();

            NumEditor_Opacity.BorderColor = numEditorBorderColor;
            NumEditor_Alpha.BorderColor = numEditorBorderColor;
            NumEditor_RGB_R.BorderColor = numEditorBorderColor;
            NumEditor_RGB_G.BorderColor = numEditorBorderColor;
            NumEditor_RGB_B.BorderColor = numEditorBorderColor;
            NumEditor_HSV_H.BorderColor = numEditorBorderColor;
            NumEditor_HSV_S.BorderColor = numEditorBorderColor;
            NumEditor_HSV_V.BorderColor = numEditorBorderColor;
            NumEditor_HSL_H.BorderColor = numEditorBorderColor;
            NumEditor_HSL_S.BorderColor = numEditorBorderColor;
            NumEditor_HSL_L.BorderColor = numEditorBorderColor;
            NumEditor_CMYK_C.BorderColor = numEditorBorderColor;
            NumEditor_CMYK_M.BorderColor = numEditorBorderColor;
            NumEditor_CMYK_Y.BorderColor = numEditorBorderColor;
            NumEditor_CMYK_K.BorderColor = numEditorBorderColor;
            NumEditor_LAB_L.BorderColor = numEditorBorderColor;
            NumEditor_LAB_A.BorderColor = numEditorBorderColor;
            NumEditor_LAB_B.BorderColor = numEditorBorderColor;
            NumEditor_YUV_Y.BorderColor = numEditorBorderColor;
            NumEditor_YUV_U.BorderColor = numEditorBorderColor;
            NumEditor_YUV_V.BorderColor = numEditorBorderColor;

            //

            HTrackBar_Opacity.Refresh();
            HTrackBar_Alpha.Refresh();
            HTrackBar_RGB_R.Refresh();
            HTrackBar_RGB_G.Refresh();
            HTrackBar_RGB_B.Refresh();
            HTrackBar_HSV_H.Refresh();
            HTrackBar_HSV_S.Refresh();
            HTrackBar_HSV_V.Refresh();
            HTrackBar_HSL_H.Refresh();
            HTrackBar_HSL_S.Refresh();
            HTrackBar_HSL_L.Refresh();
            HTrackBar_CMYK_C.Refresh();
            HTrackBar_CMYK_M.Refresh();
            HTrackBar_CMYK_Y.Refresh();
            HTrackBar_CMYK_K.Refresh();
            HTrackBar_LAB_L.Refresh();
            HTrackBar_LAB_A.Refresh();
            HTrackBar_LAB_B.Refresh();
            HTrackBar_YUV_Y.Refresh();
            HTrackBar_YUV_U.Refresh();
            HTrackBar_YUV_V.Refresh();

            //

            _RepaintInfoImage();
            _RepaintBuiltinColorsImage();
            _RepaintCustomizeColorsImage();
            _RepaintViewImage();
            _RepaintDivLabelsImage();
            _RepaintBlendLabelsImage();
            _RepaintBlendResultsImage();
            _RepaintAppearanceImage();

            _RepaintEditingColorsShadowImage();
            _RepaintColorSpacesShadowImage();
        }

        #endregion

        #region 通用功能

        // 获取或设置已选择的颜色
        private ColorX CurrentColor
        {
            get
            {
                if (_ColorTag >= _ColorTags.BuiltinFirst && _ColorTag <= _ColorTags.BuiltinLast)
                {
                    return _BuiltinColors[_ColorTag - _ColorTags.BuiltinFirst];
                }
                else if (_ColorTag >= _ColorTags.CustomizeFirst && _ColorTag <= _ColorTags.CustomizeLast)
                {
                    return _CustomizeColors[_ColorTag - _ColorTags.CustomizeFirst];
                }
                else if (_ColorTag >= _ColorTags.BlendColor1 && _ColorTag <= _ColorTags.BlendColor2)
                {
                    switch (_ColorTag)
                    {
                        case _ColorTags.BlendColor1: return _BlendColor1;
                        case _ColorTags.BlendColor2: return _BlendColor2;
                    }
                }
                else if (_ColorTag >= _ColorTags.Background && _ColorTag <= _ColorTags.Text)
                {
                    switch (_ColorTag)
                    {
                        case _ColorTags.Background: return _BackgroundColor;
                        case _ColorTags.Label: return _LabelColor;
                        case _ColorTags.Border: return _BorderColor;
                        case _ColorTags.Text: return _TextColor;
                    }
                }
                else if (_ColorTag == _ColorTags.ThemeColor)
                {
                    return _ThemeColor;
                }

                return ColorX.Empty;
            }

            set
            {
                if (_ColorTag >= _ColorTags.BuiltinFirst && _ColorTag <= _ColorTags.BuiltinLast)
                {
                    _BuiltinColors[_ColorTag - _ColorTags.BuiltinFirst] = value;
                }
                else if (_ColorTag >= _ColorTags.CustomizeFirst && _ColorTag <= _ColorTags.CustomizeLast)
                {
                    _CustomizeColors[_ColorTag - _ColorTags.CustomizeFirst] = value;
                }
                else if (_ColorTag >= _ColorTags.BlendColor1 && _ColorTag <= _ColorTags.BlendColor2)
                {
                    switch (_ColorTag)
                    {
                        case _ColorTags.BlendColor1: _BlendColor1 = value; break;
                        case _ColorTags.BlendColor2: _BlendColor2 = value; break;
                    }
                }
                else if (_ColorTag >= _ColorTags.Background && _ColorTag <= _ColorTags.Text)
                {
                    switch (_ColorTag)
                    {
                        case _ColorTags.Background: _BackgroundColor = value; break;
                        case _ColorTags.Label: _LabelColor = value; break;
                        case _ColorTags.Border: _BorderColor = value; break;
                        case _ColorTags.Text: _TextColor = value; break;
                    }
                }
                else if (_ColorTag == _ColorTags.ThemeColor)
                {
                    _ThemeColor = value;
                }

                if (RadioButton_ThemeColor_EditingColor.Checked || (RadioButton_ThemeColor_Customize.Checked && _ColorTag == _ColorTags.ThemeColor))
                {
                    Me.ThemeColor = value.AtAlpha(255);
                }

                _RepaintInfoImage();

                if (_ColorTag >= _ColorTags.BuiltinFirst && _ColorTag <= _ColorTags.BuiltinLast)
                {
                    _RepaintBuiltinColorsImage();
                }
                else if (_ColorTag >= _ColorTags.CustomizeFirst && _ColorTag <= _ColorTags.CustomizeLast)
                {
                    _RepaintCustomizeColorsImage();
                }
                else if (_ColorTag >= _ColorTags.BlendColor1 && _ColorTag <= _ColorTags.BlendColor2)
                {
                    _RepaintBlendLabelsImage();
                    _RepaintBlendResultsImage();

                    //

                    if (_ColorTag == _ColorTags.BlendColor1)
                    {
                        HTrackBar_Blend.Colors = new Color[] { Color.Transparent, _BlendColor1.ToColor() };
                    }
                }
                else if (_ColorTag >= _ColorTags.Background && _ColorTag <= _ColorTags.Text)
                {
                    _RepaintDivImage();
                    _RepaintDivLabelsImage();
                }
                else if (_ColorTag == _ColorTags.ThemeColor)
                {
                    _RepaintAppearanceImage();
                }

                //

                UpdateTrackBarAndNumEditor(value);
            }
        }

        // 选择指定的颜色
        private void ChoseColor(_ColorTags colorTag)
        {
            if (_ColorTag != colorTag && (!(colorTag >= _ColorTags.Grayscale && colorTag <= _ColorTags.Invert)))
            {
                _ColorTag = colorTag;

                //

                ColorX currentColor = CurrentColor;

                if (RadioButton_ThemeColor_EditingColor.Checked)
                {
                    Me.ThemeColor = currentColor.AtAlpha(255);
                }

                _RepaintInfoImage();

                //

                UpdateTrackBarAndNumEditor(currentColor);
            }
        }

        // 获取指定的颜色
        private ColorX GetColor(_ColorTags colorTag)
        {
            if (colorTag >= _ColorTags.Grayscale && colorTag <= _ColorTags.Invert)
            {
                switch (colorTag)
                {
                    case _ColorTags.Grayscale: return CurrentColor.Grayscale;
                    case _ColorTags.Complementary: return CurrentColor.Complementary;
                    case _ColorTags.Invert: return CurrentColor.Invert;
                }
            }
            else if (colorTag >= _ColorTags.BuiltinFirst && colorTag <= _ColorTags.BuiltinLast)
            {
                return _BuiltinColors[colorTag - _ColorTags.BuiltinFirst];
            }
            else if (colorTag >= _ColorTags.CustomizeFirst && colorTag <= _ColorTags.CustomizeLast)
            {
                return _CustomizeColors[colorTag - _ColorTags.CustomizeFirst];
            }
            else if (colorTag >= _ColorTags.BlendColor1 && colorTag <= _ColorTags.BlendColor2)
            {
                switch (colorTag)
                {
                    case _ColorTags.BlendColor1: return _BlendColor1;
                    case _ColorTags.BlendColor2: return _BlendColor2;
                }
            }
            else if (colorTag >= _ColorTags.BlendResultRGB && colorTag <= _ColorTags.BlendResultYUV)
            {
                switch (colorTag)
                {
                    case _ColorTags.BlendResultRGB: return ColorManipulation.BlendByRGB(_BlendColor1, _BlendColor2, NumEditor_Blend.Value * 0.01);
                    case _ColorTags.BlendResultHSV: return ColorManipulation.BlendByHSV(_BlendColor1, _BlendColor2, NumEditor_Blend.Value * 0.01);
                    case _ColorTags.BlendResultHSL: return ColorManipulation.BlendByHSL(_BlendColor1, _BlendColor2, NumEditor_Blend.Value * 0.01);
                    case _ColorTags.BlendResultCMYK: return ColorManipulation.BlendByCMYK(_BlendColor1, _BlendColor2, NumEditor_Blend.Value * 0.01);
                    case _ColorTags.BlendResultLAB: return ColorManipulation.BlendByLAB(_BlendColor1, _BlendColor2, NumEditor_Blend.Value * 0.01);
                    case _ColorTags.BlendResultYUV: return ColorManipulation.BlendByYUV(_BlendColor1, _BlendColor2, NumEditor_Blend.Value * 0.01);
                }
            }
            else if (colorTag >= _ColorTags.Background && colorTag <= _ColorTags.Text)
            {
                switch (colorTag)
                {
                    case _ColorTags.Background: return _BackgroundColor;
                    case _ColorTags.Label: return _LabelColor;
                    case _ColorTags.Border: return _BorderColor;
                    case _ColorTags.Text: return _TextColor;
                }
            }
            else if (colorTag == _ColorTags.ThemeColor)
            {
                return _ThemeColor;
            }

            return ColorX.Empty;
        }

        // 设置指定的颜色
        private void SetColor(_ColorTags colorTag, ColorX color)
        {
            if (colorTag == _ColorTag)
            {
                CurrentColor = color;
            }
            else
            {
                if (colorTag >= _ColorTags.BuiltinFirst && colorTag <= _ColorTags.BuiltinLast)
                {
                    _BuiltinColors[colorTag - _ColorTags.BuiltinFirst] = color;

                    //

                    _RepaintBuiltinColorsImage();
                }
                else if (colorTag >= _ColorTags.CustomizeFirst && colorTag <= _ColorTags.CustomizeLast)
                {
                    _CustomizeColors[colorTag - _ColorTags.CustomizeFirst] = color;

                    //

                    _RepaintCustomizeColorsImage();
                }
                else if (colorTag >= _ColorTags.BlendColor1 && colorTag <= _ColorTags.BlendColor2)
                {
                    switch (colorTag)
                    {
                        case _ColorTags.BlendColor1: _BlendColor1 = color; break;
                        case _ColorTags.BlendColor2: _BlendColor2 = color; break;
                    }

                    //

                    _RepaintBlendLabelsImage();
                    _RepaintBlendResultsImage();

                    //

                    if (colorTag == _ColorTags.BlendColor1)
                    {
                        HTrackBar_Blend.Colors = new Color[] { Color.Transparent, _BlendColor1.ToColor() };
                    }
                }
                else if (colorTag >= _ColorTags.Background && colorTag <= _ColorTags.Text)
                {
                    switch (colorTag)
                    {
                        case _ColorTags.Background: _BackgroundColor = color; break;
                        case _ColorTags.Label: _LabelColor = color; break;
                        case _ColorTags.Border: _BorderColor = color; break;
                        case _ColorTags.Text: _TextColor = color; break;
                    }

                    //

                    _RepaintDivImage();
                    _RepaintDivLabelsImage();
                }
                else if (colorTag == _ColorTags.ThemeColor)
                {
                    _ThemeColor = color;

                    if (RadioButton_ThemeColor_Customize.Checked)
                    {
                        Me.ThemeColor = color;
                    }

                    _RepaintAppearanceImage();
                }
            }
        }

        #endregion

        #region 颜色编辑

        // 注册 HTrackBar、NumEditor 事件
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

            //

            NumEditor_Opacity.ValueChanged += NumEditor_ValueChanged;
            NumEditor_Alpha.ValueChanged += NumEditor_ValueChanged;
            NumEditor_RGB_R.ValueChanged += NumEditor_ValueChanged;
            NumEditor_RGB_G.ValueChanged += NumEditor_ValueChanged;
            NumEditor_RGB_B.ValueChanged += NumEditor_ValueChanged;
            NumEditor_HSV_H.ValueChanged += NumEditor_ValueChanged;
            NumEditor_HSV_S.ValueChanged += NumEditor_ValueChanged;
            NumEditor_HSV_V.ValueChanged += NumEditor_ValueChanged;
            NumEditor_HSL_H.ValueChanged += NumEditor_ValueChanged;
            NumEditor_HSL_S.ValueChanged += NumEditor_ValueChanged;
            NumEditor_HSL_L.ValueChanged += NumEditor_ValueChanged;
            NumEditor_CMYK_C.ValueChanged += NumEditor_ValueChanged;
            NumEditor_CMYK_M.ValueChanged += NumEditor_ValueChanged;
            NumEditor_CMYK_Y.ValueChanged += NumEditor_ValueChanged;
            NumEditor_CMYK_K.ValueChanged += NumEditor_ValueChanged;
            NumEditor_LAB_L.ValueChanged += NumEditor_ValueChanged;
            NumEditor_LAB_A.ValueChanged += NumEditor_ValueChanged;
            NumEditor_LAB_B.ValueChanged += NumEditor_ValueChanged;
            NumEditor_YUV_Y.ValueChanged += NumEditor_ValueChanged;
            NumEditor_YUV_U.ValueChanged += NumEditor_ValueChanged;
            NumEditor_YUV_V.ValueChanged += NumEditor_ValueChanged;
        }

        // 取消注册 HTrackBar、NumEditor 事件
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

            //

            NumEditor_Opacity.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_Alpha.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_RGB_R.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_RGB_G.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_RGB_B.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_HSV_H.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_HSV_S.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_HSV_V.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_HSL_H.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_HSL_S.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_HSL_L.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_CMYK_C.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_CMYK_M.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_CMYK_Y.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_CMYK_K.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_LAB_L.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_LAB_A.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_LAB_B.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_YUV_Y.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_YUV_U.ValueChanged -= NumEditor_ValueChanged;
            NumEditor_YUV_V.ValueChanged -= NumEditor_ValueChanged;
        }

        //

        private Control _CurrentTrackBarOrNumEditor = null;

        // 更新 HTrackBar、NumEditor 的外观与值
        private void UpdateTrackBarAndNumEditor(ColorX color)
        {
            UnregisterEvents();

            //

            Color[] Colors_Opacity = _HTrackBarColorsTable[_HTrackBarColorsKey.Opacity] as Color[];
            Color[] Colors_Alpha = _HTrackBarColorsTable[_HTrackBarColorsKey.Alpha] as Color[];
            Color[] Colors_RGB_R = _HTrackBarColorsTable[_HTrackBarColorsKey.RGB_R] as Color[];
            Color[] Colors_RGB_G = _HTrackBarColorsTable[_HTrackBarColorsKey.RGB_G] as Color[];
            Color[] Colors_RGB_B = _HTrackBarColorsTable[_HTrackBarColorsKey.RGB_B] as Color[];
            Color[] Colors_HSV_H = _HTrackBarColorsTable[_HTrackBarColorsKey.HSV_H] as Color[];
            Color[] Colors_HSV_S = _HTrackBarColorsTable[_HTrackBarColorsKey.HSV_S] as Color[];
            Color[] Colors_HSV_V = _HTrackBarColorsTable[_HTrackBarColorsKey.HSV_V] as Color[];
            Color[] Colors_HSL_H = _HTrackBarColorsTable[_HTrackBarColorsKey.HSL_H] as Color[];
            Color[] Colors_HSL_S = _HTrackBarColorsTable[_HTrackBarColorsKey.HSL_S] as Color[];
            Color[] Colors_HSL_L = _HTrackBarColorsTable[_HTrackBarColorsKey.HSL_L] as Color[];
            Color[] Colors_CMYK_C = _HTrackBarColorsTable[_HTrackBarColorsKey.CMYK_C] as Color[];
            Color[] Colors_CMYK_M = _HTrackBarColorsTable[_HTrackBarColorsKey.CMYK_M] as Color[];
            Color[] Colors_CMYK_Y = _HTrackBarColorsTable[_HTrackBarColorsKey.CMYK_Y] as Color[];
            Color[] Colors_CMYK_K = _HTrackBarColorsTable[_HTrackBarColorsKey.CMYK_K] as Color[];
            Color[] Colors_LAB_L = _HTrackBarColorsTable[_HTrackBarColorsKey.LAB_L] as Color[];
            Color[] Colors_LAB_A = _HTrackBarColorsTable[_HTrackBarColorsKey.LAB_A] as Color[];
            Color[] Colors_LAB_B = _HTrackBarColorsTable[_HTrackBarColorsKey.LAB_B] as Color[];
            Color[] Colors_YUV_Y = _HTrackBarColorsTable[_HTrackBarColorsKey.YUV_Y] as Color[];
            Color[] Colors_YUV_U = _HTrackBarColorsTable[_HTrackBarColorsKey.YUV_U] as Color[];
            Color[] Colors_YUV_V = _HTrackBarColorsTable[_HTrackBarColorsKey.YUV_V] as Color[];

            Colors_Opacity[0] = color.AtOpacity(0).ToColor();
            Colors_Opacity[1] = color.AtOpacity(100).ToColor();
            Colors_Alpha[0] = color.AtAlpha(0).ToColor();
            Colors_Alpha[1] = color.AtAlpha(255).ToColor();

            for (int i = 0; i < _HTrackBarColorsNum; i++)
            {
                double Pct = (double)i / (_HTrackBarColorsNum - 1);

                Colors_RGB_R[i] = color.AtRed(Pct * 255).ToColor();
                Colors_RGB_G[i] = color.AtGreen(Pct * 255).ToColor();
                Colors_RGB_B[i] = color.AtBlue(Pct * 255).ToColor();
                Colors_HSV_H[i] = color.AtHue_HSV(Pct * 360).ToColor();
                Colors_HSV_S[i] = color.AtSaturation_HSV(Pct * 100).ToColor();
                Colors_HSV_V[i] = color.AtBrightness(Pct * 100).ToColor();
                Colors_HSL_H[i] = color.AtHue_HSL(Pct * 360).ToColor();
                Colors_HSL_S[i] = color.AtSaturation_HSL(Pct * 100).ToColor();
                Colors_HSL_L[i] = color.AtLightness_HSL(Pct * 100).ToColor();
                Colors_CMYK_C[i] = color.AtCyan(Pct * 100).ToColor();
                Colors_CMYK_M[i] = color.AtMagenta(Pct * 100).ToColor();
                Colors_CMYK_Y[i] = color.AtYellow(Pct * 100).ToColor();
                Colors_CMYK_K[i] = color.AtBlack(Pct * 100).ToColor();
                Colors_LAB_L[i] = color.AtLightness_LAB(Pct * 100).ToColor();
                Colors_LAB_A[i] = color.AtGreenRed(-128 + Pct * 256).ToColor();
                Colors_LAB_B[i] = color.AtBlueYellow(-128 + Pct * 256).ToColor();
                Colors_YUV_Y[i] = color.AtLuminance(Pct * 1.0).ToColor();
                Colors_YUV_U[i] = color.AtChrominanceBlue(-0.5 + Pct * 1.0).ToColor();
                Colors_YUV_V[i] = color.AtChrominanceRed(-0.5 + Pct * 1.0).ToColor();
            }

            HTrackBar_Opacity.Colors = Colors_Opacity;
            HTrackBar_Alpha.Colors = Colors_Alpha;
            HTrackBar_RGB_R.Colors = Colors_RGB_R;
            HTrackBar_RGB_G.Colors = Colors_RGB_G;
            HTrackBar_RGB_B.Colors = Colors_RGB_B;
            HTrackBar_HSV_H.Colors = Colors_HSV_H;
            HTrackBar_HSV_S.Colors = Colors_HSV_S;
            HTrackBar_HSV_V.Colors = Colors_HSV_V;
            HTrackBar_HSL_H.Colors = Colors_HSL_H;
            HTrackBar_HSL_S.Colors = Colors_HSL_S;
            HTrackBar_HSL_L.Colors = Colors_HSL_L;
            HTrackBar_CMYK_C.Colors = Colors_CMYK_C;
            HTrackBar_CMYK_M.Colors = Colors_CMYK_M;
            HTrackBar_CMYK_Y.Colors = Colors_CMYK_Y;
            HTrackBar_CMYK_K.Colors = Colors_CMYK_K;
            HTrackBar_LAB_L.Colors = Colors_LAB_L;
            HTrackBar_LAB_A.Colors = Colors_LAB_A;
            HTrackBar_LAB_B.Colors = Colors_LAB_B;
            HTrackBar_YUV_Y.Colors = Colors_YUV_Y;
            HTrackBar_YUV_U.Colors = Colors_YUV_U;
            HTrackBar_YUV_V.Colors = Colors_YUV_V;

            if (_CurrentTrackBarOrNumEditor != HTrackBar_Opacity) HTrackBar_Opacity.Value = color.Opacity;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_Alpha) HTrackBar_Alpha.Value = color.Alpha;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_RGB_R) HTrackBar_RGB_R.Value = color.Red;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_RGB_G) HTrackBar_RGB_G.Value = color.Green;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_RGB_B) HTrackBar_RGB_B.Value = color.Blue;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_HSV_H) HTrackBar_HSV_H.Value = color.Hue_HSV;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_HSV_S) HTrackBar_HSV_S.Value = color.Saturation_HSV;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_HSV_V) HTrackBar_HSV_V.Value = color.Brightness;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_HSL_H) HTrackBar_HSL_H.Value = color.Hue_HSL;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_HSL_S) HTrackBar_HSL_S.Value = color.Saturation_HSL;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_HSL_L) HTrackBar_HSL_L.Value = color.Lightness_HSL;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_CMYK_C) HTrackBar_CMYK_C.Value = color.Cyan;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_CMYK_M) HTrackBar_CMYK_M.Value = color.Magenta;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_CMYK_Y) HTrackBar_CMYK_Y.Value = color.Yellow;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_CMYK_K) HTrackBar_CMYK_K.Value = color.Black;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_LAB_L) HTrackBar_LAB_L.Value = color.Lightness_LAB;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_LAB_A) HTrackBar_LAB_A.Value = color.GreenRed;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_LAB_B) HTrackBar_LAB_B.Value = color.BlueYellow;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_YUV_Y) HTrackBar_YUV_Y.Value = color.Luminance;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_YUV_U) HTrackBar_YUV_U.Value = color.ChrominanceBlue;
            if (_CurrentTrackBarOrNumEditor != HTrackBar_YUV_V) HTrackBar_YUV_V.Value = color.ChrominanceRed;

            //

            if (_CurrentTrackBarOrNumEditor != NumEditor_Opacity) NumEditor_Opacity.Value = color.Opacity;
            if (_CurrentTrackBarOrNumEditor != NumEditor_Alpha) NumEditor_Alpha.Value = color.Alpha;
            if (_CurrentTrackBarOrNumEditor != NumEditor_RGB_R) NumEditor_RGB_R.Value = color.Red;
            if (_CurrentTrackBarOrNumEditor != NumEditor_RGB_G) NumEditor_RGB_G.Value = color.Green;
            if (_CurrentTrackBarOrNumEditor != NumEditor_RGB_B) NumEditor_RGB_B.Value = color.Blue;
            if (_CurrentTrackBarOrNumEditor != NumEditor_HSV_H) NumEditor_HSV_H.Value = color.Hue_HSV;
            if (_CurrentTrackBarOrNumEditor != NumEditor_HSV_S) NumEditor_HSV_S.Value = color.Saturation_HSV;
            if (_CurrentTrackBarOrNumEditor != NumEditor_HSV_V) NumEditor_HSV_V.Value = color.Brightness;
            if (_CurrentTrackBarOrNumEditor != NumEditor_HSL_H) NumEditor_HSL_H.Value = color.Hue_HSL;
            if (_CurrentTrackBarOrNumEditor != NumEditor_HSL_S) NumEditor_HSL_S.Value = color.Saturation_HSL;
            if (_CurrentTrackBarOrNumEditor != NumEditor_HSL_L) NumEditor_HSL_L.Value = color.Lightness_HSL;
            if (_CurrentTrackBarOrNumEditor != NumEditor_CMYK_C) NumEditor_CMYK_C.Value = color.Cyan;
            if (_CurrentTrackBarOrNumEditor != NumEditor_CMYK_M) NumEditor_CMYK_M.Value = color.Magenta;
            if (_CurrentTrackBarOrNumEditor != NumEditor_CMYK_Y) NumEditor_CMYK_Y.Value = color.Yellow;
            if (_CurrentTrackBarOrNumEditor != NumEditor_CMYK_K) NumEditor_CMYK_K.Value = color.Black;
            if (_CurrentTrackBarOrNumEditor != NumEditor_LAB_L) NumEditor_LAB_L.Value = color.Lightness_LAB;
            if (_CurrentTrackBarOrNumEditor != NumEditor_LAB_A) NumEditor_LAB_A.Value = color.GreenRed;
            if (_CurrentTrackBarOrNumEditor != NumEditor_LAB_B) NumEditor_LAB_B.Value = color.BlueYellow;
            if (_CurrentTrackBarOrNumEditor != NumEditor_YUV_Y) NumEditor_YUV_Y.Value = color.Luminance;
            if (_CurrentTrackBarOrNumEditor != NumEditor_YUV_U) NumEditor_YUV_U.Value = color.ChrominanceBlue;
            if (_CurrentTrackBarOrNumEditor != NumEditor_YUV_V) NumEditor_YUV_V.Value = color.ChrominanceRed;

            //

            _CurrentTrackBarOrNumEditor = null;

            //

            RegisterEvents();
        }

        //

        private void HTrackBar_ValueChanged(object sender, EventArgs e)
        {
            HTrackBar trackBar = sender as HTrackBar;

            if (trackBar != null)
            {
                _CurrentTrackBarOrNumEditor = trackBar;

                ColorX color = CurrentColor;

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
            }
        }

        private void NumEditor_ValueChanged(object sender, EventArgs e)
        {
            NumEditor numEditor = sender as NumEditor;

            if (numEditor != null)
            {
                _CurrentTrackBarOrNumEditor = numEditor;

                ColorX color = CurrentColor;

                double channel = numEditor.Value;

                if (numEditor == NumEditor_Opacity)
                {
                    color.Opacity = channel;
                }
                else if (numEditor == NumEditor_Alpha)
                {
                    color.Alpha = channel;
                }
                else if (numEditor == NumEditor_RGB_R)
                {
                    color.Red = channel;
                }
                else if (numEditor == NumEditor_RGB_G)
                {
                    color.Green = channel;
                }
                else if (numEditor == NumEditor_RGB_B)
                {
                    color.Blue = channel;
                }
                else if (numEditor == NumEditor_HSV_H)
                {
                    color.Hue_HSV = channel;
                }
                else if (numEditor == NumEditor_HSV_S)
                {
                    color.Saturation_HSV = channel;
                }
                else if (numEditor == NumEditor_HSV_V)
                {
                    color.Brightness = channel;
                }
                else if (numEditor == NumEditor_HSL_H)
                {
                    color.Hue_HSL = channel;
                }
                else if (numEditor == NumEditor_HSL_S)
                {
                    color.Saturation_HSL = channel;
                }
                else if (numEditor == NumEditor_HSL_L)
                {
                    color.Lightness_HSL = channel;
                }
                else if (numEditor == NumEditor_CMYK_C)
                {
                    color.Cyan = channel;
                }
                else if (numEditor == NumEditor_CMYK_M)
                {
                    color.Magenta = channel;
                }
                else if (numEditor == NumEditor_CMYK_Y)
                {
                    color.Yellow = channel;
                }
                else if (numEditor == NumEditor_CMYK_K)
                {
                    color.Black = channel;
                }
                else if (numEditor == NumEditor_LAB_L)
                {
                    color.Lightness_LAB = channel;
                }
                else if (numEditor == NumEditor_LAB_A)
                {
                    color.GreenRed = channel;
                }
                else if (numEditor == NumEditor_LAB_B)
                {
                    color.BlueYellow = channel;
                }
                else if (numEditor == NumEditor_YUV_Y)
                {
                    color.Luminance = channel;
                }
                else if (numEditor == NumEditor_YUV_U)
                {
                    color.ChrominanceBlue = channel;
                }
                else if (numEditor == NumEditor_YUV_V)
                {
                    color.ChrominanceRed = channel;
                }

                CurrentColor = color;
            }
        }

        #endregion

        #region 颜色选择

        private _ColorTags _CopyColorTag = _ColorTags.None;

        // 选择指定的颜色用于复制
        private void CopyColor(_ColorTags colorTag)
        {
            if (colorTag != _ColorTags.None)
            {
                _CopyColorTag = colorTag;
            }
        }

        // 将复制的颜色粘贴到指定的颜色
        private void PasteColor(_ColorTags colorTag)
        {
            if (_CopyColorTag != _ColorTags.None)
            {
                if (_CopyColorTag != colorTag && (!(colorTag >= _ColorTags.Grayscale && colorTag <= _ColorTags.Invert)) && (!(colorTag >= _ColorTags.BuiltinFirst && colorTag <= _ColorTags.BuiltinLast)) && !(colorTag >= _ColorTags.BlendResultRGB && colorTag <= _ColorTags.BlendResultYUV))
                {
                    SetColor(colorTag, GetColor(_CopyColorTag));
                }

                _CopyColorTag = _ColorTags.None;
            }
        }

        //

        // 获取鼠标所在位置的颜色标签
        private _ColorTags GetColorTagOfCursorPosition()
        {
            Point pt = Cursor.Position;

            if (Geometry.ScreenPointIsInControl(pt, Panel_LeftArea))
            {
                if (Button_Appearance.ImageIndex == 1)
                {
                    if (Geometry.ScreenPointIsInControl(pt, Label_ThemeColor_Customize))
                    {
                        return _ColorTags.ThemeColor;
                    }
                }

                if (Button_View.ImageIndex == 1)
                {
                    if (Geometry.ScreenPointIsInControl(pt, Label_Background_Val))
                    {
                        return _ColorTags.Background;
                    }
                    else if (Geometry.ScreenPointIsInControl(pt, Label_Label_Val))
                    {
                        return _ColorTags.Label;
                    }
                    else if (Geometry.ScreenPointIsInControl(pt, Label_Border_Val))
                    {
                        return _ColorTags.Border;
                    }
                    else if (Geometry.ScreenPointIsInControl(pt, Label_Text_Val))
                    {
                        return _ColorTags.Text;
                    }
                }

                if (Button_Blend.ImageIndex == 1)
                {
                    if (Geometry.ScreenPointIsInControl(pt, Label_BlendColor1_Val))
                    {
                        return _ColorTags.BlendColor1;
                    }
                    else if (Geometry.ScreenPointIsInControl(pt, Label_BlendColor2_Val))
                    {
                        return _ColorTags.BlendColor2;
                    }
                    else if (Geometry.ScreenPointIsInControl(pt, Label_BlendResultRGB_Val))
                    {
                        return _ColorTags.BlendResultRGB;
                    }
                    else if (Geometry.ScreenPointIsInControl(pt, Label_BlendResultHSV_Val))
                    {
                        return _ColorTags.BlendResultHSV;
                    }
                    else if (Geometry.ScreenPointIsInControl(pt, Label_BlendResultHSL_Val))
                    {
                        return _ColorTags.BlendResultHSL;
                    }
                    else if (Geometry.ScreenPointIsInControl(pt, Label_BlendResultCMYK_Val))
                    {
                        return _ColorTags.BlendResultCMYK;
                    }
                    else if (Geometry.ScreenPointIsInControl(pt, Label_BlendResultLAB_Val))
                    {
                        return _ColorTags.BlendResultLAB;
                    }
                    else if (Geometry.ScreenPointIsInControl(pt, Label_BlendResultYUV_Val))
                    {
                        return _ColorTags.BlendResultYUV;
                    }
                }

                if (Button_Colors.ImageIndex == 1)
                {
                    for (_ColorTags i = _ColorTags.CustomizeFirst; i <= _ColorTags.CustomizeLast; i++)
                    {
                        if (Geometry.ScreenPointIsInControl(pt, Label_CustomizeColors[i - _ColorTags.CustomizeFirst]))
                        {
                            return i;
                        }
                    }

                    for (_ColorTags i = _ColorTags.BuiltinFirst; i <= _ColorTags.BuiltinLast; i++)
                    {
                        if (Geometry.ScreenPointIsInControl(pt, Label_BuiltinColors[i - _ColorTags.BuiltinFirst]))
                        {
                            return i;
                        }
                    }
                }
            }

            return _ColorTags.None;
        }

        //

        private void Label_Grayscale_Val_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.Grayscale);
            }
        }

        private void Label_Grayscale_Val_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_Background_Val))
                {
                    CurrentColor = GetColor(_ColorTags.Grayscale);
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        private void Label_Complementary_Val_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.Complementary);
            }
        }

        private void Label_Complementary_Val_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_Background_Val))
                {
                    CurrentColor = GetColor(_ColorTags.Complementary);
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        private void Label_Invert_Val_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.Invert);
            }
        }

        private void Label_Invert_Val_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_Background_Val))
                {
                    CurrentColor = GetColor(_ColorTags.Invert);
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        //

        private Label[] Label_BuiltinColors = new Label[0];

        private void Label_BuiltinColors_MouseDown(object sender, MouseEventArgs e)
        {
            Label l = sender as Label;

            if (l != null && e.Button == MouseButtons.Left)
            {
                for (_ColorTags i = _ColorTags.BuiltinFirst; i <= _ColorTags.BuiltinLast; i++)
                {
                    if (object.ReferenceEquals(l, Label_BuiltinColors[i - _ColorTags.BuiltinFirst]))
                    {
                        CopyColor(i);

                        break;
                    }
                }
            }
        }

        private void Label_BuiltinColors_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label l = sender as Label;

                if (l != null)
                {
                    if (Geometry.PointIsInControl(e.Location, l))
                    {
                        for (_ColorTags i = _ColorTags.BuiltinFirst; i <= _ColorTags.BuiltinLast; i++)
                        {
                            if (object.ReferenceEquals(l, Label_BuiltinColors[i - _ColorTags.BuiltinFirst]))
                            {
                                CurrentColor = _BuiltinColors[i - _ColorTags.BuiltinFirst];

                                break;
                            }
                        }
                    }
                    else
                    {
                        PasteColor(GetColorTagOfCursorPosition());
                    }
                }
            }
        }

        //

        private Label[] Label_CustomizeColors = new Label[0];

        private void Label_CustomizeColors_MouseDown(object sender, MouseEventArgs e)
        {
            Label l = sender as Label;

            if (l != null && e.Button == MouseButtons.Left)
            {
                for (_ColorTags i = _ColorTags.CustomizeFirst; i <= _ColorTags.CustomizeLast; i++)
                {
                    if (object.ReferenceEquals(l, Label_CustomizeColors[i - _ColorTags.CustomizeFirst]))
                    {
                        CopyColor(i);

                        break;
                    }
                }
            }
        }

        private void Label_CustomizeColors_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label l = sender as Label;

                if (l != null)
                {
                    if (Geometry.PointIsInControl(e.Location, l))
                    {
                        for (_ColorTags i = _ColorTags.CustomizeFirst; i <= _ColorTags.CustomizeLast; i++)
                        {
                            if (object.ReferenceEquals(l, Label_CustomizeColors[i - _ColorTags.CustomizeFirst]))
                            {
                                ChoseColor(i);

                                _RepaintCustomizeColorsImage();
                                _RepaintDivLabelsImage();
                                _RepaintBlendLabelsImage();
                                _RepaintAppearanceImage();

                                break;
                            }
                        }
                    }
                    else
                    {
                        PasteColor(GetColorTagOfCursorPosition());
                    }
                }
            }
        }

        //

        private void Label_BlendColor1_Val_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.BlendColor1);
            }
        }

        private void Label_BlendColor1_Val_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_BlendColor1_Val))
                {
                    ChoseColor(_ColorTags.BlendColor1);

                    _RepaintCustomizeColorsImage();
                    _RepaintDivLabelsImage();
                    _RepaintBlendLabelsImage();
                    _RepaintAppearanceImage();
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        private void Label_BlendColor2_Val_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.BlendColor2);
            }
        }

        private void Label_BlendColor2_Val_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_BlendColor2_Val))
                {
                    ChoseColor(_ColorTags.BlendColor2);

                    _RepaintCustomizeColorsImage();
                    _RepaintDivLabelsImage();
                    _RepaintBlendLabelsImage();
                    _RepaintAppearanceImage();
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        private void Label_BlendResultRGB_Val_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.BlendResultRGB);
            }
        }

        private void Label_BlendResultRGB_Val_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_BlendResultRGB_Val))
                {
                    CurrentColor = GetColor(_ColorTags.BlendResultRGB);
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        private void Label_BlendResultHSV_Val_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.BlendResultHSV);
            }
        }

        private void Label_BlendResultHSV_Val_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_BlendResultHSV_Val))
                {
                    CurrentColor = GetColor(_ColorTags.BlendResultHSV);
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        private void Label_BlendResultHSL_Val_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.BlendResultHSL);
            }
        }

        private void Label_BlendResultHSL_Val_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_BlendResultHSL_Val))
                {
                    CurrentColor = GetColor(_ColorTags.BlendResultHSL);
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        private void Label_BlendResultCMYK_Val_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.BlendResultCMYK);
            }
        }

        private void Label_BlendResultCMYK_Val_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_BlendResultCMYK_Val))
                {
                    CurrentColor = GetColor(_ColorTags.BlendResultCMYK);
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        private void Label_BlendResultLAB_Val_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.BlendResultLAB);
            }
        }

        private void Label_BlendResultLAB_Val_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_BlendResultLAB_Val))
                {
                    CurrentColor = GetColor(_ColorTags.BlendResultLAB);
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        private void Label_BlendResultYUV_Val_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.BlendResultYUV);
            }
        }

        private void Label_BlendResultYUV_Val_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_BlendResultYUV_Val))
                {
                    CurrentColor = GetColor(_ColorTags.BlendResultYUV);
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        //

        private void Label_Background_Val_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.Background);
            }
        }

        private void Label_Background_Val_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_Background_Val))
                {
                    ChoseColor(_ColorTags.Background);

                    _RepaintCustomizeColorsImage();
                    _RepaintDivLabelsImage();
                    _RepaintBlendLabelsImage();
                    _RepaintAppearanceImage();
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        private void Label_Label_Val_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.Label);
            }
        }

        private void Label_Label_Val_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_Label_Val))
                {
                    ChoseColor(_ColorTags.Label);

                    _RepaintCustomizeColorsImage();
                    _RepaintDivLabelsImage();
                    _RepaintBlendLabelsImage();
                    _RepaintAppearanceImage();
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        private void Label_Border_Val_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.Border);
            }
        }

        private void Label_Border_Val_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_Border_Val))
                {
                    ChoseColor(_ColorTags.Border);

                    _RepaintCustomizeColorsImage();
                    _RepaintDivLabelsImage();
                    _RepaintBlendLabelsImage();
                    _RepaintAppearanceImage();
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        private void Label_Text_Val_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.Text);
            }
        }

        private void Label_Text_Val_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_Text_Val))
                {
                    ChoseColor(_ColorTags.Text);

                    _RepaintCustomizeColorsImage();
                    _RepaintDivLabelsImage();
                    _RepaintBlendLabelsImage();
                    _RepaintAppearanceImage();
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        //

        private void Label_ThemeColor_Customize_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CopyColor(_ColorTags.ThemeColor);
            }
        }

        private void Label_ThemeColor_Customize_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Geometry.PointIsInControl(e.Location, Label_ThemeColor_Customize))
                {
                    ChoseColor(_ColorTags.ThemeColor);

                    _RepaintCustomizeColorsImage();
                    _RepaintDivLabelsImage();
                    _RepaintBlendLabelsImage();
                    _RepaintAppearanceImage();
                }
                else
                {
                    PasteColor(GetColorTagOfCursorPosition());
                }
            }
        }

        #endregion

        #region 卡片控制

        // 反转卡片折叠状态
        private void ReverseFolderState(Button button, Panel panel)
        {
            if (button.ImageIndex == 0)
            {
                int MaxHeight = button.Bottom;

                foreach (Control c in panel.Controls)
                {
                    MaxHeight = Math.Max(MaxHeight, c.Bottom);
                }

                button.ImageIndex = 1;

                panel.Height = MaxHeight;
            }
            else
            {
                button.ImageIndex = 0;

                panel.Height = button.Bottom;
            }
        }

        private void Button_EditingColors_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Button btn = sender as Button;

                if (btn != null)
                {
                    Panel pnl = btn.Parent as Panel;

                    if (pnl != null)
                    {
                        ReverseFolderState(btn, pnl);

                        //

                        Panel_Colors.Top = Panel_Info.Bottom + 15;
                        Panel_Blend.Top = Panel_Colors.Bottom + 15;
                        Panel_View.Top = Panel_Blend.Bottom + 15;
                        Panel_Appearance.Top = Panel_View.Bottom + 15;
                        Panel_About.Top = Panel_Appearance.Bottom + 15;
                        Panel_EditingColors.Height = Panel_About.Bottom + Panel_Info.Top;

                        //

                        Me.OnSizeChanged();

                        //

                        _RepaintEditingColorsShadowImage();
                    }
                }
            }
        }

        private void Button_ColorSpaces_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Button btn = sender as Button;

                if (btn != null)
                {
                    Panel pnl = btn.Parent as Panel;

                    if (pnl != null)
                    {
                        ReverseFolderState(btn, pnl);

                        //

                        Panel_RGB.Top = Panel_Transparency.Bottom + 15;
                        Panel_HSV.Top = Panel_RGB.Bottom + 15;
                        Panel_HSL.Top = Panel_HSV.Bottom + 15;
                        Panel_CMYK.Top = Panel_HSL.Bottom + 15;
                        Panel_LAB.Top = Panel_CMYK.Bottom + 15;
                        Panel_YUV.Top = Panel_LAB.Bottom + 15;
                        Panel_ColorSpaces.Height = Panel_YUV.Bottom + Panel_Transparency.Top;

                        //

                        Me.OnSizeChanged();

                        //

                        _RepaintColorSpacesShadowImage();
                    }
                }
            }
        }

        #endregion

        #region 背景绘图

        private static void _PaintShadow(Graphics graphics, Color color, Rectangle bounds, int radius)
        {
            for (int i = 0; i < radius; i++)
            {
                using (Pen Pn = new Pen(Color.FromArgb(color.A * (i + 1) * (i + 1) / radius / radius, color), Math.Max(1F, Math.Min(radius - i, 3F))))
                {
                    using (GraphicsPath Path = Geometry.CreateRoundedRectanglePath(new Rectangle(bounds.X - radius + i, bounds.Y - radius + i, bounds.Width + 2 * radius - 2 * i - 1, bounds.Height + 2 * radius - 2 * i - 1), radius - i + 2))
                    {
                        int N = (Pn.Width >= 3F ? 1 : (Pn.Width == 2F ? 2 : (Pn.Width == 1 ? 3 : 0)));

                        for (int j = 0; j < N; j++)
                        {
                            graphics.DrawPath(Pn, Path);
                        }
                    }
                }
            }
        }

        //

        private Bitmap _EditingColorsShadowImage = null;

        private void _UpdateEditingColorsShadowImage()
        {
            if (_EditingColorsShadowImage != null)
            {
                _EditingColorsShadowImage.Dispose();
            }

            _EditingColorsShadowImage = new Bitmap(Math.Max(1, Panel_EditingColors.Width), Math.Max(1, Panel_EditingColors.Height));

            using (Graphics Grap = Graphics.FromImage(_EditingColorsShadowImage))
            {
                Grap.SmoothingMode = SmoothingMode.AntiAlias;

                Grap.Clear(Panel_Main.BackColor);

                //

                Control[] ctrls = new Control[] { Panel_Info, Panel_Colors, Panel_Blend, Panel_View, Panel_Appearance };

                Color borderColor = Color.FromArgb(20, Color.Black);

                foreach (Control ctrl in ctrls)
                {
                    _PaintShadow(Grap, borderColor, ctrl.Bounds, 5);
                }
            }
        }

        private void _RepaintEditingColorsShadowImage()
        {
            _UpdateEditingColorsShadowImage();

            if (_EditingColorsShadowImage != null)
            {
                Panel_EditingColors.CreateGraphics().DrawImage(_EditingColorsShadowImage, new Point(0, 0));
            }
        }

        private void Panel_EditingColors_Paint(object sender, PaintEventArgs e)
        {
            if (_EditingColorsShadowImage == null)
            {
                _UpdateEditingColorsShadowImage();
            }

            if (_EditingColorsShadowImage != null)
            {
                e.Graphics.DrawImage(_EditingColorsShadowImage, new Point(0, 0));
            }
        }

        //

        private Bitmap _InfoImage = null;

        private void _UpdateInfoImage()
        {
            ColorX currentColor = CurrentColor;

            bool empty = currentColor.IsEmpty;
            bool trueColor = currentColor.IsTrueColor;
            string name = ColorManipulation.GetColorName(currentColor);

            Label_CurrentColor.BackColor = currentColor.ToColor();
            Label_Name_Val.Text = (empty || trueColor ? name : "(近似) " + name);
            Label_Type_Val.Text = (empty ? "无" : (trueColor ? "32 位真彩色" : "浮点色"));
            Label_Grayscale_Val.BackColor = currentColor.Grayscale.ToColor();
            Label_Grayscale_Val2.Text = currentColor.Grayscale.Red.ToString("N3");
            Label_Complementary_Val.BackColor = currentColor.Complementary.ToColor();
            Label_Invert_Val.BackColor = currentColor.Invert.ToColor();

            //

            if (_InfoImage != null)
            {
                _InfoImage.Dispose();
            }

            _InfoImage = new Bitmap(Math.Max(1, Panel_Info_Contents.Width), Math.Max(1, Panel_Info_Contents.Height));

            using (Graphics Grap = Graphics.FromImage(_InfoImage))
            {
                Grap.SmoothingMode = SmoothingMode.AntiAlias;

                Grap.Clear(Panel_Info_Contents.BackColor);

                //

                Control[] ctrls = new Control[] { Label_CurrentColor, Label_Grayscale_Val, Label_Complementary_Val, Label_Invert_Val };

                Color borderColor = Color.FromArgb(20, Color.Black);

                foreach (Control ctrl in ctrls)
                {
                    _PaintShadow(Grap, borderColor, ctrl.Bounds, 5);
                }
            }
        }

        private void _RepaintInfoImage()
        {
            _UpdateInfoImage();

            if (_InfoImage != null)
            {
                Panel_Info_Contents.CreateGraphics().DrawImage(_InfoImage, new Point(0, 0));
            }
        }

        private void Panel_Info_Contents_Paint(object sender, PaintEventArgs e)
        {
            if (_InfoImage == null)
            {
                _UpdateInfoImage();
            }

            if (_InfoImage != null)
            {
                e.Graphics.DrawImage(_InfoImage, new Point(0, 0));
            }
        }

        //

        private Bitmap _BuiltinColorsImage = null;

        private void _UpdateBuiltinColorsImage()
        {
            for (int i = 0; i < Label_BuiltinColors.Length; i++)
            {
                Label_BuiltinColors[i].BackColor = _BuiltinColors[i].ToColor();
            }

            //

            if (_BuiltinColorsImage != null)
            {
                _BuiltinColorsImage.Dispose();
            }

            _BuiltinColorsImage = new Bitmap(Math.Max(1, Panel_Colors_Builtin.Width), Math.Max(1, Panel_Colors_Builtin.Height));

            using (Graphics Grap = Graphics.FromImage(_BuiltinColorsImage))
            {
                Grap.SmoothingMode = SmoothingMode.Default;

                Grap.Clear(Panel_Colors_Contents.BackColor);

                //

                using (Pen Pn = new Pen(Me.RecommendColors.Border.Grayscale.ToColor(), 1F))
                {
                    foreach (Label ctrl in Label_BuiltinColors)
                    {
                        Grap.DrawRectangle(Pn, new Rectangle(ctrl.Left - 1, ctrl.Top - 1, ctrl.Bounds.Width + 1, ctrl.Bounds.Height + 1));
                    }
                }
            }
        }

        private void _RepaintBuiltinColorsImage()
        {
            _UpdateBuiltinColorsImage();

            if (_BuiltinColorsImage != null)
            {
                Panel_Colors_Builtin.CreateGraphics().DrawImage(_BuiltinColorsImage, new Point(0, 0));
            }
        }

        private void Panel_Colors_Builtin_Paint(object sender, PaintEventArgs e)
        {
            if (_BuiltinColorsImage == null)
            {
                _UpdateBuiltinColorsImage();
            }

            if (_BuiltinColorsImage != null)
            {
                e.Graphics.DrawImage(_BuiltinColorsImage, new Point(0, 0));
            }
        }

        //

        private Bitmap _CustomizeColorsImage = null;

        private void _UpdateCustomizeColorsImage()
        {
            if (_CustomizeColorsImage != null)
            {
                _CustomizeColorsImage.Dispose();
            }

            _CustomizeColorsImage = new Bitmap(Math.Max(1, Panel_Colors_Customize.Width), Math.Max(1, Panel_Colors_Customize.Height));

            using (Graphics Grap = Graphics.FromImage(_CustomizeColorsImage))
            {
                Grap.SmoothingMode = SmoothingMode.Default;

                Grap.Clear(Panel_Colors_Contents.BackColor);

                //

                for (int i = 0; i < Label_CustomizeColors.Length; i++)
                {
                    using (Brush Br = new SolidBrush(_CustomizeColors[i].ToColor()))
                    {
                        Grap.FillRectangle(Br, Label_CustomizeColors[i].Bounds);
                    }
                }

                //

                using (Pen Pn = new Pen(Me.RecommendColors.Border.Grayscale.ToColor(), 1F))
                {
                    foreach (Label ctrl in Label_CustomizeColors)
                    {
                        Grap.DrawRectangle(Pn, ctrl.Bounds);
                    }
                }

                //

                if (_ColorTag >= _ColorTags.CustomizeFirst && _ColorTag <= _ColorTags.CustomizeLast)
                {
                    Label ctrl = Label_CustomizeColors[_ColorTag - _ColorTags.CustomizeFirst];
                    ColorX crx = _CustomizeColors[_ColorTag - _ColorTags.CustomizeFirst];

                    Rectangle rect = ctrl.Bounds;

                    //

                    Color crCorner, crBorder;

                    if (crx.Lightness_LAB < 50)
                    {
                        crCorner = ColorManipulation.ShiftLightnessByHSL(crx, +0.75).AtOpacity(100).ToColor();
                        crBorder = ColorManipulation.ShiftLightnessByHSL(crx, +0.5).AtOpacity(75).ToColor();
                    }
                    else
                    {
                        crCorner = ColorManipulation.ShiftLightnessByHSL(crx, -0.6).AtOpacity(100).ToColor();
                        crBorder = ColorManipulation.ShiftLightnessByHSL(crx, -0.4).AtOpacity(75).ToColor();
                    }

                    using (Brush Br = new SolidBrush(crCorner))
                    {
                        Grap.FillPolygon(Br, new PointF[] { new PointF(rect.X, rect.Y), new PointF(rect.X + 12, rect.Y), new PointF(rect.X, rect.Y + 12) });
                    }

                    using (Pen Pn = new Pen(crBorder, 2F))
                    {
                        Grap.DrawRectangle(Pn, new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2));
                    }

                    //

                    Grap.SmoothingMode = SmoothingMode.AntiAlias;

                    Color borderColor = Color.FromArgb(30, Color.Black);

                    _PaintShadow(Grap, borderColor, rect, 8);
                }
            }
        }

        private void _RepaintCustomizeColorsImage()
        {
            _UpdateCustomizeColorsImage();

            if (_CustomizeColorsImage != null)
            {
                Panel_Colors_Customize.CreateGraphics().DrawImage(_CustomizeColorsImage, new Point(0, 0));

                //

                foreach (Label l in Label_CustomizeColors)
                {
                    l.Refresh();
                }
            }
        }

        private void Panel_Colors_Customize_Paint(object sender, PaintEventArgs e)
        {
            if (_CustomizeColorsImage == null)
            {
                _UpdateCustomizeColorsImage();
            }

            if (_CustomizeColorsImage != null)
            {
                e.Graphics.DrawImage(_CustomizeColorsImage, new Point(0, 0));
            }
        }

        //

        private Bitmap _BlendLabelsImage = null;

        private void _UpdateBlendLabelsImage()
        {
            if (_BlendLabelsImage != null)
            {
                _BlendLabelsImage.Dispose();
            }

            _BlendLabelsImage = new Bitmap(Math.Max(1, Panel_BlendLabels.Width), Math.Max(1, Panel_BlendLabels.Height));

            using (Graphics Grap = Graphics.FromImage(_BlendLabelsImage))
            {
                Grap.SmoothingMode = SmoothingMode.Default;

                Grap.Clear(Panel_Blend_Contents.BackColor);

                //

                using (Brush Br = new SolidBrush(_BlendColor1.ToColor()))
                {
                    Grap.FillRectangle(Br, Label_BlendColor1_Val.Bounds);
                }

                using (Brush Br = new SolidBrush(_BlendColor2.ToColor()))
                {
                    Grap.FillRectangle(Br, Label_BlendColor2_Val.Bounds);
                }

                //

                if (_ColorTag >= _ColorTags.BlendColor1 && _ColorTag <= _ColorTags.BlendColor2)
                {
                    Label ctrl = null;
                    ColorX crx = ColorX.Empty;

                    switch (_ColorTag)
                    {
                        case _ColorTags.BlendColor1: ctrl = Label_BlendColor1_Val; crx = _BlendColor1; break;
                        case _ColorTags.BlendColor2: ctrl = Label_BlendColor2_Val; crx = _BlendColor2; break;
                    }

                    Rectangle rect = ctrl.Bounds;

                    //

                    Color crCorner, crBorder;

                    if (crx.Lightness_LAB < 50)
                    {
                        crCorner = ColorManipulation.ShiftLightnessByHSL(crx, +0.75).AtOpacity(100).ToColor();
                        crBorder = ColorManipulation.ShiftLightnessByHSL(crx, +0.5).AtOpacity(75).ToColor();
                    }
                    else
                    {
                        crCorner = ColorManipulation.ShiftLightnessByHSL(crx, -0.6).AtOpacity(100).ToColor();
                        crBorder = ColorManipulation.ShiftLightnessByHSL(crx, -0.4).AtOpacity(75).ToColor();
                    }

                    using (Brush Br = new SolidBrush(crCorner))
                    {
                        Grap.FillPolygon(Br, new PointF[] { new PointF(rect.X, rect.Y), new PointF(rect.X + 12, rect.Y), new PointF(rect.X, rect.Y + 12) });
                    }

                    using (Pen Pn = new Pen(crBorder, 2F))
                    {
                        Grap.DrawRectangle(Pn, new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2));
                    }
                }

                //

                Grap.SmoothingMode = SmoothingMode.AntiAlias;

                Control[] ctrls = new Control[] { Label_BlendColor1_Val, Label_BlendColor2_Val };

                Color borderColor = Color.FromArgb(20, Color.Black);

                foreach (Control ctrl in ctrls)
                {
                    _PaintShadow(Grap, borderColor, ctrl.Bounds, 5);
                }
            }
        }

        private void _RepaintBlendLabelsImage()
        {
            _UpdateBlendLabelsImage();

            if (_BlendLabelsImage != null)
            {
                Panel_BlendLabels.CreateGraphics().DrawImage(_BlendLabelsImage, new Point(0, 0));

                Label_BlendColor1_Val.Refresh();
                Label_BlendColor2_Val.Refresh();
            }
        }

        private void Panel_BlendLabels_Paint(object sender, PaintEventArgs e)
        {
            if (_BlendLabelsImage == null)
            {
                _UpdateBlendLabelsImage();
            }

            if (_BlendLabelsImage != null)
            {
                e.Graphics.DrawImage(_BlendLabelsImage, new Point(0, 0));
            }
        }

        //

        private Bitmap _BlendResultsImage = null;

        private void _UpdateBlendResultsImage()
        {
            Label_BlendResultRGB_Val.BackColor = GetColor(_ColorTags.BlendResultRGB).ToColor();
            Label_BlendResultHSV_Val.BackColor = GetColor(_ColorTags.BlendResultHSV).ToColor();
            Label_BlendResultHSL_Val.BackColor = GetColor(_ColorTags.BlendResultHSL).ToColor();
            Label_BlendResultCMYK_Val.BackColor = GetColor(_ColorTags.BlendResultCMYK).ToColor();
            Label_BlendResultLAB_Val.BackColor = GetColor(_ColorTags.BlendResultLAB).ToColor();
            Label_BlendResultYUV_Val.BackColor = GetColor(_ColorTags.BlendResultYUV).ToColor();

            //

            if (_BlendResultsImage != null)
            {
                _BlendResultsImage.Dispose();
            }

            _BlendResultsImage = new Bitmap(Math.Max(1, Panel_BlendResults.Width), Math.Max(1, Panel_BlendResults.Height));

            using (Graphics Grap = Graphics.FromImage(_BlendResultsImage))
            {
                Grap.SmoothingMode = SmoothingMode.Default;

                Grap.Clear(Panel_Blend_Contents.BackColor);

                //

                Grap.SmoothingMode = SmoothingMode.AntiAlias;

                Control[] ctrls = new Control[] { Label_BlendResultRGB_Val, Label_BlendResultHSV_Val, Label_BlendResultHSL_Val, Label_BlendResultCMYK_Val, Label_BlendResultLAB_Val, Label_BlendResultYUV_Val };

                Color borderColor = Color.FromArgb(20, Color.Black);

                foreach (Control ctrl in ctrls)
                {
                    _PaintShadow(Grap, borderColor, ctrl.Bounds, 5);
                }
            }
        }

        private void _RepaintBlendResultsImage()
        {
            _UpdateBlendResultsImage();

            if (_BlendResultsImage != null)
            {
                Panel_BlendResults.CreateGraphics().DrawImage(_BlendResultsImage, new Point(0, 0));
            }
        }

        private void Panel_BlendResults_Paint(object sender, PaintEventArgs e)
        {
            if (_BlendResultsImage == null)
            {
                _UpdateBlendResultsImage();
            }

            if (_BlendResultsImage != null)
            {
                e.Graphics.DrawImage(_BlendResultsImage, new Point(0, 0));
            }
        }

        //

        private Bitmap _ViewImage = null;

        private void _UpdateViewImage()
        {
            if (_ViewImage != null)
            {
                _ViewImage.Dispose();
            }

            _ViewImage = new Bitmap(Math.Max(1, Panel_View_Contents.Width), Math.Max(1, Panel_View_Contents.Height));

            using (Graphics Grap = Graphics.FromImage(_ViewImage))
            {
                Grap.SmoothingMode = SmoothingMode.Default;

                Grap.Clear(Panel_View_Contents.BackColor);

                //

                Grap.SmoothingMode = SmoothingMode.AntiAlias;

                Color borderColor = Color.FromArgb(20, Color.Black);

                _PaintShadow(Grap, borderColor, Panel_Div.Bounds, 5);
            }
        }

        private void _RepaintViewImage()
        {
            _UpdateViewImage();

            if (_ViewImage != null)
            {
                Panel_View_Contents.CreateGraphics().DrawImage(_ViewImage, new Point(0, 0));

                Label_Background_Val.Refresh();
                Label_Label_Val.Refresh();
                Label_Border_Val.Refresh();
                Label_Text_Val.Refresh();
            }
        }

        private void Panel_View_Contents_Paint(object sender, PaintEventArgs e)
        {
            if (_ViewImage == null)
            {
                _UpdateViewImage();
            }

            if (_ViewImage != null)
            {
                e.Graphics.DrawImage(_ViewImage, new Point(0, 0));
            }
        }

        //

        private Bitmap _DivImage = null;

        private void _UpdateDivImage()
        {
            if (_DivImage != null)
            {
                _DivImage.Dispose();
            }

            _DivImage = new Bitmap(Math.Max(1, Panel_Div.Width), Math.Max(1, Panel_Div.Height));

            using (Graphics Grap = Graphics.FromImage(_DivImage))
            {
                Grap.SmoothingMode = SmoothingMode.AntiAlias;

                Grap.Clear(Panel_View_Contents.BackColor);

                //

                Rectangle outerBounds = new Rectangle(0, 0, _DivImage.Width, _DivImage.Height);
                Rectangle innerBounds = new Rectangle(20, 20, outerBounds.Width - 40, outerBounds.Height - 40);

                using (Brush Br = new SolidBrush(_BackgroundColor.ToColor()))
                {
                    Grap.FillRectangle(Br, outerBounds);
                }

                using (Brush Br = new SolidBrush(_LabelColor.ToColor()))
                {
                    Grap.FillRectangle(Br, innerBounds);
                }

                using (Pen Pn = new Pen(_BorderColor.ToColor(), 2))
                {
                    Grap.DrawRectangle(Pn, innerBounds);
                }

                using (Brush Br = new SolidBrush(_TextColor.ToColor()))
                {
                    string text1 = "示例文本";
                    Font font1 = new Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 134);
                    Size size1 = TextRenderer.MeasureText(text1, font1);

                    string text2 = "Sample text";
                    Font font2 = new Font("微软雅黑", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 134);
                    Size size2 = TextRenderer.MeasureText(text2, font2);

                    Point loc1 = new Point((outerBounds.Width - size1.Width) / 2, (outerBounds.Height - size1.Height - size2.Height) / 2);
                    Point loc2 = new Point((outerBounds.Width - size2.Width) / 2, loc1.Y + size1.Height);

                    Grap.DrawString(text1, font1, Br, loc1);
                    Grap.DrawString(text2, font2, Br, loc2);
                }
            }
        }

        private void _RepaintDivImage()
        {
            _UpdateDivImage();

            if (_DivImage != null)
            {
                Panel_Div.CreateGraphics().DrawImage(_DivImage, new Point(0, 0));
            }
        }

        private void Panel_Div_Paint(object sender, PaintEventArgs e)
        {
            if (_DivImage == null)
            {
                _UpdateDivImage();
            }

            if (_DivImage != null)
            {
                e.Graphics.DrawImage(_DivImage, new Point(0, 0));
            }
        }

        //

        private Bitmap _DivLabelsImage = null;

        private void _UpdateDivLabelsImage()
        {
            if (_DivLabelsImage != null)
            {
                _DivLabelsImage.Dispose();
            }

            _DivLabelsImage = new Bitmap(Math.Max(1, Panel_DivLabels.Width), Math.Max(1, Panel_DivLabels.Height));

            using (Graphics Grap = Graphics.FromImage(_DivLabelsImage))
            {
                Grap.SmoothingMode = SmoothingMode.Default;

                Grap.Clear(Panel_View_Contents.BackColor);

                //

                using (Brush Br = new SolidBrush(_BackgroundColor.ToColor()))
                {
                    Grap.FillRectangle(Br, Label_Background_Val.Bounds);
                }

                using (Brush Br = new SolidBrush(_LabelColor.ToColor()))
                {
                    Grap.FillRectangle(Br, Label_Label_Val.Bounds);
                }

                using (Brush Br = new SolidBrush(_BorderColor.ToColor()))
                {
                    Grap.FillRectangle(Br, Label_Border_Val.Bounds);
                }

                using (Brush Br = new SolidBrush(_TextColor.ToColor()))
                {
                    Grap.FillRectangle(Br, Label_Text_Val.Bounds);
                }

                //

                if (_ColorTag >= _ColorTags.Background && _ColorTag <= _ColorTags.Text)
                {
                    Label ctrl = null;
                    ColorX crx = ColorX.Empty;

                    switch (_ColorTag)
                    {
                        case _ColorTags.Background: ctrl = Label_Background_Val; crx = _BackgroundColor; break;
                        case _ColorTags.Label: ctrl = Label_Label_Val; crx = _LabelColor; break;
                        case _ColorTags.Border: ctrl = Label_Border_Val; crx = _BorderColor; break;
                        case _ColorTags.Text: ctrl = Label_Text_Val; crx = _TextColor; break;
                    }

                    Rectangle rect = ctrl.Bounds;

                    //

                    Color crCorner, crBorder;

                    if (crx.Lightness_LAB < 50)
                    {
                        crCorner = ColorManipulation.ShiftLightnessByHSL(crx, +0.75).AtOpacity(100).ToColor();
                        crBorder = ColorManipulation.ShiftLightnessByHSL(crx, +0.5).AtOpacity(75).ToColor();
                    }
                    else
                    {
                        crCorner = ColorManipulation.ShiftLightnessByHSL(crx, -0.6).AtOpacity(100).ToColor();
                        crBorder = ColorManipulation.ShiftLightnessByHSL(crx, -0.4).AtOpacity(75).ToColor();
                    }

                    using (Brush Br = new SolidBrush(crCorner))
                    {
                        Grap.FillPolygon(Br, new PointF[] { new PointF(rect.X, rect.Y), new PointF(rect.X + 12, rect.Y), new PointF(rect.X, rect.Y + 12) });
                    }

                    using (Pen Pn = new Pen(crBorder, 2F))
                    {
                        Grap.DrawRectangle(Pn, new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2));
                    }
                }

                //

                Grap.SmoothingMode = SmoothingMode.AntiAlias;

                Control[] ctrls = new Control[] { Label_Background_Val, Label_Label_Val, Label_Border_Val, Label_Text_Val };

                Color borderColor = Color.FromArgb(20, Color.Black);

                foreach (Control ctrl in ctrls)
                {
                    _PaintShadow(Grap, borderColor, ctrl.Bounds, 5);
                }
            }
        }

        private void _RepaintDivLabelsImage()
        {
            _UpdateDivLabelsImage();

            if (_DivLabelsImage != null)
            {
                Panel_DivLabels.CreateGraphics().DrawImage(_DivLabelsImage, new Point(0, 0));

                Label_Background_Val.Refresh();
                Label_Label_Val.Refresh();
                Label_Border_Val.Refresh();
                Label_Text_Val.Refresh();
            }
        }

        private void Panel_DivLabels_Paint(object sender, PaintEventArgs e)
        {
            if (_DivLabelsImage == null)
            {
                _UpdateDivLabelsImage();
            }

            if (_DivLabelsImage != null)
            {
                e.Graphics.DrawImage(_DivLabelsImage, new Point(0, 0));
            }
        }

        //

        private Bitmap _AppearanceImage = null;

        private void _UpdateAppearanceImage()
        {
            if (_AppearanceImage != null)
            {
                _AppearanceImage.Dispose();
            }

            _AppearanceImage = new Bitmap(Math.Max(1, Panel_Appearance_Contents.Width), Math.Max(1, Panel_Appearance_Contents.Height));

            using (Graphics Grap = Graphics.FromImage(_AppearanceImage))
            {
                Grap.SmoothingMode = SmoothingMode.Default;

                Grap.Clear(Panel_Appearance_Contents.BackColor);

                //

                using (Brush Br = new SolidBrush(_ThemeColor.ToColor()))
                {
                    Grap.FillRectangle(Br, Label_ThemeColor_Customize.Bounds);
                }

                //

                if (_ColorTag == _ColorTags.ThemeColor)
                {
                    ColorX crx = _ThemeColor;
                    Rectangle rect = Label_ThemeColor_Customize.Bounds;

                    //

                    Color crCorner, crBorder;

                    if (crx.Lightness_LAB < 50)
                    {
                        crCorner = ColorManipulation.ShiftLightnessByHSL(crx, +0.75).AtOpacity(100).ToColor();
                        crBorder = ColorManipulation.ShiftLightnessByHSL(crx, +0.5).AtOpacity(75).ToColor();
                    }
                    else
                    {
                        crCorner = ColorManipulation.ShiftLightnessByHSL(crx, -0.6).AtOpacity(100).ToColor();
                        crBorder = ColorManipulation.ShiftLightnessByHSL(crx, -0.4).AtOpacity(75).ToColor();
                    }

                    using (Brush Br = new SolidBrush(crCorner))
                    {
                        Grap.FillPolygon(Br, new PointF[] { new PointF(rect.X, rect.Y), new PointF(rect.X + 12, rect.Y), new PointF(rect.X, rect.Y + 12) });
                    }

                    using (Pen Pn = new Pen(crBorder, 2F))
                    {
                        Grap.DrawRectangle(Pn, new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2));
                    }
                }

                //

                Grap.SmoothingMode = SmoothingMode.AntiAlias;

                Color borderColor = Color.FromArgb(20, Color.Black);

                _PaintShadow(Grap, borderColor, Label_ThemeColor_Customize.Bounds, 5);
            }
        }

        private void _RepaintAppearanceImage()
        {
            _UpdateAppearanceImage();

            if (_AppearanceImage != null)
            {
                Panel_Appearance_Contents.CreateGraphics().DrawImage(_AppearanceImage, new Point(0, 0));

                Label_ThemeColor_Customize.Refresh();
            }
        }

        private void Panel_Appearance_Contents_Paint(object sender, PaintEventArgs e)
        {
            if (_AppearanceImage == null)
            {
                _UpdateAppearanceImage();
            }

            if (_AppearanceImage != null)
            {
                e.Graphics.DrawImage(_AppearanceImage, new Point(0, 0));
            }
        }

        //

        private Bitmap _ColorSpacesShadowImage = null;

        private void _UpdateColorSpacesShadowImage()
        {
            if (_ColorSpacesShadowImage != null)
            {
                _ColorSpacesShadowImage.Dispose();
            }

            _ColorSpacesShadowImage = new Bitmap(Math.Max(1, Panel_ColorSpaces.Width), Math.Max(1, Panel_ColorSpaces.Height));

            using (Graphics Grap = Graphics.FromImage(_ColorSpacesShadowImage))
            {
                Grap.SmoothingMode = SmoothingMode.AntiAlias;

                Grap.Clear(Panel_Main.BackColor);

                //

                Control[] ctrls = new Control[] { Panel_Transparency, Panel_RGB, Panel_HSV, Panel_HSL, Panel_CMYK, Panel_LAB, Panel_YUV };

                Color borderColor = Color.FromArgb(20, Color.Black);

                foreach (Control ctrl in ctrls)
                {
                    _PaintShadow(Grap, borderColor, ctrl.Bounds, 5);
                }
            }
        }

        private void _RepaintColorSpacesShadowImage()
        {
            _UpdateColorSpacesShadowImage();

            if (_ColorSpacesShadowImage != null)
            {
                Panel_ColorSpaces.CreateGraphics().DrawImage(_ColorSpacesShadowImage, new Point(0, 0));
            }
        }

        private void Panel_ColorSpaces_Paint(object sender, PaintEventArgs e)
        {
            if (_ColorSpacesShadowImage == null)
            {
                _UpdateColorSpacesShadowImage();
            }

            if (_ColorSpacesShadowImage != null)
            {
                e.Graphics.DrawImage(_ColorSpacesShadowImage, new Point(0, 0));
            }
        }

        #endregion

        #region 混色

        private void HTrackBar_Blend_ValueChanged(object sender, EventArgs e)
        {
            HTrackBar_Blend.ValueChanged -= HTrackBar_Blend_ValueChanged;
            NumEditor_Blend.ValueChanged -= NumEditor_Blend_ValueChanged;

            //

            NumEditor_Blend.Value = HTrackBar_Blend.Value;

            _RepaintBlendResultsImage();

            //

            HTrackBar_Blend.ValueChanged += HTrackBar_Blend_ValueChanged;
            NumEditor_Blend.ValueChanged += NumEditor_Blend_ValueChanged;
        }

        private void NumEditor_Blend_ValueChanged(object sender, EventArgs e)
        {
            HTrackBar_Blend.ValueChanged -= HTrackBar_Blend_ValueChanged;
            NumEditor_Blend.ValueChanged -= NumEditor_Blend_ValueChanged;

            //

            HTrackBar_Blend.Value = NumEditor_Blend.Value;

            _RepaintBlendResultsImage();

            //

            HTrackBar_Blend.ValueChanged += HTrackBar_Blend_ValueChanged;
            NumEditor_Blend.ValueChanged += NumEditor_Blend_ValueChanged;
        }

        #endregion

        #region 外观

        private void ComboBox_Theme_SelectedIndexChanged(object sender, EventArgs e)
        {
            Me.Theme = (Theme)ComboBox_Theme.SelectedIndex;
        }

        private void RadioButton_ThemeColor_Customize_CheckedChanged(object sender, EventArgs e)
        {
            Me.ThemeColor = _ThemeColor;
        }

        private void RadioButton_ThemeColor_EditingColor_CheckedChanged(object sender, EventArgs e)
        {
            Me.ThemeColor = CurrentColor;
        }

        private void RadioButton_ThemeColor_Windows_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region 关于

        private void Label_GitHub_Base_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/chibayuki/ColorPalette");
        }

        private void Label_GitHub_Release_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/chibayuki/ColorPalette/releases/latest");
        }

        #endregion
    }
}