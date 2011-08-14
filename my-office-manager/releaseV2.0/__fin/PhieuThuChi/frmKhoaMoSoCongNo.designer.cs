namespace office
{
    partial class frmKhoaMoSoCongNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhoaMoSoCongNo));
            this.btnCapNhatCongNoDauKy = new DevExpress.XtraEditors.SimpleButton();
            this.InPhieu = new DevExpress.XtraEditors.DropDownButton();
            this.DaKetChuyen = new DevExpress.XtraEditors.CheckEdit();
            this.DenNgay = new DevExpress.XtraEditors.DateEdit();
            this.TuNgay = new DevExpress.XtraEditors.DateEdit();
            this.btnMoKhoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhoa = new DevExpress.XtraEditors.SimpleButton();
            this.Dong = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.PLLabel();
            this.KyKinhDoanh = new ProtocolVN.Framework.Win.PLCombobox();
            this.label1 = new System.Windows.Forms.PLLabel();
            this.label15 = new System.Windows.Forms.PLLabel();
            this.ctMnuInPhieu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemXemTruoc = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.colMasterID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterLcp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterEmp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterTienThu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterTienChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cplMasterNgayPs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterNgayTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterNguoiTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterDienGiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterThuChiBit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.DaKetChuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties)).BeginInit();
            this.ctMnuInPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCapNhatCongNoDauKy
            // 
            this.btnCapNhatCongNoDauKy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCapNhatCongNoDauKy.Location = new System.Drawing.Point(92, 443);
            this.btnCapNhatCongNoDauKy.Name = "btnCapNhatCongNoDauKy";
            this.btnCapNhatCongNoDauKy.Size = new System.Drawing.Size(135, 23);
            this.btnCapNhatCongNoDauKy.TabIndex = 44;
            this.btnCapNhatCongNoDauKy.Text = "Cập nhật công nợ đầu kỳ";
            this.btnCapNhatCongNoDauKy.Visible = false;
            // 
            // InPhieu
            // 
            this.InPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.InPhieu.Location = new System.Drawing.Point(11, 443);
            this.InPhieu.Name = "InPhieu";
            this.InPhieu.Size = new System.Drawing.Size(75, 23);
            this.InPhieu.TabIndex = 43;
            this.InPhieu.Text = "&In phiếu";
            // 
            // DaKetChuyen
            // 
            this.DaKetChuyen.Enabled = false;
            this.DaKetChuyen.Location = new System.Drawing.Point(683, 8);
            this.DaKetChuyen.Name = "DaKetChuyen";
            this.DaKetChuyen.Properties.Caption = "Đã khóa sổ";
            this.DaKetChuyen.Size = new System.Drawing.Size(92, 19);
            this.DaKetChuyen.TabIndex = 45;
            this.DaKetChuyen.ToolTip = "Khách thường xuyên";
            // 
            // DenNgay
            // 
            this.DenNgay.EditValue = null;
            this.DenNgay.Location = new System.Drawing.Point(557, 7);
            this.DenNgay.Name = "DenNgay";
            this.DenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DenNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DenNgay.Size = new System.Drawing.Size(100, 20);
            this.DenNgay.TabIndex = 41;
            // 
            // TuNgay
            // 
            this.TuNgay.EditValue = null;
            this.TuNgay.Location = new System.Drawing.Point(371, 7);
            this.TuNgay.Name = "TuNgay";
            this.TuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TuNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TuNgay.Size = new System.Drawing.Size(100, 20);
            this.TuNgay.TabIndex = 42;
            // 
            // btnMoKhoa
            // 
            this.btnMoKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoKhoa.Location = new System.Drawing.Point(738, 443);
            this.btnMoKhoa.Name = "btnMoKhoa";
            this.btnMoKhoa.Size = new System.Drawing.Size(75, 23);
            this.btnMoKhoa.TabIndex = 40;
            this.btnMoKhoa.Text = "Mở khoá";
            this.btnMoKhoa.Click += new System.EventHandler(this.MoKhoa_Click);
            // 
            // btnKhoa
            // 
            this.btnKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhoa.Location = new System.Drawing.Point(738, 443);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Size = new System.Drawing.Size(75, 23);
            this.btnKhoa.TabIndex = 39;
            this.btnKhoa.Text = "Khóa";
            this.btnKhoa.Click += new System.EventHandler(this.Khoa_Click);
            // 
            // Dong
            // 
            this.Dong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Dong.Location = new System.Drawing.Point(819, 443);
            this.Dong.Name = "Dong";
            this.Dong.Size = new System.Drawing.Size(75, 23);
            this.Dong.TabIndex = 37;
            this.Dong.Text = "Đón&g";
            this.Dong.Click += new System.EventHandler(this.Dong_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(477, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Ngày kết thúc";
            this.label2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // KyKinhDoanh
            // 
            this.KyKinhDoanh.DataSource = null;
            this.KyKinhDoanh.DisplayField = null;
            this.KyKinhDoanh.Location = new System.Drawing.Point(100, 7);
            this.KyKinhDoanh.Name = "KyKinhDoanh";
            this.KyKinhDoanh.Size = new System.Drawing.Size(186, 20);
            this.KyKinhDoanh.TabIndex = 36;
            this.KyKinhDoanh.ValueField = null;
            this.KyKinhDoanh.SelectedIndexChanged += new System.EventHandler(this.KyKinhDoanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(293, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Ngày bắt đầu";
            this.label1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(8, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Kỳ ghi sổ công nợ";
            this.label15.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label15.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // ctMnuInPhieu
            // 
            this.ctMnuInPhieu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemXemTruoc});
            this.ctMnuInPhieu.Name = "contextMenuStrip2";
            this.ctMnuInPhieu.Size = new System.Drawing.Size(162, 26);
            // 
            // itemXemTruoc
            // 
            this.itemXemTruoc.Name = "itemXemTruoc";
            this.itemXemTruoc.Size = new System.Drawing.Size(161, 22);
            this.itemXemTruoc.Text = "Xem t&rước khi in";
            // 
            // gridControlMaster
            // 
            this.gridControlMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlMaster.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlMaster.BackgroundImage")));
            this.gridControlMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlMaster.Location = new System.Drawing.Point(-1, 36);
            this.gridControlMaster.MainView = this.gridViewMaster;
            this.gridControlMaster.Name = "gridControlMaster";
            this.gridControlMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControlMaster.Size = new System.Drawing.Size(904, 394);
            this.gridControlMaster.TabIndex = 46;
            this.gridControlMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMaster});
            // 
            // gridViewMaster
            // 
            this.gridViewMaster.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Inch);
            this.gridViewMaster.Appearance.GroupPanel.Options.UseFont = true;
            this.gridViewMaster.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewMaster.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMasterID,
            this.colMasterCode,
            this.colMasterLcp,
            this.colMasterEmp,
            this.colMasterDonVi,
            this.colMasterTienThu,
            this.colMasterTienChi,
            this.cplMasterNgayPs,
            this.colMasterNgayTao,
            this.colMasterNguoiTao,
            this.colMasterDienGiai,
            this.colMasterThuChiBit});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupCount = 1;
            this.gridViewMaster.GroupPanelText = "Danh sách các phiếu thu/chi thỏa điều kiện tìm";
            this.gridViewMaster.IndicatorWidth = 40;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewMaster.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewMaster.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewMaster.OptionsSelection.MultiSelect = true;
            this.gridViewMaster.OptionsView.ColumnAutoWidth = false;
            this.gridViewMaster.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMaster.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = true;
            this.gridViewMaster.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMasterLcp, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colMasterID
            // 
            this.colMasterID.Caption = "ID";
            this.colMasterID.Name = "colMasterID";
            this.colMasterID.Width = 23;
            // 
            // colMasterCode
            // 
            this.colMasterCode.Caption = "Mã phiếu";
            this.colMasterCode.Name = "colMasterCode";
            this.colMasterCode.Visible = true;
            this.colMasterCode.VisibleIndex = 0;
            this.colMasterCode.Width = 55;
            // 
            // colMasterLcp
            // 
            this.colMasterLcp.Caption = "Loại phát sinh";
            this.colMasterLcp.Name = "colMasterLcp";
            this.colMasterLcp.Visible = true;
            this.colMasterLcp.VisibleIndex = 1;
            this.colMasterLcp.Width = 91;
            // 
            // colMasterEmp
            // 
            this.colMasterEmp.Caption = "Người liên quan";
            this.colMasterEmp.Name = "colMasterEmp";
            this.colMasterEmp.Visible = true;
            this.colMasterEmp.VisibleIndex = 2;
            this.colMasterEmp.Width = 86;
            // 
            // colMasterDonVi
            // 
            this.colMasterDonVi.Caption = "Đơn vị liên quan";
            this.colMasterDonVi.Name = "colMasterDonVi";
            this.colMasterDonVi.Visible = true;
            this.colMasterDonVi.VisibleIndex = 3;
            this.colMasterDonVi.Width = 89;
            // 
            // colMasterTienThu
            // 
            this.colMasterTienThu.Caption = "Số tiền thu (VNĐ)";
            this.colMasterTienThu.Name = "colMasterTienThu";
            this.colMasterTienThu.Visible = true;
            this.colMasterTienThu.VisibleIndex = 4;
            this.colMasterTienThu.Width = 96;
            // 
            // colMasterTienChi
            // 
            this.colMasterTienChi.Caption = "Số tiền chi (VNĐ)";
            this.colMasterTienChi.Name = "colMasterTienChi";
            this.colMasterTienChi.Visible = true;
            this.colMasterTienChi.VisibleIndex = 5;
            this.colMasterTienChi.Width = 93;
            // 
            // cplMasterNgayPs
            // 
            this.cplMasterNgayPs.Caption = "Ngày phát sinh";
            this.cplMasterNgayPs.Name = "cplMasterNgayPs";
            this.cplMasterNgayPs.Visible = true;
            this.cplMasterNgayPs.VisibleIndex = 6;
            this.cplMasterNgayPs.Width = 84;
            // 
            // colMasterNgayTao
            // 
            this.colMasterNgayTao.Caption = "Ngày cập nhật";
            this.colMasterNgayTao.Name = "colMasterNgayTao";
            this.colMasterNgayTao.Visible = true;
            this.colMasterNgayTao.VisibleIndex = 7;
            this.colMasterNgayTao.Width = 82;
            // 
            // colMasterNguoiTao
            // 
            this.colMasterNguoiTao.Caption = "Người cập nhật";
            this.colMasterNguoiTao.Name = "colMasterNguoiTao";
            this.colMasterNguoiTao.Visible = true;
            this.colMasterNguoiTao.VisibleIndex = 8;
            this.colMasterNguoiTao.Width = 85;
            // 
            // colMasterDienGiai
            // 
            this.colMasterDienGiai.Caption = "Diễn giải";
            this.colMasterDienGiai.Name = "colMasterDienGiai";
            this.colMasterDienGiai.Visible = true;
            this.colMasterDienGiai.VisibleIndex = 9;
            this.colMasterDienGiai.Width = 52;
            // 
            // colMasterThuChiBit
            // 
            this.colMasterThuChiBit.Caption = "Thu/Chi";
            this.colMasterThuChiBit.Name = "colMasterThuChiBit";
            this.colMasterThuChiBit.Visible = true;
            this.colMasterThuChiBit.VisibleIndex = 10;
            this.colMasterThuChiBit.Width = 49;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // frmKhoaMoSoCongNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 476);
            this.Controls.Add(this.btnCapNhatCongNoDauKy);
            this.Controls.Add(this.gridControlMaster);
            this.Controls.Add(this.InPhieu);
            this.Controls.Add(this.DenNgay);
            this.Controls.Add(this.DaKetChuyen);
            this.Controls.Add(this.TuNgay);
            this.Controls.Add(this.btnMoKhoa);
            this.Controls.Add(this.btnKhoa);
            this.Controls.Add(this.Dong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KyKinhDoanh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Name = "frmKhoaMoSoCongNo";
            this.Text = "Khóa sổ / Mở sổ công nợ";
            ((System.ComponentModel.ISupportInitialize)(this.DaKetChuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties)).EndInit();
            this.ctMnuInPhieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton btnCapNhatCongNoDauKy;
        private DevExpress.XtraEditors.DropDownButton InPhieu;
        private DevExpress.XtraEditors.CheckEdit DaKetChuyen;
        private DevExpress.XtraEditors.DateEdit DenNgay;
        private DevExpress.XtraEditors.DateEdit TuNgay;
        public DevExpress.XtraEditors.SimpleButton btnMoKhoa;
        public DevExpress.XtraEditors.SimpleButton btnKhoa;
        public DevExpress.XtraEditors.SimpleButton Dong;
        private System.Windows.Forms.PLLabel label2;
        private ProtocolVN.Framework.Win.PLCombobox KyKinhDoanh;
        private System.Windows.Forms.PLLabel label1;
        private System.Windows.Forms.PLLabel label15;
        private System.Windows.Forms.ContextMenuStrip ctMnuInPhieu;
        private System.Windows.Forms.ToolStripMenuItem itemXemTruoc;
        protected DevExpress.XtraGrid.GridControl gridControlMaster;
        protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterID;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterLcp;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterEmp;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterTienThu;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterTienChi;
        private DevExpress.XtraGrid.Columns.GridColumn cplMasterNgayPs;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterNgayTao;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterNguoiTao;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterDienGiai;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterThuChiBit;
        protected DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}