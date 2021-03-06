namespace office
{
    partial class frmPhieuRaVaoCty
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.cmbDuyet = new ProtocolVN.Framework.Win.PLDuyetCombobox();
            this.plLabel3 = new System.Windows.Forms.PLLabel();
            this.timeEditKetThuc = new DevExpress.XtraEditors.TimeEdit();
            this.plLabel7 = new System.Windows.Forms.PLLabel();
            this.timeEditBatDau = new DevExpress.XtraEditors.TimeEdit();
            this.DateTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.plLabel6 = new System.Windows.Forms.PLLabel();
            this.lblNguoiLapPhieu = new DevExpress.XtraEditors.LabelControl();
            this.lblNgayLapPhieu = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.plLabel10 = new System.Windows.Forms.PLLabel();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.plLabel4 = new System.Windows.Forms.PLLabel();
            this.textLyDo = new DevExpress.XtraEditors.MemoEdit();
            this.plLabel5 = new System.Windows.Forms.PLLabel();
            this.NhanVien = new ProtocolVN.Framework.Win.PLDMTreeGroup();
            this.NguoiNhanEmail = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditKetThuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditBatDau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTuNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textLyDo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(350, 262);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(258, 30);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(183, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Đón&g";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(105, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbDuyet
            // 
            this.cmbDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbDuyet.Enabled = false;
            this.cmbDuyet.Location = new System.Drawing.Point(136, 265);
            this.cmbDuyet.Name = "cmbDuyet";
            this.cmbDuyet.Size = new System.Drawing.Size(175, 20);
            this.cmbDuyet.TabIndex = 6;
            // 
            // plLabel3
            // 
            this.plLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.plLabel3.Appearance.Options.UseFont = true;
            this.plLabel3.Location = new System.Drawing.Point(10, 268);
            this.plLabel3.Name = "plLabel3";
            this.plLabel3.Size = new System.Drawing.Size(50, 13);
            this.plLabel3.TabIndex = 163;
            this.plLabel3.Text = "Tình trạng";
            this.plLabel3.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // timeEditKetThuc
            // 
            this.timeEditKetThuc.EditValue = new System.DateTime(2009, 7, 6, 0, 0, 0, 0);
            this.timeEditKetThuc.Location = new System.Drawing.Point(223, 61);
            this.timeEditKetThuc.Name = "timeEditKetThuc";
            this.timeEditKetThuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEditKetThuc.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditKetThuc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeEditKetThuc.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditKetThuc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeEditKetThuc.Properties.Mask.EditMask = "HH:mm";
            this.timeEditKetThuc.Size = new System.Drawing.Size(67, 20);
            this.timeEditKetThuc.TabIndex = 3;
            // 
            // plLabel7
            // 
            this.plLabel7.Location = new System.Drawing.Point(8, 65);
            this.plLabel7.Name = "plLabel7";
            this.plLabel7.Size = new System.Drawing.Size(57, 13);
            this.plLabel7.TabIndex = 161;
            this.plLabel7.Text = "Thời gian từ";
            this.plLabel7.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel7.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // timeEditBatDau
            // 
            this.timeEditBatDau.EditValue = new System.DateTime(2009, 7, 6, 0, 0, 0, 0);
            this.timeEditBatDau.Location = new System.Drawing.Point(82, 61);
            this.timeEditBatDau.Name = "timeEditBatDau";
            this.timeEditBatDau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEditBatDau.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditBatDau.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeEditBatDau.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditBatDau.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeEditBatDau.Properties.Mask.EditMask = "HH:mm";
            this.timeEditBatDau.Size = new System.Drawing.Size(67, 20);
            this.timeEditBatDau.TabIndex = 2;
            // 
            // DateTuNgay
            // 
            this.DateTuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTuNgay.EditValue = null;
            this.DateTuNgay.Location = new System.Drawing.Point(82, 35);
            this.DateTuNgay.Name = "DateTuNgay";
            this.DateTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateTuNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateTuNgay.Size = new System.Drawing.Size(252, 20);
            this.DateTuNgay.TabIndex = 1;
            // 
            // plLabel6
            // 
            this.plLabel6.Location = new System.Drawing.Point(10, 39);
            this.plLabel6.Name = "plLabel6";
            this.plLabel6.Size = new System.Drawing.Size(66, 13);
            this.plLabel6.TabIndex = 160;
            this.plLabel6.Text = "Ngày làm việc";
            this.plLabel6.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel6.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // lblNguoiLapPhieu
            // 
            this.lblNguoiLapPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNguoiLapPhieu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiLapPhieu.Appearance.Options.UseFont = true;
            this.lblNguoiLapPhieu.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNguoiLapPhieu.Location = new System.Drawing.Point(458, 12);
            this.lblNguoiLapPhieu.Name = "lblNguoiLapPhieu";
            this.lblNguoiLapPhieu.Size = new System.Drawing.Size(149, 13);
            this.lblNguoiLapPhieu.TabIndex = 158;
            this.lblNguoiLapPhieu.Text = "lblNguoiLapPhieu";
            // 
            // lblNgayLapPhieu
            // 
            this.lblNgayLapPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNgayLapPhieu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayLapPhieu.Appearance.Options.UseFont = true;
            this.lblNgayLapPhieu.AutoEllipsis = true;
            this.lblNgayLapPhieu.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNgayLapPhieu.Location = new System.Drawing.Point(458, 37);
            this.lblNgayLapPhieu.Name = "lblNgayLapPhieu";
            this.lblNgayLapPhieu.Size = new System.Drawing.Size(149, 16);
            this.lblNgayLapPhieu.TabIndex = 159;
            this.lblNgayLapPhieu.Text = "lblNgayLapPhieu";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(363, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(74, 13);
            this.labelControl4.TabIndex = 156;
            this.labelControl4.Text = "Người cập nhật";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(363, 39);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(89, 13);
            this.labelControl3.TabIndex = 157;
            this.labelControl3.Text = "Thời gian cập nhật";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(10, 12);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(48, 13);
            this.plLabel1.TabIndex = 155;
            this.plLabel1.Text = "Nhân viên";
            this.plLabel1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel10
            // 
            this.plLabel10.Location = new System.Drawing.Point(154, 65);
            this.plLabel10.Name = "plLabel10";
            this.plLabel10.Size = new System.Drawing.Size(64, 13);
            this.plLabel10.TabIndex = 166;
            this.plLabel10.Text = "(hh:mm)  đến";
            this.plLabel10.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel10.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel2
            // 
            this.plLabel2.Location = new System.Drawing.Point(294, 65);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(40, 13);
            this.plLabel2.TabIndex = 166;
            this.plLabel2.Text = "(hh:mm)";
            this.plLabel2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel4
            // 
            this.plLabel4.Location = new System.Drawing.Point(10, 240);
            this.plLabel4.Name = "plLabel4";
            this.plLabel4.Size = new System.Drawing.Size(120, 13);
            this.plLabel4.TabIndex = 167;
            this.plLabel4.Text = "Gửi e-mail thông báo đến";
            this.plLabel4.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // textLyDo
            // 
            this.textLyDo.Location = new System.Drawing.Point(10, 106);
            this.textLyDo.Name = "textLyDo";
            this.textLyDo.Size = new System.Drawing.Size(598, 120);
            this.textLyDo.TabIndex = 5;
            // 
            // plLabel5
            // 
            this.plLabel5.Location = new System.Drawing.Point(10, 87);
            this.plLabel5.Name = "plLabel5";
            this.plLabel5.Size = new System.Drawing.Size(26, 13);
            this.plLabel5.TabIndex = 169;
            this.plLabel5.Text = "Lý do";
            this.plLabel5.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel5.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // NhanVien
            // 
            this.NhanVien.Location = new System.Drawing.Point(82, 9);
            this.NhanVien.Name = "NhanVien";
            this.NhanVien.Size = new System.Drawing.Size(252, 20);
            this.NhanVien.TabIndex = 0;
            // 
            // NguoiNhanEmail
            // 
            this.NguoiNhanEmail.Location = new System.Drawing.Point(136, 240);
            this.NguoiNhanEmail.Name = "NguoiNhanEmail";
            this.NguoiNhanEmail.Size = new System.Drawing.Size(175, 20);
            this.NguoiNhanEmail.TabIndex = 6;
            this.NguoiNhanEmail.ZZZWidthFactor = 3F;
            // 
            // frmPhieuRaVaoCty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 304);
            this.Controls.Add(this.NhanVien);
            this.Controls.Add(this.NguoiNhanEmail);
            this.Controls.Add(this.plLabel5);
            this.Controls.Add(this.textLyDo);
            this.Controls.Add(this.timeEditKetThuc);
            this.Controls.Add(this.plLabel4);
            this.Controls.Add(this.plLabel2);
            this.Controls.Add(this.plLabel10);
            this.Controls.Add(this.cmbDuyet);
            this.Controls.Add(this.plLabel3);
            this.Controls.Add(this.plLabel7);
            this.Controls.Add(this.timeEditBatDau);
            this.Controls.Add(this.DateTuNgay);
            this.Controls.Add(this.plLabel6);
            this.Controls.Add(this.lblNguoiLapPhieu);
            this.Controls.Add(this.lblNgayLapPhieu);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.plLabel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmPhieuRaVaoCty";
            this.Text = "Ra vào công ty";
            this.Load += new System.EventHandler(this.frmPhieuRaVaoCty_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeEditKetThuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditBatDau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTuNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textLyDo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        public DevExpress.XtraEditors.SimpleButton btnSave;
        private ProtocolVN.Framework.Win.PLDuyetCombobox cmbDuyet;
        private System.Windows.Forms.PLLabel plLabel3;
        public DevExpress.XtraEditors.TimeEdit timeEditKetThuc;
        private System.Windows.Forms.PLLabel plLabel7;
        public DevExpress.XtraEditors.TimeEdit timeEditBatDau;
        private DevExpress.XtraEditors.DateEdit DateTuNgay;
        private System.Windows.Forms.PLLabel plLabel6;
        private DevExpress.XtraEditors.LabelControl lblNguoiLapPhieu;
        private DevExpress.XtraEditors.LabelControl lblNgayLapPhieu;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel plLabel1;
        private System.Windows.Forms.PLLabel plLabel10;
        private System.Windows.Forms.PLLabel plLabel2;
        private System.Windows.Forms.PLLabel plLabel4;
        private DevExpress.XtraEditors.MemoEdit textLyDo;
        private System.Windows.Forms.PLLabel plLabel5;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiNhanEmail;
        public ProtocolVN.Framework.Win.PLDMTreeGroup NhanVien;
    }
}