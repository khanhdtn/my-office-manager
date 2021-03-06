namespace ProtocolVN.Plugin.TimeSheet
{
    partial class frmKeHoachLamViec
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDuyet = new DevExpress.XtraEditors.SimpleButton();
            this.btnChonNhanVien = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridViewDSCongviec = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotduan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotnhanvien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotcongviec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotmota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.Cotbatdau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotketthuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTGTH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDSCongviec = new DevExpress.XtraGrid.GridControl();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.label2 = new  System.Windows.Forms.PLLabel ();
            this.ctMnuChonHangHoa = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemChonTuKho = new System.Windows.Forms.ToolStripMenuItem();
            this.itemXemTruoc = new System.Windows.Forms.ToolStripMenuItem();
            this.ctMnuInPhieu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NgayNhap = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new  System.Windows.Forms.PLLabel ();
            this.NhanVien = new ProtocolVN.Framework.Win.PLCombobox();
            this.Duyet = new ProtocolVN.Framework.Win.PLDuyetCombobox();
            this.label3 = new  System.Windows.Forms.PLLabel ();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Info = new ProtocolVN.Framework.Win.PLInfoBox();
            this.plFormTitle1 = new ProtocolVN.Framework.Win.PLFormTitle();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSCongviec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSCongviec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.ctMnuChonHangHoa.SuspendLayout();
            this.ctMnuInPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NgayNhap.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayNhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel2.Controls.Add(this.btnDuyet);
            this.flowLayoutPanel2.Controls.Add(this.btnChonNhanVien);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 482);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(187, 33);
            this.flowLayoutPanel2.TabIndex = 29;
            // 
            // btnDuyet
            // 
            this.btnDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDuyet.Location = new System.Drawing.Point(3, 3);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(75, 23);
            this.btnDuyet.TabIndex = 33;
            this.btnDuyet.Text = "&Duyệt";
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // btnChonNhanVien
            // 
            this.btnChonNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChonNhanVien.Location = new System.Drawing.Point(84, 3);
            this.btnChonNhanVien.Name = "btnChonNhanVien";
            this.btnChonNhanVien.Size = new System.Drawing.Size(97, 23);
            this.btnChonNhanVien.TabIndex = 34;
            this.btnChonNhanVien.Text = "&Chọn nhân viên";
            this.btnChonNhanVien.Click += new System.EventHandler(this.btnChonNhanVien_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(640, 483);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 33);
            this.flowLayoutPanel1.TabIndex = 28;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(84, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Ð&óng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridViewDSCongviec
            // 
            this.gridViewDSCongviec.ActiveFilterEnabled = false;
            this.gridViewDSCongviec.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridViewDSCongviec.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridViewDSCongviec.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewDSCongviec.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridViewDSCongviec.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewDSCongviec.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewDSCongviec.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.Cotduan,
            this.cotnhanvien,
            this.Cotcongviec,
            this.Cotmota,
            this.Cotbatdau,
            this.Cotketthuc,
            this.CotTGTH});
            this.gridViewDSCongviec.GridControl = this.gridDSCongviec;
            this.gridViewDSCongviec.GroupPanelText = "Nhật ký làm việc";
            this.gridViewDSCongviec.IndicatorWidth = 40;
            this.gridViewDSCongviec.Name = "gridViewDSCongviec";
            this.gridViewDSCongviec.NewItemRowText = "Thêm mới ở đây";
            this.gridViewDSCongviec.OptionsCustomization.AllowFilter = false;
            this.gridViewDSCongviec.OptionsCustomization.AllowGroup = false;
            this.gridViewDSCongviec.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridViewDSCongviec.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewDSCongviec.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewDSCongviec.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewDSCongviec.OptionsView.ColumnAutoWidth = false;
            this.gridViewDSCongviec.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewDSCongviec.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewDSCongviec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridViewDSCongviec.OptionsView.ShowFooter = true;
            this.gridViewDSCongviec.OptionsView.ShowGroupedColumns = true;
            this.gridViewDSCongviec.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Cotbatdau, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewDSCongviec.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewDSCongviec_CellValueChanged);
            this.gridViewDSCongviec.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridViewDSCongviec_ValidateRow);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.Name = "ID";
            // 
            // Cotduan
            // 
            this.Cotduan.Caption = "Dự án";
            this.Cotduan.Name = "Cotduan";
            this.Cotduan.Visible = true;
            this.Cotduan.VisibleIndex = 0;
            this.Cotduan.Width = 131;
            // 
            // cotnhanvien
            // 
            this.cotnhanvien.Caption = "Nhân viên";
            this.cotnhanvien.Name = "cotnhanvien";
            this.cotnhanvien.Width = 253;
            // 
            // Cotcongviec
            // 
            this.Cotcongviec.Caption = "Công việc";
            this.Cotcongviec.Name = "Cotcongviec";
            this.Cotcongviec.Visible = true;
            this.Cotcongviec.VisibleIndex = 1;
            this.Cotcongviec.Width = 138;
            // 
            // Cotmota
            // 
            this.Cotmota.Caption = "Mô tả công việc";
            this.Cotmota.ColumnEdit = this.repositoryItemMemoEdit1;
            this.Cotmota.Name = "Cotmota";
            this.Cotmota.Visible = true;
            this.Cotmota.VisibleIndex = 2;
            this.Cotmota.Width = 153;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // Cotbatdau
            // 
            this.Cotbatdau.Caption = "Giờ bắt đầu";
            this.Cotbatdau.Name = "Cotbatdau";
            this.Cotbatdau.Visible = true;
            this.Cotbatdau.VisibleIndex = 3;
            this.Cotbatdau.Width = 151;
            // 
            // Cotketthuc
            // 
            this.Cotketthuc.Caption = "Giờ kết thúc";
            this.Cotketthuc.Name = "Cotketthuc";
            this.Cotketthuc.Visible = true;
            this.Cotketthuc.VisibleIndex = 4;
            this.Cotketthuc.Width = 143;
            // 
            // CotTGTH
            // 
            this.CotTGTH.Caption = "Thời gian thực hiện";
            this.CotTGTH.Name = "CotTGTH";
            this.CotTGTH.OptionsColumn.ReadOnly = true;
            this.CotTGTH.Visible = true;
            this.CotTGTH.VisibleIndex = 5;
            this.CotTGTH.Width = 157;
            // 
            // gridDSCongviec
            // 
            this.gridDSCongviec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDSCongviec.Location = new System.Drawing.Point(6, 72);
            this.gridDSCongviec.MainView = this.gridViewDSCongviec;
            this.gridDSCongviec.Name = "gridDSCongviec";
            this.gridDSCongviec.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemMemoEdit1});
            this.gridDSCongviec.Size = new System.Drawing.Size(791, 406);
            this.gridDSCongviec.TabIndex = 27;
            this.gridDSCongviec.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDSCongviec});
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "Duyệt",
            "Chưa Duyệt",
            "Chờ Duyệt"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Ngày làm việc";
            // 
            // ctMnuChonHangHoa
            // 
            this.ctMnuChonHangHoa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemChonTuKho});
            this.ctMnuChonHangHoa.Name = "contextMenuStrip1";
            this.ctMnuChonHangHoa.Size = new System.Drawing.Size(199, 26);
            // 
            // itemChonTuKho
            // 
            this.itemChonTuKho.Name = "itemChonTuKho";
            this.itemChonTuKho.Size = new System.Drawing.Size(198, 22);
            this.itemChonTuKho.Text = "Chọn từ phiếu xuất kho";
            // 
            // itemXemTruoc
            // 
            this.itemXemTruoc.Name = "itemXemTruoc";
            this.itemXemTruoc.Size = new System.Drawing.Size(161, 22);
            this.itemXemTruoc.Text = "Xem trước khi in";
            // 
            // ctMnuInPhieu
            // 
            this.ctMnuInPhieu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemXemTruoc});
            this.ctMnuInPhieu.Name = "contextMenuStrip2";
            this.ctMnuInPhieu.Size = new System.Drawing.Size(162, 26);
            // 
            // NgayNhap
            // 
            this.NgayNhap.EditValue = null;
            this.NgayNhap.Location = new System.Drawing.Point(84, 42);
            this.NgayNhap.Name = "NgayNhap";
            this.NgayNhap.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.NgayNhap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NgayNhap.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.NgayNhap.Size = new System.Drawing.Size(157, 20);
            this.NgayNhap.TabIndex = 22;
            this.NgayNhap.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.NgayNhap_Closed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nhân viên";
            // 
            // NhanVien
            // 
            this.NhanVien.DataSource = null;
            this.NhanVien.DisplayField = null;
            this.NhanVien.Location = new System.Drawing.Point(308, 42);
            this.NhanVien.Name = "NhanVien";
            this.NhanVien.Size = new System.Drawing.Size(173, 20);
            this.NhanVien.TabIndex = 30;
            this.NhanVien.ValueField = null;
            this.NhanVien.SelectedIndexChanged += new System.EventHandler(this.NhanVien_SelectedIndexChanged);
            // 
            // Duyet
            // 
            this.Duyet.Enabled = false;
            this.Duyet.Location = new System.Drawing.Point(561, 42);
            this.Duyet.Name = "Duyet";
            this.Duyet.Size = new System.Drawing.Size(143, 20);
            this.Duyet.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(499, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Tình trạng";
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(561, 42);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "Duyệt",
            "Chưa Duyệt",
            "Chờ  Duyệt"});
            this.comboBoxEdit1.Size = new System.Drawing.Size(42, 20);
            this.comboBoxEdit1.TabIndex = 32;
            this.comboBoxEdit1.Visible = false;
            // 
            // Info
            // 
            this.Info.Location = new System.Drawing.Point(710, 10);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(21, 21);
            this.Info.TabIndex = 33;
            // 
            // plFormTitle1
            // 
            this.plFormTitle1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.plFormTitle1.Appearance.Options.UseFont = true;
            this.plFormTitle1.Appearance.Options.UseTextOptions = true;
            this.plFormTitle1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.plFormTitle1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.plFormTitle1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.plFormTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.plFormTitle1.Location = new System.Drawing.Point(0, 0);
            this.plFormTitle1.Name = "plFormTitle1";
            this.plFormTitle1.Size = new System.Drawing.Size(804, 33);
            this.plFormTitle1.TabIndex = 39;
            this.plFormTitle1.Text = "KẾ HOẠCH LÀM VIỆC";
            // 
            // frmKeHoachLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 517);
            this.Controls.Add(this.plFormTitle1);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.comboBoxEdit1);
            this.Controls.Add(this.Duyet);
            this.Controls.Add(this.NhanVien);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NgayNhap);
            this.Controls.Add(this.gridDSCongviec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmKeHoachLamViec";
            this.Text = "Kế hoạch làm việc";
            this.Load += new System.EventHandler(this.frmTimeTable_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSCongviec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSCongviec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ctMnuChonHangHoa.ResumeLayout(false);
            this.ctMnuInPhieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NgayNhap.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayNhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        public DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Views.Grid.PLGridView gridViewDSCongviec;
        private DevExpress.XtraGrid.GridControl gridDSCongviec;
        private  System.Windows.Forms.PLLabel  label2;
        private System.Windows.Forms.ContextMenuStrip ctMnuChonHangHoa;
        private System.Windows.Forms.ToolStripMenuItem itemChonTuKho;
        private System.Windows.Forms.ToolStripMenuItem itemXemTruoc;
        private System.Windows.Forms.ContextMenuStrip ctMnuInPhieu;
        private DevExpress.XtraEditors.DateEdit NgayNhap;
        private DevExpress.XtraGrid.Columns.GridColumn Cotcongviec;
        private DevExpress.XtraGrid.Columns.GridColumn Cotmota;
        private DevExpress.XtraGrid.Columns.GridColumn Cotbatdau;
        private DevExpress.XtraGrid.Columns.GridColumn Cotketthuc;
        private DevExpress.XtraGrid.Columns.GridColumn CotTGTH;
        private DevExpress.XtraGrid.Columns.GridColumn Cotduan;
        private DevExpress.XtraGrid.Columns.GridColumn cotnhanvien;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private  System.Windows.Forms.PLLabel  label1;
        private ProtocolVN.Framework.Win.PLCombobox NhanVien;
        private ProtocolVN.Framework.Win.PLDuyetCombobox Duyet;
        private  System.Windows.Forms.PLLabel  label3;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        public DevExpress.XtraEditors.SimpleButton btnDuyet;
        public DevExpress.XtraEditors.SimpleButton btnChonNhanVien;
        private ProtocolVN.Framework.Win.PLInfoBox Info;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private ProtocolVN.Framework.Win.PLFormTitle plFormTitle1;

    }
}