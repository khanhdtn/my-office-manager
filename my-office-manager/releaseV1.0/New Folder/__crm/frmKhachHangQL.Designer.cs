using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmKhachHangQL
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
            catch { }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhachHangQL));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
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
            this.barRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.treeListNhomKH = new DevExpress.XtraTreeList.TreeList();
            this.NAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barbuttonCapNhatTienDo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonNhatKyCongViec = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.colTenkhachhang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiachi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.tabCongViec = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlCongviec = new DevExpress.XtraGrid.GridControl();
            this.gridViewCongviec = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.CongViec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotnguoigiao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTienDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotNguoiThucHien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotLoaiCongViec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotbatdau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotngayketthuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTGdutinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotNgayKTTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotDouutien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTinhtrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabDuAn = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlDuAn = new DevExpress.XtraGrid.GridControl();
            this.layoutViewDuAn = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colTen_DA = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colTen_DA = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colLoaiDA = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colLoaiDA = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colNguoi_QL = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colNguoi_QL = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colNgayKTDK = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn2_4 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colNgay_BD_DA = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colNgay_BD_DA = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colNgayKT = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colNgayKT_DA_DuKien = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colT_trang = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colT_trang = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.codT_do_DA = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_codT_do_DA = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewColumn1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_id = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colXemDA = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repImage = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_layoutViewColumn2_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colTaoCV = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repImageTaoCV = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_layoutViewColumn2_2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.item6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem2 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item8 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item9 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item10 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.tabNhatKy = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlNhatKy = new DevExpress.XtraGrid.GridControl();
            this.gridViewNhatKy = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNguoiCapNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTGCapNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabTaiLieu = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlTaiLieu = new DevExpress.XtraGrid.GridControl();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.lvTieuDe = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvFile_dinh_kem = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lv_anh_default = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvNoi_dung = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cot_mofile = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rep_mofile = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_cot_mofile_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cot_luufile = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rep_luufile = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_cot_luufile_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cot_xoa = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rep_xoa = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_cot_xoa = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cot_suafile = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rep_sua = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_cot_suafile = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvNguoiCapNhat = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvNgayCapNhat = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvGhi_chu = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_4 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvSize = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn2_3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.Group1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.item1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item2 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item3 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item4 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item5 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item7 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.repositoryItemButtonEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemButtonEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemMemoExEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.gridViewTaiLieu = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.CotFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTieuDe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotxoa2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListNhomKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).BeginInit();
            this.xtraTabControlDetail.SuspendLayout();
            this.tabCongViec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCongviec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCongviec)).BeginInit();
            this.tabDuAn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDuAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewDuAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colTen_DA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLoaiDA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNguoi_QL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNgay_BD_DA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNgayKT_DA_DuKien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colT_trang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_codT_do_DA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repImageTaoCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item10)).BeginInit();
            this.tabNhatKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNhatKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhatKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            this.tabTaiLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_mofile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_mofile_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_luufile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_luufile_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_xoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_xoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_sua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_suafile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaiLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.barManager1.DockManager = this.dockManager1;
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
            this.barButtonItem5,
            this.barbuttonCapNhatTienDo,
            this.barButtonNhatKyCongViec,
            this.barRefresh});
            this.barManager1.MaxItemId = 42;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemClose, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barRefresh, true)});
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
            // barRefresh
            // 
            this.barRefresh.Caption = "&Refresh";
            this.barRefresh.Glyph = global::ProtocolVN.App.Office.Properties.Resources.MenuBar_Refresh;
            this.barRefresh.Id = 41;
            this.barRefresh.Name = "barRefresh";
            this.barRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barRefresh_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(968, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 539);
            this.barDockControlBottom.Size = new System.Drawing.Size(968, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 513);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(968, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 513);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Appearance.Options.UseTextOptions = true;
            this.dockPanel1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dockPanel1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("87a9fe6a-665f-4650-9de1-d082d488648f");
            this.dockPanel1.Location = new System.Drawing.Point(0, 26);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(221, 200);
            this.dockPanel1.Size = new System.Drawing.Size(221, 513);
            this.dockPanel1.Text = "Nhóm khách hàng";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.treeListNhomKH);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(215, 485);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // treeListNhomKH
            // 
            this.treeListNhomKH.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.NAME,
            this.ID});
            this.treeListNhomKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListNhomKH.Location = new System.Drawing.Point(0, 0);
            this.treeListNhomKH.Name = "treeListNhomKH";
            this.treeListNhomKH.OptionsView.ShowColumns = false;
            this.treeListNhomKH.OptionsView.ShowHorzLines = false;
            this.treeListNhomKH.OptionsView.ShowIndicator = false;
            this.treeListNhomKH.OptionsView.ShowVertLines = false;
            this.treeListNhomKH.RowHeight = 27;
            this.treeListNhomKH.Size = new System.Drawing.Size(215, 485);
            this.treeListNhomKH.StateImageList = this.imageList1;
            this.treeListNhomKH.TabIndex = 17;
            // 
            // NAME
            // 
            this.NAME.AppearanceHeader.Options.UseTextOptions = true;
            this.NAME.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NAME.Caption = "Tên nhóm";
            this.NAME.FieldName = "NAME";
            this.NAME.MinWidth = 63;
            this.NAME.Name = "NAME";
            this.NAME.OptionsColumn.AllowEdit = false;
            this.NAME.OptionsColumn.AllowFocus = false;
            this.NAME.OptionsColumn.ReadOnly = true;
            this.NAME.Visible = true;
            this.NAME.VisibleIndex = 0;
            // 
            // ID
            // 
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "NhomKhachHang.png");
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
            // barbuttonCapNhatTienDo
            // 
            this.barbuttonCapNhatTienDo.Caption = "&Cập nhật tiến độ";
            this.barbuttonCapNhatTienDo.Id = 39;
            this.barbuttonCapNhatTienDo.Name = "barbuttonCapNhatTienDo";
            // 
            // barButtonNhatKyCongViec
            // 
            this.barButtonNhatKyCongViec.Caption = "&Nhật ký công việc";
            this.barButtonNhatKyCongViec.Id = 40;
            this.barButtonNhatKyCongViec.Name = "barButtonNhatKyCongViec";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(221, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlMaster);
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlDetail);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(747, 513);
            this.splitContainerControl1.SplitterPosition = 287;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControlMaster
            // 
            this.gridControlMaster.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlMaster.BackgroundImage")));
            this.gridControlMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControlMaster.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControlMaster.Location = new System.Drawing.Point(0, 0);
            this.gridControlMaster.MainView = this.gridViewMaster;
            this.gridControlMaster.Name = "gridControlMaster";
            this.gridControlMaster.Size = new System.Drawing.Size(747, 220);
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
            this.colTenkhachhang,
            this.colDiachi,
            this.colDienThoai,
            this.colFax,
            this.colEmail});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupPanelText = "DANH SÁCH KHÁCH HÀNG";
            this.gridViewMaster.IndicatorWidth = 40;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewMaster.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewMaster.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewMaster.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewMaster.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewMaster.OptionsPrint.UsePrintStyles = true;
            this.gridViewMaster.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridViewMaster.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMaster.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewMaster.OptionsView.RowAutoHeight = true;
            this.gridViewMaster.OptionsView.ShowFooter = true;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = true;
            // 
            // colTenkhachhang
            // 
            this.colTenkhachhang.AppearanceCell.Options.UseTextOptions = true;
            this.colTenkhachhang.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTenkhachhang.Caption = "Khách hàng";
            this.colTenkhachhang.Name = "colTenkhachhang";
            this.colTenkhachhang.OptionsColumn.AllowEdit = false;
            this.colTenkhachhang.Visible = true;
            this.colTenkhachhang.VisibleIndex = 0;
            this.colTenkhachhang.Width = 68;
            // 
            // colDiachi
            // 
            this.colDiachi.Caption = "Địa chỉ";
            this.colDiachi.Name = "colDiachi";
            this.colDiachi.Visible = true;
            this.colDiachi.VisibleIndex = 1;
            this.colDiachi.Width = 44;
            // 
            // colDienThoai
            // 
            this.colDienThoai.Caption = "Điện thoại";
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.Visible = true;
            this.colDienThoai.VisibleIndex = 2;
            this.colDienThoai.Width = 61;
            // 
            // colFax
            // 
            this.colFax.Caption = "Fax";
            this.colFax.Name = "colFax";
            this.colFax.Visible = true;
            this.colFax.VisibleIndex = 3;
            this.colFax.Width = 30;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 4;
            this.colEmail.Width = 36;
            // 
            // xtraTabControlDetail
            // 
            this.xtraTabControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlDetail.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlDetail.Name = "xtraTabControlDetail";
            this.xtraTabControlDetail.SelectedTabPage = this.tabCongViec;
            this.xtraTabControlDetail.Size = new System.Drawing.Size(747, 287);
            this.xtraTabControlDetail.TabIndex = 0;
            this.xtraTabControlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabCongViec,
            this.tabDuAn,
            this.tabNhatKy,
            this.tabTaiLieu});
            this.xtraTabControlDetail.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControlDetail_SelectedPageChanged);
            // 
            // tabCongViec
            // 
            this.tabCongViec.Controls.Add(this.gridControlCongviec);
            this.tabCongViec.Name = "tabCongViec";
            this.tabCongViec.Size = new System.Drawing.Size(740, 258);
            this.tabCongViec.Text = "Danh sách công việc";
            // 
            // gridControlCongviec
            // 
            this.gridControlCongviec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlCongviec.BackgroundImage")));
            this.gridControlCongviec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlCongviec.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode2.RelationName = "Level1";
            this.gridControlCongviec.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridControlCongviec.Location = new System.Drawing.Point(0, 0);
            this.gridControlCongviec.MainView = this.gridViewCongviec;
            this.gridControlCongviec.Name = "gridControlCongviec";
            this.gridControlCongviec.Size = new System.Drawing.Size(740, 258);
            this.gridControlCongviec.TabIndex = 3;
            this.gridControlCongviec.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCongviec});
            // 
            // gridViewCongviec
            // 
            this.gridViewCongviec.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewCongviec.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridViewCongviec.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewCongviec.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewCongviec.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CongViec,
            this.Cotnguoigiao,
            this.CotTienDo,
            this.CotNguoiThucHien,
            this.CotLoaiCongViec,
            this.Cotbatdau,
            this.Cotngayketthuc,
            this.CotTGdutinh,
            this.cotNgayKTTT,
            this.CotDouutien,
            this.CotTinhtrang});
            this.gridViewCongviec.GridControl = this.gridControlCongviec;
            this.gridViewCongviec.GroupPanelText = "Danh sách ";
            this.gridViewCongviec.IndicatorWidth = 40;
            this.gridViewCongviec.Name = "gridViewCongviec";
            this.gridViewCongviec.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCongviec.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCongviec.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewCongviec.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewCongviec.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewCongviec.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewCongviec.OptionsPrint.UsePrintStyles = true;
            this.gridViewCongviec.OptionsSelection.MultiSelect = true;
            this.gridViewCongviec.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridViewCongviec.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewCongviec.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewCongviec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewCongviec.OptionsView.RowAutoHeight = true;
            this.gridViewCongviec.OptionsView.ShowGroupedColumns = true;
            this.gridViewCongviec.OptionsView.ShowGroupPanel = false;
            this.gridViewCongviec.DoubleClick += new System.EventHandler(this.gridViewCongviec_DoubleClick);
            // 
            // CongViec
            // 
            this.CongViec.AppearanceCell.Options.UseTextOptions = true;
            this.CongViec.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CongViec.Caption = "Công việc";
            this.CongViec.Name = "CongViec";
            this.CongViec.OptionsColumn.AllowEdit = false;
            this.CongViec.OptionsColumn.AllowFocus = false;
            this.CongViec.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.CongViec.OptionsColumn.ReadOnly = true;
            this.CongViec.Visible = true;
            this.CongViec.VisibleIndex = 0;
            this.CongViec.Width = 59;
            // 
            // Cotnguoigiao
            // 
            this.Cotnguoigiao.AppearanceCell.Options.UseTextOptions = true;
            this.Cotnguoigiao.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Cotnguoigiao.AppearanceHeader.Options.UseTextOptions = true;
            this.Cotnguoigiao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cotnguoigiao.Caption = "Người giao";
            this.Cotnguoigiao.Name = "Cotnguoigiao";
            this.Cotnguoigiao.OptionsColumn.AllowEdit = false;
            this.Cotnguoigiao.OptionsColumn.AllowFocus = false;
            this.Cotnguoigiao.OptionsColumn.ReadOnly = true;
            this.Cotnguoigiao.Width = 63;
            // 
            // CotTienDo
            // 
            this.CotTienDo.AppearanceCell.Options.UseTextOptions = true;
            this.CotTienDo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CotTienDo.Caption = "Tiến độ";
            this.CotTienDo.Name = "CotTienDo";
            this.CotTienDo.OptionsColumn.AllowEdit = false;
            this.CotTienDo.OptionsColumn.AllowFocus = false;
            this.CotTienDo.OptionsColumn.ReadOnly = true;
            this.CotTienDo.Visible = true;
            this.CotTienDo.VisibleIndex = 2;
            this.CotTienDo.Width = 47;
            // 
            // CotNguoiThucHien
            // 
            this.CotNguoiThucHien.Caption = "Người thực hiện";
            this.CotNguoiThucHien.Name = "CotNguoiThucHien";
            this.CotNguoiThucHien.OptionsColumn.AllowEdit = false;
            this.CotNguoiThucHien.OptionsColumn.AllowFocus = false;
            this.CotNguoiThucHien.OptionsColumn.ReadOnly = true;
            this.CotNguoiThucHien.Visible = true;
            this.CotNguoiThucHien.VisibleIndex = 1;
            this.CotNguoiThucHien.Width = 88;
            // 
            // CotLoaiCongViec
            // 
            this.CotLoaiCongViec.AppearanceCell.Options.UseTextOptions = true;
            this.CotLoaiCongViec.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CotLoaiCongViec.Caption = "Loại công việc";
            this.CotLoaiCongViec.Name = "CotLoaiCongViec";
            this.CotLoaiCongViec.OptionsColumn.AllowEdit = false;
            this.CotLoaiCongViec.OptionsColumn.AllowFocus = false;
            this.CotLoaiCongViec.OptionsColumn.ReadOnly = true;
            this.CotLoaiCongViec.Width = 79;
            // 
            // Cotbatdau
            // 
            this.Cotbatdau.AppearanceCell.Options.UseTextOptions = true;
            this.Cotbatdau.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Cotbatdau.AppearanceHeader.Options.UseTextOptions = true;
            this.Cotbatdau.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cotbatdau.Caption = "Ngày bắt đầu";
            this.Cotbatdau.Name = "Cotbatdau";
            this.Cotbatdau.OptionsColumn.AllowEdit = false;
            this.Cotbatdau.OptionsColumn.AllowFocus = false;
            this.Cotbatdau.OptionsColumn.ReadOnly = true;
            this.Cotbatdau.Visible = true;
            this.Cotbatdau.VisibleIndex = 3;
            this.Cotbatdau.Width = 77;
            // 
            // Cotngayketthuc
            // 
            this.Cotngayketthuc.AppearanceCell.Options.UseTextOptions = true;
            this.Cotngayketthuc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Cotngayketthuc.AppearanceHeader.Options.UseTextOptions = true;
            this.Cotngayketthuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cotngayketthuc.Caption = "Ngày kết thúc dự kiến";
            this.Cotngayketthuc.Name = "Cotngayketthuc";
            this.Cotngayketthuc.OptionsColumn.AllowEdit = false;
            this.Cotngayketthuc.OptionsColumn.AllowFocus = false;
            this.Cotngayketthuc.OptionsColumn.ReadOnly = true;
            this.Cotngayketthuc.Width = 117;
            // 
            // CotTGdutinh
            // 
            this.CotTGdutinh.AppearanceCell.Options.UseTextOptions = true;
            this.CotTGdutinh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CotTGdutinh.Caption = "Thời gian dự kiến";
            this.CotTGdutinh.Name = "CotTGdutinh";
            this.CotTGdutinh.OptionsColumn.AllowEdit = false;
            this.CotTGdutinh.OptionsColumn.AllowFocus = false;
            this.CotTGdutinh.OptionsColumn.ReadOnly = true;
            this.CotTGdutinh.Visible = true;
            this.CotTGdutinh.VisibleIndex = 4;
            this.CotTGdutinh.Width = 93;
            // 
            // cotNgayKTTT
            // 
            this.cotNgayKTTT.Caption = "Ngày kết thúc thực tế";
            this.cotNgayKTTT.Name = "cotNgayKTTT";
            this.cotNgayKTTT.OptionsColumn.AllowEdit = false;
            this.cotNgayKTTT.OptionsColumn.AllowFocus = false;
            this.cotNgayKTTT.OptionsColumn.ReadOnly = true;
            this.cotNgayKTTT.Visible = true;
            this.cotNgayKTTT.VisibleIndex = 5;
            this.cotNgayKTTT.Width = 117;
            // 
            // CotDouutien
            // 
            this.CotDouutien.AppearanceCell.Options.UseTextOptions = true;
            this.CotDouutien.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CotDouutien.Caption = "Độ ưu tiên";
            this.CotDouutien.Name = "CotDouutien";
            this.CotDouutien.OptionsColumn.AllowEdit = false;
            this.CotDouutien.OptionsColumn.AllowFocus = false;
            this.CotDouutien.OptionsColumn.ReadOnly = true;
            this.CotDouutien.Visible = true;
            this.CotDouutien.VisibleIndex = 6;
            this.CotDouutien.Width = 63;
            // 
            // CotTinhtrang
            // 
            this.CotTinhtrang.AppearanceCell.Options.UseTextOptions = true;
            this.CotTinhtrang.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CotTinhtrang.Caption = "Tình trạng";
            this.CotTinhtrang.Name = "CotTinhtrang";
            this.CotTinhtrang.OptionsColumn.AllowEdit = false;
            this.CotTinhtrang.OptionsColumn.AllowFocus = false;
            this.CotTinhtrang.OptionsColumn.ReadOnly = true;
            this.CotTinhtrang.Visible = true;
            this.CotTinhtrang.VisibleIndex = 7;
            this.CotTinhtrang.Width = 61;
            // 
            // tabDuAn
            // 
            this.tabDuAn.Controls.Add(this.gridControlDuAn);
            this.tabDuAn.Name = "tabDuAn";
            this.tabDuAn.Size = new System.Drawing.Size(740, 258);
            this.tabDuAn.Text = "Danh sách dự án";
            // 
            // gridControlDuAn
            // 
            this.gridControlDuAn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlDuAn.BackgroundImage")));
            this.gridControlDuAn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlDuAn.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode3.RelationName = "Level1";
            this.gridControlDuAn.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode3});
            this.gridControlDuAn.Location = new System.Drawing.Point(0, 0);
            this.gridControlDuAn.MainView = this.layoutViewDuAn;
            this.gridControlDuAn.Name = "gridControlDuAn";
            this.gridControlDuAn.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repImage,
            this.repImageTaoCV});
            this.gridControlDuAn.Size = new System.Drawing.Size(740, 258);
            this.gridControlDuAn.TabIndex = 2;
            this.gridControlDuAn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutViewDuAn});
            // 
            // layoutViewDuAn
            // 
            this.layoutViewDuAn.ActiveFilterEnabled = false;
            this.layoutViewDuAn.Appearance.CardCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutViewDuAn.Appearance.CardCaption.Options.UseFont = true;
            this.layoutViewDuAn.CardCaptionFormat = "{2}";
            this.layoutViewDuAn.CardHorzInterval = 25;
            this.layoutViewDuAn.CardMinSize = new System.Drawing.Size(200, 196);
            this.layoutViewDuAn.CardVertInterval = 7;
            this.layoutViewDuAn.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colTen_DA,
            this.colLoaiDA,
            this.colNguoi_QL,
            this.colNgayKTDK,
            this.colNgay_BD_DA,
            this.colNgayKT,
            this.colT_trang,
            this.codT_do_DA,
            this.layoutViewColumn1,
            this.colXemDA,
            this.colTaoCV});
            this.layoutViewDuAn.GridControl = this.gridControlDuAn;
            this.layoutViewDuAn.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_id,
            this.layoutViewField_colTen_DA,
            this.layoutViewField_colLoaiDA,
            this.layoutViewField_layoutViewColumn2_4});
            this.layoutViewDuAn.Name = "layoutViewDuAn";
            this.layoutViewDuAn.OptionsItemText.AlignMode = DevExpress.XtraGrid.Views.Layout.FieldTextAlignMode.AutoSize;
            this.layoutViewDuAn.OptionsItemText.TextToControlDistance = 4;
            this.layoutViewDuAn.OptionsLayout.Columns.AddNewColumns = false;
            this.layoutViewDuAn.OptionsView.CardsAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near;
            this.layoutViewDuAn.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
            this.layoutViewDuAn.SynchronizeClones = false;
            this.layoutViewDuAn.TemplateCard = this.layoutViewCard2;
            // 
            // colTen_DA
            // 
            this.colTen_DA.Caption = "Tên dự án";
            this.colTen_DA.LayoutViewField = this.layoutViewField_colTen_DA;
            this.colTen_DA.Name = "colTen_DA";
            this.colTen_DA.OptionsColumn.AllowEdit = false;
            this.colTen_DA.OptionsColumn.AllowFocus = false;
            this.colTen_DA.Width = 61;
            // 
            // layoutViewField_colTen_DA
            // 
            this.layoutViewField_colTen_DA.EditorPreferredWidth = 20;
            this.layoutViewField_colTen_DA.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colTen_DA.Name = "layoutViewField_colTen_DA";
            this.layoutViewField_colTen_DA.Size = new System.Drawing.Size(194, 190);
            this.layoutViewField_colTen_DA.TextSize = new System.Drawing.Size(109, 13);
            this.layoutViewField_colTen_DA.TextToControlDistance = 5;
            // 
            // colLoaiDA
            // 
            this.colLoaiDA.Caption = "Loại dự án";
            this.colLoaiDA.LayoutViewField = this.layoutViewField_colLoaiDA;
            this.colLoaiDA.Name = "colLoaiDA";
            this.colLoaiDA.OptionsColumn.AllowEdit = false;
            this.colLoaiDA.OptionsColumn.AllowFocus = false;
            // 
            // layoutViewField_colLoaiDA
            // 
            this.layoutViewField_colLoaiDA.EditorPreferredWidth = 20;
            this.layoutViewField_colLoaiDA.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colLoaiDA.Name = "layoutViewField_colLoaiDA";
            this.layoutViewField_colLoaiDA.Size = new System.Drawing.Size(194, 190);
            this.layoutViewField_colLoaiDA.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutViewField_colLoaiDA.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_colLoaiDA.TextToControlDistance = 0;
            this.layoutViewField_colLoaiDA.TextVisible = false;
            // 
            // colNguoi_QL
            // 
            this.colNguoi_QL.Caption = "Người quản lý";
            this.colNguoi_QL.LayoutViewField = this.layoutViewField_colNguoi_QL;
            this.colNguoi_QL.Name = "colNguoi_QL";
            this.colNguoi_QL.OptionsColumn.AllowEdit = false;
            this.colNguoi_QL.OptionsColumn.AllowFocus = false;
            this.colNguoi_QL.Width = 78;
            // 
            // layoutViewField_colNguoi_QL
            // 
            this.layoutViewField_colNguoi_QL.EditorPreferredWidth = 112;
            this.layoutViewField_colNguoi_QL.Location = new System.Drawing.Point(78, 0);
            this.layoutViewField_colNguoi_QL.Name = "layoutViewField_colNguoi_QL";
            this.layoutViewField_colNguoi_QL.Size = new System.Drawing.Size(116, 20);
            this.layoutViewField_colNguoi_QL.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutViewField_colNguoi_QL.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_colNguoi_QL.TextToControlDistance = 0;
            this.layoutViewField_colNguoi_QL.TextVisible = false;
            // 
            // colNgayKTDK
            // 
            this.colNgayKTDK.LayoutViewField = this.layoutViewField_layoutViewColumn2_4;
            this.colNgayKTDK.Name = "colNgayKTDK";
            // 
            // layoutViewField_layoutViewColumn2_4
            // 
            this.layoutViewField_layoutViewColumn2_4.EditorPreferredWidth = 10;
            this.layoutViewField_layoutViewColumn2_4.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn2_4.Name = "layoutViewField_layoutViewColumn2_4";
            this.layoutViewField_layoutViewColumn2_4.Size = new System.Drawing.Size(194, 190);
            this.layoutViewField_layoutViewColumn2_4.TextSize = new System.Drawing.Size(0, 13);
            this.layoutViewField_layoutViewColumn2_4.TextToControlDistance = 4;
            // 
            // colNgay_BD_DA
            // 
            this.colNgay_BD_DA.Caption = "Ngày bắt đầu";
            this.colNgay_BD_DA.LayoutViewField = this.layoutViewField_colNgay_BD_DA;
            this.colNgay_BD_DA.Name = "colNgay_BD_DA";
            this.colNgay_BD_DA.OptionsColumn.AllowEdit = false;
            this.colNgay_BD_DA.OptionsColumn.AllowFocus = false;
            this.colNgay_BD_DA.Width = 77;
            // 
            // layoutViewField_colNgay_BD_DA
            // 
            this.layoutViewField_colNgay_BD_DA.EditorPreferredWidth = 112;
            this.layoutViewField_colNgay_BD_DA.Location = new System.Drawing.Point(78, 20);
            this.layoutViewField_colNgay_BD_DA.Name = "layoutViewField_colNgay_BD_DA";
            this.layoutViewField_colNgay_BD_DA.Size = new System.Drawing.Size(116, 20);
            this.layoutViewField_colNgay_BD_DA.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutViewField_colNgay_BD_DA.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_colNgay_BD_DA.TextToControlDistance = 0;
            this.layoutViewField_colNgay_BD_DA.TextVisible = false;
            // 
            // colNgayKT
            // 
            this.colNgayKT.Caption = "Ngày kết thúc";
            this.colNgayKT.LayoutViewField = this.layoutViewField_colNgayKT_DA_DuKien;
            this.colNgayKT.Name = "colNgayKT";
            this.colNgayKT.OptionsColumn.AllowEdit = false;
            this.colNgayKT.OptionsColumn.AllowFocus = false;
            this.colNgayKT.Width = 117;
            // 
            // layoutViewField_colNgayKT_DA_DuKien
            // 
            this.layoutViewField_colNgayKT_DA_DuKien.EditorPreferredWidth = 112;
            this.layoutViewField_colNgayKT_DA_DuKien.Location = new System.Drawing.Point(78, 40);
            this.layoutViewField_colNgayKT_DA_DuKien.Name = "layoutViewField_colNgayKT_DA_DuKien";
            this.layoutViewField_colNgayKT_DA_DuKien.Size = new System.Drawing.Size(116, 20);
            this.layoutViewField_colNgayKT_DA_DuKien.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutViewField_colNgayKT_DA_DuKien.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_colNgayKT_DA_DuKien.TextToControlDistance = 0;
            this.layoutViewField_colNgayKT_DA_DuKien.TextVisible = false;
            // 
            // colT_trang
            // 
            this.colT_trang.Caption = "Tình trạng";
            this.colT_trang.LayoutViewField = this.layoutViewField_colT_trang;
            this.colT_trang.Name = "colT_trang";
            this.colT_trang.OptionsColumn.AllowEdit = false;
            this.colT_trang.OptionsColumn.AllowFocus = false;
            this.colT_trang.Width = 61;
            // 
            // layoutViewField_colT_trang
            // 
            this.layoutViewField_colT_trang.EditorPreferredWidth = 112;
            this.layoutViewField_colT_trang.Location = new System.Drawing.Point(78, 60);
            this.layoutViewField_colT_trang.Name = "layoutViewField_colT_trang";
            this.layoutViewField_colT_trang.Size = new System.Drawing.Size(116, 20);
            this.layoutViewField_colT_trang.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutViewField_colT_trang.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_colT_trang.TextToControlDistance = 0;
            this.layoutViewField_colT_trang.TextVisible = false;
            // 
            // codT_do_DA
            // 
            this.codT_do_DA.Caption = "Tiến độ";
            this.codT_do_DA.LayoutViewField = this.layoutViewField_codT_do_DA;
            this.codT_do_DA.Name = "codT_do_DA";
            this.codT_do_DA.OptionsColumn.AllowEdit = false;
            this.codT_do_DA.OptionsColumn.AllowFocus = false;
            this.codT_do_DA.Width = 47;
            // 
            // layoutViewField_codT_do_DA
            // 
            this.layoutViewField_codT_do_DA.EditorPreferredWidth = 112;
            this.layoutViewField_codT_do_DA.Location = new System.Drawing.Point(78, 80);
            this.layoutViewField_codT_do_DA.Name = "layoutViewField_codT_do_DA";
            this.layoutViewField_codT_do_DA.Size = new System.Drawing.Size(116, 20);
            this.layoutViewField_codT_do_DA.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutViewField_codT_do_DA.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_codT_do_DA.TextToControlDistance = 0;
            this.layoutViewField_codT_do_DA.TextVisible = false;
            // 
            // layoutViewColumn1
            // 
            this.layoutViewColumn1.Caption = "gridColumn1";
            this.layoutViewColumn1.LayoutViewField = this.layoutViewField_id;
            this.layoutViewColumn1.Name = "layoutViewColumn1";
            this.layoutViewColumn1.OptionsColumn.AllowEdit = false;
            this.layoutViewColumn1.OptionsColumn.AllowFocus = false;
            this.layoutViewColumn1.OptionsColumn.AllowIncrementalSearch = false;
            this.layoutViewColumn1.OptionsColumn.AllowMove = false;
            this.layoutViewColumn1.OptionsColumn.ShowCaption = false;
            this.layoutViewColumn1.Width = 71;
            // 
            // layoutViewField_id
            // 
            this.layoutViewField_id.EditorPreferredWidth = 20;
            this.layoutViewField_id.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_id.Name = "layoutViewField_id";
            this.layoutViewField_id.Size = new System.Drawing.Size(194, 190);
            this.layoutViewField_id.TextSize = new System.Drawing.Size(109, 13);
            this.layoutViewField_id.TextToControlDistance = 5;
            // 
            // colXemDA
            // 
            this.colXemDA.ColumnEdit = this.repImage;
            this.colXemDA.LayoutViewField = this.layoutViewField_layoutViewColumn2_1;
            this.colXemDA.Name = "colXemDA";
            // 
            // repImage
            // 
            this.repImage.Name = "repImage";
            this.repImage.Click += new System.EventHandler(this.repImage_Click);
            // 
            // layoutViewField_layoutViewColumn2_1
            // 
            this.layoutViewField_layoutViewColumn2_1.EditorPreferredWidth = 30;
            this.layoutViewField_layoutViewColumn2_1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn2_1.MaxSize = new System.Drawing.Size(34, 26);
            this.layoutViewField_layoutViewColumn2_1.MinSize = new System.Drawing.Size(34, 26);
            this.layoutViewField_layoutViewColumn2_1.Name = "layoutViewField_layoutViewColumn2_1";
            this.layoutViewField_layoutViewColumn2_1.Size = new System.Drawing.Size(34, 26);
            this.layoutViewField_layoutViewColumn2_1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_layoutViewColumn2_1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_layoutViewColumn2_1.TextToControlDistance = 0;
            this.layoutViewField_layoutViewColumn2_1.TextVisible = false;
            // 
            // colTaoCV
            // 
            this.colTaoCV.ColumnEdit = this.repImageTaoCV;
            this.colTaoCV.LayoutViewField = this.layoutViewField_layoutViewColumn2_2;
            this.colTaoCV.Name = "colTaoCV";
            // 
            // repImageTaoCV
            // 
            this.repImageTaoCV.Name = "repImageTaoCV";
            this.repImageTaoCV.Click += new System.EventHandler(this.repImageTaoCV_Click);
            // 
            // layoutViewField_layoutViewColumn2_2
            // 
            this.layoutViewField_layoutViewColumn2_2.EditorPreferredWidth = 30;
            this.layoutViewField_layoutViewColumn2_2.Location = new System.Drawing.Point(34, 0);
            this.layoutViewField_layoutViewColumn2_2.MaxSize = new System.Drawing.Size(34, 26);
            this.layoutViewField_layoutViewColumn2_2.MinSize = new System.Drawing.Size(34, 26);
            this.layoutViewField_layoutViewColumn2_2.Name = "layoutViewField_layoutViewColumn2_2";
            this.layoutViewField_layoutViewColumn2_2.Size = new System.Drawing.Size(34, 26);
            this.layoutViewField_layoutViewColumn2_2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_layoutViewColumn2_2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_layoutViewColumn2_2.TextToControlDistance = 0;
            this.layoutViewField_layoutViewColumn2_2.TextVisible = false;
            // 
            // layoutViewCard2
            // 
            this.layoutViewCard2.CustomizationFormText = "TemplateCard";
            this.layoutViewCard2.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colNguoi_QL,
            this.layoutViewField_colNgay_BD_DA,
            this.layoutViewField_colNgayKT_DA_DuKien,
            this.layoutViewField_colT_trang,
            this.layoutViewField_codT_do_DA,
            this.item6,
            this.simpleLabelItem1,
            this.simpleLabelItem2,
            this.item8,
            this.item9,
            this.item10});
            this.layoutViewCard2.Name = "layoutViewCard2";
            this.layoutViewCard2.OptionsItemText.TextToControlDistance = 4;
            this.layoutViewCard2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewCard2.Text = "TemplateCard";
            // 
            // item6
            // 
            this.item6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item6.AppearanceItemCaption.Options.UseFont = true;
            this.item6.CustomizationFormText = "Thao tác";
            this.item6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn2_1,
            this.layoutViewField_layoutViewColumn2_2,
            this.emptySpaceItem1});
            this.item6.Location = new System.Drawing.Point(0, 100);
            this.item6.Name = "item6";
            this.item6.Size = new System.Drawing.Size(194, 70);
            this.item6.Text = "Thao tác";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "item7";
            this.emptySpaceItem1.Location = new System.Drawing.Point(68, 0);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(102, 26);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(101, 26);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(102, 26);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            this.emptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.simpleLabelItem1.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem1.CustomizationFormText = "Người quản lý: ";
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(78, 20);
            this.simpleLabelItem1.Text = "Người quản lý: ";
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(73, 13);
            // 
            // simpleLabelItem2
            // 
            this.simpleLabelItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.simpleLabelItem2.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem2.CustomizationFormText = "Ngày bắt đầu: ";
            this.simpleLabelItem2.Location = new System.Drawing.Point(0, 20);
            this.simpleLabelItem2.Name = "simpleLabelItem2";
            this.simpleLabelItem2.Size = new System.Drawing.Size(78, 20);
            this.simpleLabelItem2.Text = "Ngày bắt đầu: ";
            this.simpleLabelItem2.TextSize = new System.Drawing.Size(72, 13);
            // 
            // item8
            // 
            this.item8.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item8.AppearanceItemCaption.Options.UseFont = true;
            this.item8.CustomizationFormText = "Ngày kết thúc: ";
            this.item8.Location = new System.Drawing.Point(0, 40);
            this.item8.Name = "item8";
            this.item8.Size = new System.Drawing.Size(78, 20);
            this.item8.Text = "Ngày kết thúc: ";
            this.item8.TextSize = new System.Drawing.Size(74, 13);
            // 
            // item9
            // 
            this.item9.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item9.AppearanceItemCaption.Options.UseFont = true;
            this.item9.CustomizationFormText = "Tình trạng: ";
            this.item9.Location = new System.Drawing.Point(0, 60);
            this.item9.Name = "item9";
            this.item9.Size = new System.Drawing.Size(78, 20);
            this.item9.Text = "Tình trạng: ";
            this.item9.TextSize = new System.Drawing.Size(56, 13);
            // 
            // item10
            // 
            this.item10.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item10.AppearanceItemCaption.Options.UseFont = true;
            this.item10.CustomizationFormText = "Tiến độ: ";
            this.item10.Location = new System.Drawing.Point(0, 80);
            this.item10.Name = "item10";
            this.item10.Size = new System.Drawing.Size(78, 20);
            this.item10.Text = "Tiến độ: ";
            this.item10.TextSize = new System.Drawing.Size(42, 13);
            // 
            // tabNhatKy
            // 
            this.tabNhatKy.Controls.Add(this.gridControlNhatKy);
            this.tabNhatKy.Name = "tabNhatKy";
            this.tabNhatKy.Size = new System.Drawing.Size(740, 258);
            this.tabNhatKy.Text = "Danh sách nhật ký";
            // 
            // gridControlNhatKy
            // 
            this.gridControlNhatKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlNhatKy.Location = new System.Drawing.Point(0, 0);
            this.gridControlNhatKy.MainView = this.gridViewNhatKy;
            this.gridControlNhatKy.Name = "gridControlNhatKy";
            this.gridControlNhatKy.Size = new System.Drawing.Size(740, 258);
            this.gridControlNhatKy.TabIndex = 4;
            this.gridControlNhatKy.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNhatKy,
            this.gridView5});
            // 
            // gridViewNhatKy
            // 
            this.gridViewNhatKy.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNguoiCapNhat,
            this.colTGCapNhat,
            this.colNoiDung});
            this.gridViewNhatKy.GridControl = this.gridControlNhatKy;
            this.gridViewNhatKy.Name = "gridViewNhatKy";
            this.gridViewNhatKy.OptionsBehavior.Editable = false;
            this.gridViewNhatKy.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewNhatKy.OptionsView.ShowGroupPanel = false;
            // 
            // colNguoiCapNhat
            // 
            this.colNguoiCapNhat.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiCapNhat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiCapNhat.Caption = "Người cập nhật";
            this.colNguoiCapNhat.Name = "colNguoiCapNhat";
            this.colNguoiCapNhat.OptionsColumn.AllowEdit = false;
            this.colNguoiCapNhat.OptionsColumn.ReadOnly = true;
            this.colNguoiCapNhat.Visible = true;
            this.colNguoiCapNhat.VisibleIndex = 0;
            this.colNguoiCapNhat.Width = 145;
            // 
            // colTGCapNhat
            // 
            this.colTGCapNhat.AppearanceCell.Options.UseTextOptions = true;
            this.colTGCapNhat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTGCapNhat.AppearanceHeader.Options.UseTextOptions = true;
            this.colTGCapNhat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTGCapNhat.Caption = "Thời gian cập nhật";
            this.colTGCapNhat.Name = "colTGCapNhat";
            this.colTGCapNhat.Visible = true;
            this.colTGCapNhat.VisibleIndex = 1;
            this.colTGCapNhat.Width = 132;
            // 
            // colNoiDung
            // 
            this.colNoiDung.AppearanceHeader.Options.UseTextOptions = true;
            this.colNoiDung.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNoiDung.Caption = "Nội dung";
            this.colNoiDung.Name = "colNoiDung";
            this.colNoiDung.OptionsColumn.AllowEdit = false;
            this.colNoiDung.OptionsColumn.ReadOnly = true;
            this.colNoiDung.Visible = true;
            this.colNoiDung.VisibleIndex = 2;
            this.colNoiDung.Width = 228;
            // 
            // gridView5
            // 
            this.gridView5.GridControl = this.gridControlNhatKy;
            this.gridView5.Name = "gridView5";
            // 
            // tabTaiLieu
            // 
            this.tabTaiLieu.Controls.Add(this.gridControlTaiLieu);
            this.tabTaiLieu.Name = "tabTaiLieu";
            this.tabTaiLieu.Size = new System.Drawing.Size(740, 258);
            this.tabTaiLieu.Text = "Danh sách tài liệu";
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
            this.repositoryItemPictureEdit1,
            this.repositoryItemButtonEdit4,
            this.repositoryItemButtonEdit5,
            this.repositoryItemMemoExEdit1,
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoExEdit2,
            this.rep_mofile,
            this.rep_luufile,
            this.rep_xoa,
            this.rep_sua});
            this.gridControlTaiLieu.Size = new System.Drawing.Size(740, 258);
            this.gridControlTaiLieu.TabIndex = 191;
            this.gridControlTaiLieu.Tag = "";
            this.gridControlTaiLieu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1,
            this.gridViewTaiLieu});
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
            this.layoutViewField1,
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
            this.lvNoi_dung.LayoutViewField = this.layoutViewField1;
            this.lvNoi_dung.Name = "lvNoi_dung";
            this.lvNoi_dung.OptionsColumn.AllowEdit = false;
            this.lvNoi_dung.OptionsColumn.AllowFocus = false;
            // 
            // layoutViewField1
            // 
            this.layoutViewField1.EditorPreferredWidth = 20;
            this.layoutViewField1.Image = ((System.Drawing.Image)(resources.GetObject("layoutViewField1.Image")));
            this.layoutViewField1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutViewField1.ImageIndex = 1;
            this.layoutViewField1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField1.MaxSize = new System.Drawing.Size(60, 52);
            this.layoutViewField1.MinSize = new System.Drawing.Size(60, 52);
            this.layoutViewField1.Name = "layoutViewField1";
            this.layoutViewField1.Size = new System.Drawing.Size(194, 170);
            this.layoutViewField1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField1.TextToControlDistance = 0;
            this.layoutViewField1.TextVisible = false;
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
            this.rep_luufile.Click += new System.EventHandler(this.rep_luufile_Click);
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
            this.cot_xoa.LayoutViewField = this.layoutViewField_cot_xoa;
            this.cot_xoa.Name = "cot_xoa";
            // 
            // rep_xoa
            // 
            this.rep_xoa.Name = "rep_xoa";
            // 
            // layoutViewField_cot_xoa
            // 
            this.layoutViewField_cot_xoa.EditorPreferredWidth = 200;
            this.layoutViewField_cot_xoa.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_cot_xoa.MaxSize = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_xoa.MinSize = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_xoa.Name = "layoutViewField_cot_xoa";
            this.layoutViewField_cot_xoa.Size = new System.Drawing.Size(194, 170);
            this.layoutViewField_cot_xoa.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_cot_xoa.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_cot_xoa.TextToControlDistance = 0;
            this.layoutViewField_cot_xoa.TextVisible = false;
            // 
            // cot_suafile
            // 
            this.cot_suafile.Caption = "Sửa File";
            this.cot_suafile.ColumnEdit = this.rep_sua;
            this.cot_suafile.LayoutViewField = this.layoutViewField_cot_suafile;
            this.cot_suafile.Name = "cot_suafile";
            // 
            // rep_sua
            // 
            this.rep_sua.Name = "rep_sua";
            // 
            // layoutViewField_cot_suafile
            // 
            this.layoutViewField_cot_suafile.EditorPreferredWidth = 200;
            this.layoutViewField_cot_suafile.Location = new System.Drawing.Point(0, 170);
            this.layoutViewField_cot_suafile.MaxSize = new System.Drawing.Size(29, 26);
            this.layoutViewField_cot_suafile.MinSize = new System.Drawing.Size(29, 26);
            this.layoutViewField_cot_suafile.Name = "layoutViewField_cot_suafile";
            this.layoutViewField_cot_suafile.Size = new System.Drawing.Size(194, 25);
            this.layoutViewField_cot_suafile.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_cot_suafile.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_cot_suafile.TextToControlDistance = 0;
            this.layoutViewField_cot_suafile.TextVisible = false;
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
            this.lvSize.LayoutViewField = this.layoutViewField_layoutViewColumn2_3;
            this.lvSize.Name = "lvSize";
            this.lvSize.OptionsColumn.AllowEdit = false;
            this.lvSize.OptionsColumn.AllowFocus = false;
            // 
            // layoutViewField_layoutViewColumn2_3
            // 
            this.layoutViewField_layoutViewColumn2_3.EditorPreferredWidth = 107;
            this.layoutViewField_layoutViewColumn2_3.Location = new System.Drawing.Point(81, 20);
            this.layoutViewField_layoutViewColumn2_3.Name = "layoutViewField_layoutViewColumn2_3";
            this.layoutViewField_layoutViewColumn2_3.Size = new System.Drawing.Size(113, 20);
            this.layoutViewField_layoutViewColumn2_3.TextSize = new System.Drawing.Size(0, 13);
            this.layoutViewField_layoutViewColumn2_3.TextToControlDistance = 2;
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
            this.layoutViewField_layoutViewColumn2_3,
            this.item7});
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
            // item7
            // 
            this.item7.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item7.AppearanceItemCaption.Options.UseFont = true;
            this.item7.CustomizationFormText = "Độ lớn(KB):";
            this.item7.Location = new System.Drawing.Point(0, 20);
            this.item7.Name = "item7";
            this.item7.Size = new System.Drawing.Size(81, 20);
            this.item7.Text = "Độ lớn(KB):";
            this.item7.TextSize = new System.Drawing.Size(55, 13);
            // 
            // repositoryItemButtonEdit3
            // 
            this.repositoryItemButtonEdit3.AutoHeight = false;
            this.repositoryItemButtonEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repositoryItemButtonEdit3.Name = "repositoryItemButtonEdit3";
            this.repositoryItemButtonEdit3.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
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
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // repositoryItemMemoExEdit2
            // 
            this.repositoryItemMemoExEdit2.AutoHeight = false;
            this.repositoryItemMemoExEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit2.Name = "repositoryItemMemoExEdit2";
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
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // frmKhachHangQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 539);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmKhachHangQL";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản trị quan hệ khách hàng";
            this.Load += new System.EventHandler(this.frmQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListNhomKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).EndInit();
            this.xtraTabControlDetail.ResumeLayout(false);
            this.tabCongViec.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCongviec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCongviec)).EndInit();
            this.tabDuAn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDuAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewDuAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colTen_DA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLoaiDA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNguoi_QL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNgay_BD_DA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colNgayKT_DA_DuKien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colT_trang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_codT_do_DA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repImageTaoCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item10)).EndInit();
            this.tabNhatKy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNhatKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhatKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            this.tabTaiLieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_mofile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_mofile_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_luufile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_luufile_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_xoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_xoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_sua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_suafile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn2_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaiLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colTenkhachhang;
        public DevExpress.XtraBars.BarButtonItem barbuttonCapNhatTienDo;
        private DevExpress.XtraBars.BarButtonItem barButtonNhatKyCongViec;
        public DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        private DevExpress.XtraTab.XtraTabPage tabCongViec;
        private DevExpress.XtraTab.XtraTabPage tabTaiLieu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        public DevExpress.XtraGrid.GridControl gridControlCongviec;
        public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewCongviec;
        private DevExpress.XtraGrid.Columns.GridColumn CongViec;
        private DevExpress.XtraGrid.Columns.GridColumn Cotnguoigiao;
        private DevExpress.XtraGrid.Columns.GridColumn CotTienDo;
        private DevExpress.XtraGrid.Columns.GridColumn CotNguoiThucHien;
        private DevExpress.XtraGrid.Columns.GridColumn CotLoaiCongViec;
        private DevExpress.XtraGrid.Columns.GridColumn Cotbatdau;
        private DevExpress.XtraGrid.Columns.GridColumn Cotngayketthuc;
        private DevExpress.XtraGrid.Columns.GridColumn CotTGdutinh;
        private DevExpress.XtraGrid.Columns.GridColumn CotDouutien;
        private DevExpress.XtraGrid.Columns.GridColumn CotTinhtrang;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraTreeList.TreeList treeListNhomKH;
        private DevExpress.XtraTreeList.Columns.TreeListColumn NAME;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn cotNgayKTTT;
        private DevExpress.XtraGrid.GridControl gridControlTaiLieu;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lv_anh_default;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvNoi_dung;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cot_mofile;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rep_mofile;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cot_luufile;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rep_luufile;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cot_xoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rep_xoa;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cot_suafile;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rep_sua;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvNguoiCapNhat;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvNgayCapNhat;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvTieuDe;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvFile_dinh_kem;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvGhi_chu;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit2;
        private DevExpress.XtraGrid.Views.Grid.PLGridView gridViewTaiLieu;
        private DevExpress.XtraGrid.Columns.GridColumn CotFile;
        private DevExpress.XtraGrid.Columns.GridColumn CotGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn CotTieuDe;
        private DevExpress.XtraGrid.Columns.GridColumn cotID;
        private DevExpress.XtraGrid.Columns.GridColumn cotxoa2;
        private DevExpress.XtraTab.XtraTabPage tabDuAn;
        private DevExpress.XtraTab.XtraTabPage tabNhatKy;
        public DevExpress.XtraGrid.GridControl gridControlDuAn;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutViewDuAn;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colTen_DA;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colLoaiDA;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colNguoi_QL;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colNgay_BD_DA;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colNgayKT;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colT_trang;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn codT_do_DA;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn layoutViewColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repImage;
        private DevExpress.XtraGrid.GridControl gridControlNhatKy;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNhatKy;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiCapNhat;
        private DevExpress.XtraGrid.Columns.GridColumn colTGCapNhat;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiDung;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn colDiachi;
        private DevExpress.XtraGrid.Columns.GridColumn colDienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn colFax;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colXemDA;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colTaoCV;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repImageTaoCV;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvSize;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_mofile_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_luufile_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_xoa;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_suafile;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_4;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn2_3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.LayoutControlGroup Group1;
        private DevExpress.XtraLayout.SimpleLabelItem item1;
        private DevExpress.XtraLayout.SimpleLabelItem item2;
        private DevExpress.XtraLayout.SimpleLabelItem item3;
        private DevExpress.XtraLayout.SimpleLabelItem item4;
        private DevExpress.XtraLayout.SimpleLabelItem item5;
        private DevExpress.XtraLayout.SimpleLabelItem item7;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colTen_DA;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colLoaiDA;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colNguoi_QL;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colNgayKTDK;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn2_4;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colNgay_BD_DA;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colNgayKT_DA_DuKien;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colT_trang;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_codT_do_DA;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_id;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn2_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn2_2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard2;
        private DevExpress.XtraLayout.LayoutControlGroup item6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem2;
        private DevExpress.XtraLayout.SimpleLabelItem item8;
        private DevExpress.XtraLayout.SimpleLabelItem item9;
        private DevExpress.XtraLayout.SimpleLabelItem item10;
        private DevExpress.XtraBars.BarButtonItem barRefresh;
    }
}