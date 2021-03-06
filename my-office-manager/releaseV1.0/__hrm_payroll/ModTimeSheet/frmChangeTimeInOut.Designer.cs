using office;
using ProtocolVN.App.Office.Report;
namespace ProtocolVN.Plugin.TimeSheet
{
    partial class frmChangeTimeInOut
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
            this.grctrlNguoiTGThuc = new DevExpress.XtraGrid.GridControl();
            this.grvwNguoiTGThuc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcolTenNgTGThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcolPhanTramThamGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grctrlNguoiTGDuBi = new DevExpress.XtraGrid.GridControl();
            this.grvwNguoiTGDuBi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Cotphongban = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotnhanvien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.sePhanTramThamGia = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl9 = new System.Windows.Forms.PLLabel();
            this.sbtnThemNguoiThamGia = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnBotNguoiThamGia = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlSource = new DevExpress.XtraGrid.GridControl();
            this.gridViewSource = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHo_ten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TG_ThayDoi = new DevExpress.XtraEditors.TimeEdit();
            this.gridControlDestination = new DevExpress.XtraGrid.GridControl();
            this.gridViewDestination = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPB_DC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHT_DC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTGDC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSub_all = new DevExpress.XtraEditors.SimpleButton();
            this.btnSub_1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd_all = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd_1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.radioGroup = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl10 = new System.Windows.Forms.PLLabel();
            this.dateNgay_LV1 = new DevExpress.XtraEditors.DateEdit();
            this.dateNgay_LV = new DevExpress.XtraEditors.DateEdit();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.cachedPLHeader1 = new ProtocolVN.App.Office.Report.CachedPLHeader();
            ((System.ComponentModel.ISupportInitialize)(this.grctrlNguoiTGThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvwNguoiTGThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grctrlNguoiTGDuBi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvwNguoiTGDuBi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePhanTramThamGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSource)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TG_ThayDoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_LV1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_LV1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_LV.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_LV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grctrlNguoiTGThuc
            // 
            this.grctrlNguoiTGThuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grctrlNguoiTGThuc.Location = new System.Drawing.Point(430, 2);
            this.grctrlNguoiTGThuc.MainView = this.grvwNguoiTGThuc;
            this.grctrlNguoiTGThuc.Name = "grctrlNguoiTGThuc";
            this.grctrlNguoiTGThuc.Size = new System.Drawing.Size(323, 161);
            this.grctrlNguoiTGThuc.TabIndex = 37;
            this.grctrlNguoiTGThuc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvwNguoiTGThuc,
            this.gridView3});
            // 
            // grvwNguoiTGThuc
            // 
            this.grvwNguoiTGThuc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcolTenNgTGThuc,
            this.grcolPhanTramThamGia});
            this.grvwNguoiTGThuc.GridControl = this.grctrlNguoiTGThuc;
            this.grvwNguoiTGThuc.Name = "grvwNguoiTGThuc";
            this.grvwNguoiTGThuc.OptionsBehavior.Editable = false;
            // 
            // grcolTenNgTGThuc
            // 
            this.grcolTenNgTGThuc.AppearanceHeader.Options.UseTextOptions = true;
            this.grcolTenNgTGThuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcolTenNgTGThuc.Caption = "Họ tên";
            this.grcolTenNgTGThuc.Name = "grcolTenNgTGThuc";
            this.grcolTenNgTGThuc.OptionsColumn.AllowEdit = false;
            this.grcolTenNgTGThuc.OptionsColumn.ReadOnly = true;
            this.grcolTenNgTGThuc.Visible = true;
            this.grcolTenNgTGThuc.VisibleIndex = 0;
            // 
            // grcolPhanTramThamGia
            // 
            this.grcolPhanTramThamGia.AppearanceCell.Options.UseTextOptions = true;
            this.grcolPhanTramThamGia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcolPhanTramThamGia.AppearanceHeader.Options.UseTextOptions = true;
            this.grcolPhanTramThamGia.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcolPhanTramThamGia.Caption = "Mức độ tham gia";
            this.grcolPhanTramThamGia.Name = "grcolPhanTramThamGia";
            this.grcolPhanTramThamGia.OptionsColumn.AllowEdit = false;
            this.grcolPhanTramThamGia.OptionsColumn.ReadOnly = true;
            this.grcolPhanTramThamGia.Visible = true;
            this.grcolPhanTramThamGia.VisibleIndex = 1;
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.grctrlNguoiTGThuc;
            this.gridView3.Name = "gridView3";
            // 
            // grctrlNguoiTGDuBi
            // 
            this.grctrlNguoiTGDuBi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grctrlNguoiTGDuBi.Location = new System.Drawing.Point(0, 2);
            this.grctrlNguoiTGDuBi.MainView = this.grvwNguoiTGDuBi;
            this.grctrlNguoiTGDuBi.Name = "grctrlNguoiTGDuBi";
            this.grctrlNguoiTGDuBi.Size = new System.Drawing.Size(352, 161);
            this.grctrlNguoiTGDuBi.TabIndex = 35;
            this.grctrlNguoiTGDuBi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvwNguoiTGDuBi,
            this.gridView2});
            // 
            // grvwNguoiTGDuBi
            // 
            this.grvwNguoiTGDuBi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Cotphongban,
            this.Cotnhanvien});
            this.grvwNguoiTGDuBi.GridControl = this.grctrlNguoiTGDuBi;
            this.grvwNguoiTGDuBi.GroupCount = 1;
            this.grvwNguoiTGDuBi.Name = "grvwNguoiTGDuBi";
            this.grvwNguoiTGDuBi.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvwNguoiTGDuBi.OptionsBehavior.Editable = false;
            this.grvwNguoiTGDuBi.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Cotphongban, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // Cotphongban
            // 
            this.Cotphongban.Caption = "Phòng ban";
            this.Cotphongban.Name = "Cotphongban";
            this.Cotphongban.Visible = true;
            this.Cotphongban.VisibleIndex = 0;
            // 
            // Cotnhanvien
            // 
            this.Cotnhanvien.Caption = "Họ tên";
            this.Cotnhanvien.Name = "Cotnhanvien";
            this.Cotnhanvien.Visible = true;
            this.Cotnhanvien.VisibleIndex = 0;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grctrlNguoiTGDuBi;
            this.gridView2.GroupPanelText = "efwfwfw";
            this.gridView2.Name = "gridView2";
            // 
            // textEdit1
            // 
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(407, 16);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.AllowFocused = false;
            this.textEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit1.Properties.HideSelection = false;
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(21, 18);
            this.textEdit1.TabIndex = 36;
            // 
            // sePhanTramThamGia
            // 
            this.sePhanTramThamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sePhanTramThamGia.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sePhanTramThamGia.Location = new System.Drawing.Point(358, 71);
            this.sePhanTramThamGia.Name = "sePhanTramThamGia";
            this.sePhanTramThamGia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.sePhanTramThamGia.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sePhanTramThamGia.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sePhanTramThamGia.Size = new System.Drawing.Size(55, 20);
            this.sePhanTramThamGia.TabIndex = 34;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(413, 77);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(11, 13);
            this.labelControl9.TabIndex = 32;
            this.labelControl9.Text = "%";
            this.labelControl9.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl9.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // sbtnThemNguoiThamGia
            // 
            this.sbtnThemNguoiThamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnThemNguoiThamGia.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbtnThemNguoiThamGia.Appearance.Options.UseFont = true;
            this.sbtnThemNguoiThamGia.Location = new System.Drawing.Point(358, 46);
            this.sbtnThemNguoiThamGia.Name = "sbtnThemNguoiThamGia";
            this.sbtnThemNguoiThamGia.Size = new System.Drawing.Size(66, 22);
            this.sbtnThemNguoiThamGia.TabIndex = 2;
            this.sbtnThemNguoiThamGia.Text = ">";
            // 
            // sbtnBotNguoiThamGia
            // 
            this.sbtnBotNguoiThamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnBotNguoiThamGia.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbtnBotNguoiThamGia.Appearance.Options.UseFont = true;
            this.sbtnBotNguoiThamGia.Location = new System.Drawing.Point(358, 94);
            this.sbtnBotNguoiThamGia.Name = "sbtnBotNguoiThamGia";
            this.sbtnBotNguoiThamGia.Size = new System.Drawing.Size(66, 22);
            this.sbtnBotNguoiThamGia.TabIndex = 33;
            this.sbtnBotNguoiThamGia.Text = "<";
            // 
            // gridControlSource
            // 
            this.gridControlSource.Location = new System.Drawing.Point(12, 36);
            this.gridControlSource.MainView = this.gridViewSource;
            this.gridControlSource.Name = "gridControlSource";
            this.gridControlSource.Size = new System.Drawing.Size(305, 247);
            this.gridControlSource.TabIndex = 36;
            this.gridControlSource.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSource});
            // 
            // gridViewSource
            // 
            this.gridViewSource.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPb,
            this.colHo_ten});
            this.gridViewSource.GridControl = this.gridControlSource;
            this.gridViewSource.GroupCount = 1;
            this.gridViewSource.Name = "gridViewSource";
            this.gridViewSource.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewSource.OptionsSelection.MultiSelect = true;
            this.gridViewSource.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridViewSource.OptionsView.ShowGroupPanel = false;
            this.gridViewSource.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPb, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewSource.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colPb
            // 
            this.colPb.Caption = "Phòng ban";
            this.colPb.Name = "colPb";
            // 
            // colHo_ten
            // 
            this.colHo_ten.Caption = "Họ tên";
            this.colHo_ten.Name = "colHo_ten";
            this.colHo_ten.OptionsColumn.AllowEdit = false;
            this.colHo_ten.Visible = true;
            this.colHo_ten.VisibleIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TG_ThayDoi);
            this.splitContainer1.Panel1.Controls.Add(this.gridControlDestination);
            this.splitContainer1.Panel1.Controls.Add(this.btnSub_all);
            this.splitContainer1.Panel1.Controls.Add(this.btnSub_1);
            this.splitContainer1.Panel1.Controls.Add(this.btnAdd_all);
            this.splitContainer1.Panel1.Controls.Add(this.btnAdd_1);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainer1.Panel1.Controls.Add(this.radioGroup);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl10);
            this.splitContainer1.Panel1.Controls.Add(this.dateNgay_LV1);
            this.splitContainer1.Panel1.Controls.Add(this.dateNgay_LV);
            this.splitContainer1.Panel1.Controls.Add(this.gridControlSource);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnDong);
            this.splitContainer1.Panel2.Controls.Add(this.btnLuu);
            this.splitContainer1.Size = new System.Drawing.Size(682, 322);
            this.splitContainer1.SplitterDistance = 278;
            this.splitContainer1.TabIndex = 39;
            // 
            // TG_ThayDoi
            // 
            this.TG_ThayDoi.EditValue = new System.DateTime(2009, 11, 27, 0, 0, 0, 0);
            this.TG_ThayDoi.Location = new System.Drawing.Point(565, 10);
            this.TG_ThayDoi.Name = "TG_ThayDoi";
            this.TG_ThayDoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TG_ThayDoi.Properties.DisplayFormat.FormatString = "HH:mm";
            this.TG_ThayDoi.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TG_ThayDoi.Properties.EditFormat.FormatString = "HH:mm";
            this.TG_ThayDoi.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TG_ThayDoi.Properties.Mask.EditMask = "HH:mm";
            this.TG_ThayDoi.Size = new System.Drawing.Size(105, 20);
            this.TG_ThayDoi.TabIndex = 3;
            // 
            // gridControlDestination
            // 
            this.gridControlDestination.Location = new System.Drawing.Point(375, 36);
            this.gridControlDestination.MainView = this.gridViewDestination;
            this.gridControlDestination.Name = "gridControlDestination";
            this.gridControlDestination.Size = new System.Drawing.Size(295, 247);
            this.gridControlDestination.TabIndex = 91;
            this.gridControlDestination.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDestination});
            // 
            // gridViewDestination
            // 
            this.gridViewDestination.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPB_DC,
            this.colHT_DC,
            this.colTGDC});
            this.gridViewDestination.GridControl = this.gridControlDestination;
            this.gridViewDestination.GroupCount = 1;
            this.gridViewDestination.Name = "gridViewDestination";
            this.gridViewDestination.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewDestination.OptionsSelection.MultiSelect = true;
            this.gridViewDestination.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridViewDestination.OptionsView.ShowGroupPanel = false;
            this.gridViewDestination.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPB_DC, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewDestination.DoubleClick += new System.EventHandler(this.gridView4_DoubleClick);
            // 
            // colPB_DC
            // 
            this.colPB_DC.Caption = "Phòng ban";
            this.colPB_DC.Name = "colPB_DC";
            // 
            // colHT_DC
            // 
            this.colHT_DC.Caption = "Họ tên";
            this.colHT_DC.Name = "colHT_DC";
            this.colHT_DC.OptionsColumn.AllowEdit = false;
            this.colHT_DC.Visible = true;
            this.colHT_DC.VisibleIndex = 0;
            // 
            // colTGDC
            // 
            this.colTGDC.Caption = "gridColumn1";
            this.colTGDC.Name = "colTGDC";
            // 
            // btnSub_all
            // 
            this.btnSub_all.Appearance.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSub_all.Appearance.Options.UseFont = true;
            this.btnSub_all.Location = new System.Drawing.Point(331, 189);
            this.btnSub_all.Name = "btnSub_all";
            this.btnSub_all.Size = new System.Drawing.Size(29, 24);
            this.btnSub_all.TabIndex = 7;
            this.btnSub_all.Text = "7";
            this.btnSub_all.Click += new System.EventHandler(this.btnSub_all_Click);
            // 
            // btnSub_1
            // 
            this.btnSub_1.Appearance.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSub_1.Appearance.Options.UseFont = true;
            this.btnSub_1.Location = new System.Drawing.Point(331, 159);
            this.btnSub_1.Name = "btnSub_1";
            this.btnSub_1.Size = new System.Drawing.Size(29, 24);
            this.btnSub_1.TabIndex = 6;
            this.btnSub_1.Text = "3";
            this.btnSub_1.Click += new System.EventHandler(this.btnSub_1_Click);
            // 
            // btnAdd_all
            // 
            this.btnAdd_all.Appearance.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd_all.Appearance.Options.UseFont = true;
            this.btnAdd_all.Location = new System.Drawing.Point(331, 129);
            this.btnAdd_all.Name = "btnAdd_all";
            this.btnAdd_all.Size = new System.Drawing.Size(29, 24);
            this.btnAdd_all.TabIndex = 5;
            this.btnAdd_all.Text = "8";
            this.btnAdd_all.Click += new System.EventHandler(this.btnAdd_all_Click);
            // 
            // btnAdd_1
            // 
            this.btnAdd_1.Appearance.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd_1.Appearance.Options.UseFont = true;
            this.btnAdd_1.Location = new System.Drawing.Point(331, 99);
            this.btnAdd_1.Name = "btnAdd_1";
            this.btnAdd_1.Size = new System.Drawing.Size(29, 24);
            this.btnAdd_1.TabIndex = 4;
            this.btnAdd_1.Text = "4";
            this.btnAdd_1.Click += new System.EventHandler(this.btnAdd_1_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl2.Location = new System.Drawing.Point(536, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 85;
            this.labelControl2.Text = "Giảm";
            this.labelControl2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(269, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 13);
            this.labelControl1.TabIndex = 84;
            this.labelControl1.Text = "Giờ điều chỉnh";
            this.labelControl1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // radioGroup
            // 
            this.radioGroup.Location = new System.Drawing.Point(341, 8);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Giờ bắt đầu"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Giờ kết thúc")});
            this.radioGroup.Size = new System.Drawing.Size(179, 21);
            this.radioGroup.TabIndex = 2;
            this.radioGroup.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(14, 13);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(76, 13);
            this.labelControl10.TabIndex = 82;
            this.labelControl10.Text = "Ngày điều chỉnh";
            this.labelControl10.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl10.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // dateNgay_LV1
            // 
            this.dateNgay_LV1.EditValue = null;
            this.dateNgay_LV1.Location = new System.Drawing.Point(96, 9);
            this.dateNgay_LV1.Name = "dateNgay_LV1";
            this.dateNgay_LV1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgay_LV1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateNgay_LV1.Size = new System.Drawing.Size(145, 20);
            this.dateNgay_LV1.TabIndex = 1;
            this.dateNgay_LV1.Visible = false;
            // 
            // dateNgay_LV
            // 
            this.dateNgay_LV.EditValue = null;
            this.dateNgay_LV.Location = new System.Drawing.Point(96, 9);
            this.dateNgay_LV.Name = "dateNgay_LV";
            this.dateNgay_LV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgay_LV.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateNgay_LV.Size = new System.Drawing.Size(145, 20);
            this.dateNgay_LV.TabIndex = 80;
            this.dateNgay_LV.EditValueChanged += new System.EventHandler(this.dateNgay_LV_EditValueChanged);
            // 
            // btnDong
            // 
            this.btnDong.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDong.Appearance.Options.UseFont = true;
            this.btnDong.Location = new System.Drawing.Point(599, 7);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(72, 24);
            this.btnDong.TabIndex = 9;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Location = new System.Drawing.Point(521, 8);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(72, 23);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmChangeTimeInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 322);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmChangeTimeInOut";
            this.Text = "Điều chỉnh thời gian chấm công";
            this.Load += new System.EventHandler(this.frmThayDoi_GBD_GKT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grctrlNguoiTGThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvwNguoiTGThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grctrlNguoiTGDuBi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvwNguoiTGDuBi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePhanTramThamGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TG_ThayDoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_LV1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_LV1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_LV.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgay_LV.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grctrlNguoiTGThuc;
        private DevExpress.XtraGrid.Views.Grid.GridView grvwNguoiTGThuc;
        private DevExpress.XtraGrid.Columns.GridColumn grcolTenNgTGThuc;
        private DevExpress.XtraGrid.Columns.GridColumn grcolPhanTramThamGia;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.GridControl grctrlNguoiTGDuBi;
        private DevExpress.XtraGrid.Views.Grid.GridView grvwNguoiTGDuBi;
        private DevExpress.XtraGrid.Columns.GridColumn Cotphongban;
        private DevExpress.XtraGrid.Columns.GridColumn Cotnhanvien;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SpinEdit sePhanTramThamGia;
        private DevExpress.XtraEditors.SimpleButton sbtnThemNguoiThamGia;
        private DevExpress.XtraEditors.SimpleButton sbtnBotNguoiThamGia;
        private DevExpress.XtraGrid.GridControl gridControlSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPb;
        private DevExpress.XtraGrid.Columns.GridColumn colHo_ten;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.DateEdit dateNgay_LV;
        private DevExpress.XtraEditors.DateEdit dateNgay_LV1;
        private DevExpress.XtraEditors.RadioGroup radioGroup;
        private DevExpress.XtraEditors.SimpleButton btnSub_1;
        private DevExpress.XtraEditors.SimpleButton btnAdd_all;
        private DevExpress.XtraEditors.SimpleButton btnAdd_1;
        private DevExpress.XtraEditors.SimpleButton btnSub_all;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraGrid.GridControl gridControlDestination;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDestination;
        private DevExpress.XtraGrid.Columns.GridColumn colPB_DC;
        private DevExpress.XtraGrid.Columns.GridColumn colHT_DC;
        private DevExpress.XtraGrid.Columns.GridColumn colTGDC;
        private DevExpress.XtraEditors.TimeEdit TG_ThayDoi;
        private System.Windows.Forms.PLLabel labelControl9;
        private System.Windows.Forms.PLLabel labelControl10;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel labelControl2;
        private CachedPLHeader cachedPLHeader1;
    }
}