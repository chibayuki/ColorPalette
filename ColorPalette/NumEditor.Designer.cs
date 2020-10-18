namespace ColorPalette
{
    partial class NumEditor
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
            this.TextBox_Num = new System.Windows.Forms.TextBox();
            this.Panel_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Main
            // 
            this.Panel_Main.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Main.Controls.Add(this.TextBox_Num);
            this.Panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Main.Location = new System.Drawing.Point(0, 0);
            this.Panel_Main.Name = "Panel_Main";
            this.Panel_Main.Size = new System.Drawing.Size(150, 150);
            this.Panel_Main.TabIndex = 0;
            this.Panel_Main.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Main_Paint);
            // 
            // TextBox_Num
            // 
            this.TextBox_Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox_Num.Location = new System.Drawing.Point(3, 3);
            this.TextBox_Num.Name = "TextBox_Num";
            this.TextBox_Num.Size = new System.Drawing.Size(100, 14);
            this.TextBox_Num.TabIndex = 0;
            this.TextBox_Num.TabStop = false;
            this.TextBox_Num.SizeChanged += new System.EventHandler(this.TextBox_Num_SizeChanged);
            this.TextBox_Num.TextChanged += new System.EventHandler(this.TextBox_Num_TextChanged);
            // 
            // NumEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Panel_Main);
            this.Name = "NumEditor";
            this.Load += new System.EventHandler(this.NumEditor_Load);
            this.SizeChanged += new System.EventHandler(this.NumEditor_SizeChanged);
            this.Panel_Main.ResumeLayout(false);
            this.Panel_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Main;
        private System.Windows.Forms.TextBox TextBox_Num;
    }
}
