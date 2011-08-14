using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmNghiPhep
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
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.labelControl7 = new System.Windows.Forms.PLLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.Duyet = new ProtocolVN.Framework.Win.PLDuyetCombobox();
            this.meNoi_dung = new DevExpress.XtraEditors.MemoEdit();
            this.radioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.lblThoiGianCapNhat = new DevExpress.XtraEditors.LabelControl();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.lblNguoiCapNhat = new DevExpress.XtraEditors.LabelControl();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.plLabel3 = new System.Windows.Forms.PLLabel();
            this.plLabel4 = new System.Windows.Forms.PLLabel();
            this.plLabel5 = new System.Windows.Forms.PLLabel();
            this.plLabel6 = new System.Windows.Forms.PLLabel();
            this.NhanVien = new ProtocolVN.Framework.Win.PLDMTreeGroup();
            this.NguoiNhanEmail = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.ngayNP = new office.NgayNghiPhep();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meNoi_dung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(115, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 69);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(75, 13);
            this.labelControl5.TabIndex = 47;
            this.labelControl5.Text = "Ngày nghỉ phép";
            this.labelControl5.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(10, 14);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(48, 13);
            this.labelControl7.TabIndex = 45;
            this.labelControl7.Text = "Nhân viên";
            this.labelControl7.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl7.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnDong);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(355, 276);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(268, 30);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(193, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(72, 23);
            this.btnDong.TabIndex = 7;
            this.btnDong.Text = "Đón&g";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(315, 42);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(89, 13);
            this.labelControl3.TabIndex = 144;
            this.labelControl3.Text = "Thời gian cập nhật";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // Duyet
            // 
            this.Duyet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Duyet.Enabled = false;
            this.Duyet.Location = new System.Drawing.Point(136, 276);
            this.Duyet.Name = "Duyet";
            this.Duyet.Size = new System.Drawing.Size(151, 20);
            this.Duyet.TabIndex = 3;
            // 
            // meNoi_dung
            // 
            this.meNoi_dung.Location = new System.Drawing.Point(10, 116);
            this.meNoi_dung.Name = "meNoi_dung";
            this.meNoi_dung.Size = new System.Drawing.Size(613, 124);
            this.meNoi_dung.TabIndex = 3;
            // 
            // radioGroup
            // 
            this.radioGroup.Location = new System.Drawing.Point(87, 36);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup.Properties.Columns = 2;
            this.radioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Không lương"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Phép năm")});
            this.radioGroup.Size = new System.Drawing.Size(200, 25);
            this.radioGroup.TabIndex = 1;
            // 
            // lblThoiGianCapNhat
            // 
            this.lblThoiGianCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianCapNhat.Appearance.Options.UseFont = true;
            this.lblThoiGianCapNhat.Location = new System.Drawing.Point(409, 42);
            this.lblThoiGianCapNhat.Name = "lblThoiGianCapNhat";
            this.lblThoiGianCapNhat.Size = new System.Drawing.Size(79, 13);
            this.lblThoiGianCapNhat.TabIndex = 146;
            this.lblThoiGianCapNhat.Text = "Chưa xác định";
            // 
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(10, 42);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(69, 13);
            this.plLabel1.TabIndex = 149;
            this.plLabel1.Text = "Loại nghỉ phép";
            this.plLabel1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // lblNguoiCapNhat
            // 
            this.lblNguoiCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiCapNhat.Appearance.Options.UseFont = true;
            this.lblNguoiCapNhat.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNguoiCapNhat.Location = new System.Drawing.Point(409, 12);
            this.lblNguoiCapNhat.Name = "lblNguoiCapNhat";
            this.lblNguoiCapNhat.Size = new System.Drawing.Size(148, 18);
            this.lblNguoiCapNhat.TabIndex = 151;
            this.lblNguoiCapNhat.Text = "lblNguoiCapNhat";
            // 
            // plLabel2
            // 
            this.plLabel2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.plLabel2.Appearance.Options.UseFont = true;
            this.plLabel2.Location = new System.Drawing.Point(315, 14);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(74, 13);
            this.plLabel2.TabIndex = 150;
            this.plLabel2.Text = "Người cập nhật";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // plLabel3
            // 
            this.plLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plLabel3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.plLabel3.Appearance.Options.UseFont = true;
            this.plLabel3.Location = new System.Drawing.Point(12, 280);
            this.plLabel3.Name = "plLabel3";
            this.plLabel3.Size = new System.Drawing.Size(50, 13);
            this.plLabel3.TabIndex = 152;
            this.plLabel3.Text = "Tình trạng";
            this.plLabel3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel3.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // plLabel4
            // 
            this.plLabel4.Location = new System.Drawing.Point(10, 249);
            this.plLabel4.Name = "plLabel4";
            this.plLabel4.Size = new System.Drawing.Size(120, 13);
            this.plLabel4.TabIndex = 153;
            this.plLabel4.Text = "Gửi e-mail thông báo đến";
            this.plLabel4.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // plLabel5
            // 
            this.plLabel5.Location = new System.Drawing.Point(12, 97);
            this.plLabel5.Name = "plLabel5";
            this.plLabel5.Size = new System.Drawing.Size(26, 13);
            this.plLabel5.TabIndex = 154;
            this.plLabel5.Text = "Lý do";
            this.plLabel5.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel5.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel6
            // 
            this.plLabel6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.plLabel6.Appearance.Options.UseFont = true;
            this.plLabel6.Location = new System.Drawing.Point(42, 97);
            this.plLabel6.Name = "plLabel6";
            this.plLabel6.Size = new System.Drawing.Size(306, 13);
            this.plLabel6.TabIndex = 155;
            this.plLabel6.Text = "(Đề nghị nêu lý do thật cụ thể, không duyệt lý do chung chung)";
            this.plLabel6.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // NhanVien
            // 
            this.NhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NhanVien.Location = new System.Drawing.Point(91, 10);
            this.NhanVien.Name = "NhanVien";
            this.NhanVien.Size = new System.Drawing.Size(198, 20);
            this.NhanVien.TabIndex = 0;
            // 
            // NguoiNhanEmail
            // 
            this.NguoiNhanEmail.Location = new System.Drawing.Point(136, 247);
            this.NguoiNhanEmail.Name = "NguoiNhanEmail";
            this.NguoiNhanEmail.Size = new System.Drawing.Size(151, 20);
            this.NguoiNhanEmail.TabIndex = 156;
            this.NguoiNhanEmail.ZZZWidthFactor = 3F;
            // 
            // ngayNP
            // 
            this.ngayNP.Location = new System.Drawing.Point(91, 66);
            this.ngayNP.Name = "ngayNP";
            this.ngayNP.Size = new System.Drawing.Size(196, 22);
            this.ngayNP.TabIndex = 2;
            // 
            // frmNghiPhep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 314);
            this.Controls.Add(this.NhanVien);
            this.Controls.Add(this.NguoiNhanEmail);
            this.Controls.Add(this.plLabel6);
            this.Controls.Add(this.plLabel5);
            this.Controls.Add(this.meNoi_dung);
            this.Controls.Add(this.plLabel4);
            this.Controls.Add(this.plLabel3);
            this.Controls.Add(this.ngayNP);
            this.Controls.Add(this.lblNguoiCapNhat);
            this.Controls.Add(this.plLabel2);
            this.Controls.Add(this.plLabel1);
            this.Controls.Add(this.lblThoiGianCapNhat);
            this.Controls.Add(this.radioGroup);
            this.Controls.Add(this.Duyet);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl7);
            this.Name = "frmNghiPhep";
            this.Text = "Xin nghỉ phép";
            this.Load += new System.EventHandler(this.frmNghiPhep_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meNoi_dung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public DevExpress.XtraEditors.SimpleButton btnDong;
        private PLDuyetCombobox Duyet;
        private DevExpress.XtraEditors.MemoEdit meNoi_dung;
        private DevExpress.XtraEditors.RadioGroup radioGroup;
        public DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel labelControl7;
        private System.Windows.Forms.PLLabel labelControl3;
        private DevExpress.XtraEditors.LabelControl lblThoiGianCapNhat;
        private System.Windows.Forms.PLLabel plLabel1;
        private DevExpress.XtraEditors.LabelControl lblNguoiCapNhat;
        private System.Windows.Forms.PLLabel plLabel2;
        private NgayNghiPhep ngayNP;
        private System.Windows.Forms.PLLabel plLabel3;
        private System.Windows.Forms.PLLabel plLabel4;
        private System.Windows.Forms.PLLabel plLabel5;
        private System.Windows.Forms.PLLabel plLabel6;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiNhanEmail;
        public PLDMTreeGroup NhanVien;
    }
}