namespace office
{
    partial class frmNhatKyDuAn
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
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.memoGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.buttonLuu = new DevExpress.XtraEditors.SimpleButton();
            this.buttonThoat = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.txtTenDuAn = new System.Windows.Forms.PLLabel();
            this.txtNguoiCapNhat = new System.Windows.Forms.PLLabel();
            this.txtThoiGianCapNhat = new System.Windows.Forms.PLLabel();
            ((System.ComponentModel.ISupportInitialize)(this.memoGhiChu.Properties)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(247, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Người cập nhật";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(243, 37);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(89, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Thời gian cập nhật";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // memoGhiChu
            // 
            this.memoGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memoGhiChu.Location = new System.Drawing.Point(6, 60);
            this.memoGhiChu.Name = "memoGhiChu";
            this.memoGhiChu.Size = new System.Drawing.Size(448, 82);
            this.memoGhiChu.TabIndex = 5;
            // 
            // buttonLuu
            // 
            this.buttonLuu.Location = new System.Drawing.Point(7, 3);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(72, 23);
            this.buttonLuu.TabIndex = 6;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // buttonThoat
            // 
            this.buttonThoat.Location = new System.Drawing.Point(85, 3);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(72, 23);
            this.buttonThoat.TabIndex = 7;
            this.buttonThoat.Text = "Đóng";
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.buttonThoat);
            this.flowLayoutPanel1.Controls.Add(this.buttonLuu);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(294, 150);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(160, 29);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(9, 10);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(30, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Dự án";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(5, 40);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(42, 13);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "Nội dung";
            this.labelControl4.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // txtTenDuAn
            // 
            this.txtTenDuAn.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTenDuAn.Appearance.Options.UseFont = true;
            this.txtTenDuAn.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.txtTenDuAn.Location = new System.Drawing.Point(55, 10);
            this.txtTenDuAn.Name = "txtTenDuAn";
            this.txtTenDuAn.Size = new System.Drawing.Size(185, 13);
            this.txtTenDuAn.TabIndex = 0;
            this.txtTenDuAn.Text = "<Tên>";
            this.txtTenDuAn.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // txtNguoiCapNhat
            // 
            this.txtNguoiCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtNguoiCapNhat.Appearance.Options.UseFont = true;
            this.txtNguoiCapNhat.Location = new System.Drawing.Point(338, 10);
            this.txtNguoiCapNhat.Name = "txtNguoiCapNhat";
            this.txtNguoiCapNhat.Size = new System.Drawing.Size(102, 13);
            this.txtNguoiCapNhat.TabIndex = 1;
            this.txtNguoiCapNhat.Text = "<Người cập nhật>";
            this.txtNguoiCapNhat.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // txtThoiGianCapNhat
            // 
            this.txtThoiGianCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtThoiGianCapNhat.Appearance.Options.UseFont = true;
            this.txtThoiGianCapNhat.Location = new System.Drawing.Point(337, 37);
            this.txtThoiGianCapNhat.Name = "txtThoiGianCapNhat";
            this.txtThoiGianCapNhat.Size = new System.Drawing.Size(121, 13);
            this.txtThoiGianCapNhat.TabIndex = 2;
            this.txtThoiGianCapNhat.Text = "<Thời gian cập nhật>";
            this.txtThoiGianCapNhat.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // frmNhatKyDuAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 184);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.memoGhiChu);
            this.Controls.Add(this.txtTenDuAn);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtThoiGianCapNhat);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtNguoiCapNhat);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmNhatKyDuAn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ghi nhật ký";
            this.Load += new System.EventHandler(this.frmNhatKyDuAn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memoGhiChu.Properties)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit memoGhiChu;
        public DevExpress.XtraEditors.SimpleButton buttonLuu;
        private DevExpress.XtraEditors.SimpleButton buttonThoat;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel txtTenDuAn;
        private System.Windows.Forms.PLLabel txtNguoiCapNhat;
        private System.Windows.Forms.PLLabel txtThoiGianCapNhat;
    }
}