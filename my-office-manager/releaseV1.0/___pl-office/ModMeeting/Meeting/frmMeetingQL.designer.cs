
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmMeetingQL
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
            catch { throw; }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeetingQL));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.MainBar = new DevExpress.XtraBars.Bar();
            this.barButtonItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemSearch = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuFilter = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barCheckItemFilter = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.Tuan = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.Ngay = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.Thang = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.Ngaythuchien = new DevExpress.XtraScheduler.DateNavigator();
            this.schedulerControl = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.barButtonItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCommit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemNoCommit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDuyet = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemK_Duyet = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.xtraTabControlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageChiTiet = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewDetail = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.ID = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cotNgay = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cotGioBD = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cotGioKT = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cotNoiDung = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repNoiDung = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.layoutViewField_layoutViewColumn1_4 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.cotDiaDiemHop = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repDiaDiemHop = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.layoutViewField_layoutViewColumn1_5 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.item1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item2 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.repositoryItemButtonEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemButtonEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemMemoExEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.rep_mofile = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.rep_luu_file = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repDiaDiem = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.xtraTabPageDetail = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.CotThoiGianBatDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotThoiGianKetThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotDiaDiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotNguoiToChuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTinhChat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotLoaiMeeting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotKetQua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.rtxVanBan = new System.Windows.Forms.RichTextBox();
            this.popupControlContainerFilter = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.cboNguoiToChuc = new ProtocolVN.Framework.Win.PLCombobox();
            this.txtDiaDiem = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.PLLabel();
            this.cboTinhChat = new ProtocolVN.Framework.Win.PLCombobox();
            this.label3 = new System.Windows.Forms.PLLabel();
            this.label2 = new System.Windows.Forms.PLLabel();
            this.cboLoai = new ProtocolVN.Framework.Win.PLCombobox();
            this.label1 = new System.Windows.Forms.PLLabel();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.checkEdit1 = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.checkEdit2 = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.checkEdit3 = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.imageList_layout = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tuan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Thang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ngaythuchien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).BeginInit();
            this.xtraTabControlDetail.SuspendLayout();
            this.xtraTabPageChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNoiDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDiaDiemHop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_mofile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_luu_file)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDiaDiem)).BeginInit();
            this.xtraTabPageDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).BeginInit();
            this.popupControlContainerFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaDiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
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
            this.barButtonItemDuyet,
            this.barButtonItemK_Duyet});
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
            this.barButtonItemSearch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            this.barCheckItemFilter.Caption = "Điề&u kiện tìm kiếm";
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
            this.barDockControlTop.Size = new System.Drawing.Size(943, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 579);
            this.barDockControlBottom.Size = new System.Drawing.Size(943, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 555);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(943, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 555);
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
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("b41cff86-da37-41cb-9b0d-062fa10996a9");
            this.dockPanel1.Location = new System.Drawing.Point(0, 24);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 555);
            this.dockPanel1.Text = "Tùy chọn";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panelControl2);
            this.dockPanel1_Container.Controls.Add(this.labelControl5);
            this.dockPanel1_Container.Controls.Add(this.Ngaythuchien);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(194, 527);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.Tuan);
            this.panelControl2.Controls.Add(this.Ngay);
            this.panelControl2.Controls.Add(this.Thang);
            this.panelControl2.Location = new System.Drawing.Point(8, 196);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(178, 96);
            this.panelControl2.TabIndex = 99;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 13);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "Tùy chọn hiển thị";
            this.labelControl2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // Tuan
            // 
            this.Tuan.Location = new System.Drawing.Point(18, 49);
            this.Tuan.Name = "Tuan";
            this.Tuan.Properties.Caption = "Theo tuần";
            this.Tuan.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.Tuan.Properties.RadioGroupIndex = 1;
            this.Tuan.Size = new System.Drawing.Size(83, 19);
            this.Tuan.TabIndex = 21;
            this.Tuan.TabStop = false;
            this.Tuan.ToolTip = "Dữ liệu bắt buộc nhập";
            this.Tuan.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
            this.Tuan.CheckedChanged += new System.EventHandler(this.Tuan_CheckedChanged);
            // 
            // Ngay
            // 
            this.Ngay.Location = new System.Drawing.Point(18, 24);
            this.Ngay.Name = "Ngay";
            this.Ngay.Properties.Caption = "Theo ngày";
            this.Ngay.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.Ngay.Properties.RadioGroupIndex = 1;
            this.Ngay.Size = new System.Drawing.Size(83, 19);
            this.Ngay.TabIndex = 17;
            this.Ngay.TabStop = false;
            this.Ngay.ToolTip = "Dữ liệu bắt buộc nhập";
            this.Ngay.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
            this.Ngay.CheckedChanged += new System.EventHandler(this.Ngay_CheckedChanged);
            // 
            // Thang
            // 
            this.Thang.Location = new System.Drawing.Point(18, 74);
            this.Thang.Name = "Thang";
            this.Thang.Properties.Caption = "Theo tháng";
            this.Thang.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.Thang.Properties.RadioGroupIndex = 1;
            this.Thang.Size = new System.Drawing.Size(83, 19);
            this.Thang.TabIndex = 18;
            this.Thang.TabStop = false;
            this.Thang.ToolTip = "Dữ liệu bắt buộc nhập";
            this.Thang.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
            this.Thang.CheckedChanged += new System.EventHandler(this.Thang_CheckedChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 3);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(43, 13);
            this.labelControl5.TabIndex = 84;
            this.labelControl5.Text = "Thời gian";
            this.labelControl5.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // Ngaythuchien
            // 
            this.Ngaythuchien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Ngaythuchien.HotDate = null;
            this.Ngaythuchien.Location = new System.Drawing.Point(8, 22);
            this.Ngaythuchien.Name = "Ngaythuchien";
            this.Ngaythuchien.SchedulerControl = this.schedulerControl;
            this.Ngaythuchien.Size = new System.Drawing.Size(178, 168);
            this.Ngaythuchien.TabIndex = 82;
            // 
            // schedulerControl
            // 
            this.schedulerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl.MenuManager = this.barManager1;
            this.schedulerControl.Name = "schedulerControl";
            this.schedulerControl.OptionsCustomization.AllowAppointmentCopy = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl.OptionsCustomization.AllowAppointmentMultiSelect = false;
            this.schedulerControl.OptionsCustomization.AllowAppointmentResize = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl.OptionsView.NavigationButtons.NextCaption = "Sự kiện tiếp theo";
            this.schedulerControl.OptionsView.NavigationButtons.PrevCaption = "Sự kiện trước";
            this.schedulerControl.OptionsView.NavigationButtons.Visibility = DevExpress.XtraScheduler.NavigationButtonVisibility.Never;
            this.schedulerControl.Size = new System.Drawing.Size(743, 489);
            this.schedulerControl.Start = new System.DateTime(2009, 2, 14, 0, 0, 0, 0);
            this.schedulerControl.Storage = this.schedulerStorage;
            this.schedulerControl.TabIndex = 12;
            this.schedulerControl.Text = "schedulerControl1";
            this.schedulerControl.Views.DayView.AllDayAreaScrollBarVisible = true;
            this.schedulerControl.Views.DayView.AppointmentDisplayOptions.EndTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never;
            this.schedulerControl.Views.DayView.AppointmentDisplayOptions.StartTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never;
            this.schedulerControl.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl.Views.DayView.WorkTime.End = System.TimeSpan.Parse("17:00:00");
            this.schedulerControl.Views.DayView.WorkTime.Start = System.TimeSpan.Parse("08:00:00");
            this.schedulerControl.Views.MonthView.AppointmentDisplayOptions.EndTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never;
            this.schedulerControl.Views.MonthView.AppointmentDisplayOptions.StartTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never;
            this.schedulerControl.Views.WeekView.AppointmentDisplayOptions.EndTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never;
            this.schedulerControl.Views.WeekView.AppointmentDisplayOptions.StartTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never;
            this.schedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl.PreparePopupMenu += new DevExpress.XtraScheduler.PreparePopupMenuEventHandler(this.schedulerControl_PreparePopupMenu);
            this.schedulerControl.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControl_EditAppointmentFormShowing);
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
            this.barButtonItem4.Caption = "Xem t&rước";
            this.barButtonItem4.Id = 33;
            this.barButtonItem4.Name = "barButtonItem4";
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
            // barButtonItem3
            // 
            this.barButtonItem3.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem3.Caption = "In";
            this.barButtonItem3.Id = 30;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItemDuyet
            // 
            this.barButtonItemDuyet.Caption = "&Duyệt";
            this.barButtonItemDuyet.Enabled = false;
            this.barButtonItemDuyet.Id = 35;
            this.barButtonItemDuyet.Name = "barButtonItemDuyet";
            this.barButtonItemDuyet.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItemK_Duyet
            // 
            this.barButtonItemK_Duyet.Caption = "&Không duyệt";
            this.barButtonItemK_Duyet.Enabled = false;
            this.barButtonItemK_Duyet.Id = 36;
            this.barButtonItemK_Duyet.Name = "barButtonItemK_Duyet";
            this.barButtonItemK_Duyet.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(200, 90);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.schedulerControl);
            this.splitContainerControl1.Panel1.MinSize = 200;
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlDetail);
            this.splitContainerControl1.Panel2.MinSize = 150;
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            this.splitContainerControl1.Size = new System.Drawing.Size(743, 489);
            this.splitContainerControl1.SplitterPosition = 240;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // xtraTabControlDetail
            // 
            this.xtraTabControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlDetail.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlDetail.Name = "xtraTabControlDetail";
            this.xtraTabControlDetail.SelectedTabPage = this.xtraTabPageChiTiet;
            this.xtraTabControlDetail.Size = new System.Drawing.Size(0, 0);
            this.xtraTabControlDetail.TabIndex = 0;
            this.xtraTabControlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageDetail,
            this.xtraTabPageChiTiet,
            this.xtraTabPage2});
            // 
            // xtraTabPageChiTiet
            // 
            this.xtraTabPageChiTiet.Controls.Add(this.gridControlDetail);
            this.xtraTabPageChiTiet.Name = "xtraTabPageChiTiet";
            this.xtraTabPageChiTiet.Size = new System.Drawing.Size(0, 0);
            this.xtraTabPageChiTiet.Text = "Chi tiết";
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlDetail.BackgroundImage")));
            this.gridControlDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDetail.Location = new System.Drawing.Point(0, 0);
            this.gridControlDetail.MainView = this.gridViewDetail;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit3,
            this.repositoryItemPictureEdit1,
            this.repositoryItemPictureEdit2,
            this.repositoryItemMemoEdit1,
            this.repDiaDiemHop,
            this.repositoryItemButtonEdit4,
            this.repositoryItemButtonEdit5,
            this.repositoryItemMemoExEdit2,
            this.rep_mofile,
            this.rep_luu_file,
            this.repNoiDung,
            this.repDiaDiem});
            this.gridControlDetail.Size = new System.Drawing.Size(0, 0);
            this.gridControlDetail.TabIndex = 191;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetail});
            // 
            // gridViewDetail
            // 
            this.gridViewDetail.CardCaptionFormat = "Ngày họp: {3}, từ: {4} - {5}";
            this.gridViewDetail.CardHorzInterval = 13;
            this.gridViewDetail.CardMinSize = new System.Drawing.Size(270, 151);
            this.gridViewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.ID,
            this.cotNgay,
            this.cotGioBD,
            this.cotGioKT,
            this.cotNoiDung,
            this.cotDiaDiemHop});
            this.gridViewDetail.GridControl = this.gridControlDetail;
            this.gridViewDetail.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn1,
            this.layoutViewField_layoutViewColumn1_1,
            this.layoutViewField_layoutViewColumn1_2,
            this.layoutViewField_layoutViewColumn1_3});
            this.gridViewDetail.Name = "gridViewDetail";
            this.gridViewDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewDetail.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.gridViewDetail.OptionsCustomization.AllowFilter = false;
            this.gridViewDetail.OptionsCustomization.AllowSort = false;
            this.gridViewDetail.OptionsHeaderPanel.EnableCustomizeButton = false;
            this.gridViewDetail.OptionsItemText.AlignMode = DevExpress.XtraGrid.Views.Layout.FieldTextAlignMode.CustomSize;
            this.gridViewDetail.OptionsItemText.TextToControlDistance = 0;
            this.gridViewDetail.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewDetail.OptionsView.AllowHotTrackFields = false;
            this.gridViewDetail.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
            this.gridViewDetail.TemplateCard = this.layoutViewCard1;
            // 
            // ID
            // 
            this.ID.Caption = "id";
            this.ID.LayoutViewField = this.layoutViewField_layoutViewColumn1;
            this.ID.Name = "ID";
            // 
            // layoutViewField_layoutViewColumn1
            // 
            this.layoutViewField_layoutViewColumn1.EditorPreferredWidth = 10;
            this.layoutViewField_layoutViewColumn1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1.Name = "layoutViewField_layoutViewColumn1";
            this.layoutViewField_layoutViewColumn1.Size = new System.Drawing.Size(264, 125);
            this.layoutViewField_layoutViewColumn1.TextSize = new System.Drawing.Size(97, 13);
            this.layoutViewField_layoutViewColumn1.TextToControlDistance = 5;
            // 
            // cotNgay
            // 
            this.cotNgay.Caption = "Ngày họp";
            this.cotNgay.LayoutViewField = this.layoutViewField_layoutViewColumn1_1;
            this.cotNgay.Name = "cotNgay";
            this.cotNgay.OptionsColumn.AllowEdit = false;
            this.cotNgay.OptionsColumn.AllowFocus = false;
            this.cotNgay.OptionsColumn.ReadOnly = true;
            // 
            // layoutViewField_layoutViewColumn1_1
            // 
            this.layoutViewField_layoutViewColumn1_1.EditorPreferredWidth = 20;
            this.layoutViewField_layoutViewColumn1_1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1_1.Name = "layoutViewField_layoutViewColumn1_1";
            this.layoutViewField_layoutViewColumn1_1.Size = new System.Drawing.Size(264, 125);
            this.layoutViewField_layoutViewColumn1_1.TextSize = new System.Drawing.Size(50, 13);
            this.layoutViewField_layoutViewColumn1_1.TextToControlDistance = 5;
            // 
            // cotGioBD
            // 
            this.cotGioBD.Caption = "Từ";
            this.cotGioBD.CustomizationCaption = "Từ";
            this.cotGioBD.LayoutViewField = this.layoutViewField_layoutViewColumn1_2;
            this.cotGioBD.Name = "cotGioBD";
            this.cotGioBD.OptionsColumn.AllowEdit = false;
            this.cotGioBD.OptionsColumn.AllowFocus = false;
            this.cotGioBD.OptionsColumn.ReadOnly = true;
            // 
            // layoutViewField_layoutViewColumn1_2
            // 
            this.layoutViewField_layoutViewColumn1_2.EditorPreferredWidth = 20;
            this.layoutViewField_layoutViewColumn1_2.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1_2.Name = "layoutViewField_layoutViewColumn1_2";
            this.layoutViewField_layoutViewColumn1_2.Size = new System.Drawing.Size(264, 125);
            this.layoutViewField_layoutViewColumn1_2.TextSize = new System.Drawing.Size(17, 13);
            this.layoutViewField_layoutViewColumn1_2.TextToControlDistance = 5;
            // 
            // cotGioKT
            // 
            this.cotGioKT.Caption = "đến";
            this.cotGioKT.LayoutViewField = this.layoutViewField_layoutViewColumn1_3;
            this.cotGioKT.Name = "cotGioKT";
            this.cotGioKT.OptionsColumn.AllowEdit = false;
            this.cotGioKT.OptionsColumn.AllowFocus = false;
            this.cotGioKT.OptionsColumn.ReadOnly = true;
            // 
            // layoutViewField_layoutViewColumn1_3
            // 
            this.layoutViewField_layoutViewColumn1_3.EditorPreferredWidth = 20;
            this.layoutViewField_layoutViewColumn1_3.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_layoutViewColumn1_3.Name = "layoutViewField_layoutViewColumn1_3";
            this.layoutViewField_layoutViewColumn1_3.Size = new System.Drawing.Size(264, 125);
            this.layoutViewField_layoutViewColumn1_3.TextSize = new System.Drawing.Size(22, 13);
            this.layoutViewField_layoutViewColumn1_3.TextToControlDistance = 5;
            // 
            // cotNoiDung
            // 
            this.cotNoiDung.ColumnEdit = this.repNoiDung;
            this.cotNoiDung.LayoutViewField = this.layoutViewField_layoutViewColumn1_4;
            this.cotNoiDung.Name = "cotNoiDung";
            this.cotNoiDung.OptionsColumn.ReadOnly = true;
            // 
            // repNoiDung
            // 
            this.repNoiDung.Name = "repNoiDung";
            // 
            // layoutViewField_layoutViewColumn1_4
            // 
            this.layoutViewField_layoutViewColumn1_4.EditorPreferredWidth = 260;
            this.layoutViewField_layoutViewColumn1_4.Location = new System.Drawing.Point(0, 17);
            this.layoutViewField_layoutViewColumn1_4.MaxSize = new System.Drawing.Size(264, 45);
            this.layoutViewField_layoutViewColumn1_4.MinSize = new System.Drawing.Size(264, 45);
            this.layoutViewField_layoutViewColumn1_4.Name = "layoutViewField_layoutViewColumn1_4";
            this.layoutViewField_layoutViewColumn1_4.Size = new System.Drawing.Size(264, 45);
            this.layoutViewField_layoutViewColumn1_4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_layoutViewColumn1_4.TextSize = new System.Drawing.Size(0, 13);
            // 
            // cotDiaDiemHop
            // 
            this.cotDiaDiemHop.ColumnEdit = this.repDiaDiemHop;
            this.cotDiaDiemHop.LayoutViewField = this.layoutViewField_layoutViewColumn1_5;
            this.cotDiaDiemHop.Name = "cotDiaDiemHop";
            this.cotDiaDiemHop.OptionsColumn.ReadOnly = true;
            // 
            // repDiaDiemHop
            // 
            this.repDiaDiemHop.Name = "repDiaDiemHop";
            // 
            // layoutViewField_layoutViewColumn1_5
            // 
            this.layoutViewField_layoutViewColumn1_5.EditorPreferredWidth = 260;
            this.layoutViewField_layoutViewColumn1_5.Location = new System.Drawing.Point(0, 79);
            this.layoutViewField_layoutViewColumn1_5.MaxSize = new System.Drawing.Size(264, 46);
            this.layoutViewField_layoutViewColumn1_5.MinSize = new System.Drawing.Size(264, 46);
            this.layoutViewField_layoutViewColumn1_5.Name = "layoutViewField_layoutViewColumn1_5";
            this.layoutViewField_layoutViewColumn1_5.Size = new System.Drawing.Size(264, 46);
            this.layoutViewField_layoutViewColumn1_5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_layoutViewColumn1_5.TextSize = new System.Drawing.Size(0, 13);
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "layoutViewCard1";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn1_4,
            this.layoutViewField_layoutViewColumn1_5,
            this.item1,
            this.item2});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 0;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // item1
            // 
            this.item1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item1.AppearanceItemCaption.Options.UseFont = true;
            this.item1.CustomizationFormText = "Nội dung:";
            this.item1.Location = new System.Drawing.Point(0, 0);
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(264, 17);
            this.item1.Text = "Nội dung:";
            this.item1.TextSize = new System.Drawing.Size(46, 13);
            // 
            // item2
            // 
            this.item2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.item2.AppearanceItemCaption.Options.UseFont = true;
            this.item2.CustomizationFormText = "Địa điểm:";
            this.item2.Location = new System.Drawing.Point(0, 62);
            this.item2.Name = "item2";
            this.item2.Size = new System.Drawing.Size(264, 17);
            this.item2.Text = "Địa điểm:";
            this.item2.TextSize = new System.Drawing.Size(45, 13);
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
            // rep_mofile
            // 
            this.rep_mofile.AppearanceFocused.Options.UseImage = true;
            this.rep_mofile.Name = "rep_mofile";
            // 
            // rep_luu_file
            // 
            this.rep_luu_file.Name = "rep_luu_file";
            // 
            // repDiaDiem
            // 
            this.repDiaDiem.AutoHeight = false;
            this.repDiaDiem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDiaDiem.Name = "repDiaDiem";
            // 
            // xtraTabPageDetail
            // 
            this.xtraTabPageDetail.Controls.Add(this.gridControlMaster);
            this.xtraTabPageDetail.Name = "xtraTabPageDetail";
            this.xtraTabPageDetail.PageVisible = false;
            this.xtraTabPageDetail.Size = new System.Drawing.Size(0, 0);
            this.xtraTabPageDetail.Text = "Chi tiết ";
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
            this.repositoryItemButtonEdit1,
            this.repositoryItemImageComboBox1});
            this.gridControlMaster.Size = new System.Drawing.Size(0, 0);
            this.gridControlMaster.TabIndex = 0;
            this.gridControlMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMaster});
            // 
            // gridViewMaster
            // 
            this.gridViewMaster.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewMaster.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CotThoiGianBatDau,
            this.CotThoiGianKetThuc,
            this.CotDiaDiem,
            this.CotNguoiToChuc,
            this.CotTinhChat,
            this.CotLoaiMeeting,
            this.CotKetQua});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.IndicatorWidth = 40;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.NewItemRowText = "Nhập dữ liệu mới tại đây";
            this.gridViewMaster.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridViewMaster.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewMaster.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewMaster.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewMaster.OptionsPrint.UsePrintStyles = true;
            this.gridViewMaster.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMaster.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = true;
            this.gridViewMaster.OptionsView.ShowGroupPanel = false;
            // 
            // CotThoiGianBatDau
            // 
            this.CotThoiGianBatDau.Caption = "Giờ bắt đầu";
            this.CotThoiGianBatDau.Name = "CotThoiGianBatDau";
            this.CotThoiGianBatDau.OptionsColumn.AllowEdit = false;
            this.CotThoiGianBatDau.OptionsColumn.AllowFocus = false;
            this.CotThoiGianBatDau.Visible = true;
            this.CotThoiGianBatDau.VisibleIndex = 2;
            this.CotThoiGianBatDau.Width = 67;
            // 
            // CotThoiGianKetThuc
            // 
            this.CotThoiGianKetThuc.Caption = "Giờ kết thúc";
            this.CotThoiGianKetThuc.Name = "CotThoiGianKetThuc";
            this.CotThoiGianKetThuc.OptionsColumn.AllowEdit = false;
            this.CotThoiGianKetThuc.OptionsColumn.AllowFocus = false;
            this.CotThoiGianKetThuc.Visible = true;
            this.CotThoiGianKetThuc.VisibleIndex = 3;
            this.CotThoiGianKetThuc.Width = 69;
            // 
            // CotDiaDiem
            // 
            this.CotDiaDiem.Caption = "Địa điểm";
            this.CotDiaDiem.Name = "CotDiaDiem";
            this.CotDiaDiem.OptionsColumn.AllowEdit = false;
            this.CotDiaDiem.OptionsColumn.AllowFocus = false;
            this.CotDiaDiem.OptionsColumn.ReadOnly = true;
            this.CotDiaDiem.Visible = true;
            this.CotDiaDiem.VisibleIndex = 0;
            this.CotDiaDiem.Width = 53;
            // 
            // CotNguoiToChuc
            // 
            this.CotNguoiToChuc.Caption = "Người tổ chức";
            this.CotNguoiToChuc.Name = "CotNguoiToChuc";
            this.CotNguoiToChuc.OptionsColumn.AllowEdit = false;
            this.CotNguoiToChuc.OptionsColumn.AllowFocus = false;
            this.CotNguoiToChuc.Visible = true;
            this.CotNguoiToChuc.VisibleIndex = 1;
            this.CotNguoiToChuc.Width = 79;
            // 
            // CotTinhChat
            // 
            this.CotTinhChat.Caption = "Tính chất";
            this.CotTinhChat.Name = "CotTinhChat";
            this.CotTinhChat.OptionsColumn.AllowEdit = false;
            this.CotTinhChat.OptionsColumn.AllowFocus = false;
            this.CotTinhChat.Visible = true;
            this.CotTinhChat.VisibleIndex = 4;
            this.CotTinhChat.Width = 56;
            // 
            // CotLoaiMeeting
            // 
            this.CotLoaiMeeting.Caption = "Loại";
            this.CotLoaiMeeting.Name = "CotLoaiMeeting";
            this.CotLoaiMeeting.OptionsColumn.AllowEdit = false;
            this.CotLoaiMeeting.OptionsColumn.AllowFocus = false;
            this.CotLoaiMeeting.Visible = true;
            this.CotLoaiMeeting.VisibleIndex = 5;
            this.CotLoaiMeeting.Width = 31;
            // 
            // CotKetQua
            // 
            this.CotKetQua.Caption = "Kết quả";
            this.CotKetQua.Name = "CotKetQua";
            this.CotKetQua.OptionsColumn.AllowEdit = false;
            this.CotKetQua.OptionsColumn.AllowFocus = false;
            this.CotKetQua.OptionsColumn.ReadOnly = true;
            this.CotKetQua.Visible = true;
            this.CotKetQua.VisibleIndex = 6;
            this.CotKetQua.Width = 49;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.rtxVanBan);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.PageVisible = false;
            this.xtraTabPage2.Size = new System.Drawing.Size(0, 0);
            this.xtraTabPage2.Text = "Văn bản họp";
            // 
            // rtxVanBan
            // 
            this.rtxVanBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxVanBan.Location = new System.Drawing.Point(0, 0);
            this.rtxVanBan.MaxLength = 200;
            this.rtxVanBan.Name = "rtxVanBan";
            this.rtxVanBan.ReadOnly = true;
            this.rtxVanBan.Size = new System.Drawing.Size(0, 0);
            this.rtxVanBan.TabIndex = 4;
            this.rtxVanBan.Text = "";
            // 
            // popupControlContainerFilter
            // 
            this.popupControlContainerFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainerFilter.Controls.Add(this.cboNguoiToChuc);
            this.popupControlContainerFilter.Controls.Add(this.txtDiaDiem);
            this.popupControlContainerFilter.Controls.Add(this.label4);
            this.popupControlContainerFilter.Controls.Add(this.cboTinhChat);
            this.popupControlContainerFilter.Controls.Add(this.label3);
            this.popupControlContainerFilter.Controls.Add(this.label2);
            this.popupControlContainerFilter.Controls.Add(this.cboLoai);
            this.popupControlContainerFilter.Controls.Add(this.label1);
            this.popupControlContainerFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupControlContainerFilter.Location = new System.Drawing.Point(200, 24);
            this.popupControlContainerFilter.Manager = this.barManager1;
            this.popupControlContainerFilter.Name = "popupControlContainerFilter";
            this.popupControlContainerFilter.Size = new System.Drawing.Size(743, 66);
            this.popupControlContainerFilter.TabIndex = 0;
            this.popupControlContainerFilter.Visible = false;
            // 
            // cboNguoiToChuc
            // 
            this.cboNguoiToChuc.DataSource = null;
            this.cboNguoiToChuc.DisplayField = null;
            this.cboNguoiToChuc.Location = new System.Drawing.Point(87, 5);
            this.cboNguoiToChuc.Name = "cboNguoiToChuc";
            this.cboNguoiToChuc.Size = new System.Drawing.Size(162, 21);
            this.cboNguoiToChuc.TabIndex = 221;
            this.cboNguoiToChuc.ValueField = null;
            // 
            // txtDiaDiem
            // 
            this.txtDiaDiem.Location = new System.Drawing.Point(343, 34);
            this.txtDiaDiem.Name = "txtDiaDiem";
            this.txtDiaDiem.Size = new System.Drawing.Size(380, 20);
            this.txtDiaDiem.TabIndex = 220;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(265, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Địa điểm";
            this.label4.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label4.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // cboTinhChat
            // 
            this.cboTinhChat.DataSource = null;
            this.cboTinhChat.DisplayField = null;
            this.cboTinhChat.Location = new System.Drawing.Point(87, 32);
            this.cboTinhChat.Name = "cboTinhChat";
            this.cboTinhChat.Size = new System.Drawing.Size(162, 21);
            this.cboTinhChat.TabIndex = 9;
            this.cboTinhChat.ValueField = null;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tính chất";
            this.label3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label3.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(265, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Loại cuộc họp";
            this.label2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // cboLoai
            // 
            this.cboLoai.DataSource = null;
            this.cboLoai.DisplayField = null;
            this.cboLoai.Location = new System.Drawing.Point(343, 5);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(156, 21);
            this.cboLoai.TabIndex = 5;
            this.cboLoai.ValueField = null;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Người tổ chức";
            this.label1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
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
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 13);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "Tùy chọn hiển thị";
            this.labelControl1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(18, 49);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Theo tuần";
            this.checkEdit1.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEdit1.Properties.RadioGroupIndex = 1;
            this.checkEdit1.Size = new System.Drawing.Size(83, 19);
            this.checkEdit1.TabIndex = 21;
            this.checkEdit1.TabStop = false;
            this.checkEdit1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.checkEdit1.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
            // 
            // checkEdit2
            // 
            this.checkEdit2.EditValue = true;
            this.checkEdit2.Location = new System.Drawing.Point(18, 24);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "Theo ngày";
            this.checkEdit2.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEdit2.Properties.RadioGroupIndex = 1;
            this.checkEdit2.Size = new System.Drawing.Size(83, 19);
            this.checkEdit2.TabIndex = 17;
            this.checkEdit2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.checkEdit2.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
            // 
            // checkEdit3
            // 
            this.checkEdit3.Location = new System.Drawing.Point(18, 74);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Caption = "Theo tháng";
            this.checkEdit3.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEdit3.Properties.RadioGroupIndex = 1;
            this.checkEdit3.Size = new System.Drawing.Size(83, 19);
            this.checkEdit3.TabIndex = 18;
            this.checkEdit3.TabStop = false;
            this.checkEdit3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.checkEdit3.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
            // 
            // imageList_layout
            // 
            this.imageList_layout.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_layout.ImageStream")));
            this.imageList_layout.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_layout.Images.SetKeyName(0, "pl-xuatkho.png");
            this.imageList_layout.Images.SetKeyName(1, "fwSave.png");
            this.imageList_layout.Images.SetKeyName(2, "Delete.png");
            // 
            // frmMeetingQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 579);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.popupControlContainerFilter);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmMeetingQL";
            this.Text = "Cuộc họp";
            this.Load += new System.EventHandler(this.frmMeetingQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tuan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Thang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ngaythuchien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).EndInit();
            this.xtraTabControlDetail.ResumeLayout(false);
            this.xtraTabPageChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNoiDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDiaDiemHop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_mofile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_luu_file)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDiaDiem)).EndInit();
            this.xtraTabPageDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).EndInit();
            this.popupControlContainerFilter.ResumeLayout(false);
            this.popupControlContainerFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaDiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl;
        private DevExpress.XtraScheduler.DateNavigator Ngaythuchien;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageChiTiet;
        private PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Layout.LayoutView gridViewDetail;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repDiaDiemHop;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rep_mofile;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit rep_luu_file;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit2;
        private PLCombobox cboLoai;
        private  System.Windows.Forms.PLLabel  label1;
        private PLCombobox cboTinhChat;
        private  System.Windows.Forms.PLLabel  label3;
        private  System.Windows.Forms.PLLabel  label2;
        private  System.Windows.Forms.PLLabel  label4;
        private TextEdit txtDiaDiem;
        private DevExpress.XtraGrid.Columns.GridColumn CotThoiGianBatDau;
        private DevExpress.XtraGrid.Columns.GridColumn CotThoiGianKetThuc;
        private DevExpress.XtraGrid.Columns.GridColumn CotDiaDiem;
        private DevExpress.XtraGrid.Columns.GridColumn CotNguoiToChuc;
        private DevExpress.XtraGrid.Columns.GridColumn CotTinhChat;
        private DevExpress.XtraGrid.Columns.GridColumn CotLoaiMeeting;
        private DevExpress.XtraGrid.Columns.GridColumn CotKetQua;
        private PLCombobox cboNguoiToChuc;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage;
        private System.Windows.Forms.ImageList imageList_layout;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.RichTextBox rtxVanBan;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel labelControl2;
        private PLCheckEdit Tuan;
        private PLCheckEdit Ngay;
        private PLCheckEdit Thang;
        private System.Windows.Forms.PLLabel labelControl1;
        private PLCheckEdit checkEdit1;
        private PLCheckEdit checkEdit2;
        private PLCheckEdit checkEdit3;
        public DevExpress.XtraBars.BarButtonItem barButtonItemDuyet;
        public DevExpress.XtraBars.BarButtonItem barButtonItemK_Duyet;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cotNgay;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cotGioBD;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cotGioKT;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cotNoiDung;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn cotDiaDiemHop;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repNoiDung;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repDiaDiem;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_4;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_5;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.SimpleLabelItem item1;
        private DevExpress.XtraLayout.SimpleLabelItem item2;



    }
}