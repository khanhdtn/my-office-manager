using ProtocolVN.Framework.Win;
namespace pl.office.form
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
            this.chkNghi_BS = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.checkNghi_BC = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.NgayNghiPhep = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.label3 = new System.Windows.Forms.PLLabel();
            this.Duyet = new ProtocolVN.Framework.Win.PLDuyetCombobox();
            this.meNoi_dung = new DevExpress.XtraEditors.MemoEdit();
            this.radioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabMailInfo = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlNguoiTheoDoi = new DevExpress.XtraGrid.GridControl();
            this.gridViewNguoiTheoDoi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPhongBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkSendMail = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.lblThoiGianCapNhat = new DevExpress.XtraEditors.LabelControl();
            this.NguoiNghiPhep = new ProtocolVN.Framework.Win.PLDMGrid();
            this.cmbNguoiDuyet = new ProtocolVN.Framework.Win.PLDMGrid();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNghi_BS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNghi_BC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayNghiPhep.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayNghiPhep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meNoi_dung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabMailInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNguoiTheoDoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNguoiTheoDoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSendMail.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(115, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 91);
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
            this.labelControl7.Size = new System.Drawing.Size(78, 13);
            this.labelControl7.TabIndex = 45;
            this.labelControl7.Text = "Người nghỉ phép";
            this.labelControl7.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl7.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnDong);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(475, 507);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(268, 30);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(193, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(72, 23);
            this.btnDong.TabIndex = 14;
            this.btnDong.Text = "Đón&g";
            // 
            // chkNghi_BS
            // 
            this.chkNghi_BS.Location = new System.Drawing.Point(99, 62);
            this.chkNghi_BS.Name = "chkNghi_BS";
            this.chkNghi_BS.Properties.Caption = "Sáng";
            this.chkNghi_BS.Size = new System.Drawing.Size(106, 19);
            this.chkNghi_BS.TabIndex = 7;
            this.chkNghi_BS.ToolTip = "Dữ liệu bắt buộc nhập";
            this.chkNghi_BS.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
            // 
            // checkNghi_BC
            // 
            this.checkNghi_BC.Location = new System.Drawing.Point(209, 62);
            this.checkNghi_BC.Name = "checkNghi_BC";
            this.checkNghi_BC.Properties.Caption = "Chiều";
            this.checkNghi_BC.Size = new System.Drawing.Size(123, 19);
            this.checkNghi_BC.TabIndex = 8;
            this.checkNghi_BC.ToolTip = "Dữ liệu bắt buộc nhập";
            this.checkNghi_BC.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
            // 
            // NgayNghiPhep
            // 
            this.NgayNghiPhep.EditValue = null;
            this.NgayNghiPhep.Location = new System.Drawing.Point(102, 87);
            this.NgayNghiPhep.Name = "NgayNghiPhep";
            this.NgayNghiPhep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NgayNghiPhep.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.NgayNghiPhep.Size = new System.Drawing.Size(236, 20);
            this.NgayNghiPhep.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(398, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 13);
            this.labelControl2.TabIndex = 142;
            this.labelControl2.Text = "Người duyệt";
            this.labelControl2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(398, 68);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(88, 13);
            this.labelControl3.TabIndex = 144;
            this.labelControl3.Text = "Thời gian ghi nhận";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(398, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 145;
            this.label3.Text = "Tình trạng";
            this.label3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label3.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // Duyet
            // 
            this.Duyet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Duyet.Enabled = false;
            this.Duyet.Location = new System.Drawing.Point(492, 36);
            this.Duyet.Name = "Duyet";
            this.Duyet.Size = new System.Drawing.Size(251, 20);
            this.Duyet.TabIndex = 4;
            // 
            // meNoi_dung
            // 
            this.meNoi_dung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meNoi_dung.Location = new System.Drawing.Point(0, 0);
            this.meNoi_dung.Name = "meNoi_dung";
            this.meNoi_dung.Size = new System.Drawing.Size(726, 349);
            this.meNoi_dung.TabIndex = 10;
            // 
            // radioGroup
            // 
            this.radioGroup.Location = new System.Drawing.Point(96, 36);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup.Properties.Columns = 2;
            this.radioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Nghỉ phép năm"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Nghỉ không lương")});
            this.radioGroup.Size = new System.Drawing.Size(230, 21);
            this.radioGroup.TabIndex = 9;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.meNoi_dung);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(726, 349);
            this.xtraTabPage1.Text = "Lý do";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 123);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(733, 378);
            this.xtraTabControl1.TabIndex = 10;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.tabMailInfo});
            // 
            // tabMailInfo
            // 
            this.tabMailInfo.Controls.Add(this.gridControlNguoiTheoDoi);
            this.tabMailInfo.Name = "tabMailInfo";
            this.tabMailInfo.Size = new System.Drawing.Size(726, 349);
            this.tabMailInfo.Text = "Thông tin gửi mail";
            // 
            // gridControlNguoiTheoDoi
            // 
            this.gridControlNguoiTheoDoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlNguoiTheoDoi.Location = new System.Drawing.Point(0, 0);
            this.gridControlNguoiTheoDoi.MainView = this.gridViewNguoiTheoDoi;
            this.gridControlNguoiTheoDoi.Name = "gridControlNguoiTheoDoi";
            this.gridControlNguoiTheoDoi.Size = new System.Drawing.Size(726, 349);
            this.gridControlNguoiTheoDoi.TabIndex = 155;
            this.gridControlNguoiTheoDoi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNguoiTheoDoi});
            // 
            // gridViewNguoiTheoDoi
            // 
            this.gridViewNguoiTheoDoi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPhongBan,
            this.colHoTen,
            this.colEmail,
            this.colChon});
            this.gridViewNguoiTheoDoi.GridControl = this.gridControlNguoiTheoDoi;
            this.gridViewNguoiTheoDoi.GroupCount = 1;
            this.gridViewNguoiTheoDoi.Name = "gridViewNguoiTheoDoi";
            this.gridViewNguoiTheoDoi.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewNguoiTheoDoi.OptionsSelection.MultiSelect = true;
            this.gridViewNguoiTheoDoi.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridViewNguoiTheoDoi.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPhongBan, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colPhongBan
            // 
            this.colPhongBan.Caption = "Phòng ban";
            this.colPhongBan.Name = "colPhongBan";
            // 
            // colHoTen
            // 
            this.colHoTen.Caption = "Họ tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.OptionsColumn.AllowEdit = false;
            this.colHoTen.Visible = true;
            this.colHoTen.VisibleIndex = 0;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 1;
            // 
            // colChon
            // 
            this.colChon.Caption = "Chọn";
            this.colChon.Name = "colChon";
            this.colChon.Visible = true;
            this.colChon.VisibleIndex = 2;
            // 
            // checkSendMail
            // 
            this.checkSendMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.checkSendMail.Location = new System.Drawing.Point(10, 514);
            this.checkSendMail.Name = "checkSendMail";
            this.checkSendMail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.checkSendMail.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.checkSendMail.Properties.Appearance.Options.UseFont = true;
            this.checkSendMail.Properties.Appearance.Options.UseForeColor = true;
            this.checkSendMail.Properties.Caption = "Gửi mail thông báo";
            this.checkSendMail.Size = new System.Drawing.Size(161, 19);
            this.checkSendMail.TabIndex = 3;
            this.checkSendMail.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.checkSendMail.ZZZType = ProtocolVN.Framework.Win.CaptionType.OPTION;
            this.checkSendMail.CheckedChanged += new System.EventHandler(this.checkSendMail_CheckedChanged);
            // 
            // lblThoiGianCapNhat
            // 
            this.lblThoiGianCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianCapNhat.Appearance.Options.UseFont = true;
            this.lblThoiGianCapNhat.Location = new System.Drawing.Point(492, 69);
            this.lblThoiGianCapNhat.Name = "lblThoiGianCapNhat";
            this.lblThoiGianCapNhat.Size = new System.Drawing.Size(79, 13);
            this.lblThoiGianCapNhat.TabIndex = 146;
            this.lblThoiGianCapNhat.Text = "Chưa xác định";
            // 
            // NguoiNghiPhep
            // 
            this.NguoiNghiPhep.Location = new System.Drawing.Point(102, 10);
            this.NguoiNghiPhep.Name = "NguoiNghiPhep";
            this.NguoiNghiPhep.Size = new System.Drawing.Size(236, 20);
            this.NguoiNghiPhep.TabIndex = 147;
            this.NguoiNghiPhep.ZZZWidthFactor = 2F;
            // 
            // cmbNguoiDuyet
            // 
            this.cmbNguoiDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNguoiDuyet.Location = new System.Drawing.Point(492, 10);
            this.cmbNguoiDuyet.Name = "cmbNguoiDuyet";
            this.cmbNguoiDuyet.Size = new System.Drawing.Size(251, 20);
            this.cmbNguoiDuyet.TabIndex = 148;
            this.cmbNguoiDuyet.ZZZWidthFactor = 2F;
            // 
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(10, 40);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(69, 13);
            this.plLabel1.TabIndex = 149;
            this.plLabel1.Text = "Loại nghỉ phép";
            this.plLabel1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel2
            // 
            this.plLabel2.Location = new System.Drawing.Point(10, 65);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(43, 13);
            this.plLabel2.TabIndex = 150;
            this.plLabel2.Text = "Buổi nghỉ";
            this.plLabel2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // frmNghiPhep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 546);
            this.Controls.Add(this.plLabel2);
            this.Controls.Add(this.plLabel1);
            this.Controls.Add(this.cmbNguoiDuyet);
            this.Controls.Add(this.NguoiNghiPhep);
            this.Controls.Add(this.lblThoiGianCapNhat);
            this.Controls.Add(this.checkSendMail);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.radioGroup);
            this.Controls.Add(this.Duyet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.NgayNghiPhep);
            this.Controls.Add(this.checkNghi_BC);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.chkNghi_BS);
            this.Name = "frmNghiPhep";
            this.Text = "Xin nghỉ phép";
            this.Load += new System.EventHandler(this.frmHotroSupport_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkNghi_BS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNghi_BC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayNghiPhep.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayNghiPhep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meNoi_dung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabMailInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNguoiTheoDoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNguoiTheoDoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkSendMail.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ProtocolVN.Framework.Win.PLCheckEdit chkNghi_BS;
        private ProtocolVN.Framework.Win.PLCheckEdit checkNghi_BC;
        public DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.DateEdit NgayNghiPhep;
        private  System.Windows.Forms.PLLabel  label3;
        private PLDuyetCombobox Duyet;
        private DevExpress.XtraEditors.MemoEdit meNoi_dung;
        private DevExpress.XtraEditors.RadioGroup radioGroup;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private ProtocolVN.Framework.Win.PLCheckEdit checkSendMail;
        private DevExpress.XtraTab.XtraTabPage tabMailInfo;
        private DevExpress.XtraGrid.GridControl gridControlNguoiTheoDoi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNguoiTheoDoi;
        private DevExpress.XtraGrid.Columns.GridColumn colPhongBan;
        private DevExpress.XtraGrid.Columns.GridColumn colHoTen;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colChon;
        public DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel labelControl7;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel labelControl3;
        private DevExpress.XtraEditors.LabelControl lblThoiGianCapNhat;
        private PLDMGrid NguoiNghiPhep;
        private PLDMGrid cmbNguoiDuyet;
        private System.Windows.Forms.PLLabel plLabel1;
        private System.Windows.Forms.PLLabel plLabel2;
    }
}