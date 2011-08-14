namespace office
{
    partial class frmNewsPaper
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
            this.labelControl10 = new System.Windows.Forms.PLLabel();
            this.txtTieude = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.Duyet = new ProtocolVN.Framework.Win.PLDuyetCombobox();
            this.hideContainerBottom = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.PLNhomTT = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.labelControl6 = new System.Windows.Forms.PLLabel();
            this.lblNguoiCapNhat = new DevExpress.XtraEditors.LabelControl();
            this.lblThoiGianCapNhat = new DevExpress.XtraEditors.LabelControl();
            this.seSoNgay = new DevExpress.XtraEditors.SpinEdit();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.chkHieuLuc = new DevExpress.XtraEditors.CheckEdit();
            this.NoiDung = new DevExpress.XtraRichEdit.Demos.PLRichTextBox();
            this.FileDinhKem = new office.PLMultiChoiceFiles();
            this.checkTin_noi_bat = new ProtocolVN.Framework.Win.PLCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTieude.Properties)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seSoNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHieuLuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTin_noi_bat.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(10, 16);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(42, 13);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "Nhóm tin";
            this.labelControl10.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl10.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // txtTieude
            // 
            this.txtTieude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTieude.Location = new System.Drawing.Point(91, 38);
            this.txtTieude.Name = "txtTieude";
            this.txtTieude.Size = new System.Drawing.Size(275, 20);
            this.txtTieude.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(10, 68);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tập tin đính kèm";
            this.labelControl1.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(81, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(72, 23);
            this.btnDong.TabIndex = 8;
            this.btnDong.Text = "Đón&g";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Chủ đề";
            this.labelControl2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnDong);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(577, 430);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(156, 30);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(490, 42);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(74, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Người cập nhật";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(490, 68);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(89, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Thời gian cập nhật";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // Duyet
            // 
            this.Duyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Duyet.Enabled = false;
            this.Duyet.Location = new System.Drawing.Point(65, 435);
            this.Duyet.Name = "Duyet";
            this.Duyet.Size = new System.Drawing.Size(141, 20);
            this.Duyet.TabIndex = 6;
            // 
            // hideContainerBottom
            // 
            this.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hideContainerBottom.Location = new System.Drawing.Point(0, 382);
            this.hideContainerBottom.Name = "hideContainerBottom";
            this.hideContainerBottom.Size = new System.Drawing.Size(536, 19);
            // 
            // PLNhomTT
            // 
            this.PLNhomTT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PLNhomTT.DataSource = null;
            this.PLNhomTT.DisplayField = null;
            this.PLNhomTT.Location = new System.Drawing.Point(91, 12);
            this.PLNhomTT.Name = "PLNhomTT";
            this.PLNhomTT.Size = new System.Drawing.Size(352, 20);
            this.PLNhomTT.TabIndex = 0;
            this.PLNhomTT.ValueField = null;
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(9, 439);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(50, 13);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Tình trạng";
            this.labelControl6.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // lblNguoiCapNhat
            // 
            this.lblNguoiCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNguoiCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiCapNhat.Appearance.Options.UseFont = true;
            this.lblNguoiCapNhat.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNguoiCapNhat.Location = new System.Drawing.Point(585, 39);
            this.lblNguoiCapNhat.Name = "lblNguoiCapNhat";
            this.lblNguoiCapNhat.Size = new System.Drawing.Size(148, 18);
            this.lblNguoiCapNhat.TabIndex = 15;
            this.lblNguoiCapNhat.Text = "lblNguoiCapNhat";
            // 
            // lblThoiGianCapNhat
            // 
            this.lblThoiGianCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThoiGianCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianCapNhat.Appearance.Options.UseFont = true;
            this.lblThoiGianCapNhat.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblThoiGianCapNhat.Location = new System.Drawing.Point(585, 65);
            this.lblThoiGianCapNhat.Name = "lblThoiGianCapNhat";
            this.lblThoiGianCapNhat.Size = new System.Drawing.Size(148, 18);
            this.lblThoiGianCapNhat.TabIndex = 15;
            this.lblThoiGianCapNhat.Text = "lblThoiGianCapNhat";
            // 
            // seSoNgay
            // 
            this.seSoNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.seSoNgay.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seSoNgay.Location = new System.Drawing.Point(585, 12);
            this.seSoNgay.Name = "seSoNgay";
            this.seSoNgay.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.seSoNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seSoNgay.Properties.IsFloatValue = false;
            this.seSoNgay.Properties.Mask.EditMask = "N00";
            this.seSoNgay.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.seSoNgay.Properties.NullText = "(Không xác định)";
            this.seSoNgay.Size = new System.Drawing.Size(111, 20);
            this.seSoNgay.TabIndex = 5;
            this.seSoNgay.EditValueChanged += new System.EventHandler(this.seSoNgay_EditValueChanged);
            // 
            // plLabel2
            // 
            this.plLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.plLabel2.Location = new System.Drawing.Point(702, 16);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(24, 13);
            this.plLabel2.TabIndex = 19;
            this.plLabel2.Text = "ngày";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // chkHieuLuc
            // 
            this.chkHieuLuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHieuLuc.Location = new System.Drawing.Point(479, 13);
            this.chkHieuLuc.Name = "chkHieuLuc";
            this.chkHieuLuc.Properties.Caption = "Hiệu lực trong";
            this.chkHieuLuc.Size = new System.Drawing.Size(92, 19);
            this.chkHieuLuc.TabIndex = 4;
            this.chkHieuLuc.CheckedChanged += new System.EventHandler(this.chkHieuLuc_CheckedChanged);
            // 
            // NoiDung
            // 
            this.NoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NoiDung.Location = new System.Drawing.Point(10, 87);
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Size = new System.Drawing.Size(723, 336);
            this.NoiDung.TabIndex = 6;
            // 
            // FileDinhKem
            // 
            this.FileDinhKem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FileDinhKem.Location = new System.Drawing.Point(91, 63);
            this.FileDinhKem.Name = "FileDinhKem";
            this.FileDinhKem.Size = new System.Drawing.Size(356, 20);
            this.FileDinhKem.TabIndex = 3;
            // 
            // checkTin_noi_bat
            // 
            this.checkTin_noi_bat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkTin_noi_bat.Location = new System.Drawing.Point(372, 39);
            this.checkTin_noi_bat.Name = "checkTin_noi_bat";
            this.checkTin_noi_bat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.checkTin_noi_bat.Properties.Appearance.Options.UseFont = true;
            this.checkTin_noi_bat.Properties.Caption = "Tin nổi bật";
            this.checkTin_noi_bat.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.checkTin_noi_bat.Size = new System.Drawing.Size(112, 19);
            this.checkTin_noi_bat.TabIndex = 2;
            this.checkTin_noi_bat.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.checkTin_noi_bat.ZZZType = ProtocolVN.Framework.Win.CaptionType.OPTION;
            // 
            // frmNewsPaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 468);
            this.Controls.Add(this.NoiDung);
            this.Controls.Add(this.FileDinhKem);
            this.Controls.Add(this.chkHieuLuc);
            this.Controls.Add(this.plLabel2);
            this.Controls.Add(this.seSoNgay);
            this.Controls.Add(this.lblThoiGianCapNhat);
            this.Controls.Add(this.lblNguoiCapNhat);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.PLNhomTT);
            this.Controls.Add(this.Duyet);
            this.Controls.Add(this.checkTin_noi_bat);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.txtTieude);
            this.Name = "frmNewsPaper";
            this.Text = "Tin tức";
            this.Load += new System.EventHandler(this.frmTinTuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTieude.Properties)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seSoNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHieuLuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTin_noi_bat.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtTieude;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ProtocolVN.Framework.Win.PLCheckEdit checkTin_noi_bat;
        private ProtocolVN.Framework.Win.PLDuyetCombobox Duyet;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerBottom;
        private ProtocolVN.Framework.Win.PLImgCombobox PLNhomTT;
        private System.Windows.Forms.PLLabel labelControl10;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl6;
        private DevExpress.XtraEditors.LabelControl lblNguoiCapNhat;
        private DevExpress.XtraEditors.LabelControl lblThoiGianCapNhat;
        private DevExpress.XtraEditors.SpinEdit seSoNgay;
        private System.Windows.Forms.PLLabel plLabel2;
        private DevExpress.XtraEditors.CheckEdit chkHieuLuc;
        private PLMultiChoiceFiles FileDinhKem;
        private DevExpress.XtraRichEdit.Demos.PLRichTextBox NoiDung;
    }
}