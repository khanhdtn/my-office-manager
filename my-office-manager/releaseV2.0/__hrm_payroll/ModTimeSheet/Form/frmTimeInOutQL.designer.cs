
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
namespace ProtocolVN.Plugin.TimeSheet
{
    partial class frmTimeInOutQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimeInOutQL));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.MainBar = new DevExpress.XtraBars.Bar();
            this.barButtonItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDuyet = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemK_Duyet = new DevExpress.XtraBars.BarButtonItem();
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
            this.barButtonItemCommit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemNoCommit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_NVID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_TenNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_NgayLamViec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_GioBatDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_GioKetThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTG_LV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_Cham_Cong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_N_Bs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_N_BC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_NP_Nam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_NP_KL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_Noi_Dung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotIP_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotLoaiDT_VS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageDetail = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewDetail = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.popupControlContainerFilter = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.chkVe_som = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.chkDi_tre = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.chkChuaChamCong = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.chkDaChamCong = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.PLNhanVien = new ProtocolVN.Framework.Win.PLDMGrid();
            this.DenNgay = new DevExpress.XtraEditors.DateEdit();
            this.TuNgay = new DevExpress.XtraEditors.DateEdit();
            this.label8 = new System.Windows.Forms.PLLabel();
            this.label4 = new System.Windows.Forms.PLLabel();
            this.label1 = new System.Windows.Forms.PLLabel();
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).BeginInit();
            this.popupControlContainerFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkVe_som.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDi_tre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChuaChamCong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDaChamCong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties)).BeginInit();
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemPrint, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemDuyet, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemK_Duyet),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
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
            // barButtonItemDuyet
            // 
            this.barButtonItemDuyet.Caption = "&Duyệt";
            this.barButtonItemDuyet.Id = 35;
            this.barButtonItemDuyet.Name = "barButtonItemDuyet";
            // 
            // barButtonItemK_Duyet
            // 
            this.barButtonItemK_Duyet.Caption = "&Không duyệt";
            this.barButtonItemK_Duyet.Id = 36;
            this.barButtonItemK_Duyet.Name = "barButtonItemK_Duyet";
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
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 90);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlMaster);
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlDetail);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(804, 407);
            this.splitContainerControl1.SplitterPosition = 196;
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
            this.gridControlMaster.Size = new System.Drawing.Size(804, 196);
            this.gridControlMaster.TabIndex = 0;
            this.gridControlMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMaster});
            // 
            // gridViewMaster
            // 
            this.gridViewMaster.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Inch);
            this.gridViewMaster.Appearance.GroupPanel.Options.UseFont = true;
            this.gridViewMaster.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewMaster.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.Cot_NVID,
            this.Cot_TenNV,
            this.Cot_NgayLamViec,
            this.Cot_GioBatDau,
            this.Cot_GioKetThuc,
            this.CotTG_LV,
            this.Cot_Cham_Cong,
            this.Cot_N_Bs,
            this.Cot_N_BC,
            this.Cot_NP_Nam,
            this.Cot_NP_KL,
            this.Cot_Noi_Dung,
            this.CotLoai,
            this.CotIP_Address,
            this.CotLoaiDT_VS});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupCount = 2;
            this.gridViewMaster.GroupPanelText = "Thời gian làm việc của nhân viên thỏa điều kiện tìm kiếm";
            this.gridViewMaster.IndicatorWidth = 40;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.NewItemRowText = "Nhập dữ liệu mới tại đây";
            this.gridViewMaster.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridViewMaster.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewMaster.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewMaster.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewMaster.OptionsSelection.MultiSelect = true;
            this.gridViewMaster.OptionsView.ColumnAutoWidth = false;
            this.gridViewMaster.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMaster.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewMaster.OptionsView.ShowFooter = true;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = true;
            this.gridViewMaster.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Cot_NgayLamViec, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Cot_TenNV, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 23;
            // 
            // Cot_NVID
            // 
            this.Cot_NVID.Caption = "NV_ID";
            this.Cot_NVID.Name = "Cot_NVID";
            this.Cot_NVID.Width = 42;
            // 
            // Cot_TenNV
            // 
            this.Cot_TenNV.Caption = "Nhân viên";
            this.Cot_TenNV.Name = "Cot_TenNV";
            this.Cot_TenNV.Visible = true;
            this.Cot_TenNV.VisibleIndex = 0;
            this.Cot_TenNV.Width = 73;
            // 
            // Cot_NgayLamViec
            // 
            this.Cot_NgayLamViec.Caption = "Ngày làm việc";
            this.Cot_NgayLamViec.Name = "Cot_NgayLamViec";
            this.Cot_NgayLamViec.Visible = true;
            this.Cot_NgayLamViec.VisibleIndex = 1;
            this.Cot_NgayLamViec.Width = 91;
            // 
            // Cot_GioBatDau
            // 
            this.Cot_GioBatDau.Caption = "Giờ bắt đầu";
            this.Cot_GioBatDau.Name = "Cot_GioBatDau";
            this.Cot_GioBatDau.Visible = true;
            this.Cot_GioBatDau.VisibleIndex = 2;
            this.Cot_GioBatDau.Width = 67;
            // 
            // Cot_GioKetThuc
            // 
            this.Cot_GioKetThuc.Caption = "Giờ kết thúc";
            this.Cot_GioKetThuc.Name = "Cot_GioKetThuc";
            this.Cot_GioKetThuc.Visible = true;
            this.Cot_GioKetThuc.VisibleIndex = 3;
            this.Cot_GioKetThuc.Width = 69;
            // 
            // CotTG_LV
            // 
            this.CotTG_LV.Caption = "Thời gian làm việc (giờ : phút)";
            this.CotTG_LV.Name = "CotTG_LV";
            this.CotTG_LV.SummaryItem.DisplayFormat = "Thời gian: {0:#.##0}";
            this.CotTG_LV.SummaryItem.FieldName = "TG";
            this.CotTG_LV.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.CotTG_LV.Visible = true;
            this.CotTG_LV.VisibleIndex = 4;
            this.CotTG_LV.Width = 153;
            // 
            // Cot_Cham_Cong
            // 
            this.Cot_Cham_Cong.Caption = "Đã chấm công";
            this.Cot_Cham_Cong.Name = "Cot_Cham_Cong";
            this.Cot_Cham_Cong.Visible = true;
            this.Cot_Cham_Cong.VisibleIndex = 9;
            this.Cot_Cham_Cong.Width = 80;
            // 
            // Cot_N_Bs
            // 
            this.Cot_N_Bs.Caption = "Sáng (giờ : phút)";
            this.Cot_N_Bs.Name = "Cot_N_Bs";
            this.Cot_N_Bs.Visible = true;
            this.Cot_N_Bs.VisibleIndex = 5;
            this.Cot_N_Bs.Width = 59;
            // 
            // Cot_N_BC
            // 
            this.Cot_N_BC.Caption = "Chiều (giờ : phút)";
            this.Cot_N_BC.Name = "Cot_N_BC";
            this.Cot_N_BC.Visible = true;
            this.Cot_N_BC.VisibleIndex = 6;
            this.Cot_N_BC.Width = 61;
            // 
            // Cot_NP_Nam
            // 
            this.Cot_NP_Nam.Caption = "Nghỉ phép năm";
            this.Cot_NP_Nam.Name = "Cot_NP_Nam";
            this.Cot_NP_Nam.Visible = true;
            this.Cot_NP_Nam.VisibleIndex = 10;
            this.Cot_NP_Nam.Width = 83;
            // 
            // Cot_NP_KL
            // 
            this.Cot_NP_KL.Caption = "Nghỉ không lương";
            this.Cot_NP_KL.Name = "Cot_NP_KL";
            this.Cot_NP_KL.Visible = true;
            this.Cot_NP_KL.VisibleIndex = 11;
            this.Cot_NP_KL.Width = 95;
            // 
            // Cot_Noi_Dung
            // 
            this.Cot_Noi_Dung.Caption = "Nội dung";
            this.Cot_Noi_Dung.Name = "Cot_Noi_Dung";
            this.Cot_Noi_Dung.Visible = true;
            this.Cot_Noi_Dung.VisibleIndex = 8;
            this.Cot_Noi_Dung.Width = 54;
            // 
            // CotLoai
            // 
            this.CotLoai.Caption = "Loại";
            this.CotLoai.Name = "CotLoai";
            this.CotLoai.Width = 31;
            // 
            // CotIP_Address
            // 
            this.CotIP_Address.Caption = "IP_Address";
            this.CotIP_Address.Name = "CotIP_Address";
            this.CotIP_Address.Visible = true;
            this.CotIP_Address.VisibleIndex = 12;
            this.CotIP_Address.Width = 67;
            // 
            // CotLoaiDT_VS
            // 
            this.CotLoaiDT_VS.Caption = "Đi trễ / Về sớm";
            this.CotLoaiDT_VS.Name = "CotLoaiDT_VS";
            this.CotLoaiDT_VS.Visible = true;
            this.CotLoaiDT_VS.VisibleIndex = 7;
            // 
            // xtraTabControlDetail
            // 
            this.xtraTabControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlDetail.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlDetail.Name = "xtraTabControlDetail";
            this.xtraTabControlDetail.SelectedTabPage = this.xtraTabPageDetail;
            this.xtraTabControlDetail.Size = new System.Drawing.Size(804, 205);
            this.xtraTabControlDetail.TabIndex = 0;
            this.xtraTabControlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageDetail});
            // 
            // xtraTabPageDetail
            // 
            this.xtraTabPageDetail.Controls.Add(this.gridControlDetail);
            this.xtraTabPageDetail.Name = "xtraTabPageDetail";
            this.xtraTabPageDetail.Size = new System.Drawing.Size(797, 176);
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
            this.gridControlDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemImageComboBox1});
            this.gridControlDetail.Size = new System.Drawing.Size(797, 176);
            this.gridControlDetail.TabIndex = 0;
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
            this.gridViewDetail.NewItemRowText = "Nhập dữ liệu mới tại đây";
            this.gridViewDetail.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridViewDetail.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewDetail.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewDetail.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewDetail.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewDetail.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewDetail.OptionsView.ShowGroupedColumns = true;
            this.gridViewDetail.OptionsView.ShowGroupPanel = false;
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
            // popupControlContainerFilter
            // 
            this.popupControlContainerFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainerFilter.Controls.Add(this.chkVe_som);
            this.popupControlContainerFilter.Controls.Add(this.chkDi_tre);
            this.popupControlContainerFilter.Controls.Add(this.chkChuaChamCong);
            this.popupControlContainerFilter.Controls.Add(this.chkDaChamCong);
            this.popupControlContainerFilter.Controls.Add(this.PLNhanVien);
            this.popupControlContainerFilter.Controls.Add(this.DenNgay);
            this.popupControlContainerFilter.Controls.Add(this.TuNgay);
            this.popupControlContainerFilter.Controls.Add(this.label8);
            this.popupControlContainerFilter.Controls.Add(this.label4);
            this.popupControlContainerFilter.Controls.Add(this.label1);
            this.popupControlContainerFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupControlContainerFilter.Location = new System.Drawing.Point(0, 24);
            this.popupControlContainerFilter.Manager = this.barManager1;
            this.popupControlContainerFilter.Name = "popupControlContainerFilter";
            this.popupControlContainerFilter.Size = new System.Drawing.Size(804, 66);
            this.popupControlContainerFilter.TabIndex = 0;
            this.popupControlContainerFilter.Visible = false;
            // 
            // chkVe_som
            // 
            this.chkVe_som.Location = new System.Drawing.Point(427, 36);
            this.chkVe_som.Name = "chkVe_som";
            this.chkVe_som.Properties.Caption = "Về sớm";
            this.chkVe_som.Size = new System.Drawing.Size(98, 19);
            this.chkVe_som.TabIndex = 7;
            this.chkVe_som.ToolTip = "Dữ liệu bắt buộc nhập";
            this.chkVe_som.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
            // 
            // chkDi_tre
            // 
            this.chkDi_tre.Location = new System.Drawing.Point(315, 36);
            this.chkDi_tre.Name = "chkDi_tre";
            this.chkDi_tre.Properties.Caption = "Đi trễ";
            this.chkDi_tre.Size = new System.Drawing.Size(98, 19);
            this.chkDi_tre.TabIndex = 6;
            this.chkDi_tre.ToolTip = "Dữ liệu bắt buộc nhập";
            this.chkDi_tre.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
            // 
            // chkChuaChamCong
            // 
            this.chkChuaChamCong.Location = new System.Drawing.Point(427, 10);
            this.chkChuaChamCong.Name = "chkChuaChamCong";
            this.chkChuaChamCong.Properties.Caption = "Chưa chấm công";
            this.chkChuaChamCong.Size = new System.Drawing.Size(130, 19);
            this.chkChuaChamCong.TabIndex = 5;
            this.chkChuaChamCong.ToolTip = "Dữ liệu bắt buộc nhập";
            this.chkChuaChamCong.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
            // 
            // chkDaChamCong
            // 
            this.chkDaChamCong.Location = new System.Drawing.Point(315, 10);
            this.chkDaChamCong.Name = "chkDaChamCong";
            this.chkDaChamCong.Properties.Caption = "Đã chấm công";
            this.chkDaChamCong.Size = new System.Drawing.Size(109, 19);
            this.chkDaChamCong.TabIndex = 4;
            this.chkDaChamCong.ToolTip = "Dữ liệu bắt buộc nhập";
            this.chkDaChamCong.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
            // 
            // PLNhanVien
            // 
            this.PLNhanVien.Location = new System.Drawing.Point(67, 8);
            this.PLNhanVien.Name = "PLNhanVien";
            this.PLNhanVien.Size = new System.Drawing.Size(219, 21);
            this.PLNhanVien.TabIndex = 1;
            this.PLNhanVien.ZZZWidthFactor = 2F;
            // 
            // DenNgay
            // 
            this.DenNgay.EditValue = null;
            this.DenNgay.Location = new System.Drawing.Point(199, 35);
            this.DenNgay.Name = "DenNgay";
            this.DenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DenNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DenNgay.Size = new System.Drawing.Size(87, 20);
            this.DenNgay.TabIndex = 3;
            // 
            // TuNgay
            // 
            this.TuNgay.EditValue = null;
            this.TuNgay.Location = new System.Drawing.Point(67, 35);
            this.TuNgay.Name = "TuNgay";
            this.TuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TuNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TuNgay.Size = new System.Drawing.Size(88, 20);
            this.TuNgay.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(166, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "đến";
            this.label8.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label8.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Từ ngày";
            this.label4.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label4.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nhân viên";
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
            // frmTimeInOutQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 497);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.popupControlContainerFilter);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmTimeInOutQL";
            this.Text = "Thời gian làm việc";
            this.Load += new System.EventHandler(this.frmTimeInOutQL_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).EndInit();
            this.popupControlContainerFilter.ResumeLayout(false);
            this.popupControlContainerFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkVe_som.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDi_tre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChuaChamCong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDaChamCong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DateEdit DenNgay;
        private DateEdit TuNgay;
        private  System.Windows.Forms.PLLabel  label8;
        private  System.Windows.Forms.PLLabel  label4;
        private  System.Windows.Forms.PLLabel  label1;
        private PLDMGrid PLNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_NVID;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_TenNV;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_NgayLamViec;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_GioBatDau;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_GioKetThuc;
        private DevExpress.XtraGrid.Columns.GridColumn CotTG_LV;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_Cham_Cong;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_N_Bs;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_N_BC;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_Noi_Dung;
        public DevExpress.XtraBars.BarButtonItem barButtonItemDuyet;
        public DevExpress.XtraBars.BarButtonItem barButtonItemK_Duyet;
        private DevExpress.XtraGrid.Columns.GridColumn CotLoai;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_NP_Nam;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_NP_KL;
        private DevExpress.XtraGrid.Columns.GridColumn CotIP_Address;
        private DevExpress.XtraGrid.Columns.GridColumn CotLoaiDT_VS;
        private PLCheckEdit chkDaChamCong;
        private PLCheckEdit chkChuaChamCong;
        private PLCheckEdit chkDi_tre;
        private PLCheckEdit chkVe_som;



    }
}