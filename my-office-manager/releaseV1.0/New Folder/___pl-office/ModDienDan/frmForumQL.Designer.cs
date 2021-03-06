using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmForumQL
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
            catch (System.Exception ex)
            {
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForumQL));
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
            this.CotNhomDienDan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotChuyenMuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotChuDe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotNguoiGui = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTG_Gui = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotLanXem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotLanTraLoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotID_Parent = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.treeDienDan = new ProtocolVN.Framework.Win.PLDMTreeGroup();
            this.NguoiGui = new ProtocolVN.Framework.Win.PLDMTreeGroup();
            this.ngayLamViec = new ProtocolVN.Framework.Win.Office.PLDateSelection();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemClose)});
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
            this.barDockControlTop.Size = new System.Drawing.Size(897, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 497);
            this.barDockControlBottom.Size = new System.Drawing.Size(897, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(897, 24);
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
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 88);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlMaster);
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlDetail);
            this.splitContainerControl1.Panel2.Controls.Add(this.gridDetailChiTietSanPham);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(897, 409);
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
            this.gridControlMaster.Size = new System.Drawing.Size(897, 226);
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
            this.CotNhomDienDan,
            this.CotChuyenMuc,
            this.CotChuDe,
            this.CotNguoiGui,
            this.CotTG_Gui,
            this.CotLanXem,
            this.CotLanTraLoi,
            this.CotID_Parent});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupCount = 2;
            this.gridViewMaster.GroupPanelText = "DANH SÁCH DIỄN ĐÀN";
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
            this.gridViewMaster.OptionsView.ShowGroupPanel = false;
            this.gridViewMaster.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.CotNhomDienDan, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.CotChuyenMuc, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // CotNhomDienDan
            // 
            this.CotNhomDienDan.Caption = "Nhóm diễn đàn";
            this.CotNhomDienDan.Name = "CotNhomDienDan";
            this.CotNhomDienDan.Visible = true;
            this.CotNhomDienDan.VisibleIndex = 0;
            this.CotNhomDienDan.Width = 96;
            // 
            // CotChuyenMuc
            // 
            this.CotChuyenMuc.Caption = "Chuyên mục";
            this.CotChuyenMuc.Name = "CotChuyenMuc";
            this.CotChuyenMuc.Visible = true;
            this.CotChuyenMuc.VisibleIndex = 2;
            this.CotChuyenMuc.Width = 84;
            // 
            // CotChuDe
            // 
            this.CotChuDe.Caption = "Chủ đề";
            this.CotChuDe.Name = "CotChuDe";
            this.CotChuDe.Visible = true;
            this.CotChuDe.VisibleIndex = 1;
            this.CotChuDe.Width = 46;
            // 
            // CotNguoiGui
            // 
            this.CotNguoiGui.Caption = "Người thảo luận";
            this.CotNguoiGui.Name = "CotNguoiGui";
            this.CotNguoiGui.Visible = true;
            this.CotNguoiGui.VisibleIndex = 3;
            this.CotNguoiGui.Width = 88;
            // 
            // CotTG_Gui
            // 
            this.CotTG_Gui.Caption = "Thời gian cập nhật";
            this.CotTG_Gui.Name = "CotTG_Gui";
            this.CotTG_Gui.Visible = true;
            this.CotTG_Gui.VisibleIndex = 4;
            this.CotTG_Gui.Width = 100;
            // 
            // CotLanXem
            // 
            this.CotLanXem.Caption = "Số lần xem";
            this.CotLanXem.Name = "CotLanXem";
            this.CotLanXem.Visible = true;
            this.CotLanXem.VisibleIndex = 5;
            this.CotLanXem.Width = 64;
            // 
            // CotLanTraLoi
            // 
            this.CotLanTraLoi.Caption = "Số lần trả lời";
            this.CotLanTraLoi.Name = "CotLanTraLoi";
            this.CotLanTraLoi.Visible = true;
            this.CotLanTraLoi.VisibleIndex = 6;
            this.CotLanTraLoi.Width = 71;
            // 
            // CotID_Parent
            // 
            this.CotID_Parent.Caption = "ID_Parent";
            this.CotID_Parent.Name = "CotID_Parent";
            this.CotID_Parent.Width = 61;
            // 
            // xtraTabControlDetail
            // 
            this.xtraTabControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlDetail.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlDetail.Name = "xtraTabControlDetail";
            this.xtraTabControlDetail.SelectedTabPage = this.xtraTabPageDetail;
            this.xtraTabControlDetail.Size = new System.Drawing.Size(897, 177);
            this.xtraTabControlDetail.TabIndex = 0;
            this.xtraTabControlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageDetail});
            // 
            // xtraTabPageDetail
            // 
            this.xtraTabPageDetail.Name = "xtraTabPageDetail";
            this.xtraTabPageDetail.Size = new System.Drawing.Size(890, 148);
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
            this.gridDetailChiTietSanPham.Size = new System.Drawing.Size(897, 177);
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
            this.popupControlContainerFilter.Controls.Add(this.treeDienDan);
            this.popupControlContainerFilter.Controls.Add(this.NguoiGui);
            this.popupControlContainerFilter.Controls.Add(this.ngayLamViec);
            this.popupControlContainerFilter.Controls.Add(this.labelControl4);
            this.popupControlContainerFilter.Controls.Add(this.labelControl5);
            this.popupControlContainerFilter.Controls.Add(this.labelControl3);
            this.popupControlContainerFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupControlContainerFilter.Location = new System.Drawing.Point(0, 24);
            this.popupControlContainerFilter.Manager = this.barManager1;
            this.popupControlContainerFilter.Name = "popupControlContainerFilter";
            this.popupControlContainerFilter.Size = new System.Drawing.Size(897, 64);
            this.popupControlContainerFilter.TabIndex = 0;
            this.popupControlContainerFilter.Visible = false;
            // 
            // treeDienDan
            // 
            this.treeDienDan.Location = new System.Drawing.Point(94, 8);
            this.treeDienDan.Name = "treeDienDan";
            this.treeDienDan.Size = new System.Drawing.Size(234, 21);
            this.treeDienDan.TabIndex = 0;
            // 
            // NguoiGui
            // 
            this.NguoiGui.Location = new System.Drawing.Point(94, 40);
            this.NguoiGui.Name = "NguoiGui";
            this.NguoiGui.Size = new System.Drawing.Size(234, 21);
            this.NguoiGui.TabIndex = 1;
            // 
            // ngayLamViec
            // 
            this.ngayLamViec.Caption = "Năm 2010 và 2011";
            this.ngayLamViec.Default = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromMonthToMonth;
            this.ngayLamViec.FirstFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayLamViec.FirstTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayLamViec.FromDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayLamViec.Location = new System.Drawing.Point(436, 7);
            this.ngayLamViec.Name = "ngayLamViec";
            this.ngayLamViec.ReturnType = ProtocolVN.Framework.Win.Trial.TimeType.Date;
            this.ngayLamViec.SecondFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayLamViec.SecondTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayLamViec.SelectedType = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromYearToYear;
            this.ngayLamViec.Size = new System.Drawing.Size(225, 21);
            this.ngayLamViec.TabIndex = 2;
            this.ngayLamViec.ToDate = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayLamViec.Types = ((ProtocolVN.Framework.Win.Trial.SelectionTypes)(((((((((ProtocolVN.Framework.Win.Trial.SelectionTypes.OneDate | ProtocolVN.Framework.Win.Trial.SelectionTypes.OneMonth)
                        | ProtocolVN.Framework.Win.Trial.SelectionTypes.OneQuarter)
                        | ProtocolVN.Framework.Win.Trial.SelectionTypes.OneYear)
                        | ProtocolVN.Framework.Win.Trial.SelectionTypes.SixMonths)
                        | ProtocolVN.Framework.Win.Trial.SelectionTypes.FromDateToDate)
                        | ProtocolVN.Framework.Win.Trial.SelectionTypes.FromMonthToMonth)
                        | ProtocolVN.Framework.Win.Trial.SelectionTypes.FromQuarterToQuarter)
                        | ProtocolVN.Framework.Win.Trial.SelectionTypes.FromYearToYear)));
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 44);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 13);
            this.labelControl4.TabIndex = 188;
            this.labelControl4.Text = "Người thảo luận";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(354, 11);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(70, 13);
            this.labelControl5.TabIndex = 21;
            this.labelControl5.Text = "Ngày cập nhật";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(71, 13);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "Nhóm diễn đàn";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
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
            // frmForumQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 497);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.popupControlContainerFilter);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmForumQL";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diễn đàn thảo luận";
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
        private DevExpress.XtraGrid.Columns.GridColumn CotNhomDienDan;
        private DevExpress.XtraGrid.Columns.GridColumn CotChuyenMuc;
        private DevExpress.XtraGrid.Columns.GridColumn CotChuDe;
        private DevExpress.XtraGrid.Columns.GridColumn CotNguoiGui;
        private DevExpress.XtraGrid.Columns.GridColumn CotTG_Gui;
        private DevExpress.XtraGrid.Columns.GridColumn CotLanXem;
        private DevExpress.XtraGrid.Columns.GridColumn CotLanTraLoi;
        private DevExpress.XtraGrid.Columns.GridColumn CotID_Parent;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl5;
        private ProtocolVN.Framework.Win.Office.PLDateSelection ngayLamViec;
        public PLDMTreeGroup NguoiGui;
        public PLDMTreeGroup treeDienDan;
    }
}
