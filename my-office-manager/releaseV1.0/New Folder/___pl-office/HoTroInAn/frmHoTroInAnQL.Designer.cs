using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmHoTroInAnQL
    {

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
            try
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoTroInAnQL));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
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
            this.colNguoi_gui = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThoi_gian = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoi_nhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMuc_UT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMuc_dich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT_trang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.XtraTabPageDetail = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlTaiLieu = new DevExpress.XtraGrid.GridControl();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.lvFile_dinh_kem = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvTieuDe = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvSoBan = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_5 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cot_mofile = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rep_mofile = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_cot_mofile = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cot_luufile = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.rep_luufile = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_cot_luufile = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
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
            this.lvYeuCau = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_6 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvSize = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_7 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.lvIn = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repIn = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_layoutViewColumn1_8 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.Group1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.item1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.item3 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item5 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item4 = new DevExpress.XtraLayout.SimpleLabelItem();
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
            this.popupControlContainerFilter = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.cboNguoi_nhan = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.ngayKT = new ProtocolVN.Framework.Win.Office.PLDateSelection();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.PLImgTinhTrang = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.cboMuc_uu_tien = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.cboNguoi_gui = new ProtocolVN.Framework.Win.PLDMTreeGroup();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_mofile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_mofile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_luufile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_luufile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_xoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_xoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_sua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_suafile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaiLieu)).BeginInit();
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
            this.barButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Xem trước phiếu bả&o hành";
            this.barButtonItem5.Id = 35;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            this.barSubItem1.Caption = "T&hay đổi tình trạng";
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
            this.barDockControlTop.Size = new System.Drawing.Size(907, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 497);
            this.barDockControlBottom.Size = new System.Drawing.Size(907, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(907, 24);
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
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 92);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlMaster);
            this.splitContainerControl1.Panel1.MinSize = 160;
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlDetail);
            this.splitContainerControl1.Panel2.MinSize = 50;
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(907, 405);
            this.splitContainerControl1.SplitterPosition = 221;
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
            this.gridControlMaster.Size = new System.Drawing.Size(907, 178);
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
            this.colNguoi_gui,
            this.colThoi_gian,
            this.colNguoi_nhan,
            this.colMuc_UT,
            this.colMuc_dich,
            this.colT_trang});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupCount = 1;
            this.gridViewMaster.GroupPanelText = "DANH SÁCH IN ẤN";
            this.gridViewMaster.IndicatorWidth = 40;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewMaster.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewMaster.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewMaster.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewMaster.OptionsPrint.UsePrintStyles = true;
            this.gridViewMaster.OptionsSelection.MultiSelect = true;
            this.gridViewMaster.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMaster.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewMaster.OptionsView.RowAutoHeight = true;
            this.gridViewMaster.OptionsView.ShowFooter = true;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = true;
            this.gridViewMaster.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNguoi_nhan, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colNguoi_gui
            // 
            this.colNguoi_gui.Caption = "Người yêu cầu";
            this.colNguoi_gui.Name = "colNguoi_gui";
            this.colNguoi_gui.Visible = true;
            this.colNguoi_gui.VisibleIndex = 0;
            this.colNguoi_gui.Width = 81;
            // 
            // colThoi_gian
            // 
            this.colThoi_gian.Caption = "Thời gian yêu cầu";
            this.colThoi_gian.Name = "colThoi_gian";
            this.colThoi_gian.Visible = true;
            this.colThoi_gian.VisibleIndex = 1;
            this.colThoi_gian.Width = 96;
            // 
            // colNguoi_nhan
            // 
            this.colNguoi_nhan.Caption = "Người thực hiện";
            this.colNguoi_nhan.Name = "colNguoi_nhan";
            this.colNguoi_nhan.Visible = true;
            this.colNguoi_nhan.VisibleIndex = 2;
            this.colNguoi_nhan.Width = 101;
            // 
            // colMuc_UT
            // 
            this.colMuc_UT.Caption = "Độ ưu tiên";
            this.colMuc_UT.Name = "colMuc_UT";
            this.colMuc_UT.Visible = true;
            this.colMuc_UT.VisibleIndex = 4;
            this.colMuc_UT.Width = 63;
            // 
            // colMuc_dich
            // 
            this.colMuc_dich.Caption = "Mục đích";
            this.colMuc_dich.Name = "colMuc_dich";
            this.colMuc_dich.Visible = true;
            this.colMuc_dich.VisibleIndex = 3;
            this.colMuc_dich.Width = 53;
            // 
            // colT_trang
            // 
            this.colT_trang.Caption = "Tình trạng";
            this.colT_trang.Name = "colT_trang";
            this.colT_trang.Visible = true;
            this.colT_trang.VisibleIndex = 5;
            this.colT_trang.Width = 61;
            // 
            // xtraTabControlDetail
            // 
            this.xtraTabControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlDetail.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlDetail.Name = "xtraTabControlDetail";
            this.xtraTabControlDetail.SelectedTabPage = this.XtraTabPageDetail;
            this.xtraTabControlDetail.Size = new System.Drawing.Size(907, 221);
            this.xtraTabControlDetail.TabIndex = 0;
            this.xtraTabControlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.XtraTabPageDetail});
            // 
            // XtraTabPageDetail
            // 
            this.XtraTabPageDetail.Controls.Add(this.gridControlTaiLieu);
            this.XtraTabPageDetail.Name = "XtraTabPageDetail";
            this.XtraTabPageDetail.Size = new System.Drawing.Size(900, 192);
            this.XtraTabPageDetail.Text = "Danh sách file in ấn";
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
            this.rep_sua,
            this.repIn});
            this.gridControlTaiLieu.Size = new System.Drawing.Size(900, 192);
            this.gridControlTaiLieu.TabIndex = 192;
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
            this.layoutView1.CardMinSize = new System.Drawing.Size(200, 156);
            this.layoutView1.CardVertInterval = 7;
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.lvFile_dinh_kem,
            this.lvTieuDe,
            this.lvSoBan,
            this.cot_mofile,
            this.cot_luufile,
            this.cot_xoa,
            this.cot_suafile,
            this.lvNguoiCapNhat,
            this.lvNgayCapNhat,
            this.lvGhi_chu,
            this.lvYeuCau,
            this.lvSize,
            this.lvIn});
            this.layoutView1.GridControl = this.gridControlTaiLieu;
            this.layoutView1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn1_2,
            this.layoutViewField_layoutViewColumn1_3,
            this.layoutViewField_layoutViewColumn1_4,
            this.layoutViewField_layoutViewColumn1,
            this.layoutViewField_layoutViewColumn1_1});
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.layoutView1.OptionsFilter.AllowFilterEditor = false;
            this.layoutView1.OptionsFilter.AllowMRUFilterList = false;
            this.layoutView1.OptionsItemText.AlignMode = DevExpress.XtraGrid.Views.Layout.FieldTextAlignMode.CustomSize;
            this.layoutView1.OptionsItemText.TextToControlDistance = 0;
            this.layoutView1.OptionsLayout.Columns.AddNewColumns = false;
            this.layoutView1.OptionsView.CardsAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near;
            this.layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
            this.layoutView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.lvGhi_chu, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.layoutView1.SynchronizeClones = false;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // lvFile_dinh_kem
            // 
            this.lvFile_dinh_kem.Caption = "tên tt";
            this.lvFile_dinh_kem.LayoutViewField = this.layoutViewField_layoutViewColumn1_3;
            this.lvFile_dinh_kem.Name = "lvFile_dinh_kem";
            this.lvFile_dinh_kem.OptionsColumn.AllowEdit = false;
            this.lvFile_dinh_kem.OptionsColumn.AllowFocus = false;
            // 
            // layoutViewField_layoutViewColumn1_3
            // 
            this.layoutViewField_layoutViewColumn1_3.EditorPreferredWidth = 20;
            this.layoutViewField_layoutViewColumn1_3.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1_3.Name = "layoutViewField_layoutViewColumn1_3";
            this.layoutViewField_layoutViewColumn1_3.Size = new System.Drawing.Size(194, 130);
            this.layoutViewField_layoutViewColumn1_3.TextSize = new System.Drawing.Size(0, 13);
            this.layoutViewField_layoutViewColumn1_3.TextToControlDistance = 5;
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
            this.layoutViewField_layoutViewColumn1_2.Size = new System.Drawing.Size(194, 130);
            this.layoutViewField_layoutViewColumn1_2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutViewField_layoutViewColumn1_2.TextSize = new System.Drawing.Size(39, 13);
            this.layoutViewField_layoutViewColumn1_2.TextToControlDistance = 5;
            // 
            // lvSoBan
            // 
            this.lvSoBan.AppearanceCell.Options.UseTextOptions = true;
            this.lvSoBan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lvSoBan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.lvSoBan.AppearanceHeader.Options.UseFont = true;
            this.lvSoBan.LayoutViewField = this.layoutViewField_layoutViewColumn1_5;
            this.lvSoBan.Name = "lvSoBan";
            this.lvSoBan.OptionsColumn.AllowEdit = false;
            this.lvSoBan.OptionsColumn.AllowFocus = false;
            // 
            // layoutViewField_layoutViewColumn1_5
            // 
            this.layoutViewField_layoutViewColumn1_5.EditorPreferredWidth = 131;
            this.layoutViewField_layoutViewColumn1_5.Location = new System.Drawing.Point(59, 20);
            this.layoutViewField_layoutViewColumn1_5.Name = "layoutViewField_layoutViewColumn1_5";
            this.layoutViewField_layoutViewColumn1_5.Size = new System.Drawing.Size(135, 20);
            this.layoutViewField_layoutViewColumn1_5.TextSize = new System.Drawing.Size(0, 13);
            // 
            // cot_mofile
            // 
            this.cot_mofile.Caption = "Mở file";
            this.cot_mofile.ColumnEdit = this.rep_mofile;
            this.cot_mofile.LayoutViewField = this.layoutViewField_cot_mofile;
            this.cot_mofile.Name = "cot_mofile";
            // 
            // rep_mofile
            // 
            this.rep_mofile.Name = "rep_mofile";
            this.rep_mofile.Click += new System.EventHandler(this.rep_mofile_Click);
            // 
            // layoutViewField_cot_mofile
            // 
            this.layoutViewField_cot_mofile.EditorPreferredWidth = 26;
            this.layoutViewField_cot_mofile.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_cot_mofile.MaxSize = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_mofile.MinSize = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_mofile.Name = "layoutViewField_cot_mofile";
            this.layoutViewField_cot_mofile.Size = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_mofile.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_cot_mofile.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_cot_mofile.TextToControlDistance = 0;
            this.layoutViewField_cot_mofile.TextVisible = false;
            // 
            // cot_luufile
            // 
            this.cot_luufile.Caption = "lưu file";
            this.cot_luufile.ColumnEdit = this.rep_luufile;
            this.cot_luufile.LayoutViewField = this.layoutViewField_cot_luufile;
            this.cot_luufile.Name = "cot_luufile";
            // 
            // rep_luufile
            // 
            this.rep_luufile.Name = "rep_luufile";
            this.rep_luufile.Click += new System.EventHandler(this.rep_luu_file_Click);
            // 
            // layoutViewField_cot_luufile
            // 
            this.layoutViewField_cot_luufile.EditorPreferredWidth = 26;
            this.layoutViewField_cot_luufile.Location = new System.Drawing.Point(30, 0);
            this.layoutViewField_cot_luufile.MaxSize = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_luufile.MinSize = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_luufile.Name = "layoutViewField_cot_luufile";
            this.layoutViewField_cot_luufile.Size = new System.Drawing.Size(30, 26);
            this.layoutViewField_cot_luufile.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_cot_luufile.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_cot_luufile.TextToControlDistance = 0;
            this.layoutViewField_cot_luufile.TextVisible = false;
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
            this.layoutViewField_cot_xoa.Size = new System.Drawing.Size(194, 130);
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
            this.layoutViewField_cot_suafile.Location = new System.Drawing.Point(0, 130);
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
            this.lvNguoiCapNhat.Caption = "NguoiCapNhat";
            this.lvNguoiCapNhat.LayoutViewField = this.layoutViewField_layoutViewColumn1;
            this.lvNguoiCapNhat.Name = "lvNguoiCapNhat";
            this.lvNguoiCapNhat.OptionsColumn.AllowEdit = false;
            this.lvNguoiCapNhat.OptionsColumn.AllowFocus = false;
            // 
            // layoutViewField_layoutViewColumn1
            // 
            this.layoutViewField_layoutViewColumn1.EditorPreferredWidth = 20;
            this.layoutViewField_layoutViewColumn1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1.Name = "layoutViewField_layoutViewColumn1";
            this.layoutViewField_layoutViewColumn1.Size = new System.Drawing.Size(194, 130);
            this.layoutViewField_layoutViewColumn1.TextSize = new System.Drawing.Size(0, 13);
            this.layoutViewField_layoutViewColumn1.TextToControlDistance = 5;
            // 
            // lvNgayCapNhat
            // 
            this.lvNgayCapNhat.Caption = "Ngay cap nhat";
            this.lvNgayCapNhat.LayoutViewField = this.layoutViewField_layoutViewColumn1_1;
            this.lvNgayCapNhat.Name = "lvNgayCapNhat";
            this.lvNgayCapNhat.OptionsColumn.AllowEdit = false;
            this.lvNgayCapNhat.OptionsColumn.AllowFocus = false;
            // 
            // layoutViewField_layoutViewColumn1_1
            // 
            this.layoutViewField_layoutViewColumn1_1.EditorPreferredWidth = 20;
            this.layoutViewField_layoutViewColumn1_1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1_1.Name = "layoutViewField_layoutViewColumn1_1";
            this.layoutViewField_layoutViewColumn1_1.Size = new System.Drawing.Size(194, 130);
            this.layoutViewField_layoutViewColumn1_1.TextSize = new System.Drawing.Size(0, 13);
            this.layoutViewField_layoutViewColumn1_1.TextToControlDistance = 5;
            // 
            // lvGhi_chu
            // 
            this.lvGhi_chu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.lvGhi_chu.AppearanceHeader.Options.UseFont = true;
            this.lvGhi_chu.Caption = "Ghi chú";
            this.lvGhi_chu.LayoutViewField = this.layoutViewField_layoutViewColumn1_4;
            this.lvGhi_chu.Name = "lvGhi_chu";
            // 
            // layoutViewField_layoutViewColumn1_4
            // 
            this.layoutViewField_layoutViewColumn1_4.EditorPreferredWidth = 20;
            this.layoutViewField_layoutViewColumn1_4.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1_4.Name = "layoutViewField_layoutViewColumn1_4";
            this.layoutViewField_layoutViewColumn1_4.Size = new System.Drawing.Size(194, 130);
            this.layoutViewField_layoutViewColumn1_4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutViewField_layoutViewColumn1_4.TextSize = new System.Drawing.Size(39, 13);
            this.layoutViewField_layoutViewColumn1_4.TextToControlDistance = 5;
            // 
            // lvYeuCau
            // 
            this.lvYeuCau.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.lvYeuCau.AppearanceHeader.Options.UseFont = true;
            this.lvYeuCau.LayoutViewField = this.layoutViewField_layoutViewColumn1_6;
            this.lvYeuCau.Name = "lvYeuCau";
            this.lvYeuCau.OptionsColumn.ReadOnly = true;
            // 
            // layoutViewField_layoutViewColumn1_6
            // 
            this.layoutViewField_layoutViewColumn1_6.EditorPreferredWidth = 131;
            this.layoutViewField_layoutViewColumn1_6.Location = new System.Drawing.Point(59, 40);
            this.layoutViewField_layoutViewColumn1_6.Name = "layoutViewField_layoutViewColumn1_6";
            this.layoutViewField_layoutViewColumn1_6.Size = new System.Drawing.Size(135, 20);
            this.layoutViewField_layoutViewColumn1_6.TextSize = new System.Drawing.Size(0, 13);
            // 
            // lvSize
            // 
            this.lvSize.AppearanceCell.Options.UseTextOptions = true;
            this.lvSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lvSize.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.lvSize.AppearanceHeader.Options.UseFont = true;
            this.lvSize.LayoutViewField = this.layoutViewField_layoutViewColumn1_7;
            this.lvSize.Name = "lvSize";
            this.lvSize.OptionsColumn.AllowEdit = false;
            this.lvSize.OptionsColumn.AllowFocus = false;
            // 
            // layoutViewField_layoutViewColumn1_7
            // 
            this.layoutViewField_layoutViewColumn1_7.EditorPreferredWidth = 131;
            this.layoutViewField_layoutViewColumn1_7.Location = new System.Drawing.Point(59, 0);
            this.layoutViewField_layoutViewColumn1_7.Name = "layoutViewField_layoutViewColumn1_7";
            this.layoutViewField_layoutViewColumn1_7.Size = new System.Drawing.Size(135, 20);
            this.layoutViewField_layoutViewColumn1_7.TextSize = new System.Drawing.Size(0, 13);
            // 
            // lvIn
            // 
            this.lvIn.ColumnEdit = this.repIn;
            this.lvIn.LayoutViewField = this.layoutViewField_layoutViewColumn1_8;
            this.lvIn.Name = "lvIn";
            // 
            // repIn
            // 
            this.repIn.Name = "repIn";
            this.repIn.Click += new System.EventHandler(this.repIn_Click);
            // 
            // layoutViewField_layoutViewColumn1_8
            // 
            this.layoutViewField_layoutViewColumn1_8.EditorPreferredWidth = 26;
            this.layoutViewField_layoutViewColumn1_8.Location = new System.Drawing.Point(60, 0);
            this.layoutViewField_layoutViewColumn1_8.MaxSize = new System.Drawing.Size(30, 26);
            this.layoutViewField_layoutViewColumn1_8.MinSize = new System.Drawing.Size(30, 26);
            this.layoutViewField_layoutViewColumn1_8.Name = "layoutViewField_layoutViewColumn1_8";
            this.layoutViewField_layoutViewColumn1_8.Size = new System.Drawing.Size(30, 26);
            this.layoutViewField_layoutViewColumn1_8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_layoutViewColumn1_8.TextSize = new System.Drawing.Size(0, 13);
            this.layoutViewField_layoutViewColumn1_8.TextToControlDistance = 0;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "layoutViewTemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Group1,
            this.item3,
            this.layoutViewField_layoutViewColumn1_7,
            this.item5,
            this.layoutViewField_layoutViewColumn1_5,
            this.item4,
            this.layoutViewField_layoutViewColumn1_6});
            this.layoutViewCard1.Name = "layoutViewTemplateCard";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 0;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // Group1
            // 
            this.Group1.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.Group1.AppearanceGroup.Options.UseFont = true;
            this.Group1.CustomizationFormText = "Thao tác";
            this.Group1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_cot_mofile,
            this.layoutViewField_cot_luufile,
            this.item1,
            this.layoutViewField_layoutViewColumn1_8});
            this.Group1.Location = new System.Drawing.Point(0, 60);
            this.Group1.Name = "Group1";
            this.Group1.Size = new System.Drawing.Size(194, 70);
            this.Group1.Text = "Thao tác";
            // 
            // item1
            // 
            this.item1.CustomizationFormText = "item1";
            this.item1.Location = new System.Drawing.Point(90, 0);
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(80, 26);
            this.item1.Text = "item1";
            this.item1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // item3
            // 
            this.item3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item3.AppearanceItemCaption.Options.UseFont = true;
            this.item3.CustomizationFormText = "Người cập nhật:";
            this.item3.Location = new System.Drawing.Point(0, 20);
            this.item3.Name = "item3";
            this.item3.Size = new System.Drawing.Size(59, 20);
            this.item3.Text = "Số bản in:";
            this.item3.TextSize = new System.Drawing.Size(48, 13);
            // 
            // item5
            // 
            this.item5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item5.AppearanceItemCaption.Options.UseFont = true;
            this.item5.CustomizationFormText = "Độ lớn(KB):";
            this.item5.Location = new System.Drawing.Point(0, 0);
            this.item5.Name = "item5";
            this.item5.Size = new System.Drawing.Size(59, 20);
            this.item5.Text = "Độ lớn(KB):";
            this.item5.TextSize = new System.Drawing.Size(55, 13);
            // 
            // item4
            // 
            this.item4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item4.AppearanceItemCaption.Options.UseFont = true;
            this.item4.CustomizationFormText = "Ngày cập nhật:";
            this.item4.Location = new System.Drawing.Point(0, 40);
            this.item4.Name = "item4";
            this.item4.Size = new System.Drawing.Size(59, 20);
            this.item4.Text = "Yêu cầu:";
            this.item4.TextSize = new System.Drawing.Size(42, 13);
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
            // popupControlContainerFilter
            // 
            this.popupControlContainerFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainerFilter.Controls.Add(this.cboNguoi_nhan);
            this.popupControlContainerFilter.Controls.Add(this.ngayKT);
            this.popupControlContainerFilter.Controls.Add(this.plLabel1);
            this.popupControlContainerFilter.Controls.Add(this.PLImgTinhTrang);
            this.popupControlContainerFilter.Controls.Add(this.labelControl5);
            this.popupControlContainerFilter.Controls.Add(this.cboMuc_uu_tien);
            this.popupControlContainerFilter.Controls.Add(this.cboNguoi_gui);
            this.popupControlContainerFilter.Controls.Add(this.labelControl4);
            this.popupControlContainerFilter.Controls.Add(this.labelControl6);
            this.popupControlContainerFilter.Controls.Add(this.labelControl3);
            this.popupControlContainerFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupControlContainerFilter.Location = new System.Drawing.Point(0, 24);
            this.popupControlContainerFilter.Manager = this.barManager1;
            this.popupControlContainerFilter.Name = "popupControlContainerFilter";
            this.popupControlContainerFilter.Size = new System.Drawing.Size(907, 68);
            this.popupControlContainerFilter.TabIndex = 0;
            this.popupControlContainerFilter.Visible = false;
            // 
            // cboNguoi_nhan
            // 
            this.cboNguoi_nhan.Location = new System.Drawing.Point(88, 38);
            this.cboNguoi_nhan.Name = "cboNguoi_nhan";
            this.cboNguoi_nhan.Size = new System.Drawing.Size(162, 20);
            this.cboNguoi_nhan.TabIndex = 2;
            // 
            // ngayKT
            // 
            this.ngayKT.Caption = "Năm 2010 và 2011";
            this.ngayKT.Default = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromMonthToMonth;
            this.ngayKT.FirstFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayKT.FirstTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayKT.FromDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayKT.Location = new System.Drawing.Point(548, 38);
            this.ngayKT.Name = "ngayKT";
            this.ngayKT.ReturnType = ProtocolVN.Framework.Win.Trial.TimeType.Date;
            this.ngayKT.SecondFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayKT.SecondTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayKT.SelectedType = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromYearToYear;
            this.ngayKT.Size = new System.Drawing.Size(225, 21);
            this.ngayKT.TabIndex = 5;
            this.ngayKT.ToDate = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayKT.Types = ((ProtocolVN.Framework.Win.Trial.SelectionTypes)(((((((((ProtocolVN.Framework.Win.Trial.SelectionTypes.OneDate | ProtocolVN.Framework.Win.Trial.SelectionTypes.OneMonth)
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
            this.plLabel1.Location = new System.Drawing.Point(481, 42);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(61, 13);
            this.plLabel1.TabIndex = 171;
            this.plLabel1.Text = "Thời gian gửi";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // PLImgTinhTrang
            // 
            this.PLImgTinhTrang.DataSource = null;
            this.PLImgTinhTrang.DisplayField = null;
            this.PLImgTinhTrang.Location = new System.Drawing.Point(336, 38);
            this.PLImgTinhTrang.Name = "PLImgTinhTrang";
            this.PLImgTinhTrang.Size = new System.Drawing.Size(108, 20);
            this.PLImgTinhTrang.TabIndex = 4;
            this.PLImgTinhTrang.ValueField = "";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(279, 42);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(49, 13);
            this.labelControl5.TabIndex = 170;
            this.labelControl5.Text = "Tình trạng";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // cboMuc_uu_tien
            // 
            this.cboMuc_uu_tien.DataSource = null;
            this.cboMuc_uu_tien.DisplayField = null;
            this.cboMuc_uu_tien.Location = new System.Drawing.Point(336, 9);
            this.cboMuc_uu_tien.Name = "cboMuc_uu_tien";
            this.cboMuc_uu_tien.Size = new System.Drawing.Size(108, 20);
            this.cboMuc_uu_tien.TabIndex = 3;
            this.cboMuc_uu_tien.ValueField = "";
            // 
            // cboNguoi_gui
            // 
            this.cboNguoi_gui.Location = new System.Drawing.Point(88, 9);
            this.cboNguoi_gui.Name = "cboNguoi_gui";
            this.cboNguoi_gui.Size = new System.Drawing.Size(162, 20);
            this.cboNguoi_gui.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(279, 13);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 13);
            this.labelControl4.TabIndex = 91;
            this.labelControl4.Text = "Độ ưu tiên";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(6, 42);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(76, 13);
            this.labelControl6.TabIndex = 34;
            this.labelControl6.Text = "Người thực hiện";
            this.labelControl6.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 13);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 13);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "Người yêu cầu";
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
            // frmHoTroInAnQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 497);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.popupControlContainerFilter);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmHoTroInAnQL";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hỗ trợ in ấn";
            this.Load += new System.EventHandler(this.frmHoTroInAnQL_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTaiLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_mofile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_mofile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_luufile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_luufile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_xoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_xoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_sua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_cot_suafile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaiLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).EndInit();
            this.popupControlContainerFilter.ResumeLayout(false);
            this.popupControlContainerFilter.PerformLayout();
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
        private DevExpress.XtraGrid.Columns.GridColumn colThoi_gian;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoi_gui;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoi_nhan;
        private DevExpress.XtraGrid.Columns.GridColumn colMuc_dich;
        private DevExpress.XtraGrid.Columns.GridColumn colT_trang;
        private DevExpress.XtraGrid.Columns.GridColumn colMuc_UT;
        private System.Windows.Forms.ToolTip toolTip1;
        private PLImgCombobox cboMuc_uu_tien;
        private PLImgCombobox PLImgTinhTrang;
        private System.Windows.Forms.PLLabel labelControl6;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel plLabel1;
        private ProtocolVN.Framework.Win.Office.PLDateSelection ngayKT;
        private DevExpress.XtraGrid.GridControl gridControlTaiLieu;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvTieuDe;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvFile_dinh_kem;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvSoBan;
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
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvYeuCau;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvSize;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn lvIn;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repIn;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_5;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_mofile;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_luufile;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_xoa;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_cot_suafile;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_4;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_6;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_7;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_8;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.LayoutControlGroup Group1;
        private DevExpress.XtraLayout.SimpleSeparator item1;
        private DevExpress.XtraLayout.SimpleLabelItem item3;
        private DevExpress.XtraLayout.SimpleLabelItem item5;
        private DevExpress.XtraLayout.SimpleLabelItem item4;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice cboNguoi_nhan;
        public PLDMTreeGroup cboNguoi_gui;
    }
}