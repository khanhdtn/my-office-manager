
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
namespace office
{
    partial class frmHoSoUngVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoSoUngVien));
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.labelControl6 = new System.Windows.Forms.PLLabel();
            this.NgaySinh = new DevExpress.XtraEditors.DateEdit();
            this.HoTen = new DevExpress.XtraEditors.TextEdit();
            this.Email = new DevExpress.XtraEditors.TextEdit();
            this.DienThoai = new DevExpress.XtraEditors.TextEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.tdngoaingu = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.QuaTrinhDaoTao = new ProtocolVN.Framework.Win.PLEditor();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.QuaTrinhCongTac = new ProtocolVN.Framework.Win.PLEditor();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.TrinhDoChuyenMon = new ProtocolVN.Framework.Win.PLEditor();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.TrinhDoNgoaiNgu = new ProtocolVN.Framework.Win.PLEditor();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.ThongTinKhac = new ProtocolVN.Framework.Win.PLEditor();
            this.labelControl7 = new System.Windows.Forms.PLLabel();
            this.labelControl9 = new System.Windows.Forms.PLLabel();
            this.DiaChi = new DevExpress.XtraEditors.MemoEdit();
            this.GTNam = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.GTNu = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.DanhSachViTriUngTuyen = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl8 = new System.Windows.Forms.PLLabel();
            this.NgayCapNhatHS = new DevExpress.XtraEditors.DateEdit();
            this.labelControl10 = new System.Windows.Forms.PLLabel();
            this.TinhTrangHonNhan = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.LoaiTien = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl11 = new System.Windows.Forms.PLLabel();
            this.PLLoaiHoSo = new ProtocolVN.Framework.Win.PLCombobox();
            this.PLTinhTrangHoSo = new ProtocolVN.Framework.Win.PLCombobox();
            this.labelControl12 = new System.Windows.Forms.PLLabel();
            this.MaPhieu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new System.Windows.Forms.PLLabel();
            this.LuongMongDoi = new DevExpress.XtraEditors.CalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.NgaySinh.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgaySinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Email.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DienThoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdngoaingu)).BeginInit();
            this.tdngoaingu.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            this.xtraTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GTNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GTNu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DanhSachViTriUngTuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayCapNhatHS.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayCapNhatHS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoaiTien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LuongMongDoi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Họ tên";
            this.labelControl1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 98);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Ngày sinh";
            this.labelControl2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(278, 98);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Địa chỉ";
            this.labelControl3.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(7, 124);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(49, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Điện thoại";
            this.labelControl4.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(7, 150);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Email";
            this.labelControl5.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(7, 69);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(38, 13);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Giới tính";
            this.labelControl6.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl6.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // NgaySinh
            // 
            this.NgaySinh.EditValue = null;
            this.NgaySinh.Location = new System.Drawing.Point(61, 94);
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NgaySinh.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.NgaySinh.Size = new System.Drawing.Size(193, 20);
            this.NgaySinh.TabIndex = 4;
            // 
            // HoTen
            // 
            this.HoTen.Location = new System.Drawing.Point(61, 38);
            this.HoTen.Name = "HoTen";
            this.HoTen.Size = new System.Drawing.Size(193, 20);
            this.HoTen.TabIndex = 1;
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(61, 146);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(193, 20);
            this.Email.TabIndex = 6;
            // 
            // DienThoai
            // 
            this.DienThoai.Location = new System.Drawing.Point(61, 120);
            this.DienThoai.Name = "DienThoai";
            this.DienThoai.Size = new System.Drawing.Size(193, 20);
            this.DienThoai.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(788, 473);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Đó&ng";
            this.btnClose.ToolTipTitle = "Đóng form";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(709, 473);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "&Lưu";
            this.btnSave.ToolTipTitle = "Lưu hồ sơ";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tdngoaingu
            // 
            this.tdngoaingu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tdngoaingu.Location = new System.Drawing.Point(5, 195);
            this.tdngoaingu.Name = "tdngoaingu";
            this.tdngoaingu.SelectedTabPage = this.xtraTabPage1;
            this.tdngoaingu.Size = new System.Drawing.Size(860, 272);
            this.tdngoaingu.TabIndex = 14;
            this.tdngoaingu.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4,
            this.xtraTabPage5});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.QuaTrinhDaoTao);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(853, 243);
            this.xtraTabPage1.Text = "Quá trình đào tạo";
            // 
            // QuaTrinhDaoTao
            // 
            this.QuaTrinhDaoTao.BodyHtml = null;
            this.QuaTrinhDaoTao.BodyText = null;
            this.QuaTrinhDaoTao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuaTrinhDaoTao.DocumentText = resources.GetString("QuaTrinhDaoTao.DocumentText");
            this.QuaTrinhDaoTao.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.QuaTrinhDaoTao.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.QuaTrinhDaoTao.FontSize = ProtocolVN.Framework.Win.FontSize.Three;
            this.QuaTrinhDaoTao.Location = new System.Drawing.Point(0, 0);
            this.QuaTrinhDaoTao.Name = "QuaTrinhDaoTao";
            this.QuaTrinhDaoTao.Size = new System.Drawing.Size(853, 243);
            this.QuaTrinhDaoTao.State = "HTML";
            this.QuaTrinhDaoTao.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.QuaTrinhCongTac);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(853, 243);
            this.xtraTabPage2.Text = "Quá trình công tác";
            // 
            // QuaTrinhCongTac
            // 
            this.QuaTrinhCongTac.BodyHtml = null;
            this.QuaTrinhCongTac.BodyText = null;
            this.QuaTrinhCongTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuaTrinhCongTac.DocumentText = resources.GetString("QuaTrinhCongTac.DocumentText");
            this.QuaTrinhCongTac.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.QuaTrinhCongTac.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.QuaTrinhCongTac.FontSize = ProtocolVN.Framework.Win.FontSize.Three;
            this.QuaTrinhCongTac.Location = new System.Drawing.Point(0, 0);
            this.QuaTrinhCongTac.Name = "QuaTrinhCongTac";
            this.QuaTrinhCongTac.Size = new System.Drawing.Size(853, 243);
            this.QuaTrinhCongTac.State = "HTML";
            this.QuaTrinhCongTac.TabIndex = 0;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.TrinhDoChuyenMon);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(853, 243);
            this.xtraTabPage3.Text = "Trình độ chuyên môn";
            // 
            // TrinhDoChuyenMon
            // 
            this.TrinhDoChuyenMon.BodyHtml = null;
            this.TrinhDoChuyenMon.BodyText = null;
            this.TrinhDoChuyenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrinhDoChuyenMon.DocumentText = resources.GetString("TrinhDoChuyenMon.DocumentText");
            this.TrinhDoChuyenMon.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TrinhDoChuyenMon.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TrinhDoChuyenMon.FontSize = ProtocolVN.Framework.Win.FontSize.Three;
            this.TrinhDoChuyenMon.Location = new System.Drawing.Point(0, 0);
            this.TrinhDoChuyenMon.Name = "TrinhDoChuyenMon";
            this.TrinhDoChuyenMon.Size = new System.Drawing.Size(853, 243);
            this.TrinhDoChuyenMon.State = "HTML";
            this.TrinhDoChuyenMon.TabIndex = 0;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.TrinhDoNgoaiNgu);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(853, 243);
            this.xtraTabPage4.Text = "Trình độ ngoại ngữ";
            // 
            // TrinhDoNgoaiNgu
            // 
            this.TrinhDoNgoaiNgu.BodyHtml = null;
            this.TrinhDoNgoaiNgu.BodyText = null;
            this.TrinhDoNgoaiNgu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrinhDoNgoaiNgu.DocumentText = resources.GetString("TrinhDoNgoaiNgu.DocumentText");
            this.TrinhDoNgoaiNgu.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TrinhDoNgoaiNgu.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TrinhDoNgoaiNgu.FontSize = ProtocolVN.Framework.Win.FontSize.Three;
            this.TrinhDoNgoaiNgu.Location = new System.Drawing.Point(0, 0);
            this.TrinhDoNgoaiNgu.Name = "TrinhDoNgoaiNgu";
            this.TrinhDoNgoaiNgu.Size = new System.Drawing.Size(853, 243);
            this.TrinhDoNgoaiNgu.State = "HTML";
            this.TrinhDoNgoaiNgu.TabIndex = 0;
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.ThongTinKhac);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(853, 243);
            this.xtraTabPage5.Text = "Thông tin khác";
            // 
            // ThongTinKhac
            // 
            this.ThongTinKhac.BodyHtml = null;
            this.ThongTinKhac.BodyText = null;
            this.ThongTinKhac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThongTinKhac.DocumentText = resources.GetString("ThongTinKhac.DocumentText");
            this.ThongTinKhac.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ThongTinKhac.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ThongTinKhac.FontSize = ProtocolVN.Framework.Win.FontSize.Three;
            this.ThongTinKhac.Location = new System.Drawing.Point(0, 0);
            this.ThongTinKhac.Name = "ThongTinKhac";
            this.ThongTinKhac.Size = new System.Drawing.Size(853, 243);
            this.ThongTinKhac.State = "HTML";
            this.ThongTinKhac.TabIndex = 0;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(584, 150);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(76, 13);
            this.labelControl7.TabIndex = 24;
            this.labelControl7.Text = "Lương mong đợi";
            this.labelControl7.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.labelControl7.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(278, 69);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(46, 13);
            this.labelControl9.TabIndex = 27;
            this.labelControl9.Text = "Hôn nhân";
            this.labelControl9.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl9.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // DiaChi
            // 
            this.DiaChi.Location = new System.Drawing.Point(362, 94);
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Size = new System.Drawing.Size(193, 72);
            this.DiaChi.TabIndex = 10;
            // 
            // GTNam
            // 
            this.GTNam.EditValue = true;
            this.GTNam.Location = new System.Drawing.Point(61, 66);
            this.GTNam.Name = "GTNam";
            this.GTNam.Properties.Caption = "Nam";
            this.GTNam.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.GTNam.Properties.RadioGroupIndex = 1;
            this.GTNam.Size = new System.Drawing.Size(47, 19);
            this.GTNam.TabIndex = 2;
            this.GTNam.ToolTip = "Dữ liệu bắt buộc nhập";
            this.GTNam.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
            // 
            // GTNu
            // 
            this.GTNu.Location = new System.Drawing.Point(147, 66);
            this.GTNu.Name = "GTNu";
            this.GTNu.Properties.Caption = "Nữ";
            this.GTNu.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.GTNu.Properties.RadioGroupIndex = 1;
            this.GTNu.Size = new System.Drawing.Size(40, 19);
            this.GTNu.TabIndex = 3;
            this.GTNu.TabStop = false;
            this.GTNu.ToolTip = "Dữ liệu bắt buộc nhập";
            this.GTNu.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
            // 
            // DanhSachViTriUngTuyen
            // 
            this.DanhSachViTriUngTuyen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DanhSachViTriUngTuyen.Location = new System.Drawing.Point(668, 11);
            this.DanhSachViTriUngTuyen.Name = "DanhSachViTriUngTuyen";
            this.DanhSachViTriUngTuyen.Size = new System.Drawing.Size(188, 124);
            this.DanhSachViTriUngTuyen.TabIndex = 11;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(584, 15);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(79, 13);
            this.labelControl8.TabIndex = 27;
            this.labelControl8.Text = "Vị trí tuyển dụng";
            this.labelControl8.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl8.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // NgayCapNhatHS
            // 
            this.NgayCapNhatHS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NgayCapNhatHS.EditValue = null;
            this.NgayCapNhatHS.Enabled = false;
            this.NgayCapNhatHS.Location = new System.Drawing.Point(668, 174);
            this.NgayCapNhatHS.Name = "NgayCapNhatHS";
            this.NgayCapNhatHS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NgayCapNhatHS.Properties.ReadOnly = true;
            this.NgayCapNhatHS.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.NgayCapNhatHS.Size = new System.Drawing.Size(188, 20);
            this.NgayCapNhatHS.TabIndex = 14;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(584, 178);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(71, 13);
            this.labelControl10.TabIndex = 32;
            this.labelControl10.Text = "Ngày cập nhật";
            this.labelControl10.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // TinhTrangHonNhan
            // 
            this.TinhTrangHonNhan.DataSource = null;
            this.TinhTrangHonNhan.DisplayField = null;
            this.TinhTrangHonNhan.Location = new System.Drawing.Point(362, 65);
            this.TinhTrangHonNhan.Name = "TinhTrangHonNhan";
            this.TinhTrangHonNhan.Size = new System.Drawing.Size(193, 20);
            this.TinhTrangHonNhan.TabIndex = 9;
            this.TinhTrangHonNhan.ValueField = null;
            // 
            // LoaiTien
            // 
            this.LoaiTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LoaiTien.EditValue = "VND";
            this.LoaiTien.Location = new System.Drawing.Point(805, 146);
            this.LoaiTien.Name = "LoaiTien";
            this.LoaiTien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LoaiTien.Properties.Items.AddRange(new object[] {
            "VND",
            "USD"});
            this.LoaiTien.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.LoaiTien.Size = new System.Drawing.Size(51, 20);
            this.LoaiTien.TabIndex = 13;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(278, 15);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(48, 13);
            this.labelControl11.TabIndex = 27;
            this.labelControl11.Text = "Loại hồ sơ";
            this.labelControl11.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl11.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // PLLoaiHoSo
            // 
            this.PLLoaiHoSo.DataSource = null;
            this.PLLoaiHoSo.DisplayField = null;
            this.PLLoaiHoSo.Location = new System.Drawing.Point(362, 11);
            this.PLLoaiHoSo.Name = "PLLoaiHoSo";
            this.PLLoaiHoSo.Size = new System.Drawing.Size(193, 20);
            this.PLLoaiHoSo.TabIndex = 7;
            this.PLLoaiHoSo.ValueField = null;
            // 
            // PLTinhTrangHoSo
            // 
            this.PLTinhTrangHoSo.DataSource = null;
            this.PLTinhTrangHoSo.DisplayField = null;
            this.PLTinhTrangHoSo.Location = new System.Drawing.Point(362, 38);
            this.PLTinhTrangHoSo.Name = "PLTinhTrangHoSo";
            this.PLTinhTrangHoSo.Size = new System.Drawing.Size(193, 20);
            this.PLTinhTrangHoSo.TabIndex = 8;
            this.PLTinhTrangHoSo.ValueField = null;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(278, 42);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(78, 13);
            this.labelControl12.TabIndex = 38;
            this.labelControl12.Text = "Tình trạng hồ sơ";
            this.labelControl12.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl12.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // MaPhieu
            // 
            this.MaPhieu.Enabled = false;
            this.MaPhieu.Location = new System.Drawing.Point(61, 11);
            this.MaPhieu.Name = "MaPhieu";
            this.MaPhieu.Properties.ReadOnly = true;
            this.MaPhieu.Size = new System.Drawing.Size(193, 20);
            this.MaPhieu.TabIndex = 0;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(8, 15);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(45, 13);
            this.labelControl13.TabIndex = 41;
            this.labelControl13.Text = "Mã hồ sơ";
            this.labelControl13.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // LuongMongDoi
            // 
            this.LuongMongDoi.Location = new System.Drawing.Point(668, 146);
            this.LuongMongDoi.Name = "LuongMongDoi";
            this.LuongMongDoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LuongMongDoi.Size = new System.Drawing.Size(127, 20);
            this.LuongMongDoi.TabIndex = 12;
            // 
            // frmHoSoUngVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 502);
            this.Controls.Add(this.LuongMongDoi);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.MaPhieu);
            this.Controls.Add(this.PLTinhTrangHoSo);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.LoaiTien);
            this.Controls.Add(this.PLLoaiHoSo);
            this.Controls.Add(this.TinhTrangHonNhan);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.NgayCapNhatHS);
            this.Controls.Add(this.DanhSachViTriUngTuyen);
            this.Controls.Add(this.GTNu);
            this.Controls.Add(this.GTNam);
            this.Controls.Add(this.DiaChi);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.tdngoaingu);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.DienThoai);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.HoTen);
            this.Controls.Add(this.NgaySinh);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmHoSoUngVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin hồ sơ";
            ((System.ComponentModel.ISupportInitialize)(this.NgaySinh.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgaySinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Email.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DienThoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdngoaingu)).EndInit();
            this.tdngoaingu.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GTNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GTNu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DanhSachViTriUngTuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayCapNhatHS.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayCapNhatHS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoaiTien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LuongMongDoi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //[RequiredItem("Bạn chưa nhập ngày sinh")]
        private DevExpress.XtraEditors.DateEdit NgaySinh;
        //[RequiredItem("Bạn chưa nhập tên")]        
        private DevExpress.XtraEditors.TextEdit HoTen;
        //[RequiredItem("Bạn chưa nhập mail")]
        private DevExpress.XtraEditors.TextEdit Email;
        //[RequiredItem("Bạn chưa nhập điện thoại")]
        private DevExpress.XtraEditors.TextEdit DienThoai;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        public DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraTab.XtraTabControl tdngoaingu;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        //  [RequiredItem("Bạn chưa nhập quá trình đào tạo")]
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        // [RequiredItem("Bạn chưa nhập quá trình công tác")]
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        //  [RequiredItem("Bạn chưa nhập trình độ chuyên môn")]
        //  [RequiredItem("Bạn chưa nhập lương mong đợi")]
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        //  [RequiredItem("Bạn chưa nhập trình độ ngoại ngữ")]
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        // [RequiredItem("Bạn chưa nhập thông tin khác")]
        private DevExpress.XtraEditors.MemoEdit DiaChi;
        private ProtocolVN.Framework.Win.PLCheckEdit GTNam;
        private ProtocolVN.Framework.Win.PLCheckEdit GTNu;
        private DevExpress.XtraEditors.CheckedListBoxControl DanhSachViTriUngTuyen;
        private DevExpress.XtraEditors.DateEdit NgayCapNhatHS;
        private PLImgCombobox TinhTrangHonNhan;        
        private PLEditor QuaTrinhDaoTao;
        private PLEditor QuaTrinhCongTac;
        private PLEditor TrinhDoChuyenMon;
        private PLEditor TrinhDoNgoaiNgu;
        private PLEditor ThongTinKhac;
        private DevExpress.XtraEditors.ComboBoxEdit LoaiTien;
        //[RequiredItem("Bạn chưa chọn loại hồ sơ")]
        //[Int32Range(null,0,2,"Bạn chưa chọn loại hồ sơ")]
        private PLCombobox PLLoaiHoSo;
        private PLCombobox PLTinhTrangHoSo;
        private DevExpress.XtraEditors.TextEdit MaPhieu;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel labelControl6;
        private System.Windows.Forms.PLLabel labelControl7;
        private System.Windows.Forms.PLLabel labelControl9;
        private System.Windows.Forms.PLLabel labelControl8;
        private System.Windows.Forms.PLLabel labelControl10;
        private System.Windows.Forms.PLLabel labelControl11;
        private System.Windows.Forms.PLLabel labelControl12;
        private System.Windows.Forms.PLLabel labelControl13;
        private DevExpress.XtraEditors.CalcEdit LuongMongDoi;
    }
}