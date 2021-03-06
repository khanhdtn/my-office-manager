using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using System;
namespace office
{
    partial class frmBugProductQL
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
            catch (Exception ex) { }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBugProductQL));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.MainBar = new DevExpress.XtraBars.Bar();
            this.barButtonItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
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
            this.Web_Mo_Ta = new System.Windows.Forms.WebBrowser();
            this.popupControlContainerFilter = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.NhanVien = new ProtocolVN.Framework.Win.PLDMTreeGroup();
            this.cmbNguoiNhan = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.labelControl6 = new System.Windows.Forms.PLLabel();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.ngayLamViec = new ProtocolVN.Framework.Win.Office.PLDateSelection();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.loaiVanDe = new ProtocolVN.Framework.Win.PLCombobox();
            this.Tinh_Trang = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.xtraTabControlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabMo_ta = new DevExpress.XtraTab.XtraTabPage();
            this.XtraTabPageDetail = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlThongTinLienHe = new DevExpress.XtraGrid.GridControl();
            this.gridViewThongTinLienHe = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.colNguoi_gui_PH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoi_nhan_PH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTG_Gui_PH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoi_Dung_PH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.colTT_DK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabtaptin = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlTaiLieu = new DevExpress.XtraGrid.GridControl();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.lvTieuDe = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvFile_dinh_kem = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lv_anh_default = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvNoi_dung = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.Item7 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cot_mofile = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rep_mofile = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_cot_mofile_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cot_luufile = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rep_luufile = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_cot_luufile_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cot_xoa = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rep_xoa = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_cot_xoa_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cot_suafile = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rep_sua = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_cot_suafile_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvNguoiCapNhat = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvNgayCapNhat = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvGhi_chu = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_4 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvSize = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_5 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.Group1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.item1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item2 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item3 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item4 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item5 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item6 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.repositoryItemButtonEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemButtonEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemMemoExEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemMemoExEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.gridViewTaiLieu = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.CotFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTieuDe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotxoa2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.colTenBug = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoi_Gui = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoi_Nhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgay_Gui = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT_trang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiVanDe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).BeginInit();
            this.popupControlContainerFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).BeginInit();
            this.xtraTabControlDetail.SuspendLayout();
            this.xtraTabMo_ta.SuspendLayout();
            this.XtraTabPageDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThongTinLienHe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThongTinLienHe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.tabtaptin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_mofile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_mofile_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_luufile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_luufile_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_xoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_xoa_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_sua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_suafile_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaiLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
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
            this.barButtonItem4,
            this.barButtonItem5});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, this.barButtonItemAdd, "&Thêm"),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemXem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemUpdate),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemCommit, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemNoCommit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSearch),
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Xem trước phiếu bá&n hàng";
            this.barButtonItem4.Id = 33;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Xem trước phiếu bả&o hành";
            this.barButtonItem5.Id = 35;
            this.barButtonItem5.Name = "barButtonItem5";
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
            this.barSubItem1.Caption = "&Nghiệp vụ";
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
            this.barDockControlTop.Size = new System.Drawing.Size(869, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 628);
            this.barDockControlBottom.Size = new System.Drawing.Size(869, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 604);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(869, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 604);
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
            // Web_Mo_Ta
            // 
            this.Web_Mo_Ta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Web_Mo_Ta.IsWebBrowserContextMenuEnabled = false;
            this.Web_Mo_Ta.Location = new System.Drawing.Point(0, 0);
            this.Web_Mo_Ta.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.Web_Mo_Ta.MinimumSize = new System.Drawing.Size(20, 20);
            this.Web_Mo_Ta.Name = "Web_Mo_Ta";
            this.barManager1.SetPopupContextMenu(this.Web_Mo_Ta, this.popupMenuFilter);
            this.Web_Mo_Ta.Size = new System.Drawing.Size(862, 291);
            this.Web_Mo_Ta.TabIndex = 1;
            // 
            // popupControlContainerFilter
            // 
            this.popupControlContainerFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainerFilter.Controls.Add(this.NhanVien);
            this.popupControlContainerFilter.Controls.Add(this.cmbNguoiNhan);
            this.popupControlContainerFilter.Controls.Add(this.labelControl6);
            this.popupControlContainerFilter.Controls.Add(this.plLabel2);
            this.popupControlContainerFilter.Controls.Add(this.ngayLamViec);
            this.popupControlContainerFilter.Controls.Add(this.plLabel1);
            this.popupControlContainerFilter.Controls.Add(this.loaiVanDe);
            this.popupControlContainerFilter.Controls.Add(this.Tinh_Trang);
            this.popupControlContainerFilter.Controls.Add(this.labelControl5);
            this.popupControlContainerFilter.Controls.Add(this.labelControl3);
            this.popupControlContainerFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupControlContainerFilter.Location = new System.Drawing.Point(0, 24);
            this.popupControlContainerFilter.Manager = this.barManager1;
            this.popupControlContainerFilter.Name = "popupControlContainerFilter";
            this.popupControlContainerFilter.Size = new System.Drawing.Size(869, 62);
            this.popupControlContainerFilter.TabIndex = 0;
            this.popupControlContainerFilter.Visible = false;
            // 
            // NhanVien
            // 
            this.NhanVien.Location = new System.Drawing.Point(77, 8);
            this.NhanVien.Name = "NhanVien";
            this.NhanVien.Size = new System.Drawing.Size(162, 20);
            this.NhanVien.TabIndex = 0;
            // 
            // cmbNguoiNhan
            // 
            this.cmbNguoiNhan.Location = new System.Drawing.Point(77, 34);
            this.cmbNguoiNhan.Name = "cmbNguoiNhan";
            this.cmbNguoiNhan.Size = new System.Drawing.Size(162, 20);
            this.cmbNguoiNhan.TabIndex = 1;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(9, 39);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(55, 13);
            this.labelControl6.TabIndex = 43;
            this.labelControl6.Text = "Người nhận";
            this.labelControl6.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // plLabel2
            // 
            this.plLabel2.Location = new System.Drawing.Point(10, 9);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(46, 13);
            this.plLabel2.TabIndex = 42;
            this.plLabel2.Text = "Người gửi";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // ngayLamViec
            // 
            this.ngayLamViec.Caption = "Năm 2010 và 2011";
            this.ngayLamViec.Default = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromYearToYear;
            this.ngayLamViec.FirstFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayLamViec.FirstTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayLamViec.FromDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayLamViec.Location = new System.Drawing.Point(600, 37);
            this.ngayLamViec.Name = "ngayLamViec";
            this.ngayLamViec.ReturnType = ProtocolVN.Framework.Win.Trial.TimeType.Date;
            this.ngayLamViec.SecondFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayLamViec.SecondTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayLamViec.SelectedType = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromYearToYear;
            this.ngayLamViec.Size = new System.Drawing.Size(225, 21);
            this.ngayLamViec.TabIndex = 4;
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
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(533, 39);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(61, 13);
            this.plLabel1.TabIndex = 39;
            this.plLabel1.Text = "Thời gian gửi";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // loaiVanDe
            // 
            this.loaiVanDe.AutoSize = true;
            this.loaiVanDe.DataSource = null;
            this.loaiVanDe.DisplayField = null;
            this.loaiVanDe.Location = new System.Drawing.Point(334, 5);
            this.loaiVanDe.Name = "loaiVanDe";
            this.loaiVanDe.Size = new System.Drawing.Size(163, 20);
            this.loaiVanDe.TabIndex = 2;
            this.loaiVanDe.ValueField = null;
            // 
            // Tinh_Trang
            // 
            this.Tinh_Trang.DataSource = null;
            this.Tinh_Trang.DisplayField = null;
            this.Tinh_Trang.Location = new System.Drawing.Point(334, 34);
            this.Tinh_Trang.Name = "Tinh_Trang";
            this.Tinh_Trang.Size = new System.Drawing.Size(163, 20);
            this.Tinh_Trang.TabIndex = 3;
            this.Tinh_Trang.ValueField = "";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(272, 39);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(49, 13);
            this.labelControl5.TabIndex = 38;
            this.labelControl5.Text = "Tình trạng";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(273, 9);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 13);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "Loại vấn đề";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
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
            // xtraTabControlDetail
            // 
            this.xtraTabControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlDetail.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlDetail.Name = "xtraTabControlDetail";
            this.xtraTabControlDetail.SelectedTabPage = this.xtraTabMo_ta;
            this.xtraTabControlDetail.Size = new System.Drawing.Size(869, 320);
            this.xtraTabControlDetail.TabIndex = 0;
            this.xtraTabControlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabMo_ta,
            this.XtraTabPageDetail,
            this.tabtaptin});
            this.xtraTabControlDetail.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControlDetail_SelectedPageChanged);
            // 
            // xtraTabMo_ta
            // 
            this.xtraTabMo_ta.Controls.Add(this.Web_Mo_Ta);
            this.xtraTabMo_ta.Name = "xtraTabMo_ta";
            this.xtraTabMo_ta.Size = new System.Drawing.Size(862, 291);
            this.xtraTabMo_ta.Text = "Mô tả";
            // 
            // XtraTabPageDetail
            // 
            this.XtraTabPageDetail.Controls.Add(this.gridControlThongTinLienHe);
            this.XtraTabPageDetail.Name = "XtraTabPageDetail";
            this.XtraTabPageDetail.Size = new System.Drawing.Size(862, 291);
            this.XtraTabPageDetail.Text = "Danh sách các phản hồi của vấn đề";
            // 
            // gridControlThongTinLienHe
            // 
            this.gridControlThongTinLienHe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlThongTinLienHe.BackgroundImage")));
            this.gridControlThongTinLienHe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlThongTinLienHe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlThongTinLienHe.Location = new System.Drawing.Point(0, 0);
            this.gridControlThongTinLienHe.MainView = this.gridViewThongTinLienHe;
            this.gridControlThongTinLienHe.Name = "gridControlThongTinLienHe";
            this.gridControlThongTinLienHe.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1});
            this.gridControlThongTinLienHe.Size = new System.Drawing.Size(862, 291);
            this.gridControlThongTinLienHe.TabIndex = 10;
            this.gridControlThongTinLienHe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewThongTinLienHe,
            this.gridView3});
            // 
            // gridViewThongTinLienHe
            // 
            this.gridViewThongTinLienHe.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewThongTinLienHe.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewThongTinLienHe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNguoi_gui_PH,
            this.colNguoi_nhan_PH,
            this.colTG_Gui_PH,
            this.colNoi_Dung_PH,
            this.colTT_DK});
            this.gridViewThongTinLienHe.GridControl = this.gridControlThongTinLienHe;
            this.gridViewThongTinLienHe.IndicatorWidth = 40;
            this.gridViewThongTinLienHe.Name = "gridViewThongTinLienHe";
            this.gridViewThongTinLienHe.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewThongTinLienHe.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewThongTinLienHe.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewThongTinLienHe.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewThongTinLienHe.OptionsPrint.UsePrintStyles = true;
            this.gridViewThongTinLienHe.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewThongTinLienHe.OptionsSelection.MultiSelect = true;
            this.gridViewThongTinLienHe.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewThongTinLienHe.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewThongTinLienHe.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewThongTinLienHe.OptionsView.ShowGroupedColumns = true;
            this.gridViewThongTinLienHe.OptionsView.ShowGroupPanel = false;
            this.gridViewThongTinLienHe.OptionsView.ShowHorzLines = false;
            // 
            // colNguoi_gui_PH
            // 
            this.colNguoi_gui_PH.Caption = "Người gửi";
            this.colNguoi_gui_PH.Name = "colNguoi_gui_PH";
            this.colNguoi_gui_PH.OptionsColumn.AllowEdit = false;
            this.colNguoi_gui_PH.Visible = true;
            this.colNguoi_gui_PH.VisibleIndex = 0;
            this.colNguoi_gui_PH.Width = 58;
            // 
            // colNguoi_nhan_PH
            // 
            this.colNguoi_nhan_PH.Caption = "Người nhận";
            this.colNguoi_nhan_PH.Name = "colNguoi_nhan_PH";
            this.colNguoi_nhan_PH.OptionsColumn.AllowEdit = false;
            this.colNguoi_nhan_PH.Visible = true;
            this.colNguoi_nhan_PH.VisibleIndex = 1;
            this.colNguoi_nhan_PH.Width = 67;
            // 
            // colTG_Gui_PH
            // 
            this.colTG_Gui_PH.Caption = "Thời gian phản hồi";
            this.colTG_Gui_PH.Name = "colTG_Gui_PH";
            this.colTG_Gui_PH.OptionsColumn.AllowEdit = false;
            this.colTG_Gui_PH.Visible = true;
            this.colTG_Gui_PH.VisibleIndex = 2;
            this.colTG_Gui_PH.Width = 99;
            // 
            // colNoi_Dung_PH
            // 
            this.colNoi_Dung_PH.Caption = "Nội dung";
            this.colNoi_Dung_PH.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colNoi_Dung_PH.FieldName = "STR_NOI_DUNG";
            this.colNoi_Dung_PH.Name = "colNoi_Dung_PH";
            this.colNoi_Dung_PH.Visible = true;
            this.colNoi_Dung_PH.VisibleIndex = 3;
            this.colNoi_Dung_PH.Width = 54;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // colTT_DK
            // 
            this.colTT_DK.Caption = "Tập tin đính kèm";
            this.colTT_DK.Name = "colTT_DK";
            this.colTT_DK.Width = 90;
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridControlThongTinLienHe;
            this.gridView3.Name = "gridView3";
            // 
            // tabtaptin
            // 
            this.tabtaptin.Controls.Add(this.gridControlTaiLieu);
            this.tabtaptin.Name = "tabtaptin";
            this.tabtaptin.Size = new System.Drawing.Size(862, 291);
            this.tabtaptin.Text = "Danh sách tập Tin";
            // 
            // gridControlTaiLieu
            // 
            this.gridControlTaiLieu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlTaiLieu.BackgroundImage")));
            this.gridControlTaiLieu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlTaiLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTaiLieu.Location = new System.Drawing.Point(0, 0);
            this.gridControlTaiLieu.MainView = this.layoutView1;
            this.gridControlTaiLieu.Name = "gridControlTaiLieu";
            this.gridControlTaiLieu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit3,
            this.repositoryItemPictureEdit2,
            this.repositoryItemButtonEdit4,
            this.repositoryItemButtonEdit5,
            this.repositoryItemMemoExEdit2,
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoExEdit3,
            this.rep_mofile,
            this.rep_luufile,
            this.rep_xoa,
            this.rep_sua});
            this.gridControlTaiLieu.Size = new System.Drawing.Size(862, 291);
            this.gridControlTaiLieu.TabIndex = 191;
            this.gridControlTaiLieu.Tag = "";
            this.gridControlTaiLieu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1,
            this.gridViewTaiLieu,
            this.gridView1});
            this.gridControlTaiLieu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridControlTaiLieu_MouseMove);
            // 
            // layoutView1
            // 
            this.layoutView1.ActiveFilterEnabled = false;
            this.layoutView1.Appearance.CardCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutView1.Appearance.CardCaption.Options.UseFont = true;
            this.layoutView1.CardCaptionFormat = "{2}";
            this.layoutView1.CardHorzInterval = 25;
            this.layoutView1.CardMinSize = new System.Drawing.Size(200, 196);
            this.layoutView1.CardVertInterval = 7;
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.lvTieuDe,
            this.lvFile_dinh_kem,
            this.lv_anh_default,
            this.lvNoi_dung,
            this.cot_mofile,
            this.cot_luufile,
            this.cot_xoa,
            this.cot_suafile,
            this.lvNguoiCapNhat,
            this.lvNgayCapNhat,
            this.lvGhi_chu,
            this.lvSize});
            this.layoutView1.GridControl = this.gridControlTaiLieu;
            this.layoutView1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn2,
            this.Item7,
            this.layoutViewField_cot_xoa_1,
            this.layoutViewField_cot_suafile_1,
            this.layoutViewField_layoutViewColumn1_2});
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.layoutView1.OptionsFilter.AllowFilterEditor = false;
            this.layoutView1.OptionsFilter.AllowMRUFilterList = false;
            this.layoutView1.OptionsItemText.AlignMode = DevExpress.XtraGrid.Views.Layout.FieldTextAlignMode.CustomSize;
            this.layoutView1.OptionsItemText.TextToControlDistance = 2;
            this.layoutView1.OptionsLayout.Columns.AddNewColumns = false;
            this.layoutView1.OptionsView.CardsAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near;
            this.layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
            this.layoutView1.SynchronizeClones = false;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // lvTieuDe
            // 
            this.lvTieuDe.Caption = "Tiêu đề";
            this.lvTieuDe.LayoutViewField = this.layoutViewField_layoutViewColumn1_2;
            this.lvTieuDe.Name = "lvTieuDe";
            this.lvTieuDe.OptionsColumn.AllowEdit = false;
            this.lvTieuDe.OptionsColumn.AllowFocus = false;
            // 
            // layoutViewField_layoutViewColumn1_2
            // 
            this.layoutViewField_layoutViewColumn1_2.EditorPreferredWidth = 20;
            this.layoutViewField_layoutViewColumn1_2.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1_2.Name = "layoutViewField_layoutViewColumn1_2";
            this.layoutViewField_layoutViewColumn1_2.Size = new System.Drawing.Size(194, 170);
            this.layoutViewField_layoutViewColumn1_2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutViewField_layoutViewColumn1_2.TextSize = new System.Drawing.Size(39, 13);
            this.layoutViewField_layoutViewColumn1_2.TextToControlDistance = 5;
            // 
            // lvFile_dinh_kem
            // 
            this.lvFile_dinh_kem.LayoutViewField = this.layoutViewField_layoutViewColumn1_3;
            this.lvFile_dinh_kem.Name = "lvFile_dinh_kem";
            this.lvFile_dinh_kem.OptionsColumn.AllowEdit = false;
            this.lvFile_dinh_kem.OptionsColumn.AllowFocus = false;
            // 
            // layoutViewField_layoutViewColumn1_3
            // 
            this.layoutViewField_layoutViewColumn1_3.EditorPreferredWidth = 107;
            this.layoutViewField_layoutViewColumn1_3.Location = new System.Drawing.Point(81, 0);
            this.layoutViewField_layoutViewColumn1_3.Name = "layoutViewField_layoutViewColumn1_3";
            this.layoutViewField_layoutViewColumn1_3.Size = new System.Drawing.Size(113, 20);
            this.layoutViewField_layoutViewColumn1_3.TextSize = new System.Drawing.Size(0, 13);
            // 
            // lv_anh_default
            // 
            this.lv_anh_default.Caption = "layoutViewColumn2";
            this.lv_anh_default.LayoutViewField = this.layoutViewField_layoutViewColumn2;
            this.lv_anh_default.Name = "lv_anh_default";
            this.lv_anh_default.OptionsColumn.AllowEdit = false;
            this.lv_anh_default.OptionsColumn.AllowFocus = false;
            // 
            // layoutViewField_layoutViewColumn2
            // 
            this.layoutViewField_layoutViewColumn2.EditorPreferredWidth = 20;
            this.layoutViewField_layoutViewColumn2.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn2.Name = "layoutViewField_layoutViewColumn2";
            this.layoutViewField_layoutViewColumn2.Size = new System.Drawing.Size(194, 170);
            this.layoutViewField_layoutViewColumn2.TextSize = new System.Drawing.Size(97, 13);
            this.layoutViewField_layoutViewColumn2.TextToControlDistance = 5;
            // 
            // lvNoi_dung
            // 
            this.lvNoi_dung.ImageIndex = 1;
            this.lvNoi_dung.LayoutViewField = this.Item7;
            this.lvNoi_dung.Name = "lvNoi_dung";
            this.lvNoi_dung.OptionsColumn.AllowEdit = false;
            this.lvNoi_dung.OptionsColumn.AllowFocus = false;
            // 
            // Item7
            // 
            this.Item7.EditorPreferredWidth = 20;
            this.Item7.Image = ((System.Drawing.Image)(resources.GetObject("Item7.Image")));
            this.Item7.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Item7.ImageIndex = 1;
            this.Item7.Location = new System.Drawing.Point(0, 0);
            this.Item7.MaxSize = new System.Drawing.Size(60, 52);
            this.Item7.MinSize = new System.Drawing.Size(60, 52);
            this.Item7.Name = "Item7";
            this.Item7.Size = new System.Drawing.Size(194, 170);
            this.Item7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.Item7.TextSize = new System.Drawing.Size(0, 0);
            this.Item7.TextToControlDistance = 0;
            this.Item7.TextVisible = false;
            // 
            // cot_mofile
            // 
            this.cot_mofile.Caption = "Mở file";
            this.cot_mofile.ColumnEdit = this.rep_mofile;
            this.cot_mofile.LayoutViewField = this.layoutViewField_cot_mofile_1;
            this.cot_mofile.Name = "cot_mofile";
            // 
            // rep_mofile
            // 
            this.rep_mofile.Name = "rep_mofile";
            this.rep_mofile.Click += new System.EventHandler(this.rep_mofile_Click);
            // 
            // layoutViewField_cot_mofile_1
            // 
            this.layoutViewField_cot_mofile_1.EditorPreferredWidth = 26;
            this.layoutViewField_cot_mofile_1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_cot_mofile_1.MaxSize = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_mofile_1.MinSize = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_mofile_1.Name = "layoutViewField_cot_mofile_1";
            this.layoutViewField_cot_mofile_1.Size = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_mofile_1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_cot_mofile_1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_cot_mofile_1.TextToControlDistance = 0;
            this.layoutViewField_cot_mofile_1.TextVisible = false;
            // 
            // cot_luufile
            // 
            this.cot_luufile.Caption = "lưu file";
            this.cot_luufile.ColumnEdit = this.rep_luufile;
            this.cot_luufile.LayoutViewField = this.layoutViewField_cot_luufile_1;
            this.cot_luufile.Name = "cot_luufile";
            // 
            // rep_luufile
            // 
            this.rep_luufile.Name = "rep_luufile";
            this.rep_luufile.Click += new System.EventHandler(this.rep_luu_file_Click);
            // 
            // layoutViewField_cot_luufile_1
            // 
            this.layoutViewField_cot_luufile_1.EditorPreferredWidth = 26;
            this.layoutViewField_cot_luufile_1.Location = new System.Drawing.Point(30, 0);
            this.layoutViewField_cot_luufile_1.MaxSize = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_luufile_1.MinSize = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_luufile_1.Name = "layoutViewField_cot_luufile_1";
            this.layoutViewField_cot_luufile_1.Size = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_luufile_1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_cot_luufile_1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_cot_luufile_1.TextToControlDistance = 0;
            this.layoutViewField_cot_luufile_1.TextVisible = false;
            // 
            // cot_xoa
            // 
            this.cot_xoa.Caption = "Xóa File";
            this.cot_xoa.ColumnEdit = this.rep_xoa;
            this.cot_xoa.LayoutViewField = this.layoutViewField_cot_xoa_1;
            this.cot_xoa.Name = "cot_xoa";
            // 
            // rep_xoa
            // 
            this.rep_xoa.Name = "rep_xoa";
            // 
            // layoutViewField_cot_xoa_1
            // 
            this.layoutViewField_cot_xoa_1.EditorPreferredWidth = 20;
            this.layoutViewField_cot_xoa_1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_cot_xoa_1.MaxSize = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_xoa_1.MinSize = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_xoa_1.Name = "layoutViewField_cot_xoa_1";
            this.layoutViewField_cot_xoa_1.Size = new System.Drawing.Size(194, 170);
            this.layoutViewField_cot_xoa_1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_cot_xoa_1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_cot_xoa_1.TextToControlDistance = 0;
            this.layoutViewField_cot_xoa_1.TextVisible = false;
            // 
            // cot_suafile
            // 
            this.cot_suafile.Caption = "Sửa File";
            this.cot_suafile.ColumnEdit = this.rep_sua;
            this.cot_suafile.LayoutViewField = this.layoutViewField_cot_suafile_1;
            this.cot_suafile.Name = "cot_suafile";
            // 
            // rep_sua
            // 
            this.rep_sua.Name = "rep_sua";
            // 
            // layoutViewField_cot_suafile_1
            // 
            this.layoutViewField_cot_suafile_1.EditorPreferredWidth = 20;
            this.layoutViewField_cot_suafile_1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_cot_suafile_1.MaxSize = new System.Drawing.Size(29, 26);
            this.layoutViewField_cot_suafile_1.MinSize = new System.Drawing.Size(29, 26);
            this.layoutViewField_cot_suafile_1.Name = "layoutViewField_cot_suafile_1";
            this.layoutViewField_cot_suafile_1.Size = new System.Drawing.Size(194, 170);
            this.layoutViewField_cot_suafile_1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_cot_suafile_1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_cot_suafile_1.TextToControlDistance = 0;
            this.layoutViewField_cot_suafile_1.TextVisible = false;
            // 
            // lvNguoiCapNhat
            // 
            this.lvNguoiCapNhat.LayoutViewField = this.layoutViewField_layoutViewColumn1;
            this.lvNguoiCapNhat.Name = "lvNguoiCapNhat";
            this.lvNguoiCapNhat.OptionsColumn.AllowEdit = false;
            this.lvNguoiCapNhat.OptionsColumn.AllowFocus = false;
            // 
            // layoutViewField_layoutViewColumn1
            // 
            this.layoutViewField_layoutViewColumn1.EditorPreferredWidth = 107;
            this.layoutViewField_layoutViewColumn1.Location = new System.Drawing.Point(81, 40);
            this.layoutViewField_layoutViewColumn1.Name = "layoutViewField_layoutViewColumn1";
            this.layoutViewField_layoutViewColumn1.Size = new System.Drawing.Size(113, 20);
            this.layoutViewField_layoutViewColumn1.TextSize = new System.Drawing.Size(0, 13);
            // 
            // lvNgayCapNhat
            // 
            this.lvNgayCapNhat.LayoutViewField = this.layoutViewField_layoutViewColumn1_1;
            this.lvNgayCapNhat.Name = "lvNgayCapNhat";
            this.lvNgayCapNhat.OptionsColumn.AllowEdit = false;
            this.lvNgayCapNhat.OptionsColumn.AllowFocus = false;
            // 
            // layoutViewField_layoutViewColumn1_1
            // 
            this.layoutViewField_layoutViewColumn1_1.EditorPreferredWidth = 107;
            this.layoutViewField_layoutViewColumn1_1.Location = new System.Drawing.Point(81, 60);
            this.layoutViewField_layoutViewColumn1_1.Name = "layoutViewField_layoutViewColumn1_1";
            this.layoutViewField_layoutViewColumn1_1.Size = new System.Drawing.Size(113, 20);
            this.layoutViewField_layoutViewColumn1_1.TextSize = new System.Drawing.Size(0, 13);
            // 
            // lvGhi_chu
            // 
            this.lvGhi_chu.LayoutViewField = this.layoutViewField_layoutViewColumn1_4;
            this.lvGhi_chu.Name = "lvGhi_chu";
            // 
            // layoutViewField_layoutViewColumn1_4
            // 
            this.layoutViewField_layoutViewColumn1_4.EditorPreferredWidth = 107;
            this.layoutViewField_layoutViewColumn1_4.Location = new System.Drawing.Point(81, 80);
            this.layoutViewField_layoutViewColumn1_4.Name = "layoutViewField_layoutViewColumn1_4";
            this.layoutViewField_layoutViewColumn1_4.Size = new System.Drawing.Size(113, 20);
            this.layoutViewField_layoutViewColumn1_4.TextSize = new System.Drawing.Size(0, 13);
            // 
            // lvSize
            // 
            this.lvSize.LayoutViewField = this.layoutViewField_layoutViewColumn1_5;
            this.lvSize.Name = "lvSize";
            this.lvSize.OptionsColumn.AllowEdit = false;
            this.lvSize.OptionsColumn.AllowFocus = false;
            // 
            // layoutViewField_layoutViewColumn1_5
            // 
            this.layoutViewField_layoutViewColumn1_5.EditorPreferredWidth = 107;
            this.layoutViewField_layoutViewColumn1_5.Location = new System.Drawing.Point(81, 20);
            this.layoutViewField_layoutViewColumn1_5.Name = "layoutViewField_layoutViewColumn1_5";
            this.layoutViewField_layoutViewColumn1_5.Size = new System.Drawing.Size(113, 20);
            this.layoutViewField_layoutViewColumn1_5.TextSize = new System.Drawing.Size(0, 13);
            this.layoutViewField_layoutViewColumn1_5.TextToControlDistance = 2;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "layoutViewTemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn1,
            this.layoutViewField_layoutViewColumn1_3,
            this.Group1,
            this.layoutViewField_layoutViewColumn1_1,
            this.layoutViewField_layoutViewColumn1_4,
            this.item2,
            this.item3,
            this.item4,
            this.item5,
            this.layoutViewField_layoutViewColumn1_5,
            this.item6});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 2;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // Group1
            // 
            this.Group1.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.Group1.AppearanceGroup.Options.UseFont = true;
            this.Group1.CustomizationFormText = "Thao tác";
            this.Group1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_cot_mofile_1,
            this.layoutViewField_cot_luufile_1,
            this.item1});
            this.Group1.Location = new System.Drawing.Point(0, 100);
            this.Group1.Name = "Group1";
            this.Group1.Size = new System.Drawing.Size(194, 70);
            this.Group1.Text = "Thao tác";
            // 
            // item1
            // 
            this.item1.CustomizationFormText = " ";
            this.item1.Location = new System.Drawing.Point(60, 0);
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(110, 26);
            this.item1.Text = " ";
            this.item1.TextSize = new System.Drawing.Size(3, 13);
            // 
            // item2
            // 
            this.item2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item2.AppearanceItemCaption.Options.UseFont = true;
            this.item2.CustomizationFormText = "Tên tập tin:";
            this.item2.Location = new System.Drawing.Point(0, 0);
            this.item2.Name = "item2";
            this.item2.Size = new System.Drawing.Size(81, 20);
            this.item2.Text = "Tên tập tin:";
            this.item2.TextSize = new System.Drawing.Size(56, 13);
            // 
            // item3
            // 
            this.item3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item3.AppearanceItemCaption.Options.UseFont = true;
            this.item3.CustomizationFormText = "Người cập nhật:";
            this.item3.Location = new System.Drawing.Point(0, 40);
            this.item3.Name = "item3";
            this.item3.Size = new System.Drawing.Size(81, 20);
            this.item3.Text = "Người cập nhật:";
            this.item3.TextSize = new System.Drawing.Size(77, 13);
            // 
            // item4
            // 
            this.item4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item4.AppearanceItemCaption.Options.UseFont = true;
            this.item4.CustomizationFormText = "Ngày cập nhật:";
            this.item4.Location = new System.Drawing.Point(0, 60);
            this.item4.Name = "item4";
            this.item4.Size = new System.Drawing.Size(81, 20);
            this.item4.Text = "Ngày cập nhật:";
            this.item4.TextSize = new System.Drawing.Size(74, 13);
            // 
            // item5
            // 
            this.item5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item5.AppearanceItemCaption.Options.UseFont = true;
            this.item5.CustomizationFormText = "Ghi chú:";
            this.item5.Location = new System.Drawing.Point(0, 80);
            this.item5.Name = "item5";
            this.item5.Size = new System.Drawing.Size(81, 20);
            this.item5.Text = "Ghi chú:";
            this.item5.TextSize = new System.Drawing.Size(39, 13);
            // 
            // item6
            // 
            this.item6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item6.AppearanceItemCaption.Options.UseFont = true;
            this.item6.CustomizationFormText = "Độ lớn(KB):";
            this.item6.Location = new System.Drawing.Point(0, 20);
            this.item6.Name = "item6";
            this.item6.Size = new System.Drawing.Size(81, 20);
            this.item6.Text = "Độ lớn(KB):";
            this.item6.TextSize = new System.Drawing.Size(55, 13);
            // 
            // repositoryItemButtonEdit3
            // 
            this.repositoryItemButtonEdit3.AutoHeight = false;
            this.repositoryItemButtonEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repositoryItemButtonEdit3.Name = "repositoryItemButtonEdit3";
            this.repositoryItemButtonEdit3.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            // 
            // repositoryItemButtonEdit4
            // 
            this.repositoryItemButtonEdit4.AutoHeight = false;
            this.repositoryItemButtonEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.OK)});
            this.repositoryItemButtonEdit4.Name = "repositoryItemButtonEdit4";
            // 
            // repositoryItemButtonEdit5
            // 
            this.repositoryItemButtonEdit5.AutoHeight = false;
            this.repositoryItemButtonEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Mở file", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, false)});
            this.repositoryItemButtonEdit5.Name = "repositoryItemButtonEdit5";
            this.repositoryItemButtonEdit5.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemMemoExEdit2
            // 
            this.repositoryItemMemoExEdit2.AutoHeight = false;
            this.repositoryItemMemoExEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit2.Name = "repositoryItemMemoExEdit2";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // repositoryItemMemoExEdit3
            // 
            this.repositoryItemMemoExEdit3.AutoHeight = false;
            this.repositoryItemMemoExEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit3.Name = "repositoryItemMemoExEdit3";
            // 
            // gridViewTaiLieu
            // 
            this.gridViewTaiLieu.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewTaiLieu.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewTaiLieu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CotFile,
            this.CotGhiChu,
            this.CotTieuDe,
            this.cotID,
            this.cotxoa2});
            this.gridViewTaiLieu.GridControl = this.gridControlTaiLieu;
            this.gridViewTaiLieu.GroupPanelText = "Thông tin liên lạc";
            this.gridViewTaiLieu.IndicatorWidth = 40;
            this.gridViewTaiLieu.Name = "gridViewTaiLieu";
            this.gridViewTaiLieu.NewItemRowText = "Nhập dòng mới ở đây";
            this.gridViewTaiLieu.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewTaiLieu.OptionsFilter.AllowFilterEditor = false;
            this.gridViewTaiLieu.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewTaiLieu.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewTaiLieu.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewTaiLieu.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewTaiLieu.OptionsPrint.UsePrintStyles = true;
            this.gridViewTaiLieu.OptionsView.ColumnAutoWidth = false;
            this.gridViewTaiLieu.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewTaiLieu.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewTaiLieu.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewTaiLieu.OptionsView.ShowGroupedColumns = true;
            this.gridViewTaiLieu.OptionsView.ShowGroupPanel = false;
            this.gridViewTaiLieu.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            // 
            // CotFile
            // 
            this.CotFile.AppearanceHeader.Options.UseTextOptions = true;
            this.CotFile.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CotFile.Caption = "File đính kèm";
            this.CotFile.FieldName = "TEN_FILE";
            this.CotFile.Name = "CotFile";
            this.CotFile.OptionsColumn.AllowEdit = false;
            this.CotFile.OptionsColumn.ReadOnly = true;
            this.CotFile.Visible = true;
            this.CotFile.VisibleIndex = 1;
            this.CotFile.Width = 73;
            // 
            // CotGhiChu
            // 
            this.CotGhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.CotGhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CotGhiChu.Caption = "Ghi chú";
            this.CotGhiChu.Name = "CotGhiChu";
            this.CotGhiChu.OptionsColumn.ReadOnly = true;
            this.CotGhiChu.Visible = true;
            this.CotGhiChu.VisibleIndex = 2;
            this.CotGhiChu.Width = 47;
            // 
            // CotTieuDe
            // 
            this.CotTieuDe.Caption = "Tiêu đề";
            this.CotTieuDe.Name = "CotTieuDe";
            this.CotTieuDe.OptionsColumn.AllowEdit = false;
            this.CotTieuDe.OptionsColumn.ReadOnly = true;
            this.CotTieuDe.Visible = true;
            this.CotTieuDe.VisibleIndex = 0;
            this.CotTieuDe.Width = 47;
            // 
            // cotID
            // 
            this.cotID.Caption = "gridColumn1";
            this.cotID.Name = "cotID";
            this.cotID.Width = 71;
            // 
            // cotxoa2
            // 
            this.cotxoa2.ColumnEdit = this.repositoryItemButtonEdit3;
            this.cotxoa2.MaxWidth = 30;
            this.cotxoa2.MinWidth = 30;
            this.cotxoa2.Name = "cotxoa2";
            this.cotxoa2.Visible = true;
            this.cotxoa2.VisibleIndex = 3;
            this.cotxoa2.Width = 30;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlTaiLieu;
            this.gridView1.Name = "gridView1";
            // 
            // gridControlMaster
            // 
            this.gridControlMaster.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlMaster.BackgroundImage")));
            this.gridControlMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            gridLevelNode2.RelationName = "Level2";
            this.gridControlMaster.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.gridControlMaster.Location = new System.Drawing.Point(0, 0);
            this.gridControlMaster.MainView = this.gridViewMaster;
            this.gridControlMaster.Name = "gridControlMaster";
            this.gridControlMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1});
            this.gridControlMaster.Size = new System.Drawing.Size(869, 216);
            this.gridControlMaster.TabIndex = 0;
            this.gridControlMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMaster,
            this.gridView4});
            // 
            // gridViewMaster
            // 
            this.gridViewMaster.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewMaster.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridViewMaster.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewMaster.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenBug,
            this.colNguoi_Gui,
            this.colNguoi_Nhan,
            this.colNgay_Gui,
            this.colT_trang,
            this.colLoaiVanDe});
            this.gridViewMaster.CustomizationFormBounds = new System.Drawing.Rectangle(705, 329, 208, 168);
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupCount = 1;
            this.gridViewMaster.GroupPanelText = "DANH SÁCH VẤN ĐỀ";
            this.gridViewMaster.IndicatorWidth = 40;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewMaster.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewMaster.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewMaster.OptionsPrint.UsePrintStyles = true;
            this.gridViewMaster.OptionsSelection.MultiSelect = true;
            this.gridViewMaster.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridViewMaster.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMaster.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewMaster.OptionsView.RowAutoHeight = true;
            this.gridViewMaster.OptionsView.ShowFooter = true;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = true;
            this.gridViewMaster.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLoaiVanDe, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colTenBug
            // 
            this.colTenBug.Caption = "Vấn đề";
            this.colTenBug.Name = "colTenBug";
            this.colTenBug.Visible = true;
            this.colTenBug.VisibleIndex = 0;
            this.colTenBug.Width = 45;
            // 
            // colNguoi_Gui
            // 
            this.colNguoi_Gui.Caption = "Người gửi";
            this.colNguoi_Gui.Name = "colNguoi_Gui";
            this.colNguoi_Gui.Visible = true;
            this.colNguoi_Gui.VisibleIndex = 1;
            this.colNguoi_Gui.Width = 58;
            // 
            // colNguoi_Nhan
            // 
            this.colNguoi_Nhan.Caption = "Người nhận";
            this.colNguoi_Nhan.Name = "colNguoi_Nhan";
            this.colNguoi_Nhan.Visible = true;
            this.colNguoi_Nhan.VisibleIndex = 3;
            this.colNguoi_Nhan.Width = 67;
            // 
            // colNgay_Gui
            // 
            this.colNgay_Gui.Caption = "Thời gian gửi";
            this.colNgay_Gui.Name = "colNgay_Gui";
            this.colNgay_Gui.Visible = true;
            this.colNgay_Gui.VisibleIndex = 2;
            this.colNgay_Gui.Width = 73;
            // 
            // colT_trang
            // 
            this.colT_trang.Caption = "Tình trạng";
            this.colT_trang.Name = "colT_trang";
            this.colT_trang.Visible = true;
            this.colT_trang.VisibleIndex = 4;
            this.colT_trang.Width = 61;
            // 
            // colLoaiVanDe
            // 
            this.colLoaiVanDe.Caption = "Loại vấn đề";
            this.colLoaiVanDe.Name = "colLoaiVanDe";
            this.colLoaiVanDe.Visible = true;
            this.colLoaiVanDe.VisibleIndex = 5;
            this.colLoaiVanDe.Width = 80;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.gridControlMaster;
            this.gridView4.Name = "gridView4";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 86);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlMaster);
            this.splitContainerControl1.Panel1.MinSize = 216;
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlDetail);
            this.splitContainerControl1.Panel2.MinSize = 216;
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(869, 542);
            this.splitContainerControl1.SplitterPosition = 216;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // frmBugProductQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 628);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.popupControlContainerFilter);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Name = "frmBugProductQL";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý vấn đề";
            this.Load += new System.EventHandler(this.frmQLCongviecQL1N_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).EndInit();
            this.popupControlContainerFilter.ResumeLayout(false);
            this.popupControlContainerFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).EndInit();
            this.xtraTabControlDetail.ResumeLayout(false);
            this.xtraTabMo_ta.ResumeLayout(false);
            this.XtraTabPageDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThongTinLienHe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThongTinLienHe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.tabtaptin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_mofile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_mofile_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_luufile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_luufile_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_xoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_xoa_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_sua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_suafile_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaiLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraGrid.Views.Grid.PLGridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private PLImgCombobox Tinh_Trang;
        private PLCombobox loaiVanDe;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel plLabel1;
        private ProtocolVN.Framework.Win.Office.PLDateSelection ngayLamViec;

        private DevExpress.XtraGrid.Columns.GridColumn colTenBug;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoi_Gui;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoi_Nhan;
        private DevExpress.XtraGrid.Columns.GridColumn colNgay_Gui;
        private DevExpress.XtraGrid.Columns.GridColumn colT_trang;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        public DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        private DevExpress.XtraTab.XtraTabPage xtraTabMo_ta;
        private System.Windows.Forms.WebBrowser Web_Mo_Ta;
        private DevExpress.XtraTab.XtraTabPage XtraTabPageDetail;
        public DevExpress.XtraGrid.GridControl gridControlThongTinLienHe;
        public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewThongTinLienHe;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoi_gui_PH;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoi_nhan_PH;
        private DevExpress.XtraGrid.Columns.GridColumn colTG_Gui_PH;
        private DevExpress.XtraGrid.Columns.GridColumn colNoi_Dung_PH;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colTT_DK;
        private DevExpress.XtraTab.XtraTabPage tabtaptin;
        private DevExpress.XtraGrid.GridControl gridControlTaiLieu;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvTieuDe;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_2;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvFile_dinh_kem;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_3;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lv_anh_default;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn2;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvNoi_dung;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item7;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cot_mofile;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rep_mofile;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_mofile_1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cot_luufile;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rep_luufile;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_luufile_1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cot_xoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rep_xoa;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_xoa_1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cot_suafile;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rep_sua;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_suafile_1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvNguoiCapNhat;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvNgayCapNhat;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvGhi_chu;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_4;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvSize;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_5;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.LayoutControlGroup Group1;
        private DevExpress.XtraLayout.SimpleLabelItem item1;
        private DevExpress.XtraLayout.SimpleLabelItem item2;
        private DevExpress.XtraLayout.SimpleLabelItem item3;
        private DevExpress.XtraLayout.SimpleLabelItem item4;
        private DevExpress.XtraLayout.SimpleLabelItem item5;
        private DevExpress.XtraLayout.SimpleLabelItem item6;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit3;
        private DevExpress.XtraGrid.Views.Grid.PLGridView gridViewTaiLieu;
        private DevExpress.XtraGrid.Columns.GridColumn CotFile;
        private DevExpress.XtraGrid.Columns.GridColumn CotGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn CotTieuDe;
        private DevExpress.XtraGrid.Columns.GridColumn cotID;
        private DevExpress.XtraGrid.Columns.GridColumn cotxoa2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiVanDe;
        private System.Windows.Forms.PLLabel labelControl6;
        private System.Windows.Forms.PLLabel plLabel2;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice cmbNguoiNhan;
        public PLDMTreeGroup NhanVien;
    }
}