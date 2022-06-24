namespace PID
{
    partial class frmMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStart2 = new System.Windows.Forms.Button();
            this.numP = new System.Windows.Forms.NumericUpDown();
            this.numI = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numI)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo1
            // 
            this.lblInfo1.AutoSize = true;
            this.lblInfo1.Location = new System.Drawing.Point(223, 57);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(44, 18);
            this.lblInfo1.TabIndex = 0;
            this.lblInfo1.Text = "超调";
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.Location = new System.Drawing.Point(483, 56);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(80, 18);
            this.lblInfo2.TabIndex = 1;
            this.lblInfo2.Text = "调节时间";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(57, 102);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(142, 58);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "普通PID算法";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStart2
            // 
            this.btnStart2.Location = new System.Drawing.Point(57, 166);
            this.btnStart2.Name = "btnStart2";
            this.btnStart2.Size = new System.Drawing.Size(142, 59);
            this.btnStart2.TabIndex = 3;
            this.btnStart2.Text = "积分分离算法";
            this.btnStart2.UseVisualStyleBackColor = true;
            this.btnStart2.Click += new System.EventHandler(this.btnStart2_Click);
            // 
            // numP
            // 
            this.numP.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numP.Location = new System.Drawing.Point(57, 258);
            this.numP.Name = "numP";
            this.numP.Size = new System.Drawing.Size(120, 28);
            this.numP.TabIndex = 4;
            this.numP.Value = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            // 
            // numI
            // 
            this.numI.Location = new System.Drawing.Point(57, 337);
            this.numI.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numI.Name = "numI";
            this.numI.Size = new System.Drawing.Size(120, 28);
            this.numI.TabIndex = 5;
            this.numI.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(205, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(733, 376);
            this.panel2.TabIndex = 6;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 504);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.numI);
            this.Controls.Add(this.numP);
            this.Controls.Add(this.btnStart2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblInfo2);
            this.Controls.Add(this.lblInfo1);
            this.Name = "frmMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStart2;
        private System.Windows.Forms.NumericUpDown numP;
        private System.Windows.Forms.NumericUpDown numI;
        private System.Windows.Forms.Panel panel2;
    }
}

