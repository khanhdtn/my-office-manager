using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmYeuCauHoTroQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYeuCauHoTroQL));
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
            this.CotNguoigui = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotMuc_ut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotNguoinhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotYeucau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotLoaiYC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTinhTrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTG_gui = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotSoLanPH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.popupControlContainerFilter = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.mruEditYeuCau = new DevExpress.XtraEditors.MRUEdit();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.cmbNguoiNhan = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.cmbNguoiYC = new ProtocolVN.Framework.Win.PLDMTreeGroup();
            this.ngayLamViec = new ProtocolVN.Framework.Win.Office.PLDateSelection();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.PLTinhtrang = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.PLMucuutien = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.labelControl7 = new System.Windows.Forms.PLLabel();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.xtraTabControlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.XtraTabPageDetail = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlThongTinLienHe = new DevExpress.XtraGrid.GridControl();
            this.gridViewThongTinLienHe = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.CotNguoiphanhoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTG_PH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotNoidung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).BeginInit();
            this.popupControlContainerFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mruEditYeuCau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).BeginInit();
            this.xtraTabControlDetail.SuspendLayout();
            this.XtraTabPageDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThongTinLienHe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThongTinLienHe)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(922, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 497);
            this.barDockControlBottom.Size = new System.Drawing.Size(922, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(922, 24);
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
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 24);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlMaster);
            this.splitContainerControl1.Panel1.Controls.Add(this.popupControlContainerFilter);
            this.splitContainerControl1.Panel1.MinSize = 216;
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlDetail);
            this.splitContainerControl1.Panel2.MinSize = 126;
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(922, 473);
            this.splitContainerControl1.SplitterPosition = 308;
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
            this.gridControlMaster.Location = new System.Drawing.Point(0, 59);
            this.gridControlMaster.MainView = this.gridViewMaster;
            this.gridControlMaster.Name = "gridControlMaster";
            this.gridControlMaster.Size = new System.Drawing.Size(922, 249);
            this.gridControlMaster.TabIndex = 8;
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
            this.CotNguoigui,
            this.CotMuc_ut,
            this.CotNguoinhan,
            this.CotYeucau,
            this.CotLoaiYC,
            this.CotTinhTrang,
            this.CotTG_gui,
            this.CotSoLanPH});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupCount = 1;
            this.gridViewMaster.GroupPanelText = "DANH SÁCH ";
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
            this.gridViewMaster.OptionsView.ShowViewCaption = true;
            this.gridViewMaster.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.CotLoaiYC, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewMaster.ViewCaption = "DANH SÁCH YÊU CẦU HỖ TRỢ";
            // 
            // CotNguoigui
            // 
            this.CotNguoigui.Caption = "Người yêu cầu";
            this.CotNguoigui.Name = "CotNguoigui";
            this.CotNguoigui.Visible = true;
            this.CotNguoigui.VisibleIndex = 1;
            this.CotNguoigui.Width = 81;
            // 
            // CotMuc_ut
            // 
            this.CotMuc_ut.Caption = "Mức ưu tiên";
            this.CotMuc_ut.Name = "CotMuc_ut";
            this.CotMuc_ut.Visible = true;
            this.CotMuc_ut.VisibleIndex = 6;
            this.CotMuc_ut.Width = 69;
            // 
            // CotNguoinhan
            // 
            this.CotNguoinhan.Caption = "Người hỗ trợ";
            this.CotNguoinhan.Name = "CotNguoinhan";
            this.CotNguoinhan.Visible = true;
            this.CotNguoinhan.VisibleIndex = 4;
            this.CotNguoinhan.Width = 72;
            // 
            // CotYeucau
            // 
            this.CotYeucau.Caption = "Yêu cầu";
            this.CotYeucau.Name = "CotYeucau";
            this.CotYeucau.Visible = true;
            this.CotYeucau.VisibleIndex = 0;
            this.CotYeucau.Width = 50;
            // 
            // CotLoaiYC
            // 
            this.CotLoaiYC.Caption = "Loại yêu cầu";
            this.CotLoaiYC.Name = "CotLoaiYC";
            this.CotLoaiYC.Visible = true;
            this.CotLoaiYC.VisibleIndex = 2;
            this.CotLoaiYC.Width = 85;
            // 
            // CotTinhTrang
            // 
            this.CotTinhTrang.Caption = "Tình trạng";
            this.CotTinhTrang.Name = "CotTinhTrang";
            this.CotTinhTrang.Visible = true;
            this.CotTinhTrang.VisibleIndex = 7;
            this.CotTinhTrang.Width = 61;
            // 
            // CotTG_gui
            // 
            this.CotTG_gui.Caption = "Thời gian cập nhật";
            this.CotTG_gui.Name = "CotTG_gui";
            this.CotTG_gui.Visible = true;
            this.CotTG_gui.VisibleIndex = 3;
            this.CotTG_gui.Width = 100;
            // 
            // CotSoLanPH
            // 
            this.CotSoLanPH.Caption = "Số lần phản hồi";
            this.CotSoLanPH.Name = "CotSoLanPH";
            this.CotSoLanPH.Visible = true;
            this.CotSoLanPH.VisibleIndex = 5;
            this.CotSoLanPH.Width = 85;
            // 
            // popupControlContainerFilter
            // 
            this.popupControlContainerFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainerFilter.Controls.Add(this.mruEditYeuCau);
            this.popupControlContainerFilter.Controls.Add(this.plLabel2);
            this.popupControlContainerFilter.Controls.Add(this.cmbNguoiNhan);
            this.popupControlContainerFilter.Controls.Add(this.cmbNguoiYC);
            this.popupControlContainerFilter.Controls.Add(this.ngayLamViec);
            this.popupControlContainerFilter.Controls.Add(this.plLabel1);
            this.popupControlContainerFilter.Controls.Add(this.PLTinhtrang);
            this.popupControlContainerFilter.Controls.Add(this.PLMucuutien);
            this.popupControlContainerFilter.Controls.Add(this.labelControl7);
            this.popupControlContainerFilter.Controls.Add(this.labelControl5);
            this.popupControlContainerFilter.Controls.Add(this.labelControl2);
            this.popupControlContainerFilter.Controls.Add(this.labelControl1);
            this.popupControlContainerFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupControlContainerFilter.Location = new System.Drawing.Point(0, 0);
            this.popupControlContainerFilter.Manager = this.barManager1;
            this.popupControlContainerFilter.Name = "popupControlContainerFilter";
            this.popupControlContainerFilter.Size = new System.Drawing.Size(922, 59);
            this.popupControlContainerFilter.TabIndex = 6;
            this.popupControlContainerFilter.Visible = false;
            // 
            // mruEditYeuCau
            // 
            this.mruEditYeuCau.Location = new System.Drawing.Point(86, 6);
            this.mruEditYeuCau.Name = "mruEditYeuCau";
            this.mruEditYeuCau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.mruEditYeuCau.Size = new System.Drawing.Size(362, 20);
            this.mruEditYeuCau.TabIndex = 0;
            // 
            // plLabel2
            // 
            this.plLabel2.Location = new System.Drawing.Point(11, 9);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(38, 13);
            this.plLabel2.TabIndex = 54;
            this.plLabel2.Text = "Yêu cầu";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // cmbNguoiNhan
            // 
            this.cmbNguoiNhan.Location = new System.Drawing.Point(308, 32);
            this.cmbNguoiNhan.Name = "cmbNguoiNhan";
            this.cmbNguoiNhan.Size = new System.Drawing.Size(140, 20);
            this.cmbNguoiNhan.TabIndex = 2;
            // 
            // cmbNguoiYC
            // 
            this.cmbNguoiYC.Location = new System.Drawing.Point(86, 32);
            this.cmbNguoiYC.Name = "cmbNguoiYC";
            this.cmbNguoiYC.Size = new System.Drawing.Size(140, 20);
            this.cmbNguoiYC.TabIndex = 1;
            // 
            // ngayLamViec
            // 
            this.ngayLamViec.Caption = "Năm 2010 và 2011";
            this.ngayLamViec.Default = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromYearToYear;
            this.ngayLamViec.FirstFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayLamViec.FirstTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayLamViec.FromDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayLamViec.Location = new System.Drawing.Point(546, 5);
            this.ngayLamViec.Name = "ngayLamViec";
            this.ngayLamViec.ReturnType = ProtocolVN.Framework.Win.Trial.TimeType.Date;
            this.ngayLamViec.SecondFrom = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.ngayLamViec.SecondTo = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.ngayLamViec.SelectedType = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromYearToYear;
            this.ngayLamViec.Size = new System.Drawing.Size(229, 21);
            this.ngayLamViec.TabIndex = 3;
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
            this.plLabel1.Location = new System.Drawing.Point(470, 9);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(61, 13);
            this.plLabel1.TabIndex = 52;
            this.plLabel1.Text = "Thời gian gửi";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // PLTinhtrang
            // 
            this.PLTinhtrang.DataSource = null;
            this.PLTinhtrang.DisplayField = null;
            this.PLTinhtrang.Location = new System.Drawing.Point(724, 31);
            this.PLTinhtrang.Name = "PLTinhtrang";
            this.PLTinhtrang.Size = new System.Drawing.Size(108, 20);
            this.PLTinhtrang.TabIndex = 5;
            this.PLTinhtrang.ValueField = "";
            // 
            // PLMucuutien
            // 
            this.PLMucuutien.DataSource = null;
            this.PLMucuutien.DisplayField = null;
            this.PLMucuutien.Location = new System.Drawing.Point(546, 31);
            this.PLMucuutien.Name = "PLMucuutien";
            this.PLMucuutien.Size = new System.Drawing.Size(108, 20);
            this.PLMucuutien.TabIndex = 4;
            this.PLMucuutien.ValueField = "";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(667, 35);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 51;
            this.labelControl7.Text = "Tình trạng";
            this.labelControl7.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(470, 35);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(51, 13);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Độ ưu tiên";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 36);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Người yêu cầu";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(242, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Người hỗ trợ";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // xtraTabControlDetail
            // 
            this.xtraTabControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlDetail.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlDetail.Name = "xtraTabControlDetail";
            this.xtraTabControlDetail.SelectedTabPage = this.XtraTabPageDetail;
            this.xtraTabControlDetail.Size = new System.Drawing.Size(922, 159);
            this.xtraTabControlDetail.TabIndex = 0;
            this.xtraTabControlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.XtraTabPageDetail});
            // 
            // XtraTabPageDetail
            // 
            this.XtraTabPageDetail.Controls.Add(this.gridControlThongTinLienHe);
            this.XtraTabPageDetail.Name = "XtraTabPageDetail";
            this.XtraTabPageDetail.Size = new System.Drawing.Size(915, 130);
            this.XtraTabPageDetail.Text = "Thông tin phản hồi";
            // 
            // gridControlThongTinLienHe
            // 
            this.gridControlThongTinLienHe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlThongTinLienHe.BackgroundImage")));
            this.gridControlThongTinLienHe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlThongTinLienHe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlThongTinLienHe.Location = new System.Drawing.Point(0, 0);
            this.gridControlThongTinLienHe.MainView = this.gridViewThongTinLienHe;
            this.gridControlThongTinLienHe.Name = "gridControlThongTinLienHe";
            this.gridControlThongTinLienHe.Size = new System.Drawing.Size(915, 130);
            this.gridControlThongTinLienHe.TabIndex = 10;
            this.gridControlThongTinLienHe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewThongTinLienHe,
            this.gridView1});
            // 
            // gridViewThongTinLienHe
            // 
            this.gridViewThongTinLienHe.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewThongTinLienHe.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewThongTinLienHe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CotNguoiphanhoi,
            this.CotTG_PH,
            this.CotNoidung});
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
            // CotNguoiphanhoi
            // 
            this.CotNguoiphanhoi.Caption = "Người phản hồi";
            this.CotNguoiphanhoi.Name = "CotNguoiphanhoi";
            this.CotNguoiphanhoi.Visible = true;
            this.CotNguoiphanhoi.VisibleIndex = 0;
            this.CotNguoiphanhoi.Width = 84;
            // 
            // CotTG_PH
            // 
            this.CotTG_PH.Caption = "Thời gian phản hồi";
            this.CotTG_PH.Name = "CotTG_PH";
            this.CotTG_PH.Visible = true;
            this.CotTG_PH.VisibleIndex = 1;
            this.CotTG_PH.Width = 99;
            // 
            // CotNoidung
            // 
            this.CotNoidung.Caption = "Nội dung";
            this.CotNoidung.Name = "CotNoidung";
            this.CotNoidung.Visible = true;
            this.CotNoidung.VisibleIndex = 2;
            this.CotNoidung.Width = 54;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlThongTinLienHe;
            this.gridView1.Name = "gridView1";
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
            // frmYeuCauHoTroQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 497);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmYeuCauHoTroQL";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yêu cầu hỗ trợ";
            this.Load += new System.EventHandler(this.frmQLCongviecQL1N_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).EndInit();
            this.popupControlContainerFilter.ResumeLayout(false);
            this.popupControlContainerFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mruEditYeuCau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).EndInit();
            this.xtraTabControlDetail.ResumeLayout(false);
            this.XtraTabPageDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThongTinLienHe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThongTinLienHe)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem barbuttonCapNhatTienDo;        
        private DevExpress.XtraGrid.Columns.GridColumn CotNguoigui;
        private DevExpress.XtraGrid.Columns.GridColumn CotMuc_ut;
        private DevExpress.XtraGrid.Columns.GridColumn CotNguoinhan;
        private DevExpress.XtraGrid.Columns.GridColumn CotYeucau;
        private DevExpress.XtraGrid.Columns.GridColumn CotLoaiYC;
        private DevExpress.XtraGrid.Columns.GridColumn CotTinhTrang;
        private DevExpress.XtraGrid.Columns.GridColumn CotTG_gui;        
        private DevExpress.XtraTab.XtraTabPage XtraTabPageDetail;
        public DevExpress.XtraGrid.GridControl gridControlThongTinLienHe;
        public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewThongTinLienHe;
        private DevExpress.XtraGrid.Columns.GridColumn CotNguoiphanhoi;
        private DevExpress.XtraGrid.Columns.GridColumn CotTG_PH;
        private DevExpress.XtraGrid.Columns.GridColumn CotNoidung;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private PLImgCombobox PLTinhtrang;
        private PLImgCombobox PLMucuutien;
        private System.Windows.Forms.PLLabel labelControl7;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel plLabel1;
        private ProtocolVN.Framework.Win.Office.PLDateSelection ngayLamViec;
        public PLDMTreeGroup cmbNguoiYC;
        private System.Windows.Forms.PLLabel labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn CotSoLanPH;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice cmbNguoiNhan;
        private MRUEdit mruEditYeuCau;
        private System.Windows.Forms.PLLabel plLabel2;
    }
}