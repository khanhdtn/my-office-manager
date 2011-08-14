namespace office
{
    partial class frmSendFax
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
            this.txtNguoiNhan = new DevExpress.XtraEditors.TextEdit();
            this.txtGuiDenSo = new DevExpress.XtraEditors.TextEdit();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.plLabel3 = new System.Windows.Forms.PLLabel();
            this.txtTenFile = new DevExpress.XtraEditors.TextEdit();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiNhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGuiDenSo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenFile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNguoiNhan
            // 
            this.txtNguoiNhan.Location = new System.Drawing.Point(73, 9);
            this.txtNguoiNhan.Name = "txtNguoiNhan";
            this.txtNguoiNhan.Properties.ReadOnly = true;
            this.txtNguoiNhan.Size = new System.Drawing.Size(171, 20);
            this.txtNguoiNhan.TabIndex = 8;
            // 
            // txtGuiDenSo
            // 
            this.txtGuiDenSo.Location = new System.Drawing.Point(73, 35);
            this.txtGuiDenSo.Name = "txtGuiDenSo";
            this.txtGuiDenSo.Properties.ReadOnly = true;
            this.txtGuiDenSo.Size = new System.Drawing.Size(171, 20);
            this.txtGuiDenSo.TabIndex = 7;
            // 
            // plLabel2
            // 
            this.plLabel2.Location = new System.Drawing.Point(12, 12);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(55, 13);
            this.plLabel2.TabIndex = 5;
            this.plLabel2.Text = "Người nhận";
            this.plLabel2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(12, 38);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(51, 13);
            this.plLabel1.TabIndex = 6;
            this.plLabel1.Text = "Gửi đến số";
            this.plLabel1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel3
            // 
            this.plLabel3.Location = new System.Drawing.Point(12, 64);
            this.plLabel3.Name = "plLabel3";
            this.plLabel3.Size = new System.Drawing.Size(35, 13);
            this.plLabel3.TabIndex = 9;
            this.plLabel3.Text = "Tên file";
            this.plLabel3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel3.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // txtTenFile
            // 
            this.txtTenFile.Location = new System.Drawing.Point(73, 61);
            this.txtTenFile.Name = "txtTenFile";
            this.txtTenFile.Properties.ReadOnly = true;
            this.txtTenFile.Size = new System.Drawing.Size(171, 20);
            this.txtTenFile.TabIndex = 10;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(96, 93);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(72, 23);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "&Gửi";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(174, 93);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "&Đóng";
            // 
            // frmSendFax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 128);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtTenFile);
            this.Controls.Add(this.plLabel3);
            this.Controls.Add(this.txtNguoiNhan);
            this.Controls.Add(this.txtGuiDenSo);
            this.Controls.Add(this.plLabel2);
            this.Controls.Add(this.plLabel1);
            this.Name = "frmSendFax";
            this.Text = "Gửi fax";
            this.Load += new System.EventHandler(this.frmSendFax_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiNhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGuiDenSo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenFile.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit txtNguoiNhan;
        public DevExpress.XtraEditors.TextEdit txtGuiDenSo;
        private System.Windows.Forms.PLLabel plLabel2;
        private System.Windows.Forms.PLLabel plLabel1;
        private System.Windows.Forms.PLLabel plLabel3;
        public DevExpress.XtraEditors.TextEdit txtTenFile;
        public DevExpress.XtraEditors.SimpleButton btnLuu;
        public DevExpress.XtraEditors.SimpleButton btnClose;
    }
}