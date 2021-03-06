using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmDuAnQL
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
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuAnQL));
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
            this.barbuttonCapNhatTienDo = new DevExpress.XtraBars.BarButtonItem();
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
            this.colTen_DA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiDA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoi_QL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMuc_UT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgay_BD_DA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayKT_DA_DuKien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotNgayKetThucTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT_trang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.codT_do_DA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.XtraTabPageDetail = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlThongTinLienHe = new DevExpress.XtraGrid.GridControl();
            this.gridViewThongTinLienHe = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.colCong_viec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiCV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoi_giao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoi_TH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDo_UT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgay_bat_dau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgay_ket_thucDuKien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTG_DT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotNgayKT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColTien_Do = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTinh_trang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlCongviec = new DevExpress.XtraGrid.GridControl();
            this.gridViewCongviec = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotCongViec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotLoaiCongViec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotNguoiGiao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotNguoiThucHien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotDoUuTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotBatDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotNgayKetThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTGDuTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTienDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTinhTrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotxoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotxoa1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.xtraTabPageTai_Lieu = new DevExpress.XtraTab.XtraTabPage();
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
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_cot_xoa = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cot_suafile = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rep_sua = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_cot_suafile = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvSize = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_5 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvNguoiCapNhat = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvNgayCapNhat = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvGhi_chu = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_4 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.Group1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.item6 = new DevExpress.XtraLayout.SimpleSeparator();
            this.item2 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item3 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item4 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item5 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item1 = new DevExpress.XtraLayout.SimpleLabelItem();
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
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotxoa2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPageNhatKy = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlNhatKyDA = new DevExpress.XtraGrid.GridControl();
            this.gridViewNhatKyDA = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNguoiCapNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTGCapNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupControlContainerFilter = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.NhanVien = new ProtocolVN.Framework.Win.PLDMTreeGroup();
            this.mruEditTenDuAn = new DevExpress.XtraEditors.MRUEdit();
            this.plLabel3 = new System.Windows.Forms.PLLabel();
            this.chkEditCV_KH = new DevExpress.XtraEditors.CheckEdit();
            this.ngayBD = new ProtocolVN.Framework.Win.Office.PLDateSelection();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.mucuutien = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.tintrang = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.LoaiCV = new ProtocolVN.Framework.Win.PLCombobox();
            this.LoaiDA = new ProtocolVN.Framework.Win.PLCombobox();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.labelControl6 = new System.Windows.Forms.PLLabel();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThongTinLienHe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThongTinLienHe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCongviec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCongviec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.xtraTabPageTai_Lieu.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_xoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_sua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_suafile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaiLieu)).BeginInit();
            this.xtraTabPageNhatKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNhatKyDA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhatKyDA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).BeginInit();
            this.popupControlContainerFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mruEditTenDuAn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditCV_KH.Properties)).BeginInit();
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
            this.barbuttonCapNhatTienDo});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barbuttonCapNhatTienDo),
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
            // barbuttonCapNhatTienDo
            // 
            this.barbuttonCapNhatTienDo.Caption = "Cập nhật tiến độ";
            this.barbuttonCapNhatTienDo.Id = 39;
            this.barbuttonCapNhatTienDo.Name = "barbuttonCapNhatTienDo";
            this.barbuttonCapNhatTienDo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 517);
            this.barDockControlBottom.Size = new System.Drawing.Size(1028, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 493);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1028, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 493);
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
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 119);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlMaster);
            this.splitContainerControl1.Panel1.MinSize = 50;
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlDetail);
            this.splitContainerControl1.Panel2.MinSize = 146;
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1028, 398);
            this.splitContainerControl1.SplitterPosition = 126;
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
            this.gridControlMaster.Size = new System.Drawing.Size(1028, 126);
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
            this.colTen_DA,
            this.colLoaiDA,
            this.colNguoi_QL,
            this.colMuc_UT,
            this.colNgay_BD_DA,
            this.colNgayKT_DA_DuKien,
            this.cotNgayKetThucTT,
            this.colT_trang,
            this.codT_do_DA,
            this.id,
            this.colTenKhachHang});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupCount = 1;
            this.gridViewMaster.GroupPanelText = "Danh sách dự án";
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
            this.gridViewMaster.OptionsView.ShowGroupPanel = false;
            this.gridViewMaster.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLoaiDA, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colTen_DA
            // 
            this.colTen_DA.Caption = "Tên dự án";
            this.colTen_DA.Name = "colTen_DA";
            this.colTen_DA.Visible = true;
            this.colTen_DA.VisibleIndex = 0;
            this.colTen_DA.Width = 61;
            // 
            // colLoaiDA
            // 
            this.colLoaiDA.Caption = "Loại dự án";
            this.colLoaiDA.Name = "colLoaiDA";
            this.colLoaiDA.Visible = true;
            this.colLoaiDA.VisibleIndex = 1;
            // 
            // colNguoi_QL
            // 
            this.colNguoi_QL.Caption = "Người quản lý";
            this.colNguoi_QL.Name = "colNguoi_QL";
            this.colNguoi_QL.Visible = true;
            this.colNguoi_QL.VisibleIndex = 2;
            this.colNguoi_QL.Width = 78;
            // 
            // colMuc_UT
            // 
            this.colMuc_UT.Caption = "Độ ưu tiên";
            this.colMuc_UT.Name = "colMuc_UT";
            this.colMuc_UT.Visible = true;
            this.colMuc_UT.VisibleIndex = 6;
            this.colMuc_UT.Width = 63;
            // 
            // colNgay_BD_DA
            // 
            this.colNgay_BD_DA.Caption = "Ngày bắt đầu";
            this.colNgay_BD_DA.Name = "colNgay_BD_DA";
            this.colNgay_BD_DA.Visible = true;
            this.colNgay_BD_DA.VisibleIndex = 3;
            this.colNgay_BD_DA.Width = 77;
            // 
            // colNgayKT_DA_DuKien
            // 
            this.colNgayKT_DA_DuKien.Caption = "Ngày kết thúc dự kiến";
            this.colNgayKT_DA_DuKien.Name = "colNgayKT_DA_DuKien";
            this.colNgayKT_DA_DuKien.Visible = true;
            this.colNgayKT_DA_DuKien.VisibleIndex = 4;
            this.colNgayKT_DA_DuKien.Width = 117;
            // 
            // cotNgayKetThucTT
            // 
            this.cotNgayKetThucTT.Caption = "Ngày kết thúc thực tế";
            this.cotNgayKetThucTT.Name = "cotNgayKetThucTT";
            this.cotNgayKetThucTT.Visible = true;
            this.cotNgayKetThucTT.VisibleIndex = 5;
            this.cotNgayKetThucTT.Width = 117;
            // 
            // colT_trang
            // 
            this.colT_trang.Caption = "Tình trạng";
            this.colT_trang.Name = "colT_trang";
            this.colT_trang.Visible = true;
            this.colT_trang.VisibleIndex = 7;
            this.colT_trang.Width = 61;
            // 
            // codT_do_DA
            // 
            this.codT_do_DA.Caption = "Tiến độ";
            this.codT_do_DA.Name = "codT_do_DA";
            this.codT_do_DA.Visible = true;
            this.codT_do_DA.VisibleIndex = 8;
            this.codT_do_DA.Width = 47;
            // 
            // id
            // 
            this.id.Caption = "gridColumn1";
            this.id.Name = "id";
            this.id.OptionsColumn.AllowEdit = false;
            this.id.OptionsColumn.AllowIncrementalSearch = false;
            this.id.OptionsColumn.AllowMove = false;
            this.id.OptionsColumn.ShowCaption = false;
            this.id.Width = 71;
            // 
            // colTenKhachHang
            // 
            this.colTenKhachHang.Caption = "Khách hàng";
            this.colTenKhachHang.Name = "colTenKhachHang";
            this.colTenKhachHang.Width = 68;
            // 
            // xtraTabControlDetail
            // 
            this.xtraTabControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlDetail.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlDetail.Name = "xtraTabControlDetail";
            this.xtraTabControlDetail.SelectedTabPage = this.XtraTabPageDetail;
            this.xtraTabControlDetail.Size = new System.Drawing.Size(1028, 266);
            this.xtraTabControlDetail.TabIndex = 0;
            this.xtraTabControlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.XtraTabPageDetail,
            this.xtraTabPageTai_Lieu,
            this.xtraTabPageNhatKy});
            // 
            // XtraTabPageDetail
            // 
            this.XtraTabPageDetail.Controls.Add(this.gridControlThongTinLienHe);
            this.XtraTabPageDetail.Controls.Add(this.gridControlCongviec);
            this.XtraTabPageDetail.Name = "XtraTabPageDetail";
            this.XtraTabPageDetail.Size = new System.Drawing.Size(1021, 237);
            this.XtraTabPageDetail.Text = "Danh sách công việc";
            // 
            // gridControlThongTinLienHe
            // 
            this.gridControlThongTinLienHe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlThongTinLienHe.BackgroundImage")));
            this.gridControlThongTinLienHe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlThongTinLienHe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlThongTinLienHe.Location = new System.Drawing.Point(0, 0);
            this.gridControlThongTinLienHe.MainView = this.gridViewThongTinLienHe;
            this.gridControlThongTinLienHe.Name = "gridControlThongTinLienHe";
            this.gridControlThongTinLienHe.Size = new System.Drawing.Size(1021, 237);
            this.gridControlThongTinLienHe.TabIndex = 11;
            this.gridControlThongTinLienHe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewThongTinLienHe});
            // 
            // gridViewThongTinLienHe
            // 
            this.gridViewThongTinLienHe.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewThongTinLienHe.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewThongTinLienHe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCong_viec,
            this.colLoaiCV,
            this.colNguoi_giao,
            this.colNguoi_TH,
            this.colDo_UT,
            this.colNgay_bat_dau,
            this.colNgay_ket_thucDuKien,
            this.colTG_DT,
            this.cotNgayKT,
            this.ColTien_Do,
            this.colTinh_trang});
            this.gridViewThongTinLienHe.GridControl = this.gridControlThongTinLienHe;
            this.gridViewThongTinLienHe.GroupCount = 1;
            this.gridViewThongTinLienHe.IndicatorWidth = 40;
            this.gridViewThongTinLienHe.Name = "gridViewThongTinLienHe";
            this.gridViewThongTinLienHe.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewThongTinLienHe.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewThongTinLienHe.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewThongTinLienHe.OptionsPrint.UsePrintStyles = true;
            this.gridViewThongTinLienHe.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewThongTinLienHe.OptionsSelection.MultiSelect = true;
            this.gridViewThongTinLienHe.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridViewThongTinLienHe.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewThongTinLienHe.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewThongTinLienHe.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewThongTinLienHe.OptionsView.RowAutoHeight = true;
            this.gridViewThongTinLienHe.OptionsView.ShowFooter = true;
            this.gridViewThongTinLienHe.OptionsView.ShowGroupedColumns = true;
            this.gridViewThongTinLienHe.OptionsView.ShowGroupPanel = false;
            this.gridViewThongTinLienHe.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLoaiCV, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewThongTinLienHe.DoubleClick += new System.EventHandler(this.gridViewThongTinLienHe_DoubleClick);
            // 
            // colCong_viec
            // 
            this.colCong_viec.Caption = "Công việc";
            this.colCong_viec.Name = "colCong_viec";
            this.colCong_viec.OptionsColumn.AllowEdit = false;
            this.colCong_viec.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colCong_viec.Visible = true;
            this.colCong_viec.VisibleIndex = 0;
            this.colCong_viec.Width = 59;
            // 
            // colLoaiCV
            // 
            this.colLoaiCV.Caption = "Loại công việc";
            this.colLoaiCV.Name = "colLoaiCV";
            this.colLoaiCV.OptionsColumn.AllowEdit = false;
            this.colLoaiCV.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colLoaiCV.Visible = true;
            this.colLoaiCV.VisibleIndex = 1;
            this.colLoaiCV.Width = 92;
            // 
            // colNguoi_giao
            // 
            this.colNguoi_giao.Caption = "Người giao";
            this.colNguoi_giao.Name = "colNguoi_giao";
            this.colNguoi_giao.OptionsColumn.AllowEdit = false;
            this.colNguoi_giao.Width = 63;
            // 
            // colNguoi_TH
            // 
            this.colNguoi_TH.Caption = "Người thực hiện";
            this.colNguoi_TH.Name = "colNguoi_TH";
            this.colNguoi_TH.OptionsColumn.AllowEdit = false;
            this.colNguoi_TH.Visible = true;
            this.colNguoi_TH.VisibleIndex = 2;
            this.colNguoi_TH.Width = 88;
            // 
            // colDo_UT
            // 
            this.colDo_UT.Caption = "Độ ưu tiên";
            this.colDo_UT.Name = "colDo_UT";
            this.colDo_UT.OptionsColumn.AllowEdit = false;
            this.colDo_UT.Visible = true;
            this.colDo_UT.VisibleIndex = 7;
            this.colDo_UT.Width = 63;
            // 
            // colNgay_bat_dau
            // 
            this.colNgay_bat_dau.Caption = "Ngày bắt đầu";
            this.colNgay_bat_dau.Name = "colNgay_bat_dau";
            this.colNgay_bat_dau.OptionsColumn.AllowEdit = false;
            this.colNgay_bat_dau.Visible = true;
            this.colNgay_bat_dau.VisibleIndex = 4;
            this.colNgay_bat_dau.Width = 77;
            // 
            // colNgay_ket_thucDuKien
            // 
            this.colNgay_ket_thucDuKien.Caption = "Ngày kết thúc dự kiến";
            this.colNgay_ket_thucDuKien.Name = "colNgay_ket_thucDuKien";
            this.colNgay_ket_thucDuKien.OptionsColumn.AllowEdit = false;
            this.colNgay_ket_thucDuKien.Width = 117;
            // 
            // colTG_DT
            // 
            this.colTG_DT.Caption = "Thời gian dự kiến";
            this.colTG_DT.Name = "colTG_DT";
            this.colTG_DT.OptionsColumn.AllowEdit = false;
            this.colTG_DT.Visible = true;
            this.colTG_DT.VisibleIndex = 5;
            this.colTG_DT.Width = 93;
            // 
            // cotNgayKT
            // 
            this.cotNgayKT.Caption = "Ngày kết thúc thực tế";
            this.cotNgayKT.Name = "cotNgayKT";
            this.cotNgayKT.OptionsColumn.AllowEdit = false;
            this.cotNgayKT.Visible = true;
            this.cotNgayKT.VisibleIndex = 6;
            this.cotNgayKT.Width = 117;
            // 
            // ColTien_Do
            // 
            this.ColTien_Do.Caption = "Tiến độ";
            this.ColTien_Do.Name = "ColTien_Do";
            this.ColTien_Do.OptionsColumn.AllowEdit = false;
            this.ColTien_Do.Visible = true;
            this.ColTien_Do.VisibleIndex = 3;
            this.ColTien_Do.Width = 47;
            // 
            // colTinh_trang
            // 
            this.colTinh_trang.Caption = "Tình trạng";
            this.colTinh_trang.Name = "colTinh_trang";
            this.colTinh_trang.OptionsColumn.AllowEdit = false;
            this.colTinh_trang.Visible = true;
            this.colTinh_trang.VisibleIndex = 8;
            this.colTinh_trang.Width = 61;
            // 
            // gridControlCongviec
            // 
            this.gridControlCongviec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlCongviec.BackgroundImage")));
            this.gridControlCongviec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlCongviec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCongviec.Location = new System.Drawing.Point(0, 0);
            this.gridControlCongviec.MainView = this.gridViewCongviec;
            this.gridControlCongviec.Name = "gridControlCongviec";
            this.gridControlCongviec.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2});
            this.gridControlCongviec.Size = new System.Drawing.Size(1021, 237);
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
            this.gridColumn1,
            this.CotCongViec,
            this.CotLoaiCongViec,
            this.CotNguoiGiao,
            this.CotNguoiThucHien,
            this.CotDoUuTien,
            this.CotBatDau,
            this.CotNgayKetThuc,
            this.CotTGDuTinh,
            this.CotTienDo,
            this.CotTinhTrang,
            this.cotxoa,
            this.cotxoa1});
            this.gridViewCongviec.GridControl = this.gridControlCongviec;
            this.gridViewCongviec.GroupPanelText = "DANH SÁCH DỰ ÁN";
            this.gridViewCongviec.IndicatorWidth = 40;
            this.gridViewCongviec.Name = "gridViewCongviec";
            this.gridViewCongviec.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewCongviec.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewCongviec.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewCongviec.OptionsPrint.UsePrintStyles = true;
            this.gridViewCongviec.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewCongviec.OptionsSelection.MultiSelect = true;
            this.gridViewCongviec.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridViewCongviec.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewCongviec.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewCongviec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewCongviec.OptionsView.RowAutoHeight = true;
            this.gridViewCongviec.OptionsView.ShowFooter = true;
            this.gridViewCongviec.OptionsView.ShowGroupedColumns = true;
            this.gridViewCongviec.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "DU_AN_ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 71;
            // 
            // CotCongViec
            // 
            this.CotCongViec.Caption = "Công việc";
            this.CotCongViec.FieldName = "CONG_VIEC";
            this.CotCongViec.Name = "CotCongViec";
            this.CotCongViec.OptionsColumn.AllowEdit = false;
            this.CotCongViec.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.CotCongViec.OptionsColumn.ReadOnly = true;
            this.CotCongViec.Visible = true;
            this.CotCongViec.VisibleIndex = 0;
            this.CotCongViec.Width = 59;
            // 
            // CotLoaiCongViec
            // 
            this.CotLoaiCongViec.Caption = "Loại công việc";
            this.CotLoaiCongViec.FieldName = "CONGVIEC";
            this.CotLoaiCongViec.Name = "CotLoaiCongViec";
            this.CotLoaiCongViec.OptionsColumn.AllowEdit = false;
            this.CotLoaiCongViec.OptionsColumn.ReadOnly = true;
            this.CotLoaiCongViec.Visible = true;
            this.CotLoaiCongViec.VisibleIndex = 1;
            this.CotLoaiCongViec.Width = 79;
            // 
            // CotNguoiGiao
            // 
            this.CotNguoiGiao.AppearanceHeader.Options.UseTextOptions = true;
            this.CotNguoiGiao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CotNguoiGiao.Caption = "Người giao";
            this.CotNguoiGiao.FieldName = "NGUOIGIAO";
            this.CotNguoiGiao.Name = "CotNguoiGiao";
            this.CotNguoiGiao.OptionsColumn.AllowEdit = false;
            this.CotNguoiGiao.OptionsColumn.ReadOnly = true;
            this.CotNguoiGiao.Visible = true;
            this.CotNguoiGiao.VisibleIndex = 2;
            this.CotNguoiGiao.Width = 63;
            // 
            // CotNguoiThucHien
            // 
            this.CotNguoiThucHien.Caption = "Người thực hiện";
            this.CotNguoiThucHien.FieldName = "TENNHANVIEN";
            this.CotNguoiThucHien.Name = "CotNguoiThucHien";
            this.CotNguoiThucHien.OptionsColumn.AllowEdit = false;
            this.CotNguoiThucHien.OptionsColumn.ReadOnly = true;
            this.CotNguoiThucHien.Visible = true;
            this.CotNguoiThucHien.VisibleIndex = 3;
            this.CotNguoiThucHien.Width = 88;
            // 
            // CotDoUuTien
            // 
            this.CotDoUuTien.AppearanceCell.Options.UseTextOptions = true;
            this.CotDoUuTien.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CotDoUuTien.Caption = "Độ ưu tiên";
            this.CotDoUuTien.FieldName = "TEN_MUC_UU_TIEN";
            this.CotDoUuTien.Name = "CotDoUuTien";
            this.CotDoUuTien.OptionsColumn.AllowEdit = false;
            this.CotDoUuTien.OptionsColumn.ReadOnly = true;
            this.CotDoUuTien.Visible = true;
            this.CotDoUuTien.VisibleIndex = 4;
            this.CotDoUuTien.Width = 63;
            // 
            // CotBatDau
            // 
            this.CotBatDau.AppearanceCell.Options.UseTextOptions = true;
            this.CotBatDau.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CotBatDau.AppearanceHeader.Options.UseTextOptions = true;
            this.CotBatDau.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CotBatDau.Caption = "Ngày bắt đầu";
            this.CotBatDau.FieldName = "NGAY_BAT_DAU";
            this.CotBatDau.Name = "CotBatDau";
            this.CotBatDau.OptionsColumn.AllowEdit = false;
            this.CotBatDau.OptionsColumn.ReadOnly = true;
            this.CotBatDau.Visible = true;
            this.CotBatDau.VisibleIndex = 5;
            this.CotBatDau.Width = 77;
            // 
            // CotNgayKetThuc
            // 
            this.CotNgayKetThuc.AppearanceCell.Options.UseTextOptions = true;
            this.CotNgayKetThuc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CotNgayKetThuc.AppearanceHeader.Options.UseTextOptions = true;
            this.CotNgayKetThuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CotNgayKetThuc.Caption = "Ngày kết thúc";
            this.CotNgayKetThuc.FieldName = "NGAY_KET_THUC";
            this.CotNgayKetThuc.Name = "CotNgayKetThuc";
            this.CotNgayKetThuc.OptionsColumn.AllowEdit = false;
            this.CotNgayKetThuc.OptionsColumn.ReadOnly = true;
            this.CotNgayKetThuc.Visible = true;
            this.CotNgayKetThuc.VisibleIndex = 6;
            this.CotNgayKetThuc.Width = 79;
            // 
            // CotTGDuTinh
            // 
            this.CotTGDuTinh.AppearanceCell.Options.UseTextOptions = true;
            this.CotTGDuTinh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CotTGDuTinh.Caption = "Thời gian dự tính";
            this.CotTGDuTinh.FieldName = "NGAY_KET_THUC_DU_KIEN";
            this.CotTGDuTinh.Name = "CotTGDuTinh";
            this.CotTGDuTinh.OptionsColumn.AllowEdit = false;
            this.CotTGDuTinh.OptionsColumn.ReadOnly = true;
            this.CotTGDuTinh.Visible = true;
            this.CotTGDuTinh.VisibleIndex = 7;
            this.CotTGDuTinh.Width = 92;
            // 
            // CotTienDo
            // 
            this.CotTienDo.AppearanceCell.Options.UseTextOptions = true;
            this.CotTienDo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CotTienDo.Caption = "Tiến độ công việc";
            this.CotTienDo.FieldName = "TIEN_DO";
            this.CotTienDo.Name = "CotTienDo";
            this.CotTienDo.OptionsColumn.AllowEdit = false;
            this.CotTienDo.OptionsColumn.ReadOnly = true;
            this.CotTienDo.Visible = true;
            this.CotTienDo.VisibleIndex = 8;
            this.CotTienDo.Width = 95;
            // 
            // CotTinhTrang
            // 
            this.CotTinhTrang.Caption = "Tình trạng";
            this.CotTinhTrang.FieldName = "TT";
            this.CotTinhTrang.Name = "CotTinhTrang";
            this.CotTinhTrang.OptionsColumn.AllowEdit = false;
            this.CotTinhTrang.OptionsColumn.ReadOnly = true;
            this.CotTinhTrang.Visible = true;
            this.CotTinhTrang.VisibleIndex = 9;
            this.CotTinhTrang.Width = 61;
            // 
            // cotxoa
            // 
            this.cotxoa.Caption = "gridColumn2";
            this.cotxoa.FieldName = "PCCV_ID";
            this.cotxoa.Name = "cotxoa";
            this.cotxoa.Width = 71;
            // 
            // cotxoa1
            // 
            this.cotxoa1.ColumnEdit = this.repositoryItemButtonEdit2;
            this.cotxoa1.Name = "cotxoa1";
            this.cotxoa1.Visible = true;
            this.cotxoa1.VisibleIndex = 10;
            this.cotxoa1.Width = 28;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // xtraTabPageTai_Lieu
            // 
            this.xtraTabPageTai_Lieu.Controls.Add(this.gridControlTaiLieu);
            this.xtraTabPageTai_Lieu.Name = "xtraTabPageTai_Lieu";
            this.xtraTabPageTai_Lieu.Size = new System.Drawing.Size(1021, 237);
            this.xtraTabPageTai_Lieu.Text = "Danh sách tài liệu";
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
            this.repositoryItemPictureEdit1,
            this.rep_sua});
            this.gridControlTaiLieu.Size = new System.Drawing.Size(1021, 237);
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
            this.lvSize,
            this.lvNguoiCapNhat,
            this.lvNgayCapNhat,
            this.lvGhi_chu});
            this.layoutView1.GridControl = this.gridControlTaiLieu;
            this.layoutView1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn2,
            this.Item7,
            this.layoutViewField_cot_xoa,
            this.layoutViewField_cot_suafile,
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
            this.cot_xoa.ColumnEdit = this.repositoryItemPictureEdit1;
            this.cot_xoa.LayoutViewField = this.layoutViewField_cot_xoa;
            this.cot_xoa.Name = "cot_xoa";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // layoutViewField_cot_xoa
            // 
            this.layoutViewField_cot_xoa.EditorPreferredWidth = 238;
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
            this.layoutViewField_cot_suafile.EditorPreferredWidth = 20;
            this.layoutViewField_cot_suafile.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_cot_suafile.MaxSize = new System.Drawing.Size(29, 26);
            this.layoutViewField_cot_suafile.MinSize = new System.Drawing.Size(29, 26);
            this.layoutViewField_cot_suafile.Name = "layoutViewField_cot_suafile";
            this.layoutViewField_cot_suafile.Size = new System.Drawing.Size(194, 170);
            this.layoutViewField_cot_suafile.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_cot_suafile.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_cot_suafile.TextToControlDistance = 0;
            this.layoutViewField_cot_suafile.TextVisible = false;
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
            this.item1});
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
            this.item6});
            this.Group1.Location = new System.Drawing.Point(0, 100);
            this.Group1.Name = "Group1";
            this.Group1.Size = new System.Drawing.Size(194, 70);
            this.Group1.Text = "Thao tác";
            // 
            // item6
            // 
            this.item6.CustomizationFormText = "item6";
            this.item6.Location = new System.Drawing.Point(60, 0);
            this.item6.Name = "item6";
            this.item6.Size = new System.Drawing.Size(110, 26);
            this.item6.Text = "item6";
            this.item6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
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
            this.item3.Location = new System.Drawing.Point(0, 37);
            this.item3.Name = "item3";
            this.item3.Size = new System.Drawing.Size(81, 23);
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
            // item1
            // 
            this.item1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item1.AppearanceItemCaption.Options.UseFont = true;
            this.item1.CustomizationFormText = "Độ lớn(KB):";
            this.item1.Location = new System.Drawing.Point(0, 20);
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(81, 17);
            this.item1.Text = "Độ lớn(KB):";
            this.item1.TextSize = new System.Drawing.Size(55, 13);
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
            this.gridColumn2,
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
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn1";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 71;
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
            this.xtraTabPageNhatKy.Controls.Add(this.gridControlNhatKyDA);
            this.xtraTabPageNhatKy.Name = "xtraTabPageNhatKy";
            this.xtraTabPageNhatKy.Size = new System.Drawing.Size(1021, 237);
            this.xtraTabPageNhatKy.Text = "Danh sách nhật ký";
            // 
            // gridControlNhatKyDA
            // 
            this.gridControlNhatKyDA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlNhatKyDA.Location = new System.Drawing.Point(0, 0);
            this.gridControlNhatKyDA.MainView = this.gridViewNhatKyDA;
            this.gridControlNhatKyDA.Name = "gridControlNhatKyDA";
            this.gridControlNhatKyDA.Size = new System.Drawing.Size(1021, 237);
            this.gridControlNhatKyDA.TabIndex = 2;
            this.gridControlNhatKyDA.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNhatKyDA,
            this.gridView5});
            // 
            // gridViewNhatKyDA
            // 
            this.gridViewNhatKyDA.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNguoiCapNhat,
            this.colTGCapNhat,
            this.colNoiDung});
            this.gridViewNhatKyDA.GridControl = this.gridControlNhatKyDA;
            this.gridViewNhatKyDA.Name = "gridViewNhatKyDA";
            this.gridViewNhatKyDA.OptionsBehavior.Editable = false;
            this.gridViewNhatKyDA.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewNhatKyDA.OptionsView.ShowGroupPanel = false;
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
            this.gridView5.GridControl = this.gridControlNhatKyDA;
            this.gridView5.Name = "gridView5";
            // 
            // popupControlContainerFilter
            // 
            this.popupControlContainerFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainerFilter.Controls.Add(this.NhanVien);
            this.popupControlContainerFilter.Controls.Add(this.mruEditTenDuAn);
            this.popupControlContainerFilter.Controls.Add(this.plLabel3);
            this.popupControlContainerFilter.Controls.Add(this.chkEditCV_KH);
            this.popupControlContainerFilter.Controls.Add(this.ngayBD);
            this.popupControlContainerFilter.Controls.Add(this.plLabel2);
            this.popupControlContainerFilter.Controls.Add(this.plLabel1);
            this.popupControlContainerFilter.Controls.Add(this.mucuutien);
            this.popupControlContainerFilter.Controls.Add(this.tintrang);
            this.popupControlContainerFilter.Controls.Add(this.LoaiCV);
            this.popupControlContainerFilter.Controls.Add(this.LoaiDA);
            this.popupControlContainerFilter.Controls.Add(this.labelControl5);
            this.popupControlContainerFilter.Controls.Add(this.labelControl4);
            this.popupControlContainerFilter.Controls.Add(this.labelControl6);
            this.popupControlContainerFilter.Controls.Add(this.labelControl3);
            this.popupControlContainerFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupControlContainerFilter.Location = new System.Drawing.Point(0, 24);
            this.popupControlContainerFilter.Manager = this.barManager1;
            this.popupControlContainerFilter.Name = "popupControlContainerFilter";
            this.popupControlContainerFilter.Size = new System.Drawing.Size(1028, 95);
            this.popupControlContainerFilter.TabIndex = 0;
            this.popupControlContainerFilter.Visible = false;
            // 
            // NhanVien
            // 
            this.NhanVien.Location = new System.Drawing.Point(562, 65);
            this.NhanVien.Name = "NhanVien";
            this.NhanVien.Size = new System.Drawing.Size(223, 20);
            this.NhanVien.TabIndex = 6;
            // 
            // mruEditTenDuAn
            // 
            this.mruEditTenDuAn.Location = new System.Drawing.Point(86, 11);
            this.mruEditTenDuAn.MenuManager = this.barManager1;
            this.mruEditTenDuAn.Name = "mruEditTenDuAn";
            this.mruEditTenDuAn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.mruEditTenDuAn.Size = new System.Drawing.Size(352, 20);
            this.mruEditTenDuAn.TabIndex = 0;
            // 
            // plLabel3
            // 
            this.plLabel3.Location = new System.Drawing.Point(11, 15);
            this.plLabel3.Name = "plLabel3";
            this.plLabel3.Size = new System.Drawing.Size(49, 13);
            this.plLabel3.TabIndex = 94;
            this.plLabel3.Text = "Tên dự án";
            this.plLabel3.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // chkEditCV_KH
            // 
            this.chkEditCV_KH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEditCV_KH.Location = new System.Drawing.Point(923, 11);
            this.chkEditCV_KH.MenuManager = this.barManager1;
            this.chkEditCV_KH.Name = "chkEditCV_KH";
            this.chkEditCV_KH.Properties.Caption = "Khách hàng";
            this.chkEditCV_KH.Size = new System.Drawing.Size(84, 19);
            this.chkEditCV_KH.TabIndex = 7;
            // 
            // ngayBD
            // 
            this.ngayBD.Caption = "Năm 2010 và 2011";
            this.ngayBD.Default = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromYearToYear;
            this.ngayBD.FirstFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayBD.FirstTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayBD.FromDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayBD.Location = new System.Drawing.Point(562, 38);
            this.ngayBD.Name = "ngayBD";
            this.ngayBD.ReturnType = ProtocolVN.Framework.Win.Trial.TimeType.Date;
            this.ngayBD.SecondFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayBD.SecondTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayBD.SelectedType = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromYearToYear;
            this.ngayBD.Size = new System.Drawing.Size(226, 21);
            this.ngayBD.TabIndex = 5;
            this.ngayBD.ToDate = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayBD.Types = ((ProtocolVN.Framework.Win.Trial.SelectionTypes)(((((((((ProtocolVN.Framework.Win.Trial.SelectionTypes.OneDate | ProtocolVN.Framework.Win.Trial.SelectionTypes.OneMonth)
                        | ProtocolVN.Framework.Win.Trial.SelectionTypes.OneQuarter)
                        | ProtocolVN.Framework.Win.Trial.SelectionTypes.OneYear)
                        | ProtocolVN.Framework.Win.Trial.SelectionTypes.SixMonths)
                        | ProtocolVN.Framework.Win.Trial.SelectionTypes.FromDateToDate)
                        | ProtocolVN.Framework.Win.Trial.SelectionTypes.FromMonthToMonth)
                        | ProtocolVN.Framework.Win.Trial.SelectionTypes.FromQuarterToQuarter)
                        | ProtocolVN.Framework.Win.Trial.SelectionTypes.FromYearToYear)));
            // 
            // plLabel2
            // 
            this.plLabel2.Location = new System.Drawing.Point(465, 69);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(66, 13);
            this.plLabel2.TabIndex = 93;
            this.plLabel2.Text = "Người quản lý";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(465, 42);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(91, 13);
            this.plLabel1.TabIndex = 92;
            this.plLabel1.Text = "Thời gian thực hiện";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // mucuutien
            // 
            this.mucuutien.DataSource = null;
            this.mucuutien.DisplayField = null;
            this.mucuutien.Location = new System.Drawing.Point(304, 38);
            this.mucuutien.Name = "mucuutien";
            this.mucuutien.Size = new System.Drawing.Size(134, 20);
            this.mucuutien.TabIndex = 3;
            this.mucuutien.ValueField = "";
            // 
            // tintrang
            // 
            this.tintrang.DataSource = null;
            this.tintrang.DisplayField = null;
            this.tintrang.Location = new System.Drawing.Point(304, 65);
            this.tintrang.Name = "tintrang";
            this.tintrang.Size = new System.Drawing.Size(134, 20);
            this.tintrang.TabIndex = 4;
            this.tintrang.ValueField = "";
            // 
            // LoaiCV
            // 
            this.LoaiCV.DataSource = null;
            this.LoaiCV.DisplayField = null;
            this.LoaiCV.Enabled = false;
            this.LoaiCV.Location = new System.Drawing.Point(85, 65);
            this.LoaiCV.Name = "LoaiCV";
            this.LoaiCV.Size = new System.Drawing.Size(142, 20);
            this.LoaiCV.TabIndex = 2;
            this.LoaiCV.ValueField = "";
            // 
            // LoaiDA
            // 
            this.LoaiDA.DataSource = null;
            this.LoaiDA.DisplayField = null;
            this.LoaiDA.Location = new System.Drawing.Point(86, 38);
            this.LoaiDA.Name = "LoaiDA";
            this.LoaiDA.Size = new System.Drawing.Size(141, 20);
            this.LoaiDA.TabIndex = 1;
            this.LoaiDA.ValueField = "";
            this.LoaiDA.SelectedIndexChanged += new System.EventHandler(this.LoaiDA_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(247, 69);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(49, 13);
            this.labelControl5.TabIndex = 91;
            this.labelControl5.Text = "Tình trạng";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(247, 42);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 13);
            this.labelControl4.TabIndex = 91;
            this.labelControl4.Text = "Độ ưu tiên";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(11, 69);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(67, 13);
            this.labelControl6.TabIndex = 34;
            this.labelControl6.Text = "Loại công việc";
            this.labelControl6.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 42);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 13);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "Loại dự án";
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
            // frmDuAnQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 517);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.popupControlContainerFilter);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDuAnQL";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý dự án";
            this.Load += new System.EventHandler(this.frmDuAnQL_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThongTinLienHe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThongTinLienHe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCongviec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCongviec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.xtraTabPageTai_Lieu.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_xoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_sua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_suafile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaiLieu)).EndInit();
            this.xtraTabPageNhatKy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNhatKyDA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhatKyDA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).EndInit();
            this.popupControlContainerFilter.ResumeLayout(false);
            this.popupControlContainerFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mruEditTenDuAn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditCV_KH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
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
        
        private DevExpress.XtraTab.XtraTabPage XtraTabPageDetail;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barbuttonCapNhatTienDo;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiDA;
        private DevExpress.XtraGrid.Columns.GridColumn colTen_DA;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoi_QL;
        private DevExpress.XtraGrid.Columns.GridColumn colNgay_BD_DA;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayKT_DA_DuKien;
        private DevExpress.XtraGrid.Columns.GridColumn colT_trang;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageTai_Lieu;
        private DevExpress.XtraGrid.Columns.GridColumn codT_do_DA;
        private DevExpress.XtraGrid.Columns.GridColumn colMuc_UT;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        public DevExpress.XtraGrid.GridControl gridControlCongviec;
        public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewCongviec;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn CotCongViec;
        private DevExpress.XtraGrid.Columns.GridColumn CotLoaiCongViec;
        private DevExpress.XtraGrid.Columns.GridColumn CotNguoiGiao;
        private DevExpress.XtraGrid.Columns.GridColumn CotNguoiThucHien;
        private DevExpress.XtraGrid.Columns.GridColumn CotDoUuTien;
        private DevExpress.XtraGrid.Columns.GridColumn CotBatDau;
        private DevExpress.XtraGrid.Columns.GridColumn CotNgayKetThuc;
        private DevExpress.XtraGrid.Columns.GridColumn CotTGDuTinh;
        private DevExpress.XtraGrid.Columns.GridColumn CotTienDo;
        private DevExpress.XtraGrid.Columns.GridColumn CotTinhTrang;
        private DevExpress.XtraGrid.Columns.GridColumn cotxoa;
        private DevExpress.XtraGrid.Columns.GridColumn cotxoa1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        public DevExpress.XtraGrid.GridControl gridControlThongTinLienHe;
        public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewThongTinLienHe;
        private DevExpress.XtraGrid.Columns.GridColumn colCong_viec;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiCV;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoi_giao;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoi_TH;
        private DevExpress.XtraGrid.Columns.GridColumn colDo_UT;
        private DevExpress.XtraGrid.Columns.GridColumn colNgay_bat_dau;
        private DevExpress.XtraGrid.Columns.GridColumn colNgay_ket_thucDuKien;
        private DevExpress.XtraGrid.Columns.GridColumn colTG_DT;
        private DevExpress.XtraGrid.Columns.GridColumn ColTien_Do;
        private DevExpress.XtraGrid.Columns.GridColumn colTinh_trang;
        private PLCombobox LoaiDA;
        private PLImgCombobox mucuutien;
        private PLImgCombobox tintrang;
        private PLCombobox LoaiCV;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PLLabel labelControl6;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel plLabel2;
        private System.Windows.Forms.PLLabel plLabel1;
        private ProtocolVN.Framework.Win.Office.PLDateSelection ngayBD;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageNhatKy;
        private DevExpress.XtraGrid.GridControl gridControlNhatKyDA;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNhatKyDA;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiCapNhat;
        private DevExpress.XtraGrid.Columns.GridColumn colTGCapNhat;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiDung;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn cotNgayKT;
        private DevExpress.XtraGrid.Columns.GridColumn cotNgayKetThucTT;
        private DevExpress.XtraGrid.GridControl gridControlTaiLieu;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lv_anh_default;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvNoi_dung;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cot_mofile;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rep_mofile;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cot_luufile;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rep_luufile;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cot_xoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cot_suafile;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rep_sua;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvNguoiCapNhat;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvNgayCapNhat;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvTieuDe;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvFile_dinh_kem;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvGhi_chu;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn cotxoa2;
        private CheckEdit chkEditCV_KH;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKhachHang;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvSize;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item7;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_mofile_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_luufile_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_xoa;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_suafile;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_5;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_4;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.LayoutControlGroup Group1;
        private DevExpress.XtraLayout.SimpleSeparator item6;
        private DevExpress.XtraLayout.SimpleLabelItem item2;
        private DevExpress.XtraLayout.SimpleLabelItem item3;
        private DevExpress.XtraLayout.SimpleLabelItem item4;
        private DevExpress.XtraLayout.SimpleLabelItem item5;
        private DevExpress.XtraLayout.SimpleLabelItem item1;
        private System.Windows.Forms.PLLabel plLabel3;
        private MRUEdit mruEditTenDuAn;
        public PLDMTreeGroup NhanVien;
    }
}