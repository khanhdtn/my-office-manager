
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using DevExpress.XtraGrid.Views.Grid;
namespace office
{
    partial class frmHomThuGopYQL
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                try
                {
                    components.Dispose();
                }
                catch { }
                
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHomThuGopYQL));
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
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.colMaster_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaster_NoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaster_NguoiGopY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaster_NgayGhiNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaster_NguoiNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaster_TieuDe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageDetail = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewDetail = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.colDetail_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetail_NguoiPhanHoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetail_NoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetail_ThoiGianGhiNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkNguoiGopY = new DevExpress.XtraEditors.CheckEdit();
            this.popupControlContainerFilter = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.NguoiNhan = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.nguoiGui = new ProtocolVN.Framework.Win.PLDMTreeGroup();
            this.labelControl7 = new System.Windows.Forms.PLLabel();
            this.ngayKT = new ProtocolVN.Framework.Win.Office.PLDateSelection();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.plTreeSelectItem1 = new ProtocolVN.Framework.Win.PLDMTreeGroupElement();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).BeginInit();
            this.xtraTabControlDetail.SuspendLayout();
            this.xtraTabPageDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNguoiGopY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).BeginInit();
            this.popupControlContainerFilter.SuspendLayout();
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
            this.barManager1.MaxItemId = 35;
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
            this.barButtonItem4.Caption = "Xem t&rước";
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
            this.barDockControlTop.Size = new System.Drawing.Size(973, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 497);
            this.barDockControlBottom.Size = new System.Drawing.Size(973, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(973, 24);
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
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 34;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 86);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlMaster);
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlDetail);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(973, 411);
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
            this.gridControlMaster.Size = new System.Drawing.Size(973, 175);
            this.gridControlMaster.TabIndex = 7;
            this.gridControlMaster.TabStop = false;
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
            this.colMaster_ID,
            this.colMaster_NoiDung,
            this.colMaster_NguoiGopY,
            this.colMaster_NgayGhiNhan,
            this.colMaster_NguoiNhan,
            this.colMaster_TieuDe});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupPanelText = "DANH SÁCH GÓP Ý";
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
            this.gridViewMaster.OptionsView.RowAutoHeight = true;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = true;
            // 
            // colMaster_ID
            // 
            this.colMaster_ID.Caption = "ID";
            this.colMaster_ID.Name = "colMaster_ID";
            this.colMaster_ID.Width = 23;
            // 
            // colMaster_NoiDung
            // 
            this.colMaster_NoiDung.Caption = "Nội dung";
            this.colMaster_NoiDung.Name = "colMaster_NoiDung";
            this.colMaster_NoiDung.OptionsColumn.ReadOnly = true;
            this.colMaster_NoiDung.Visible = true;
            this.colMaster_NoiDung.VisibleIndex = 1;
            this.colMaster_NoiDung.Width = 54;
            // 
            // colMaster_NguoiGopY
            // 
            this.colMaster_NguoiGopY.Caption = "Người gửi";
            this.colMaster_NguoiGopY.Name = "colMaster_NguoiGopY";
            this.colMaster_NguoiGopY.OptionsColumn.AllowEdit = false;
            this.colMaster_NguoiGopY.OptionsColumn.AllowFocus = false;
            this.colMaster_NguoiGopY.OptionsColumn.ReadOnly = true;
            this.colMaster_NguoiGopY.Visible = true;
            this.colMaster_NguoiGopY.VisibleIndex = 2;
            this.colMaster_NguoiGopY.Width = 58;
            // 
            // colMaster_NgayGhiNhan
            // 
            this.colMaster_NgayGhiNhan.Caption = "Thời gian góp ý";
            this.colMaster_NgayGhiNhan.Name = "colMaster_NgayGhiNhan";
            this.colMaster_NgayGhiNhan.OptionsColumn.AllowEdit = false;
            this.colMaster_NgayGhiNhan.OptionsColumn.AllowFocus = false;
            this.colMaster_NgayGhiNhan.OptionsColumn.ReadOnly = true;
            this.colMaster_NgayGhiNhan.Visible = true;
            this.colMaster_NgayGhiNhan.VisibleIndex = 4;
            this.colMaster_NgayGhiNhan.Width = 85;
            // 
            // colMaster_NguoiNhan
            // 
            this.colMaster_NguoiNhan.Caption = "Người nhận";
            this.colMaster_NguoiNhan.Name = "colMaster_NguoiNhan";
            this.colMaster_NguoiNhan.Visible = true;
            this.colMaster_NguoiNhan.VisibleIndex = 3;
            this.colMaster_NguoiNhan.Width = 67;
            this.colMaster_NguoiNhan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            // 
            // colMaster_TieuDe
            // 
            this.colMaster_TieuDe.Caption = "Vấn đề góp ý";
            this.colMaster_TieuDe.Name = "colMaster_TieuDe";
            this.colMaster_TieuDe.OptionsColumn.AllowEdit = false;
            this.colMaster_TieuDe.OptionsColumn.AllowFocus = false;
            this.colMaster_TieuDe.OptionsColumn.ReadOnly = true;
            this.colMaster_TieuDe.Visible = true;
            this.colMaster_TieuDe.VisibleIndex = 0;
            // 
            // xtraTabControlDetail
            // 
            this.xtraTabControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlDetail.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlDetail.Name = "xtraTabControlDetail";
            this.xtraTabControlDetail.SelectedTabPage = this.xtraTabPageDetail;
            this.xtraTabControlDetail.Size = new System.Drawing.Size(973, 230);
            this.xtraTabControlDetail.TabIndex = 0;
            this.xtraTabControlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageDetail});
            this.xtraTabControlDetail.TabStop = false;
            // 
            // xtraTabPageDetail
            // 
            this.xtraTabPageDetail.Controls.Add(this.gridControlDetail);
            this.xtraTabPageDetail.Name = "xtraTabPageDetail";
            this.xtraTabPageDetail.Size = new System.Drawing.Size(966, 201);
            this.xtraTabPageDetail.Text = "Danh sách phản hồi";
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlDetail.BackgroundImage")));
            this.gridControlDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDetail.Location = new System.Drawing.Point(0, 0);
            this.gridControlDetail.MainView = this.gridViewDetail;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.Size = new System.Drawing.Size(966, 201);
            this.gridControlDetail.TabIndex = 113;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetail});
            // 
            // gridViewDetail
            // 
            this.gridViewDetail.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDetail_ID,
            this.colDetail_NguoiPhanHoi,
            this.colDetail_NoiDung,
            this.colDetail_ThoiGianGhiNhan});
            this.gridViewDetail.GridControl = this.gridControlDetail;
            this.gridViewDetail.GroupPanelText = "Danh sách phản hồi";
            this.gridViewDetail.IndicatorWidth = 40;
            this.gridViewDetail.Name = "gridViewDetail";
            this.gridViewDetail.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewDetail.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewDetail.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewDetail.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewDetail.OptionsPrint.UsePrintStyles = true;
            this.gridViewDetail.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewDetail.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewDetail.OptionsView.ShowFooter = true;
            this.gridViewDetail.OptionsView.ShowGroupedColumns = true;
            this.gridViewDetail.OptionsView.ShowGroupPanel = false;
            // 
            // colDetail_ID
            // 
            this.colDetail_ID.Caption = "ID";
            this.colDetail_ID.Name = "colDetail_ID";
            this.colDetail_ID.Width = 23;
            // 
            // colDetail_NguoiPhanHoi
            // 
            this.colDetail_NguoiPhanHoi.Caption = "Người phản hồi";
            this.colDetail_NguoiPhanHoi.Name = "colDetail_NguoiPhanHoi";
            this.colDetail_NguoiPhanHoi.OptionsColumn.AllowEdit = false;
            this.colDetail_NguoiPhanHoi.OptionsColumn.AllowFocus = false;
            this.colDetail_NguoiPhanHoi.OptionsColumn.ReadOnly = true;
            this.colDetail_NguoiPhanHoi.Visible = true;
            this.colDetail_NguoiPhanHoi.VisibleIndex = 0;
            this.colDetail_NguoiPhanHoi.Width = 84;
            // 
            // colDetail_NoiDung
            // 
            this.colDetail_NoiDung.Caption = "Nội dung";
            this.colDetail_NoiDung.Name = "colDetail_NoiDung";
            this.colDetail_NoiDung.OptionsColumn.ReadOnly = true;
            this.colDetail_NoiDung.Visible = true;
            this.colDetail_NoiDung.VisibleIndex = 1;
            this.colDetail_NoiDung.Width = 54;
            // 
            // colDetail_ThoiGianGhiNhan
            // 
            this.colDetail_ThoiGianGhiNhan.Caption = "Thời gian ghi nhận";
            this.colDetail_ThoiGianGhiNhan.Name = "colDetail_ThoiGianGhiNhan";
            this.colDetail_ThoiGianGhiNhan.OptionsColumn.AllowEdit = false;
            this.colDetail_ThoiGianGhiNhan.OptionsColumn.AllowFocus = false;
            this.colDetail_ThoiGianGhiNhan.OptionsColumn.ReadOnly = true;
            this.colDetail_ThoiGianGhiNhan.Visible = true;
            this.colDetail_ThoiGianGhiNhan.VisibleIndex = 2;
            this.colDetail_ThoiGianGhiNhan.Width = 99;
            // 
            // chkNguoiGopY
            // 
            this.chkNguoiGopY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNguoiGopY.Location = new System.Drawing.Point(849, 6);
            this.chkNguoiGopY.MenuManager = this.barManager1;
            this.chkNguoiGopY.Name = "chkNguoiGopY";
            this.chkNguoiGopY.Properties.Caption = "Hiện người gửi";
            this.chkNguoiGopY.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.chkNguoiGopY.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkNguoiGopY.Size = new System.Drawing.Size(121, 19);
            this.chkNguoiGopY.TabIndex = 3;
            // 
            // popupControlContainerFilter
            // 
            this.popupControlContainerFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainerFilter.Controls.Add(this.NguoiNhan);
            this.popupControlContainerFilter.Controls.Add(this.plLabel1);
            this.popupControlContainerFilter.Controls.Add(this.nguoiGui);
            this.popupControlContainerFilter.Controls.Add(this.labelControl7);
            this.popupControlContainerFilter.Controls.Add(this.chkNguoiGopY);
            this.popupControlContainerFilter.Controls.Add(this.ngayKT);
            this.popupControlContainerFilter.Controls.Add(this.labelControl1);
            this.popupControlContainerFilter.Controls.Add(this.plTreeSelectItem1);
            this.popupControlContainerFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupControlContainerFilter.Location = new System.Drawing.Point(0, 24);
            this.popupControlContainerFilter.Manager = this.barManager1;
            this.popupControlContainerFilter.Name = "popupControlContainerFilter";
            this.popupControlContainerFilter.Size = new System.Drawing.Size(973, 62);
            this.popupControlContainerFilter.TabIndex = 0;
            this.popupControlContainerFilter.Visible = false;
            // 
            // NguoiNhan
            // 
            this.NguoiNhan.Location = new System.Drawing.Point(91, 32);
            this.NguoiNhan.Name = "NguoiNhan";
            this.NguoiNhan.Size = new System.Drawing.Size(162, 20);
            this.NguoiNhan.TabIndex = 1;
            // 
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(12, 35);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(55, 13);
            this.plLabel1.TabIndex = 201;
            this.plLabel1.Text = "Người nhận";
            this.plLabel1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // nguoiGui
            // 
            this.nguoiGui.Location = new System.Drawing.Point(91, 5);
            this.nguoiGui.Name = "nguoiGui";
            this.nguoiGui.Size = new System.Drawing.Size(162, 20);
            this.nguoiGui.TabIndex = 0;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 9);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(46, 13);
            this.labelControl7.TabIndex = 200;
            this.labelControl7.Text = "Người gửi";
            this.labelControl7.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl7.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // ngayKT
            // 
            this.ngayKT.Caption = "Năm 2010 và 2011";
            this.ngayKT.Default = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromMonthToMonth;
            this.ngayKT.FirstFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayKT.FirstTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayKT.FromDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayKT.Location = new System.Drawing.Point(363, 31);
            this.ngayKT.Name = "ngayKT";
            this.ngayKT.ReturnType = ProtocolVN.Framework.Win.Trial.TimeType.Date;
            this.ngayKT.SecondFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayKT.SecondTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayKT.SelectedType = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromYearToYear;
            this.ngayKT.Size = new System.Drawing.Size(226, 21);
            this.ngayKT.TabIndex = 2;
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
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(284, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 13);
            this.labelControl1.TabIndex = 198;
            this.labelControl1.Text = "Thời gian góp ý";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // plTreeSelectItem1
            // 
            this.plTreeSelectItem1.Location = new System.Drawing.Point(605, -20);
            this.plTreeSelectItem1.Name = "plTreeSelectItem1";
            this.plTreeSelectItem1.Size = new System.Drawing.Size(167, 20);
            this.plTreeSelectItem1.TabIndex = 193;
            this.plTreeSelectItem1.ZZZWidthFactor = 2F;
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
            // frmHomThuGopYQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 497);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.popupControlContainerFilter);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmHomThuGopYQL";
            this.Text = "Hòm thư góp ý";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).EndInit();
            this.xtraTabControlDetail.ResumeLayout(false);
            this.xtraTabPageDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNguoiGopY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).EndInit();
            this.popupControlContainerFilter.ResumeLayout(false);
            this.popupControlContainerFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PLDMTreeGroupElement plTreeSelectItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraGrid.Columns.GridColumn colMaster_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colMaster_NoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn colMaster_NguoiGopY;
        private DevExpress.XtraGrid.Columns.GridColumn colMaster_NgayGhiNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colDetail_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDetail_NguoiPhanHoi;
        private DevExpress.XtraGrid.Columns.GridColumn colDetail_NoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn colDetail_ThoiGianGhiNhan;
        private System.Windows.Forms.PLLabel labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaster_TieuDe;
        //Phân quyền xem người góp ý
        public CheckEdit chkNguoiGopY;
        private ProtocolVN.Framework.Win.Office.PLDateSelection ngayKT;
        private System.Windows.Forms.PLLabel labelControl7;
        private System.Windows.Forms.PLLabel plLabel1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaster_NguoiNhan;
        public PLDMTreeGroup nguoiGui;
        public ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiNhan;
    }
}