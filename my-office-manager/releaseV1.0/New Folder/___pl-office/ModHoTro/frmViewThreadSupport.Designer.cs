namespace office
{
    partial class frmViewThreadSupport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.btn_TL = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.flowLayoutPanel2.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnDong);
            this.flowLayoutPanel2.Controls.Add(this.btn_TL);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 253);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(703, 30);
            this.flowLayoutPanel2.TabIndex = 136;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(639, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(61, 23);
            this.btnDong.TabIndex = 27;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnTL_Click_1);
            // 
            // btn_TL
            // 
            this.btn_TL.Location = new System.Drawing.Point(572, 3);
            this.btn_TL.Name = "btn_TL";
            this.btn_TL.Size = new System.Drawing.Size(61, 23);
            this.btn_TL.TabIndex = 29;
            this.btn_TL.Text = "Phản hồi";
            this.btn_TL.Click += new System.EventHandler(this.btn_TL_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(694, 207);
            this.flowLayoutPanel1.TabIndex = 137;
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraScrollableControl1.Controls.Add(this.flowLayoutPanel1);
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 12);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(700, 235);
            this.xtraScrollableControl1.TabIndex = 139;
            // 
            // frmViewThreadSupport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 283);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmViewThreadSupport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCapNhat_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            this.xtraScrollableControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public DevExpress.XtraEditors.SimpleButton btnDong;
        public DevExpress.XtraEditors.SimpleButton btn_TL;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;





    }
}