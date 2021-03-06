namespace office
{
    partial class frmPhieuThuChiMan
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
                
                throw ex;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuThuChiMan));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.MainBar = new DevExpress.XtraBars.Bar();
            this.barButtonItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemThu = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChi = new DevExpress.XtraBars.BarButtonItem();
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
            this.colMasterID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterLcp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterEmp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterTienThu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterTienChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cplMasterNgayPs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterNgayTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterNguoiTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterDienGiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterThuChiBit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.xtraTabControlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageDetail = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewDetail = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.popupControlContainerFilter = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.chkLocKKD = new DevExpress.XtraEditors.CheckEdit();
            this.cmbKyKD = new ProtocolVN.Framework.Win.PLCombobox();
            this.cmbEmp = new ProtocolVN.Framework.Win.PLDMGrid();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.dateTo = new DevExpress.XtraEditors.DateEdit();
            this.dateFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkChi = new DevExpress.XtraEditors.CheckEdit();
            this.chkThu = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).BeginInit();
            this.xtraTabControlDetail.SuspendLayout();
            this.xtraTabPageDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).BeginInit();
            this.popupControlContainerFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLocKKD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThu.Properties)).BeginInit();
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
            
            this.barSubItem2,
            this.barButtonItemThu,
            this.barButtonItemChi});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, this.barButtonItemAdd, "&Thêm"),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemXem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemUpdate),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemPrint, true),
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
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Thêm";
            this.barSubItem2.Id = 37;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemThu),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemChi)});
            this.barSubItem2.Name = "barSubItem2";
            this.barSubItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;

            // 
            // barButtonItem5
            // 
            this.barButtonItemThu.Caption = "Tạo phiếu &thu";
            this.barButtonItemThu.Id = 38;
            this.barButtonItemThu.Name = "barButtonItemThu";
            this.barButtonItemThu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.itemAdd_Click);
            // 
            // barButtonItem6
            // 
            this.barButtonItemChi.Caption = "Tạo phiếu &chi";
            this.barButtonItemChi.Id = 39;
            this.barButtonItemChi.Name = "barButtonItemChi";
            this.barButtonItemChi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.itemAdd_Click);
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
            this.barButtonItemSearch.Caption = "Tìm kiếm";
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
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 97);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlMaster);
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlDetail);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(856, 400);
            this.splitContainerControl1.SplitterPosition = 175;
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
            this.repositoryItemCheckEdit1});
            this.gridControlMaster.Size = new System.Drawing.Size(856, 175);
            this.gridControlMaster.TabIndex = 8;
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
            this.colMasterID,
            this.colMasterCode,
            this.colMasterLcp,
            this.colMasterEmp,
            this.colMasterDonVi,
            this.colMasterTienThu,
            this.colMasterTienChi,
            this.cplMasterNgayPs,
            this.colMasterNgayTao,
            this.colMasterNguoiTao,
            this.colMasterDienGiai,
            this.colMasterThuChiBit});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupPanelText = "DANH SÁCH CÁC PHIẾU THU/CHI";
            this.gridViewMaster.IndicatorWidth = 40;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewMaster.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewMaster.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewMaster.OptionsSelection.MultiSelect = true;
            this.gridViewMaster.OptionsView.ColumnAutoWidth = false;
            this.gridViewMaster.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMaster.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = true;
            // 
            // colMasterID
            // 
            this.colMasterID.Caption = "ID";
            this.colMasterID.Name = "colMasterID";
            this.colMasterID.Width = 23;
            // 
            // colMasterCode
            // 
            this.colMasterCode.Caption = "Mã phiếu";
            this.colMasterCode.Name = "colMasterCode";
            this.colMasterCode.Visible = true;
            this.colMasterCode.VisibleIndex = 0;
            this.colMasterCode.Width = 55;
            // 
            // colMasterLcp
            // 
            this.colMasterLcp.Caption = "Loại phát sinh";
            this.colMasterLcp.Name = "colMasterLcp";
            this.colMasterLcp.Visible = true;
            this.colMasterLcp.VisibleIndex = 1;
            this.colMasterLcp.Width = 78;
            // 
            // colMasterEmp
            // 
            this.colMasterEmp.Caption = "Người liên quan";
            this.colMasterEmp.Name = "colMasterEmp";
            this.colMasterEmp.Visible = true;
            this.colMasterEmp.VisibleIndex = 2;
            this.colMasterEmp.Width = 86;
            // 
            // colMasterDonVi
            // 
            this.colMasterDonVi.Caption = "Đơn vị liên quan";
            this.colMasterDonVi.Name = "colMasterDonVi";
            this.colMasterDonVi.Visible = true;
            this.colMasterDonVi.VisibleIndex = 3;
            this.colMasterDonVi.Width = 89;
            // 
            // colMasterTienThu
            // 
            this.colMasterTienThu.Caption = "Số tiền thu(VNĐ)";
            this.colMasterTienThu.Name = "colMasterTienThu";
            this.colMasterTienThu.Visible = true;
            this.colMasterTienThu.VisibleIndex = 4;
            this.colMasterTienThu.Width = 93;
            // 
            // colMasterTienChi
            // 
            this.colMasterTienChi.Caption = "Số tiền chi(VNĐ)";
            this.colMasterTienChi.Name = "colMasterTienChi";
            this.colMasterTienChi.Visible = true;
            this.colMasterTienChi.VisibleIndex = 5;
            this.colMasterTienChi.Width = 90;
            // 
            // cplMasterNgayPs
            // 
            this.cplMasterNgayPs.Caption = "Ngày phát sinh";
            this.cplMasterNgayPs.Name = "cplMasterNgayPs";
            this.cplMasterNgayPs.Visible = true;
            this.cplMasterNgayPs.VisibleIndex = 6;
            this.cplMasterNgayPs.Width = 84;
            // 
            // colMasterNgayTao
            // 
            this.colMasterNgayTao.Caption = "Ngày cập nhật";
            this.colMasterNgayTao.Name = "colMasterNgayTao";
            this.colMasterNgayTao.Visible = true;
            this.colMasterNgayTao.VisibleIndex = 7;
            this.colMasterNgayTao.Width = 82;
            // 
            // colMasterNguoiTao
            // 
            this.colMasterNguoiTao.Caption = "Người cập nhật";
            this.colMasterNguoiTao.Name = "colMasterNguoiTao";
            this.colMasterNguoiTao.Visible = true;
            this.colMasterNguoiTao.VisibleIndex = 8;
            this.colMasterNguoiTao.Width = 85;
            // 
            // colMasterDienGiai
            // 
            this.colMasterDienGiai.Caption = "Diễn giải";
            this.colMasterDienGiai.Name = "colMasterDienGiai";
            this.colMasterDienGiai.Visible = true;
            this.colMasterDienGiai.VisibleIndex = 9;
            this.colMasterDienGiai.Width = 52;
            // 
            // colMasterThuChiBit
            // 
            this.colMasterThuChiBit.Caption = "Thu/Chi";
            this.colMasterThuChiBit.Name = "colMasterThuChiBit";
            this.colMasterThuChiBit.Visible = true;
            this.colMasterThuChiBit.VisibleIndex = 10;
            this.colMasterThuChiBit.Width = 49;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // xtraTabControlDetail
            // 
            this.xtraTabControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlDetail.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlDetail.Name = "xtraTabControlDetail";
            this.xtraTabControlDetail.SelectedTabPage = this.xtraTabPageDetail;
            this.xtraTabControlDetail.Size = new System.Drawing.Size(856, 219);
            this.xtraTabControlDetail.TabIndex = 10;
            this.xtraTabControlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageDetail});
            // 
            // xtraTabPageDetail
            // 
            this.xtraTabPageDetail.Controls.Add(this.gridControlDetail);
            this.xtraTabPageDetail.Name = "xtraTabPageDetail";
            this.xtraTabPageDetail.Size = new System.Drawing.Size(849, 190);
            this.xtraTabPageDetail.Text = "Chi tiết";
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlDetail.BackgroundImage")));
            this.gridControlDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDetail.Location = new System.Drawing.Point(0, 0);
            this.gridControlDetail.MainView = this.gridViewDetail;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.Size = new System.Drawing.Size(849, 190);
            this.gridControlDetail.TabIndex = 9;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetail});
            // 
            // gridViewDetail
            // 
            this.gridViewDetail.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewDetail.GridControl = this.gridControlDetail;
            this.gridViewDetail.IndicatorWidth = 40;
            this.gridViewDetail.Name = "gridViewDetail";
            this.gridViewDetail.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewDetail.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewDetail.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewDetail.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewDetail.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewDetail.OptionsView.ShowGroupedColumns = true;
            this.gridViewDetail.OptionsView.ShowGroupPanel = false;
            // 
            // popupControlContainerFilter
            // 
            this.popupControlContainerFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainerFilter.Controls.Add(this.chkLocKKD);
            this.popupControlContainerFilter.Controls.Add(this.cmbKyKD);
            this.popupControlContainerFilter.Controls.Add(this.cmbEmp);
            this.popupControlContainerFilter.Controls.Add(this.txtCode);
            this.popupControlContainerFilter.Controls.Add(this.dateTo);
            this.popupControlContainerFilter.Controls.Add(this.dateFrom);
            this.popupControlContainerFilter.Controls.Add(this.labelControl2);
            this.popupControlContainerFilter.Controls.Add(this.chkChi);
            this.popupControlContainerFilter.Controls.Add(this.chkThu);
            this.popupControlContainerFilter.Controls.Add(this.labelControl4);
            this.popupControlContainerFilter.Controls.Add(this.labelControl3);
            this.popupControlContainerFilter.Controls.Add(this.labelControl5);
            this.popupControlContainerFilter.Controls.Add(this.labelControl1);
            this.popupControlContainerFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupControlContainerFilter.Location = new System.Drawing.Point(0, 24);
            this.popupControlContainerFilter.Manager = this.barManager1;
            this.popupControlContainerFilter.Name = "popupControlContainerFilter";
            this.popupControlContainerFilter.Size = new System.Drawing.Size(856, 73);
            this.popupControlContainerFilter.TabIndex = 5;
            this.popupControlContainerFilter.Visible = false;
            // 
            // chkLocKKD
            // 
            this.chkLocKKD.Location = new System.Drawing.Point(695, 12);
            this.chkLocKKD.Name = "chkLocKKD";
            this.chkLocKKD.Properties.Caption = "Lọc theo kỳ kinh doanh";
            this.chkLocKKD.Size = new System.Drawing.Size(149, 19);
            this.chkLocKKD.TabIndex = 154;
            // 
            // cmbKyKD
            // 
            this.cmbKyKD.DataSource = null;
            this.cmbKyKD.DisplayField = null;
            this.cmbKyKD.Location = new System.Drawing.Point(412, 11);
            this.cmbKyKD.Name = "cmbKyKD";
            this.cmbKyKD.Size = new System.Drawing.Size(277, 20);
            this.cmbKyKD.TabIndex = 153;
            this.cmbKyKD.ValueField = null;
            // 
            // cmbEmp
            // 
            this.cmbEmp.Location = new System.Drawing.Point(87, 42);
            this.cmbEmp.Name = "cmbEmp";
            this.cmbEmp.Size = new System.Drawing.Size(228, 20);
            this.cmbEmp.TabIndex = 152;
            this.cmbEmp.ZZZWidthFactor = 2F;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(87, 11);
            this.txtCode.MenuManager = this.barManager1;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(134, 20);
            this.txtCode.TabIndex = 3;
            // 
            // dateTo
            // 
            this.dateTo.EditValue = null;
            this.dateTo.Location = new System.Drawing.Point(571, 42);
            this.dateTo.Name = "dateTo";
            this.dateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateTo.Size = new System.Drawing.Size(118, 20);
            this.dateTo.TabIndex = 2;
            // 
            // dateFrom
            // 
            this.dateFrom.EditValue = null;
            this.dateFrom.Location = new System.Drawing.Point(412, 42);
            this.dateFrom.MenuManager = this.barManager1;
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateFrom.Size = new System.Drawing.Size(118, 20);
            this.dateFrom.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(546, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "đến";
            // 
            // chkChi
            // 
            this.chkChi.Location = new System.Drawing.Point(279, 12);
            this.chkChi.Name = "chkChi";
            this.chkChi.Properties.Caption = "Chi";
            this.chkChi.Size = new System.Drawing.Size(48, 19);
            this.chkChi.TabIndex = 1;
            // 
            // chkThu
            // 
            this.chkThu.Location = new System.Drawing.Point(226, 12);
            this.chkThu.MenuManager = this.barManager1;
            this.chkThu.Name = "chkThu";
            this.chkThu.Properties.Caption = "Thu";
            this.chkThu.Size = new System.Drawing.Size(48, 19);
            this.chkThu.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(8, 46);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(74, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Người liên quan";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(43, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Mã phiếu";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(339, 15);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(67, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Kỳ kinh doanh";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(339, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ ngày";
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
            // frmPhieuThuChiMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 497);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.popupControlContainerFilter);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmPhieuThuChiMan";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).EndInit();
            this.xtraTabControlDetail.ResumeLayout(false);
            this.xtraTabPageDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).EndInit();
            this.popupControlContainerFilter.ResumeLayout(false);
            this.popupControlContainerFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLocKKD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThu.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colMasterID;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterLcp;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterEmp;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn cplMasterNgayPs;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterNgayTao;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterNguoiTao;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterTienThu;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterTienChi;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterDienGiai;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterThuChiBit;
        private DevExpress.XtraEditors.DateEdit dateTo;
        private DevExpress.XtraEditors.DateEdit dateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit chkThu;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.CheckEdit chkChi;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private ProtocolVN.Framework.Win.PLDMGrid cmbEmp;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit chkLocKKD;
        private ProtocolVN.Framework.Win.PLCombobox cmbKyKD;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        
        public DevExpress.XtraBars.BarSubItem barSubItem2;
        public DevExpress.XtraBars.BarButtonItem barButtonItemThu;
        public DevExpress.XtraBars.BarButtonItem barButtonItemChi;
    }
}