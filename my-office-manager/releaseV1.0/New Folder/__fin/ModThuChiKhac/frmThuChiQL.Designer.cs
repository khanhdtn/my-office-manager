using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmThuChiQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThuChiQL));
            this.Filter_LoaiChiPhi = new ProtocolVN.Framework.Win.PLCombobox();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.MainBar = new DevExpress.XtraBars.Bar();
            this.barButtonItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemCommit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemNoCommit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSearch = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuFilter = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barCheckItemFilter = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem_Chot = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_NoChot = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChot = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemNoChot = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.Cot_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_MaPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_NgayPhatSinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_DienGiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_LoaiChiPhi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_DonViLienQuan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_NguoiLienQuan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_TonDauKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_Thu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_Chi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_TonCuoiKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.repositoryItemTimeEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.gridViewDetail = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.popupControlContainerFilter = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.ngayKT = new ProtocolVN.Framework.Win.Office.PLDateSelection();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.chk_Chi = new DevExpress.XtraEditors.CheckEdit();
            this.chk_Thu = new DevExpress.XtraEditors.CheckEdit();
            this.Calc_SoTienDen = new DevExpress.XtraEditors.CalcEdit();
            this.Calc_SoTienTu = new DevExpress.XtraEditors.CalcEdit();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.labelControl7 = new System.Windows.Forms.PLLabel();
            this.Filter_NguoiLienQuan = new ProtocolVN.Framework.Win.PLDMGrid();
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).BeginInit();
            this.popupControlContainerFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Chi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Thu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Calc_SoTienDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Calc_SoTienTu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Filter_LoaiChiPhi
            // 
            this.Filter_LoaiChiPhi.DataSource = null;
            this.Filter_LoaiChiPhi.DisplayField = null;
            this.Filter_LoaiChiPhi.Location = new System.Drawing.Point(412, 36);
            this.Filter_LoaiChiPhi.Name = "Filter_LoaiChiPhi";
            this.Filter_LoaiChiPhi.Size = new System.Drawing.Size(235, 20);
            this.Filter_LoaiChiPhi.TabIndex = 2;
            this.Filter_LoaiChiPhi.ValueField = null;
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
            this.barButtonItemCommit,
            this.barButtonItemNoCommit,
            this.barButtonItemSearch,
            this.barButtonItemClose,
            this.barCheckItemFilter,
            this.barSubItem1,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItemXem,
            this.barButtonItem4,
            this.barButtonItemChot,
            this.barButtonItemNoChot,
            this.barSubItem2,
            this.barButtonItem_Chot,
            this.barButtonItem_NoChot});
            this.barManager1.MaxItemId = 128;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSearch, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemClose, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2, true)});
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
            // barSubItem1
            // 
            this.barSubItem1.Caption = "&Nghiệp vụ";
            this.barSubItem1.Id = 20;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemCommit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemNoCommit)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barButtonItemCommit
            // 
            this.barButtonItemCommit.Caption = "&Chốt";
            this.barButtonItemCommit.Id = 17;
            this.barButtonItemCommit.Name = "barButtonItemCommit";
            this.barButtonItemCommit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemCommit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCommit_ItemClick);
            // 
            // barButtonItemNoCommit
            // 
            this.barButtonItemNoCommit.Caption = "&Chưa chốt";
            this.barButtonItemNoCommit.Id = 18;
            this.barButtonItemNoCommit.Name = "barButtonItemNoCommit";
            this.barButtonItemNoCommit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemNoCommit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemNoCommit_ItemClick);
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
            this.barButtonItemClose.Caption = "Đóng";
            this.barButtonItemClose.Id = 28;
            this.barButtonItemClose.Name = "barButtonItemClose";
            this.barButtonItemClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "&Nghiệp vụ";
            this.barSubItem2.Id = 125;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Chot),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_NoChot)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barButtonItem_Chot
            // 
            this.barButtonItem_Chot.Caption = "&Chốt";
            this.barButtonItem_Chot.Id = 126;
            this.barButtonItem_Chot.Name = "barButtonItem_Chot";
            this.barButtonItem_Chot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Chot_ItemClick);
            // 
            // barButtonItem_NoChot
            // 
            this.barButtonItem_NoChot.Caption = "&Mở chốt";
            this.barButtonItem_NoChot.Id = 127;
            this.barButtonItem_NoChot.Name = "barButtonItem_NoChot";
            this.barButtonItem_NoChot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_NoChot_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(804, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 531);
            this.barDockControlBottom.Size = new System.Drawing.Size(804, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 507);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(804, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 507);
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
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Chốt";
            this.barButtonItem6.Id = 35;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Mở chốt";
            this.barButtonItem7.Id = 36;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItemChot
            // 
            this.barButtonItemChot.Caption = "&Chốt";
            this.barButtonItemChot.Id = 123;
            this.barButtonItemChot.Name = "barButtonItemChot";
            // 
            // barButtonItemNoChot
            // 
            this.barButtonItemNoChot.Caption = "&Mở chốt";
            this.barButtonItemNoChot.Id = 124;
            this.barButtonItemNoChot.Name = "barButtonItemNoChot";
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
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 112);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlMaster);
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            this.splitContainerControl1.Size = new System.Drawing.Size(804, 419);
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
            this.gridControlMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemTimeEdit1,
            this.repositoryItemTimeEdit2});
            this.gridControlMaster.Size = new System.Drawing.Size(804, 419);
            this.gridControlMaster.TabIndex = 9;
            this.gridControlMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMaster});
            // 
            // gridViewMaster
            // 
            this.gridViewMaster.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewMaster.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Cot_ID,
            this.Cot_MaPhieu,
            this.Cot_NgayPhatSinh,
            this.Cot_DienGiai,
            this.Cot_LoaiChiPhi,
            this.Cot_DonViLienQuan,
            this.Cot_NguoiLienQuan,
            this.Cot_TonDauKy,
            this.Cot_Thu,
            this.Cot_Chi,
            this.Cot_TonCuoiKy,
            this.Cot_TrangThai});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupCount = 1;
            this.gridViewMaster.GroupPanelText = "DANH SÁCH PHIẾU ";
            this.gridViewMaster.IndicatorWidth = 40;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.NewItemRowText = "Nhập dữ liệu mới tại đây";
            this.gridViewMaster.OptionsFilter.UseNewCustomFilterDialog = true;
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Cot_LoaiChiPhi, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // Cot_ID
            // 
            this.Cot_ID.Caption = "ID";
            this.Cot_ID.FieldName = "ID";
            this.Cot_ID.Name = "Cot_ID";
            this.Cot_ID.Width = 23;
            // 
            // Cot_MaPhieu
            // 
            this.Cot_MaPhieu.Caption = "Mã phiếu";
            this.Cot_MaPhieu.FieldName = "O_MA_PHIEU";
            this.Cot_MaPhieu.Name = "Cot_MaPhieu";
            this.Cot_MaPhieu.Visible = true;
            this.Cot_MaPhieu.VisibleIndex = 0;
            this.Cot_MaPhieu.Width = 55;
            // 
            // Cot_NgayPhatSinh
            // 
            this.Cot_NgayPhatSinh.Caption = "Ngày phát sinh";
            this.Cot_NgayPhatSinh.FieldName = "O_NGAY_PHAT_SINH";
            this.Cot_NgayPhatSinh.Name = "Cot_NgayPhatSinh";
            this.Cot_NgayPhatSinh.Visible = true;
            this.Cot_NgayPhatSinh.VisibleIndex = 1;
            this.Cot_NgayPhatSinh.Width = 84;
            // 
            // Cot_DienGiai
            // 
            this.Cot_DienGiai.Caption = "Diễn giải";
            this.Cot_DienGiai.FieldName = "O_DIEN_GIAI";
            this.Cot_DienGiai.Name = "Cot_DienGiai";
            this.Cot_DienGiai.Visible = true;
            this.Cot_DienGiai.VisibleIndex = 7;
            this.Cot_DienGiai.Width = 52;
            // 
            // Cot_LoaiChiPhi
            // 
            this.Cot_LoaiChiPhi.Caption = "Loại chi phí";
            this.Cot_LoaiChiPhi.FieldName = "O_LOAI_CHI_PHI";
            this.Cot_LoaiChiPhi.Name = "Cot_LoaiChiPhi";
            this.Cot_LoaiChiPhi.Visible = true;
            this.Cot_LoaiChiPhi.VisibleIndex = 2;
            this.Cot_LoaiChiPhi.Width = 77;
            // 
            // Cot_DonViLienQuan
            // 
            this.Cot_DonViLienQuan.Caption = "Đơn vị liên quan";
            this.Cot_DonViLienQuan.FieldName = "O_DON_VI_LIEN_QUAN";
            this.Cot_DonViLienQuan.Name = "Cot_DonViLienQuan";
            this.Cot_DonViLienQuan.Visible = true;
            this.Cot_DonViLienQuan.VisibleIndex = 3;
            this.Cot_DonViLienQuan.Width = 89;
            // 
            // Cot_NguoiLienQuan
            // 
            this.Cot_NguoiLienQuan.Caption = "Người liên quan";
            this.Cot_NguoiLienQuan.FieldName = "O_NGUOI_LIEN_QUAN";
            this.Cot_NguoiLienQuan.Name = "Cot_NguoiLienQuan";
            this.Cot_NguoiLienQuan.Visible = true;
            this.Cot_NguoiLienQuan.VisibleIndex = 4;
            this.Cot_NguoiLienQuan.Width = 86;
            // 
            // Cot_TonDauKy
            // 
            this.Cot_TonDauKy.Caption = "Tồn đầu kỳ";
            this.Cot_TonDauKy.FieldName = "O_TON_DAU_KY";
            this.Cot_TonDauKy.Name = "Cot_TonDauKy";
            this.Cot_TonDauKy.Width = 65;
            // 
            // Cot_Thu
            // 
            this.Cot_Thu.Caption = "Thu (VNĐ)";
            this.Cot_Thu.FieldName = "O_THU";
            this.Cot_Thu.Name = "Cot_Thu";
            this.Cot_Thu.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.Cot_Thu.Visible = true;
            this.Cot_Thu.VisibleIndex = 5;
            this.Cot_Thu.Width = 62;
            // 
            // Cot_Chi
            // 
            this.Cot_Chi.Caption = "Chi (VNĐ)";
            this.Cot_Chi.FieldName = "O_CHI";
            this.Cot_Chi.Name = "Cot_Chi";
            this.Cot_Chi.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.Cot_Chi.Visible = true;
            this.Cot_Chi.VisibleIndex = 6;
            this.Cot_Chi.Width = 59;
            // 
            // Cot_TonCuoiKy
            // 
            this.Cot_TonCuoiKy.Caption = "Tồn cuối kỳ";
            this.Cot_TonCuoiKy.FieldName = "O_TON_CUOI_KY";
            this.Cot_TonCuoiKy.Name = "Cot_TonCuoiKy";
            this.Cot_TonCuoiKy.Width = 66;
            // 
            // Cot_TrangThai
            // 
            this.Cot_TrangThai.Caption = "Trạng thái";
            this.Cot_TrangThai.FieldName = "O_IS_CHOT";
            this.Cot_TrangThai.Name = "Cot_TrangThai";
            this.Cot_TrangThai.Width = 61;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // repositoryItemTimeEdit2
            // 
            this.repositoryItemTimeEdit2.AutoHeight = false;
            this.repositoryItemTimeEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemTimeEdit2.Name = "repositoryItemTimeEdit2";
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlDetail.BackgroundImage")));
            this.gridControlDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlDetail.Location = new System.Drawing.Point(0, 0);
            this.gridControlDetail.MainView = this.gridView1;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.Size = new System.Drawing.Size(400, 200);
            this.gridControlDetail.TabIndex = 0;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.GridControl = this.gridControlDetail;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Nhập dữ liệu mới tại đây";
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.UsePrintStyles = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            // 
            // gridViewDetail
            // 
            this.gridViewDetail.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewDetail.IndicatorWidth = 40;
            this.gridViewDetail.Name = "gridViewDetail";
            this.gridViewDetail.NewItemRowText = "Nhập dữ liệu mới tại đây";
            this.gridViewDetail.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridViewDetail.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewDetail.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewDetail.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewDetail.OptionsPrint.UsePrintStyles = true;
            this.gridViewDetail.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewDetail.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewDetail.OptionsView.ShowGroupedColumns = true;
            // 
            // popupControlContainerFilter
            // 
            this.popupControlContainerFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainerFilter.Controls.Add(this.ngayKT);
            this.popupControlContainerFilter.Controls.Add(this.plLabel1);
            this.popupControlContainerFilter.Controls.Add(this.chk_Chi);
            this.popupControlContainerFilter.Controls.Add(this.chk_Thu);
            this.popupControlContainerFilter.Controls.Add(this.Calc_SoTienDen);
            this.popupControlContainerFilter.Controls.Add(this.Calc_SoTienTu);
            this.popupControlContainerFilter.Controls.Add(this.labelControl5);
            this.popupControlContainerFilter.Controls.Add(this.labelControl4);
            this.popupControlContainerFilter.Controls.Add(this.labelControl1);
            this.popupControlContainerFilter.Controls.Add(this.labelControl2);
            this.popupControlContainerFilter.Controls.Add(this.labelControl3);
            this.popupControlContainerFilter.Controls.Add(this.labelControl7);
            this.popupControlContainerFilter.Controls.Add(this.Filter_NguoiLienQuan);
            this.popupControlContainerFilter.Controls.Add(this.Filter_LoaiChiPhi);
            this.popupControlContainerFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupControlContainerFilter.Location = new System.Drawing.Point(0, 24);
            this.popupControlContainerFilter.Manager = this.barManager1;
            this.popupControlContainerFilter.Name = "popupControlContainerFilter";
            this.popupControlContainerFilter.Size = new System.Drawing.Size(804, 88);
            this.popupControlContainerFilter.TabIndex = 5;
            this.popupControlContainerFilter.Visible = false;
            // 
            // ngayKT
            // 
            this.ngayKT.Caption = "Năm 2010 và 2011";
            this.ngayKT.Default = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromYearToYear;
            this.ngayKT.FirstFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayKT.FirstTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayKT.FromDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayKT.Location = new System.Drawing.Point(89, 9);
            this.ngayKT.Name = "ngayKT";
            this.ngayKT.ReturnType = ProtocolVN.Framework.Win.Trial.TimeType.Date;
            this.ngayKT.SecondFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayKT.SecondTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayKT.SelectedType = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromYearToYear;
            this.ngayKT.Size = new System.Drawing.Size(229, 21);
            this.ngayKT.TabIndex = 0;
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
            this.plLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.plLabel1.Appearance.Options.UseFont = true;
            this.plLabel1.Location = new System.Drawing.Point(653, 65);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(30, 13);
            this.plLabel1.TabIndex = 29;
            this.plLabel1.Text = "(VNĐ)";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // chk_Chi
            // 
            this.chk_Chi.Location = new System.Drawing.Point(178, 62);
            this.chk_Chi.Name = "chk_Chi";
            this.chk_Chi.Properties.Caption = "Chi";
            this.chk_Chi.Size = new System.Drawing.Size(45, 19);
            this.chk_Chi.TabIndex = 4;
            // 
            // chk_Thu
            // 
            this.chk_Thu.Location = new System.Drawing.Point(87, 62);
            this.chk_Thu.Name = "chk_Thu";
            this.chk_Thu.Properties.Caption = "Thu";
            this.chk_Thu.Size = new System.Drawing.Size(46, 19);
            this.chk_Thu.TabIndex = 3;
            // 
            // Calc_SoTienDen
            // 
            this.Calc_SoTienDen.Location = new System.Drawing.Point(547, 62);
            this.Calc_SoTienDen.Name = "Calc_SoTienDen";
            this.Calc_SoTienDen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Calc_SoTienDen.Size = new System.Drawing.Size(100, 20);
            this.Calc_SoTienDen.TabIndex = 6;
            // 
            // Calc_SoTienTu
            // 
            this.Calc_SoTienTu.Location = new System.Drawing.Point(412, 62);
            this.Calc_SoTienTu.Name = "Calc_SoTienTu";
            this.Calc_SoTienTu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Calc_SoTienTu.Size = new System.Drawing.Size(100, 20);
            this.Calc_SoTienTu.TabIndex = 5;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(9, 65);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(44, 13);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "Phát sinh";
            this.labelControl5.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(354, 68);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(47, 13);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Số tiền từ";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(518, 65);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(18, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "đến";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 13);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Ngày phát sinh";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 40);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(74, 13);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Người liên quan";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(354, 40);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(52, 13);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "Loại chi phí";
            this.labelControl7.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // Filter_NguoiLienQuan
            // 
            this.Filter_NguoiLienQuan.Location = new System.Drawing.Point(89, 36);
            this.Filter_NguoiLienQuan.Name = "Filter_NguoiLienQuan";
            this.Filter_NguoiLienQuan.Size = new System.Drawing.Size(229, 20);
            this.Filter_NguoiLienQuan.TabIndex = 1;
            this.Filter_NguoiLienQuan.ZZZWidthFactor = 2F;
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
            // frmThuChiQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 531);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.popupControlContainerFilter);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmThuChiQL";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thu chi";
            this.Load += new System.EventHandler(this.frmThuChiQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).EndInit();
            this.popupControlContainerFilter.ResumeLayout(false);
            this.popupControlContainerFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Chi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Thu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Calc_SoTienDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Calc_SoTienTu.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraEditors.CalcEdit Calc_SoTienDen;
        private DevExpress.XtraEditors.CalcEdit Calc_SoTienTu;
        private System.Data.DataSet ds;
        private PLCombobox Filter_LoaiChiPhi;
        private PLDMGrid Filter_NguoiLienQuan;
        private DevExpress.XtraEditors.CheckEdit chk_Chi;
        private DevExpress.XtraEditors.CheckEdit chk_Thu;
        private DevExpress.XtraGrid.Views.Grid.PLGridView gridView1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemChot;
        private DevExpress.XtraBars.BarButtonItem barButtonItemNoChot;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Chot;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_NoChot;
        protected DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_ID;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_MaPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_NgayPhatSinh;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_DienGiai;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_LoaiChiPhi;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_DonViLienQuan;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_NguoiLienQuan;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_TonDauKy;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_Thu;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_Chi;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_TonCuoiKy;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_TrangThai;
        private System.Windows.Forms.PLLabel plLabel1;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel labelControl7;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel labelControl5;
        private ProtocolVN.Framework.Win.Office.PLDateSelection ngayKT;
        
      
        
    }
}