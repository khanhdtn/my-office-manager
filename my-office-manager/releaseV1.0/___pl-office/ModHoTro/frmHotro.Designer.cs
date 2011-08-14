using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmHotro
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
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.lblTGYeuCau = new System.Windows.Forms.PLLabel();
            this.lblNguoiYeuCau = new System.Windows.Forms.PLLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.PLTinhtrang = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.PLMucuutien = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.PLLoaiYeuCau = new ProtocolVN.Framework.Win.PLCombobox();
            this.lblThoiGianGui = new DevExpress.XtraEditors.LabelControl();
            this.lblNguoiGui = new DevExpress.XtraEditors.LabelControl();
            this.plLabel4 = new System.Windows.Forms.PLLabel();
            this.txtChude = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.pllblNguoiHoTro = new System.Windows.Forms.PLLabel();
            this.plLabel6 = new System.Windows.Forms.PLLabel();
            this.plLabel7 = new System.Windows.Forms.PLLabel();
            this.plLabel8 = new System.Windows.Forms.PLLabel();
            this.NguoiNhanEmail = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.NguoiHoTro = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.plMultiChoiceFiles1 = new office.PLMultiChoiceFiles();
            this.NoiDung = new DevExpress.XtraRichEdit.Demos.PLRichTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChude.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(254, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đón&g";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(176, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(72, 23);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(187, 90);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Độ ưu tiên";
            this.labelControl2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // lblTGYeuCau
            // 
            this.lblTGYeuCau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTGYeuCau.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblTGYeuCau.Appearance.Options.UseFont = true;
            this.lblTGYeuCau.Location = new System.Drawing.Point(387, 42);
            this.lblTGYeuCau.Name = "lblTGYeuCau";
            this.lblTGYeuCau.Size = new System.Drawing.Size(85, 13);
            this.lblTGYeuCau.TabIndex = 0;
            this.lblTGYeuCau.Text = "Thời gian yêu cầu";
            this.lblTGYeuCau.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // lblNguoiYeuCau
            // 
            this.lblNguoiYeuCau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNguoiYeuCau.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblNguoiYeuCau.Appearance.Options.UseFont = true;
            this.lblNguoiYeuCau.Location = new System.Drawing.Point(387, 19);
            this.lblNguoiYeuCau.Name = "lblNguoiYeuCau";
            this.lblNguoiYeuCau.Size = new System.Drawing.Size(70, 13);
            this.lblNguoiYeuCau.TabIndex = 0;
            this.lblNguoiYeuCau.Text = "Người yêu cầu";
            this.lblNguoiYeuCau.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnLuu);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(408, 428);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(329, 30);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // PLTinhtrang
            // 
            this.PLTinhtrang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PLTinhtrang.DataSource = null;
            this.PLTinhtrang.DisplayField = null;
            this.PLTinhtrang.Location = new System.Drawing.Point(74, 85);
            this.PLTinhtrang.Name = "PLTinhtrang";
            this.PLTinhtrang.Size = new System.Drawing.Size(99, 20);
            this.PLTinhtrang.TabIndex = 2;
            this.PLTinhtrang.ValueField = "";
            // 
            // PLMucuutien
            // 
            this.PLMucuutien.DataSource = null;
            this.PLMucuutien.DisplayField = null;
            this.PLMucuutien.Location = new System.Drawing.Point(244, 86);
            this.PLMucuutien.Name = "PLMucuutien";
            this.PLMucuutien.Size = new System.Drawing.Size(99, 20);
            this.PLMucuutien.TabIndex = 3;
            this.PLMucuutien.ValueField = "";
            // 
            // PLLoaiYeuCau
            // 
            this.PLLoaiYeuCau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PLLoaiYeuCau.DataSource = null;
            this.PLLoaiYeuCau.DisplayField = null;
            this.PLLoaiYeuCau.Location = new System.Drawing.Point(74, 15);
            this.PLLoaiYeuCau.Name = "PLLoaiYeuCau";
            this.PLLoaiYeuCau.Size = new System.Drawing.Size(269, 20);
            this.PLLoaiYeuCau.TabIndex = 0;
            this.PLLoaiYeuCau.ValueField = null;
            // 
            // lblThoiGianGui
            // 
            this.lblThoiGianGui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThoiGianGui.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianGui.Appearance.Options.UseFont = true;
            this.lblThoiGianGui.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblThoiGianGui.Location = new System.Drawing.Point(482, 42);
            this.lblThoiGianGui.Name = "lblThoiGianGui";
            this.lblThoiGianGui.Size = new System.Drawing.Size(138, 13);
            this.lblThoiGianGui.TabIndex = 17;
            this.lblThoiGianGui.Text = "lblThoiGianCapNhat";
            // 
            // lblNguoiGui
            // 
            this.lblNguoiGui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNguoiGui.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiGui.Appearance.Options.UseFont = true;
            this.lblNguoiGui.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNguoiGui.Location = new System.Drawing.Point(482, 19);
            this.lblNguoiGui.Name = "lblNguoiGui";
            this.lblNguoiGui.Size = new System.Drawing.Size(138, 13);
            this.lblNguoiGui.TabIndex = 16;
            this.lblNguoiGui.Text = "lblNguoiCapNhat";
            // 
            // plLabel4
            // 
            this.plLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plLabel4.Location = new System.Drawing.Point(9, 434);
            this.plLabel4.Name = "plLabel4";
            this.plLabel4.Size = new System.Drawing.Size(120, 13);
            this.plLabel4.TabIndex = 155;
            this.plLabel4.Text = "Gửi e-mail thông báo đến";
            this.plLabel4.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // txtChude
            // 
            this.txtChude.Location = new System.Drawing.Point(74, 42);
            this.txtChude.Name = "txtChude";
            this.txtChude.Size = new System.Drawing.Size(269, 37);
            this.txtChude.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(387, 90);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 171;
            this.labelControl1.Text = "File đính kèm";
            this.labelControl1.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(8, 89);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(49, 13);
            this.plLabel1.TabIndex = 170;
            this.plLabel1.Text = "Tình trạng";
            this.plLabel1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // pllblNguoiHoTro
            // 
            this.pllblNguoiHoTro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pllblNguoiHoTro.Location = new System.Drawing.Point(387, 65);
            this.pllblNguoiHoTro.Name = "pllblNguoiHoTro";
            this.pllblNguoiHoTro.Size = new System.Drawing.Size(60, 13);
            this.pllblNguoiHoTro.TabIndex = 159;
            this.pllblNguoiHoTro.Text = "Người hỗ trợ";
            this.pllblNguoiHoTro.ToolTip = "Dữ liệu bắt buộc nhập";
            this.pllblNguoiHoTro.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel6
            // 
            this.plLabel6.Location = new System.Drawing.Point(8, 119);
            this.plLabel6.Name = "plLabel6";
            this.plLabel6.Size = new System.Drawing.Size(42, 13);
            this.plLabel6.TabIndex = 164;
            this.plLabel6.Text = "Nội dung";
            this.plLabel6.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel6.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel7
            // 
            this.plLabel7.Location = new System.Drawing.Point(8, 54);
            this.plLabel7.Name = "plLabel7";
            this.plLabel7.Size = new System.Drawing.Size(38, 13);
            this.plLabel7.TabIndex = 163;
            this.plLabel7.Text = "Yêu cầu";
            this.plLabel7.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel7.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel8
            // 
            this.plLabel8.Location = new System.Drawing.Point(8, 19);
            this.plLabel8.Name = "plLabel8";
            this.plLabel8.Size = new System.Drawing.Size(60, 13);
            this.plLabel8.TabIndex = 162;
            this.plLabel8.Text = "Loại yêu cầu";
            this.plLabel8.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel8.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // NguoiNhanEmail
            // 
            this.NguoiNhanEmail.Location = new System.Drawing.Point(135, 431);
            this.NguoiNhanEmail.Name = "NguoiNhanEmail";
            this.NguoiNhanEmail.Size = new System.Drawing.Size(231, 20);
            this.NguoiNhanEmail.TabIndex = 7;
            this.NguoiNhanEmail.ZZZWidthFactor = 2F;
            // 
            // NguoiHoTro
            // 
            this.NguoiHoTro.Location = new System.Drawing.Point(482, 62);
            this.NguoiHoTro.Name = "NguoiHoTro";
            this.NguoiHoTro.Size = new System.Drawing.Size(255, 20);
            this.NguoiHoTro.TabIndex = 4;
            // 
            // plMultiChoiceFiles1
            // 
            this.plMultiChoiceFiles1.Location = new System.Drawing.Point(482, 86);
            this.plMultiChoiceFiles1.Name = "plMultiChoiceFiles1";
            this.plMultiChoiceFiles1.Size = new System.Drawing.Size(259, 20);
            this.plMultiChoiceFiles1.TabIndex = 5;
            // 
            // NoiDung
            // 
            this.NoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NoiDung.Location = new System.Drawing.Point(4, 140);
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Size = new System.Drawing.Size(737, 282);
            this.NoiDung.TabIndex = 6;
            // 
            // frmHotro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 465);
            this.Controls.Add(this.NguoiNhanEmail);
            this.Controls.Add(this.NguoiHoTro);
            this.Controls.Add(this.txtChude);
            this.Controls.Add(this.plMultiChoiceFiles1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.plLabel1);
            this.Controls.Add(this.pllblNguoiHoTro);
            this.Controls.Add(this.plLabel6);
            this.Controls.Add(this.plLabel7);
            this.Controls.Add(this.plLabel8);
            this.Controls.Add(this.NoiDung);
            this.Controls.Add(this.plLabel4);
            this.Controls.Add(this.lblThoiGianGui);
            this.Controls.Add(this.lblNguoiGui);
            this.Controls.Add(this.PLLoaiYeuCau);
            this.Controls.Add(this.PLMucuutien);
            this.Controls.Add(this.PLTinhtrang);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblTGYeuCau);
            this.Controls.Add(this.lblNguoiYeuCau);
            this.Controls.Add(this.labelControl2);
            this.Name = "frmHotro";
            this.Text = "Yêu cầu hỗ trợ";
            this.Load += new System.EventHandler(this.frmHotroSupport_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtChude.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        public DevExpress.XtraEditors.SimpleButton btnLuu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private PLImgCombobox PLTinhtrang;
        private PLImgCombobox PLMucuutien;
        private PLCombobox PLLoaiYeuCau;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel lblTGYeuCau;
        private System.Windows.Forms.PLLabel lblNguoiYeuCau;
        private DevExpress.XtraEditors.LabelControl lblThoiGianGui;
        private DevExpress.XtraEditors.LabelControl lblNguoiGui;
        private System.Windows.Forms.PLLabel plLabel4;
        private DevExpress.XtraRichEdit.Demos.PLRichTextBox NoiDung;
        private DevExpress.XtraEditors.MemoEdit txtChude;
        private PLMultiChoiceFiles plMultiChoiceFiles1;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel plLabel1;
        private System.Windows.Forms.PLLabel pllblNguoiHoTro;
        private System.Windows.Forms.PLLabel plLabel6;
        private System.Windows.Forms.PLLabel plLabel7;
        private System.Windows.Forms.PLLabel plLabel8;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiHoTro;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiNhanEmail;
    }
}