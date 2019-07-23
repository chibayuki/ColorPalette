namespace WinFormApp
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.Panel_Main = new System.Windows.Forms.Panel();
            this.Panel_LeftArea = new System.Windows.Forms.Panel();
            this.Panel_EditingColors = new System.Windows.Forms.Panel();
            this.Panel_Info = new System.Windows.Forms.Panel();
            this.Button_Info = new System.Windows.Forms.Button();
            this.ImageList_FoldAndUnfold = new System.Windows.Forms.ImageList(this.components);
            this.Label_CurrentColor = new System.Windows.Forms.Label();
            this.Label_Name = new System.Windows.Forms.Label();
            this.Label_Name_Val = new System.Windows.Forms.Label();
            this.Label_Grayscale = new System.Windows.Forms.Label();
            this.Label_Grayscale_Val = new System.Windows.Forms.Label();
            this.Label_Grayscale_Val2 = new System.Windows.Forms.Label();
            this.Label_Complementary = new System.Windows.Forms.Label();
            this.Label_Complementary_Val = new System.Windows.Forms.Label();
            this.Panel_View = new System.Windows.Forms.Panel();
            this.Button_View = new System.Windows.Forms.Button();
            this.Button_Background = new System.Windows.Forms.Button();
            this.Button_Label = new System.Windows.Forms.Button();
            this.Button_Border = new System.Windows.Forms.Button();
            this.Button_Text = new System.Windows.Forms.Button();
            this.Panel_Div = new System.Windows.Forms.Panel();
            this.Panel_RightArea = new System.Windows.Forms.Panel();
            this.Panel_ColorSpaces = new System.Windows.Forms.Panel();
            this.Panel_Transparency = new System.Windows.Forms.Panel();
            this.Button_Transparency = new System.Windows.Forms.Button();
            this.Label_Abbr_Opacity = new System.Windows.Forms.Label();
            this.Label_Abbr_Alpha = new System.Windows.Forms.Label();
            this.Label_Opacity = new System.Windows.Forms.Label();
            this.Label_Alpha = new System.Windows.Forms.Label();
            this.Panel_RGB = new System.Windows.Forms.Panel();
            this.Button_RGB = new System.Windows.Forms.Button();
            this.Label_Abbr_RGB_R = new System.Windows.Forms.Label();
            this.Label_Abbr_RGB_G = new System.Windows.Forms.Label();
            this.Label_Abbr_RGB_B = new System.Windows.Forms.Label();
            this.Label_RGB_R = new System.Windows.Forms.Label();
            this.Label_RGB_G = new System.Windows.Forms.Label();
            this.Label_RGB_B = new System.Windows.Forms.Label();
            this.Panel_HSV = new System.Windows.Forms.Panel();
            this.Button_HSV = new System.Windows.Forms.Button();
            this.Label_Abbr_HSV_H = new System.Windows.Forms.Label();
            this.Label_Abbr_HSV_S = new System.Windows.Forms.Label();
            this.Label_Abbr_HSV_V = new System.Windows.Forms.Label();
            this.Label_HSV_H = new System.Windows.Forms.Label();
            this.Label_HSV_S = new System.Windows.Forms.Label();
            this.Label_HSV_V = new System.Windows.Forms.Label();
            this.Panel_HSL = new System.Windows.Forms.Panel();
            this.Button_HSL = new System.Windows.Forms.Button();
            this.Label_Abbr_HSL_H = new System.Windows.Forms.Label();
            this.Label_Abbr_HSL_S = new System.Windows.Forms.Label();
            this.Label_Abbr_HSL_L = new System.Windows.Forms.Label();
            this.Label_HSL_H = new System.Windows.Forms.Label();
            this.Label_HSL_S = new System.Windows.Forms.Label();
            this.Label_HSL_L = new System.Windows.Forms.Label();
            this.Panel_CMYK = new System.Windows.Forms.Panel();
            this.Button_CMYK = new System.Windows.Forms.Button();
            this.Label_Abbr_CMYK_C = new System.Windows.Forms.Label();
            this.Label_Abbr_CMYK_M = new System.Windows.Forms.Label();
            this.Label_Abbr_CMYK_Y = new System.Windows.Forms.Label();
            this.Label_Abbr_CMYK_K = new System.Windows.Forms.Label();
            this.Label_CMYK_C = new System.Windows.Forms.Label();
            this.Label_CMYK_M = new System.Windows.Forms.Label();
            this.Label_CMYK_Y = new System.Windows.Forms.Label();
            this.Label_CMYK_K = new System.Windows.Forms.Label();
            this.Panel_LAB = new System.Windows.Forms.Panel();
            this.Button_LAB = new System.Windows.Forms.Button();
            this.Label_Abbr_LAB_L = new System.Windows.Forms.Label();
            this.Label_Abbr_LAB_A = new System.Windows.Forms.Label();
            this.Label_Abbr_LAB_B = new System.Windows.Forms.Label();
            this.Label_LAB_L = new System.Windows.Forms.Label();
            this.Label_LAB_A = new System.Windows.Forms.Label();
            this.Label_LAB_B = new System.Windows.Forms.Label();
            this.Panel_YUV = new System.Windows.Forms.Panel();
            this.Button_YUV = new System.Windows.Forms.Button();
            this.Label_Abbr_YUV_Y = new System.Windows.Forms.Label();
            this.Label_Abbr_YUV_U = new System.Windows.Forms.Label();
            this.Label_Abbr_YUV_V = new System.Windows.Forms.Label();
            this.Label_YUV_Y = new System.Windows.Forms.Label();
            this.Label_YUV_U = new System.Windows.Forms.Label();
            this.Label_YUV_V = new System.Windows.Forms.Label();
            this.NumEditor_Opacity = new WinFormApp.NumEditor();
            this.NumEditor_Alpha = new WinFormApp.NumEditor();
            this.HTrackBar_Opacity = new WinFormApp.HTrackBar();
            this.HTrackBar_Alpha = new WinFormApp.HTrackBar();
            this.NumEditor_RGB_R = new WinFormApp.NumEditor();
            this.NumEditor_RGB_G = new WinFormApp.NumEditor();
            this.NumEditor_RGB_B = new WinFormApp.NumEditor();
            this.HTrackBar_RGB_R = new WinFormApp.HTrackBar();
            this.HTrackBar_RGB_G = new WinFormApp.HTrackBar();
            this.HTrackBar_RGB_B = new WinFormApp.HTrackBar();
            this.NumEditor_HSV_H = new WinFormApp.NumEditor();
            this.NumEditor_HSV_S = new WinFormApp.NumEditor();
            this.NumEditor_HSV_V = new WinFormApp.NumEditor();
            this.HTrackBar_HSV_H = new WinFormApp.HTrackBar();
            this.HTrackBar_HSV_S = new WinFormApp.HTrackBar();
            this.HTrackBar_HSV_V = new WinFormApp.HTrackBar();
            this.NumEditor_HSL_H = new WinFormApp.NumEditor();
            this.NumEditor_HSL_S = new WinFormApp.NumEditor();
            this.NumEditor_HSL_L = new WinFormApp.NumEditor();
            this.HTrackBar_HSL_H = new WinFormApp.HTrackBar();
            this.HTrackBar_HSL_S = new WinFormApp.HTrackBar();
            this.HTrackBar_HSL_L = new WinFormApp.HTrackBar();
            this.NumEditor_CMYK_K = new WinFormApp.NumEditor();
            this.NumEditor_CMYK_C = new WinFormApp.NumEditor();
            this.NumEditor_CMYK_M = new WinFormApp.NumEditor();
            this.NumEditor_CMYK_Y = new WinFormApp.NumEditor();
            this.HTrackBar_CMYK_C = new WinFormApp.HTrackBar();
            this.HTrackBar_CMYK_M = new WinFormApp.HTrackBar();
            this.HTrackBar_CMYK_Y = new WinFormApp.HTrackBar();
            this.HTrackBar_CMYK_K = new WinFormApp.HTrackBar();
            this.NumEditor_LAB_L = new WinFormApp.NumEditor();
            this.NumEditor_LAB_A = new WinFormApp.NumEditor();
            this.NumEditor_LAB_B = new WinFormApp.NumEditor();
            this.HTrackBar_LAB_L = new WinFormApp.HTrackBar();
            this.HTrackBar_LAB_A = new WinFormApp.HTrackBar();
            this.HTrackBar_LAB_B = new WinFormApp.HTrackBar();
            this.NumEditor_YUV_Y = new WinFormApp.NumEditor();
            this.NumEditor_YUV_U = new WinFormApp.NumEditor();
            this.NumEditor_YUV_V = new WinFormApp.NumEditor();
            this.HTrackBar_YUV_Y = new WinFormApp.HTrackBar();
            this.HTrackBar_YUV_U = new WinFormApp.HTrackBar();
            this.HTrackBar_YUV_V = new WinFormApp.HTrackBar();
            this.Panel_Main.SuspendLayout();
            this.Panel_LeftArea.SuspendLayout();
            this.Panel_EditingColors.SuspendLayout();
            this.Panel_Info.SuspendLayout();
            this.Panel_View.SuspendLayout();
            this.Panel_RightArea.SuspendLayout();
            this.Panel_ColorSpaces.SuspendLayout();
            this.Panel_Transparency.SuspendLayout();
            this.Panel_RGB.SuspendLayout();
            this.Panel_HSV.SuspendLayout();
            this.Panel_HSL.SuspendLayout();
            this.Panel_CMYK.SuspendLayout();
            this.Panel_LAB.SuspendLayout();
            this.Panel_YUV.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Main
            // 
            this.Panel_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Panel_Main.Controls.Add(this.Panel_LeftArea);
            this.Panel_Main.Controls.Add(this.Panel_RightArea);
            this.Panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Main.Location = new System.Drawing.Point(0, 0);
            this.Panel_Main.Name = "Panel_Main";
            this.Panel_Main.Size = new System.Drawing.Size(1100, 545);
            this.Panel_Main.TabIndex = 0;
            // 
            // Panel_LeftArea
            // 
            this.Panel_LeftArea.AutoScroll = true;
            this.Panel_LeftArea.BackColor = System.Drawing.Color.Transparent;
            this.Panel_LeftArea.Controls.Add(this.Panel_EditingColors);
            this.Panel_LeftArea.Location = new System.Drawing.Point(0, 0);
            this.Panel_LeftArea.Name = "Panel_LeftArea";
            this.Panel_LeftArea.Size = new System.Drawing.Size(400, 545);
            this.Panel_LeftArea.TabIndex = 0;
            // 
            // Panel_EditingColors
            // 
            this.Panel_EditingColors.BackColor = System.Drawing.Color.Transparent;
            this.Panel_EditingColors.Controls.Add(this.Panel_Info);
            this.Panel_EditingColors.Controls.Add(this.Panel_View);
            this.Panel_EditingColors.Location = new System.Drawing.Point(0, 0);
            this.Panel_EditingColors.Name = "Panel_EditingColors";
            this.Panel_EditingColors.Size = new System.Drawing.Size(380, 375);
            this.Panel_EditingColors.TabIndex = 0;
            this.Panel_EditingColors.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_EditingColors_Paint);
            // 
            // Panel_Info
            // 
            this.Panel_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Panel_Info.Controls.Add(this.Button_Info);
            this.Panel_Info.Controls.Add(this.Label_CurrentColor);
            this.Panel_Info.Controls.Add(this.Label_Name);
            this.Panel_Info.Controls.Add(this.Label_Name_Val);
            this.Panel_Info.Controls.Add(this.Label_Grayscale);
            this.Panel_Info.Controls.Add(this.Label_Grayscale_Val);
            this.Panel_Info.Controls.Add(this.Label_Grayscale_Val2);
            this.Panel_Info.Controls.Add(this.Label_Complementary);
            this.Panel_Info.Controls.Add(this.Label_Complementary_Val);
            this.Panel_Info.Location = new System.Drawing.Point(20, 20);
            this.Panel_Info.Name = "Panel_Info";
            this.Panel_Info.Size = new System.Drawing.Size(340, 150);
            this.Panel_Info.TabIndex = 0;
            // 
            // Button_Info
            // 
            this.Button_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Button_Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_Info.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button_Info.FlatAppearance.BorderSize = 0;
            this.Button_Info.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Info.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Info.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button_Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_Info.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Info.ImageIndex = 1;
            this.Button_Info.ImageList = this.ImageList_FoldAndUnfold;
            this.Button_Info.Location = new System.Drawing.Point(0, 0);
            this.Button_Info.Name = "Button_Info";
            this.Button_Info.Size = new System.Drawing.Size(340, 30);
            this.Button_Info.TabIndex = 0;
            this.Button_Info.TabStop = false;
            this.Button_Info.Text = "信息";
            this.Button_Info.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_Info.UseVisualStyleBackColor = false;
            this.Button_Info.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Info_MouseDown);
            // 
            // ImageList_FoldAndUnfold
            // 
            this.ImageList_FoldAndUnfold.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList_FoldAndUnfold.ImageStream")));
            this.ImageList_FoldAndUnfold.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList_FoldAndUnfold.Images.SetKeyName(0, "ToSpread_Flat_16.png");
            this.ImageList_FoldAndUnfold.Images.SetKeyName(1, "ToFold_Flat_16.png");
            // 
            // Label_CurrentColor
            // 
            this.Label_CurrentColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_CurrentColor.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_CurrentColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_CurrentColor.Location = new System.Drawing.Point(20, 40);
            this.Label_CurrentColor.Name = "Label_CurrentColor";
            this.Label_CurrentColor.Size = new System.Drawing.Size(100, 100);
            this.Label_CurrentColor.TabIndex = 0;
            this.Label_CurrentColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.BackColor = System.Drawing.Color.Transparent;
            this.Label_Name.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Name.ForeColor = System.Drawing.Color.Silver;
            this.Label_Name.Location = new System.Drawing.Point(130, 40);
            this.Label_Name.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Name.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(35, 25);
            this.Label_Name.TabIndex = 0;
            this.Label_Name.Text = "名称";
            this.Label_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Name_Val
            // 
            this.Label_Name_Val.AutoSize = true;
            this.Label_Name_Val.BackColor = System.Drawing.Color.Transparent;
            this.Label_Name_Val.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Name_Val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_Name_Val.Location = new System.Drawing.Point(190, 40);
            this.Label_Name_Val.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Name_Val.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Name_Val.Name = "Label_Name_Val";
            this.Label_Name_Val.Size = new System.Drawing.Size(83, 25);
            this.Label_Name_Val.TabIndex = 0;
            this.Label_Name_Val.Text = "Color Name";
            this.Label_Name_Val.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Grayscale
            // 
            this.Label_Grayscale.AutoSize = true;
            this.Label_Grayscale.BackColor = System.Drawing.Color.Transparent;
            this.Label_Grayscale.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Grayscale.ForeColor = System.Drawing.Color.Silver;
            this.Label_Grayscale.Location = new System.Drawing.Point(130, 75);
            this.Label_Grayscale.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Grayscale.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Grayscale.Name = "Label_Grayscale";
            this.Label_Grayscale.Size = new System.Drawing.Size(35, 25);
            this.Label_Grayscale.TabIndex = 0;
            this.Label_Grayscale.Text = "灰度";
            this.Label_Grayscale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Grayscale_Val
            // 
            this.Label_Grayscale_Val.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_Grayscale_Val.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Grayscale_Val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_Grayscale_Val.Location = new System.Drawing.Point(190, 75);
            this.Label_Grayscale_Val.Name = "Label_Grayscale_Val";
            this.Label_Grayscale_Val.Size = new System.Drawing.Size(60, 25);
            this.Label_Grayscale_Val.TabIndex = 0;
            this.Label_Grayscale_Val.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Grayscale_Val2
            // 
            this.Label_Grayscale_Val2.AutoSize = true;
            this.Label_Grayscale_Val2.BackColor = System.Drawing.Color.Transparent;
            this.Label_Grayscale_Val2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Grayscale_Val2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_Grayscale_Val2.Location = new System.Drawing.Point(260, 75);
            this.Label_Grayscale_Val2.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Grayscale_Val2.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Grayscale_Val2.Name = "Label_Grayscale_Val2";
            this.Label_Grayscale_Val2.Size = new System.Drawing.Size(68, 25);
            this.Label_Grayscale_Val2.TabIndex = 0;
            this.Label_Grayscale_Val2.Text = "Grayscale";
            this.Label_Grayscale_Val2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Complementary
            // 
            this.Label_Complementary.AutoSize = true;
            this.Label_Complementary.BackColor = System.Drawing.Color.Transparent;
            this.Label_Complementary.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Complementary.ForeColor = System.Drawing.Color.Silver;
            this.Label_Complementary.Location = new System.Drawing.Point(130, 110);
            this.Label_Complementary.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Complementary.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Complementary.Name = "Label_Complementary";
            this.Label_Complementary.Size = new System.Drawing.Size(48, 25);
            this.Label_Complementary.TabIndex = 0;
            this.Label_Complementary.Text = "互补色";
            this.Label_Complementary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Complementary_Val
            // 
            this.Label_Complementary_Val.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_Complementary_Val.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Complementary_Val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_Complementary_Val.Location = new System.Drawing.Point(190, 110);
            this.Label_Complementary_Val.Name = "Label_Complementary_Val";
            this.Label_Complementary_Val.Size = new System.Drawing.Size(60, 25);
            this.Label_Complementary_Val.TabIndex = 0;
            this.Label_Complementary_Val.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel_View
            // 
            this.Panel_View.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Panel_View.Controls.Add(this.Button_View);
            this.Panel_View.Controls.Add(this.Button_Background);
            this.Panel_View.Controls.Add(this.Button_Label);
            this.Panel_View.Controls.Add(this.Button_Border);
            this.Panel_View.Controls.Add(this.Button_Text);
            this.Panel_View.Controls.Add(this.Panel_Div);
            this.Panel_View.Location = new System.Drawing.Point(20, 185);
            this.Panel_View.Name = "Panel_View";
            this.Panel_View.Size = new System.Drawing.Size(340, 170);
            this.Panel_View.TabIndex = 0;
            // 
            // Button_View
            // 
            this.Button_View.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Button_View.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_View.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button_View.FlatAppearance.BorderSize = 0;
            this.Button_View.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_View.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_View.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_View.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button_View.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_View.ImageIndex = 1;
            this.Button_View.ImageList = this.ImageList_FoldAndUnfold;
            this.Button_View.Location = new System.Drawing.Point(0, 0);
            this.Button_View.Name = "Button_View";
            this.Button_View.Size = new System.Drawing.Size(340, 30);
            this.Button_View.TabIndex = 0;
            this.Button_View.TabStop = false;
            this.Button_View.Text = "视图";
            this.Button_View.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_View.UseVisualStyleBackColor = false;
            this.Button_View.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_View_MouseDown);
            // 
            // Button_Background
            // 
            this.Button_Background.BackColor = System.Drawing.Color.Transparent;
            this.Button_Background.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button_Background.FlatAppearance.BorderSize = 0;
            this.Button_Background.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Background.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Background.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Background.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button_Background.ForeColor = System.Drawing.Color.Silver;
            this.Button_Background.Location = new System.Drawing.Point(20, 40);
            this.Button_Background.Name = "Button_Background";
            this.Button_Background.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Button_Background.Size = new System.Drawing.Size(100, 30);
            this.Button_Background.TabIndex = 0;
            this.Button_Background.TabStop = false;
            this.Button_Background.Text = "背景";
            this.Button_Background.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Background.UseVisualStyleBackColor = false;
            this.Button_Background.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Background_MouseDown);
            // 
            // Button_Label
            // 
            this.Button_Label.BackColor = System.Drawing.Color.Transparent;
            this.Button_Label.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button_Label.FlatAppearance.BorderSize = 0;
            this.Button_Label.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Label.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Label.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button_Label.ForeColor = System.Drawing.Color.Silver;
            this.Button_Label.Location = new System.Drawing.Point(20, 70);
            this.Button_Label.Name = "Button_Label";
            this.Button_Label.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Button_Label.Size = new System.Drawing.Size(100, 30);
            this.Button_Label.TabIndex = 0;
            this.Button_Label.TabStop = false;
            this.Button_Label.Text = "标签";
            this.Button_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Label.UseVisualStyleBackColor = false;
            this.Button_Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Label_MouseDown);
            // 
            // Button_Border
            // 
            this.Button_Border.BackColor = System.Drawing.Color.Transparent;
            this.Button_Border.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button_Border.FlatAppearance.BorderSize = 0;
            this.Button_Border.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Border.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Border.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Border.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button_Border.ForeColor = System.Drawing.Color.Silver;
            this.Button_Border.Location = new System.Drawing.Point(20, 100);
            this.Button_Border.Name = "Button_Border";
            this.Button_Border.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Button_Border.Size = new System.Drawing.Size(100, 30);
            this.Button_Border.TabIndex = 0;
            this.Button_Border.TabStop = false;
            this.Button_Border.Text = "边框";
            this.Button_Border.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Border.UseVisualStyleBackColor = false;
            this.Button_Border.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Border_MouseDown);
            // 
            // Button_Text
            // 
            this.Button_Text.BackColor = System.Drawing.Color.Transparent;
            this.Button_Text.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button_Text.FlatAppearance.BorderSize = 0;
            this.Button_Text.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Text.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Text.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Text.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button_Text.ForeColor = System.Drawing.Color.Silver;
            this.Button_Text.Location = new System.Drawing.Point(20, 130);
            this.Button_Text.Name = "Button_Text";
            this.Button_Text.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Button_Text.Size = new System.Drawing.Size(100, 30);
            this.Button_Text.TabIndex = 0;
            this.Button_Text.TabStop = false;
            this.Button_Text.Text = "文本";
            this.Button_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Text.UseVisualStyleBackColor = false;
            this.Button_Text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Text_MouseDown);
            // 
            // Panel_Div
            // 
            this.Panel_Div.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Div.Location = new System.Drawing.Point(130, 40);
            this.Panel_Div.Name = "Panel_Div";
            this.Panel_Div.Size = new System.Drawing.Size(190, 120);
            this.Panel_Div.TabIndex = 0;
            this.Panel_Div.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Div_Paint);
            // 
            // Panel_RightArea
            // 
            this.Panel_RightArea.AutoScroll = true;
            this.Panel_RightArea.BackColor = System.Drawing.Color.Transparent;
            this.Panel_RightArea.Controls.Add(this.Panel_ColorSpaces);
            this.Panel_RightArea.Location = new System.Drawing.Point(400, 0);
            this.Panel_RightArea.Name = "Panel_RightArea";
            this.Panel_RightArea.Size = new System.Drawing.Size(700, 545);
            this.Panel_RightArea.TabIndex = 0;
            // 
            // Panel_ColorSpaces
            // 
            this.Panel_ColorSpaces.BackColor = System.Drawing.Color.Transparent;
            this.Panel_ColorSpaces.Controls.Add(this.Panel_Transparency);
            this.Panel_ColorSpaces.Controls.Add(this.Panel_RGB);
            this.Panel_ColorSpaces.Controls.Add(this.Panel_HSV);
            this.Panel_ColorSpaces.Controls.Add(this.Panel_HSL);
            this.Panel_ColorSpaces.Controls.Add(this.Panel_CMYK);
            this.Panel_ColorSpaces.Controls.Add(this.Panel_LAB);
            this.Panel_ColorSpaces.Controls.Add(this.Panel_YUV);
            this.Panel_ColorSpaces.Location = new System.Drawing.Point(0, 0);
            this.Panel_ColorSpaces.Name = "Panel_ColorSpaces";
            this.Panel_ColorSpaces.Size = new System.Drawing.Size(680, 1145);
            this.Panel_ColorSpaces.TabIndex = 0;
            this.Panel_ColorSpaces.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_ColorSpaces_Paint);
            // 
            // Panel_Transparency
            // 
            this.Panel_Transparency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Panel_Transparency.Controls.Add(this.Button_Transparency);
            this.Panel_Transparency.Controls.Add(this.Label_Abbr_Opacity);
            this.Panel_Transparency.Controls.Add(this.Label_Abbr_Alpha);
            this.Panel_Transparency.Controls.Add(this.Label_Opacity);
            this.Panel_Transparency.Controls.Add(this.Label_Alpha);
            this.Panel_Transparency.Controls.Add(this.NumEditor_Opacity);
            this.Panel_Transparency.Controls.Add(this.NumEditor_Alpha);
            this.Panel_Transparency.Controls.Add(this.HTrackBar_Opacity);
            this.Panel_Transparency.Controls.Add(this.HTrackBar_Alpha);
            this.Panel_Transparency.Location = new System.Drawing.Point(20, 20);
            this.Panel_Transparency.Name = "Panel_Transparency";
            this.Panel_Transparency.Size = new System.Drawing.Size(640, 110);
            this.Panel_Transparency.TabIndex = 0;
            // 
            // Button_Transparency
            // 
            this.Button_Transparency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Button_Transparency.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_Transparency.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button_Transparency.FlatAppearance.BorderSize = 0;
            this.Button_Transparency.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Transparency.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Transparency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Transparency.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button_Transparency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_Transparency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Transparency.ImageIndex = 1;
            this.Button_Transparency.ImageList = this.ImageList_FoldAndUnfold;
            this.Button_Transparency.Location = new System.Drawing.Point(0, 0);
            this.Button_Transparency.Name = "Button_Transparency";
            this.Button_Transparency.Size = new System.Drawing.Size(640, 30);
            this.Button_Transparency.TabIndex = 0;
            this.Button_Transparency.TabStop = false;
            this.Button_Transparency.Text = "不透明度";
            this.Button_Transparency.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_Transparency.UseVisualStyleBackColor = false;
            this.Button_Transparency.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Transparency_MouseDown);
            // 
            // Label_Abbr_Opacity
            // 
            this.Label_Abbr_Opacity.AutoSize = true;
            this.Label_Abbr_Opacity.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_Opacity.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_Opacity.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_Opacity.Location = new System.Drawing.Point(20, 35);
            this.Label_Abbr_Opacity.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_Opacity.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_Opacity.Name = "Label_Abbr_Opacity";
            this.Label_Abbr_Opacity.Size = new System.Drawing.Size(13, 25);
            this.Label_Abbr_Opacity.TabIndex = 0;
            this.Label_Abbr_Opacity.Text = " ";
            this.Label_Abbr_Opacity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Abbr_Alpha
            // 
            this.Label_Abbr_Alpha.AutoSize = true;
            this.Label_Abbr_Alpha.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_Alpha.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_Alpha.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_Alpha.Location = new System.Drawing.Point(20, 75);
            this.Label_Abbr_Alpha.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_Alpha.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_Alpha.Name = "Label_Abbr_Alpha";
            this.Label_Abbr_Alpha.Size = new System.Drawing.Size(19, 25);
            this.Label_Abbr_Alpha.TabIndex = 0;
            this.Label_Abbr_Alpha.Text = "A";
            this.Label_Abbr_Alpha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Opacity
            // 
            this.Label_Opacity.AutoSize = true;
            this.Label_Opacity.BackColor = System.Drawing.Color.Transparent;
            this.Label_Opacity.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Opacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_Opacity.Location = new System.Drawing.Point(50, 40);
            this.Label_Opacity.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Opacity.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Opacity.Name = "Label_Opacity";
            this.Label_Opacity.Size = new System.Drawing.Size(57, 25);
            this.Label_Opacity.TabIndex = 0;
            this.Label_Opacity.Text = "Opacity";
            this.Label_Opacity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Alpha
            // 
            this.Label_Alpha.AutoSize = true;
            this.Label_Alpha.BackColor = System.Drawing.Color.Transparent;
            this.Label_Alpha.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Alpha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_Alpha.Location = new System.Drawing.Point(50, 75);
            this.Label_Alpha.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Alpha.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Alpha.Name = "Label_Alpha";
            this.Label_Alpha.Size = new System.Drawing.Size(44, 25);
            this.Label_Alpha.TabIndex = 0;
            this.Label_Alpha.Text = "Alpha";
            this.Label_Alpha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel_RGB
            // 
            this.Panel_RGB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Panel_RGB.Controls.Add(this.Button_RGB);
            this.Panel_RGB.Controls.Add(this.Label_Abbr_RGB_R);
            this.Panel_RGB.Controls.Add(this.Label_Abbr_RGB_G);
            this.Panel_RGB.Controls.Add(this.Label_Abbr_RGB_B);
            this.Panel_RGB.Controls.Add(this.Label_RGB_R);
            this.Panel_RGB.Controls.Add(this.Label_RGB_G);
            this.Panel_RGB.Controls.Add(this.Label_RGB_B);
            this.Panel_RGB.Controls.Add(this.NumEditor_RGB_R);
            this.Panel_RGB.Controls.Add(this.NumEditor_RGB_G);
            this.Panel_RGB.Controls.Add(this.NumEditor_RGB_B);
            this.Panel_RGB.Controls.Add(this.HTrackBar_RGB_R);
            this.Panel_RGB.Controls.Add(this.HTrackBar_RGB_G);
            this.Panel_RGB.Controls.Add(this.HTrackBar_RGB_B);
            this.Panel_RGB.Location = new System.Drawing.Point(20, 145);
            this.Panel_RGB.Name = "Panel_RGB";
            this.Panel_RGB.Size = new System.Drawing.Size(640, 145);
            this.Panel_RGB.TabIndex = 0;
            // 
            // Button_RGB
            // 
            this.Button_RGB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Button_RGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_RGB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button_RGB.FlatAppearance.BorderSize = 0;
            this.Button_RGB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_RGB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_RGB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_RGB.Font = new System.Drawing.Font("微软雅黑", 11.25F);
            this.Button_RGB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_RGB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_RGB.ImageIndex = 1;
            this.Button_RGB.ImageList = this.ImageList_FoldAndUnfold;
            this.Button_RGB.Location = new System.Drawing.Point(0, 0);
            this.Button_RGB.Name = "Button_RGB";
            this.Button_RGB.Size = new System.Drawing.Size(640, 30);
            this.Button_RGB.TabIndex = 0;
            this.Button_RGB.TabStop = false;
            this.Button_RGB.Text = "RGB";
            this.Button_RGB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_RGB.UseVisualStyleBackColor = false;
            this.Button_RGB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_RGB_MouseDown);
            // 
            // Label_Abbr_RGB_R
            // 
            this.Label_Abbr_RGB_R.AutoSize = true;
            this.Label_Abbr_RGB_R.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_RGB_R.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_RGB_R.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_RGB_R.Location = new System.Drawing.Point(20, 40);
            this.Label_Abbr_RGB_R.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_RGB_R.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_RGB_R.Name = "Label_Abbr_RGB_R";
            this.Label_Abbr_RGB_R.Size = new System.Drawing.Size(18, 25);
            this.Label_Abbr_RGB_R.TabIndex = 0;
            this.Label_Abbr_RGB_R.Text = "R";
            this.Label_Abbr_RGB_R.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Abbr_RGB_G
            // 
            this.Label_Abbr_RGB_G.AutoSize = true;
            this.Label_Abbr_RGB_G.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_RGB_G.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_RGB_G.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_RGB_G.Location = new System.Drawing.Point(20, 75);
            this.Label_Abbr_RGB_G.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_RGB_G.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_RGB_G.Name = "Label_Abbr_RGB_G";
            this.Label_Abbr_RGB_G.Size = new System.Drawing.Size(19, 25);
            this.Label_Abbr_RGB_G.TabIndex = 0;
            this.Label_Abbr_RGB_G.Text = "G";
            this.Label_Abbr_RGB_G.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Abbr_RGB_B
            // 
            this.Label_Abbr_RGB_B.AutoSize = true;
            this.Label_Abbr_RGB_B.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_RGB_B.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_RGB_B.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_RGB_B.Location = new System.Drawing.Point(20, 110);
            this.Label_Abbr_RGB_B.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_RGB_B.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_RGB_B.Name = "Label_Abbr_RGB_B";
            this.Label_Abbr_RGB_B.Size = new System.Drawing.Size(18, 25);
            this.Label_Abbr_RGB_B.TabIndex = 0;
            this.Label_Abbr_RGB_B.Text = "B";
            this.Label_Abbr_RGB_B.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_RGB_R
            // 
            this.Label_RGB_R.AutoSize = true;
            this.Label_RGB_R.BackColor = System.Drawing.Color.Transparent;
            this.Label_RGB_R.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_RGB_R.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_RGB_R.Location = new System.Drawing.Point(50, 40);
            this.Label_RGB_R.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_RGB_R.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_RGB_R.Name = "Label_RGB_R";
            this.Label_RGB_R.Size = new System.Drawing.Size(32, 25);
            this.Label_RGB_R.TabIndex = 0;
            this.Label_RGB_R.Text = "Red";
            this.Label_RGB_R.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_RGB_G
            // 
            this.Label_RGB_G.AutoSize = true;
            this.Label_RGB_G.BackColor = System.Drawing.Color.Transparent;
            this.Label_RGB_G.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_RGB_G.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_RGB_G.Location = new System.Drawing.Point(50, 75);
            this.Label_RGB_G.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_RGB_G.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_RGB_G.Name = "Label_RGB_G";
            this.Label_RGB_G.Size = new System.Drawing.Size(46, 25);
            this.Label_RGB_G.TabIndex = 0;
            this.Label_RGB_G.Text = "Green";
            this.Label_RGB_G.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_RGB_B
            // 
            this.Label_RGB_B.AutoSize = true;
            this.Label_RGB_B.BackColor = System.Drawing.Color.Transparent;
            this.Label_RGB_B.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_RGB_B.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_RGB_B.Location = new System.Drawing.Point(50, 110);
            this.Label_RGB_B.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_RGB_B.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_RGB_B.Name = "Label_RGB_B";
            this.Label_RGB_B.Size = new System.Drawing.Size(35, 25);
            this.Label_RGB_B.TabIndex = 0;
            this.Label_RGB_B.Text = "Blue";
            this.Label_RGB_B.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel_HSV
            // 
            this.Panel_HSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Panel_HSV.Controls.Add(this.Button_HSV);
            this.Panel_HSV.Controls.Add(this.Label_Abbr_HSV_H);
            this.Panel_HSV.Controls.Add(this.Label_Abbr_HSV_S);
            this.Panel_HSV.Controls.Add(this.Label_Abbr_HSV_V);
            this.Panel_HSV.Controls.Add(this.Label_HSV_H);
            this.Panel_HSV.Controls.Add(this.Label_HSV_S);
            this.Panel_HSV.Controls.Add(this.Label_HSV_V);
            this.Panel_HSV.Controls.Add(this.NumEditor_HSV_H);
            this.Panel_HSV.Controls.Add(this.NumEditor_HSV_S);
            this.Panel_HSV.Controls.Add(this.NumEditor_HSV_V);
            this.Panel_HSV.Controls.Add(this.HTrackBar_HSV_H);
            this.Panel_HSV.Controls.Add(this.HTrackBar_HSV_S);
            this.Panel_HSV.Controls.Add(this.HTrackBar_HSV_V);
            this.Panel_HSV.Location = new System.Drawing.Point(20, 305);
            this.Panel_HSV.Name = "Panel_HSV";
            this.Panel_HSV.Size = new System.Drawing.Size(640, 145);
            this.Panel_HSV.TabIndex = 0;
            // 
            // Button_HSV
            // 
            this.Button_HSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Button_HSV.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_HSV.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button_HSV.FlatAppearance.BorderSize = 0;
            this.Button_HSV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_HSV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_HSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_HSV.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button_HSV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_HSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_HSV.ImageIndex = 1;
            this.Button_HSV.ImageList = this.ImageList_FoldAndUnfold;
            this.Button_HSV.Location = new System.Drawing.Point(0, 0);
            this.Button_HSV.Name = "Button_HSV";
            this.Button_HSV.Size = new System.Drawing.Size(640, 30);
            this.Button_HSV.TabIndex = 0;
            this.Button_HSV.TabStop = false;
            this.Button_HSV.Text = "HSV";
            this.Button_HSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_HSV.UseVisualStyleBackColor = false;
            this.Button_HSV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_HSV_MouseDown);
            // 
            // Label_Abbr_HSV_H
            // 
            this.Label_Abbr_HSV_H.AutoSize = true;
            this.Label_Abbr_HSV_H.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_HSV_H.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_HSV_H.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_HSV_H.Location = new System.Drawing.Point(20, 40);
            this.Label_Abbr_HSV_H.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_HSV_H.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_HSV_H.Name = "Label_Abbr_HSV_H";
            this.Label_Abbr_HSV_H.Size = new System.Drawing.Size(20, 25);
            this.Label_Abbr_HSV_H.TabIndex = 0;
            this.Label_Abbr_HSV_H.Text = "H";
            this.Label_Abbr_HSV_H.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Abbr_HSV_S
            // 
            this.Label_Abbr_HSV_S.AutoSize = true;
            this.Label_Abbr_HSV_S.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_HSV_S.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_HSV_S.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_HSV_S.Location = new System.Drawing.Point(20, 75);
            this.Label_Abbr_HSV_S.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_HSV_S.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_HSV_S.Name = "Label_Abbr_HSV_S";
            this.Label_Abbr_HSV_S.Size = new System.Drawing.Size(17, 25);
            this.Label_Abbr_HSV_S.TabIndex = 0;
            this.Label_Abbr_HSV_S.Text = "S";
            this.Label_Abbr_HSV_S.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Abbr_HSV_V
            // 
            this.Label_Abbr_HSV_V.AutoSize = true;
            this.Label_Abbr_HSV_V.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_HSV_V.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_HSV_V.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_HSV_V.Location = new System.Drawing.Point(20, 110);
            this.Label_Abbr_HSV_V.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_HSV_V.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_HSV_V.Name = "Label_Abbr_HSV_V";
            this.Label_Abbr_HSV_V.Size = new System.Drawing.Size(18, 25);
            this.Label_Abbr_HSV_V.TabIndex = 0;
            this.Label_Abbr_HSV_V.Text = "V";
            this.Label_Abbr_HSV_V.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_HSV_H
            // 
            this.Label_HSV_H.AutoSize = true;
            this.Label_HSV_H.BackColor = System.Drawing.Color.Transparent;
            this.Label_HSV_H.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_HSV_H.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_HSV_H.Location = new System.Drawing.Point(50, 40);
            this.Label_HSV_H.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_HSV_H.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_HSV_H.Name = "Label_HSV_H";
            this.Label_HSV_H.Size = new System.Drawing.Size(34, 25);
            this.Label_HSV_H.TabIndex = 0;
            this.Label_HSV_H.Text = "Hue";
            this.Label_HSV_H.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_HSV_S
            // 
            this.Label_HSV_S.AutoSize = true;
            this.Label_HSV_S.BackColor = System.Drawing.Color.Transparent;
            this.Label_HSV_S.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_HSV_S.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_HSV_S.Location = new System.Drawing.Point(50, 75);
            this.Label_HSV_S.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_HSV_S.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_HSV_S.Name = "Label_HSV_S";
            this.Label_HSV_S.Size = new System.Drawing.Size(73, 25);
            this.Label_HSV_S.TabIndex = 0;
            this.Label_HSV_S.Text = "Saturation";
            this.Label_HSV_S.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_HSV_V
            // 
            this.Label_HSV_V.AutoSize = true;
            this.Label_HSV_V.BackColor = System.Drawing.Color.Transparent;
            this.Label_HSV_V.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_HSV_V.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_HSV_V.Location = new System.Drawing.Point(50, 110);
            this.Label_HSV_V.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_HSV_V.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_HSV_V.Name = "Label_HSV_V";
            this.Label_HSV_V.Size = new System.Drawing.Size(73, 25);
            this.Label_HSV_V.TabIndex = 0;
            this.Label_HSV_V.Text = "Brightness";
            this.Label_HSV_V.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel_HSL
            // 
            this.Panel_HSL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Panel_HSL.Controls.Add(this.Button_HSL);
            this.Panel_HSL.Controls.Add(this.Label_Abbr_HSL_H);
            this.Panel_HSL.Controls.Add(this.Label_Abbr_HSL_S);
            this.Panel_HSL.Controls.Add(this.Label_Abbr_HSL_L);
            this.Panel_HSL.Controls.Add(this.Label_HSL_H);
            this.Panel_HSL.Controls.Add(this.Label_HSL_S);
            this.Panel_HSL.Controls.Add(this.Label_HSL_L);
            this.Panel_HSL.Controls.Add(this.NumEditor_HSL_H);
            this.Panel_HSL.Controls.Add(this.NumEditor_HSL_S);
            this.Panel_HSL.Controls.Add(this.NumEditor_HSL_L);
            this.Panel_HSL.Controls.Add(this.HTrackBar_HSL_H);
            this.Panel_HSL.Controls.Add(this.HTrackBar_HSL_S);
            this.Panel_HSL.Controls.Add(this.HTrackBar_HSL_L);
            this.Panel_HSL.Location = new System.Drawing.Point(20, 465);
            this.Panel_HSL.Name = "Panel_HSL";
            this.Panel_HSL.Size = new System.Drawing.Size(640, 145);
            this.Panel_HSL.TabIndex = 0;
            // 
            // Button_HSL
            // 
            this.Button_HSL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Button_HSL.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_HSL.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button_HSL.FlatAppearance.BorderSize = 0;
            this.Button_HSL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_HSL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_HSL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_HSL.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button_HSL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_HSL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_HSL.ImageIndex = 1;
            this.Button_HSL.ImageList = this.ImageList_FoldAndUnfold;
            this.Button_HSL.Location = new System.Drawing.Point(0, 0);
            this.Button_HSL.Name = "Button_HSL";
            this.Button_HSL.Size = new System.Drawing.Size(640, 30);
            this.Button_HSL.TabIndex = 0;
            this.Button_HSL.TabStop = false;
            this.Button_HSL.Text = "HSL";
            this.Button_HSL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_HSL.UseVisualStyleBackColor = false;
            this.Button_HSL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_HSL_MouseDown);
            // 
            // Label_Abbr_HSL_H
            // 
            this.Label_Abbr_HSL_H.AutoSize = true;
            this.Label_Abbr_HSL_H.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_HSL_H.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_HSL_H.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_HSL_H.Location = new System.Drawing.Point(20, 40);
            this.Label_Abbr_HSL_H.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_HSL_H.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_HSL_H.Name = "Label_Abbr_HSL_H";
            this.Label_Abbr_HSL_H.Size = new System.Drawing.Size(20, 25);
            this.Label_Abbr_HSL_H.TabIndex = 0;
            this.Label_Abbr_HSL_H.Text = "H";
            this.Label_Abbr_HSL_H.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Abbr_HSL_S
            // 
            this.Label_Abbr_HSL_S.AutoSize = true;
            this.Label_Abbr_HSL_S.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_HSL_S.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_HSL_S.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_HSL_S.Location = new System.Drawing.Point(20, 75);
            this.Label_Abbr_HSL_S.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_HSL_S.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_HSL_S.Name = "Label_Abbr_HSL_S";
            this.Label_Abbr_HSL_S.Size = new System.Drawing.Size(17, 25);
            this.Label_Abbr_HSL_S.TabIndex = 0;
            this.Label_Abbr_HSL_S.Text = "S";
            this.Label_Abbr_HSL_S.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Abbr_HSL_L
            // 
            this.Label_Abbr_HSL_L.AutoSize = true;
            this.Label_Abbr_HSL_L.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_HSL_L.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_HSL_L.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_HSL_L.Location = new System.Drawing.Point(20, 110);
            this.Label_Abbr_HSL_L.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_HSL_L.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_HSL_L.Name = "Label_Abbr_HSL_L";
            this.Label_Abbr_HSL_L.Size = new System.Drawing.Size(16, 25);
            this.Label_Abbr_HSL_L.TabIndex = 0;
            this.Label_Abbr_HSL_L.Text = "L";
            this.Label_Abbr_HSL_L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_HSL_H
            // 
            this.Label_HSL_H.AutoSize = true;
            this.Label_HSL_H.BackColor = System.Drawing.Color.Transparent;
            this.Label_HSL_H.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_HSL_H.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_HSL_H.Location = new System.Drawing.Point(50, 40);
            this.Label_HSL_H.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_HSL_H.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_HSL_H.Name = "Label_HSL_H";
            this.Label_HSL_H.Size = new System.Drawing.Size(34, 25);
            this.Label_HSL_H.TabIndex = 0;
            this.Label_HSL_H.Text = "Hue";
            this.Label_HSL_H.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_HSL_S
            // 
            this.Label_HSL_S.AutoSize = true;
            this.Label_HSL_S.BackColor = System.Drawing.Color.Transparent;
            this.Label_HSL_S.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_HSL_S.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_HSL_S.Location = new System.Drawing.Point(50, 75);
            this.Label_HSL_S.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_HSL_S.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_HSL_S.Name = "Label_HSL_S";
            this.Label_HSL_S.Size = new System.Drawing.Size(73, 25);
            this.Label_HSL_S.TabIndex = 0;
            this.Label_HSL_S.Text = "Saturation";
            this.Label_HSL_S.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_HSL_L
            // 
            this.Label_HSL_L.AutoSize = true;
            this.Label_HSL_L.BackColor = System.Drawing.Color.Transparent;
            this.Label_HSL_L.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_HSL_L.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_HSL_L.Location = new System.Drawing.Point(50, 110);
            this.Label_HSL_L.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_HSL_L.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_HSL_L.Name = "Label_HSL_L";
            this.Label_HSL_L.Size = new System.Drawing.Size(67, 25);
            this.Label_HSL_L.TabIndex = 0;
            this.Label_HSL_L.Text = "Lightness";
            this.Label_HSL_L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel_CMYK
            // 
            this.Panel_CMYK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Panel_CMYK.Controls.Add(this.Button_CMYK);
            this.Panel_CMYK.Controls.Add(this.Label_Abbr_CMYK_C);
            this.Panel_CMYK.Controls.Add(this.Label_Abbr_CMYK_M);
            this.Panel_CMYK.Controls.Add(this.Label_Abbr_CMYK_Y);
            this.Panel_CMYK.Controls.Add(this.Label_Abbr_CMYK_K);
            this.Panel_CMYK.Controls.Add(this.Label_CMYK_C);
            this.Panel_CMYK.Controls.Add(this.Label_CMYK_M);
            this.Panel_CMYK.Controls.Add(this.Label_CMYK_Y);
            this.Panel_CMYK.Controls.Add(this.Label_CMYK_K);
            this.Panel_CMYK.Controls.Add(this.NumEditor_CMYK_K);
            this.Panel_CMYK.Controls.Add(this.NumEditor_CMYK_C);
            this.Panel_CMYK.Controls.Add(this.NumEditor_CMYK_M);
            this.Panel_CMYK.Controls.Add(this.NumEditor_CMYK_Y);
            this.Panel_CMYK.Controls.Add(this.HTrackBar_CMYK_C);
            this.Panel_CMYK.Controls.Add(this.HTrackBar_CMYK_M);
            this.Panel_CMYK.Controls.Add(this.HTrackBar_CMYK_Y);
            this.Panel_CMYK.Controls.Add(this.HTrackBar_CMYK_K);
            this.Panel_CMYK.Location = new System.Drawing.Point(20, 625);
            this.Panel_CMYK.Name = "Panel_CMYK";
            this.Panel_CMYK.Size = new System.Drawing.Size(640, 180);
            this.Panel_CMYK.TabIndex = 0;
            // 
            // Button_CMYK
            // 
            this.Button_CMYK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Button_CMYK.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_CMYK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button_CMYK.FlatAppearance.BorderSize = 0;
            this.Button_CMYK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_CMYK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_CMYK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_CMYK.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button_CMYK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_CMYK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_CMYK.ImageIndex = 1;
            this.Button_CMYK.ImageList = this.ImageList_FoldAndUnfold;
            this.Button_CMYK.Location = new System.Drawing.Point(0, 0);
            this.Button_CMYK.Name = "Button_CMYK";
            this.Button_CMYK.Size = new System.Drawing.Size(640, 30);
            this.Button_CMYK.TabIndex = 0;
            this.Button_CMYK.TabStop = false;
            this.Button_CMYK.Text = "CMYK";
            this.Button_CMYK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_CMYK.UseVisualStyleBackColor = false;
            this.Button_CMYK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_CMYK_MouseDown);
            // 
            // Label_Abbr_CMYK_C
            // 
            this.Label_Abbr_CMYK_C.AutoSize = true;
            this.Label_Abbr_CMYK_C.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_CMYK_C.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_CMYK_C.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_CMYK_C.Location = new System.Drawing.Point(20, 40);
            this.Label_Abbr_CMYK_C.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_CMYK_C.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_CMYK_C.Name = "Label_Abbr_CMYK_C";
            this.Label_Abbr_CMYK_C.Size = new System.Drawing.Size(18, 25);
            this.Label_Abbr_CMYK_C.TabIndex = 0;
            this.Label_Abbr_CMYK_C.Text = "C";
            this.Label_Abbr_CMYK_C.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Abbr_CMYK_M
            // 
            this.Label_Abbr_CMYK_M.AutoSize = true;
            this.Label_Abbr_CMYK_M.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_CMYK_M.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_CMYK_M.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_CMYK_M.Location = new System.Drawing.Point(20, 75);
            this.Label_Abbr_CMYK_M.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_CMYK_M.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_CMYK_M.Name = "Label_Abbr_CMYK_M";
            this.Label_Abbr_CMYK_M.Size = new System.Drawing.Size(22, 25);
            this.Label_Abbr_CMYK_M.TabIndex = 0;
            this.Label_Abbr_CMYK_M.Text = "M";
            this.Label_Abbr_CMYK_M.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Abbr_CMYK_Y
            // 
            this.Label_Abbr_CMYK_Y.AutoSize = true;
            this.Label_Abbr_CMYK_Y.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_CMYK_Y.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_CMYK_Y.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_CMYK_Y.Location = new System.Drawing.Point(20, 110);
            this.Label_Abbr_CMYK_Y.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_CMYK_Y.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_CMYK_Y.Name = "Label_Abbr_CMYK_Y";
            this.Label_Abbr_CMYK_Y.Size = new System.Drawing.Size(17, 25);
            this.Label_Abbr_CMYK_Y.TabIndex = 0;
            this.Label_Abbr_CMYK_Y.Text = "Y";
            this.Label_Abbr_CMYK_Y.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Abbr_CMYK_K
            // 
            this.Label_Abbr_CMYK_K.AutoSize = true;
            this.Label_Abbr_CMYK_K.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_CMYK_K.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_CMYK_K.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_CMYK_K.Location = new System.Drawing.Point(20, 145);
            this.Label_Abbr_CMYK_K.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_CMYK_K.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_CMYK_K.Name = "Label_Abbr_CMYK_K";
            this.Label_Abbr_CMYK_K.Size = new System.Drawing.Size(18, 25);
            this.Label_Abbr_CMYK_K.TabIndex = 0;
            this.Label_Abbr_CMYK_K.Text = "K";
            this.Label_Abbr_CMYK_K.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_CMYK_C
            // 
            this.Label_CMYK_C.AutoSize = true;
            this.Label_CMYK_C.BackColor = System.Drawing.Color.Transparent;
            this.Label_CMYK_C.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_CMYK_C.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_CMYK_C.Location = new System.Drawing.Point(50, 40);
            this.Label_CMYK_C.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_CMYK_C.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_CMYK_C.Name = "Label_CMYK_C";
            this.Label_CMYK_C.Size = new System.Drawing.Size(40, 25);
            this.Label_CMYK_C.TabIndex = 0;
            this.Label_CMYK_C.Text = "Cyan";
            this.Label_CMYK_C.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_CMYK_M
            // 
            this.Label_CMYK_M.AutoSize = true;
            this.Label_CMYK_M.BackColor = System.Drawing.Color.Transparent;
            this.Label_CMYK_M.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_CMYK_M.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_CMYK_M.Location = new System.Drawing.Point(50, 75);
            this.Label_CMYK_M.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_CMYK_M.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_CMYK_M.Name = "Label_CMYK_M";
            this.Label_CMYK_M.Size = new System.Drawing.Size(64, 25);
            this.Label_CMYK_M.TabIndex = 0;
            this.Label_CMYK_M.Text = "Magenta";
            this.Label_CMYK_M.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_CMYK_Y
            // 
            this.Label_CMYK_Y.AutoSize = true;
            this.Label_CMYK_Y.BackColor = System.Drawing.Color.Transparent;
            this.Label_CMYK_Y.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_CMYK_Y.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_CMYK_Y.Location = new System.Drawing.Point(50, 110);
            this.Label_CMYK_Y.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_CMYK_Y.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_CMYK_Y.Name = "Label_CMYK_Y";
            this.Label_CMYK_Y.Size = new System.Drawing.Size(48, 25);
            this.Label_CMYK_Y.TabIndex = 0;
            this.Label_CMYK_Y.Text = "Yellow";
            this.Label_CMYK_Y.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_CMYK_K
            // 
            this.Label_CMYK_K.AutoSize = true;
            this.Label_CMYK_K.BackColor = System.Drawing.Color.Transparent;
            this.Label_CMYK_K.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_CMYK_K.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_CMYK_K.Location = new System.Drawing.Point(50, 145);
            this.Label_CMYK_K.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_CMYK_K.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_CMYK_K.Name = "Label_CMYK_K";
            this.Label_CMYK_K.Size = new System.Drawing.Size(41, 25);
            this.Label_CMYK_K.TabIndex = 0;
            this.Label_CMYK_K.Text = "Black";
            this.Label_CMYK_K.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel_LAB
            // 
            this.Panel_LAB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Panel_LAB.Controls.Add(this.Button_LAB);
            this.Panel_LAB.Controls.Add(this.Label_Abbr_LAB_L);
            this.Panel_LAB.Controls.Add(this.Label_Abbr_LAB_A);
            this.Panel_LAB.Controls.Add(this.Label_Abbr_LAB_B);
            this.Panel_LAB.Controls.Add(this.Label_LAB_L);
            this.Panel_LAB.Controls.Add(this.Label_LAB_A);
            this.Panel_LAB.Controls.Add(this.Label_LAB_B);
            this.Panel_LAB.Controls.Add(this.NumEditor_LAB_L);
            this.Panel_LAB.Controls.Add(this.NumEditor_LAB_A);
            this.Panel_LAB.Controls.Add(this.NumEditor_LAB_B);
            this.Panel_LAB.Controls.Add(this.HTrackBar_LAB_L);
            this.Panel_LAB.Controls.Add(this.HTrackBar_LAB_A);
            this.Panel_LAB.Controls.Add(this.HTrackBar_LAB_B);
            this.Panel_LAB.Location = new System.Drawing.Point(20, 820);
            this.Panel_LAB.Name = "Panel_LAB";
            this.Panel_LAB.Size = new System.Drawing.Size(640, 145);
            this.Panel_LAB.TabIndex = 0;
            // 
            // Button_LAB
            // 
            this.Button_LAB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Button_LAB.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_LAB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button_LAB.FlatAppearance.BorderSize = 0;
            this.Button_LAB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_LAB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_LAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_LAB.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button_LAB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_LAB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_LAB.ImageIndex = 1;
            this.Button_LAB.ImageList = this.ImageList_FoldAndUnfold;
            this.Button_LAB.Location = new System.Drawing.Point(0, 0);
            this.Button_LAB.Name = "Button_LAB";
            this.Button_LAB.Size = new System.Drawing.Size(640, 30);
            this.Button_LAB.TabIndex = 0;
            this.Button_LAB.TabStop = false;
            this.Button_LAB.Text = "Lab";
            this.Button_LAB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_LAB.UseVisualStyleBackColor = false;
            this.Button_LAB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_LAB_MouseDown);
            // 
            // Label_Abbr_LAB_L
            // 
            this.Label_Abbr_LAB_L.AutoSize = true;
            this.Label_Abbr_LAB_L.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_LAB_L.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_LAB_L.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_LAB_L.Location = new System.Drawing.Point(20, 40);
            this.Label_Abbr_LAB_L.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_LAB_L.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_LAB_L.Name = "Label_Abbr_LAB_L";
            this.Label_Abbr_LAB_L.Size = new System.Drawing.Size(16, 25);
            this.Label_Abbr_LAB_L.TabIndex = 0;
            this.Label_Abbr_LAB_L.Text = "L";
            this.Label_Abbr_LAB_L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Abbr_LAB_A
            // 
            this.Label_Abbr_LAB_A.AutoSize = true;
            this.Label_Abbr_LAB_A.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_LAB_A.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_LAB_A.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_LAB_A.Location = new System.Drawing.Point(20, 75);
            this.Label_Abbr_LAB_A.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_LAB_A.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_LAB_A.Name = "Label_Abbr_LAB_A";
            this.Label_Abbr_LAB_A.Size = new System.Drawing.Size(17, 25);
            this.Label_Abbr_LAB_A.TabIndex = 0;
            this.Label_Abbr_LAB_A.Text = "a";
            this.Label_Abbr_LAB_A.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Abbr_LAB_B
            // 
            this.Label_Abbr_LAB_B.AutoSize = true;
            this.Label_Abbr_LAB_B.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_LAB_B.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_LAB_B.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_LAB_B.Location = new System.Drawing.Point(20, 110);
            this.Label_Abbr_LAB_B.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_LAB_B.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_LAB_B.Name = "Label_Abbr_LAB_B";
            this.Label_Abbr_LAB_B.Size = new System.Drawing.Size(18, 25);
            this.Label_Abbr_LAB_B.TabIndex = 0;
            this.Label_Abbr_LAB_B.Text = "b";
            this.Label_Abbr_LAB_B.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_LAB_L
            // 
            this.Label_LAB_L.AutoSize = true;
            this.Label_LAB_L.BackColor = System.Drawing.Color.Transparent;
            this.Label_LAB_L.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_LAB_L.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_LAB_L.Location = new System.Drawing.Point(50, 40);
            this.Label_LAB_L.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_LAB_L.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_LAB_L.Name = "Label_LAB_L";
            this.Label_LAB_L.Size = new System.Drawing.Size(67, 25);
            this.Label_LAB_L.TabIndex = 0;
            this.Label_LAB_L.Text = "Lightness";
            this.Label_LAB_L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_LAB_A
            // 
            this.Label_LAB_A.AutoSize = true;
            this.Label_LAB_A.BackColor = System.Drawing.Color.Transparent;
            this.Label_LAB_A.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_LAB_A.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_LAB_A.Location = new System.Drawing.Point(50, 75);
            this.Label_LAB_A.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_LAB_A.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_LAB_A.Name = "Label_LAB_A";
            this.Label_LAB_A.Size = new System.Drawing.Size(75, 25);
            this.Label_LAB_A.TabIndex = 0;
            this.Label_LAB_A.Text = "Green-Red";
            this.Label_LAB_A.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_LAB_B
            // 
            this.Label_LAB_B.AutoSize = true;
            this.Label_LAB_B.BackColor = System.Drawing.Color.Transparent;
            this.Label_LAB_B.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_LAB_B.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_LAB_B.Location = new System.Drawing.Point(50, 110);
            this.Label_LAB_B.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_LAB_B.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_LAB_B.Name = "Label_LAB_B";
            this.Label_LAB_B.Size = new System.Drawing.Size(80, 25);
            this.Label_LAB_B.TabIndex = 0;
            this.Label_LAB_B.Text = "Blue-Yellow";
            this.Label_LAB_B.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel_YUV
            // 
            this.Panel_YUV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Panel_YUV.Controls.Add(this.Button_YUV);
            this.Panel_YUV.Controls.Add(this.Label_Abbr_YUV_Y);
            this.Panel_YUV.Controls.Add(this.Label_Abbr_YUV_U);
            this.Panel_YUV.Controls.Add(this.Label_Abbr_YUV_V);
            this.Panel_YUV.Controls.Add(this.Label_YUV_Y);
            this.Panel_YUV.Controls.Add(this.Label_YUV_U);
            this.Panel_YUV.Controls.Add(this.Label_YUV_V);
            this.Panel_YUV.Controls.Add(this.NumEditor_YUV_Y);
            this.Panel_YUV.Controls.Add(this.NumEditor_YUV_U);
            this.Panel_YUV.Controls.Add(this.NumEditor_YUV_V);
            this.Panel_YUV.Controls.Add(this.HTrackBar_YUV_Y);
            this.Panel_YUV.Controls.Add(this.HTrackBar_YUV_U);
            this.Panel_YUV.Controls.Add(this.HTrackBar_YUV_V);
            this.Panel_YUV.Location = new System.Drawing.Point(20, 980);
            this.Panel_YUV.Name = "Panel_YUV";
            this.Panel_YUV.Size = new System.Drawing.Size(640, 145);
            this.Panel_YUV.TabIndex = 0;
            // 
            // Button_YUV
            // 
            this.Button_YUV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Button_YUV.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_YUV.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button_YUV.FlatAppearance.BorderSize = 0;
            this.Button_YUV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_YUV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_YUV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_YUV.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button_YUV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_YUV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_YUV.ImageIndex = 1;
            this.Button_YUV.ImageList = this.ImageList_FoldAndUnfold;
            this.Button_YUV.Location = new System.Drawing.Point(0, 0);
            this.Button_YUV.Name = "Button_YUV";
            this.Button_YUV.Size = new System.Drawing.Size(640, 30);
            this.Button_YUV.TabIndex = 0;
            this.Button_YUV.TabStop = false;
            this.Button_YUV.Text = "YUV";
            this.Button_YUV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Button_YUV.UseVisualStyleBackColor = false;
            this.Button_YUV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_YUV_MouseDown);
            // 
            // Label_Abbr_YUV_Y
            // 
            this.Label_Abbr_YUV_Y.AutoSize = true;
            this.Label_Abbr_YUV_Y.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_YUV_Y.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_YUV_Y.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_YUV_Y.Location = new System.Drawing.Point(20, 40);
            this.Label_Abbr_YUV_Y.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_YUV_Y.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_YUV_Y.Name = "Label_Abbr_YUV_Y";
            this.Label_Abbr_YUV_Y.Size = new System.Drawing.Size(17, 25);
            this.Label_Abbr_YUV_Y.TabIndex = 0;
            this.Label_Abbr_YUV_Y.Text = "Y";
            this.Label_Abbr_YUV_Y.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Abbr_YUV_U
            // 
            this.Label_Abbr_YUV_U.AutoSize = true;
            this.Label_Abbr_YUV_U.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_YUV_U.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_YUV_U.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_YUV_U.Location = new System.Drawing.Point(20, 75);
            this.Label_Abbr_YUV_U.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_YUV_U.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_YUV_U.Name = "Label_Abbr_YUV_U";
            this.Label_Abbr_YUV_U.Size = new System.Drawing.Size(19, 25);
            this.Label_Abbr_YUV_U.TabIndex = 0;
            this.Label_Abbr_YUV_U.Text = "U";
            this.Label_Abbr_YUV_U.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Abbr_YUV_V
            // 
            this.Label_Abbr_YUV_V.AutoSize = true;
            this.Label_Abbr_YUV_V.BackColor = System.Drawing.Color.Transparent;
            this.Label_Abbr_YUV_V.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Abbr_YUV_V.ForeColor = System.Drawing.Color.Silver;
            this.Label_Abbr_YUV_V.Location = new System.Drawing.Point(20, 110);
            this.Label_Abbr_YUV_V.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_YUV_V.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_Abbr_YUV_V.Name = "Label_Abbr_YUV_V";
            this.Label_Abbr_YUV_V.Size = new System.Drawing.Size(18, 25);
            this.Label_Abbr_YUV_V.TabIndex = 0;
            this.Label_Abbr_YUV_V.Text = "V";
            this.Label_Abbr_YUV_V.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_YUV_Y
            // 
            this.Label_YUV_Y.AutoSize = true;
            this.Label_YUV_Y.BackColor = System.Drawing.Color.Transparent;
            this.Label_YUV_Y.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_YUV_Y.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_YUV_Y.Location = new System.Drawing.Point(50, 40);
            this.Label_YUV_Y.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_YUV_Y.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_YUV_Y.Name = "Label_YUV_Y";
            this.Label_YUV_Y.Size = new System.Drawing.Size(76, 25);
            this.Label_YUV_Y.TabIndex = 0;
            this.Label_YUV_Y.Text = "Luminance";
            this.Label_YUV_Y.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_YUV_U
            // 
            this.Label_YUV_U.AutoSize = true;
            this.Label_YUV_U.BackColor = System.Drawing.Color.Transparent;
            this.Label_YUV_U.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_YUV_U.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_YUV_U.Location = new System.Drawing.Point(50, 75);
            this.Label_YUV_U.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_YUV_U.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_YUV_U.Name = "Label_YUV_U";
            this.Label_YUV_U.Size = new System.Drawing.Size(121, 25);
            this.Label_YUV_U.TabIndex = 0;
            this.Label_YUV_U.Text = "Blue Chrominance";
            this.Label_YUV_U.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_YUV_V
            // 
            this.Label_YUV_V.AutoSize = true;
            this.Label_YUV_V.BackColor = System.Drawing.Color.Transparent;
            this.Label_YUV_V.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_YUV_V.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Label_YUV_V.Location = new System.Drawing.Point(50, 110);
            this.Label_YUV_V.MaximumSize = new System.Drawing.Size(0, 25);
            this.Label_YUV_V.MinimumSize = new System.Drawing.Size(0, 25);
            this.Label_YUV_V.Name = "Label_YUV_V";
            this.Label_YUV_V.Size = new System.Drawing.Size(118, 25);
            this.Label_YUV_V.TabIndex = 0;
            this.Label_YUV_V.Text = "Red Chrominance";
            this.Label_YUV_V.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumEditor_Opacity
            // 
            this.NumEditor_Opacity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_Opacity.Location = new System.Drawing.Point(180, 40);
            this.NumEditor_Opacity.Maximum = 100D;
            this.NumEditor_Opacity.Minimum = 0D;
            this.NumEditor_Opacity.Name = "NumEditor_Opacity";
            this.NumEditor_Opacity.Precision = 0;
            this.NumEditor_Opacity.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_Opacity.TabIndex = 0;
            this.NumEditor_Opacity.TabStop = false;
            this.NumEditor_Opacity.Value = 0D;
            // 
            // NumEditor_Alpha
            // 
            this.NumEditor_Alpha.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_Alpha.Location = new System.Drawing.Point(180, 75);
            this.NumEditor_Alpha.Maximum = 100D;
            this.NumEditor_Alpha.Minimum = 0D;
            this.NumEditor_Alpha.Name = "NumEditor_Alpha";
            this.NumEditor_Alpha.Precision = 0;
            this.NumEditor_Alpha.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_Alpha.TabIndex = 0;
            this.NumEditor_Alpha.TabStop = false;
            this.NumEditor_Alpha.Value = 0D;
            // 
            // HTrackBar_Opacity
            // 
            this.HTrackBar_Opacity.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_Opacity.Colors = new System.Drawing.Color[0];
            this.HTrackBar_Opacity.Delta = 5D;
            this.HTrackBar_Opacity.Location = new System.Drawing.Point(260, 40);
            this.HTrackBar_Opacity.Maximum = 100D;
            this.HTrackBar_Opacity.Minimum = 0D;
            this.HTrackBar_Opacity.Name = "HTrackBar_Opacity";
            this.HTrackBar_Opacity.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_Opacity.TabIndex = 0;
            this.HTrackBar_Opacity.TabStop = false;
            this.HTrackBar_Opacity.Value = 0D;
            // 
            // HTrackBar_Alpha
            // 
            this.HTrackBar_Alpha.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_Alpha.Colors = new System.Drawing.Color[0];
            this.HTrackBar_Alpha.Delta = 5D;
            this.HTrackBar_Alpha.Location = new System.Drawing.Point(260, 75);
            this.HTrackBar_Alpha.Maximum = 100D;
            this.HTrackBar_Alpha.Minimum = 0D;
            this.HTrackBar_Alpha.Name = "HTrackBar_Alpha";
            this.HTrackBar_Alpha.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_Alpha.TabIndex = 0;
            this.HTrackBar_Alpha.TabStop = false;
            this.HTrackBar_Alpha.Value = 0D;
            // 
            // NumEditor_RGB_R
            // 
            this.NumEditor_RGB_R.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_RGB_R.Location = new System.Drawing.Point(180, 40);
            this.NumEditor_RGB_R.Maximum = 100D;
            this.NumEditor_RGB_R.Minimum = 0D;
            this.NumEditor_RGB_R.Name = "NumEditor_RGB_R";
            this.NumEditor_RGB_R.Precision = 0;
            this.NumEditor_RGB_R.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_RGB_R.TabIndex = 0;
            this.NumEditor_RGB_R.TabStop = false;
            this.NumEditor_RGB_R.Value = 0D;
            // 
            // NumEditor_RGB_G
            // 
            this.NumEditor_RGB_G.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_RGB_G.Location = new System.Drawing.Point(180, 75);
            this.NumEditor_RGB_G.Maximum = 100D;
            this.NumEditor_RGB_G.Minimum = 0D;
            this.NumEditor_RGB_G.Name = "NumEditor_RGB_G";
            this.NumEditor_RGB_G.Precision = 0;
            this.NumEditor_RGB_G.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_RGB_G.TabIndex = 0;
            this.NumEditor_RGB_G.TabStop = false;
            this.NumEditor_RGB_G.Value = 0D;
            // 
            // NumEditor_RGB_B
            // 
            this.NumEditor_RGB_B.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_RGB_B.Location = new System.Drawing.Point(180, 110);
            this.NumEditor_RGB_B.Maximum = 100D;
            this.NumEditor_RGB_B.Minimum = 0D;
            this.NumEditor_RGB_B.Name = "NumEditor_RGB_B";
            this.NumEditor_RGB_B.Precision = 0;
            this.NumEditor_RGB_B.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_RGB_B.TabIndex = 0;
            this.NumEditor_RGB_B.TabStop = false;
            this.NumEditor_RGB_B.Value = 0D;
            // 
            // HTrackBar_RGB_R
            // 
            this.HTrackBar_RGB_R.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_RGB_R.Colors = new System.Drawing.Color[0];
            this.HTrackBar_RGB_R.Delta = 5D;
            this.HTrackBar_RGB_R.Location = new System.Drawing.Point(260, 40);
            this.HTrackBar_RGB_R.Maximum = 100D;
            this.HTrackBar_RGB_R.Minimum = 0D;
            this.HTrackBar_RGB_R.Name = "HTrackBar_RGB_R";
            this.HTrackBar_RGB_R.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_RGB_R.TabIndex = 0;
            this.HTrackBar_RGB_R.TabStop = false;
            this.HTrackBar_RGB_R.Value = 0D;
            // 
            // HTrackBar_RGB_G
            // 
            this.HTrackBar_RGB_G.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_RGB_G.Colors = new System.Drawing.Color[0];
            this.HTrackBar_RGB_G.Delta = 5D;
            this.HTrackBar_RGB_G.Location = new System.Drawing.Point(260, 75);
            this.HTrackBar_RGB_G.Maximum = 100D;
            this.HTrackBar_RGB_G.Minimum = 0D;
            this.HTrackBar_RGB_G.Name = "HTrackBar_RGB_G";
            this.HTrackBar_RGB_G.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_RGB_G.TabIndex = 0;
            this.HTrackBar_RGB_G.TabStop = false;
            this.HTrackBar_RGB_G.Value = 0D;
            // 
            // HTrackBar_RGB_B
            // 
            this.HTrackBar_RGB_B.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_RGB_B.Colors = new System.Drawing.Color[0];
            this.HTrackBar_RGB_B.Delta = 5D;
            this.HTrackBar_RGB_B.Location = new System.Drawing.Point(260, 110);
            this.HTrackBar_RGB_B.Maximum = 100D;
            this.HTrackBar_RGB_B.Minimum = 0D;
            this.HTrackBar_RGB_B.Name = "HTrackBar_RGB_B";
            this.HTrackBar_RGB_B.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_RGB_B.TabIndex = 0;
            this.HTrackBar_RGB_B.TabStop = false;
            this.HTrackBar_RGB_B.Value = 0D;
            // 
            // NumEditor_HSV_H
            // 
            this.NumEditor_HSV_H.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_HSV_H.Location = new System.Drawing.Point(180, 40);
            this.NumEditor_HSV_H.Maximum = 100D;
            this.NumEditor_HSV_H.Minimum = 0D;
            this.NumEditor_HSV_H.Name = "NumEditor_HSV_H";
            this.NumEditor_HSV_H.Precision = 0;
            this.NumEditor_HSV_H.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_HSV_H.TabIndex = 0;
            this.NumEditor_HSV_H.TabStop = false;
            this.NumEditor_HSV_H.Value = 0D;
            // 
            // NumEditor_HSV_S
            // 
            this.NumEditor_HSV_S.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_HSV_S.Location = new System.Drawing.Point(180, 75);
            this.NumEditor_HSV_S.Maximum = 100D;
            this.NumEditor_HSV_S.Minimum = 0D;
            this.NumEditor_HSV_S.Name = "NumEditor_HSV_S";
            this.NumEditor_HSV_S.Precision = 0;
            this.NumEditor_HSV_S.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_HSV_S.TabIndex = 0;
            this.NumEditor_HSV_S.TabStop = false;
            this.NumEditor_HSV_S.Value = 0D;
            // 
            // NumEditor_HSV_V
            // 
            this.NumEditor_HSV_V.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_HSV_V.Location = new System.Drawing.Point(180, 110);
            this.NumEditor_HSV_V.Maximum = 100D;
            this.NumEditor_HSV_V.Minimum = 0D;
            this.NumEditor_HSV_V.Name = "NumEditor_HSV_V";
            this.NumEditor_HSV_V.Precision = 0;
            this.NumEditor_HSV_V.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_HSV_V.TabIndex = 0;
            this.NumEditor_HSV_V.TabStop = false;
            this.NumEditor_HSV_V.Value = 0D;
            // 
            // HTrackBar_HSV_H
            // 
            this.HTrackBar_HSV_H.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_HSV_H.Colors = new System.Drawing.Color[0];
            this.HTrackBar_HSV_H.Delta = 5D;
            this.HTrackBar_HSV_H.Location = new System.Drawing.Point(260, 40);
            this.HTrackBar_HSV_H.Maximum = 100D;
            this.HTrackBar_HSV_H.Minimum = 0D;
            this.HTrackBar_HSV_H.Name = "HTrackBar_HSV_H";
            this.HTrackBar_HSV_H.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_HSV_H.TabIndex = 0;
            this.HTrackBar_HSV_H.TabStop = false;
            this.HTrackBar_HSV_H.Value = 0D;
            // 
            // HTrackBar_HSV_S
            // 
            this.HTrackBar_HSV_S.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_HSV_S.Colors = new System.Drawing.Color[0];
            this.HTrackBar_HSV_S.Delta = 5D;
            this.HTrackBar_HSV_S.Location = new System.Drawing.Point(260, 75);
            this.HTrackBar_HSV_S.Maximum = 100D;
            this.HTrackBar_HSV_S.Minimum = 0D;
            this.HTrackBar_HSV_S.Name = "HTrackBar_HSV_S";
            this.HTrackBar_HSV_S.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_HSV_S.TabIndex = 0;
            this.HTrackBar_HSV_S.TabStop = false;
            this.HTrackBar_HSV_S.Value = 0D;
            // 
            // HTrackBar_HSV_V
            // 
            this.HTrackBar_HSV_V.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_HSV_V.Colors = new System.Drawing.Color[0];
            this.HTrackBar_HSV_V.Delta = 5D;
            this.HTrackBar_HSV_V.Location = new System.Drawing.Point(260, 110);
            this.HTrackBar_HSV_V.Maximum = 100D;
            this.HTrackBar_HSV_V.Minimum = 0D;
            this.HTrackBar_HSV_V.Name = "HTrackBar_HSV_V";
            this.HTrackBar_HSV_V.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_HSV_V.TabIndex = 0;
            this.HTrackBar_HSV_V.TabStop = false;
            this.HTrackBar_HSV_V.Value = 0D;
            // 
            // NumEditor_HSL_H
            // 
            this.NumEditor_HSL_H.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_HSL_H.Location = new System.Drawing.Point(180, 40);
            this.NumEditor_HSL_H.Maximum = 100D;
            this.NumEditor_HSL_H.Minimum = 0D;
            this.NumEditor_HSL_H.Name = "NumEditor_HSL_H";
            this.NumEditor_HSL_H.Precision = 0;
            this.NumEditor_HSL_H.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_HSL_H.TabIndex = 0;
            this.NumEditor_HSL_H.TabStop = false;
            this.NumEditor_HSL_H.Value = 0D;
            // 
            // NumEditor_HSL_S
            // 
            this.NumEditor_HSL_S.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_HSL_S.Location = new System.Drawing.Point(180, 75);
            this.NumEditor_HSL_S.Maximum = 100D;
            this.NumEditor_HSL_S.Minimum = 0D;
            this.NumEditor_HSL_S.Name = "NumEditor_HSL_S";
            this.NumEditor_HSL_S.Precision = 0;
            this.NumEditor_HSL_S.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_HSL_S.TabIndex = 0;
            this.NumEditor_HSL_S.TabStop = false;
            this.NumEditor_HSL_S.Value = 0D;
            // 
            // NumEditor_HSL_L
            // 
            this.NumEditor_HSL_L.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_HSL_L.Location = new System.Drawing.Point(180, 110);
            this.NumEditor_HSL_L.Maximum = 100D;
            this.NumEditor_HSL_L.Minimum = 0D;
            this.NumEditor_HSL_L.Name = "NumEditor_HSL_L";
            this.NumEditor_HSL_L.Precision = 0;
            this.NumEditor_HSL_L.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_HSL_L.TabIndex = 0;
            this.NumEditor_HSL_L.TabStop = false;
            this.NumEditor_HSL_L.Value = 0D;
            // 
            // HTrackBar_HSL_H
            // 
            this.HTrackBar_HSL_H.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_HSL_H.Colors = new System.Drawing.Color[0];
            this.HTrackBar_HSL_H.Delta = 5D;
            this.HTrackBar_HSL_H.Location = new System.Drawing.Point(260, 40);
            this.HTrackBar_HSL_H.Maximum = 100D;
            this.HTrackBar_HSL_H.Minimum = 0D;
            this.HTrackBar_HSL_H.Name = "HTrackBar_HSL_H";
            this.HTrackBar_HSL_H.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_HSL_H.TabIndex = 0;
            this.HTrackBar_HSL_H.TabStop = false;
            this.HTrackBar_HSL_H.Value = 0D;
            // 
            // HTrackBar_HSL_S
            // 
            this.HTrackBar_HSL_S.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_HSL_S.Colors = new System.Drawing.Color[0];
            this.HTrackBar_HSL_S.Delta = 5D;
            this.HTrackBar_HSL_S.Location = new System.Drawing.Point(260, 75);
            this.HTrackBar_HSL_S.Maximum = 100D;
            this.HTrackBar_HSL_S.Minimum = 0D;
            this.HTrackBar_HSL_S.Name = "HTrackBar_HSL_S";
            this.HTrackBar_HSL_S.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_HSL_S.TabIndex = 0;
            this.HTrackBar_HSL_S.TabStop = false;
            this.HTrackBar_HSL_S.Value = 0D;
            // 
            // HTrackBar_HSL_L
            // 
            this.HTrackBar_HSL_L.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_HSL_L.Colors = new System.Drawing.Color[0];
            this.HTrackBar_HSL_L.Delta = 5D;
            this.HTrackBar_HSL_L.Location = new System.Drawing.Point(260, 110);
            this.HTrackBar_HSL_L.Maximum = 100D;
            this.HTrackBar_HSL_L.Minimum = 0D;
            this.HTrackBar_HSL_L.Name = "HTrackBar_HSL_L";
            this.HTrackBar_HSL_L.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_HSL_L.TabIndex = 0;
            this.HTrackBar_HSL_L.TabStop = false;
            this.HTrackBar_HSL_L.Value = 0D;
            // 
            // NumEditor_CMYK_K
            // 
            this.NumEditor_CMYK_K.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_CMYK_K.Location = new System.Drawing.Point(180, 145);
            this.NumEditor_CMYK_K.Maximum = 100D;
            this.NumEditor_CMYK_K.Minimum = 0D;
            this.NumEditor_CMYK_K.Name = "NumEditor_CMYK_K";
            this.NumEditor_CMYK_K.Precision = 0;
            this.NumEditor_CMYK_K.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_CMYK_K.TabIndex = 0;
            this.NumEditor_CMYK_K.TabStop = false;
            this.NumEditor_CMYK_K.Value = 0D;
            // 
            // NumEditor_CMYK_C
            // 
            this.NumEditor_CMYK_C.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_CMYK_C.Location = new System.Drawing.Point(180, 40);
            this.NumEditor_CMYK_C.Maximum = 100D;
            this.NumEditor_CMYK_C.Minimum = 0D;
            this.NumEditor_CMYK_C.Name = "NumEditor_CMYK_C";
            this.NumEditor_CMYK_C.Precision = 0;
            this.NumEditor_CMYK_C.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_CMYK_C.TabIndex = 0;
            this.NumEditor_CMYK_C.TabStop = false;
            this.NumEditor_CMYK_C.Value = 0D;
            // 
            // NumEditor_CMYK_M
            // 
            this.NumEditor_CMYK_M.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_CMYK_M.Location = new System.Drawing.Point(180, 75);
            this.NumEditor_CMYK_M.Maximum = 100D;
            this.NumEditor_CMYK_M.Minimum = 0D;
            this.NumEditor_CMYK_M.Name = "NumEditor_CMYK_M";
            this.NumEditor_CMYK_M.Precision = 0;
            this.NumEditor_CMYK_M.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_CMYK_M.TabIndex = 0;
            this.NumEditor_CMYK_M.TabStop = false;
            this.NumEditor_CMYK_M.Value = 0D;
            // 
            // NumEditor_CMYK_Y
            // 
            this.NumEditor_CMYK_Y.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_CMYK_Y.Location = new System.Drawing.Point(180, 110);
            this.NumEditor_CMYK_Y.Maximum = 100D;
            this.NumEditor_CMYK_Y.Minimum = 0D;
            this.NumEditor_CMYK_Y.Name = "NumEditor_CMYK_Y";
            this.NumEditor_CMYK_Y.Precision = 0;
            this.NumEditor_CMYK_Y.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_CMYK_Y.TabIndex = 0;
            this.NumEditor_CMYK_Y.TabStop = false;
            this.NumEditor_CMYK_Y.Value = 0D;
            // 
            // HTrackBar_CMYK_C
            // 
            this.HTrackBar_CMYK_C.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_CMYK_C.Colors = new System.Drawing.Color[0];
            this.HTrackBar_CMYK_C.Delta = 5D;
            this.HTrackBar_CMYK_C.Location = new System.Drawing.Point(260, 40);
            this.HTrackBar_CMYK_C.Maximum = 100D;
            this.HTrackBar_CMYK_C.Minimum = 0D;
            this.HTrackBar_CMYK_C.Name = "HTrackBar_CMYK_C";
            this.HTrackBar_CMYK_C.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_CMYK_C.TabIndex = 0;
            this.HTrackBar_CMYK_C.TabStop = false;
            this.HTrackBar_CMYK_C.Value = 0D;
            // 
            // HTrackBar_CMYK_M
            // 
            this.HTrackBar_CMYK_M.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_CMYK_M.Colors = new System.Drawing.Color[0];
            this.HTrackBar_CMYK_M.Delta = 5D;
            this.HTrackBar_CMYK_M.Location = new System.Drawing.Point(260, 75);
            this.HTrackBar_CMYK_M.Maximum = 100D;
            this.HTrackBar_CMYK_M.Minimum = 0D;
            this.HTrackBar_CMYK_M.Name = "HTrackBar_CMYK_M";
            this.HTrackBar_CMYK_M.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_CMYK_M.TabIndex = 0;
            this.HTrackBar_CMYK_M.TabStop = false;
            this.HTrackBar_CMYK_M.Value = 0D;
            // 
            // HTrackBar_CMYK_Y
            // 
            this.HTrackBar_CMYK_Y.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_CMYK_Y.Colors = new System.Drawing.Color[0];
            this.HTrackBar_CMYK_Y.Delta = 5D;
            this.HTrackBar_CMYK_Y.Location = new System.Drawing.Point(260, 110);
            this.HTrackBar_CMYK_Y.Maximum = 100D;
            this.HTrackBar_CMYK_Y.Minimum = 0D;
            this.HTrackBar_CMYK_Y.Name = "HTrackBar_CMYK_Y";
            this.HTrackBar_CMYK_Y.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_CMYK_Y.TabIndex = 0;
            this.HTrackBar_CMYK_Y.TabStop = false;
            this.HTrackBar_CMYK_Y.Value = 0D;
            // 
            // HTrackBar_CMYK_K
            // 
            this.HTrackBar_CMYK_K.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_CMYK_K.Colors = new System.Drawing.Color[0];
            this.HTrackBar_CMYK_K.Delta = 5D;
            this.HTrackBar_CMYK_K.Location = new System.Drawing.Point(260, 145);
            this.HTrackBar_CMYK_K.Maximum = 100D;
            this.HTrackBar_CMYK_K.Minimum = 0D;
            this.HTrackBar_CMYK_K.Name = "HTrackBar_CMYK_K";
            this.HTrackBar_CMYK_K.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_CMYK_K.TabIndex = 0;
            this.HTrackBar_CMYK_K.TabStop = false;
            this.HTrackBar_CMYK_K.Value = 0D;
            // 
            // NumEditor_LAB_L
            // 
            this.NumEditor_LAB_L.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_LAB_L.Location = new System.Drawing.Point(180, 40);
            this.NumEditor_LAB_L.Maximum = 100D;
            this.NumEditor_LAB_L.Minimum = 0D;
            this.NumEditor_LAB_L.Name = "NumEditor_LAB_L";
            this.NumEditor_LAB_L.Precision = 0;
            this.NumEditor_LAB_L.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_LAB_L.TabIndex = 0;
            this.NumEditor_LAB_L.TabStop = false;
            this.NumEditor_LAB_L.Value = 0D;
            // 
            // NumEditor_LAB_A
            // 
            this.NumEditor_LAB_A.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_LAB_A.Location = new System.Drawing.Point(180, 75);
            this.NumEditor_LAB_A.Maximum = 100D;
            this.NumEditor_LAB_A.Minimum = 0D;
            this.NumEditor_LAB_A.Name = "NumEditor_LAB_A";
            this.NumEditor_LAB_A.Precision = 0;
            this.NumEditor_LAB_A.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_LAB_A.TabIndex = 0;
            this.NumEditor_LAB_A.TabStop = false;
            this.NumEditor_LAB_A.Value = 0D;
            // 
            // NumEditor_LAB_B
            // 
            this.NumEditor_LAB_B.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_LAB_B.Location = new System.Drawing.Point(180, 110);
            this.NumEditor_LAB_B.Maximum = 100D;
            this.NumEditor_LAB_B.Minimum = 0D;
            this.NumEditor_LAB_B.Name = "NumEditor_LAB_B";
            this.NumEditor_LAB_B.Precision = 0;
            this.NumEditor_LAB_B.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_LAB_B.TabIndex = 0;
            this.NumEditor_LAB_B.TabStop = false;
            this.NumEditor_LAB_B.Value = 0D;
            // 
            // HTrackBar_LAB_L
            // 
            this.HTrackBar_LAB_L.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_LAB_L.Colors = new System.Drawing.Color[0];
            this.HTrackBar_LAB_L.Delta = 5D;
            this.HTrackBar_LAB_L.Location = new System.Drawing.Point(260, 40);
            this.HTrackBar_LAB_L.Maximum = 100D;
            this.HTrackBar_LAB_L.Minimum = 0D;
            this.HTrackBar_LAB_L.Name = "HTrackBar_LAB_L";
            this.HTrackBar_LAB_L.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_LAB_L.TabIndex = 0;
            this.HTrackBar_LAB_L.TabStop = false;
            this.HTrackBar_LAB_L.Value = 0D;
            // 
            // HTrackBar_LAB_A
            // 
            this.HTrackBar_LAB_A.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_LAB_A.Colors = new System.Drawing.Color[0];
            this.HTrackBar_LAB_A.Delta = 5D;
            this.HTrackBar_LAB_A.Location = new System.Drawing.Point(260, 75);
            this.HTrackBar_LAB_A.Maximum = 100D;
            this.HTrackBar_LAB_A.Minimum = 0D;
            this.HTrackBar_LAB_A.Name = "HTrackBar_LAB_A";
            this.HTrackBar_LAB_A.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_LAB_A.TabIndex = 0;
            this.HTrackBar_LAB_A.TabStop = false;
            this.HTrackBar_LAB_A.Value = 0D;
            // 
            // HTrackBar_LAB_B
            // 
            this.HTrackBar_LAB_B.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_LAB_B.Colors = new System.Drawing.Color[0];
            this.HTrackBar_LAB_B.Delta = 5D;
            this.HTrackBar_LAB_B.Location = new System.Drawing.Point(260, 110);
            this.HTrackBar_LAB_B.Maximum = 100D;
            this.HTrackBar_LAB_B.Minimum = 0D;
            this.HTrackBar_LAB_B.Name = "HTrackBar_LAB_B";
            this.HTrackBar_LAB_B.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_LAB_B.TabIndex = 0;
            this.HTrackBar_LAB_B.TabStop = false;
            this.HTrackBar_LAB_B.Value = 0D;
            // 
            // NumEditor_YUV_Y
            // 
            this.NumEditor_YUV_Y.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_YUV_Y.Location = new System.Drawing.Point(180, 40);
            this.NumEditor_YUV_Y.Maximum = 100D;
            this.NumEditor_YUV_Y.Minimum = 0D;
            this.NumEditor_YUV_Y.Name = "NumEditor_YUV_Y";
            this.NumEditor_YUV_Y.Precision = 0;
            this.NumEditor_YUV_Y.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_YUV_Y.TabIndex = 0;
            this.NumEditor_YUV_Y.TabStop = false;
            this.NumEditor_YUV_Y.Value = 0D;
            // 
            // NumEditor_YUV_U
            // 
            this.NumEditor_YUV_U.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_YUV_U.Location = new System.Drawing.Point(180, 75);
            this.NumEditor_YUV_U.Maximum = 100D;
            this.NumEditor_YUV_U.Minimum = 0D;
            this.NumEditor_YUV_U.Name = "NumEditor_YUV_U";
            this.NumEditor_YUV_U.Precision = 0;
            this.NumEditor_YUV_U.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_YUV_U.TabIndex = 0;
            this.NumEditor_YUV_U.TabStop = false;
            this.NumEditor_YUV_U.Value = 0D;
            // 
            // NumEditor_YUV_V
            // 
            this.NumEditor_YUV_V.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NumEditor_YUV_V.Location = new System.Drawing.Point(180, 110);
            this.NumEditor_YUV_V.Maximum = 100D;
            this.NumEditor_YUV_V.Minimum = 0D;
            this.NumEditor_YUV_V.Name = "NumEditor_YUV_V";
            this.NumEditor_YUV_V.Precision = 0;
            this.NumEditor_YUV_V.Size = new System.Drawing.Size(70, 25);
            this.NumEditor_YUV_V.TabIndex = 0;
            this.NumEditor_YUV_V.TabStop = false;
            this.NumEditor_YUV_V.Value = 0D;
            // 
            // HTrackBar_YUV_Y
            // 
            this.HTrackBar_YUV_Y.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_YUV_Y.Colors = new System.Drawing.Color[0];
            this.HTrackBar_YUV_Y.Delta = 5D;
            this.HTrackBar_YUV_Y.Location = new System.Drawing.Point(260, 40);
            this.HTrackBar_YUV_Y.Maximum = 100D;
            this.HTrackBar_YUV_Y.Minimum = 0D;
            this.HTrackBar_YUV_Y.Name = "HTrackBar_YUV_Y";
            this.HTrackBar_YUV_Y.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_YUV_Y.TabIndex = 0;
            this.HTrackBar_YUV_Y.TabStop = false;
            this.HTrackBar_YUV_Y.Value = 0D;
            // 
            // HTrackBar_YUV_U
            // 
            this.HTrackBar_YUV_U.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_YUV_U.Colors = new System.Drawing.Color[0];
            this.HTrackBar_YUV_U.Delta = 5D;
            this.HTrackBar_YUV_U.Location = new System.Drawing.Point(260, 75);
            this.HTrackBar_YUV_U.Maximum = 100D;
            this.HTrackBar_YUV_U.Minimum = 0D;
            this.HTrackBar_YUV_U.Name = "HTrackBar_YUV_U";
            this.HTrackBar_YUV_U.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_YUV_U.TabIndex = 0;
            this.HTrackBar_YUV_U.TabStop = false;
            this.HTrackBar_YUV_U.Value = 0D;
            // 
            // HTrackBar_YUV_V
            // 
            this.HTrackBar_YUV_V.BackColor = System.Drawing.Color.Transparent;
            this.HTrackBar_YUV_V.Colors = new System.Drawing.Color[0];
            this.HTrackBar_YUV_V.Delta = 5D;
            this.HTrackBar_YUV_V.Location = new System.Drawing.Point(260, 110);
            this.HTrackBar_YUV_V.Maximum = 100D;
            this.HTrackBar_YUV_V.Minimum = 0D;
            this.HTrackBar_YUV_V.Name = "HTrackBar_YUV_V";
            this.HTrackBar_YUV_V.Size = new System.Drawing.Size(360, 25);
            this.HTrackBar_YUV_V.TabIndex = 0;
            this.HTrackBar_YUV_V.TabStop = false;
            this.HTrackBar_YUV_V.Value = 0D;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1100, 545);
            this.Controls.Add(this.Panel_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Main";
            this.Panel_Main.ResumeLayout(false);
            this.Panel_LeftArea.ResumeLayout(false);
            this.Panel_EditingColors.ResumeLayout(false);
            this.Panel_Info.ResumeLayout(false);
            this.Panel_Info.PerformLayout();
            this.Panel_View.ResumeLayout(false);
            this.Panel_RightArea.ResumeLayout(false);
            this.Panel_ColorSpaces.ResumeLayout(false);
            this.Panel_Transparency.ResumeLayout(false);
            this.Panel_Transparency.PerformLayout();
            this.Panel_RGB.ResumeLayout(false);
            this.Panel_RGB.PerformLayout();
            this.Panel_HSV.ResumeLayout(false);
            this.Panel_HSV.PerformLayout();
            this.Panel_HSL.ResumeLayout(false);
            this.Panel_HSL.PerformLayout();
            this.Panel_CMYK.ResumeLayout(false);
            this.Panel_CMYK.PerformLayout();
            this.Panel_LAB.ResumeLayout(false);
            this.Panel_LAB.PerformLayout();
            this.Panel_YUV.ResumeLayout(false);
            this.Panel_YUV.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private HTrackBar HTrackBar_RGB_R;
        private HTrackBar HTrackBar_RGB_G;
        private HTrackBar HTrackBar_RGB_B;
        private System.Windows.Forms.Panel Panel_Main;
        private System.Windows.Forms.Panel Panel_RGB;
        private System.Windows.Forms.Label Label_RGB_R;
        private System.Windows.Forms.Label Label_RGB_B;
        private System.Windows.Forms.Label Label_RGB_G;
        private System.Windows.Forms.Panel Panel_Div;
        private System.Windows.Forms.Panel Panel_HSV;
        private System.Windows.Forms.Label Label_HSV_H;
        private System.Windows.Forms.Label Label_HSV_S;
        private System.Windows.Forms.Label Label_HSV_V;
        private HTrackBar HTrackBar_HSV_H;
        private HTrackBar HTrackBar_HSV_S;
        private HTrackBar HTrackBar_HSV_V;
        private System.Windows.Forms.Panel Panel_RightArea;
        private System.Windows.Forms.Panel Panel_ColorSpaces;
        private System.Windows.Forms.Panel Panel_HSL;
        private System.Windows.Forms.Label Label_HSL_H;
        private System.Windows.Forms.Label Label_HSL_S;
        private System.Windows.Forms.Label Label_HSL_L;
        private HTrackBar HTrackBar_HSL_H;
        private HTrackBar HTrackBar_HSL_S;
        private HTrackBar HTrackBar_HSL_L;
        private System.Windows.Forms.Panel Panel_CMYK;
        private System.Windows.Forms.Label Label_CMYK_K;
        private HTrackBar HTrackBar_CMYK_K;
        private System.Windows.Forms.Label Label_CMYK_C;
        private System.Windows.Forms.Label Label_CMYK_M;
        private System.Windows.Forms.Label Label_CMYK_Y;
        private HTrackBar HTrackBar_CMYK_C;
        private HTrackBar HTrackBar_CMYK_M;
        private HTrackBar HTrackBar_CMYK_Y;
        private System.Windows.Forms.Panel Panel_LAB;
        private System.Windows.Forms.Label Label_LAB_L;
        private System.Windows.Forms.Label Label_LAB_A;
        private System.Windows.Forms.Label Label_LAB_B;
        private HTrackBar HTrackBar_LAB_L;
        private HTrackBar HTrackBar_LAB_A;
        private HTrackBar HTrackBar_LAB_B;
        private System.Windows.Forms.Panel Panel_LeftArea;
        private System.Windows.Forms.Panel Panel_YUV;
        private System.Windows.Forms.Label Label_YUV_Y;
        private System.Windows.Forms.Label Label_YUV_U;
        private System.Windows.Forms.Label Label_YUV_V;
        private HTrackBar HTrackBar_YUV_Y;
        private HTrackBar HTrackBar_YUV_U;
        private HTrackBar HTrackBar_YUV_V;
        private System.Windows.Forms.Label Label_Abbr_RGB_R;
        private System.Windows.Forms.Label Label_Abbr_RGB_B;
        private System.Windows.Forms.Label Label_Abbr_RGB_G;
        private System.Windows.Forms.Label Label_Abbr_HSV_H;
        private System.Windows.Forms.Label Label_Abbr_HSV_S;
        private System.Windows.Forms.Label Label_Abbr_HSV_V;
        private System.Windows.Forms.Label Label_Abbr_HSL_H;
        private System.Windows.Forms.Label Label_Abbr_HSL_S;
        private System.Windows.Forms.Label Label_Abbr_HSL_L;
        private System.Windows.Forms.Label Label_Abbr_CMYK_K;
        private System.Windows.Forms.Label Label_Abbr_CMYK_C;
        private System.Windows.Forms.Label Label_Abbr_CMYK_M;
        private System.Windows.Forms.Label Label_Abbr_CMYK_Y;
        private System.Windows.Forms.Label Label_Abbr_LAB_L;
        private System.Windows.Forms.Label Label_Abbr_LAB_A;
        private System.Windows.Forms.Label Label_Abbr_LAB_B;
        private System.Windows.Forms.Label Label_Abbr_YUV_Y;
        private System.Windows.Forms.Label Label_Abbr_YUV_U;
        private System.Windows.Forms.Label Label_Abbr_YUV_V;
        private System.Windows.Forms.Panel Panel_Transparency;
        private System.Windows.Forms.Label Label_Abbr_Opacity;
        private System.Windows.Forms.Label Label_Abbr_Alpha;
        private System.Windows.Forms.Label Label_Opacity;
        private System.Windows.Forms.Label Label_Alpha;
        private HTrackBar HTrackBar_Opacity;
        private HTrackBar HTrackBar_Alpha;
        private NumEditor NumEditor_RGB_R;
        private NumEditor NumEditor_Alpha;
        private NumEditor NumEditor_Opacity;
        private NumEditor NumEditor_RGB_B;
        private NumEditor NumEditor_RGB_G;
        private NumEditor NumEditor_HSV_H;
        private NumEditor NumEditor_HSV_S;
        private NumEditor NumEditor_HSV_V;
        private NumEditor NumEditor_HSL_H;
        private NumEditor NumEditor_HSL_S;
        private NumEditor NumEditor_HSL_L;
        private NumEditor NumEditor_CMYK_K;
        private NumEditor NumEditor_CMYK_C;
        private NumEditor NumEditor_CMYK_M;
        private NumEditor NumEditor_CMYK_Y;
        private NumEditor NumEditor_LAB_L;
        private NumEditor NumEditor_LAB_A;
        private NumEditor NumEditor_LAB_B;
        private NumEditor NumEditor_YUV_Y;
        private NumEditor NumEditor_YUV_U;
        private NumEditor NumEditor_YUV_V;
        private System.Windows.Forms.ImageList ImageList_FoldAndUnfold;
        private System.Windows.Forms.Button Button_Transparency;
        private System.Windows.Forms.Button Button_RGB;
        private System.Windows.Forms.Button Button_HSV;
        private System.Windows.Forms.Button Button_HSL;
        private System.Windows.Forms.Button Button_CMYK;
        private System.Windows.Forms.Button Button_LAB;
        private System.Windows.Forms.Button Button_YUV;
        private System.Windows.Forms.Button Button_Background;
        private System.Windows.Forms.Button Button_Text;
        private System.Windows.Forms.Button Button_Label;
        private System.Windows.Forms.Button Button_Border;
        private System.Windows.Forms.Panel Panel_View;
        private System.Windows.Forms.Panel Panel_EditingColors;
        private System.Windows.Forms.Button Button_View;
        private System.Windows.Forms.Panel Panel_Info;
        private System.Windows.Forms.Button Button_Info;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.Label Label_Name_Val;
        private System.Windows.Forms.Label Label_Grayscale;
        private System.Windows.Forms.Label Label_Grayscale_Val;
        private System.Windows.Forms.Label Label_Complementary_Val;
        private System.Windows.Forms.Label Label_Complementary;
        private System.Windows.Forms.Label Label_Grayscale_Val2;
        private System.Windows.Forms.Label Label_CurrentColor;
    }
}