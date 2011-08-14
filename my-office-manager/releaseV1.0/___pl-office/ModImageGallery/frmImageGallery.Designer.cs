using ProtocolVN.Framework.Win;
using System;
namespace office
{
    partial class frmImageGallery
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
                _picController.ShowTrackerOnZoom(false);//(!_picController.PictureShow.ShowPanOnZoom);
            }
            catch (Exception ex)
            {
                PLMessageBoxDev.ShowMessage(ex.ToString());
            }
            finally
            {
                try
                {
                    this.viewerMain.Dispose();
                    this.crystalImageGridView1.Dispose();
                    if (disposing && (components != null))
                    {
                        components.Dispose();
                    }
                    base.Dispose(disposing);
                }
                catch (Exception)
                {

                }
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImageGallery));
            Attilan.Crystal.Controls.CrystalSlideShowOptions crystalSlideShowOptions1 = new Attilan.Crystal.Controls.CrystalSlideShowOptions();
            Attilan.Crystal.Controls.CrystalDesignCollector crystalDesignCollector1 = new Attilan.Crystal.Controls.CrystalDesignCollector();
            Attilan.Crystal.Controls.CrystalHeaderStyle crystalHeaderStyle1 = new Attilan.Crystal.Controls.CrystalHeaderStyle();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemOpenfile = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonOpen = new DevExpress.XtraBars.BarButtonItem();
            this.barSave = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.Thumbnail = new DevExpress.XtraBars.BarButtonItem();
            this.barSlipView = new DevExpress.XtraBars.BarButtonItem();
            this.barImageView = new DevExpress.XtraBars.BarButtonItem();
            this.barSlideShow = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExitSlideShow = new DevExpress.XtraBars.BarButtonItem();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.barOpen = new DevExpress.XtraBars.BarButtonItem();
            this.barExit = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.imageSplitContainer = new System.Windows.Forms.SplitContainer();
            this.viewerMain = new Attilan.Crystal.Controls.CrystalPictureShow();
            this.navToolStrip = new System.Windows.Forms.ToolStrip();
            this.zoomToolStripTrackBar = new Attilan.Crystal.Controls.CrystalToolStripTrackBar();
            this.zoomComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.leftButton = new System.Windows.Forms.ToolStripButton();
            this.rightButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonPan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.crystalImageGridView1 = new Attilan.Crystal.Controls.CrystalImageGridView();
            this.imageGridToolStrip = new System.Windows.Forms.ToolStrip();
            this.thumbZoomToolStripTrackBar = new Attilan.Crystal.Controls.CrystalToolStripTrackBar();
            this.toolStripButtonCopyThumb = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonXoaThumb = new System.Windows.Forms.ToolStripButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.imageSplitContainer.Panel1.SuspendLayout();
            this.imageSplitContainer.Panel2.SuspendLayout();
            this.imageSplitContainer.SuspendLayout();
            this.navToolStrip.SuspendLayout();
            this.imageGridToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageList2;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barOpen,
            this.barExit,
            this.Thumbnail,
            this.barSlipView,
            this.barImageView,
            this.barSlideShow,
            this.barSubItem1,
            this.barSubItem2,
            this.barButtonOpen,
            this.barSubItem3,
            this.barSave,
            this.barButtonItemOpenfile,
            this.barButtonItemExitSlideShow});
            this.barManager1.MaxItemId = 27;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.FloatLocation = new System.Drawing.Point(176, 185);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem3, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSlideShow, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemExitSlideShow)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.RotateWhenVertical = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar1.Text = "Tools";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "&Thao tác";
            this.barSubItem2.Id = 13;
            this.barSubItem2.ImageIndex = 7;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemOpenfile, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonOpen),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSave, true)});
            this.barSubItem2.Name = "barSubItem2";
            this.barSubItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItemOpenfile
            // 
            this.barButtonItemOpenfile.Caption = "T&hêm ảnh vào...";
            this.barButtonItemOpenfile.Id = 23;
            this.barButtonItemOpenfile.ImageIndex = 3;
            this.barButtonItemOpenfile.Name = "barButtonItemOpenfile";
            this.barButtonItemOpenfile.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemOpenfile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOpenfile_ItemClick);
            // 
            // barButtonOpen
            // 
            this.barButtonOpen.Caption = "Thê&m ảnh từ thư mục vào...";
            this.barButtonOpen.Id = 14;
            this.barButtonOpen.ImageIndex = 4;
            this.barButtonOpen.Name = "barButtonOpen";
            this.barButtonOpen.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonOpen_ItemClick);
            // 
            // barSave
            // 
            this.barSave.Caption = "&Lưu ảnh vào phân loại đang chọn";
            this.barSave.Enabled = false;
            this.barSave.Id = 21;
            this.barSave.ImageIndex = 5;
            this.barSave.Name = "barSave";
            this.barSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSave_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Chế độ &xem";
            this.barSubItem3.Id = 20;
            this.barSubItem3.ImageIndex = 8;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Thumbnail),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSlipView),
            new DevExpress.XtraBars.LinkPersistInfo(this.barImageView)});
            this.barSubItem3.Name = "barSubItem3";
            this.barSubItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // Thumbnail
            // 
            this.Thumbnail.Caption = "Th&umbnail";
            this.Thumbnail.Glyph = ((System.Drawing.Image)(resources.GetObject("Thumbnail.Glyph")));
            this.Thumbnail.Id = 3;
            this.Thumbnail.Name = "Thumbnail";
            this.Thumbnail.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.Thumbnail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Thumbnail_ItemClick);
            // 
            // barSlipView
            // 
            this.barSlipView.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.barSlipView.Appearance.Options.UseFont = true;
            this.barSlipView.Caption = "&Split";
            this.barSlipView.Glyph = ((System.Drawing.Image)(resources.GetObject("barSlipView.Glyph")));
            this.barSlipView.Id = 4;
            this.barSlipView.Name = "barSlipView";
            this.barSlipView.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barSlipView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSlipView_ItemClick);
            // 
            // barImageView
            // 
            this.barImageView.Caption = "&Image";
            this.barImageView.Glyph = ((System.Drawing.Image)(resources.GetObject("barImageView.Glyph")));
            this.barImageView.Id = 5;
            this.barImageView.Name = "barImageView";
            this.barImageView.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barImageView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barImageView_ItemClick);
            // 
            // barSlideShow
            // 
            this.barSlideShow.Caption = "Trình &diễn ảnh";
            this.barSlideShow.Id = 10;
            this.barSlideShow.ImageIndex = 2;
            this.barSlideShow.Name = "barSlideShow";
            this.barSlideShow.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barSlideShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSlideShow_ItemClick);
            // 
            // barButtonItemExitSlideShow
            // 
            this.barButtonItemExitSlideShow.Caption = "Đóng trình diễn ảnh";
            this.barButtonItemExitSlideShow.Id = 24;
            this.barButtonItemExitSlideShow.ImageIndex = 1;
            this.barButtonItemExitSlideShow.Name = "barButtonItemExitSlideShow";
            this.barButtonItemExitSlideShow.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemExitSlideShow.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemExitSlideShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemExitSlideShow_ItemClick);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 0);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(613, 29);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(833, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 497);
            this.barDockControlBottom.Size = new System.Drawing.Size(833, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 497);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(833, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 497);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "32px-Crystal_Clear_action_find.png");
            this.imageList2.Images.SetKeyName(1, "fwRemoveAll.png");
            this.imageList2.Images.SetKeyName(2, "slideshow.png");
            this.imageList2.Images.SetKeyName(3, "fwAddChild.png");
            this.imageList2.Images.SetKeyName(4, "fwAdd.png");
            this.imageList2.Images.SetKeyName(5, "fwChoice.png");
            this.imageList2.Images.SetKeyName(6, "fwFind.png");
            this.imageList2.Images.SetKeyName(7, "mnbCHinhHeThong.png");
            this.imageList2.Images.SetKeyName(8, "pl-transform.png");
            // 
            // barOpen
            // 
            this.barOpen.Id = 16;
            this.barOpen.Name = "barOpen";
            // 
            // barExit
            // 
            this.barExit.Id = 17;
            this.barExit.Name = "barExit";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Id = 18;
            this.barSubItem1.Name = "barSubItem1";
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
            this.navBarControl1.NavigationPaneOverflowPanelUseSmallImages = false;
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 216;
            this.navBarControl1.OptionsNavPane.ShowOverflowPanel = false;
            this.navBarControl1.OptionsNavPane.ShowSplitter = false;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.SideBar;
            this.navBarControl1.Size = new System.Drawing.Size(210, 497);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
            this.navBarControl1.SelectedLinkChanged += new DevExpress.XtraNavBar.ViewInfo.NavBarSelectedLinkChangedEventHandler(this.navBarControl1_SelectedLinkChanged);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Chọn phân loại ảnh";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.NavigationPaneVisible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "mnsExplorer.png");
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Location = new System.Drawing.Point(222, 475);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(628, 22);
            this.mainStatusStrip.TabIndex = 7;
            this.mainStatusStrip.Text = "statusStrip1";
            this.mainStatusStrip.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image files(*.bmp,*.jpeg,*.jpg,*.png,*.gif)|*.jpeg;*.bmp;*.jpg;*.png;*.gif";
            this.openFileDialog1.FilterIndex = 0;
            this.openFileDialog1.Multiselect = true;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(210, 0);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 497);
            this.splitterControl1.TabIndex = 11;
            this.splitterControl1.TabStop = false;
            // 
            // imageSplitContainer
            // 
            this.imageSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.imageSplitContainer.IsSplitterFixed = true;
            this.imageSplitContainer.Location = new System.Drawing.Point(2, 2);
            this.imageSplitContainer.Name = "imageSplitContainer";
            this.imageSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // imageSplitContainer.Panel1
            // 
            this.imageSplitContainer.Panel1.Controls.Add(this.viewerMain);
            this.imageSplitContainer.Panel1.Controls.Add(this.standaloneBarDockControl1);
            this.imageSplitContainer.Panel1.Controls.Add(this.navToolStrip);
            // 
            // imageSplitContainer.Panel2
            // 
            this.imageSplitContainer.Panel2.Controls.Add(this.crystalImageGridView1);
            this.imageSplitContainer.Panel2.Controls.Add(this.imageGridToolStrip);
            this.imageSplitContainer.Size = new System.Drawing.Size(613, 493);
            this.imageSplitContainer.SplitterDistance = 303;
            this.imageSplitContainer.TabIndex = 12;
            // 
            // viewerMain
            // 
            this.viewerMain.CenterImage = true;
            this.viewerMain.Color1 = System.Drawing.Color.White;
            this.viewerMain.Color2 = System.Drawing.Color.White;
            this.viewerMain.ColorAngle = 360F;
            this.viewerMain.CrystalImageCollector = null;
            this.viewerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewerMain.Image = null;
            this.viewerMain.ImageIndex = -1;
            this.viewerMain.ImageSizeMode = Attilan.Crystal.Controls.SizeMode.Scrollable;
            this.viewerMain.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            this.viewerMain.Location = new System.Drawing.Point(0, 29);
            this.viewerMain.Name = "viewerMain";
            this.viewerMain.ShowPanOnZoom = true;
            this.viewerMain.Size = new System.Drawing.Size(613, 249);
            crystalSlideShowOptions1.ImageIntervalTime = 2F;
            crystalSlideShowOptions1.IntervalImageHold = 3000;
            crystalSlideShowOptions1.RepeatMode = false;
            crystalSlideShowOptions1.ShuffleMode = false;
            crystalSlideShowOptions1.SlideEffect = Attilan.Crystal.Controls.SlideShowEffect.Cycle;
            this.viewerMain.SlideShowOptions = crystalSlideShowOptions1;
            this.viewerMain.TabIndex = 4;
            this.viewerMain.Text = "crystalPictureShow1";
            this.viewerMain.ToolTipText = "";
            this.viewerMain.UseThumbnailer = true;
            this.viewerMain.ZoomFactor = 1F;
            this.viewerMain.DoubleClick += new System.EventHandler(this.viewerMain_DoubleClick);
            // 
            // navToolStrip
            // 
            this.navToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.navToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripTrackBar,
            this.zoomComboBox,
            this.leftButton,
            this.rightButton,
            this.toolStripSeparator1,
            this.toolStripButtonPan,
            this.toolStripSeparator2,
            this.toolStripButtonCopy,
            this.toolStripButtonXoa,
            this.toolStripSeparator3,
            this.toolStripButtonRefresh});
            this.navToolStrip.Location = new System.Drawing.Point(0, 278);
            this.navToolStrip.Name = "navToolStrip";
            this.navToolStrip.Size = new System.Drawing.Size(613, 25);
            this.navToolStrip.TabIndex = 2;
            this.navToolStrip.Text = "toolStrip2";
            // 
            // zoomToolStripTrackBar
            // 
            this.zoomToolStripTrackBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.zoomToolStripTrackBar.Name = "zoomToolStripTrackBar";
            this.zoomToolStripTrackBar.Size = new System.Drawing.Size(150, 22);
            this.zoomToolStripTrackBar.Text = "crystalToolStripTrackBar1";
            // 
            // zoomComboBox
            // 
            this.zoomComboBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.zoomComboBox.Name = "zoomComboBox";
            this.zoomComboBox.Size = new System.Drawing.Size(75, 25);
            // 
            // leftButton
            // 
            this.leftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.leftButton.Image = ((System.Drawing.Image)(resources.GetObject("leftButton.Image")));
            this.leftButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(23, 22);
            this.leftButton.Text = "Ảnh trước";
            // 
            // rightButton
            // 
            this.rightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rightButton.Image = ((System.Drawing.Image)(resources.GetObject("rightButton.Image")));
            this.rightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(23, 22);
            this.rightButton.Text = "Ảnh sau";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonPan
            // 
            this.toolStripButtonPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPan.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPan.Image")));
            this.toolStripButtonPan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPan.Name = "toolStripButtonPan";
            this.toolStripButtonPan.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPan.Text = "toolStripButton1";
            this.toolStripButtonPan.ToolTipText = "Quét ảnh";
            this.toolStripButtonPan.Click += new System.EventHandler(this.toolStripButtonPan_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopy.Image")));
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCopy.Text = "toolStripButton2";
            this.toolStripButtonCopy.ToolTipText = "Lưu ảnh xuống đĩa";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click_1);
            // 
            // toolStripButtonXoa
            // 
            this.toolStripButtonXoa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonXoa.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonXoa.Image")));
            this.toolStripButtonXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonXoa.Name = "toolStripButtonXoa";
            this.toolStripButtonXoa.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonXoa.Text = "toolStripButton1";
            this.toolStripButtonXoa.ToolTipText = "Xóa ảnh";
            this.toolStripButtonXoa.Click += new System.EventHandler(this.toolStripButtonXoa_Click_1);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Enabled = false;
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // crystalImageGridView1
            // 
            this.crystalImageGridView1.AlphaBlendValue = 150;
            this.crystalImageGridView1.AutoScroll = true;
            this.crystalImageGridView1.AutoScrollMinSize = new System.Drawing.Size(11405, 370);
            this.crystalImageGridView1.BorderSplitMode = false;
            this.crystalImageGridView1.BorderState = Attilan.Crystal.Controls.CrystalBorderState.CrystalRoundedRectFilledBorder;
            this.crystalImageGridView1.BorderWidth = 6;
            this.crystalImageGridView1.CellBorderColor = System.Drawing.SystemColors.Desktop;
            this.crystalImageGridView1.CellMargin = 10;
            this.crystalImageGridView1.CellSelectedTextColor = System.Drawing.Color.White;
            this.crystalImageGridView1.CellSize = new System.Drawing.Size(370, 370);
            this.crystalImageGridView1.CellSplitColor = System.Drawing.Color.Black;
            this.crystalImageGridView1.CellTextColor = System.Drawing.Color.Black;
            this.crystalImageGridView1.Color1 = System.Drawing.Color.White;
            this.crystalImageGridView1.Color2 = System.Drawing.Color.White;
            this.crystalImageGridView1.ColorAngle = 90F;
            this.crystalImageGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalImageGridView1.FocusedImage = null;
            this.crystalImageGridView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crystalImageGridView1.ForeColor = System.Drawing.Color.White;
            crystalDesignCollector1.ImageFilter = null;
            crystalDesignCollector1.ImageLocation = null;
            crystalDesignCollector1.PersistThumbnails = true;
            crystalDesignCollector1.Thumbnailer = null;
            this.crystalImageGridView1.GridController = crystalDesignCollector1;
            this.crystalImageGridView1.GridImages = 3;
            this.crystalImageGridView1.GridMargin = 5;
            crystalHeaderStyle1.CollapsedImage = null;
            crystalHeaderStyle1.ExpandedImage = null;
            crystalHeaderStyle1.HeaderSize = new System.Drawing.Size(25, 25);
            this.crystalImageGridView1.HeaderStyle = crystalHeaderStyle1;
            this.crystalImageGridView1.ImageItemFilter = Attilan.Crystal.Controls.CrystalFilterType.AllImages;
            this.crystalImageGridView1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            this.crystalImageGridView1.Location = new System.Drawing.Point(0, 0);
            this.crystalImageGridView1.Name = "crystalImageGridView1";
            this.crystalImageGridView1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.crystalImageGridView1.RightMouseButtonClick = false;
            this.crystalImageGridView1.ShowHeaders = false;
            this.crystalImageGridView1.ShowText = true;
            this.crystalImageGridView1.ShowThumbnails = true;
            this.crystalImageGridView1.Size = new System.Drawing.Size(613, 161);
            this.crystalImageGridView1.TabIndex = 8;
            this.crystalImageGridView1.Text = "crystalImageGridView1";
            this.crystalImageGridView1.TextHeight = 19;
            this.crystalImageGridView1.TextMargin = 2;
            this.crystalImageGridView1.UseAlphaBlending = false;
            this.crystalImageGridView1.ZoomFactor = 1F;
            this.crystalImageGridView1.DoubleClick += new System.EventHandler(this.crystalImageGridView1_DoubleClick);
            // 
            // imageGridToolStrip
            // 
            this.imageGridToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.imageGridToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.imageGridToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thumbZoomToolStripTrackBar,
            this.toolStripButtonCopyThumb,
            this.toolStripButtonXoaThumb});
            this.imageGridToolStrip.Location = new System.Drawing.Point(0, 161);
            this.imageGridToolStrip.Name = "imageGridToolStrip";
            this.imageGridToolStrip.Size = new System.Drawing.Size(613, 25);
            this.imageGridToolStrip.TabIndex = 7;
            this.imageGridToolStrip.Text = "toolStrip1";
            // 
            // thumbZoomToolStripTrackBar
            // 
            this.thumbZoomToolStripTrackBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.thumbZoomToolStripTrackBar.Name = "thumbZoomToolStripTrackBar";
            this.thumbZoomToolStripTrackBar.Size = new System.Drawing.Size(150, 22);
            this.thumbZoomToolStripTrackBar.Text = "crystalToolStripTrackBar1";
            // 
            // toolStripButtonCopyThumb
            // 
            this.toolStripButtonCopyThumb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopyThumb.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopyThumb.Image")));
            this.toolStripButtonCopyThumb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopyThumb.Name = "toolStripButtonCopyThumb";
            this.toolStripButtonCopyThumb.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCopyThumb.Text = "toolStripButton1";
            this.toolStripButtonCopyThumb.ToolTipText = "Lưu ảnh xuống đĩa";
            this.toolStripButtonCopyThumb.Click += new System.EventHandler(this.toolStripButtonCopyThumb_Click_1);
            // 
            // toolStripButtonXoaThumb
            // 
            this.toolStripButtonXoaThumb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonXoaThumb.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonXoaThumb.Image")));
            this.toolStripButtonXoaThumb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonXoaThumb.Name = "toolStripButtonXoaThumb";
            this.toolStripButtonXoaThumb.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonXoaThumb.Text = "toolStripButton2";
            this.toolStripButtonXoaThumb.ToolTipText = "Xóa ảnh";
            this.toolStripButtonXoaThumb.Click += new System.EventHandler(this.toolStripButtonXoaThumb_Click_1);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.imageSplitContainer);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(216, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(617, 497);
            this.panelControl1.TabIndex = 13;
            // 
            // frmImageGallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 497);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.mainStatusStrip);
            this.Name = "frmImageGallery";
            this.Text = "Quản lý ảnh";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.imageSplitContainer.Panel1.ResumeLayout(false);
            this.imageSplitContainer.Panel1.PerformLayout();
            this.imageSplitContainer.Panel2.ResumeLayout(false);
            this.imageSplitContainer.Panel2.PerformLayout();
            this.imageSplitContainer.ResumeLayout(false);
            this.navToolStrip.ResumeLayout(false);
            this.navToolStrip.PerformLayout();
            this.imageGridToolStrip.ResumeLayout(false);
            this.imageGridToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarButtonItem barOpen;
        private DevExpress.XtraBars.BarButtonItem barExit;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem Thumbnail;
        private DevExpress.XtraBars.BarButtonItem barSlipView;
        private DevExpress.XtraBars.BarButtonItem barImageView;
        private DevExpress.XtraBars.BarButtonItem barSlideShow;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonOpen;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem barSave;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOpenfile;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExitSlideShow;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        protected DevExpress.XtraBars.Bar bar1;
        private System.Windows.Forms.SplitContainer imageSplitContainer;
        private Attilan.Crystal.Controls.CrystalPictureShow viewerMain;
        private System.Windows.Forms.ToolStrip navToolStrip;
        private Attilan.Crystal.Controls.CrystalToolStripTrackBar zoomToolStripTrackBar;
        private System.Windows.Forms.ToolStripComboBox zoomComboBox;
        private System.Windows.Forms.ToolStripButton leftButton;
        private System.Windows.Forms.ToolStripButton rightButton;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripButton toolStripButtonXoa;
        private Attilan.Crystal.Controls.CrystalImageGridView crystalImageGridView1;
        private System.Windows.Forms.ToolStrip imageGridToolStrip;
        private Attilan.Crystal.Controls.CrystalToolStripTrackBar thumbZoomToolStripTrackBar;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopyThumb;
        private System.Windows.Forms.ToolStripButton toolStripButtonXoaThumb;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private System.Windows.Forms.ImageList imageList2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;

    }
}