using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors;
namespace ProtocolVN.Plugin.TimeSheet
{
    partial class frmKeHoachLamViecQL
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.MainBar = new DevExpress.XtraBars.Bar();
            this.barButtonItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXem = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCapNhat = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSearch = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuFilter = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barCheckItemFilter = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItemChon = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnXemDel = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.Cotduan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotcongviec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotmota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotbatdau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotketthuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotthoigian = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotngaylamviec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotnhanvien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.popupControlContainerFilter = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.DuyetSelect = new ProtocolVN.Framework.Win.PLDuyetCheckbox();
            this.labelControl6 =  new  System.Windows.Forms.PLLabel () ;
            this.plCombobox1 = new ProtocolVN.Framework.Win.PLCombobox();
            this.labelControl5 =  new  System.Windows.Forms.PLLabel () ;
            this.loaiduan = new ProtocolVN.Framework.Win.PLCombobox();
            this.labelControl4 =  new  System.Windows.Forms.PLLabel () ;
            this.Duan = new ProtocolVN.Framework.Win.PLCombobox();
            this.nhanvien = new ProtocolVN.Framework.Win.PLLookupEdit();
            this.DenNgay = new DevExpress.XtraEditors.DateEdit();
            this.TuNgay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 =  new  System.Windows.Forms.PLLabel () ;
            this.labelControl2 =  new  System.Windows.Forms.PLLabel () ;
            this.labelControl1 =  new  System.Windows.Forms.PLLabel () ;
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).BeginInit();
            this.popupControlContainerFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.MainBar});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemAdd,
            this.barButtonItemPrint,
            this.barStaticItem1,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItemSearch,
            this.barButtonItemClose,
            this.barCheckItemFilter,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItemChon,
            this.barBtnCapNhat,
            this.barBtnXemDel,
            this.barBtnXem,
            this.barBtnXoa});
            this.barManager1.MaxItemId = 40;
            // 
            // MainBar
            // 
            this.MainBar.BarName = "MainBar";
            this.MainBar.DockCol = 0;
            this.MainBar.DockRow = 0;
            this.MainBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.MainBar.FloatLocation = new System.Drawing.Point(39, 133);
            this.MainBar.FloatSize = new System.Drawing.Size(72, 73);
            this.MainBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, this.barButtonItemAdd, "&Thêm", true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnXem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnCapNhat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSearch, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemChon),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemClose, true)});
            this.MainBar.OptionsBar.AllowQuickCustomization = false;
            this.MainBar.OptionsBar.DrawDragBorder = false;
            this.MainBar.OptionsBar.RotateWhenVertical = false;
            this.MainBar.OptionsBar.UseWholeRow = true;
            this.MainBar.Text = "Custom 1";
            // 
            // barButtonItemAdd
            // 
            this.barButtonItemAdd.Caption = "&Cập nhật";
            this.barButtonItemAdd.Id = 0;
            this.barButtonItemAdd.Name = "barButtonItemAdd";
            this.barButtonItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barBtnXem
            // 
            this.barBtnXem.Caption = "&Xem";
            this.barBtnXem.Glyph = global::pl.office.Properties.Resources.MenuBar_Refresh;
            this.barBtnXem.Id = 38;
            this.barBtnXem.Name = "barBtnXem";
            this.barBtnXem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnXem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // barBtnCapNhat
            // 
            this.barBtnCapNhat.Caption = "&Cập nhật";
            this.barBtnCapNhat.Glyph = global::pl.office.Properties.Resources.plus;
            this.barBtnCapNhat.Id = 36;
            this.barBtnCapNhat.Name = "barBtnCapNhat";
            this.barBtnCapNhat.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnCapNhat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCapNhat_ItemClick);
            // 
            // barBtnXoa
            // 
            this.barBtnXoa.Caption = "&Xóa";
            this.barBtnXoa.Glyph = global::pl.office.Properties.Resources.MenuBar_Delete;
            this.barBtnXoa.Id = 39;
            this.barBtnXoa.Name = "barBtnXoa";
            this.barBtnXoa.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // barButtonItemPrint
            // 
            this.barButtonItemPrint.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItemPrint.Caption = "&In";
            this.barButtonItemPrint.DropDownControl = this.popupMenu1;
            this.barButtonItemPrint.Id = 3;
            this.barButtonItemPrint.Name = "barButtonItemPrint";
            this.barButtonItemPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Xem trước";
            this.barButtonItem4.Id = 33;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItemSearch
            // 
            this.barButtonItemSearch.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItemSearch.Caption = "Tìm &kiếm";
            this.barButtonItemSearch.DropDownControl = this.popupMenuFilter;
            this.barButtonItemSearch.Id = 27;
            this.barButtonItemSearch.Name = "barButtonItemSearch";
            this.barButtonItemSearch.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // popupMenuFilter
            // 
            this.popupMenuFilter.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItemFilter)});
            this.popupMenuFilter.Manager = this.barManager1;
            this.popupMenuFilter.Name = "popupMenuFilter";
            // 
            // barCheckItemFilter
            // 
            this.barCheckItemFilter.Caption = "Ðiều kiện tìm kiếm";
            this.barCheckItemFilter.Checked = true;
            this.barCheckItemFilter.Id = 29;
            this.barCheckItemFilter.Name = "barCheckItemFilter";
            this.barCheckItemFilter.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItemChon
            // 
            this.barButtonItemChon.Caption = "Chọn";
            this.barButtonItemChon.Id = 34;
            this.barButtonItemChon.Name = "barButtonItemChon";
            // 
            // barButtonItemClose
            // 
            this.barButtonItemClose.Caption = "Ðón&g";
            this.barButtonItemClose.Id = 28;
            this.barButtonItemClose.Name = "barButtonItemClose";
            this.barButtonItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
            this.barStaticItem1.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barStaticItem1.Id = 13;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            this.barStaticItem1.Width = 100;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 14;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 15;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem3.Caption = "In";
            this.barButtonItem3.Id = 30;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barBtnXemDel
            // 
            this.barBtnXemDel.Caption = "&Xem";
            this.barBtnXemDel.Id = 37;
            this.barBtnXemDel.Name = "barBtnXemDel";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 95);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlMaster);
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.splitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            this.splitContainerControl1.Size = new System.Drawing.Size(785, 402);
            this.splitContainerControl1.SplitterPosition = 175;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControlMaster
            // 
            this.gridControlMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMaster.Location = new System.Drawing.Point(0, 0);
            this.gridControlMaster.MainView = this.gridViewMaster;
            this.gridControlMaster.Name = "gridControlMaster";
            this.gridControlMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControlMaster.Size = new System.Drawing.Size(785, 402);
            this.gridControlMaster.TabIndex = 3;
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
            this.Cotduan,
            this.Cotcongviec,
            this.Cotmota,
            this.Cotbatdau,
            this.Cotketthuc,
            this.Cotthoigian,
            this.cotngaylamviec,
            this.cotnhanvien});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupCount = 2;
            this.gridViewMaster.IndicatorWidth = 40;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewMaster.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewMaster.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewMaster.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewMaster.OptionsSelection.MultiSelect = true;
            this.gridViewMaster.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMaster.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = true;
            this.gridViewMaster.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.cotnhanvien, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.cotngaylamviec, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewMaster.DoubleClick += new System.EventHandler(this.gridViewMaster_DoubleClick);
            // 
            // Cotduan
            // 
            this.Cotduan.Caption = "Dự án";
            this.Cotduan.Name = "Cotduan";
            this.Cotduan.Visible = true;
            this.Cotduan.VisibleIndex = 0;
            this.Cotduan.Width = 77;
            // 
            // Cotcongviec
            // 
            this.Cotcongviec.Caption = "Công việc";
            this.Cotcongviec.Name = "Cotcongviec";
            this.Cotcongviec.Visible = true;
            this.Cotcongviec.VisibleIndex = 2;
            this.Cotcongviec.Width = 59;
            // 
            // Cotmota
            // 
            this.Cotmota.Caption = "Mô tả công việc";
            this.Cotmota.Name = "Cotmota";
            this.Cotmota.Visible = true;
            this.Cotmota.VisibleIndex = 4;
            this.Cotmota.Width = 87;
            // 
            // Cotbatdau
            // 
            this.Cotbatdau.Caption = "Giờ bắt đầu";
            this.Cotbatdau.Name = "Cotbatdau";
            this.Cotbatdau.Visible = true;
            this.Cotbatdau.VisibleIndex = 5;
            this.Cotbatdau.Width = 67;
            // 
            // Cotketthuc
            // 
            this.Cotketthuc.Caption = "Giờ Kết thúc";
            this.Cotketthuc.Name = "Cotketthuc";
            this.Cotketthuc.Visible = true;
            this.Cotketthuc.VisibleIndex = 6;
            this.Cotketthuc.Width = 70;
            // 
            // Cotthoigian
            // 
            this.Cotthoigian.Caption = "Thời gian thực hiện";
            this.Cotthoigian.Name = "Cotthoigian";
            this.Cotthoigian.Visible = true;
            this.Cotthoigian.VisibleIndex = 7;
            this.Cotthoigian.Width = 103;
            // 
            // cotngaylamviec
            // 
            this.cotngaylamviec.Caption = "Ngày làm việc";
            this.cotngaylamviec.Name = "cotngaylamviec";
            this.cotngaylamviec.Visible = true;
            this.cotngaylamviec.VisibleIndex = 3;
            this.cotngaylamviec.Width = 91;
            // 
            // cotnhanvien
            // 
            this.cotnhanvien.Caption = "Người thực hiện";
            this.cotnhanvien.Name = "cotnhanvien";
            this.cotnhanvien.Visible = true;
            this.cotnhanvien.VisibleIndex = 1;
            this.cotnhanvien.Width = 101;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // popupControlContainerFilter
            // 
            this.popupControlContainerFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainerFilter.Controls.Add(this.DuyetSelect);
            this.popupControlContainerFilter.Controls.Add(this.labelControl6);
            this.popupControlContainerFilter.Controls.Add(this.plCombobox1);
            this.popupControlContainerFilter.Controls.Add(this.labelControl5);
            this.popupControlContainerFilter.Controls.Add(this.loaiduan);
            this.popupControlContainerFilter.Controls.Add(this.labelControl4);
            this.popupControlContainerFilter.Controls.Add(this.Duan);
            this.popupControlContainerFilter.Controls.Add(this.nhanvien);
            this.popupControlContainerFilter.Controls.Add(this.DenNgay);
            this.popupControlContainerFilter.Controls.Add(this.TuNgay);
            this.popupControlContainerFilter.Controls.Add(this.labelControl3);
            this.popupControlContainerFilter.Controls.Add(this.labelControl2);
            this.popupControlContainerFilter.Controls.Add(this.labelControl1);
            this.popupControlContainerFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupControlContainerFilter.Location = new System.Drawing.Point(0, 26);
            this.popupControlContainerFilter.Manager = this.barManager1;
            this.popupControlContainerFilter.Name = "popupControlContainerFilter";
            this.popupControlContainerFilter.Size = new System.Drawing.Size(785, 69);
            this.popupControlContainerFilter.TabIndex = 5;
            this.popupControlContainerFilter.Visible = false;
            // 
            // DuyetSelect
            // 
            this.DuyetSelect.Location = new System.Drawing.Point(539, 7);
            this.DuyetSelect.Name = "DuyetSelect";
            this.DuyetSelect.Size = new System.Drawing.Size(233, 24);
            this.DuyetSelect.TabIndex = 89;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(10, 12);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 13);
            this.labelControl6.TabIndex = 88;
            this.labelControl6.Text = "Nhân viên";
            // 
            // plCombobox1
            // 
            this.plCombobox1.DataSource = null;
            this.plCombobox1.DisplayField = null;
            this.plCombobox1.Location = new System.Drawing.Point(331, 38);
            this.plCombobox1.Name = "plCombobox1";
            this.plCombobox1.Size = new System.Drawing.Size(197, 20);
            this.plCombobox1.TabIndex = 87;
            this.plCombobox1.ValueField = null;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 11);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(53, 13);
            this.labelControl5.TabIndex = 86;
            this.labelControl5.Text = "Loại dự án ";
            this.labelControl5.Visible = false;
            // 
            // loaiduan
            // 
            this.loaiduan.DataSource = null;
            this.loaiduan.DisplayField = null;
            this.loaiduan.Location = new System.Drawing.Point(551, 38);
            this.loaiduan.Name = "loaiduan";
            this.loaiduan.Size = new System.Drawing.Size(49, 20);
            this.loaiduan.TabIndex = 85;
            this.loaiduan.ValueField = null;
            this.loaiduan.Visible = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(282, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(32, 13);
            this.labelControl4.TabIndex = 84;
            this.labelControl4.Text = "Dự án ";
            // 
            // Duan
            // 
            this.Duan.DataSource = null;
            this.Duan.DisplayField = null;
            this.Duan.Location = new System.Drawing.Point(331, 7);
            this.Duan.Name = "Duan";
            this.Duan.Size = new System.Drawing.Size(197, 20);
            this.Duan.TabIndex = 83;
            this.Duan.ValueField = null;
            this.Duan.SelectedIndexChanged += new System.EventHandler(this.Duan_SelectedIndexChanged);
            // 
            // nhanvien
            // 
            this.nhanvien.Location = new System.Drawing.Point(65, 7);
            this.nhanvien.Name = "nhanvien";
            this.nhanvien.Size = new System.Drawing.Size(193, 20);
            this.nhanvien.TabIndex = 82;
            this.nhanvien.ValueField = null;
            // 
            // DenNgay
            // 
            this.DenNgay.EditValue = new System.DateTime(2009, 1, 3, 0, 0, 0, 0);
            this.DenNgay.Location = new System.Drawing.Point(178, 38);
            this.DenNgay.Name = "DenNgay";
            this.DenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DenNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DenNgay.Size = new System.Drawing.Size(80, 20);
            this.DenNgay.TabIndex = 81;
            // 
            // TuNgay
            // 
            this.TuNgay.EditValue = new System.DateTime(2009, 1, 3, 0, 0, 0, 0);
            this.TuNgay.Location = new System.Drawing.Point(65, 38);
            this.TuNgay.Name = "TuNgay";
            this.TuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TuNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TuNgay.Size = new System.Drawing.Size(80, 20);
            this.TuNgay.TabIndex = 80;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(153, 42);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(20, 13);
            this.labelControl3.TabIndex = 77;
            this.labelControl3.Text = "Đến";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 13);
            this.labelControl2.TabIndex = 78;
            this.labelControl2.Text = "Từ ngày ";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(280, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 79;
            this.labelControl1.Text = "Công việc";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "VAT";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "VAT";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 96;
            // 
            // frmKeHoachLamViecQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 497);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.popupControlContainerFilter);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmKeHoachLamViecQL";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý kế hoạch làm việc";
            this.Load += new System.EventHandler(this.frmKeHoachLamViecQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).EndInit();
            this.popupControlContainerFilter.ResumeLayout(false);
            this.popupControlContainerFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        //private System.ComponentModel.IContainer components;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_MA_PXK;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_KHO;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_NGAYXUAT;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_NGUOIXUAT;
        private LabelControl labelControl4;
        private PLCombobox Duan;
        private PLLookupEdit nhanvien;
        private DateEdit DenNgay;
        private DateEdit TuNgay;
        private LabelControl labelControl3;
        private LabelControl labelControl2;
        private LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn Cotduan;
        private DevExpress.XtraGrid.Columns.GridColumn Cotcongviec;
        private DevExpress.XtraGrid.Columns.GridColumn Cotmota;
        private DevExpress.XtraGrid.Columns.GridColumn Cotbatdau;
        private DevExpress.XtraGrid.Columns.GridColumn Cotketthuc;
        private DevExpress.XtraGrid.Columns.GridColumn Cotthoigian;
        private DevExpress.XtraGrid.Columns.GridColumn cotnhanvien;
        private LabelControl labelControl5;
        private PLCombobox loaiduan;
        private LabelControl labelControl6;
        private PLCombobox plCombobox1;
        private DevExpress.XtraGrid.Columns.GridColumn cotngaylamviec;
        public DevExpress.XtraBars.BarButtonItem barBtnCapNhat;
        private PLDuyetCheckbox DuyetSelect;
        private DevExpress.XtraBars.BarButtonItem barBtnXemDel;
        public DevExpress.XtraBars.BarButtonItem barBtnXem;
        public DevExpress.XtraBars.BarButtonItem barBtnXoa;
        
    }
}