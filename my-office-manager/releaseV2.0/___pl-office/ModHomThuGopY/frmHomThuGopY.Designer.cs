namespace office
{
    partial class frmHomThuGopY
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
            this.lblThoiGianCapNhat = new DevExpress.XtraEditors.LabelControl();
            this.lblNguoiCapNhat = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.txtTieude = new DevExpress.XtraEditors.TextEdit();
            this.chkAnHien = new DevExpress.XtraEditors.CheckEdit();
            this.plLabel4 = new System.Windows.Forms.PLLabel();
            this.NguoiNhanMail = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.NguoiNhan = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.NoiDung = new DevExpress.XtraRichEdit.Demos.PLRichTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTieude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAnHien.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblThoiGianCapNhat
            // 
            this.lblThoiGianCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThoiGianCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianCapNhat.Appearance.Options.UseFont = true;
            this.lblThoiGianCapNhat.Location = new System.Drawing.Point(527, 42);
            this.lblThoiGianCapNhat.Name = "lblThoiGianCapNhat";
            this.lblThoiGianCapNhat.Size = new System.Drawing.Size(109, 13);
            this.lblThoiGianCapNhat.TabIndex = 18;
            this.lblThoiGianCapNhat.Text = "lblThoiGianCapNhat";
            // 
            // lblNguoiCapNhat
            // 
            this.lblNguoiCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNguoiCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiCapNhat.Appearance.Options.UseFont = true;
            this.lblNguoiCapNhat.Location = new System.Drawing.Point(527, 20);
            this.lblNguoiCapNhat.Name = "lblNguoiCapNhat";
            this.lblNguoiCapNhat.Size = new System.Drawing.Size(91, 13);
            this.lblNguoiCapNhat.TabIndex = 19;
            this.lblNguoiCapNhat.Text = "lblNguoiCapNhat";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(395, 42);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(74, 13);
            this.labelControl4.TabIndex = 16;
            this.labelControl4.Text = "Thời gian góp ý";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(12, 17);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(63, 13);
            this.plLabel1.TabIndex = 21;
            this.plLabel1.Text = "Vấn đề góp ý";
            this.plLabel1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnDong);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(471, 419);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(278, 30);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(203, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(72, 23);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đón&g";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(125, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // plLabel2
            // 
            this.plLabel2.Location = new System.Drawing.Point(12, 42);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(55, 13);
            this.plLabel2.TabIndex = 35;
            this.plLabel2.Text = "Người nhận";
            this.plLabel2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // txtTieude
            // 
            this.txtTieude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTieude.Location = new System.Drawing.Point(81, 14);
            this.txtTieude.Name = "txtTieude";
            this.txtTieude.Size = new System.Drawing.Size(243, 20);
            this.txtTieude.TabIndex = 0;
            // 
            // chkAnHien
            // 
            this.chkAnHien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAnHien.Location = new System.Drawing.Point(393, 17);
            this.chkAnHien.Name = "chkAnHien";
            this.chkAnHien.Properties.Caption = "Hiện tên người góp ý: ";
            this.chkAnHien.Size = new System.Drawing.Size(128, 19);
            this.chkAnHien.TabIndex = 2;
            // 
            // plLabel4
            // 
            this.plLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plLabel4.Location = new System.Drawing.Point(12, 426);
            this.plLabel4.Name = "plLabel4";
            this.plLabel4.Size = new System.Drawing.Size(120, 13);
            this.plLabel4.TabIndex = 157;
            this.plLabel4.Text = "Gửi e-mail thông báo đến";
            this.plLabel4.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // NguoiNhanMail
            // 
            this.NguoiNhanMail.Location = new System.Drawing.Point(138, 425);
            this.NguoiNhanMail.Name = "NguoiNhanMail";
            this.NguoiNhanMail.Size = new System.Drawing.Size(243, 20);
            this.NguoiNhanMail.TabIndex = 4;
            this.NguoiNhanMail.ZZZWidthFactor = 2F;
            // 
            // NguoiNhan
            // 
            this.NguoiNhan.Location = new System.Drawing.Point(81, 40);
            this.NguoiNhan.Name = "NguoiNhan";
            this.NguoiNhan.Size = new System.Drawing.Size(243, 20);
            this.NguoiNhan.TabIndex = 1;
            // 
            // NoiDung
            // 
            this.NoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NoiDung.Location = new System.Drawing.Point(3, 84);
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Size = new System.Drawing.Size(745, 329);
            this.NoiDung.TabIndex = 3;
            // 
            // frmHomThuGopY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 459);
            this.Controls.Add(this.NguoiNhanMail);
            this.Controls.Add(this.NguoiNhan);
            this.Controls.Add(this.plLabel4);
            this.Controls.Add(this.chkAnHien);
            this.Controls.Add(this.NoiDung);
            this.Controls.Add(this.txtTieude);
            this.Controls.Add(this.plLabel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.plLabel1);
            this.Controls.Add(this.lblThoiGianCapNhat);
            this.Controls.Add(this.lblNguoiCapNhat);
            this.Controls.Add(this.labelControl4);
            this.Name = "frmHomThuGopY";
            this.Text = "Hòm thư góp ý";
            this.Load += new System.EventHandler(this.frmHomThuGopY_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTieude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAnHien.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblThoiGianCapNhat;
        private DevExpress.XtraEditors.LabelControl lblNguoiCapNhat;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel plLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private System.Windows.Forms.PLLabel plLabel2;
        private DevExpress.XtraEditors.TextEdit txtTieude;
        private DevExpress.XtraRichEdit.Demos.PLRichTextBox NoiDung;
        private DevExpress.XtraEditors.CheckEdit chkAnHien;
        private System.Windows.Forms.PLLabel plLabel4;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiNhan;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiNhanMail;
        public DevExpress.XtraEditors.SimpleButton btnSave;
    }
}