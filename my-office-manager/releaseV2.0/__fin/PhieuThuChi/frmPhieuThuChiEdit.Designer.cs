using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmPhieuThuChiEdit
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
            this.radioLoaiPhieu = new DevExpress.XtraEditors.RadioGroup();
            this.memDienGiai = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.SoTien = new DevExpress.XtraEditors.CalcEdit();
            this.cmbEmp = new ProtocolVN.Framework.Win.PLDMGrid();
            this.cmbLcp = new ProtocolVN.Framework.Win.PLCombobox();
            this.label = new System.Windows.Forms.PLLabel();
            this.labelControl6 = new System.Windows.Forms.PLLabel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.MaPhieu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new System.Windows.Forms.PLLabel();
            this.Info = new ProtocolVN.Framework.Win.PLInfoBox();
            this.txtDonViLienQuan = new DevExpress.XtraEditors.TextEdit();
            this.NgayPhatSinh = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.radioLoaiPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDienGiai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoTien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonViLienQuan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayPhatSinh.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayPhatSinh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radioLoaiPhieu
            // 
            this.radioLoaiPhieu.EditValue = true;
            this.radioLoaiPhieu.Location = new System.Drawing.Point(85, 10);
            this.radioLoaiPhieu.Name = "radioLoaiPhieu";
            this.radioLoaiPhieu.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioLoaiPhieu.Properties.Appearance.Options.UseBackColor = true;
            this.radioLoaiPhieu.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioLoaiPhieu.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Y", "Thu"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("N", "Chi")});
            this.radioLoaiPhieu.Size = new System.Drawing.Size(121, 20);
            this.radioLoaiPhieu.TabIndex = 0;
            this.radioLoaiPhieu.SelectedIndexChanged += new System.EventHandler(this.radioLoaiPhieu_SelectedIndexChanged);
            // 
            // memDienGiai
            // 
            this.memDienGiai.Location = new System.Drawing.Point(314, 64);
            this.memDienGiai.Name = "memDienGiai";
            this.memDienGiai.Size = new System.Drawing.Size(149, 74);
            this.memDienGiai.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(234, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Diễn giải";
            this.labelControl2.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // SoTien
            // 
            this.SoTien.Location = new System.Drawing.Point(88, 118);
            this.SoTien.Name = "SoTien";
            this.SoTien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SoTien.Size = new System.Drawing.Size(129, 20);
            this.SoTien.TabIndex = 4;
            // 
            // cmbEmp
            // 
            this.cmbEmp.Location = new System.Drawing.Point(314, 10);
            this.cmbEmp.Name = "cmbEmp";
            this.cmbEmp.Size = new System.Drawing.Size(149, 20);
            this.cmbEmp.TabIndex = 5;
            this.cmbEmp.ZZZWidthFactor = 2F;
            // 
            // cmbLcp
            // 
            this.cmbLcp.DataSource = null;
            this.cmbLcp.DisplayField = null;
            this.cmbLcp.Location = new System.Drawing.Point(88, 91);
            this.cmbLcp.Name = "cmbLcp";
            this.cmbLcp.Size = new System.Drawing.Size(129, 20);
            this.cmbLcp.TabIndex = 3;
            this.cmbLcp.ValueField = null;
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(11, 122);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(65, 13);
            this.label.TabIndex = 20;
            this.label.Text = "Số tiền (VNĐ)";
            this.label.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(234, 14);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(74, 13);
            this.labelControl6.TabIndex = 21;
            this.labelControl6.Text = "Người liên quan";
            this.labelControl6.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl6.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 97);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 13);
            this.labelControl3.TabIndex = 18;
            this.labelControl3.Text = "Loại chi phí";
            this.labelControl3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 68);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "Ngày phát sinh";
            this.labelControl1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(234, 40);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(77, 13);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "Đơn vị liên quan";
            this.labelControl4.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(11, 14);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(44, 13);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "Phát sinh";
            this.labelControl5.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(315, 148);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(391, 148);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(72, 23);
            this.btnDong.TabIndex = 9;
            this.btnDong.Text = "Đón&g";
            // 
            // MaPhieu
            // 
            this.MaPhieu.Location = new System.Drawing.Point(88, 36);
            this.MaPhieu.Name = "MaPhieu";
            this.MaPhieu.Size = new System.Drawing.Size(105, 20);
            this.MaPhieu.TabIndex = 1;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(11, 40);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(44, 13);
            this.labelControl7.TabIndex = 19;
            this.labelControl7.Text = "Mã phiếu";
            this.labelControl7.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.labelControl7.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // Info
            // 
            this.Info.Location = new System.Drawing.Point(196, 36);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(21, 21);
            this.Info.TabIndex = 44;
            // 
            // txtDonViLienQuan
            // 
            this.txtDonViLienQuan.Location = new System.Drawing.Point(314, 36);
            this.txtDonViLienQuan.Name = "txtDonViLienQuan";
            this.txtDonViLienQuan.Size = new System.Drawing.Size(149, 20);
            this.txtDonViLienQuan.TabIndex = 6;
            // 
            // NgayPhatSinh
            // 
            this.NgayPhatSinh.EditValue = null;
            this.NgayPhatSinh.Location = new System.Drawing.Point(88, 63);
            this.NgayPhatSinh.Name = "NgayPhatSinh";
            this.NgayPhatSinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NgayPhatSinh.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.NgayPhatSinh.Size = new System.Drawing.Size(129, 20);
            this.NgayPhatSinh.TabIndex = 2;
            // 
            // frmPhieuThuChiEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 178);
            this.Controls.Add(this.NgayPhatSinh);
            this.Controls.Add(this.txtDonViLienQuan);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.MaPhieu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.SoTien);
            this.Controls.Add(this.cmbEmp);
            this.Controls.Add(this.cmbLcp);
            this.Controls.Add(this.memDienGiai);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.radioLoaiPhieu);
            this.Name = "frmPhieuThuChiEdit";
            this.Text = "Phát sinh";
            this.Load += new System.EventHandler(this.frmPhieuThuChi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radioLoaiPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDienGiai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoTien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonViLienQuan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayPhatSinh.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayPhatSinh.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup radioLoaiPhieu;
        private DevExpress.XtraEditors.MemoEdit memDienGiai;
        private DevExpress.XtraEditors.CalcEdit SoTien;
        private PLDMGrid cmbEmp;
        private PLCombobox cmbLcp;
        //private PLDateEdit NgayPhatSinh;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.TextEdit MaPhieu;
        private PLInfoBox Info;
        private DevExpress.XtraEditors.TextEdit txtDonViLienQuan;
        private DevExpress.XtraEditors.DateEdit NgayPhatSinh;
        public DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel label;
        private System.Windows.Forms.PLLabel labelControl6;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel labelControl7;
    }
}