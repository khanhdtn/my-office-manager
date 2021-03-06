using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
namespace pl.office.form
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
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
            this.colNgayKT_DA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT_trang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.codT_do_DA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colNgay_ket_thuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTG_DT = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.layoutViewColumn1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colfile = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.Item1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colghichu = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.Item7 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.coltieude = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.Item6 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.coltenfile = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.Item2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colmofile = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rep_mofile = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.Item8 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cot_luu_file = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rep_luu_file = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_layoutViewColumn1_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.repositoryItemButtonEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemButtonEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemMemoExEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.popupControlContainerFilter = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.KetThucDen = new DevExpress.XtraEditors.DateEdit();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.KetThucTu = new DevExpress.XtraEditors.DateEdit();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.mucuutien = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.tintrang = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.LoaiCV = new ProtocolVN.Framework.Win.PLCombobox();
            this.LoaiDA = new ProtocolVN.Framework.Win.PLCombobox();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.denngay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl6 = new System.Windows.Forms.PLLabel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.Tungay = new DevExpress.XtraEditors.DateEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imageList_layout = new System.Windows.Forms.ImageList(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_mofile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_luu_file)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).BeginInit();
            this.popupControlContainerFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KetThucDen.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KetThucDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KetThucTu.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KetThucTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tungay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tungay.Properties)).BeginInit();
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
            this.barSubItem1.Caption = "Nghiệp vụ";
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
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 87);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlMaster);
            this.splitContainerControl1.Panel1.MinSize = 126;
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlDetail);
            this.splitContainerControl1.Panel2.MinSize = 246;
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(998, 410);
            this.splitContainerControl1.SplitterPosition = 175;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControlMaster
            // 
            this.gridControlMaster.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlMaster.BackgroundImage")));
            this.gridControlMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode2.RelationName = "Level1";
            this.gridControlMaster.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridControlMaster.Location = new System.Drawing.Point(0, 0);
            this.gridControlMaster.MainView = this.gridViewMaster;
            this.gridControlMaster.Name = "gridControlMaster";
            this.gridControlMaster.Size = new System.Drawing.Size(998, 158);
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
            this.colNgayKT_DA,
            this.colT_trang,
            this.codT_do_DA,
            this.id});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupCount = 1;
            this.gridViewMaster.GroupPanelText = "Danh sách thỏa điều kiện tìm kiếm";
            this.gridViewMaster.IndicatorWidth = 40;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewMaster.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewMaster.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewMaster.OptionsSelection.MultiSelect = true;
            this.gridViewMaster.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridViewMaster.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMaster.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewMaster.OptionsView.RowAutoHeight = true;
            this.gridViewMaster.OptionsView.ShowFooter = true;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = true;
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
            this.colNguoi_QL.Caption = "Nhân viên";
            this.colNguoi_QL.Name = "colNguoi_QL";
            this.colNguoi_QL.Visible = true;
            this.colNguoi_QL.VisibleIndex = 2;
            this.colNguoi_QL.Width = 60;
            // 
            // colMuc_UT
            // 
            this.colMuc_UT.Caption = "Độ ưu tiên";
            this.colMuc_UT.Name = "colMuc_UT";
            this.colMuc_UT.Visible = true;
            this.colMuc_UT.VisibleIndex = 5;
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
            // colNgayKT_DA
            // 
            this.colNgayKT_DA.Caption = "Ngày kết thúc";
            this.colNgayKT_DA.Name = "colNgayKT_DA";
            this.colNgayKT_DA.Visible = true;
            this.colNgayKT_DA.VisibleIndex = 4;
            this.colNgayKT_DA.Width = 79;
            // 
            // colT_trang
            // 
            this.colT_trang.Caption = "Tình trạng";
            this.colT_trang.Name = "colT_trang";
            this.colT_trang.Visible = true;
            this.colT_trang.VisibleIndex = 6;
            this.colT_trang.Width = 61;
            // 
            // codT_do_DA
            // 
            this.codT_do_DA.Caption = "Tiến độ";
            this.codT_do_DA.Name = "codT_do_DA";
            this.codT_do_DA.Visible = true;
            this.codT_do_DA.VisibleIndex = 7;
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
            // xtraTabControlDetail
            // 
            this.xtraTabControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlDetail.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlDetail.Name = "xtraTabControlDetail";
            this.xtraTabControlDetail.SelectedTabPage = this.XtraTabPageDetail;
            this.xtraTabControlDetail.Size = new System.Drawing.Size(998, 246);
            this.xtraTabControlDetail.TabIndex = 0;
            this.xtraTabControlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.XtraTabPageDetail,
            this.xtraTabPageTai_Lieu});
            // 
            // XtraTabPageDetail
            // 
            this.XtraTabPageDetail.Controls.Add(this.gridControlThongTinLienHe);
            this.XtraTabPageDetail.Controls.Add(this.gridControlCongviec);
            this.XtraTabPageDetail.Name = "XtraTabPageDetail";
            this.XtraTabPageDetail.Size = new System.Drawing.Size(991, 217);
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
            this.gridControlThongTinLienHe.Size = new System.Drawing.Size(991, 217);
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
            this.colNgay_ket_thuc,
            this.colTG_DT,
            this.ColTien_Do,
            this.colTinh_trang});
            this.gridViewThongTinLienHe.GridControl = this.gridControlThongTinLienHe;
            this.gridViewThongTinLienHe.IndicatorWidth = 40;
            this.gridViewThongTinLienHe.Name = "gridViewThongTinLienHe";
            this.gridViewThongTinLienHe.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewThongTinLienHe.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewThongTinLienHe.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewThongTinLienHe.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewThongTinLienHe.OptionsSelection.MultiSelect = true;
            this.gridViewThongTinLienHe.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridViewThongTinLienHe.OptionsView.ColumnAutoWidth = false;
            this.gridViewThongTinLienHe.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewThongTinLienHe.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewThongTinLienHe.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewThongTinLienHe.OptionsView.RowAutoHeight = true;
            this.gridViewThongTinLienHe.OptionsView.ShowFooter = true;
            this.gridViewThongTinLienHe.OptionsView.ShowGroupedColumns = true;
            this.gridViewThongTinLienHe.OptionsView.ShowGroupPanel = false;
            // 
            // colCong_viec
            // 
            this.colCong_viec.Caption = "Công việc";
            this.colCong_viec.Name = "colCong_viec";
            this.colCong_viec.OptionsColumn.AllowEdit = false;
            this.colCong_viec.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colCong_viec.Visible = true;
            this.colCong_viec.VisibleIndex = 0;
            this.colCong_viec.Width = 71;
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
            this.colNguoi_giao.Visible = true;
            this.colNguoi_giao.VisibleIndex = 2;
            this.colNguoi_giao.Width = 63;
            // 
            // colNguoi_TH
            // 
            this.colNguoi_TH.Caption = "Người thực hiện";
            this.colNguoi_TH.Name = "colNguoi_TH";
            this.colNguoi_TH.OptionsColumn.AllowEdit = false;
            this.colNguoi_TH.Visible = true;
            this.colNguoi_TH.VisibleIndex = 3;
            this.colNguoi_TH.Width = 88;
            // 
            // colDo_UT
            // 
            this.colDo_UT.Caption = "Độ ưu tiên";
            this.colDo_UT.Name = "colDo_UT";
            this.colDo_UT.OptionsColumn.AllowEdit = false;
            this.colDo_UT.Visible = true;
            this.colDo_UT.VisibleIndex = 4;
            this.colDo_UT.Width = 63;
            // 
            // colNgay_bat_dau
            // 
            this.colNgay_bat_dau.Caption = "Ngày bắt đầu";
            this.colNgay_bat_dau.Name = "colNgay_bat_dau";
            this.colNgay_bat_dau.OptionsColumn.AllowEdit = false;
            this.colNgay_bat_dau.Visible = true;
            this.colNgay_bat_dau.VisibleIndex = 5;
            this.colNgay_bat_dau.Width = 77;
            // 
            // colNgay_ket_thuc
            // 
            this.colNgay_ket_thuc.Caption = "Ngày kết thúc";
            this.colNgay_ket_thuc.Name = "colNgay_ket_thuc";
            this.colNgay_ket_thuc.OptionsColumn.AllowEdit = false;
            this.colNgay_ket_thuc.Visible = true;
            this.colNgay_ket_thuc.VisibleIndex = 6;
            this.colNgay_ket_thuc.Width = 79;
            // 
            // colTG_DT
            // 
            this.colTG_DT.Caption = "Thời gian dự tính";
            this.colTG_DT.Name = "colTG_DT";
            this.colTG_DT.OptionsColumn.AllowEdit = false;
            this.colTG_DT.Visible = true;
            this.colTG_DT.VisibleIndex = 7;
            this.colTG_DT.Width = 92;
            // 
            // ColTien_Do
            // 
            this.ColTien_Do.Caption = "Tiến độ công việc";
            this.ColTien_Do.Name = "ColTien_Do";
            this.ColTien_Do.OptionsColumn.AllowEdit = false;
            this.ColTien_Do.Visible = true;
            this.ColTien_Do.VisibleIndex = 8;
            this.ColTien_Do.Width = 95;
            // 
            // colTinh_trang
            // 
            this.colTinh_trang.Caption = "Tình trạng";
            this.colTinh_trang.Name = "colTinh_trang";
            this.colTinh_trang.OptionsColumn.AllowEdit = false;
            this.colTinh_trang.Visible = true;
            this.colTinh_trang.VisibleIndex = 9;
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
            this.gridControlCongviec.Size = new System.Drawing.Size(991, 217);
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
            this.gridViewCongviec.GroupPanelText = "Danh sách thỏa điều kiện tìm kiếm";
            this.gridViewCongviec.IndicatorWidth = 40;
            this.gridViewCongviec.Name = "gridViewCongviec";
            this.gridViewCongviec.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewCongviec.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewCongviec.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewCongviec.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewCongviec.OptionsSelection.MultiSelect = true;
            this.gridViewCongviec.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridViewCongviec.OptionsView.ColumnAutoWidth = false;
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
            this.xtraTabPageTai_Lieu.Size = new System.Drawing.Size(991, 217);
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
            this.repositoryItemPictureEdit1,
            this.repositoryItemPictureEdit2,
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoEdit2,
            this.repositoryItemButtonEdit4,
            this.repositoryItemButtonEdit5,
            this.repositoryItemMemoExEdit2,
            this.rep_mofile,
            this.rep_luu_file});
            this.gridControlTaiLieu.Size = new System.Drawing.Size(991, 217);
            this.gridControlTaiLieu.TabIndex = 191;
            this.gridControlTaiLieu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
            this.gridControlTaiLieu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridControlTaiLieu_MouseMove);
            // 
            // layoutView1
            // 
            this.layoutView1.CardHorzInterval = 13;
            this.layoutView1.CardMinSize = new System.Drawing.Size(189, 164);
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.layoutViewColumn1,
            this.colfile,
            this.colghichu,
            this.coltieude,
            this.coltenfile,
            this.colmofile,
            this.cot_luu_file});
            this.layoutView1.GridControl = this.gridControlTaiLieu;
            this.layoutView1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn1});
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.layoutView1.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.layoutView1.OptionsItemText.AlignMode = DevExpress.XtraGrid.Views.Layout.FieldTextAlignMode.AutoSize;
            this.layoutView1.OptionsLayout.Columns.AddNewColumns = false;
            this.layoutView1.OptionsSelection.MultiSelect = true;
            this.layoutView1.OptionsView.AllowHotTrackFields = false;
            this.layoutView1.OptionsView.CardArrangeRule = DevExpress.XtraGrid.Views.Layout.LayoutCardArrangeRule.AllowPartialCards;
            this.layoutView1.OptionsView.ShowCardBorderIfCaptionHidden = false;
            this.layoutView1.OptionsView.ShowCardCaption = false;
            this.layoutView1.OptionsView.ShowCardExpandButton = false;
            this.layoutView1.OptionsView.ShowCardLines = false;
            this.layoutView1.OptionsView.ShowHeaderPanel = false;
            this.layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Row;
            this.layoutView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.coltieude, DevExpress.Data.ColumnSortOrder.Descending)});
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // layoutViewColumn1
            // 
            this.layoutViewColumn1.Caption = "id";
            this.layoutViewColumn1.LayoutViewField = this.layoutViewField_layoutViewColumn1;
            this.layoutViewColumn1.Name = "layoutViewColumn1";
            // 
            // layoutViewField_layoutViewColumn1
            // 
            this.layoutViewField_layoutViewColumn1.EditorPreferredWidth = 10;
            this.layoutViewField_layoutViewColumn1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1.Name = "layoutViewField_layoutViewColumn1";
            this.layoutViewField_layoutViewColumn1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutViewField_layoutViewColumn1.Size = new System.Drawing.Size(189, 164);
            this.layoutViewField_layoutViewColumn1.TextSize = new System.Drawing.Size(97, 13);
            this.layoutViewField_layoutViewColumn1.TextToControlDistance = 5;
            // 
            // colfile
            // 
            this.colfile.Caption = "hinh";
            this.colfile.ColumnEdit = this.repositoryItemPictureEdit1;
            this.colfile.ImageIndex = 1;
            this.colfile.LayoutViewField = this.Item1;
            this.colfile.Name = "colfile";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // Item1
            // 
            this.Item1.EditorPreferredWidth = 97;
            this.Item1.Image = ((System.Drawing.Image)(resources.GetObject("Item1.Image")));
            this.Item1.ImageIndex = 1;
            this.Item1.Location = new System.Drawing.Point(0, 27);
            this.Item1.MaxSize = new System.Drawing.Size(98, 110);
            this.Item1.MinSize = new System.Drawing.Size(98, 110);
            this.Item1.Name = "Item1";
            this.Item1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Item1.Size = new System.Drawing.Size(98, 110);
            this.Item1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.Item1.TextSize = new System.Drawing.Size(0, 0);
            this.Item1.TextToControlDistance = 0;
            this.Item1.TextVisible = false;
            // 
            // colghichu
            // 
            this.colghichu.AppearanceCell.Options.UseTextOptions = true;
            this.colghichu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colghichu.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colghichu.Caption = "ghichu";
            this.colghichu.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colghichu.FieldName = "GHI_CHU";
            this.colghichu.LayoutViewField = this.Item7;
            this.colghichu.Name = "colghichu";
            this.colghichu.OptionsColumn.ReadOnly = true;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // Item7
            // 
            this.Item7.EditorPreferredWidth = 90;
            this.Item7.Location = new System.Drawing.Point(98, 48);
            this.Item7.MaxSize = new System.Drawing.Size(91, 89);
            this.Item7.MinSize = new System.Drawing.Size(91, 89);
            this.Item7.Name = "Item7";
            this.Item7.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Item7.Size = new System.Drawing.Size(91, 89);
            this.Item7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.Item7.TextSize = new System.Drawing.Size(0, 0);
            this.Item7.TextToControlDistance = 0;
            this.Item7.TextVisible = false;
            // 
            // coltieude
            // 
            this.coltieude.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.coltieude.AppearanceCell.Options.UseFont = true;
            this.coltieude.Caption = "tieude";
            this.coltieude.LayoutViewField = this.Item6;
            this.coltieude.Name = "coltieude";
            this.coltieude.OptionsColumn.AllowEdit = false;
            this.coltieude.OptionsColumn.AllowFocus = false;
            // 
            // Item6
            // 
            this.Item6.EditorPreferredWidth = 130;
            this.Item6.Location = new System.Drawing.Point(0, 0);
            this.Item6.Name = "Item6";
            this.Item6.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Item6.Size = new System.Drawing.Size(131, 27);
            this.Item6.TextSize = new System.Drawing.Size(0, 0);
            this.Item6.TextToControlDistance = 0;
            this.Item6.TextVisible = false;
            // 
            // coltenfile
            // 
            this.coltenfile.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.coltenfile.AppearanceCell.Options.UseFont = true;
            this.coltenfile.AppearanceCell.Options.UseTextOptions = true;
            this.coltenfile.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coltenfile.AppearanceCell.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Show;
            this.coltenfile.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.coltenfile.Caption = "tenfile";
            this.coltenfile.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.coltenfile.LayoutViewField = this.Item2;
            this.coltenfile.Name = "coltenfile";
            this.coltenfile.OptionsColumn.AllowEdit = false;
            this.coltenfile.OptionsColumn.AllowFocus = false;
            this.coltenfile.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.coltenfile.OptionsColumn.AllowMove = false;
            this.coltenfile.OptionsColumn.AllowShowHide = false;
            this.coltenfile.OptionsColumn.FixedWidth = true;
            // 
            // Item2
            // 
            this.Item2.EditorPreferredWidth = 188;
            this.Item2.Location = new System.Drawing.Point(0, 137);
            this.Item2.MaxSize = new System.Drawing.Size(189, 27);
            this.Item2.MinSize = new System.Drawing.Size(189, 27);
            this.Item2.Name = "Item2";
            this.Item2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Item2.Size = new System.Drawing.Size(189, 27);
            this.Item2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.Item2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.Item2.TextLocation = DevExpress.Utils.Locations.Bottom;
            this.Item2.TextSize = new System.Drawing.Size(0, 0);
            this.Item2.TextToControlDistance = 0;
            this.Item2.TextVisible = false;
            // 
            // colmofile
            // 
            this.colmofile.Caption = "mofile";
            this.colmofile.ColumnEdit = this.rep_mofile;
            this.colmofile.LayoutViewField = this.Item8;
            this.colmofile.Name = "colmofile";
            // 
            // rep_mofile
            // 
            this.rep_mofile.AppearanceFocused.Image = global::pl.office.Properties.Resources.MenuBar_Refresh;
            this.rep_mofile.AppearanceFocused.Options.UseImage = true;
            this.rep_mofile.Name = "rep_mofile";
            this.rep_mofile.Click += new System.EventHandler(this.rep_mofile_Click);
            // 
            // Item8
            // 
            this.Item8.EditorPreferredWidth = 28;
            this.Item8.Location = new System.Drawing.Point(131, 0);
            this.Item8.Name = "Item8";
            this.Item8.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Item8.Size = new System.Drawing.Size(29, 27);
            this.Item8.TextSize = new System.Drawing.Size(0, 0);
            this.Item8.TextToControlDistance = 0;
            this.Item8.TextVisible = false;
            // 
            // cot_luu_file
            // 
            this.cot_luu_file.Caption = "luufile";
            this.cot_luu_file.ColumnEdit = this.rep_luu_file;
            this.cot_luu_file.ImageIndex = 1;
            this.cot_luu_file.LayoutViewField = this.layoutViewField_layoutViewColumn1_1;
            this.cot_luu_file.Name = "cot_luu_file";
            // 
            // rep_luu_file
            // 
            this.rep_luu_file.Name = "rep_luu_file";
            this.rep_luu_file.Click += new System.EventHandler(this.rep_luu_file_Click_1);
            // 
            // layoutViewField_layoutViewColumn1_1
            // 
            this.layoutViewField_layoutViewColumn1_1.EditorPreferredWidth = 28;
            this.layoutViewField_layoutViewColumn1_1.ImageIndex = 1;
            this.layoutViewField_layoutViewColumn1_1.Location = new System.Drawing.Point(160, 0);
            this.layoutViewField_layoutViewColumn1_1.MaxSize = new System.Drawing.Size(29, 27);
            this.layoutViewField_layoutViewColumn1_1.MinSize = new System.Drawing.Size(29, 27);
            this.layoutViewField_layoutViewColumn1_1.Name = "layoutViewField_layoutViewColumn1_1";
            this.layoutViewField_layoutViewColumn1_1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutViewField_layoutViewColumn1_1.Size = new System.Drawing.Size(29, 27);
            this.layoutViewField_layoutViewColumn1_1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_layoutViewColumn1_1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_layoutViewColumn1_1.TextToControlDistance = 0;
            this.layoutViewField_layoutViewColumn1_1.TextVisible = false;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "layoutViewCard1";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.GroupBordersVisible = false;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Item1,
            this.Item2,
            this.Item6,
            this.Item7,
            this.Item8,
            this.layoutViewField_layoutViewColumn1_1});
            this.layoutViewCard1.Name = "layoutViewTemplateCard";
            this.layoutViewCard1.Text = "TemplateCard";
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
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // repositoryItemButtonEdit4
            // 
            this.repositoryItemButtonEdit4.AutoHeight = false;
            this.repositoryItemButtonEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repositoryItemButtonEdit4.Name = "repositoryItemButtonEdit4";
            this.repositoryItemButtonEdit4.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemButtonEdit5
            // 
            this.repositoryItemButtonEdit5.AutoHeight = false;
            this.repositoryItemButtonEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Mở file", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, false)});
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
            // popupControlContainerFilter
            // 
            this.popupControlContainerFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainerFilter.Controls.Add(this.KetThucDen);
            this.popupControlContainerFilter.Controls.Add(this.plLabel2);
            this.popupControlContainerFilter.Controls.Add(this.KetThucTu);
            this.popupControlContainerFilter.Controls.Add(this.plLabel1);
            this.popupControlContainerFilter.Controls.Add(this.mucuutien);
            this.popupControlContainerFilter.Controls.Add(this.tintrang);
            this.popupControlContainerFilter.Controls.Add(this.LoaiCV);
            this.popupControlContainerFilter.Controls.Add(this.LoaiDA);
            this.popupControlContainerFilter.Controls.Add(this.labelControl5);
            this.popupControlContainerFilter.Controls.Add(this.labelControl4);
            this.popupControlContainerFilter.Controls.Add(this.denngay);
            this.popupControlContainerFilter.Controls.Add(this.labelControl6);
            this.popupControlContainerFilter.Controls.Add(this.labelControl3);
            this.popupControlContainerFilter.Controls.Add(this.labelControl2);
            this.popupControlContainerFilter.Controls.Add(this.labelControl1);
            this.popupControlContainerFilter.Controls.Add(this.Tungay);
            this.popupControlContainerFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupControlContainerFilter.Location = new System.Drawing.Point(0, 24);
            this.popupControlContainerFilter.Manager = this.barManager1;
            this.popupControlContainerFilter.Name = "popupControlContainerFilter";
            this.popupControlContainerFilter.Size = new System.Drawing.Size(998, 63);
            this.popupControlContainerFilter.TabIndex = 0;
            this.popupControlContainerFilter.Visible = false;
            // 
            // KetThucDen
            // 
            this.KetThucDen.EditValue = null;
            this.KetThucDen.Location = new System.Drawing.Point(546, 35);
            this.KetThucDen.Name = "KetThucDen";
            this.KetThucDen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.KetThucDen.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.KetThucDen.Size = new System.Drawing.Size(134, 20);
            this.KetThucDen.TabIndex = 6;
            // 
            // plLabel2
            // 
            this.plLabel2.Location = new System.Drawing.Point(518, 39);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(18, 13);
            this.plLabel2.TabIndex = 94;
            this.plLabel2.Text = "đến";
            this.plLabel2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // KetThucTu
            // 
            this.KetThucTu.EditValue = null;
            this.KetThucTu.Location = new System.Drawing.Point(373, 35);
            this.KetThucTu.Name = "KetThucTu";
            this.KetThucTu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.KetThucTu.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.KetThucTu.Size = new System.Drawing.Size(134, 20);
            this.KetThucTu.TabIndex = 5;
            // 
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(288, 39);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(81, 13);
            this.plLabel1.TabIndex = 92;
            this.plLabel1.Text = "Ngày kết thúc từ";
            this.plLabel1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // mucuutien
            // 
            this.mucuutien.DataSource = null;
            this.mucuutien.DisplayField = null;
            this.mucuutien.Location = new System.Drawing.Point(762, 8);
            this.mucuutien.Name = "mucuutien";
            this.mucuutien.Size = new System.Drawing.Size(134, 20);
            this.mucuutien.TabIndex = 3;
            this.mucuutien.ValueField = "";
            // 
            // tintrang
            // 
            this.tintrang.DataSource = null;
            this.tintrang.DisplayField = null;
            this.tintrang.Location = new System.Drawing.Point(762, 35);
            this.tintrang.Name = "tintrang";
            this.tintrang.Size = new System.Drawing.Size(134, 20);
            this.tintrang.TabIndex = 7;
            this.tintrang.ValueField = "";
            // 
            // LoaiCV
            // 
            this.LoaiCV.DataSource = null;
            this.LoaiCV.DisplayField = null;
            this.LoaiCV.Location = new System.Drawing.Point(85, 35);
            this.LoaiCV.Name = "LoaiCV";
            this.LoaiCV.Size = new System.Drawing.Size(192, 20);
            this.LoaiCV.TabIndex = 4;
            this.LoaiCV.ValueField = "";
            // 
            // LoaiDA
            // 
            this.LoaiDA.DataSource = null;
            this.LoaiDA.DisplayField = null;
            this.LoaiDA.Location = new System.Drawing.Point(86, 8);
            this.LoaiDA.Name = "LoaiDA";
            this.LoaiDA.Size = new System.Drawing.Size(192, 20);
            this.LoaiDA.TabIndex = 0;
            this.LoaiDA.ValueField = "";
            this.LoaiDA.Load += new System.EventHandler(this.LoaiDA_Load);
            this.LoaiDA.SelectedIndexChanged += new System.EventHandler(this.LoaiDA_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(699, 39);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(49, 13);
            this.labelControl5.TabIndex = 91;
            this.labelControl5.Text = "Tình trạng";
            this.labelControl5.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(699, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 13);
            this.labelControl4.TabIndex = 91;
            this.labelControl4.Text = "Độ ưu tiên";
            this.labelControl4.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // denngay
            // 
            this.denngay.EditValue = null;
            this.denngay.Location = new System.Drawing.Point(546, 8);
            this.denngay.Name = "denngay";
            this.denngay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.denngay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.denngay.Size = new System.Drawing.Size(134, 20);
            this.denngay.TabIndex = 2;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(11, 39);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(67, 13);
            this.labelControl6.TabIndex = 34;
            this.labelControl6.Text = "Loại công việc";
            this.labelControl6.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl6.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 13);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "Loại dự án";
            this.labelControl3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(517, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "đến";
            this.labelControl2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(288, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 13);
            this.labelControl1.TabIndex = 24;
            this.labelControl1.Text = "Ngày bắt đầu từ";
            this.labelControl1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // Tungay
            // 
            this.Tungay.EditValue = null;
            this.Tungay.Location = new System.Drawing.Point(373, 8);
            this.Tungay.Name = "Tungay";
            this.Tungay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Tungay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Tungay.Size = new System.Drawing.Size(134, 20);
            this.Tungay.TabIndex = 1;
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
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "fwWord.jpg");
            this.imageList3.Images.SetKeyName(1, "fwExcel.jpg");
            this.imageList3.Images.SetKeyName(2, "fwLock.jpg");
            this.imageList3.Images.SetKeyName(3, "bbbn.JPG");
            this.imageList3.Images.SetKeyName(4, "image.jpg");
            this.imageList3.Images.SetKeyName(5, "txt.JPG");
            this.imageList3.Images.SetKeyName(6, "pdf.JPG");
            this.imageList3.Images.SetKeyName(7, "macdinh.JPG");
            // 
            // imageList_layout
            // 
            this.imageList_layout.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_layout.ImageStream")));
            this.imageList_layout.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_layout.Images.SetKeyName(0, "pl-xuatkho.png");
            this.imageList_layout.Images.SetKeyName(1, "fwSave.png");
            this.imageList_layout.Images.SetKeyName(2, "Delete.png");
            // 
            // frmDuAnQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 497);
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_mofile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_luu_file)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).EndInit();
            this.popupControlContainerFilter.ResumeLayout(false);
            this.popupControlContainerFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KetThucDen.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KetThucDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KetThucTu.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KetThucTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tungay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tungay.Properties)).EndInit();
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
        private DateEdit denngay;
        private DateEdit Tungay;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiDA;
        private DevExpress.XtraGrid.Columns.GridColumn colTen_DA;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoi_QL;
        private DevExpress.XtraGrid.Columns.GridColumn colNgay_BD_DA;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayKT_DA;
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
        private DevExpress.XtraGrid.Columns.GridColumn colNgay_ket_thuc;
        private DevExpress.XtraGrid.Columns.GridColumn colTG_DT;
        private DevExpress.XtraGrid.Columns.GridColumn ColTien_Do;
        private DevExpress.XtraGrid.Columns.GridColumn colTinh_trang;
        private PLCombobox LoaiDA;
        private PLImgCombobox mucuutien;
        private PLImgCombobox tintrang;
        private PLCombobox LoaiCV;
        private DevExpress.XtraGrid.GridControl gridControlTaiLieu;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn layoutViewColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colfile;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colghichu;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item7;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn coltieude;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item6;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn coltenfile;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item2;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colmofile;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rep_mofile;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item8;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cot_luu_file;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rep_luu_file;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit2;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList imageList_layout;
        private System.Windows.Forms.PLLabel labelControl6;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl5;
        private DateEdit KetThucTu;
        private System.Windows.Forms.PLLabel plLabel1;
        private DateEdit KetThucDen;
        private System.Windows.Forms.PLLabel plLabel2;
    }
}