﻿/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
Copyright © 2019 chibayuki@foxmail.com

调色板 (ColorPalette)
Version 1.0.2000.0.R1.190525-0000

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
using System.Drawing.Drawing2D;

namespace WinFormApp
{
    public partial class Form_Main : Form
    {
        #region 私有成员与内部成员

        private Com.ColorX _BackgroundColor;
        private Com.ColorX _LabelColor;
        private Com.ColorX _BorderColor;
        private Com.ColorX _TextColor;

        private enum _ColorTags
        {
            None = -1,
            Background,
            Border,
            Label,
            Text
        }

        private _ColorTags _ColorTag = _ColorTags.None;

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
            Me.Theme = Com.WinForm.Theme.Colorful;
            Me.ThemeColor = Com.ColorManipulation.GetRandomColorX();
            Me.MinimumSize = new Size(870, 285 + Me.CaptionBarHeight);

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

            _BackgroundColor = Me.RecommendColors.Background;
            _LabelColor = Me.RecommendColors.Button;
            _BorderColor = Me.RecommendColors.Border_INC;
            _TextColor = Me.RecommendColors.Text_INC;

            ChoseColor(_ColorTags.Background);

            RegisterEvents();
        }

        // 在窗体的大小调整时发生。
        private void ResizeEvents(object sender, EventArgs e)
        {
            Panel_LeftArea.Height = Panel_Main.Height;
            Panel_RightArea.Height = Panel_Main.Height;

            Panel_LeftArea.Width = Math.Min(1260, Panel_Main.Width - Panel_RightArea.Width);

            Panel_LeftArea.Left = Math.Max(0, (Panel_Main.Width - Panel_LeftArea.Width - Panel_RightArea.Width) / 2);
            Panel_RightArea.Left = Panel_LeftArea.Right;

            //

            Panel_ColorSpaces.Width = Panel_LeftArea.Width - 20;

            int spaceContainerWidth = Panel_ColorSpaces.Width - 2 * Panel_RGB.Left;

            Panel_Transparency.Width = spaceContainerWidth;
            Panel_RGB.Width = spaceContainerWidth;
            Panel_HSV.Width = spaceContainerWidth;
            Panel_HSL.Width = spaceContainerWidth;
            Panel_CMYK.Width = spaceContainerWidth;
            Panel_LAB.Width = spaceContainerWidth;
            Panel_YUV.Width = spaceContainerWidth;

            //

            _RepaintColorSpacesShadowImage();
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
            Panel_Main.BackColor = Me.RecommendColors.Background_DEC.ToColor();

            //

            Color spaceContainerBackColor = Me.RecommendColors.Background.ToColor();

            Panel_Transparency.BackColor = spaceContainerBackColor;
            Panel_RGB.BackColor = spaceContainerBackColor;
            Panel_HSV.BackColor = spaceContainerBackColor;
            Panel_HSL.BackColor = spaceContainerBackColor;
            Panel_CMYK.BackColor = spaceContainerBackColor;
            Panel_LAB.BackColor = spaceContainerBackColor;
            Panel_YUV.BackColor = spaceContainerBackColor;

            //

            Color spaceButtonForeColor = Me.RecommendColors.Text_INC.ToColor();

            Button_Transparency.ForeColor = spaceButtonForeColor;
            Button_RGB.ForeColor = spaceButtonForeColor;
            Button_HSV.ForeColor = spaceButtonForeColor;
            Button_HSL.ForeColor = spaceButtonForeColor;
            Button_CMYK.ForeColor = spaceButtonForeColor;
            Button_LAB.ForeColor = spaceButtonForeColor;
            Button_YUV.ForeColor = spaceButtonForeColor;

            Color spaceButtonBackColor = Me.RecommendColors.Button.ToColor();

            Button_Transparency.BackColor = spaceButtonBackColor;
            Button_RGB.BackColor = spaceButtonBackColor;
            Button_HSV.BackColor = spaceButtonBackColor;
            Button_HSL.BackColor = spaceButtonBackColor;
            Button_CMYK.BackColor = spaceButtonBackColor;
            Button_LAB.BackColor = spaceButtonBackColor;
            Button_YUV.BackColor = spaceButtonBackColor;

            Color spaceButtonBorderColor = Me.RecommendColors.Button.ToColor();

            Button_Transparency.FlatAppearance.BorderColor = spaceButtonBorderColor;
            Button_RGB.FlatAppearance.BorderColor = spaceButtonBorderColor;
            Button_HSV.FlatAppearance.BorderColor = spaceButtonBorderColor;
            Button_HSL.FlatAppearance.BorderColor = spaceButtonBorderColor;
            Button_CMYK.FlatAppearance.BorderColor = spaceButtonBorderColor;
            Button_LAB.FlatAppearance.BorderColor = spaceButtonBorderColor;
            Button_YUV.FlatAppearance.BorderColor = spaceButtonBorderColor;

            Color spaceButtonMouseOverBackColor = Me.RecommendColors.Button_DEC.ToColor();

            Button_Transparency.FlatAppearance.MouseOverBackColor = spaceButtonMouseOverBackColor;
            Button_RGB.FlatAppearance.MouseOverBackColor = spaceButtonMouseOverBackColor;
            Button_HSV.FlatAppearance.MouseOverBackColor = spaceButtonMouseOverBackColor;
            Button_HSL.FlatAppearance.MouseOverBackColor = spaceButtonMouseOverBackColor;
            Button_CMYK.FlatAppearance.MouseOverBackColor = spaceButtonMouseOverBackColor;
            Button_LAB.FlatAppearance.MouseOverBackColor = spaceButtonMouseOverBackColor;
            Button_YUV.FlatAppearance.MouseOverBackColor = spaceButtonMouseOverBackColor;

            Color spaceButtonMouseDownBackColor = Me.RecommendColors.Button.ToColor();

            Button_Transparency.FlatAppearance.MouseDownBackColor = spaceButtonMouseDownBackColor;
            Button_RGB.FlatAppearance.MouseDownBackColor = spaceButtonMouseDownBackColor;
            Button_HSV.FlatAppearance.MouseDownBackColor = spaceButtonMouseDownBackColor;
            Button_HSL.FlatAppearance.MouseDownBackColor = spaceButtonMouseDownBackColor;
            Button_CMYK.FlatAppearance.MouseDownBackColor = spaceButtonMouseDownBackColor;
            Button_LAB.FlatAppearance.MouseDownBackColor = spaceButtonMouseDownBackColor;
            Button_YUV.FlatAppearance.MouseDownBackColor = spaceButtonMouseDownBackColor;

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

            Color numEditorBackColor = Me.RecommendColors.Background.ToColor();

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

            _RepaintColorSpacesShadowImage();

            //

            UpdatePreviewButtons();
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

        private Control _CurrentTrackBarOrNumEditor = null;

        private void UpdateTrackBarAndNumEditor(Com.ColorX color)
        {
            Color[] Colors_Opacity = _ColorsTable[_ColorsKey.Opacity] as Color[];
            Color[] Colors_Alpha = _ColorsTable[_ColorsKey.Alpha] as Color[];
            Color[] Colors_RGB_R = _ColorsTable[_ColorsKey.RGB_R] as Color[];
            Color[] Colors_RGB_G = _ColorsTable[_ColorsKey.RGB_G] as Color[];
            Color[] Colors_RGB_B = _ColorsTable[_ColorsKey.RGB_B] as Color[];
            Color[] Colors_HSV_H = _ColorsTable[_ColorsKey.HSV_H] as Color[];
            Color[] Colors_HSV_S = _ColorsTable[_ColorsKey.HSV_S] as Color[];
            Color[] Colors_HSV_V = _ColorsTable[_ColorsKey.HSV_V] as Color[];
            Color[] Colors_HSL_H = _ColorsTable[_ColorsKey.HSL_H] as Color[];
            Color[] Colors_HSL_S = _ColorsTable[_ColorsKey.HSL_S] as Color[];
            Color[] Colors_HSL_L = _ColorsTable[_ColorsKey.HSL_L] as Color[];
            Color[] Colors_CMYK_C = _ColorsTable[_ColorsKey.CMYK_C] as Color[];
            Color[] Colors_CMYK_M = _ColorsTable[_ColorsKey.CMYK_M] as Color[];
            Color[] Colors_CMYK_Y = _ColorsTable[_ColorsKey.CMYK_Y] as Color[];
            Color[] Colors_CMYK_K = _ColorsTable[_ColorsKey.CMYK_K] as Color[];
            Color[] Colors_LAB_L = _ColorsTable[_ColorsKey.LAB_L] as Color[];
            Color[] Colors_LAB_A = _ColorsTable[_ColorsKey.LAB_A] as Color[];
            Color[] Colors_LAB_B = _ColorsTable[_ColorsKey.LAB_B] as Color[];
            Color[] Colors_YUV_Y = _ColorsTable[_ColorsKey.YUV_Y] as Color[];
            Color[] Colors_YUV_U = _ColorsTable[_ColorsKey.YUV_U] as Color[];
            Color[] Colors_YUV_V = _ColorsTable[_ColorsKey.YUV_V] as Color[];

            for (int i = 0; i < _ColorsNum; i++)
            {
                double Pct = (double)i / (_ColorsNum - 1);

                Colors_Opacity[i] = color.AtOpacity(Pct * 100).ToColor();
                Colors_Alpha[i] = color.AtAlpha(Pct * 255).ToColor();
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
        }

        private Com.ColorX CurrentColor
        {
            get
            {
                switch (_ColorTag)
                {
                    case _ColorTags.Background: return _BackgroundColor;
                    case _ColorTags.Label: return _LabelColor;
                    case _ColorTags.Border: return _BorderColor;
                    case _ColorTags.Text: return _TextColor;
                    default: return Com.ColorX.Empty;
                }
            }

            set
            {
                switch (_ColorTag)
                {
                    case _ColorTags.Background: _BackgroundColor = value; break;
                    case _ColorTags.Label: _LabelColor = value; break;
                    case _ColorTags.Border: _BorderColor = value; break;
                    case _ColorTags.Text: _TextColor = value; break;
                }

                Me.ThemeColor = value.AtAlpha(255);

                _RepaintPreviewImage();

                UpdateTrackBarAndNumEditor(value);
            }
        }

        private void ChoseColor(_ColorTags colorTag)
        {
            if (_ColorTag != colorTag)
            {
                _ColorTag = colorTag;

                //

                Com.ColorX currentColor = CurrentColor;

                Me.ThemeColor = currentColor.AtAlpha(255);

                UpdateTrackBarAndNumEditor(currentColor);
            }
        }

        private void UpdatePreviewButtons()
        {
            Color selectedForeColor = Me.RecommendColors.Background_DEC.ToColor();
            Color unselectedForeColor = Me.RecommendColors.Text_INC.ToColor();

            Button_Background.ForeColor = (_ColorTag == _ColorTags.Background ? selectedForeColor : unselectedForeColor);
            Button_Label.ForeColor = (_ColorTag == _ColorTags.Label ? selectedForeColor : unselectedForeColor);
            Button_Border.ForeColor = (_ColorTag == _ColorTags.Border ? selectedForeColor : unselectedForeColor);
            Button_Text.ForeColor = (_ColorTag == _ColorTags.Text ? selectedForeColor : unselectedForeColor);

            Color selectedBackColor = Me.RecommendColors.Main.ToColor();
            Color unselectedBackColor = Me.RecommendColors.Button.ToColor();

            Button_Background.BackColor = (_ColorTag == _ColorTags.Background ? selectedBackColor : unselectedBackColor);
            Button_Label.BackColor = (_ColorTag == _ColorTags.Label ? selectedBackColor : unselectedBackColor);
            Button_Border.BackColor = (_ColorTag == _ColorTags.Border ? selectedBackColor : unselectedBackColor);
            Button_Text.BackColor = (_ColorTag == _ColorTags.Text ? selectedBackColor : unselectedBackColor);

            Button_Background.FlatAppearance.BorderColor = Button_Background.BackColor;
            Button_Label.FlatAppearance.BorderColor = Button_Label.BackColor;
            Button_Border.FlatAppearance.BorderColor = Button_Border.BackColor;
            Button_Text.FlatAppearance.BorderColor = Button_Text.BackColor;

            Color selectedMouseOverBackColor = selectedBackColor;
            Color unselectedMouseOverBackColor = Me.RecommendColors.Button_DEC.ToColor();

            Button_Background.FlatAppearance.MouseOverBackColor = (_ColorTag == _ColorTags.Background ? selectedMouseOverBackColor : unselectedMouseOverBackColor);
            Button_Label.FlatAppearance.MouseOverBackColor = (_ColorTag == _ColorTags.Label ? selectedMouseOverBackColor : unselectedMouseOverBackColor);
            Button_Border.FlatAppearance.MouseOverBackColor = (_ColorTag == _ColorTags.Border ? selectedMouseOverBackColor : unselectedMouseOverBackColor);
            Button_Text.FlatAppearance.MouseOverBackColor = (_ColorTag == _ColorTags.Text ? selectedMouseOverBackColor : unselectedMouseOverBackColor);

            Color selectedMouseDownBackColor = selectedBackColor;
            Color unselectedMouseDownBackColor = Me.RecommendColors.Button_INC.ToColor();

            Button_Background.FlatAppearance.MouseDownBackColor = (_ColorTag == _ColorTags.Background ? selectedMouseDownBackColor : unselectedMouseDownBackColor);
            Button_Label.FlatAppearance.MouseDownBackColor = (_ColorTag == _ColorTags.Label ? selectedMouseDownBackColor : unselectedMouseDownBackColor);
            Button_Border.FlatAppearance.MouseDownBackColor = (_ColorTag == _ColorTags.Border ? selectedMouseDownBackColor : unselectedMouseDownBackColor);
            Button_Text.FlatAppearance.MouseDownBackColor = (_ColorTag == _ColorTags.Text ? selectedMouseDownBackColor : unselectedMouseDownBackColor);
        }

        #endregion

        #region 分量编辑

        private void HTrackBar_ValueChanged(object sender, EventArgs e)
        {
            HTrackBar trackBar = sender as HTrackBar;

            if (trackBar != null)
            {
                UnregisterEvents();

                //

                _CurrentTrackBarOrNumEditor = trackBar;

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

                //

                RegisterEvents();
            }
        }

        private void NumEditor_ValueChanged(object sender, EventArgs e)
        {
            NumEditor numEditor = sender as NumEditor;

            if (numEditor != null)
            {
                UnregisterEvents();

                //

                _CurrentTrackBarOrNumEditor = numEditor;

                Com.ColorX color = CurrentColor;

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

                //

                RegisterEvents();
            }
        }

        //

        private void Button_Background_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UnregisterEvents();

                //

                ChoseColor(_ColorTags.Background);

                //

                RegisterEvents();
            }
        }

        private void Button_Label_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UnregisterEvents();

                //

                ChoseColor(_ColorTags.Label);

                //

                RegisterEvents();
            }
        }

        private void Button_Border_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UnregisterEvents();

                //

                ChoseColor(_ColorTags.Border);

                //

                RegisterEvents();
            }
        }

        private void Button_Text_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UnregisterEvents();

                //

                ChoseColor(_ColorTags.Text);

                //

                RegisterEvents();
            }
        }

        #endregion

        #region 卡片控制

        // 反转卡片的折叠状态。
        private void ReverseTabFoldingState(Button btn)
        {
            if (btn.ImageIndex == 0)
            {
                int MaxHeight = btn.Bottom;

                foreach (object obj in btn.Parent.Controls)
                {
                    if (((Control)obj).Bottom > MaxHeight)
                    {
                        MaxHeight = ((Control)obj).Bottom;
                    }
                }

                int TopDist = MaxHeight;

                foreach (object obj in btn.Parent.Controls)
                {
                    if (!Control.Equals((Control)obj, btn) && ((Control)obj).Top < TopDist)
                    {
                        TopDist = ((Control)obj).Top;
                    }
                }

                btn.ImageIndex = 1;

                btn.Parent.Height = MaxHeight + TopDist - btn.Bottom;
            }
            else
            {
                btn.ImageIndex = 0;

                btn.Parent.Height = btn.Bottom;
            }

            Panel_RGB.Top = Panel_Transparency.Bottom + 10;
            Panel_HSV.Top = Panel_RGB.Bottom + 10;
            Panel_HSL.Top = Panel_HSV.Bottom + 10;
            Panel_CMYK.Top = Panel_HSL.Bottom + 10;
            Panel_LAB.Top = Panel_CMYK.Bottom + 10;
            Panel_YUV.Top = Panel_LAB.Bottom + 10;
            Panel_ColorSpaces.Height = Panel_YUV.Bottom + Panel_Transparency.Top;

            //

            _RepaintColorSpacesShadowImage();
        }

        private void Button_Transparency_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReverseTabFoldingState((Button)sender);
            }
        }

        private void Button_RGB_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReverseTabFoldingState((Button)sender);
            }
        }

        private void Button_HSV_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReverseTabFoldingState((Button)sender);
            }
        }

        private void Button_HSL_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReverseTabFoldingState((Button)sender);
            }
        }

        private void Button_CMYK_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReverseTabFoldingState((Button)sender);
            }
        }

        private void Button_LAB_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReverseTabFoldingState((Button)sender);
            }
        }

        private void Button_YUV_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReverseTabFoldingState((Button)sender);
            }
        }

        #endregion

        #region 背景绘图

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

                Control[] spaceContainers = new Control[] { Panel_Transparency, Panel_RGB, Panel_HSV, Panel_HSL, Panel_CMYK, Panel_LAB, Panel_YUV };

                Color borderColor = Color.FromArgb(16, Color.Black);

                Action<Graphics, Color, Rectangle, int> PaintShadow = (graphics, color, bounds, radius) =>
                {
                    for (int i = 0; i < radius; i++)
                    {
                        using (Pen Pn = new Pen(Color.FromArgb(color.A * (i + 1) * (i + 1) / radius / radius, color), Math.Max(1F, Math.Min(radius - i, 3F))))
                        {
                            using (GraphicsPath Path = Com.Geometry.CreateRoundedRectanglePath(new Rectangle(bounds.X - radius + i, bounds.Y - radius + i, bounds.Width + 2 * radius - 2 * i - 1, bounds.Height + 2 * radius - 2 * i - 1), radius - i + 2))
                            {
                                int N = (Pn.Width >= 3F ? 1 : (Pn.Width == 2F ? 2 : (Pn.Width == 1 ? 3 : 0)));

                                for (int j = 0; j < N; j++)
                                {
                                    graphics.DrawPath(Pn, Path);
                                }
                            }
                        }
                    }
                };

                foreach (Control ctrl in spaceContainers)
                {
                    PaintShadow(Grap, borderColor, ctrl.Bounds, 8);
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

        private Bitmap _PreviewImage = null;

        private void _UpdatePreviewImage()
        {
            if (_PreviewImage != null)
            {
                _PreviewImage.Dispose();
            }

            _PreviewImage = new Bitmap(Math.Max(1, Panel_Preview.Width), Math.Max(1, Panel_Preview.Height));

            using (Graphics Grap = Graphics.FromImage(_PreviewImage))
            {
                Grap.SmoothingMode = SmoothingMode.AntiAlias;

                Grap.Clear(Panel_Main.BackColor);

                //

                Rectangle outerBounds = new Rectangle(0, 0, _PreviewImage.Width, _PreviewImage.Height);
                Rectangle innerBounds = new Rectangle(25, 25, outerBounds.Width - 50, outerBounds.Height - 50);

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

        private void _RepaintPreviewImage()
        {
            _UpdatePreviewImage();

            if (_PreviewImage != null)
            {
                Panel_Preview.CreateGraphics().DrawImage(_PreviewImage, new Point(0, 0));
            }
        }

        private void Panel_Preview_Paint(object sender, PaintEventArgs e)
        {
            if (_PreviewImage == null)
            {
                _UpdatePreviewImage();
            }

            if (_PreviewImage != null)
            {
                e.Graphics.DrawImage(_PreviewImage, new Point(0, 0));
            }
        }

        #endregion
    }
}