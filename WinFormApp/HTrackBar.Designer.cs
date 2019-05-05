namespace WinFormApp
{
    partial class HTrackBar
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel_Main = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Panel_Main
            // 
            this.Panel_Main.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Main.Location = new System.Drawing.Point(0, 0);
            this.Panel_Main.Name = "Panel_Main";
            this.Panel_Main.Size = new System.Drawing.Size(150, 150);
            this.Panel_Main.TabIndex = 0;
            this.Panel_Main.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Main_Paint);
            this.Panel_Main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_Main_MouseDown);
            this.Panel_Main.MouseEnter += new System.EventHandler(this.Panel_Main_MouseEnter);
            this.Panel_Main.MouseLeave += new System.EventHandler(this.Panel_Main_MouseLeave);
            this.Panel_Main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_Main_MouseMove);
            this.Panel_Main.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel_Main_MouseUp);
            this.Panel_Main.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Panel_Main_MouseWheel);
            // 
            // HTrackBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Panel_Main);
            this.Name = "HTrackBar";
            this.Load += new System.EventHandler(this.HTrackBar_Load);
            this.SizeChanged += new System.EventHandler(this.HTrackBar_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Main;
    }
}
