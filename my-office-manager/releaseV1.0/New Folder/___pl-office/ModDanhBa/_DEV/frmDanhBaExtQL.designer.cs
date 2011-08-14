namespace office
{
    partial class frmDanhBaExtQL
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhBaExtQL));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItemThemNguoiLL = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXoaNguoiLL = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSuaNguoiLL = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLuu = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemKhongLuu = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemIn = new DevExpress.XtraBars.BarButtonItem();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItemThemNhom = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXoaNhom = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDoiTenNhom = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSuaNhom = new DevExpress.XtraBars.BarButtonItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlThongtin = new DevExpress.XtraGrid.GridControl();
            this.gridViewThongtin = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cot_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cot_diachi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cot_dienthoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cot_ten_NH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cot_fax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cot_nguoidaidien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cot_chucvu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cot_didong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cot_loaidanhba = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cot_taikhoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cot_email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThongtin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThongtin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemThemNhom,
            this.barButtonItemXoaNhom,
            this.barButtonItemDoiTenNhom,
            this.barButtonItemThemNguoiLL,
            this.barButtonItemXoaNguoiLL,
            this.barButtonItemSuaNguoiLL,
            this.barButtonItemIn,
            this.barButtonItemLuu,
            this.barButtonItemKhongLuu,
            this.barButtonItemSuaNhom});
            this.barManager1.MaxItemId = 12;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar2.FloatLocation = new System.Drawing.Point(332, 179);
            this.bar2.FloatSize = new System.Drawing.Size(292, 68);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemThemNguoiLL, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemXoaNguoiLL, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemSuaNguoiLL, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemLuu, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemKhongLuu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemIn, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DisableCustomization = true;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.Hidden = true;
            this.bar2.OptionsBar.RotateWhenVertical = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItemThemNguoiLL
            // 
            this.barButtonItemThemNguoiLL.Caption = "&Thêm";
            this.barButtonItemThemNguoiLL.Id = 3;
            this.barButtonItemThemNguoiLL.Name = "barButtonItemThemNguoiLL";
            this.barButtonItemThemNguoiLL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemThemNguoiLL_ItemClick);
            // 
            // barButtonItemXoaNguoiLL
            // 
            this.barButtonItemXoaNguoiLL.Caption = "&Xóa";
            this.barButtonItemXoaNguoiLL.Id = 4;
            this.barButtonItemXoaNguoiLL.Name = "barButtonItemXoaNguoiLL";
            this.barButtonItemXoaNguoiLL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemXoaNguoiLL_ItemClick);
            // 
            // barButtonItemSuaNguoiLL
            // 
            this.barButtonItemSuaNguoiLL.Caption = "S&ửa";
            this.barButtonItemSuaNguoiLL.Id = 5;
            this.barButtonItemSuaNguoiLL.Name = "barButtonItemSuaNguoiLL";
            this.barButtonItemSuaNguoiLL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSuaNguoiLL_ItemClick);
            // 
            // barButtonItemLuu
            // 
            this.barButtonItemLuu.Caption = "&Lưu";
            this.barButtonItemLuu.Id = 9;
            this.barButtonItemLuu.Name = "barButtonItemLuu";
            this.barButtonItemLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemLuu_ItemClick);
            // 
            // barButtonItemKhongLuu
            // 
            this.barButtonItemKhongLuu.Caption = "&Không Lưu";
            this.barButtonItemKhongLuu.Id = 10;
            this.barButtonItemKhongLuu.Name = "barButtonItemKhongLuu";
            this.barButtonItemKhongLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemKhongLuu_ItemClick);
            // 
            // barButtonItemIn
            // 
            this.barButtonItemIn.Caption = "In";
            this.barButtonItemIn.Id = 7;
            this.barButtonItemIn.Name = "barButtonItemIn";
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(202, 0);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(602, 30);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barButtonItemThemNhom
            // 
            this.barButtonItemThemNhom.Caption = "&Thêm nhóm";
            this.barButtonItemThemNhom.Id = 0;
            this.barButtonItemThemNhom.Name = "barButtonItemThemNhom";
            this.barButtonItemThemNhom.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemThemNhom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemThemNhom_ItemClick);
            // 
            // barButtonItemXoaNhom
            // 
            this.barButtonItemXoaNhom.Caption = "&Xóa nhóm";
            this.barButtonItemXoaNhom.Id = 1;
            this.barButtonItemXoaNhom.Name = "barButtonItemXoaNhom";
            this.barButtonItemXoaNhom.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemXoaNhom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemXoaNhom_ItemClick);
            // 
            // barButtonItemDoiTenNhom
            // 
            this.barButtonItemDoiTenNhom.Caption = "Đổi tên &nhóm";
            this.barButtonItemDoiTenNhom.Id = 2;
            this.barButtonItemDoiTenNhom.Name = "barButtonItemDoiTenNhom";
            this.barButtonItemDoiTenNhom.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemDoiTenNhom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDoiTenNhom_ItemClick);
            // 
            // barButtonItemSuaNhom
            // 
            this.barButtonItemSuaNhom.Caption = "&Sửa nhóm";
            this.barButtonItemSuaNhom.Id = 11;
            this.barButtonItemSuaNhom.Name = "barButtonItemSuaNhom";
            this.barButtonItemSuaNhom.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemSuaNhom.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "mnsNotePad.png");
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.AllowSelectedLink = true;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 140;
            this.navBarControl1.OptionsNavPane.ShowOverflowPanel = false;
            this.navBarControl1.OptionsNavPane.ShowSplitter = false;
            this.navBarControl1.Size = new System.Drawing.Size(196, 513);
            this.navBarControl1.TabIndex = 6;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
            this.navBarControl1.SelectedLinkChanged += new DevExpress.XtraNavBar.ViewInfo.NavBarSelectedLinkChangedEventHandler(this.navBarControl1_SelectedLinkChanged);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Nhóm danh bạ";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.NavigationPaneVisible = false;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(196, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 513);
            this.splitterControl1.TabIndex = 17;
            this.splitterControl1.TabStop = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControlThongtin);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(202, 30);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(602, 483);
            this.panelControl1.TabIndex = 20;
            // 
            // gridControlThongtin
            // 
            this.gridControlThongtin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlThongtin.BackgroundImage")));
            this.gridControlThongtin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlThongtin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlThongtin.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControlThongtin.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControlThongtin.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControlThongtin.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControlThongtin.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gridControlThongtin.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gridControlThongtin.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.gridControlThongtin.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gridControlThongtin.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.gridControlThongtin.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gridControlThongtin.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControlThongtin.EmbeddedNavigator.TextStringFormat = "Tổng số mẩu tin: {1}";
            this.gridControlThongtin.Location = new System.Drawing.Point(2, 2);
            this.gridControlThongtin.MainView = this.gridViewThongtin;
            this.gridControlThongtin.Name = "gridControlThongtin";
            this.gridControlThongtin.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gridControlThongtin.Size = new System.Drawing.Size(598, 479);
            this.gridControlThongtin.TabIndex = 6;
            this.gridControlThongtin.UseEmbeddedNavigator = true;
            this.gridControlThongtin.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewThongtin});
            // 
            // gridViewThongtin
            // 
            this.gridViewThongtin.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewThongtin.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewThongtin.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.cot_name,
            this.cot_diachi,
            this.cot_dienthoai,
            this.cot_ten_NH,
            this.cot_fax,
            this.cot_nguoidaidien,
            this.cot_chucvu,
            this.cot_didong,
            this.cot_loaidanhba,
            this.cot_taikhoan,
            this.cot_email});
            this.gridViewThongtin.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewThongtin.GridControl = this.gridControlThongtin;
            this.gridViewThongtin.GroupPanelText = "Chi tiết danh bạ";
            this.gridViewThongtin.IndicatorWidth = 40;
            this.gridViewThongtin.Name = "gridViewThongtin";
            this.gridViewThongtin.OptionsBehavior.Editable = false;
            this.gridViewThongtin.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewThongtin.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridViewThongtin.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewThongtin.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewThongtin.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewThongtin.OptionsView.ColumnAutoWidth = false;
            this.gridViewThongtin.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewThongtin.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewThongtin.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewThongtin.OptionsView.ShowDetailButtons = false;
            this.gridViewThongtin.OptionsView.ShowGroupedColumns = true;
            this.gridViewThongtin.OptionsView.ShowGroupPanel = false;
            this.gridViewThongtin.OptionsView.ShowViewCaption = true;
            this.gridViewThongtin.ViewCaption = "DANH BẠ ĐỊA CHỈ";
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 23;
            // 
            // cot_name
            // 
            this.cot_name.Caption = "Tên liên lạc";
            this.cot_name.Name = "cot_name";
            this.cot_name.Visible = true;
            this.cot_name.VisibleIndex = 0;
            this.cot_name.Width = 65;
            // 
            // cot_diachi
            // 
            this.cot_diachi.Caption = "Địa chỉ";
            this.cot_diachi.Name = "cot_diachi";
            this.cot_diachi.Visible = true;
            this.cot_diachi.VisibleIndex = 3;
            this.cot_diachi.Width = 44;
            // 
            // cot_dienthoai
            // 
            this.cot_dienthoai.Caption = "Điện thoại bàn";
            this.cot_dienthoai.Name = "cot_dienthoai";
            this.cot_dienthoai.Visible = true;
            this.cot_dienthoai.VisibleIndex = 4;
            this.cot_dienthoai.Width = 82;
            // 
            // cot_ten_NH
            // 
            this.cot_ten_NH.Caption = "Tên ngân hàng";
            this.cot_ten_NH.Name = "cot_ten_NH";
            this.cot_ten_NH.Visible = true;
            this.cot_ten_NH.VisibleIndex = 9;
            this.cot_ten_NH.Width = 84;
            // 
            // cot_fax
            // 
            this.cot_fax.Caption = "FAX";
            this.cot_fax.Name = "cot_fax";
            this.cot_fax.Visible = true;
            this.cot_fax.VisibleIndex = 6;
            this.cot_fax.Width = 31;
            // 
            // cot_nguoidaidien
            // 
            this.cot_nguoidaidien.Caption = "Người liên hệ";
            this.cot_nguoidaidien.Name = "cot_nguoidaidien";
            this.cot_nguoidaidien.Visible = true;
            this.cot_nguoidaidien.VisibleIndex = 1;
            this.cot_nguoidaidien.Width = 74;
            // 
            // cot_chucvu
            // 
            this.cot_chucvu.Caption = "Chức vụ";
            this.cot_chucvu.Name = "cot_chucvu";
            this.cot_chucvu.Visible = true;
            this.cot_chucvu.VisibleIndex = 2;
            this.cot_chucvu.Width = 52;
            // 
            // cot_didong
            // 
            this.cot_didong.Caption = "Di động";
            this.cot_didong.Name = "cot_didong";
            this.cot_didong.Visible = true;
            this.cot_didong.VisibleIndex = 5;
            this.cot_didong.Width = 48;
            // 
            // cot_loaidanhba
            // 
            this.cot_loaidanhba.Caption = "Loại danh bạ";
            this.cot_loaidanhba.Name = "cot_loaidanhba";
            this.cot_loaidanhba.Visible = true;
            this.cot_loaidanhba.VisibleIndex = 10;
            this.cot_loaidanhba.Width = 73;
            // 
            // cot_taikhoan
            // 
            this.cot_taikhoan.Caption = "Số tài Khoản";
            this.cot_taikhoan.Name = "cot_taikhoan";
            this.cot_taikhoan.Visible = true;
            this.cot_taikhoan.VisibleIndex = 8;
            this.cot_taikhoan.Width = 59;
            // 
            // cot_email
            // 
            this.cot_email.Caption = "Email";
            this.cot_email.Name = "cot_email";
            this.cot_email.Visible = true;
            this.cot_email.VisibleIndex = 7;
            this.cot_email.Width = 36;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.IgnoreMaskBlank = false;
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.repositoryItemTextEdit1.Mask.SaveLiteral = false;
            this.repositoryItemTextEdit1.Mask.ShowPlaceHolders = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // frmDanhBaExtQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 513);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.standaloneBarDockControl1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Name = "frmDanhBaExtQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh bạ địa chỉ";
            this.Load += new System.EventHandler(this.frmDanhba_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThongtin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThongtin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        public DevExpress.XtraBars.BarButtonItem barButtonItemThemNhom;
        public DevExpress.XtraBars.BarButtonItem barButtonItemXoaNhom;
        public DevExpress.XtraBars.BarButtonItem barButtonItemDoiTenNhom;
        public DevExpress.XtraBars.BarButtonItem barButtonItemThemNguoiLL;
        public DevExpress.XtraBars.BarButtonItem barButtonItemXoaNguoiLL;
        public DevExpress.XtraBars.BarButtonItem barButtonItemSuaNguoiLL;
        private DevExpress.XtraBars.BarButtonItem barButtonItemIn;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        protected DevExpress.XtraBars.Bar bar2;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        public DevExpress.XtraBars.BarButtonItem barButtonItemLuu;
        public DevExpress.XtraBars.BarButtonItem barButtonItemKhongLuu;
        public DevExpress.XtraBars.BarButtonItem barButtonItemSuaNhom;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlThongtin;
        private DevExpress.XtraGrid.Views.Grid.PLGridView gridViewThongtin;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn cot_name;
        private DevExpress.XtraGrid.Columns.GridColumn cot_diachi;
        private DevExpress.XtraGrid.Columns.GridColumn cot_dienthoai;
        private DevExpress.XtraGrid.Columns.GridColumn cot_ten_NH;
        private DevExpress.XtraGrid.Columns.GridColumn cot_fax;
        private DevExpress.XtraGrid.Columns.GridColumn cot_nguoidaidien;
        private DevExpress.XtraGrid.Columns.GridColumn cot_chucvu;
        private DevExpress.XtraGrid.Columns.GridColumn cot_didong;
        private DevExpress.XtraGrid.Columns.GridColumn cot_loaidanhba;
        private DevExpress.XtraGrid.Columns.GridColumn cot_taikhoan;
        private DevExpress.XtraGrid.Columns.GridColumn cot_email;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;

    }
}