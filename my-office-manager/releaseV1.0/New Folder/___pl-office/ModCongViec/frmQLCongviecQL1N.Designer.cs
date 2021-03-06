using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmQLCongviecQL1N
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLCongviecQL1N));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
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
            this.barbuttonCapNhatTienDo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonNhatKyCongViec = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.CotCongViec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotnguoigiao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTenDuAn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTienDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotNguoiThucHien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotLoaiCongViec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotbatdau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotNgayKetThucDuKien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotngayketthuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTGdutinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotDouutien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTinhtrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.XtraTabPageDetail = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlCTTD_ThucHien = new DevExpress.XtraGrid.GridControl();
            this.gridViewCTTD_ThucHien = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.colDetailNguoiThucHien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailMDThamGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailTienDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailTGCapNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPageTienDo = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlThongTinLienHe = new DevExpress.XtraGrid.GridControl();
            this.gridViewThongTinLienHe = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.colNgayCapNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiThucHien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTienDoThucHien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPageTaiLieu = new DevExpress.XtraTab.XtraTabPage();
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
            this.item2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.item6 = new DevExpress.XtraLayout.SimpleSeparator();
            this.item1 = new DevExpress.XtraLayout.SimpleLabelItem();
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
            this.xtraTabPageNhatKy = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlNhatKyCV = new DevExpress.XtraGrid.GridControl();
            this.gridViewNhatKyCV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNguoiCapNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTGCapNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupControlContainerFilter = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.NhanVien = new ProtocolVN.Framework.Win.PLDMTreeGroup();
            this.NguoiThucHien = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.mruEditTenCongViec = new DevExpress.XtraEditors.MRUEdit();
            this.chekEditNgayKTDK = new DevExpress.XtraEditors.CheckEdit();
            this.chkEditCV_KH = new DevExpress.XtraEditors.CheckEdit();
            this.chkEditCV_DA = new DevExpress.XtraEditors.CheckEdit();
            this.ngayLamViec = new ProtocolVN.Framework.Win.Office.PLDateSelection();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.Tinhtrang = new ProtocolVN.Framework.Win.PLCombobox();
            this.cmbDoUuTien = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.labelControl7 = new System.Windows.Forms.PLLabel();
            this.labelControl6 = new System.Windows.Forms.PLLabel();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.LoaiCV = new ProtocolVN.Framework.Win.PLCombobox();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
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
            this.XtraTabPageDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCTTD_ThucHien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCTTD_ThucHien)).BeginInit();
            this.xtraTabPageTienDo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThongTinLienHe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThongTinLienHe)).BeginInit();
            this.xtraTabPageTaiLieu.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_xoa_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_sua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_suafile_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).BeginInit();
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
            this.xtraTabPageNhatKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNhatKyCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhatKyCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).BeginInit();
            this.popupControlContainerFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mruEditTenCongViec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chekEditNgayKTDK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditCV_KH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditCV_DA.Properties)).BeginInit();
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
            this.barButtonItem4,
            this.barButtonItem5,
            this.barbuttonCapNhatTienDo,
            this.barButtonNhatKyCongViec});
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
            this.barDockControlTop.Size = new System.Drawing.Size(1028, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 497);
            this.barDockControlBottom.Size = new System.Drawing.Size(1028, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(1028, 24);
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
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 118);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlMaster);
            this.splitContainerControl1.Panel1.MinSize = 150;
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlDetail);
            this.splitContainerControl1.Panel2.MinSize = 126;
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1028, 379);
            this.splitContainerControl1.SplitterPosition = 150;
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
            this.gridControlMaster.Size = new System.Drawing.Size(1028, 150);
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
            this.CotCongViec,
            this.Cotnguoigiao,
            this.CotTenDuAn,
            this.CotKhachHang,
            this.CotTienDo,
            this.CotNguoiThucHien,
            this.CotLoaiCongViec,
            this.Cotbatdau,
            this.CotNgayKetThucDuKien,
            this.Cotngayketthuc,
            this.CotTGdutinh,
            this.CotDouutien,
            this.CotTinhtrang});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupCount = 1;
            this.gridViewMaster.GroupPanelText = "DANH SÁCH CÔNG VIỆC";
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.CotLoaiCongViec, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // CotCongViec
            // 
            this.CotCongViec.Caption = "Công việc";
            this.CotCongViec.Name = "CotCongViec";
            this.CotCongViec.Visible = true;
            this.CotCongViec.VisibleIndex = 0;
            this.CotCongViec.Width = 59;
            // 
            // Cotnguoigiao
            // 
            this.Cotnguoigiao.AppearanceHeader.Options.UseTextOptions = true;
            this.Cotnguoigiao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cotnguoigiao.Caption = "Người giao";
            this.Cotnguoigiao.Name = "Cotnguoigiao";
            this.Cotnguoigiao.OptionsColumn.AllowEdit = false;
            this.Cotnguoigiao.OptionsColumn.AllowFocus = false;
            this.Cotnguoigiao.OptionsColumn.ReadOnly = true;
            this.Cotnguoigiao.Width = 63;
            // 
            // CotTenDuAn
            // 
            this.CotTenDuAn.Caption = "Dự án";
            this.CotTenDuAn.Name = "CotTenDuAn";
            this.CotTenDuAn.OptionsColumn.AllowEdit = false;
            this.CotTenDuAn.Visible = true;
            this.CotTenDuAn.VisibleIndex = 1;
            this.CotTenDuAn.Width = 41;
            // 
            // CotKhachHang
            // 
            this.CotKhachHang.Caption = "Khách hàng";
            this.CotKhachHang.Name = "CotKhachHang";
            this.CotKhachHang.Visible = true;
            this.CotKhachHang.VisibleIndex = 2;
            this.CotKhachHang.Width = 68;
            // 
            // CotTienDo
            // 
            this.CotTienDo.AppearanceCell.Options.UseTextOptions = true;
            this.CotTienDo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CotTienDo.Caption = "Tiến độ";
            this.CotTienDo.Name = "CotTienDo";
            this.CotTienDo.Visible = true;
            this.CotTienDo.VisibleIndex = 4;
            this.CotTienDo.Width = 47;
            // 
            // CotNguoiThucHien
            // 
            this.CotNguoiThucHien.Caption = "Người thực hiện";
            this.CotNguoiThucHien.Name = "CotNguoiThucHien";
            this.CotNguoiThucHien.Visible = true;
            this.CotNguoiThucHien.VisibleIndex = 3;
            this.CotNguoiThucHien.Width = 88;
            // 
            // CotLoaiCongViec
            // 
            this.CotLoaiCongViec.Caption = "Loại công việc";
            this.CotLoaiCongViec.Name = "CotLoaiCongViec";
            this.CotLoaiCongViec.OptionsColumn.AllowEdit = false;
            this.CotLoaiCongViec.OptionsColumn.AllowFocus = false;
            this.CotLoaiCongViec.OptionsColumn.ReadOnly = true;
            this.CotLoaiCongViec.Visible = true;
            this.CotLoaiCongViec.VisibleIndex = 5;
            this.CotLoaiCongViec.Width = 92;
            // 
            // Cotbatdau
            // 
            this.Cotbatdau.AppearanceCell.Options.UseTextOptions = true;
            this.Cotbatdau.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cotbatdau.AppearanceHeader.Options.UseTextOptions = true;
            this.Cotbatdau.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cotbatdau.Caption = "Ngày bắt đầu";
            this.Cotbatdau.Name = "Cotbatdau";
            this.Cotbatdau.OptionsColumn.AllowEdit = false;
            this.Cotbatdau.OptionsColumn.AllowFocus = false;
            this.Cotbatdau.OptionsColumn.ReadOnly = true;
            this.Cotbatdau.Visible = true;
            this.Cotbatdau.VisibleIndex = 6;
            this.Cotbatdau.Width = 77;
            // 
            // CotNgayKetThucDuKien
            // 
            this.CotNgayKetThucDuKien.Caption = "Ngày kết thúc dự kiến";
            this.CotNgayKetThucDuKien.Name = "CotNgayKetThucDuKien";
            this.CotNgayKetThucDuKien.Visible = true;
            this.CotNgayKetThucDuKien.VisibleIndex = 7;
            this.CotNgayKetThucDuKien.Width = 117;
            // 
            // Cotngayketthuc
            // 
            this.Cotngayketthuc.AppearanceCell.Options.UseTextOptions = true;
            this.Cotngayketthuc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cotngayketthuc.AppearanceHeader.Options.UseTextOptions = true;
            this.Cotngayketthuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cotngayketthuc.Caption = "Ngày kết thúc";
            this.Cotngayketthuc.Name = "Cotngayketthuc";
            this.Cotngayketthuc.OptionsColumn.AllowEdit = false;
            this.Cotngayketthuc.OptionsColumn.AllowFocus = false;
            this.Cotngayketthuc.OptionsColumn.ReadOnly = true;
            this.Cotngayketthuc.Visible = true;
            this.Cotngayketthuc.VisibleIndex = 9;
            this.Cotngayketthuc.Width = 79;
            // 
            // CotTGdutinh
            // 
            this.CotTGdutinh.AppearanceCell.Options.UseTextOptions = true;
            this.CotTGdutinh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CotTGdutinh.Caption = "Thời gian dự kiến";
            this.CotTGdutinh.Name = "CotTGdutinh";
            this.CotTGdutinh.OptionsColumn.AllowEdit = false;
            this.CotTGdutinh.OptionsColumn.AllowFocus = false;
            this.CotTGdutinh.OptionsColumn.ReadOnly = true;
            this.CotTGdutinh.Visible = true;
            this.CotTGdutinh.VisibleIndex = 8;
            this.CotTGdutinh.Width = 93;
            // 
            // CotDouutien
            // 
            this.CotDouutien.AppearanceCell.Options.UseTextOptions = true;
            this.CotDouutien.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CotDouutien.Caption = "Độ ưu tiên";
            this.CotDouutien.Name = "CotDouutien";
            this.CotDouutien.OptionsColumn.AllowEdit = false;
            this.CotDouutien.OptionsColumn.AllowFocus = false;
            this.CotDouutien.OptionsColumn.ReadOnly = true;
            this.CotDouutien.Visible = true;
            this.CotDouutien.VisibleIndex = 10;
            this.CotDouutien.Width = 63;
            // 
            // CotTinhtrang
            // 
            this.CotTinhtrang.Caption = "Tình trạng";
            this.CotTinhtrang.Name = "CotTinhtrang";
            this.CotTinhtrang.OptionsColumn.AllowEdit = false;
            this.CotTinhtrang.OptionsColumn.AllowFocus = false;
            this.CotTinhtrang.OptionsColumn.ReadOnly = true;
            this.CotTinhtrang.Visible = true;
            this.CotTinhtrang.VisibleIndex = 11;
            this.CotTinhtrang.Width = 61;
            // 
            // xtraTabControlDetail
            // 
            this.xtraTabControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlDetail.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlDetail.Name = "xtraTabControlDetail";
            this.xtraTabControlDetail.SelectedTabPage = this.XtraTabPageDetail;
            this.xtraTabControlDetail.Size = new System.Drawing.Size(1028, 223);
            this.xtraTabControlDetail.TabIndex = 0;
            this.xtraTabControlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.XtraTabPageDetail,
            this.xtraTabPageTienDo,
            this.xtraTabPageTaiLieu,
            this.xtraTabPageNhatKy});
            this.xtraTabControlDetail.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControlDetail_SelectedPageChanged);
            // 
            // XtraTabPageDetail
            // 
            this.XtraTabPageDetail.Controls.Add(this.gridControlCTTD_ThucHien);
            this.XtraTabPageDetail.Name = "XtraTabPageDetail";
            this.XtraTabPageDetail.Size = new System.Drawing.Size(1021, 194);
            this.XtraTabPageDetail.Text = "Chi tiết tiến độ thực hiện";
            // 
            // gridControlCTTD_ThucHien
            // 
            this.gridControlCTTD_ThucHien.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlCTTD_ThucHien.BackgroundImage")));
            this.gridControlCTTD_ThucHien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlCTTD_ThucHien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCTTD_ThucHien.Location = new System.Drawing.Point(0, 0);
            this.gridControlCTTD_ThucHien.MainView = this.gridViewCTTD_ThucHien;
            this.gridControlCTTD_ThucHien.Name = "gridControlCTTD_ThucHien";
            this.gridControlCTTD_ThucHien.Size = new System.Drawing.Size(1021, 194);
            this.gridControlCTTD_ThucHien.TabIndex = 12;
            this.gridControlCTTD_ThucHien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCTTD_ThucHien});
            // 
            // gridViewCTTD_ThucHien
            // 
            this.gridViewCTTD_ThucHien.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewCTTD_ThucHien.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewCTTD_ThucHien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDetailNguoiThucHien,
            this.colDetailMDThamGia,
            this.colDetailTienDo,
            this.colDetailTGCapNhat});
            this.gridViewCTTD_ThucHien.GridControl = this.gridControlCTTD_ThucHien;
            this.gridViewCTTD_ThucHien.IndicatorWidth = 40;
            this.gridViewCTTD_ThucHien.Name = "gridViewCTTD_ThucHien";
            this.gridViewCTTD_ThucHien.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewCTTD_ThucHien.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewCTTD_ThucHien.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewCTTD_ThucHien.OptionsPrint.UsePrintStyles = true;
            this.gridViewCTTD_ThucHien.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewCTTD_ThucHien.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewCTTD_ThucHien.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewCTTD_ThucHien.OptionsView.ShowGroupedColumns = true;
            this.gridViewCTTD_ThucHien.OptionsView.ShowGroupPanel = false;
            // 
            // colDetailNguoiThucHien
            // 
            this.colDetailNguoiThucHien.AppearanceCell.Options.UseTextOptions = true;
            this.colDetailNguoiThucHien.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDetailNguoiThucHien.Caption = "Người thực hiện";
            this.colDetailNguoiThucHien.Name = "colDetailNguoiThucHien";
            this.colDetailNguoiThucHien.OptionsColumn.AllowEdit = false;
            this.colDetailNguoiThucHien.OptionsColumn.ReadOnly = true;
            this.colDetailNguoiThucHien.Visible = true;
            this.colDetailNguoiThucHien.VisibleIndex = 0;
            this.colDetailNguoiThucHien.Width = 88;
            // 
            // colDetailMDThamGia
            // 
            this.colDetailMDThamGia.Caption = "Mức độ tham gia";
            this.colDetailMDThamGia.Name = "colDetailMDThamGia";
            this.colDetailMDThamGia.OptionsColumn.AllowEdit = false;
            this.colDetailMDThamGia.OptionsColumn.ReadOnly = true;
            this.colDetailMDThamGia.Visible = true;
            this.colDetailMDThamGia.VisibleIndex = 1;
            this.colDetailMDThamGia.Width = 91;
            // 
            // colDetailTienDo
            // 
            this.colDetailTienDo.AppearanceCell.Options.UseTextOptions = true;
            this.colDetailTienDo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDetailTienDo.Caption = "Tiến độ thực hiện";
            this.colDetailTienDo.Name = "colDetailTienDo";
            this.colDetailTienDo.OptionsColumn.AllowEdit = false;
            this.colDetailTienDo.OptionsColumn.ReadOnly = true;
            this.colDetailTienDo.Visible = true;
            this.colDetailTienDo.VisibleIndex = 2;
            this.colDetailTienDo.Width = 95;
            // 
            // colDetailTGCapNhat
            // 
            this.colDetailTGCapNhat.Caption = "Thời gian cập nhật";
            this.colDetailTGCapNhat.Name = "colDetailTGCapNhat";
            this.colDetailTGCapNhat.OptionsColumn.AllowEdit = false;
            this.colDetailTGCapNhat.OptionsColumn.ReadOnly = true;
            this.colDetailTGCapNhat.Visible = true;
            this.colDetailTGCapNhat.VisibleIndex = 3;
            this.colDetailTGCapNhat.Width = 100;
            // 
            // xtraTabPageTienDo
            // 
            this.xtraTabPageTienDo.Controls.Add(this.gridControlThongTinLienHe);
            this.xtraTabPageTienDo.Name = "xtraTabPageTienDo";
            this.xtraTabPageTienDo.Size = new System.Drawing.Size(1021, 194);
            this.xtraTabPageTienDo.Text = "Tiến độ thực hiện";
            // 
            // gridControlThongTinLienHe
            // 
            this.gridControlThongTinLienHe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlThongTinLienHe.BackgroundImage")));
            this.gridControlThongTinLienHe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlThongTinLienHe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlThongTinLienHe.Location = new System.Drawing.Point(0, 0);
            this.gridControlThongTinLienHe.MainView = this.gridViewThongTinLienHe;
            this.gridControlThongTinLienHe.Name = "gridControlThongTinLienHe";
            this.gridControlThongTinLienHe.Size = new System.Drawing.Size(1021, 194);
            this.gridControlThongTinLienHe.TabIndex = 41;
            this.gridControlThongTinLienHe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewThongTinLienHe});
            // 
            // gridViewThongTinLienHe
            // 
            this.gridViewThongTinLienHe.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewThongTinLienHe.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewThongTinLienHe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNgayCapNhat,
            this.colNguoiThucHien,
            this.colTienDoThucHien,
            this.colGhiChu});
            this.gridViewThongTinLienHe.GridControl = this.gridControlThongTinLienHe;
            this.gridViewThongTinLienHe.IndicatorWidth = 40;
            this.gridViewThongTinLienHe.Name = "gridViewThongTinLienHe";
            this.gridViewThongTinLienHe.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewThongTinLienHe.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewThongTinLienHe.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewThongTinLienHe.OptionsPrint.UsePrintStyles = true;
            this.gridViewThongTinLienHe.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewThongTinLienHe.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewThongTinLienHe.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewThongTinLienHe.OptionsView.ShowGroupedColumns = true;
            this.gridViewThongTinLienHe.OptionsView.ShowGroupPanel = false;
            // 
            // colNgayCapNhat
            // 
            this.colNgayCapNhat.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayCapNhat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayCapNhat.Caption = "Thời gian cập nhật";
            this.colNgayCapNhat.FieldName = "colNgayCapNhat";
            this.colNgayCapNhat.Name = "colNgayCapNhat";
            this.colNgayCapNhat.OptionsColumn.AllowEdit = false;
            this.colNgayCapNhat.OptionsColumn.ReadOnly = true;
            this.colNgayCapNhat.Visible = true;
            this.colNgayCapNhat.VisibleIndex = 0;
            this.colNgayCapNhat.Width = 100;
            // 
            // colNguoiThucHien
            // 
            this.colNguoiThucHien.Caption = "Người thực hiện";
            this.colNguoiThucHien.Name = "colNguoiThucHien";
            this.colNguoiThucHien.OptionsColumn.AllowEdit = false;
            this.colNguoiThucHien.OptionsColumn.ReadOnly = true;
            this.colNguoiThucHien.Visible = true;
            this.colNguoiThucHien.VisibleIndex = 1;
            this.colNguoiThucHien.Width = 88;
            // 
            // colTienDoThucHien
            // 
            this.colTienDoThucHien.AppearanceCell.Options.UseTextOptions = true;
            this.colTienDoThucHien.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTienDoThucHien.Caption = "Tiến độ thực hiện";
            this.colTienDoThucHien.Name = "colTienDoThucHien";
            this.colTienDoThucHien.OptionsColumn.AllowEdit = false;
            this.colTienDoThucHien.OptionsColumn.ReadOnly = true;
            this.colTienDoThucHien.Visible = true;
            this.colTienDoThucHien.VisibleIndex = 2;
            this.colTienDoThucHien.Width = 95;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.OptionsColumn.AllowEdit = false;
            this.colGhiChu.OptionsColumn.ReadOnly = true;
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 3;
            this.colGhiChu.Width = 47;
            // 
            // xtraTabPageTaiLieu
            // 
            this.xtraTabPageTaiLieu.Controls.Add(this.gridControlTaiLieu);
            this.xtraTabPageTaiLieu.Name = "xtraTabPageTaiLieu";
            this.xtraTabPageTaiLieu.Size = new System.Drawing.Size(1021, 194);
            this.xtraTabPageTaiLieu.Text = "Danh sách tài liệu";
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
            this.gridControlTaiLieu.Size = new System.Drawing.Size(1021, 194);
            this.gridControlTaiLieu.TabIndex = 191;
            this.gridControlTaiLieu.Tag = "";
            this.gridControlTaiLieu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1,
            this.gridViewTaiLieu});
            this.gridControlTaiLieu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridViewTaiLieu_MouseMove);
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
            this.layoutViewField_layoutViewColumn1_2,
            this.layoutViewField_cot_suafile_1,
            this.layoutViewField_cot_xoa_1});
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
            this.layoutViewField_layoutViewColumn1_1,
            this.layoutViewField_layoutViewColumn1_4,
            this.item2,
            this.item1,
            this.item3,
            this.item4,
            this.item5,
            this.layoutViewField_layoutViewColumn1_5,
            this.item7});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 2;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // item2
            // 
            this.item2.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item2.AppearanceGroup.Options.UseFont = true;
            this.item2.CustomizationFormText = "Thao tác";
            this.item2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_cot_mofile_1,
            this.layoutViewField_cot_luufile_1,
            this.item6});
            this.item2.Location = new System.Drawing.Point(0, 100);
            this.item2.Name = "item2";
            this.item2.Size = new System.Drawing.Size(194, 70);
            this.item2.Text = "Thao tác";
            // 
            // item6
            // 
            this.item6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item6.AppearanceItemCaption.Options.UseFont = true;
            this.item6.CustomizationFormText = "item6";
            this.item6.Location = new System.Drawing.Point(60, 0);
            this.item6.Name = "item6";
            this.item6.Size = new System.Drawing.Size(110, 26);
            this.item6.Text = "item6";
            this.item6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // item1
            // 
            this.item1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item1.AppearanceItemCaption.Options.UseFont = true;
            this.item1.CustomizationFormText = "Tên tập tin:";
            this.item1.Location = new System.Drawing.Point(0, 0);
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(81, 20);
            this.item1.Text = "Tên tập tin:";
            this.item1.TextSize = new System.Drawing.Size(56, 13);
            // 
            // item3
            // 
            this.item3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item3.AppearanceItemCaption.Options.UseFont = true;
            this.item3.CustomizationFormText = "Ngày cập nhật:";
            this.item3.Location = new System.Drawing.Point(0, 60);
            this.item3.Name = "item3";
            this.item3.Size = new System.Drawing.Size(81, 20);
            this.item3.Text = "Ngày cập nhật:";
            this.item3.TextSize = new System.Drawing.Size(74, 13);
            // 
            // item4
            // 
            this.item4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item4.AppearanceItemCaption.Options.UseFont = true;
            this.item4.CustomizationFormText = "Ghi chú:";
            this.item4.Location = new System.Drawing.Point(0, 80);
            this.item4.Name = "item4";
            this.item4.Size = new System.Drawing.Size(81, 20);
            this.item4.Text = "Ghi chú:";
            this.item4.TextSize = new System.Drawing.Size(39, 13);
            // 
            // item5
            // 
            this.item5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item5.AppearanceItemCaption.Options.UseFont = true;
            this.item5.CustomizationFormText = "Người cập nhật:";
            this.item5.Location = new System.Drawing.Point(0, 37);
            this.item5.Name = "item5";
            this.item5.Size = new System.Drawing.Size(81, 23);
            this.item5.Text = "Người cập nhật:";
            this.item5.TextSize = new System.Drawing.Size(77, 13);
            // 
            // item7
            // 
            this.item7.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item7.AppearanceItemCaption.Options.UseFont = true;
            this.item7.CustomizationFormText = "Độ lớn(KB):";
            this.item7.Location = new System.Drawing.Point(0, 20);
            this.item7.Name = "item7";
            this.item7.Size = new System.Drawing.Size(81, 17);
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
            // xtraTabPageNhatKy
            // 
            this.xtraTabPageNhatKy.Controls.Add(this.gridControlNhatKyCV);
            this.xtraTabPageNhatKy.Name = "xtraTabPageNhatKy";
            this.xtraTabPageNhatKy.Size = new System.Drawing.Size(1021, 194);
            this.xtraTabPageNhatKy.Text = "Danh sách nhật ký";
            // 
            // gridControlNhatKyCV
            // 
            this.gridControlNhatKyCV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlNhatKyCV.Location = new System.Drawing.Point(0, 0);
            this.gridControlNhatKyCV.MainView = this.gridViewNhatKyCV;
            this.gridControlNhatKyCV.Name = "gridControlNhatKyCV";
            this.gridControlNhatKyCV.Size = new System.Drawing.Size(1021, 194);
            this.gridControlNhatKyCV.TabIndex = 2;
            this.gridControlNhatKyCV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNhatKyCV,
            this.gridView5});
            // 
            // gridViewNhatKyCV
            // 
            this.gridViewNhatKyCV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNguoiCapNhat,
            this.colTGCapNhat,
            this.colNoiDung});
            this.gridViewNhatKyCV.GridControl = this.gridControlNhatKyCV;
            this.gridViewNhatKyCV.Name = "gridViewNhatKyCV";
            this.gridViewNhatKyCV.OptionsBehavior.Editable = false;
            this.gridViewNhatKyCV.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewNhatKyCV.OptionsView.ShowGroupPanel = false;
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
            this.gridView5.GridControl = this.gridControlNhatKyCV;
            this.gridView5.Name = "gridView5";
            // 
            // popupControlContainerFilter
            // 
            this.popupControlContainerFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainerFilter.Controls.Add(this.NhanVien);
            this.popupControlContainerFilter.Controls.Add(this.NguoiThucHien);
            this.popupControlContainerFilter.Controls.Add(this.mruEditTenCongViec);
            this.popupControlContainerFilter.Controls.Add(this.chekEditNgayKTDK);
            this.popupControlContainerFilter.Controls.Add(this.chkEditCV_KH);
            this.popupControlContainerFilter.Controls.Add(this.chkEditCV_DA);
            this.popupControlContainerFilter.Controls.Add(this.ngayLamViec);
            this.popupControlContainerFilter.Controls.Add(this.plLabel1);
            this.popupControlContainerFilter.Controls.Add(this.Tinhtrang);
            this.popupControlContainerFilter.Controls.Add(this.cmbDoUuTien);
            this.popupControlContainerFilter.Controls.Add(this.labelControl7);
            this.popupControlContainerFilter.Controls.Add(this.labelControl6);
            this.popupControlContainerFilter.Controls.Add(this.labelControl5);
            this.popupControlContainerFilter.Controls.Add(this.plLabel2);
            this.popupControlContainerFilter.Controls.Add(this.labelControl3);
            this.popupControlContainerFilter.Controls.Add(this.LoaiCV);
            this.popupControlContainerFilter.Controls.Add(this.labelControl4);
            this.popupControlContainerFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupControlContainerFilter.Location = new System.Drawing.Point(0, 24);
            this.popupControlContainerFilter.Manager = this.barManager1;
            this.popupControlContainerFilter.Name = "popupControlContainerFilter";
            this.popupControlContainerFilter.Size = new System.Drawing.Size(1028, 94);
            this.popupControlContainerFilter.TabIndex = 0;
            this.popupControlContainerFilter.Visible = false;
            // 
            // NhanVien
            // 
            this.NhanVien.Location = new System.Drawing.Point(302, 40);
            this.NhanVien.Name = "NhanVien";
            this.NhanVien.Size = new System.Drawing.Size(141, 20);
            this.NhanVien.TabIndex = 3;
            // 
            // NguoiThucHien
            // 
            this.NguoiThucHien.Location = new System.Drawing.Point(567, 66);
            this.NguoiThucHien.Name = "NguoiThucHien";
            this.NguoiThucHien.Size = new System.Drawing.Size(227, 20);
            this.NguoiThucHien.TabIndex = 6;
            // 
            // mruEditTenCongViec
            // 
            this.mruEditTenCongViec.Location = new System.Drawing.Point(79, 12);
            this.mruEditTenCongViec.Name = "mruEditTenCongViec";
            this.mruEditTenCongViec.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.mruEditTenCongViec.Size = new System.Drawing.Size(364, 20);
            this.mruEditTenCongViec.TabIndex = 0;
            // 
            // chekEditNgayKTDK
            // 
            this.chekEditNgayKTDK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chekEditNgayKTDK.Location = new System.Drawing.Point(891, 63);
            this.chekEditNgayKTDK.MenuManager = this.barManager1;
            this.chekEditNgayKTDK.Name = "chekEditNgayKTDK";
            this.chekEditNgayKTDK.Properties.Caption = "Ngày kết thúc dự kiến";
            this.chekEditNgayKTDK.Size = new System.Drawing.Size(132, 19);
            this.chekEditNgayKTDK.TabIndex = 9;
            // 
            // chkEditCV_KH
            // 
            this.chkEditCV_KH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEditCV_KH.Location = new System.Drawing.Point(941, 38);
            this.chkEditCV_KH.MenuManager = this.barManager1;
            this.chkEditCV_KH.Name = "chkEditCV_KH";
            this.chkEditCV_KH.Properties.Caption = "Khách hàng";
            this.chkEditCV_KH.Size = new System.Drawing.Size(84, 19);
            this.chkEditCV_KH.TabIndex = 8;
            // 
            // chkEditCV_DA
            // 
            this.chkEditCV_DA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEditCV_DA.Location = new System.Drawing.Point(968, 13);
            this.chkEditCV_DA.MenuManager = this.barManager1;
            this.chkEditCV_DA.Name = "chkEditCV_DA";
            this.chkEditCV_DA.Properties.Caption = "Dự án";
            this.chkEditCV_DA.Size = new System.Drawing.Size(57, 19);
            this.chkEditCV_DA.TabIndex = 7;
            this.chkEditCV_DA.CheckedChanged += new System.EventHandler(this.chkEditCV_DA_CheckedChanged);
            // 
            // ngayLamViec
            // 
            this.ngayLamViec.Caption = "Năm 2010 và 2011";
            this.ngayLamViec.Default = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromYearToYear;
            this.ngayLamViec.FirstFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayLamViec.FirstTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayLamViec.FromDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayLamViec.Location = new System.Drawing.Point(567, 39);
            this.ngayLamViec.Name = "ngayLamViec";
            this.ngayLamViec.ReturnType = ProtocolVN.Framework.Win.Trial.TimeType.Date;
            this.ngayLamViec.SecondFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayLamViec.SecondTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayLamViec.SelectedType = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromYearToYear;
            this.ngayLamViec.Size = new System.Drawing.Size(227, 21);
            this.ngayLamViec.TabIndex = 5;
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
            this.plLabel1.Location = new System.Drawing.Point(469, 43);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(91, 13);
            this.plLabel1.TabIndex = 39;
            this.plLabel1.Text = "Thời gian thực hiện";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // Tinhtrang
            // 
            this.Tinhtrang.DataSource = null;
            this.Tinhtrang.DisplayField = null;
            this.Tinhtrang.Location = new System.Drawing.Point(79, 66);
            this.Tinhtrang.Name = "Tinhtrang";
            this.Tinhtrang.Size = new System.Drawing.Size(141, 20);
            this.Tinhtrang.TabIndex = 2;
            this.Tinhtrang.ValueField = null;
            // 
            // cmbDoUuTien
            // 
            this.cmbDoUuTien.DataSource = null;
            this.cmbDoUuTien.DisplayField = null;
            this.cmbDoUuTien.Location = new System.Drawing.Point(302, 66);
            this.cmbDoUuTien.Name = "cmbDoUuTien";
            this.cmbDoUuTien.Size = new System.Drawing.Size(141, 20);
            this.cmbDoUuTien.TabIndex = 4;
            this.cmbDoUuTien.ValueField = null;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(245, 43);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(51, 13);
            this.labelControl7.TabIndex = 38;
            this.labelControl7.Text = "Người giao";
            this.labelControl7.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(245, 70);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(51, 13);
            this.labelControl6.TabIndex = 34;
            this.labelControl6.Text = "Độ ưu tiên";
            this.labelControl6.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(6, 70);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(49, 13);
            this.labelControl5.TabIndex = 32;
            this.labelControl5.Text = "Tình trạng";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // plLabel2
            // 
            this.plLabel2.Location = new System.Drawing.Point(6, 16);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(66, 13);
            this.plLabel2.TabIndex = 29;
            this.plLabel2.Text = "Tên công việc";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 43);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(67, 13);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "Loại công việc";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // LoaiCV
            // 
            this.LoaiCV.DataSource = null;
            this.LoaiCV.DisplayField = null;
            this.LoaiCV.Location = new System.Drawing.Point(79, 39);
            this.LoaiCV.Name = "LoaiCV";
            this.LoaiCV.Size = new System.Drawing.Size(141, 20);
            this.LoaiCV.TabIndex = 1;
            this.LoaiCV.ValueField = null;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(470, 70);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 13);
            this.labelControl4.TabIndex = 26;
            this.labelControl4.Text = "Người thực hiện";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
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
            // frmQLCongviecQL1N
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 497);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.popupControlContainerFilter);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmQLCongviecQL1N";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản trị công việc";
            this.Load += new System.EventHandler(this.frmQLCongviecQL1N_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).EndInit();
            this.xtraTabControlDetail.ResumeLayout(false);
            this.XtraTabPageDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCTTD_ThucHien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCTTD_ThucHien)).EndInit();
            this.xtraTabPageTienDo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThongTinLienHe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThongTinLienHe)).EndInit();
            this.xtraTabPageTaiLieu.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_xoa_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_sua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_suafile_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).EndInit();
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
            this.xtraTabPageNhatKy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNhatKyCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhatKyCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).EndInit();
            this.popupControlContainerFilter.ResumeLayout(false);
            this.popupControlContainerFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mruEditTenCongViec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chekEditNgayKTDK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditCV_KH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditCV_DA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn Cotnguoigiao;
        private DevExpress.XtraGrid.Columns.GridColumn Cotbatdau;
        private DevExpress.XtraGrid.Columns.GridColumn Cotngayketthuc;
        private DevExpress.XtraGrid.Views.Grid.PLGridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        
        private DevExpress.XtraTab.XtraTabPage XtraTabPageDetail;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private PLCombobox LoaiCV;
        private DevExpress.XtraGrid.Columns.GridColumn CotTGdutinh;
        private DevExpress.XtraGrid.Columns.GridColumn CotLoaiCongViec;
        private DevExpress.XtraGrid.Columns.GridColumn CotDouutien;
        private DevExpress.XtraGrid.Columns.GridColumn CotTinhtrang;
        private DevExpress.XtraGrid.Columns.GridColumn CotCongViec;
        private DevExpress.XtraGrid.Columns.GridColumn CotNguoiThucHien;
        private DevExpress.XtraGrid.Columns.GridColumn CotTienDo;
        public DevExpress.XtraBars.BarButtonItem barbuttonCapNhatTienDo;
        private PLImgCombobox cmbDoUuTien;
        private PLCombobox Tinhtrang;
        private System.Windows.Forms.PLLabel labelControl7;
        private System.Windows.Forms.PLLabel labelControl6;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel plLabel1;
        private ProtocolVN.Framework.Win.Office.PLDateSelection ngayLamViec;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageTienDo;
        private DevExpress.XtraBars.BarButtonItem barButtonNhatKyCongViec;
        private DevExpress.XtraGrid.Columns.GridColumn CotNgayKetThucDuKien;
        public DevExpress.XtraGrid.GridControl gridControlCTTD_ThucHien;
        public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewCTTD_ThucHien;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailNguoiThucHien;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailMDThamGia;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailTienDo;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailTGCapNhat;
        public DevExpress.XtraGrid.GridControl gridControlThongTinLienHe;
        public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewThongTinLienHe;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayCapNhat;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiThucHien;
        private DevExpress.XtraGrid.Columns.GridColumn colTienDoThucHien;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn CotTenDuAn;
        private CheckEdit chkEditCV_DA;
        private CheckEdit chkEditCV_KH;
        private DevExpress.XtraGrid.Columns.GridColumn CotKhachHang;
        private CheckEdit chekEditNgayKTDK;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageNhatKy;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageTaiLieu;
        private DevExpress.XtraGrid.GridControl gridControlNhatKyCV;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNhatKyCV;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiCapNhat;
        private DevExpress.XtraGrid.Columns.GridColumn colTGCapNhat;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiDung;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.GridControl gridControlTaiLieu;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvTieuDe;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvFile_dinh_kem;
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
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_mofile_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_luufile_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_xoa_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_suafile_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_4;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvSize;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_5;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.LayoutControlGroup item2;
        private DevExpress.XtraLayout.SimpleSeparator item6;
        private DevExpress.XtraLayout.SimpleLabelItem item1;
        private DevExpress.XtraLayout.SimpleLabelItem item3;
        private DevExpress.XtraLayout.SimpleLabelItem item4;
        private DevExpress.XtraLayout.SimpleLabelItem item5;
        private DevExpress.XtraLayout.SimpleLabelItem item7;
        private MRUEdit mruEditTenCongViec;
        private System.Windows.Forms.PLLabel plLabel2;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiThucHien;
        public PLDMTreeGroup NhanVien;
    }
}