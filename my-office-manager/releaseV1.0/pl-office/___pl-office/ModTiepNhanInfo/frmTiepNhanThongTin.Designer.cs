namespace office
{
    partial class frmTiepNhanThongTin
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
            this.cmbNguonTin = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.plLabel3 = new System.Windows.Forms.PLLabel();
            this.plLabel6 = new System.Windows.Forms.PLLabel();
            this.txtVanDe = new DevExpress.XtraEditors.TextEdit();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblThoiGianCapNhat = new DevExpress.XtraEditors.LabelControl();
            this.lblNguoiCapNhat = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.PLTinhtrang = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.plLabel4 = new System.Windows.Forms.PLLabel();
            this.NguoiNhanMail = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.NguoiXuLy = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.NoiDung = new DevExpress.XtraRichEdit.Demos.PLRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtVanDe.Properties)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbNguonTin
            // 
            this.cmbNguonTin.DataSource = null;
            this.cmbNguonTin.DisplayField = null;
            this.cmbNguonTin.Location = new System.Drawing.Point(101, 12);
            this.cmbNguonTin.Name = "cmbNguonTin";
            this.cmbNguonTin.Size = new System.Drawing.Size(134, 20);
            this.cmbNguonTin.TabIndex = 0;
            this.cmbNguonTin.ValueField = "";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Nguồn thông tin";
            this.labelControl2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel3
            // 
            this.plLabel3.Location = new System.Drawing.Point(13, 42);
            this.plLabel3.Name = "plLabel3";
            this.plLabel3.Size = new System.Drawing.Size(55, 13);
            this.plLabel3.TabIndex = 7;
            this.plLabel3.Text = "Người xử lý";
            this.plLabel3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel3.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel6
            // 
            this.plLabel6.Location = new System.Drawing.Point(13, 67);
            this.plLabel6.Name = "plLabel6";
            this.plLabel6.Size = new System.Drawing.Size(81, 13);
            this.plLabel6.TabIndex = 6;
            this.plLabel6.Text = "Vấn đề tiếp nhận";
            this.plLabel6.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel6.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // txtVanDe
            // 
            this.txtVanDe.Location = new System.Drawing.Point(101, 64);
            this.txtVanDe.Name = "txtVanDe";
            this.txtVanDe.Size = new System.Drawing.Size(359, 20);
            this.txtVanDe.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(489, 457);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(245, 29);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(170, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đón&g";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(92, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblThoiGianCapNhat
            // 
            this.lblThoiGianCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThoiGianCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianCapNhat.Appearance.Options.UseFont = true;
            this.lblThoiGianCapNhat.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblThoiGianCapNhat.Location = new System.Drawing.Point(598, 40);
            this.lblThoiGianCapNhat.Name = "lblThoiGianCapNhat";
            this.lblThoiGianCapNhat.Size = new System.Drawing.Size(148, 18);
            this.lblThoiGianCapNhat.TabIndex = 18;
            this.lblThoiGianCapNhat.Text = "lblThoiGianCapNhat";
            // 
            // lblNguoiCapNhat
            // 
            this.lblNguoiCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNguoiCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiCapNhat.Appearance.Options.UseFont = true;
            this.lblNguoiCapNhat.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNguoiCapNhat.Location = new System.Drawing.Point(598, 14);
            this.lblNguoiCapNhat.Name = "lblNguoiCapNhat";
            this.lblNguoiCapNhat.Size = new System.Drawing.Size(148, 18);
            this.lblNguoiCapNhat.TabIndex = 19;
            this.lblNguoiCapNhat.Text = "lblNguoiCapNhat";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(501, 42);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(92, 13);
            this.labelControl4.TabIndex = 16;
            this.labelControl4.Text = "Thời gian tiếp nhận";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(501, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(77, 13);
            this.labelControl3.TabIndex = 17;
            this.labelControl3.Text = "Người tiếp nhận";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(13, 94);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(42, 13);
            this.plLabel1.TabIndex = 20;
            this.plLabel1.Text = "Nội dung";
            this.plLabel1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel2
            // 
            this.plLabel2.Location = new System.Drawing.Point(271, 16);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(49, 13);
            this.plLabel2.TabIndex = 21;
            this.plLabel2.Text = "Tình trạng";
            this.plLabel2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // PLTinhtrang
            // 
            this.PLTinhtrang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PLTinhtrang.DataSource = null;
            this.PLTinhtrang.DisplayField = null;
            this.PLTinhtrang.Location = new System.Drawing.Point(326, 12);
            this.PLTinhtrang.Name = "PLTinhtrang";
            this.PLTinhtrang.Size = new System.Drawing.Size(134, 20);
            this.PLTinhtrang.TabIndex = 1;
            this.PLTinhtrang.ValueField = "";
            // 
            // plLabel4
            // 
            this.plLabel4.Location = new System.Drawing.Point(13, 466);
            this.plLabel4.Name = "plLabel4";
            this.plLabel4.Size = new System.Drawing.Size(120, 13);
            this.plLabel4.TabIndex = 157;
            this.plLabel4.Text = "Gửi e-mail thông báo đến";
            this.plLabel4.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // NguoiNhanMail
            // 
            this.NguoiNhanMail.Location = new System.Drawing.Point(139, 463);
            this.NguoiNhanMail.Name = "NguoiNhanMail";
            this.NguoiNhanMail.Size = new System.Drawing.Size(228, 20);
            this.NguoiNhanMail.TabIndex = 5;
            this.NguoiNhanMail.ZZZWidthFactor = 2F;
            // 
            // NguoiXuLy
            // 
            this.NguoiXuLy.Location = new System.Drawing.Point(101, 38);
            this.NguoiXuLy.Name = "NguoiXuLy";
            this.NguoiXuLy.Size = new System.Drawing.Size(359, 20);
            this.NguoiXuLy.TabIndex = 2;
            // 
            // NoiDung
            // 
            this.NoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NoiDung.Location = new System.Drawing.Point(4, 113);
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Size = new System.Drawing.Size(738, 338);
            this.NoiDung.TabIndex = 4;
            // 
            // frmTiepNhanThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 494);
            this.Controls.Add(this.NguoiNhanMail);
            this.Controls.Add(this.NguoiXuLy);
            this.Controls.Add(this.plLabel4);
            this.Controls.Add(this.NoiDung);
            this.Controls.Add(this.PLTinhtrang);
            this.Controls.Add(this.plLabel2);
            this.Controls.Add(this.plLabel1);
            this.Controls.Add(this.lblThoiGianCapNhat);
            this.Controls.Add(this.lblNguoiCapNhat);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtVanDe);
            this.Controls.Add(this.plLabel3);
            this.Controls.Add(this.plLabel6);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cmbNguonTin);
            this.Name = "frmTiepNhanThongTin";
            this.Text = "Tiếp nhận thông tin";
            this.Load += new System.EventHandler(this.frmTiepNhanThongTin_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.txtVanDe.Properties)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProtocolVN.Framework.Win.PLImgCombobox cmbNguonTin;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel plLabel3;
        private System.Windows.Forms.PLLabel plLabel6;
        private DevExpress.XtraEditors.TextEdit txtVanDe;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        public DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl lblThoiGianCapNhat;
        private DevExpress.XtraEditors.LabelControl lblNguoiCapNhat;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel plLabel1;
        private System.Windows.Forms.PLLabel plLabel2;
        private ProtocolVN.Framework.Win.PLImgCombobox PLTinhtrang;
        private DevExpress.XtraRichEdit.Demos.PLRichTextBox NoiDung;
        private System.Windows.Forms.PLLabel plLabel4;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiXuLy;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiNhanMail;
    }
}