using ProtocolVN.Framework.Win;
namespace pl.office.form
{
    partial class frmHoSoQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoSoQL));
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
            this.Web_QuaTrinhDaoTao = new System.Windows.Forms.WebBrowser();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.Cot_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_ViTriTuyenDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_Ten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_NgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_GioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_TinhTrangHS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_LuongMongDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_TinhTrangHonNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_Mail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_DienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_DiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_LoaiHoSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotNgayCapNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotMaHoSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tabkpage = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.Web_QuaTrinhCongTac = new System.Windows.Forms.WebBrowser();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.Web_TrinhDoChuyenMon = new System.Windows.Forms.WebBrowser();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.Web_TrinhDoNgoaiNgu = new System.Windows.Forms.WebBrowser();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.Web_ThongTinKhac = new System.Windows.Forms.WebBrowser();
            this.xtraTabControlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageDetail = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewDetail = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.Cot_TrinhDoChuyenMon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_QuaTrinhCongTac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_QuaTrinhDaoTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_TrinhDoNgoaiNgu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_ThongTinKhac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.popupControlContainerFilter = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new System.Windows.Forms.PLLabel();
            this.PLLoaiHoSo = new ProtocolVN.Framework.Win.PLCombobox();
            this.Filter_TinhTrangHoSo = new ProtocolVN.Framework.Win.PLCombobox();
            this.Filter_DotPhongVan = new ProtocolVN.Framework.Win.PLCombobox();
            this.Filter_VTUngTuyen = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.Filter_NamSinhDen = new DevExpress.XtraEditors.SpinEdit();
            this.Filter_NamSinhTu = new DevExpress.XtraEditors.SpinEdit();
            this.Filter_Email = new DevExpress.XtraEditors.TextEdit();
            this.Filter_Ten = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.labelControl6 = new System.Windows.Forms.PLLabel();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.labelControl9 = new System.Windows.Forms.PLLabel();
            this.labelControl8 = new System.Windows.Forms.PLLabel();
            this.labelControl7 = new System.Windows.Forms.PLLabel();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.Filter_GTNu = new ProtocolVN.Framework.Win.PLCheckEdit();
            this.Filter_GTNam = new ProtocolVN.Framework.Win.PLCheckEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.tabkpage)).BeginInit();
            this.tabkpage.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            this.xtraTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).BeginInit();
            this.xtraTabControlDetail.SuspendLayout();
            this.xtraTabPageDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).BeginInit();
            this.popupControlContainerFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_VTUngTuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_NamSinhDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_NamSinhTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Email.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Ten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_GTNu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_GTNam.Properties)).BeginInit();
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
            this.barButtonItem4});
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
            this.barButtonItemXem.Caption = "&Xem";
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
            // Web_QuaTrinhDaoTao
            // 
            this.Web_QuaTrinhDaoTao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Web_QuaTrinhDaoTao.Location = new System.Drawing.Point(0, 0);
            this.Web_QuaTrinhDaoTao.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.Web_QuaTrinhDaoTao.MinimumSize = new System.Drawing.Size(20, 20);
            this.Web_QuaTrinhDaoTao.Name = "Web_QuaTrinhDaoTao";
            this.barManager1.SetPopupContextMenu(this.Web_QuaTrinhDaoTao, this.popupMenuFilter);
            this.Web_QuaTrinhDaoTao.Size = new System.Drawing.Size(797, 205);
            this.Web_QuaTrinhDaoTao.TabIndex = 0;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 115);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlMaster);
            this.splitContainerControl1.Panel1.MinSize = 171;
            this.splitContainerControl1.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl1.Panel2.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.splitContainerControl1.Panel2.Controls.Add(this.tabkpage);
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlDetail);
            this.splitContainerControl1.Panel2.MinSize = 171;
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "splitContainerControl1_Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(804, 416);
            this.splitContainerControl1.SplitterPosition = 176;
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
            this.gridControlMaster.Size = new System.Drawing.Size(804, 176);
            this.gridControlMaster.TabIndex = 8;
            this.gridControlMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMaster});
            // 
            // gridViewMaster
            // 
            this.gridViewMaster.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewMaster.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewMaster.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Cot_ID,
            this.Cot_ViTriTuyenDung,
            this.Cot_Ten,
            this.Cot_NgaySinh,
            this.Cot_GioiTinh,
            this.Cot_TinhTrangHS,
            this.Cot_LuongMongDoi,
            this.Cot_TinhTrangHonNhan,
            this.Cot_Mail,
            this.Cot_DienThoai,
            this.Cot_DiaChi,
            this.Cot_LoaiHoSo,
            this.CotNgayCapNhat,
            this.CotMaHoSo});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupPanelText = "Danh sách ứng viên thỏa điều kiện tìm kiếm";
            this.gridViewMaster.IndicatorWidth = 40;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.NewItemRowText = "Nhập dữ liệu mới tại đây";
            this.gridViewMaster.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridViewMaster.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewMaster.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewMaster.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewMaster.OptionsSelection.MultiSelect = true;
            this.gridViewMaster.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMaster.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = true;
            // 
            // Cot_ID
            // 
            this.Cot_ID.Caption = "ID";
            this.Cot_ID.FieldName = "ID";
            this.Cot_ID.Name = "Cot_ID";
            this.Cot_ID.Width = 23;
            // 
            // Cot_ViTriTuyenDung
            // 
            this.Cot_ViTriTuyenDung.Caption = "Vị trí ứng tuyển";
            this.Cot_ViTriTuyenDung.Name = "Cot_ViTriTuyenDung";
            this.Cot_ViTriTuyenDung.Visible = true;
            this.Cot_ViTriTuyenDung.VisibleIndex = 1;
            this.Cot_ViTriTuyenDung.Width = 86;
            // 
            // Cot_Ten
            // 
            this.Cot_Ten.Caption = "Ứng viên";
            this.Cot_Ten.FieldName = "TEN";
            this.Cot_Ten.Name = "Cot_Ten";
            this.Cot_Ten.Visible = true;
            this.Cot_Ten.VisibleIndex = 2;
            this.Cot_Ten.Width = 44;
            // 
            // Cot_NgaySinh
            // 
            this.Cot_NgaySinh.Caption = " Ngày sinh";
            this.Cot_NgaySinh.FieldName = "NGAY_SINH";
            this.Cot_NgaySinh.Name = "Cot_NgaySinh";
            this.Cot_NgaySinh.Visible = true;
            this.Cot_NgaySinh.VisibleIndex = 3;
            this.Cot_NgaySinh.Width = 62;
            // 
            // Cot_GioiTinh
            // 
            this.Cot_GioiTinh.Caption = "Giới tính";
            this.Cot_GioiTinh.FieldName = "GIOI_TINH";
            this.Cot_GioiTinh.Name = "Cot_GioiTinh";
            this.Cot_GioiTinh.Visible = true;
            this.Cot_GioiTinh.VisibleIndex = 4;
            this.Cot_GioiTinh.Width = 50;
            // 
            // Cot_TinhTrangHS
            // 
            this.Cot_TinhTrangHS.Caption = "Tình trạng hồ sơ";
            this.Cot_TinhTrangHS.Name = "Cot_TinhTrangHS";
            this.Cot_TinhTrangHS.Visible = true;
            this.Cot_TinhTrangHS.VisibleIndex = 5;
            this.Cot_TinhTrangHS.Width = 90;
            // 
            // Cot_LuongMongDoi
            // 
            this.Cot_LuongMongDoi.Caption = "Lương mong đợi";
            this.Cot_LuongMongDoi.FieldName = "LUONG_MONG_DOI";
            this.Cot_LuongMongDoi.Name = "Cot_LuongMongDoi";
            this.Cot_LuongMongDoi.Visible = true;
            this.Cot_LuongMongDoi.VisibleIndex = 6;
            this.Cot_LuongMongDoi.Width = 88;
            // 
            // Cot_TinhTrangHonNhan
            // 
            this.Cot_TinhTrangHonNhan.Caption = "Tình trạng hôn nhân";
            this.Cot_TinhTrangHonNhan.FieldName = "TINH_TRANG_HON_NHAN";
            this.Cot_TinhTrangHonNhan.Name = "Cot_TinhTrangHonNhan";
            this.Cot_TinhTrangHonNhan.Width = 109;
            // 
            // Cot_Mail
            // 
            this.Cot_Mail.Caption = "Email";
            this.Cot_Mail.FieldName = "EMAIL";
            this.Cot_Mail.Name = "Cot_Mail";
            this.Cot_Mail.Visible = true;
            this.Cot_Mail.VisibleIndex = 7;
            this.Cot_Mail.Width = 36;
            // 
            // Cot_DienThoai
            // 
            this.Cot_DienThoai.Caption = "Điện thoại";
            this.Cot_DienThoai.FieldName = "DIEN_THOAI";
            this.Cot_DienThoai.Name = "Cot_DienThoai";
            this.Cot_DienThoai.Width = 61;
            // 
            // Cot_DiaChi
            // 
            this.Cot_DiaChi.Caption = "Địa chỉ";
            this.Cot_DiaChi.FieldName = "DIA_CHI";
            this.Cot_DiaChi.Name = "Cot_DiaChi";
            this.Cot_DiaChi.Visible = true;
            this.Cot_DiaChi.VisibleIndex = 8;
            this.Cot_DiaChi.Width = 44;
            // 
            // Cot_LoaiHoSo
            // 
            this.Cot_LoaiHoSo.Caption = "Loại hồ sơ";
            this.Cot_LoaiHoSo.FieldName = "LOAI_HO_SO";
            this.Cot_LoaiHoSo.Name = "Cot_LoaiHoSo";
            this.Cot_LoaiHoSo.Visible = true;
            this.Cot_LoaiHoSo.VisibleIndex = 9;
            this.Cot_LoaiHoSo.Width = 60;
            // 
            // CotNgayCapNhat
            // 
            this.CotNgayCapNhat.Caption = "Ngày cập nhật";
            this.CotNgayCapNhat.Name = "CotNgayCapNhat";
            this.CotNgayCapNhat.Visible = true;
            this.CotNgayCapNhat.VisibleIndex = 10;
            this.CotNgayCapNhat.Width = 82;
            // 
            // CotMaHoSo
            // 
            this.CotMaHoSo.Caption = "Mã hồ sơ";
            this.CotMaHoSo.Name = "CotMaHoSo";
            this.CotMaHoSo.Visible = true;
            this.CotMaHoSo.VisibleIndex = 0;
            this.CotMaHoSo.Width = 55;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // tabkpage
            // 
            this.tabkpage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabkpage.Location = new System.Drawing.Point(0, 0);
            this.tabkpage.Name = "tabkpage";
            this.tabkpage.SelectedTabPage = this.xtraTabPage1;
            this.tabkpage.Size = new System.Drawing.Size(804, 234);
            this.tabkpage.TabIndex = 10;
            this.tabkpage.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4,
            this.xtraTabPage5});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.Web_QuaTrinhDaoTao);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(797, 205);
            this.xtraTabPage1.Text = "Quá trình đào tạo";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.Web_QuaTrinhCongTac);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(797, 205);
            this.xtraTabPage2.Text = "Quá trình công tác";
            // 
            // Web_QuaTrinhCongTac
            // 
            this.Web_QuaTrinhCongTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Web_QuaTrinhCongTac.Location = new System.Drawing.Point(0, 0);
            this.Web_QuaTrinhCongTac.MinimumSize = new System.Drawing.Size(20, 20);
            this.Web_QuaTrinhCongTac.Name = "Web_QuaTrinhCongTac";
            this.Web_QuaTrinhCongTac.Size = new System.Drawing.Size(797, 205);
            this.Web_QuaTrinhCongTac.TabIndex = 1;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.Web_TrinhDoChuyenMon);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(797, 205);
            this.xtraTabPage3.Text = "Trình độ chuyên môn";
            // 
            // Web_TrinhDoChuyenMon
            // 
            this.Web_TrinhDoChuyenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Web_TrinhDoChuyenMon.Location = new System.Drawing.Point(0, 0);
            this.Web_TrinhDoChuyenMon.MinimumSize = new System.Drawing.Size(20, 20);
            this.Web_TrinhDoChuyenMon.Name = "Web_TrinhDoChuyenMon";
            this.Web_TrinhDoChuyenMon.Size = new System.Drawing.Size(797, 205);
            this.Web_TrinhDoChuyenMon.TabIndex = 1;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.Web_TrinhDoNgoaiNgu);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(797, 205);
            this.xtraTabPage4.Text = "Trình độ ngoại ngữ";
            // 
            // Web_TrinhDoNgoaiNgu
            // 
            this.Web_TrinhDoNgoaiNgu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Web_TrinhDoNgoaiNgu.Location = new System.Drawing.Point(0, 0);
            this.Web_TrinhDoNgoaiNgu.MinimumSize = new System.Drawing.Size(20, 20);
            this.Web_TrinhDoNgoaiNgu.Name = "Web_TrinhDoNgoaiNgu";
            this.Web_TrinhDoNgoaiNgu.Size = new System.Drawing.Size(797, 205);
            this.Web_TrinhDoNgoaiNgu.TabIndex = 1;
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.Web_ThongTinKhac);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(797, 205);
            this.xtraTabPage5.Text = "Thông tin khác";
            // 
            // Web_ThongTinKhac
            // 
            this.Web_ThongTinKhac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Web_ThongTinKhac.Location = new System.Drawing.Point(0, 0);
            this.Web_ThongTinKhac.MinimumSize = new System.Drawing.Size(20, 20);
            this.Web_ThongTinKhac.Name = "Web_ThongTinKhac";
            this.Web_ThongTinKhac.Size = new System.Drawing.Size(797, 205);
            this.Web_ThongTinKhac.TabIndex = 1;
            // 
            // xtraTabControlDetail
            // 
            this.xtraTabControlDetail.Location = new System.Drawing.Point(0, 78);
            this.xtraTabControlDetail.Name = "xtraTabControlDetail";
            this.xtraTabControlDetail.SelectedTabPage = this.xtraTabPageDetail;
            this.xtraTabControlDetail.Size = new System.Drawing.Size(980, 156);
            this.xtraTabControlDetail.TabIndex = 10;
            this.xtraTabControlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageDetail});
            // 
            // xtraTabPageDetail
            // 
            this.xtraTabPageDetail.Controls.Add(this.gridControlDetail);
            this.xtraTabPageDetail.Name = "xtraTabPageDetail";
            this.xtraTabPageDetail.Size = new System.Drawing.Size(973, 127);
            this.xtraTabPageDetail.Text = "Chi tiết";
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlDetail.BackgroundImage")));
            this.gridControlDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlDetail.Location = new System.Drawing.Point(0, 0);
            this.gridControlDetail.MainView = this.gridViewDetail;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.Size = new System.Drawing.Size(971, 73);
            this.gridControlDetail.TabIndex = 9;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetail});
            this.gridControlDetail.Visible = false;
            // 
            // gridViewDetail
            // 
            this.gridViewDetail.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Cot_TrinhDoChuyenMon,
            this.Cot_QuaTrinhCongTac,
            this.Cot_QuaTrinhDaoTao,
            this.Cot_TrinhDoNgoaiNgu,
            this.Cot_ThongTinKhac});
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
            // Cot_TrinhDoChuyenMon
            // 
            this.Cot_TrinhDoChuyenMon.Caption = "Trình độ chuyên môn";
            this.Cot_TrinhDoChuyenMon.FieldName = "TRINH_DO_CHUYEN_MON";
            this.Cot_TrinhDoChuyenMon.Name = "Cot_TrinhDoChuyenMon";
            this.Cot_TrinhDoChuyenMon.Visible = true;
            this.Cot_TrinhDoChuyenMon.VisibleIndex = 0;
            this.Cot_TrinhDoChuyenMon.Width = 112;
            // 
            // Cot_QuaTrinhCongTac
            // 
            this.Cot_QuaTrinhCongTac.Caption = "Quá trình công tác";
            this.Cot_QuaTrinhCongTac.FieldName = "QUA_TRINH_CONG_TAC";
            this.Cot_QuaTrinhCongTac.Name = "Cot_QuaTrinhCongTac";
            this.Cot_QuaTrinhCongTac.Visible = true;
            this.Cot_QuaTrinhCongTac.VisibleIndex = 1;
            this.Cot_QuaTrinhCongTac.Width = 101;
            // 
            // Cot_QuaTrinhDaoTao
            // 
            this.Cot_QuaTrinhDaoTao.Caption = "Quá trình đào tạo";
            this.Cot_QuaTrinhDaoTao.FieldName = "QUA_TRINH_DAO_TAO";
            this.Cot_QuaTrinhDaoTao.Name = "Cot_QuaTrinhDaoTao";
            this.Cot_QuaTrinhDaoTao.Visible = true;
            this.Cot_QuaTrinhDaoTao.VisibleIndex = 2;
            this.Cot_QuaTrinhDaoTao.Width = 97;
            // 
            // Cot_TrinhDoNgoaiNgu
            // 
            this.Cot_TrinhDoNgoaiNgu.Caption = "Trình độ ngoại ngữ";
            this.Cot_TrinhDoNgoaiNgu.FieldName = "TRINH_DO_NGOAI_NGU";
            this.Cot_TrinhDoNgoaiNgu.Name = "Cot_TrinhDoNgoaiNgu";
            this.Cot_TrinhDoNgoaiNgu.Visible = true;
            this.Cot_TrinhDoNgoaiNgu.VisibleIndex = 3;
            this.Cot_TrinhDoNgoaiNgu.Width = 102;
            // 
            // Cot_ThongTinKhac
            // 
            this.Cot_ThongTinKhac.Caption = "Thông tin khác";
            this.Cot_ThongTinKhac.FieldName = "THONG_TIN_KHAC";
            this.Cot_ThongTinKhac.Name = "Cot_ThongTinKhac";
            this.Cot_ThongTinKhac.Visible = true;
            this.Cot_ThongTinKhac.VisibleIndex = 4;
            this.Cot_ThongTinKhac.Width = 82;
            // 
            // popupControlContainerFilter
            // 
            this.popupControlContainerFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainerFilter.Controls.Add(this.textEdit1);
            this.popupControlContainerFilter.Controls.Add(this.labelControl10);
            this.popupControlContainerFilter.Controls.Add(this.PLLoaiHoSo);
            this.popupControlContainerFilter.Controls.Add(this.Filter_TinhTrangHoSo);
            this.popupControlContainerFilter.Controls.Add(this.Filter_DotPhongVan);
            this.popupControlContainerFilter.Controls.Add(this.Filter_VTUngTuyen);
            this.popupControlContainerFilter.Controls.Add(this.labelControl5);
            this.popupControlContainerFilter.Controls.Add(this.Filter_NamSinhDen);
            this.popupControlContainerFilter.Controls.Add(this.Filter_NamSinhTu);
            this.popupControlContainerFilter.Controls.Add(this.Filter_Email);
            this.popupControlContainerFilter.Controls.Add(this.Filter_Ten);
            this.popupControlContainerFilter.Controls.Add(this.labelControl4);
            this.popupControlContainerFilter.Controls.Add(this.labelControl3);
            this.popupControlContainerFilter.Controls.Add(this.labelControl6);
            this.popupControlContainerFilter.Controls.Add(this.labelControl2);
            this.popupControlContainerFilter.Controls.Add(this.labelControl9);
            this.popupControlContainerFilter.Controls.Add(this.labelControl8);
            this.popupControlContainerFilter.Controls.Add(this.labelControl7);
            this.popupControlContainerFilter.Controls.Add(this.labelControl1);
            this.popupControlContainerFilter.Controls.Add(this.Filter_GTNu);
            this.popupControlContainerFilter.Controls.Add(this.Filter_GTNam);
            this.popupControlContainerFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupControlContainerFilter.Location = new System.Drawing.Point(0, 24);
            this.popupControlContainerFilter.Manager = this.barManager1;
            this.popupControlContainerFilter.Name = "popupControlContainerFilter";
            this.popupControlContainerFilter.Size = new System.Drawing.Size(804, 91);
            this.popupControlContainerFilter.TabIndex = 5;
            this.popupControlContainerFilter.Visible = false;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(54, 5);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(142, 20);
            this.textEdit1.TabIndex = 26;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(10, 9);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(43, 13);
            this.labelControl10.TabIndex = 25;
            this.labelControl10.Text = "Mã hồ sơ";
            this.labelControl10.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl10.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // PLLoaiHoSo
            // 
            this.PLLoaiHoSo.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.PLLoaiHoSo.Appearance.Options.UseBackColor = true;
            this.PLLoaiHoSo.AutoSize = true;
            this.PLLoaiHoSo.DataSource = null;
            this.PLLoaiHoSo.DisplayField = null;
            this.PLLoaiHoSo.Location = new System.Drawing.Point(849, 8);
            this.PLLoaiHoSo.Name = "PLLoaiHoSo";
            this.PLLoaiHoSo.Size = new System.Drawing.Size(140, 20);
            this.PLLoaiHoSo.TabIndex = 24;
            this.PLLoaiHoSo.ValueField = null;
            // 
            // Filter_TinhTrangHoSo
            // 
            this.Filter_TinhTrangHoSo.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Filter_TinhTrangHoSo.Appearance.Options.UseBackColor = true;
            this.Filter_TinhTrangHoSo.AutoSize = true;
            this.Filter_TinhTrangHoSo.DataSource = null;
            this.Filter_TinhTrangHoSo.DisplayField = null;
            this.Filter_TinhTrangHoSo.Location = new System.Drawing.Point(296, 35);
            this.Filter_TinhTrangHoSo.Name = "Filter_TinhTrangHoSo";
            this.Filter_TinhTrangHoSo.Size = new System.Drawing.Size(140, 20);
            this.Filter_TinhTrangHoSo.TabIndex = 23;
            this.Filter_TinhTrangHoSo.ValueField = null;
            // 
            // Filter_DotPhongVan
            // 
            this.Filter_DotPhongVan.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Filter_DotPhongVan.Appearance.Options.UseBackColor = true;
            this.Filter_DotPhongVan.AutoSize = true;
            this.Filter_DotPhongVan.DataSource = null;
            this.Filter_DotPhongVan.DisplayField = null;
            this.Filter_DotPhongVan.Location = new System.Drawing.Point(849, 35);
            this.Filter_DotPhongVan.Name = "Filter_DotPhongVan";
            this.Filter_DotPhongVan.Size = new System.Drawing.Size(140, 20);
            this.Filter_DotPhongVan.TabIndex = 23;
            this.Filter_DotPhongVan.ValueField = null;
            this.Filter_DotPhongVan.Visible = false;
            // 
            // Filter_VTUngTuyen
            // 
            this.Filter_VTUngTuyen.Location = new System.Drawing.Point(532, 8);
            this.Filter_VTUngTuyen.Name = "Filter_VTUngTuyen";
            this.Filter_VTUngTuyen.Size = new System.Drawing.Size(212, 71);
            this.Filter_VTUngTuyen.TabIndex = 21;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(454, 12);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(74, 13);
            this.labelControl5.TabIndex = 20;
            this.labelControl5.Text = "Vị trí ứng tuyển";
            this.labelControl5.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // Filter_NamSinhDen
            // 
            this.Filter_NamSinhDen.EditValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.Filter_NamSinhDen.Location = new System.Drawing.Point(382, 8);
            this.Filter_NamSinhDen.Name = "Filter_NamSinhDen";
            this.Filter_NamSinhDen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Filter_NamSinhDen.Properties.Mask.EditMask = "n0";
            this.Filter_NamSinhDen.Size = new System.Drawing.Size(54, 20);
            this.Filter_NamSinhDen.TabIndex = 19;
            // 
            // Filter_NamSinhTu
            // 
            this.Filter_NamSinhTu.EditValue = new decimal(new int[] {
            1980,
            0,
            0,
            0});
            this.Filter_NamSinhTu.Location = new System.Drawing.Point(296, 8);
            this.Filter_NamSinhTu.Name = "Filter_NamSinhTu";
            this.Filter_NamSinhTu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Filter_NamSinhTu.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Filter_NamSinhTu.Properties.Mask.EditMask = "n0";
            this.Filter_NamSinhTu.Properties.Mask.ShowPlaceHolders = false;
            this.Filter_NamSinhTu.Size = new System.Drawing.Size(54, 20);
            this.Filter_NamSinhTu.TabIndex = 19;
            // 
            // Filter_Email
            // 
            this.Filter_Email.Location = new System.Drawing.Point(54, 61);
            this.Filter_Email.Name = "Filter_Email";
            this.Filter_Email.Size = new System.Drawing.Size(142, 20);
            this.Filter_Email.TabIndex = 18;
            // 
            // Filter_Ten
            // 
            this.Filter_Ten.Location = new System.Drawing.Point(54, 34);
            this.Filter_Ten.Name = "Filter_Ten";
            this.Filter_Ten.Size = new System.Drawing.Size(142, 20);
            this.Filter_Ten.TabIndex = 17;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 38);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(32, 13);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Ứng viên";
            this.labelControl4.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 65);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Email";
            this.labelControl3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(361, 12);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(18, 13);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "đến";
            this.labelControl6.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl6.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(213, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 13);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Năm sinh từ";
            this.labelControl2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(765, 12);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(48, 13);
            this.labelControl9.TabIndex = 12;
            this.labelControl9.Text = "Loại hồ sơ";
            this.labelControl9.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl9.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(213, 39);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(78, 13);
            this.labelControl8.TabIndex = 12;
            this.labelControl8.Text = "Tình trạng hồ sơ";
            this.labelControl8.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl8.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(766, 39);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(72, 13);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "Đợt phỏng vấn";
            this.labelControl7.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl7.Visible = false;
            this.labelControl7.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(215, 64);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Giới tính";
            this.labelControl1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // Filter_GTNu
            // 
            this.Filter_GTNu.Location = new System.Drawing.Point(353, 61);
            this.Filter_GTNu.Name = "Filter_GTNu";
            this.Filter_GTNu.Properties.Caption = "Nữ";
            this.Filter_GTNu.Size = new System.Drawing.Size(46, 19);
            this.Filter_GTNu.TabIndex = 11;
            this.Filter_GTNu.ToolTip = "Dữ liệu bắt buộc nhập";
            this.Filter_GTNu.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
            // 
            // Filter_GTNam
            // 
            this.Filter_GTNam.Location = new System.Drawing.Point(295, 61);
            this.Filter_GTNam.Name = "Filter_GTNam";
            this.Filter_GTNam.Properties.Caption = "Nam";
            this.Filter_GTNam.Size = new System.Drawing.Size(46, 19);
            this.Filter_GTNam.TabIndex = 10;
            this.Filter_GTNam.ToolTip = "Dữ liệu bắt buộc nhập";
            this.Filter_GTNam.ZZZType = ProtocolVN.Framework.Win.CaptionType.REQUIRED;
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
            // frmHoSoQL
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
            this.Name = "frmHoSoQL";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý ứng viên";
            this.Load += new System.EventHandler(this.frmTestPhieuQuanLy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabkpage)).EndInit();
            this.tabkpage.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDetail)).EndInit();
            this.xtraTabControlDetail.ResumeLayout(false);
            this.xtraTabPageDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainerFilter)).EndInit();
            this.popupControlContainerFilter.ResumeLayout(false);
            this.popupControlContainerFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_VTUngTuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_NamSinhDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_NamSinhTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Email.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Ten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_GTNu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_GTNam.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit Filter_Email;
        private DevExpress.XtraEditors.TextEdit Filter_Ten;
        private ProtocolVN.Framework.Win.PLCheckEdit Filter_GTNu;
        private ProtocolVN.Framework.Win.PLCheckEdit Filter_GTNam;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_Ten;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_DiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_DienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_Mail;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_NgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_GioiTinh;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_LuongMongDoi;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_TinhTrangHonNhan;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_TrinhDoChuyenMon;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_QuaTrinhCongTac;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_QuaTrinhDaoTao;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_TrinhDoNgoaiNgu;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_ThongTinKhac;
        private DevExpress.XtraTab.XtraTabControl tabkpage;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private DevExpress.XtraEditors.SpinEdit Filter_NamSinhDen;
        private DevExpress.XtraEditors.SpinEdit Filter_NamSinhTu;
        private System.Windows.Forms.WebBrowser Web_QuaTrinhCongTac;
        private System.Windows.Forms.WebBrowser Web_QuaTrinhDaoTao;
        private System.Windows.Forms.WebBrowser Web_TrinhDoChuyenMon;
        private System.Windows.Forms.WebBrowser Web_TrinhDoNgoaiNgu;
        private System.Windows.Forms.WebBrowser Web_ThongTinKhac;
        private DevExpress.XtraEditors.CheckedListBoxControl Filter_VTUngTuyen;
        private PLCombobox Filter_DotPhongVan;
        private PLCombobox Filter_TinhTrangHoSo;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_ID;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_ViTriTuyenDung;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_TinhTrangHS;
        private PLCombobox PLLoaiHoSo;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_LoaiHoSo;
        private DevExpress.XtraGrid.Columns.GridColumn CotNgayCapNhat;
        private DevExpress.XtraGrid.Columns.GridColumn CotMaHoSo;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel labelControl6;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel labelControl8;
        private System.Windows.Forms.PLLabel labelControl7;
        private System.Windows.Forms.PLLabel labelControl9;
        private System.Windows.Forms.PLLabel labelControl10;
             
                
    }
}