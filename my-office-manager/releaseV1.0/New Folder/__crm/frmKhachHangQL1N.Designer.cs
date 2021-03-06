using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using System;
namespace office
{
    partial class frmKhachHangQL1N
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhachHangQL1N));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.MainBar = new DevExpress.XtraBars.Bar();
            this.barButtonItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCommit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemNoCommit = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemSearch = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuFilter = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barCheckItemFilter = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.Cot_gridControlMaster_TenKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_gridControlMaster_Linhvuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_gridControlMaster_Website = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_gridControlMaster_Thongtin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_gridControlMaster_NKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageDetail = new DevExpress.XtraTab.XtraTabPage();
            this.gridDetailChiTietSanPham = new DevExpress.XtraGrid.GridControl();
            this.gridViewDetailChiTietSanPham = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.Cot_gridDetailChiTietSanPham_TenSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_gridDetailChiTietSanPham_SoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_gridDetailChiTietSanPham_VAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_gridDetailChiTietSanPham_ThanhTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_gridDetailChiTietSanPham_MaSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_gridDetailChiTietSanPham_DonGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.popupControlContainerFilter = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.NguoiLienHe = new ProtocolVN.Framework.Win.PLLookupEdit();
            this.txtLVHD = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.plCbbWebsite = new ProtocolVN.Framework.Win.PLCombobox();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.Khachhang = new ProtocolVN.Framework.Win.PLCombobox();
            this.plComboboxAuto2 = new ProtocolVN.Framework.Win.PLComboboxAuto();
            this.plComboboxAuto1 = new ProtocolVN.Framework.Win.PLComboboxAuto();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).BeginInit();
            this.xtraTabControlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailChiTietSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetailChiTietSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).BeginInit();
            this.popupControlContainerFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLVHD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
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
            this.barButtonItemDelete,
            this.barButtonItemUpdate,
            this.barButtonItemPrint,
            this.barStaticItem1,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItemCommit,
            this.barButtonItemNoCommit,
            this.barSubItem1,
            this.barButtonItemXem,
            this.barButtonItemSearch,
            this.barButtonItemClose,
            this.barCheckItemFilter,
            this.barButtonItem3,
            this.barButtonItem4});
            this.barManager1.MaxItemId = 37;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, this.barButtonItemAdd, "&Thêm"),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemXem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemUpdate),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemCommit, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemNoCommit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSearch, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemClose, true)});
            this.MainBar.OptionsBar.AllowQuickCustomization = false;
            this.MainBar.OptionsBar.DrawDragBorder = false;
            this.MainBar.OptionsBar.RotateWhenVertical = false;
            this.MainBar.OptionsBar.UseWholeRow = true;
            this.MainBar.Text = "Custom 1";
            // 
            // barButtonItemAdd
            // 
            this.barButtonItemAdd.Caption = "Thêm";
            this.barButtonItemAdd.Id = 0;
            this.barButtonItemAdd.Name = "barButtonItemAdd";
            this.barButtonItemAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItemXem
            // 
            this.barButtonItemXem.Caption = "X&em";
            this.barButtonItemXem.Id = 24;
            this.barButtonItemXem.Name = "barButtonItemXem";
            this.barButtonItemXem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItemDelete
            // 
            this.barButtonItemDelete.Caption = "&Xóa";
            this.barButtonItemDelete.Id = 1;
            this.barButtonItemDelete.Name = "barButtonItemDelete";
            this.barButtonItemDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItemUpdate
            // 
            this.barButtonItemUpdate.Caption = "&Sửa";
            this.barButtonItemUpdate.Id = 2;
            this.barButtonItemUpdate.Name = "barButtonItemUpdate";
            this.barButtonItemUpdate.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            // barButtonItemCommit
            // 
            this.barButtonItemCommit.Caption = "&Duyệt";
            this.barButtonItemCommit.Id = 17;
            this.barButtonItemCommit.Name = "barButtonItemCommit";
            this.barButtonItemCommit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItemNoCommit
            // 
            this.barButtonItemNoCommit.Caption = "&Không duyệt";
            this.barButtonItemNoCommit.Id = 18;
            this.barButtonItemNoCommit.Name = "barButtonItemNoCommit";
            this.barButtonItemNoCommit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Nghiệp vụ";
            this.barSubItem1.Id = 20;
            this.barSubItem1.Name = "barSubItem1";
            this.barSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItemSearch
            // 
            this.barButtonItemSearch.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItemSearch.Caption = "Tì&m kiếm";
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
            this.barCheckItemFilter.Caption = "Điều &kiện lọc";
            this.barCheckItemFilter.Checked = true;
            this.barCheckItemFilter.Id = 29;
            this.barCheckItemFilter.Name = "barCheckItemFilter";
            this.barCheckItemFilter.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItemClose
            // 
            this.barButtonItemClose.Caption = "Đón&g";
            this.barButtonItemClose.Id = 28;
            this.barButtonItemClose.Name = "barButtonItemClose";
            this.barButtonItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(785, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 497);
            this.barDockControlBottom.Size = new System.Drawing.Size(785, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 473);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(785, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 473);
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
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 91);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlMaster);
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlDetail);
            this.splitContainerControl1.Panel2.Controls.Add(this.gridDetailChiTietSanPham);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(785, 406);
            this.splitContainerControl1.SplitterPosition = 226;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControlMaster
            // 
            this.gridControlMaster.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlMaster.BackgroundImage")));
            this.gridControlMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMaster.Location = new System.Drawing.Point(0, 0);
            this.gridControlMaster.MainView = this.gridViewMaster;
            this.gridControlMaster.Name = "gridControlMaster";
            this.gridControlMaster.Size = new System.Drawing.Size(785, 226);
            this.gridControlMaster.TabIndex = 0;
            this.gridControlMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMaster});
            // 
            // gridViewMaster
            // 
            this.gridViewMaster.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewMaster.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridViewMaster.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewMaster.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Cot_gridControlMaster_TenKH,
            this.Cot_gridControlMaster_Linhvuc,
            this.Cot_gridControlMaster_Website,
            this.Cot_gridControlMaster_Thongtin,
            this.Cot_gridControlMaster_NKH});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupCount = 1;
            this.gridViewMaster.GroupPanelText = "DANH SÁCH KHÁCH HÀNG ";
            this.gridViewMaster.IndicatorWidth = 40;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewMaster.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewMaster.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewMaster.OptionsPrint.UsePrintStyles = true;
            this.gridViewMaster.OptionsSelection.MultiSelect = true;
            this.gridViewMaster.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMaster.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewMaster.OptionsView.ShowFooter = true;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = true;
            this.gridViewMaster.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Cot_gridControlMaster_NKH, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // Cot_gridControlMaster_TenKH
            // 
            this.Cot_gridControlMaster_TenKH.AppearanceHeader.Options.UseTextOptions = true;
            this.Cot_gridControlMaster_TenKH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cot_gridControlMaster_TenKH.Caption = "Tên khách hàng";
            this.Cot_gridControlMaster_TenKH.Name = "Cot_gridControlMaster_TenKH";
            this.Cot_gridControlMaster_TenKH.OptionsColumn.AllowEdit = false;
            this.Cot_gridControlMaster_TenKH.OptionsColumn.AllowFocus = false;
            this.Cot_gridControlMaster_TenKH.OptionsColumn.ReadOnly = true;
            this.Cot_gridControlMaster_TenKH.Visible = true;
            this.Cot_gridControlMaster_TenKH.VisibleIndex = 0;
            this.Cot_gridControlMaster_TenKH.Width = 88;
            // 
            // Cot_gridControlMaster_Linhvuc
            // 
            this.Cot_gridControlMaster_Linhvuc.AppearanceHeader.Options.UseTextOptions = true;
            this.Cot_gridControlMaster_Linhvuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cot_gridControlMaster_Linhvuc.Caption = "Lĩnh vực hoạt động";
            this.Cot_gridControlMaster_Linhvuc.Name = "Cot_gridControlMaster_Linhvuc";
            this.Cot_gridControlMaster_Linhvuc.OptionsColumn.AllowEdit = false;
            this.Cot_gridControlMaster_Linhvuc.OptionsColumn.AllowFocus = false;
            this.Cot_gridControlMaster_Linhvuc.OptionsColumn.ReadOnly = true;
            this.Cot_gridControlMaster_Linhvuc.Visible = true;
            this.Cot_gridControlMaster_Linhvuc.VisibleIndex = 1;
            this.Cot_gridControlMaster_Linhvuc.Width = 104;
            // 
            // Cot_gridControlMaster_Website
            // 
            this.Cot_gridControlMaster_Website.AppearanceHeader.Options.UseTextOptions = true;
            this.Cot_gridControlMaster_Website.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cot_gridControlMaster_Website.Caption = "Website";
            this.Cot_gridControlMaster_Website.Name = "Cot_gridControlMaster_Website";
            this.Cot_gridControlMaster_Website.OptionsColumn.AllowEdit = false;
            this.Cot_gridControlMaster_Website.OptionsColumn.AllowFocus = false;
            this.Cot_gridControlMaster_Website.OptionsColumn.ReadOnly = true;
            this.Cot_gridControlMaster_Website.Visible = true;
            this.Cot_gridControlMaster_Website.VisibleIndex = 2;
            this.Cot_gridControlMaster_Website.Width = 51;
            // 
            // Cot_gridControlMaster_Thongtin
            // 
            this.Cot_gridControlMaster_Thongtin.AppearanceCell.Options.UseTextOptions = true;
            this.Cot_gridControlMaster_Thongtin.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cot_gridControlMaster_Thongtin.AppearanceHeader.Options.UseTextOptions = true;
            this.Cot_gridControlMaster_Thongtin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cot_gridControlMaster_Thongtin.Caption = "Thông tin thêm";
            this.Cot_gridControlMaster_Thongtin.Name = "Cot_gridControlMaster_Thongtin";
            this.Cot_gridControlMaster_Thongtin.OptionsColumn.AllowEdit = false;
            this.Cot_gridControlMaster_Thongtin.OptionsColumn.AllowFocus = false;
            this.Cot_gridControlMaster_Thongtin.OptionsColumn.ReadOnly = true;
            this.Cot_gridControlMaster_Thongtin.Visible = true;
            this.Cot_gridControlMaster_Thongtin.VisibleIndex = 3;
            this.Cot_gridControlMaster_Thongtin.Width = 84;
            // 
            // Cot_gridControlMaster_NKH
            // 
            this.Cot_gridControlMaster_NKH.Caption = "Nhóm khách hàng";
            this.Cot_gridControlMaster_NKH.Name = "Cot_gridControlMaster_NKH";
            this.Cot_gridControlMaster_NKH.Visible = true;
            this.Cot_gridControlMaster_NKH.VisibleIndex = 4;
            this.Cot_gridControlMaster_NKH.Width = 110;
            // 
            // xtraTabControlDetail
            // 
            this.xtraTabControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlDetail.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlDetail.Name = "xtraTabControlDetail";
            this.xtraTabControlDetail.SelectedTabPage = this.xtraTabPageDetail;
            this.xtraTabControlDetail.Size = new System.Drawing.Size(785, 174);
            this.xtraTabControlDetail.TabIndex = 0;
            this.xtraTabControlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageDetail});
            // 
            // xtraTabPageDetail
            // 
            this.xtraTabPageDetail.Name = "xtraTabPageDetail";
            this.xtraTabPageDetail.Size = new System.Drawing.Size(778, 145);
            this.xtraTabPageDetail.Text = "Chi tiết";
            // 
            // gridDetailChiTietSanPham
            // 
            this.gridDetailChiTietSanPham.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridDetailChiTietSanPham.BackgroundImage")));
            this.gridDetailChiTietSanPham.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridDetailChiTietSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetailChiTietSanPham.Location = new System.Drawing.Point(0, 0);
            this.gridDetailChiTietSanPham.MainView = this.gridViewDetailChiTietSanPham;
            this.gridDetailChiTietSanPham.Name = "gridDetailChiTietSanPham";
            this.gridDetailChiTietSanPham.Size = new System.Drawing.Size(785, 174);
            this.gridDetailChiTietSanPham.TabIndex = 11;
            this.gridDetailChiTietSanPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetailChiTietSanPham});
            // 
            // gridViewDetailChiTietSanPham
            // 
            this.gridViewDetailChiTietSanPham.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewDetailChiTietSanPham.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewDetailChiTietSanPham.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Cot_gridDetailChiTietSanPham_TenSanPham,
            this.Cot_gridDetailChiTietSanPham_SoLuong,
            this.Cot_gridDetailChiTietSanPham_VAT,
            this.Cot_gridDetailChiTietSanPham_ThanhTien,
            this.Cot_gridDetailChiTietSanPham_MaSanPham,
            this.Cot_gridDetailChiTietSanPham_DonGia});
            this.gridViewDetailChiTietSanPham.GridControl = this.gridDetailChiTietSanPham;
            this.gridViewDetailChiTietSanPham.IndicatorWidth = 40;
            this.gridViewDetailChiTietSanPham.Name = "gridViewDetailChiTietSanPham";
            this.gridViewDetailChiTietSanPham.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewDetailChiTietSanPham.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewDetailChiTietSanPham.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewDetailChiTietSanPham.OptionsPrint.UsePrintStyles = true;
            this.gridViewDetailChiTietSanPham.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewDetailChiTietSanPham.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewDetailChiTietSanPham.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewDetailChiTietSanPham.OptionsView.ShowGroupedColumns = true;
            this.gridViewDetailChiTietSanPham.OptionsView.ShowGroupPanel = false;
            // 
            // Cot_gridDetailChiTietSanPham_TenSanPham
            // 
            this.Cot_gridDetailChiTietSanPham_TenSanPham.AppearanceHeader.Options.UseTextOptions = true;
            this.Cot_gridDetailChiTietSanPham_TenSanPham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cot_gridDetailChiTietSanPham_TenSanPham.Caption = "Tên sản phẩm";
            this.Cot_gridDetailChiTietSanPham_TenSanPham.Name = "Cot_gridDetailChiTietSanPham_TenSanPham";
            this.Cot_gridDetailChiTietSanPham_TenSanPham.OptionsColumn.AllowEdit = false;
            this.Cot_gridDetailChiTietSanPham_TenSanPham.OptionsColumn.AllowFocus = false;
            this.Cot_gridDetailChiTietSanPham_TenSanPham.OptionsColumn.ReadOnly = true;
            this.Cot_gridDetailChiTietSanPham_TenSanPham.Visible = true;
            this.Cot_gridDetailChiTietSanPham_TenSanPham.VisibleIndex = 1;
            this.Cot_gridDetailChiTietSanPham_TenSanPham.Width = 79;
            // 
            // Cot_gridDetailChiTietSanPham_SoLuong
            // 
            this.Cot_gridDetailChiTietSanPham_SoLuong.AppearanceCell.Options.UseTextOptions = true;
            this.Cot_gridDetailChiTietSanPham_SoLuong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Cot_gridDetailChiTietSanPham_SoLuong.AppearanceHeader.Options.UseTextOptions = true;
            this.Cot_gridDetailChiTietSanPham_SoLuong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cot_gridDetailChiTietSanPham_SoLuong.Caption = "Số lượng";
            this.Cot_gridDetailChiTietSanPham_SoLuong.Name = "Cot_gridDetailChiTietSanPham_SoLuong";
            this.Cot_gridDetailChiTietSanPham_SoLuong.OptionsColumn.AllowEdit = false;
            this.Cot_gridDetailChiTietSanPham_SoLuong.OptionsColumn.AllowFocus = false;
            this.Cot_gridDetailChiTietSanPham_SoLuong.OptionsColumn.ReadOnly = true;
            this.Cot_gridDetailChiTietSanPham_SoLuong.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.Cot_gridDetailChiTietSanPham_SoLuong.Visible = true;
            this.Cot_gridDetailChiTietSanPham_SoLuong.VisibleIndex = 3;
            this.Cot_gridDetailChiTietSanPham_SoLuong.Width = 54;
            // 
            // Cot_gridDetailChiTietSanPham_VAT
            // 
            this.Cot_gridDetailChiTietSanPham_VAT.AppearanceCell.Options.UseTextOptions = true;
            this.Cot_gridDetailChiTietSanPham_VAT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Cot_gridDetailChiTietSanPham_VAT.AppearanceHeader.Options.UseTextOptions = true;
            this.Cot_gridDetailChiTietSanPham_VAT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cot_gridDetailChiTietSanPham_VAT.Caption = "VAT(%)";
            this.Cot_gridDetailChiTietSanPham_VAT.Name = "Cot_gridDetailChiTietSanPham_VAT";
            this.Cot_gridDetailChiTietSanPham_VAT.OptionsColumn.AllowEdit = false;
            this.Cot_gridDetailChiTietSanPham_VAT.OptionsColumn.AllowFocus = false;
            this.Cot_gridDetailChiTietSanPham_VAT.OptionsColumn.ReadOnly = true;
            this.Cot_gridDetailChiTietSanPham_VAT.Visible = true;
            this.Cot_gridDetailChiTietSanPham_VAT.VisibleIndex = 4;
            this.Cot_gridDetailChiTietSanPham_VAT.Width = 50;
            // 
            // Cot_gridDetailChiTietSanPham_ThanhTien
            // 
            this.Cot_gridDetailChiTietSanPham_ThanhTien.AppearanceCell.Options.UseTextOptions = true;
            this.Cot_gridDetailChiTietSanPham_ThanhTien.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Cot_gridDetailChiTietSanPham_ThanhTien.AppearanceHeader.Options.UseTextOptions = true;
            this.Cot_gridDetailChiTietSanPham_ThanhTien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cot_gridDetailChiTietSanPham_ThanhTien.Caption = "Thành tiền";
            this.Cot_gridDetailChiTietSanPham_ThanhTien.Name = "Cot_gridDetailChiTietSanPham_ThanhTien";
            this.Cot_gridDetailChiTietSanPham_ThanhTien.OptionsColumn.AllowEdit = false;
            this.Cot_gridDetailChiTietSanPham_ThanhTien.OptionsColumn.AllowFocus = false;
            this.Cot_gridDetailChiTietSanPham_ThanhTien.OptionsColumn.ReadOnly = true;
            this.Cot_gridDetailChiTietSanPham_ThanhTien.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.Cot_gridDetailChiTietSanPham_ThanhTien.Visible = true;
            this.Cot_gridDetailChiTietSanPham_ThanhTien.VisibleIndex = 5;
            this.Cot_gridDetailChiTietSanPham_ThanhTien.Width = 63;
            // 
            // Cot_gridDetailChiTietSanPham_MaSanPham
            // 
            this.Cot_gridDetailChiTietSanPham_MaSanPham.AppearanceHeader.Options.UseTextOptions = true;
            this.Cot_gridDetailChiTietSanPham_MaSanPham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cot_gridDetailChiTietSanPham_MaSanPham.Caption = "Mã sản phẩm";
            this.Cot_gridDetailChiTietSanPham_MaSanPham.Name = "Cot_gridDetailChiTietSanPham_MaSanPham";
            this.Cot_gridDetailChiTietSanPham_MaSanPham.OptionsColumn.AllowEdit = false;
            this.Cot_gridDetailChiTietSanPham_MaSanPham.OptionsColumn.AllowFocus = false;
            this.Cot_gridDetailChiTietSanPham_MaSanPham.OptionsColumn.ReadOnly = true;
            this.Cot_gridDetailChiTietSanPham_MaSanPham.Visible = true;
            this.Cot_gridDetailChiTietSanPham_MaSanPham.VisibleIndex = 0;
            // 
            // Cot_gridDetailChiTietSanPham_DonGia
            // 
            this.Cot_gridDetailChiTietSanPham_DonGia.AppearanceCell.Options.UseTextOptions = true;
            this.Cot_gridDetailChiTietSanPham_DonGia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Cot_gridDetailChiTietSanPham_DonGia.AppearanceHeader.Options.UseTextOptions = true;
            this.Cot_gridDetailChiTietSanPham_DonGia.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cot_gridDetailChiTietSanPham_DonGia.Caption = "Đơn giá";
            this.Cot_gridDetailChiTietSanPham_DonGia.Name = "Cot_gridDetailChiTietSanPham_DonGia";
            this.Cot_gridDetailChiTietSanPham_DonGia.OptionsColumn.AllowEdit = false;
            this.Cot_gridDetailChiTietSanPham_DonGia.OptionsColumn.AllowFocus = false;
            this.Cot_gridDetailChiTietSanPham_DonGia.OptionsColumn.ReadOnly = true;
            this.Cot_gridDetailChiTietSanPham_DonGia.Visible = true;
            this.Cot_gridDetailChiTietSanPham_DonGia.VisibleIndex = 2;
            this.Cot_gridDetailChiTietSanPham_DonGia.Width = 49;
            // 
            // popupControlContainerFilter
            // 
            this.popupControlContainerFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainerFilter.Controls.Add(this.NguoiLienHe);
            this.popupControlContainerFilter.Controls.Add(this.txtLVHD);
            this.popupControlContainerFilter.Controls.Add(this.labelControl4);
            this.popupControlContainerFilter.Controls.Add(this.plCbbWebsite);
            this.popupControlContainerFilter.Controls.Add(this.labelControl1);
            this.popupControlContainerFilter.Controls.Add(this.labelControl5);
            this.popupControlContainerFilter.Controls.Add(this.labelControl3);
            this.popupControlContainerFilter.Controls.Add(this.Khachhang);
            this.popupControlContainerFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupControlContainerFilter.Location = new System.Drawing.Point(0, 24);
            this.popupControlContainerFilter.Manager = this.barManager1;
            this.popupControlContainerFilter.Name = "popupControlContainerFilter";
            this.popupControlContainerFilter.Size = new System.Drawing.Size(785, 67);
            this.popupControlContainerFilter.TabIndex = 0;
            this.popupControlContainerFilter.Visible = false;
            // 
            // NguoiLienHe
            // 
            this.NguoiLienHe.Location = new System.Drawing.Point(490, 10);
            this.NguoiLienHe.Name = "NguoiLienHe";
            this.NguoiLienHe.Size = new System.Drawing.Size(250, 23);
            this.NguoiLienHe.TabIndex = 190;
            this.NguoiLienHe.ValueField = null;
            // 
            // txtLVHD
            // 
            this.txtLVHD.Location = new System.Drawing.Point(490, 36);
            this.txtLVHD.Name = "txtLVHD";
            this.txtLVHD.Size = new System.Drawing.Size(250, 20);
            this.txtLVHD.TabIndex = 189;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(392, 15);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(62, 13);
            this.labelControl4.TabIndex = 188;
            this.labelControl4.Text = "Người liên hệ";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // plCbbWebsite
            // 
            this.plCbbWebsite.DataSource = null;
            this.plCbbWebsite.DisplayField = null;
            this.plCbbWebsite.Location = new System.Drawing.Point(103, 37);
            this.plCbbWebsite.Name = "plCbbWebsite";
            this.plCbbWebsite.Size = new System.Drawing.Size(239, 20);
            this.plCbbWebsite.TabIndex = 24;
            this.plCbbWebsite.ValueField = null;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(85, 13);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "Nhóm khách hàng";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(392, 40);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(92, 13);
            this.labelControl5.TabIndex = 21;
            this.labelControl5.Text = "Lĩnh vực hoạt động";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 13);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "Khách hàng";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // Khachhang
            // 
            this.Khachhang.DataSource = null;
            this.Khachhang.DisplayField = null;
            this.Khachhang.Location = new System.Drawing.Point(103, 10);
            this.Khachhang.Name = "Khachhang";
            this.Khachhang.Size = new System.Drawing.Size(239, 20);
            this.Khachhang.TabIndex = 19;
            this.Khachhang.ValueField = null;
            // 
            // plComboboxAuto2
            // 
            this.plComboboxAuto2.IDField = null;
            this.plComboboxAuto2.Location = new System.Drawing.Point(74, 36);
            this.plComboboxAuto2.MemberField = null;
            this.plComboboxAuto2.Name = "plComboboxAuto2";
            this.plComboboxAuto2.Size = new System.Drawing.Size(182, 19);
            this.plComboboxAuto2.StartWith = false;
            this.plComboboxAuto2.TabIndex = 24;
            this.plComboboxAuto2.ViewName = null;
            // 
            // plComboboxAuto1
            // 
            this.plComboboxAuto1.IDField = null;
            this.plComboboxAuto1.Location = new System.Drawing.Point(366, 36);
            this.plComboboxAuto1.MemberField = null;
            this.plComboboxAuto1.Name = "plComboboxAuto1";
            this.plComboboxAuto1.Size = new System.Drawing.Size(182, 19);
            this.plComboboxAuto1.StartWith = false;
            this.plComboboxAuto1.TabIndex = 22;
            this.plComboboxAuto1.ViewName = null;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "VAT(%)";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "VAT(%)";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 96;
            // 
            // gridView2
            // 
            this.gridView2.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gridView2.IndicatorWidth = 40;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView2.OptionsPrint.UsePrintStyles = true;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.EnableAppearanceOddRow = true;
            this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView2.OptionsView.ShowGroupedColumns = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Tên sản phẩm";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Số lượng";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "VAT(%)";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "Thành tiền";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "Mã sản phẩm";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.Caption = "Đơn giá";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            // 
            // frmKhachHangQL1N
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
            this.Name = "frmKhachHangQL1N";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản trị quan hệ khách hàng";
            this.Load += new System.EventHandler(this.frmKhachHangQL1N_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).EndInit();
            this.xtraTabControlDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailChiTietSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetailChiTietSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).EndInit();
            this.popupControlContainerFilter.ResumeLayout(false);
            this.popupControlContainerFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLVHD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn CotTenKH;
        private DevExpress.XtraGrid.Columns.GridColumn CotLinhvuc;
        private DevExpress.XtraGrid.Columns.GridColumn CotWebsite;
        private DevExpress.XtraGrid.Columns.GridColumn CotThongtin;
        private DevExpress.XtraGrid.Views.Grid.PLGridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.GridControl gridDetailChiTietSanPham;
        private DevExpress.XtraGrid.Views.Grid.PLGridView gridViewDetailChiTietSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_gridDetailChiTietSanPham_TenSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_gridDetailChiTietSanPham_SoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_gridDetailChiTietSanPham_VAT;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_gridDetailChiTietSanPham_ThanhTien;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_gridDetailChiTietSanPham_MaSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_gridDetailChiTietSanPham_DonGia;
        //private DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
        //private System.ComponentModel.IContainer components;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private PLComboboxAuto plComboboxAuto2;
        private PLComboboxAuto plComboboxAuto1;
        private PLCombobox Khachhang;
        private PLCombobox plCbbWebsite;
        private TextEdit txtLVHD;
        private PLLookupEdit NguoiLienHe;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_gridControlMaster_TenKH;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_gridControlMaster_Linhvuc;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_gridControlMaster_Website;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_gridControlMaster_Thongtin;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_gridControlMaster_NKH;
    }
}
