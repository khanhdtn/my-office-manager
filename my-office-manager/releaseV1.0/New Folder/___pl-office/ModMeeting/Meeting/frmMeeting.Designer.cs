using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmMeeting
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
            this.components = new System.ComponentModel.Container();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.labelControl8 = new System.Windows.Forms.PLLabel();
            this.labelControl6 = new System.Windows.Forms.PLLabel();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl7 = new System.Windows.Forms.PLLabel();
            this.NgayKH = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.memoGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.lblKetQua = new System.Windows.Forms.PLLabel();
            this.memoKL = new DevExpress.XtraEditors.MemoEdit();
            this.PLNguoiToChuc = new ProtocolVN.Framework.Win.PLCombobox();
            this.PLLoaiCuocHop = new ProtocolVN.Framework.Win.PLCombobox();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblTinhTrang = new System.Windows.Forms.PLLabel();
            this.ThoiGianBatDau = new DevExpress.XtraEditors.TimeEdit();
            this.ThoiGianKetThuc = new DevExpress.XtraEditors.TimeEdit();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.cboThuKy = new ProtocolVN.Framework.Win.PLCombobox();
            this.txtChuDe = new DevExpress.XtraEditors.TextEdit();
            this.plLabel3 = new System.Windows.Forms.PLLabel();
            this.memoMucDich = new DevExpress.XtraEditors.MemoEdit();
            this.plLabel4 = new System.Windows.Forms.PLLabel();
            this.plLabel5 = new System.Windows.Forms.PLLabel();
            this.plLabel6 = new System.Windows.Forms.PLLabel();
            this.memoDiaDiem = new DevExpress.XtraEditors.MemoEdit();
            this.NoiDung = new DevExpress.XtraRichEdit.Demos.PLRichTextBox();
            this.plMulTTDK = new office.PLMultiChoiceFiles();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.NguoiThamDu = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.NguoiVangMat = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.NguoiNhanMail = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayKH.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoKL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThoiGianBatDau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThoiGianKetThuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChuDe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMucDich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDiaDiem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 144);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Người chủ trì";
            this.labelControl2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 70);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(57, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Thời gian từ";
            this.labelControl3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 99);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(41, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Địa điểm";
            this.labelControl4.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(9, 44);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(25, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Ngày";
            this.labelControl8.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl8.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(167, 70);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(18, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "đến";
            this.labelControl6.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl6.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(301, 18);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(34, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Chủ đề";
            this.labelControl7.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl7.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // NgayKH
            // 
            this.NgayKH.EditValue = null;
            this.NgayKH.Location = new System.Drawing.Point(80, 41);
            this.NgayKH.Name = "NgayKH";
            this.NgayKH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NgayKH.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.NgayKH.Size = new System.Drawing.Size(189, 20);
            this.NgayKH.TabIndex = 2;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(9, 18);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(65, 13);
            this.labelControl5.TabIndex = 140;
            this.labelControl5.Text = "Loại cuộc họp";
            this.labelControl5.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // memoGhiChu
            // 
            this.memoGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memoGhiChu.Location = new System.Drawing.Point(415, 148);
            this.memoGhiChu.Name = "memoGhiChu";
            this.memoGhiChu.Size = new System.Drawing.Size(323, 38);
            this.memoGhiChu.TabIndex = 12;
            // 
            // lblKetQua
            // 
            this.lblKetQua.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.lblKetQua.Appearance.Options.UseFont = true;
            this.lblKetQua.Location = new System.Drawing.Point(9, 519);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(39, 13);
            this.lblKetQua.TabIndex = 221;
            this.lblKetQua.Text = "Kết luận";
            this.lblKetQua.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.lblKetQua.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // memoKL
            // 
            this.memoKL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memoKL.Location = new System.Drawing.Point(135, 516);
            this.memoKL.Name = "memoKL";
            this.memoKL.Size = new System.Drawing.Size(609, 33);
            this.memoKL.TabIndex = 14;
            // 
            // PLNguoiToChuc
            // 
            this.PLNguoiToChuc.DataSource = null;
            this.PLNguoiToChuc.DisplayField = null;
            this.PLNguoiToChuc.Location = new System.Drawing.Point(80, 140);
            this.PLNguoiToChuc.Name = "PLNguoiToChuc";
            this.PLNguoiToChuc.Size = new System.Drawing.Size(189, 20);
            this.PLNguoiToChuc.TabIndex = 6;
            this.PLNguoiToChuc.ValueField = null;
            // 
            // PLLoaiCuocHop
            // 
            this.PLLoaiCuocHop.DataSource = null;
            this.PLLoaiCuocHop.DisplayField = null;
            this.PLLoaiCuocHop.Location = new System.Drawing.Point(80, 15);
            this.PLLoaiCuocHop.Name = "PLLoaiCuocHop";
            this.PLLoaiCuocHop.Size = new System.Drawing.Size(189, 20);
            this.PLLoaiCuocHop.TabIndex = 1;
            this.PLLoaiCuocHop.ValueField = null;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(681, 586);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Đón&g";
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(595, 586);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(72, 23);
            this.btnLuu.TabIndex = 17;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.LightYellow;
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTinhTrang.Location = new System.Drawing.Point(9, 587);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(120, 13);
            this.lblTinhTrang.TabIndex = 220;
            this.lblTinhTrang.Text = "Gửi e-mail thông báo đến";
            this.lblTinhTrang.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // ThoiGianBatDau
            // 
            this.ThoiGianBatDau.EditValue = new System.DateTime(2009, 7, 6, 0, 0, 0, 0);
            this.ThoiGianBatDau.Location = new System.Drawing.Point(80, 67);
            this.ThoiGianBatDau.Name = "ThoiGianBatDau";
            this.ThoiGianBatDau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ThoiGianBatDau.Properties.DisplayFormat.FormatString = "HH:mm";
            this.ThoiGianBatDau.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.ThoiGianBatDau.Properties.EditFormat.FormatString = "HH:mm";
            this.ThoiGianBatDau.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.ThoiGianBatDau.Properties.Mask.EditMask = "HH:mm";
            this.ThoiGianBatDau.Size = new System.Drawing.Size(73, 20);
            this.ThoiGianBatDau.TabIndex = 3;
            // 
            // ThoiGianKetThuc
            // 
            this.ThoiGianKetThuc.EditValue = new System.DateTime(2009, 7, 6, 0, 0, 0, 0);
            this.ThoiGianKetThuc.Location = new System.Drawing.Point(191, 67);
            this.ThoiGianKetThuc.Name = "ThoiGianKetThuc";
            this.ThoiGianKetThuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ThoiGianKetThuc.Properties.DisplayFormat.FormatString = "HH:mm";
            this.ThoiGianKetThuc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.ThoiGianKetThuc.Properties.EditFormat.FormatString = "HH:mm";
            this.ThoiGianKetThuc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.ThoiGianKetThuc.Properties.Mask.EditMask = "HH:mm";
            this.ThoiGianKetThuc.Size = new System.Drawing.Size(78, 20);
            this.ThoiGianKetThuc.TabIndex = 4;
            // 
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(301, 96);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(100, 13);
            this.plLabel1.TabIndex = 222;
            this.plLabel1.Text = "Thành phần tham dự";
            this.plLabel1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel2
            // 
            this.plLabel2.Location = new System.Drawing.Point(9, 170);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(33, 13);
            this.plLabel2.TabIndex = 224;
            this.plLabel2.Text = "Thư ký";
            this.plLabel2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // cboThuKy
            // 
            this.cboThuKy.DataSource = null;
            this.cboThuKy.DisplayField = null;
            this.cboThuKy.Location = new System.Drawing.Point(80, 166);
            this.cboThuKy.Name = "cboThuKy";
            this.cboThuKy.Size = new System.Drawing.Size(189, 20);
            this.cboThuKy.TabIndex = 7;
            this.cboThuKy.ValueField = null;
            // 
            // txtChuDe
            // 
            this.txtChuDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChuDe.Location = new System.Drawing.Point(415, 15);
            this.txtChuDe.Name = "txtChuDe";
            this.txtChuDe.Size = new System.Drawing.Size(323, 20);
            this.txtChuDe.TabIndex = 8;
            // 
            // plLabel3
            // 
            this.plLabel3.Location = new System.Drawing.Point(301, 44);
            this.plLabel3.Name = "plLabel3";
            this.plLabel3.Size = new System.Drawing.Size(41, 13);
            this.plLabel3.TabIndex = 227;
            this.plLabel3.Text = "Mục đích";
            this.plLabel3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel3.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // memoMucDich
            // 
            this.memoMucDich.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memoMucDich.Location = new System.Drawing.Point(415, 41);
            this.memoMucDich.Name = "memoMucDich";
            this.memoMucDich.Size = new System.Drawing.Size(323, 46);
            this.memoMucDich.TabIndex = 9;
            // 
            // plLabel4
            // 
            this.plLabel4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.plLabel4.Appearance.Options.UseFont = true;
            this.plLabel4.Location = new System.Drawing.Point(301, 123);
            this.plLabel4.Name = "plLabel4";
            this.plLabel4.Size = new System.Drawing.Size(105, 13);
            this.plLabel4.TabIndex = 230;
            this.plLabel4.Text = "Thành phần vắng mặt";
            this.plLabel4.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.plLabel4.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // plLabel5
            // 
            this.plLabel5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.plLabel5.Appearance.Options.UseFont = true;
            this.plLabel5.Location = new System.Drawing.Point(301, 151);
            this.plLabel5.Name = "plLabel5";
            this.plLabel5.Size = new System.Drawing.Size(35, 13);
            this.plLabel5.TabIndex = 232;
            this.plLabel5.Text = "Ghi chú";
            this.plLabel5.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.plLabel5.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // plLabel6
            // 
            this.plLabel6.Location = new System.Drawing.Point(9, 196);
            this.plLabel6.Name = "plLabel6";
            this.plLabel6.Size = new System.Drawing.Size(42, 13);
            this.plLabel6.TabIndex = 233;
            this.plLabel6.Text = "Nội dung";
            this.plLabel6.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel6.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // memoDiaDiem
            // 
            this.memoDiaDiem.Location = new System.Drawing.Point(80, 93);
            this.memoDiaDiem.Name = "memoDiaDiem";
            this.memoDiaDiem.Size = new System.Drawing.Size(189, 37);
            this.memoDiaDiem.TabIndex = 5;
            // 
            // NoiDung
            // 
            this.NoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NoiDung.Location = new System.Drawing.Point(4, 215);
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Size = new System.Drawing.Size(749, 293);
            this.NoiDung.TabIndex = 13;
            // 
            // plMulTTDK
            // 
            this.plMulTTDK._DataSource = null;
            this.plMulTTDK.Location = new System.Drawing.Point(135, 555);
            this.plMulTTDK.Name = "plMulTTDK";
            this.plMulTTDK.Size = new System.Drawing.Size(242, 20);
            this.plMulTTDK.TabIndex = 15;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(9, 559);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 237;
            this.labelControl1.Text = "File đính kèm";
            this.labelControl1.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // NguoiThamDu
            // 
            this.NguoiThamDu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NguoiThamDu.Location = new System.Drawing.Point(415, 94);
            this.NguoiThamDu.Name = "NguoiThamDu";
            this.NguoiThamDu.Size = new System.Drawing.Size(323, 20);
            this.NguoiThamDu.TabIndex = 10;
            // 
            // NguoiVangMat
            // 
            this.NguoiVangMat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NguoiVangMat.Location = new System.Drawing.Point(415, 120);
            this.NguoiVangMat.Name = "NguoiVangMat";
            this.NguoiVangMat.Size = new System.Drawing.Size(323, 20);
            this.NguoiVangMat.TabIndex = 11;
            // 
            // NguoiNhanMail
            // 
            this.NguoiNhanMail.Location = new System.Drawing.Point(135, 586);
            this.NguoiNhanMail.Name = "NguoiNhanMail";
            this.NguoiNhanMail.Size = new System.Drawing.Size(240, 20);
            this.NguoiNhanMail.TabIndex = 16;
            this.NguoiNhanMail.ZZZWidthFactor = 2F;
            // 
            // frmMeeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 618);
            this.Controls.Add(this.NguoiNhanMail);
            this.Controls.Add(this.NguoiVangMat);
            this.Controls.Add(this.NguoiThamDu);
            this.Controls.Add(this.plMulTTDK);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.NoiDung);
            this.Controls.Add(this.memoDiaDiem);
            this.Controls.Add(this.plLabel6);
            this.Controls.Add(this.plLabel5);
            this.Controls.Add(this.plLabel4);
            this.Controls.Add(this.memoMucDich);
            this.Controls.Add(this.plLabel3);
            this.Controls.Add(this.txtChuDe);
            this.Controls.Add(this.cboThuKy);
            this.Controls.Add(this.plLabel2);
            this.Controls.Add(this.plLabel1);
            this.Controls.Add(this.ThoiGianKetThuc);
            this.Controls.Add(this.ThoiGianBatDau);
            this.Controls.Add(this.lblTinhTrang);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.memoKL);
            this.Controls.Add(this.PLLoaiCuocHop);
            this.Controls.Add(this.PLNguoiToChuc);
            this.Controls.Add(this.memoGhiChu);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.NgayKH);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Name = "frmMeeting";
            this.Text = "Tạo mới";
            this.Load += new System.EventHandler(this.frmMeeting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayKH.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoKL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThoiGianBatDau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThoiGianKetThuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChuDe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMucDich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDiaDiem.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.DateEdit NgayKH;
        private DevExpress.XtraEditors.MemoEdit memoGhiChu;
        private DevExpress.XtraEditors.MemoEdit memoKL;
        private PLCombobox PLNguoiToChuc;
        private PLCombobox PLLoaiCuocHop;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        public DevExpress.XtraEditors.SimpleButton btnLuu;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl8;
        private System.Windows.Forms.PLLabel labelControl6;
        private System.Windows.Forms.PLLabel labelControl7;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel lblKetQua;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PLLabel lblTinhTrang;
        public DevExpress.XtraEditors.TimeEdit ThoiGianBatDau;
        public DevExpress.XtraEditors.TimeEdit ThoiGianKetThuc;
        private System.Windows.Forms.PLLabel plLabel1;
        private System.Windows.Forms.PLLabel plLabel2;
        private PLCombobox cboThuKy;
        private DevExpress.XtraEditors.TextEdit txtChuDe;
        private System.Windows.Forms.PLLabel plLabel3;
        private DevExpress.XtraEditors.MemoEdit memoMucDich;
        private System.Windows.Forms.PLLabel plLabel4;
        private System.Windows.Forms.PLLabel plLabel5;
        private System.Windows.Forms.PLLabel plLabel6;
        private DevExpress.XtraEditors.MemoEdit memoDiaDiem;
        private DevExpress.XtraRichEdit.Demos.PLRichTextBox NoiDung;
        private PLMultiChoiceFiles plMulTTDK;
        private System.Windows.Forms.PLLabel labelControl1;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiThamDu;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiVangMat;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiNhanMail;

    }
}