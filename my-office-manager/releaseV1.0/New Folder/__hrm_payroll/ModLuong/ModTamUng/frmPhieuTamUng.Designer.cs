namespace office
{
    partial class frmPhieuTamUng
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
            this.plLabel6 = new System.Windows.Forms.PLLabel();
            this.cmbDuyet = new ProtocolVN.Framework.Win.PLDuyetCombobox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.radioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.dateThangNam = new ProtocolVN.Framework.Win.PLMonthYearTimeEdit();
            this.plLabel16 = new System.Windows.Forms.PLLabel();
            this.dateNgayDeNghi = new DevExpress.XtraEditors.DateEdit();
            this.mboLyDo = new DevExpress.XtraEditors.MemoEdit();
            this.mboSoTienXinUng = new DevExpress.XtraEditors.MemoEdit();
            this.calcSoTienXinUng = new DevExpress.XtraEditors.CalcEdit();
            this.plLabel4 = new System.Windows.Forms.PLLabel();
            this.plLabel3 = new System.Windows.Forms.PLLabel();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.plLabel11 = new System.Windows.Forms.PLLabel();
            this.labelControl11 = new System.Windows.Forms.PLLabel();
            this.NguoiNhanMail = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.NhanVien = new ProtocolVN.Framework.Win.PLDMTreeGroup();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayDeNghi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayDeNghi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mboLyDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mboSoTienXinUng.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSoTienXinUng.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // plLabel6
            // 
            this.plLabel6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.plLabel6.Appearance.Options.UseFont = true;
            this.plLabel6.Location = new System.Drawing.Point(12, 185);
            this.plLabel6.Name = "plLabel6";
            this.plLabel6.Size = new System.Drawing.Size(50, 13);
            this.plLabel6.TabIndex = 32;
            this.plLabel6.Text = "Tình trạng";
            this.plLabel6.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // cmbDuyet
            // 
            this.cmbDuyet.Enabled = false;
            this.cmbDuyet.Location = new System.Drawing.Point(138, 182);
            this.cmbDuyet.Name = "cmbDuyet";
            this.cmbDuyet.Size = new System.Drawing.Size(161, 20);
            this.cmbDuyet.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnDong);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(378, 172);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(163, 30);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(88, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(72, 23);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đón&g";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(12, 156);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(120, 13);
            this.plLabel1.TabIndex = 155;
            this.plLabel1.Text = "Gửi e-mail thông báo đến";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // radioGroup
            // 
            this.radioGroup.Location = new System.Drawing.Point(328, 3);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Tạm ứng lương"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Tạm ứng công tác phí")});
            this.radioGroup.Size = new System.Drawing.Size(129, 64);
            this.radioGroup.TabIndex = 4;
            // 
            // dateThangNam
            // 
            this.dateThangNam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateThangNam.Location = new System.Drawing.Point(459, 13);
            this.dateThangNam.Name = "dateThangNam";
            this.dateThangNam.Size = new System.Drawing.Size(82, 21);
            this.dateThangNam.TabIndex = 5;
            // 
            // plLabel16
            // 
            this.plLabel16.Location = new System.Drawing.Point(425, 14);
            this.plLabel16.Name = "plLabel16";
            this.plLabel16.Size = new System.Drawing.Size(28, 13);
            this.plLabel16.TabIndex = 167;
            this.plLabel16.Text = "tháng";
            this.plLabel16.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // dateNgayDeNghi
            // 
            this.dateNgayDeNghi.EditValue = null;
            this.dateNgayDeNghi.Enabled = false;
            this.dateNgayDeNghi.Location = new System.Drawing.Point(108, 39);
            this.dateNgayDeNghi.Name = "dateNgayDeNghi";
            this.dateNgayDeNghi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayDeNghi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateNgayDeNghi.Size = new System.Drawing.Size(160, 20);
            this.dateNgayDeNghi.TabIndex = 1;
            // 
            // mboLyDo
            // 
            this.mboLyDo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mboLyDo.Enabled = false;
            this.mboLyDo.Location = new System.Drawing.Point(349, 67);
            this.mboLyDo.Name = "mboLyDo";
            this.mboLyDo.Size = new System.Drawing.Size(192, 74);
            this.mboLyDo.TabIndex = 6;
            // 
            // mboSoTienXinUng
            // 
            this.mboSoTienXinUng.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            //this.mboSoTienXinUng.Enabled = true;
            this.mboSoTienXinUng.Properties.ReadOnly = true;
            this.mboSoTienXinUng.Location = new System.Drawing.Point(108, 95);
            this.mboSoTienXinUng.Name = "mboSoTienXinUng";
            this.mboSoTienXinUng.Size = new System.Drawing.Size(160, 50);
            this.mboSoTienXinUng.TabIndex = 3;
            // 
            // calcSoTienXinUng
            // 
            this.calcSoTienXinUng.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.calcSoTienXinUng.Location = new System.Drawing.Point(108, 66);
            this.calcSoTienXinUng.Name = "calcSoTienXinUng";
            this.calcSoTienXinUng.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcSoTienXinUng.Size = new System.Drawing.Size(160, 20);
            this.calcSoTienXinUng.TabIndex = 2;
            // 
            // plLabel4
            // 
            this.plLabel4.Location = new System.Drawing.Point(296, 12);
            this.plLabel4.Name = "plLabel4";
            this.plLabel4.Size = new System.Drawing.Size(26, 13);
            this.plLabel4.TabIndex = 166;
            this.plLabel4.Text = "Lý do";
            this.plLabel4.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel4.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel3
            // 
            this.plLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.plLabel3.Appearance.Options.UseFont = true;
            this.plLabel3.Location = new System.Drawing.Point(12, 100);
            this.plLabel3.Name = "plLabel3";
            this.plLabel3.Size = new System.Drawing.Size(90, 13);
            this.plLabel3.TabIndex = 165;
            this.plLabel3.Text = "Số tiền (Bằng chữ)";
            this.plLabel3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel3.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // plLabel2
            // 
            this.plLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plLabel2.Location = new System.Drawing.Point(12, 69);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(65, 13);
            this.plLabel2.TabIndex = 164;
            this.plLabel2.Text = "Số tiền (VNĐ)";
            this.plLabel2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel11
            // 
            this.plLabel11.Location = new System.Drawing.Point(12, 42);
            this.plLabel11.Name = "plLabel11";
            this.plLabel11.Size = new System.Drawing.Size(63, 13);
            this.plLabel11.TabIndex = 162;
            this.plLabel11.Text = "Ngày đề nghị";
            this.plLabel11.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel11.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(12, 12);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(71, 13);
            this.labelControl11.TabIndex = 163;
            this.labelControl11.Text = "Người tạm ứng";
            this.labelControl11.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl11.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // NguoiNhanMail
            // 
            this.NguoiNhanMail.Location = new System.Drawing.Point(138, 156);
            this.NguoiNhanMail.Name = "NguoiNhanMail";
            this.NguoiNhanMail.Size = new System.Drawing.Size(161, 20);
            this.NguoiNhanMail.TabIndex = 7;
            this.NguoiNhanMail.ZZZWidthFactor = 3F;
            // 
            // NhanVien
            // 
            this.NhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NhanVien.Location = new System.Drawing.Point(108, 10);
            this.NhanVien.Name = "NhanVien";
            this.NhanVien.Size = new System.Drawing.Size(160, 20);
            this.NhanVien.TabIndex = 168;
            // 
            // frmPhieuTamUng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 211);
            this.Controls.Add(this.NhanVien);
            this.Controls.Add(this.NguoiNhanMail);
            this.Controls.Add(this.dateThangNam);
            this.Controls.Add(this.plLabel16);
            this.Controls.Add(this.dateNgayDeNghi);
            this.Controls.Add(this.mboLyDo);
            this.Controls.Add(this.mboSoTienXinUng);
            this.Controls.Add(this.calcSoTienXinUng);
            this.Controls.Add(this.plLabel4);
            this.Controls.Add(this.plLabel3);
            this.Controls.Add(this.plLabel2);
            this.Controls.Add(this.plLabel11);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.plLabel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.plLabel6);
            this.Controls.Add(this.cmbDuyet);
            this.Controls.Add(this.radioGroup);
            this.Name = "frmPhieuTamUng";
            this.Text = "Phiếu tạm ứng";
            this.Load += new System.EventHandler(this.frmPhieuTamUng_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayDeNghi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayDeNghi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mboLyDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mboSoTienXinUng.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSoTienXinUng.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PLLabel plLabel6;
        private ProtocolVN.Framework.Win.PLDuyetCombobox cmbDuyet;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public DevExpress.XtraEditors.SimpleButton btnDong;
        public DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.PLLabel plLabel1;
        private DevExpress.XtraEditors.RadioGroup radioGroup;
        private ProtocolVN.Framework.Win.PLMonthYearTimeEdit dateThangNam;
        private System.Windows.Forms.PLLabel plLabel16;
        private DevExpress.XtraEditors.DateEdit dateNgayDeNghi;
        private DevExpress.XtraEditors.MemoEdit mboLyDo;
        private DevExpress.XtraEditors.MemoEdit mboSoTienXinUng;
        public DevExpress.XtraEditors.CalcEdit calcSoTienXinUng;
        private System.Windows.Forms.PLLabel plLabel4;
        private System.Windows.Forms.PLLabel plLabel3;
        private System.Windows.Forms.PLLabel plLabel2;
        private System.Windows.Forms.PLLabel plLabel11;
        private System.Windows.Forms.PLLabel labelControl11;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiNhanMail;
        public ProtocolVN.Framework.Win.PLDMTreeGroup NhanVien;
    }
}