using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using Attilan.Crystal.Controls;
using System.Reflection;
using Attilan.Crystal.Tools;
using Copperfield.Windows.Forms.Native;
using DevExpress.XtraNavBar;
using System.IO;
using DTO;
using DAO;
using System.Drawing.Imaging;


namespace office
{
    //DATHQ :
  
    public partial class frmImageGallery : XtraFormPL,IFormRefresh
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmImageGallery).FullName,
                PMSupport.UpdateTitle("Quản lý ảnh", Status),
                ParentID, true,
                typeof(frmImageGallery).FullName,
                false, IsSep, "mnbCHinhHeThong.png", true, "", "");
        }
        #endregion

        #region Fields 

        /// <summary>
        /// Controller object that bundles the CrystalPictureShow and CrystalImageGridView controls together
        /// and provides the most common operations between them.
        /// </summary>
        private CrystalPictureShowController _picController = new CrystalPictureShowController();
        private Assembly _thisAssembly = null;
        private FormWindowState _oldWindowState;
        private Size _oldSize;
        private Point _oldLocation;
        private Orientation _oldOrientation;
        private bool _thumbCollapsed;
        private bool _imageCollapsed;
        private CrystalViewMode _oldViewMode;
        private DOLuuTruTapTin do_TT = null;
        private string Temp_Path = Path.GetTempPath() + @"Pic\";
        private DataSet Image_Dataset;                 
        private bool Import_from_file = false;
        private bool Is_db_image = false;
        private bool Is_file_image = false;
        private bool Is_SlideShow = false;
        private int indexSlideShow = 0;
        //Khoi tao cho navbar
        private NavBarItem itemSelect = new NavBarItem();
        private bool f_load = false;
        private NavBarItem itemCurrent;
        private Font fontCurrent;
        private Color colorCurrent;
        #endregion

        #region Các hàm khởi tạo 
        public frmImageGallery(long ID, bool? IsAdd)
        {
            InitializeComponent();
            PicturesPermission.I.Init();
            State_button(false);
            this.Load += new EventHandler(frmImageGallery_Load);
            this.viewerMain.SlideShowTerminated += new EventHandler(viewerMain_SlideShowTerminated);
        }

        
        void frmImageGallery_Load(object sender, EventArgs e)
        {
            _thisAssembly = Assembly.GetAssembly(typeof(frmImageGallery));
            // Uncomment this line to see the list of resources
            // within the assembly.
            //CrystalTools.DumpManifestResourceNames(_thisAssembly);
            System.IO.DirectoryInfo empty_dir = new System.IO.DirectoryInfo(Temp_Path + @"Empty_Image");
            if (!empty_dir.Exists) empty_dir.Create();
            imageGridToolStrip.Visible = false;
            InitController();
            //Load du lieu cho navbar
            Load_navbar();
            dockManager1.DockingOptions.ShowCloseButton = false;

        }
        public frmImageGallery() : this(-2, true) { }
      
        #endregion

        #region  Crystal Toolkit
        /// <summary>
        /// Creates thumbnail images and returns the path of directory.
        /// </summary>
        /// <param name="pathFolder"></param>
        private string CreateThumbnail(string locationSave,string pathFolder,string[] selectedFiles,bool isNotDBImage)
        {
            String interStr = pathFolder;
            String lowerStr = interStr.ToLower();
            int hashVal = lowerStr.GetHashCode();
            string thumbnailFolder = hashVal.ToString();

            StringBuilder thumbnailLocation = new StringBuilder(locationSave);
            thumbnailLocation.Append(@"\");
            thumbnailLocation.Append(thumbnailFolder);
            if (!Directory.Exists(thumbnailLocation.ToString())) Directory.CreateDirectory(thumbnailLocation.ToString());
            FileInfo[] fullFiles;
            DirectoryInfo fullDirectory;
            if (selectedFiles == null)
            {
                fullDirectory = new DirectoryInfo(pathFolder);
                fullFiles = fullDirectory.GetFiles();
                if (isNotDBImage)
                {
                    //Gets images in full image folder
                    List<FileInfo> listFullFiles = new List<FileInfo>(fullFiles);
                    //Gets images in thumbnail image folder
                    DirectoryInfo thumbnailDirectory = new DirectoryInfo(thumbnailLocation.ToString());
                    List<FileInfo> listThumbFiles = new List<FileInfo>(thumbnailDirectory.GetFiles());
                    //Deletes images in thumbnail image folder that not contain in full image folder
                    foreach (FileInfo item in listThumbFiles)
                    {
                        if (!listFullFiles.Exists(delegate(FileInfo e)
                        {
                            return string.Compare(e.Name, item.Name) == 0;
                        })) File.Delete(item.FullName);
                    }
                }
            }
            else {
                List<FileInfo> listFile = new List<FileInfo>();
                foreach (string file in selectedFiles)
                {
                    FileInfo newFile = new FileInfo(file);
                    listFile.Add(newFile);
                }
                fullFiles = listFile.ToArray();
            }

            if (_picController.IsCollectorEmpty())
                _picController.InitCollector(Temp_Path + @"Empty_Image", 0);
            try
            {
                foreach (FileInfo fiInfo in fullFiles)
                {
                    Application.DoEvents();
                    if (!IsFileImage(fiInfo.FullName)) continue;
                    ImageFormat imf = new ImageFormat(Guid.NewGuid());
                    imf=GetImageFormat(fiInfo.FullName);
                    if (fiInfo.FullName.Contains("Thumbs.db")) continue;
                    string thumbFullPath = _picController.Collector.Thumbnailer.GetThumbFullPath(fiInfo.Name,
                                                                    thumbnailLocation.ToString(),
                                                                    new Size(343, 364),imf);
                    if (File.Exists(thumbFullPath)) continue;
                    
                    using (Image fullImage = Image.FromFile(fiInfo.FullName))
                    {
                        Image thumbImage = _picController.Collector.Thumbnailer.Generate(fullImage, new System.Drawing.Size(343, 364));
                        thumbImage.Save(thumbFullPath, imf);
                        fullImage.Dispose();
                        thumbImage.Dispose();
                        thumbImage = null;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally {
                _picController.StopThumbnailer();
            }
            return thumbnailLocation.ToString();
        }

        private ImageFormat GetImageFormat(string fileName){
            ImageFormat imf = new ImageFormat(Guid.NewGuid());
            if (Path.GetExtension(fileName).ToLower().Equals(".bmp")) imf = ImageFormat.Bmp;
            else if (Path.GetExtension(fileName).ToLower().Equals(".gif")) imf = ImageFormat.Gif;
            else if (Path.GetExtension(fileName).ToLower().Equals(".jpg")) imf = ImageFormat.Jpeg;
            else if (Path.GetExtension(fileName).ToLower().Equals(".jpeg")) imf = ImageFormat.Jpeg;
            else if (Path.GetExtension(fileName).ToLower().Equals(".png")) imf = ImageFormat.Png;
            return imf;
        }

        private void barButtonOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            long phan_loaiID = HelpNumber.ParseInt64(itemSelect.Name);
            if (phan_loaiID != -1 && PicturesPermission.I._checkPermissionResGroup(phan_loaiID, PermissionOfResource.RES_PERMISSION_TYPE.CREATE) == false)
            {
                HelpMsgBox.ShowNotificationMessage("Bạn không có quyền thêm ảnh vào phân loại đang chọn!");
                return;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Import_from_file = false;
                Is_db_image = false;
                Is_file_image = false;
                toolStripButtonRefresh.Enabled = false;
                Application.DoEvents();
                WaitingMsg mes = new WaitingMsg();
                #region Modified region
                if (_picController.IsCollectorEmpty())
                    _picController.InitCollector(Temp_Path + @"Empty_Image", 0);
                else
                {
                    List<CrystalImageItem> List_1 = _picController.Collector.GridModel.CrystalImageList;
                    List<CrystalImageItem> List_2 = new List<CrystalImageItem>();
                    foreach (CrystalImageItem image in List_1)
                    {
                        if (image.ImageName == "Header") continue;
                        List_2.Add(image);
                    }
                    if (List_2.Count > 0)
                        _picController.Collector.RemoveImages(List_2);
                }
                _picController.SetNullImage();
                DirectoryInfo dir_temp = new DirectoryInfo(CreateThumbnail(Application.UserAppDataPath,folderBrowserDialog1.SelectedPath,null,true));
                FileInfo[] File_names = dir_temp.GetFiles();

                int i = File_names.Length;
                State_button(i > 0);
                if (itemSelect.Links.Count > 0 && i > 0)
                    barSave.Enabled = true;
                if (i == 0)
                {
                    HelpMsgBox.ShowNotificationMessage("Không có ảnh trong thư mục vừa chọn.");
                    if (itemSelect.Links.Count > 0)
                        Load_anh_theo_pLoai(itemSelect);
                }
                else
                {
                    foreach (FileInfo image_item in File_names)
                        _picController.Collector.AddNewModelImage(image_item.FullName);
                    _picController.Collector.SortCrystalList(CrystalSortType.ImageName, true, false);
                    CrystalImageItem theImage = _picController.Collector.GridModel[_picController.Collector.GridModel.NextNonHeaderIndex(0)];
                    _picController.ImageGridView.SelectImage(theImage);
                    _picController.CenterCurrentImage();
                    _picController.Collector.UpdateGrid();
                }

                #endregion
                mes.Finish();
            }
            
        }
        private void barButtonItemOpenfile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            long phan_loaiID = HelpNumber.ParseInt64(itemSelect.Name);
            if (phan_loaiID != -1 && PicturesPermission.I._checkPermissionResGroup(phan_loaiID, PermissionOfResource.RES_PERMISSION_TYPE.CREATE) == false)
            {
                HelpMsgBox.ShowNotificationMessage("Bạn không có quyền thêm ảnh vào phân loại đang chọn!");
                return;
            }
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                toolStripButtonRefresh.Enabled = false;
                Application.DoEvents();
                WaitingMsg msg = new WaitingMsg();
                Import_from_file = true;
                Is_db_image = false;
                Is_file_image = true;
                string[] File_names = openFileDialog1.FileNames;                
                try
                {
                    if (_picController.Collector == null)
                        _picController.InitCollector(Temp_Path + @"Empty_Image", 0);
                    else
                    {
                        List<CrystalImageItem> List_1 = _picController.Collector.GridModel.CrystalImageList;
                        List<CrystalImageItem> List_2 = new List<CrystalImageItem>();
                        foreach (CrystalImageItem image in List_1)
                        {                            
                            if (image.ImageName == "Header") continue;
                            List_2.Add(image);
                        }
                        if (List_2.Count > 0)
                            _picController.Collector.RemoveImages(List_2);
                    }
                    _picController.SetNullImage();
                    DirectoryInfo dir_temp = new DirectoryInfo(CreateThumbnail(Application.UserAppDataPath, Directory.GetCurrentDirectory() + "s", File_names,true));
                    //Gets images in full image folder
                    List<FileInfo> listFullFiles = new List<FileInfo>();
                    foreach (string item in File_names) listFullFiles.Add(new FileInfo(item));
                    //Gets images in thumbnail image folder
                    List<FileInfo> listThumbFiles = new List<FileInfo>(dir_temp.GetFiles());
                    //Deletes images in thumbnail image folder that not contain in full image folder
                    foreach (FileInfo item in listThumbFiles)
                    {
                        if (listFullFiles.Exists(delegate(FileInfo f)
                        {
                            return string.Compare(f.Name, item.Name) == 0;
                        })) _picController.Collector.AddNewModelImage(item.FullName);
                    }

                    if (_picController.Collector.GridModel.CrystalImageList.Count == 1)
                    {
                        _picController.SetNullImage();
                        navToolStrip.Enabled = false;
                        HelpMsgBox.ShowNotificationMessage("Thêm file không đúng định dạng!");
                        if (itemSelect.Links.Count >0 )
                            Load_anh_theo_pLoai(itemSelect);
                        else
                            State_button(false);                        
                        return;
                    }
                    navToolStrip.Enabled = true;
                    CrystalImageItem theImage = _picController.Collector.GridModel[_picController.Collector.GridModel.NextNonHeaderIndex(0)];
                    _picController.ImageGridView.SelectImage(theImage);
                    int i = _picController.Collector.GridModel.GetSelectedImageList().Count;
                    State_button(i > 0);                   
                    if (itemSelect.Links.Count >0 && i > 0)
                        barSave.Enabled = true;
                    msg.Finish();
                }
                catch (Exception ex) { HelpMsgBox.ShowConfirmMessage(ex.ToString()); }                     
            }
        }               
        private void barSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn lưu ảnh vào phân loại \"" + itemSelect.Caption.ToString() + "\" ?") == DialogResult.Yes)
            {
                Application.DoEvents();
                if (!Import_from_file)
                    ImageToDB(folderBrowserDialog1.SelectedPath);
                else if (Is_file_image)
                    ImageToDB(openFileDialog1.FileNames);
                else
                    ImageToDB(_picController.CurrentImage.ImageLocation);                
                //Load_anh_theo_pLoai(itemSelect);
                toolStripButtonRefresh.Enabled = true;
            }
          
        }        
        private void Origin_State()
        {
            _picController.InitNavButtons(leftButton, rightButton);
            _picController.InitZoomControls(zoomToolStripTrackBar, zoomComboBox);           

            _picController.CrystalImageDisplayed += new EventHandler(_picController_CrystalImageDisplayed);

            _picController.InitController(crystalImageGridView1,
                                        viewerMain,
                                        this);

            _picController.InitThumbZoomControls(thumbZoomToolStripTrackBar, imageGridToolStrip);
            _picController.InitTrackerControl();
        }
        /// <summary>
        /// Initializes the picture show controller object.
        /// This ties a bunch of miscelleaneous controls together:
        /// left/right toolbar buttons for navigation, combo box for zoom magnification,
        /// trackbar for magnification.
        /// Plus, the CrystalPictureShow and CrystalImageGridView objects!
        /// </summary>
        private void InitController()
        {
            Origin_State();
            _picController.CurrentViewMode = CrystalViewMode.SplitView;
            //_picController.InitCollector(string.Empty, 0);  // MyPictures folder default
       
        }
        void _picController_CrystalImageDisplayed(object sender, EventArgs e)
        {
            CrystalImageSelectEventArgs imageEventArgs = (CrystalImageSelectEventArgs)e;
            // do whatever you like with the selected image...
            // imageEventArgs.selectedImage;

            //if (_picController.CurrentViewMode == CrystalViewMode.ThumbView) {
            //    _picController.Collector.SelectImage(_picController.Collector.GridModel.CrystalImageList.IndexOf(imageEventArgs.selectedImage));                
            //    return;
            //}

            if (_picController.Collector.GridModel.CrystalImageList.IndexOf(imageEventArgs.selectedImage) == _picController.Collector.GridModel.FirstNonHeaderIndex())
                leftButton.Enabled = false;
            if (_picController.Collector.GridModel.CrystalImageList.IndexOf(imageEventArgs.selectedImage) == _picController.Collector.GridModel.LastNonHeaderIndex())
                rightButton.Enabled = false;
            
        }
        /// <summary>
        /// Allows the form to switch into a total thumbnail view.
        /// </summary>
        private void ShowThumbnailView()
        {
            this.imageSplitContainer.Panel1Collapsed = true;
            this.imageSplitContainer.Panel2Collapsed = false;
            imageGridToolStrip.Visible = true;

            crystalImageGridView1.Orientation = Orientation.Vertical;
            crystalImageGridView1.Focus();
            _picController.CurrentViewMode = CrystalViewMode.ThumbView;
            _picController.CenterCurrentImage();
        }
        /// <summary>
        /// Allows the form to have a split view between thumbnails and the selected image.
        /// </summary>
        private void ShowSplitView()
        {
            this.imageSplitContainer.Panel1Collapsed = false;
            this.imageSplitContainer.Panel2Collapsed = false;
            imageGridToolStrip.Visible = false;

            crystalImageGridView1.Orientation = Orientation.Horizontal;
            crystalImageGridView1.Focus();
            _picController.CurrentViewMode = CrystalViewMode.SplitView;
            _picController.CenterCurrentImage();
            Thumbnail.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
            barSlipView.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            barImageView.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
        }
        /// <summary>
        /// Allows the form to hide thumbnails and just show the selected image.
        /// </summary>
        private void ShowImageView()
        {
            this.imageSplitContainer.Panel1Collapsed = false;
            this.imageSplitContainer.Panel2Collapsed = true;
            imageGridToolStrip.Visible = false;

            viewerMain.Focus();
            _picController.CurrentViewMode = CrystalViewMode.ImageView;
            Thumbnail.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
            barSlipView.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
            barImageView.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
        }
        
        private void InvalidateWindow()
        {
            NativeMethods.RedrawWindow(this, RDW.FRAME | RDW.UPDATENOW | RDW.INVALIDATE | RDW.ALLCHILDREN);
        }
        /// <summary>
        /// Zooms the form into full screen mode by hiding the border, toolbars, and menus.
        /// </summary>
        private void FormZoomMode()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.mainStatusStrip.Visible = false;
            this.bar1.Visible = true;
            this.navToolStrip.Visible = false;            
            viewerMain.HideTooltip();
            viewerMain.ShowScrollBars(false);

            imageSplitContainer.Panel2Collapsed = true;
            _picController.FullScreenMode();           
        }

        /// <summary>
        /// Puts the form back into sizeable mode by showing the border, toolbars, and menus.
        /// </summary>
        private void SizableFormMode()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.bar1.Visible = true;
            this.navToolStrip.Visible = true;            
            viewerMain.ShowTooltip();
            viewerMain.ShowScrollBars(false);
        }
        /// <summary>
        /// Saves the current windows state in order to restore it after full screen or slideshow modes.
        /// </summary>
        private void SaveWindowState()
        {
            _oldWindowState = WindowState;
            _oldSize = this.Size;
            _oldLocation = this.Location;
            _oldOrientation = crystalImageGridView1.Orientation;

            _imageCollapsed = imageSplitContainer.Panel1Collapsed;
            _thumbCollapsed = imageSplitContainer.Panel2Collapsed;

            _oldViewMode = _picController.CurrentViewMode;
        }

        /// <summary>
        /// Restores the window state after full screen or slideshow modes.
        /// </summary>
        private void RestoreWindowState()
        {
            WindowState = _oldWindowState;
            this.Size = _oldSize;
            this.Location = _oldLocation;
            crystalImageGridView1.Orientation = _oldOrientation;

            imageSplitContainer.Panel1Collapsed = _imageCollapsed;
            imageSplitContainer.Panel2Collapsed = _thumbCollapsed;

            _picController.CurrentViewMode = _oldViewMode;          
            switch (_picController.CurrentViewMode)
            {
                case CrystalViewMode.ImageView:
                    ShowImageView();
                    break;
                case CrystalViewMode.SplitView:
                    ShowSplitView();
                    break;
                case CrystalViewMode.ThumbView:
                    ShowThumbnailView();
                    break;
            }
        }
        /// <summary>
        /// Starts a slideshow at a given index in the current collector.
        /// </summary>
        /// <param name="startIndex"></param>
        private void StartSlideShow(int startIndex)
        {
            Is_SlideShow = true;            
            if (!_picController.CanStartSlideShow())
                return;            
            if (startIndex < 0)
                startIndex = 0;
            #region SlideShow Options
            _picController.PictureShow.SlideShowOptions.ImageIntervalTime = 2F;
            _picController.PictureShow.SlideShowOptions.IntervalImageHold = 3000;
            _picController.PictureShow.SlideShowOptions.RepeatMode = true;
            _picController.PictureShow.SlideShowOptions.ShuffleMode = false;
            _picController.PictureShow.SlideShowOptions.SlideEffect = SlideShowEffect.Cycle;
            #endregion

            SaveWindowState();

            this.Visible = false;
            InvalidateWindow();

            FormZoomMode();

            // Start the slide show.
            // Note that you can start at any index within the current collector/model.
            try
            {
                _picController.StartSlideShow(startIndex);

                this.Visible = true;
                InvalidateWindow();
                viewerMain.Focus();
            }
            catch (Exception ex) { HelpMsgBox.ShowNotificationMessage(ex.ToString()); }
        }
        /// <summary>
        /// Handle the slide show terminated event.
        /// </summary>
        /// <param name="sender">Sender Object.</param>
        /// <param name="e">Event arguments.</param>      
        /// 
        void viewerMain_SlideShowTerminated(object sender, EventArgs e)
        {
            CrystalImageSelectEventArgs imageEvent = (CrystalImageSelectEventArgs)e;

            this.Visible = false;
            SizableFormMode();
            this.Visible = true;
            RestoreWindowState();

            // The SlideShow Terminated events tells us what image was last viewed in the
            // slideshow.  We take that image, select it in the CrystalImageGridView control,
            // then center it to make it obvious to the viewer.
            if (imageEvent.selectedImage != null)
            {
                _picController.ImageGridView.SelectImage(imageEvent.selectedImage);
                _picController.CenterCurrentImage();
            }           
        }
       
        private void SetupFullScreen()
        {
            SaveWindowState();

            this.Visible = false;          
            FormZoomMode();

            this.Visible = true;            
            viewerMain.Focus();
        }
        private void TerminateFullScreenMode()
        {        
            if (this.FormBorderStyle != FormBorderStyle.None)
                return;

            this.Visible = false;            

            SizableFormMode();
            this.Visible = true;
            RestoreWindowState();

            // Centers the currently selected image in the CrystalImageGridView control.
            _picController.CenterCurrentImage();           
        }
        /// <summary>
        /// Handles the full screen image viewing mode termination event.
        /// Note that this is different than the screen saver termination event.
        /// </summary>
        /// <param name="sender">Sender Object.</param>
        /// <param name="e">Event arguments.</param>
        private void viewerMain_FullScreenTerminated(object sender, EventArgs e)
        {
            TerminateFullScreenMode();
        }
        /// <summary>
        /// Handles the Crystal Image Double clicked event in CrystalImageGridView control.
        /// </summary>
        /// <param name="sender">Sender Object.</param>
        /// <param name="e">Event arguments.</param>  
        private void crystalImageGridView1_DoubleClick(object sender, EventArgs e)
        {
            ShowImageView();            
        }        
        /// <summary>
        /// Handles the double click event in the CrystalPictureShow control.
        /// </summary>
        /// <param name="sender">Sender Object.</param>
        /// <param name="e">Event arguments.</param>
        private void viewerMain_DoubleClick(object sender, EventArgs e)
        {
            if (_picController.CurrentViewMode == CrystalViewMode.SlideShowMode)
                return;

            // Double clicking on the image in the CrystalPictureShow control
            // flips back and forth between image view and split view.
            if (_picController.CurrentViewMode != CrystalViewMode.SplitView)
            {
                ShowSplitView();                
                _oldViewMode = CrystalViewMode.SplitView;
            }
            else
            {
                ShowImageView();
                _oldViewMode = CrystalViewMode.ImageView;
            }
        }                 
        /// <summary>
        /// Processes the command keys, looking for the Escape key.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {            
            if (msg.Msg == (int)WindowsMessages.WM_KEYDOWN)
            {
                // We need to look for the ESC key pressed while the CrystalImageGridView
                // control is focused.  In case this control is active and full screen mode is
                // in effect, we need to terminate the full screen mode.
                switch ((int)keyData)
                {
                    case (int)Keys.Escape:                      
                        if (this.FormBorderStyle == FormBorderStyle.None)
                        {
                            TerminateFullScreenMode();
                            crystalImageGridView1.SelectImage(_picController.CurrentImage);
                            barButtonItemExitSlideShow.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            barSlideShow.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;                            
                            barSubItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;                            
                            return true;
                        }
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion        

        #region Các hàm chức năng khác 

        #region Image to DB 
        private void ImageToDB(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] Get_Files = dir.GetFiles();
            do_TT = DALuuTruTapTin.Instance.Load_For_Image(-2);
            DataSet GridDataset = do_TT.DetailDataset.Copy();
            long PL_ID = HelpNumber.ParseInt64(itemSelect.Name); 
            Load_Image_table(PL_ID);
            DataSet Ds_for_duplicated_image = Image_Dataset.Copy();
            GridDataset.Tables[0].Columns.Add("OBJECT_ID", Type.GetType("System.Int64"));
            DateTime Ngay_cap_nhat = HelpDB.getDatabase().GetSystemCurrentDateTime();
            long Nguoi_cap_nhat = FrameworkParams.currentUser.employee_id;
                                   
            WaitingMsg m = new WaitingMsg();
            foreach (FileInfo file in Get_Files)
            {                               
                //string Extension=Path.GetExtension(file.FullName).ToLower();
                //if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".gif" || Extension == ".bmp" || Extension == ".png")
                //{
                    DataRow row = GridDataset.Tables[0].NewRow();
                    row["ID"] = DABase.getDatabase().GetID("G_NGHIEP_VU");
                    row["TEN_FILE"] = file.Name;
                    row["NOI_DUNG"] = HelpByte.FileToBytes(path + @"\" + file.Name);
                    row["NGAY_CAP_NHAT"] = Ngay_cap_nhat;
                    row["NGUOI_CAP_NHAT"] = Nguoi_cap_nhat;
                    row["OBJECT_ID"] = PL_ID;
                    GridDataset.Tables[0].Rows.Add(row);
                    HelpDataSet.MergeDataSet(new string[] { "OBJECT_ID", "TEN_FILE" }, Ds_for_duplicated_image, GridDataset);
                    if (Ds_for_duplicated_image.Tables[0].Rows.Count == Image_Dataset.Tables[0].Rows.Count)//Duplicate image has just inserted.
                    {
                        m.Finish();
                        if (HelpMsgBox.ShowConfirmMessage("Ảnh '" + row["TEN_FILE"] + "' đã tồn tại." + Environment.NewLine + "Bạn có muốn ảnh này thay thế ảnh cũ không?") == DialogResult.Yes)
                        {
                            Application.DoEvents();
                            m = new WaitingMsg();
                            DataRow[] Task_row = Image_Dataset.Tables[0].Select("OBJECT_ID=" + PL_ID);
                            foreach (DataRow row_item in Task_row)
                            {
                                if (row_item["TEN_FILE"].ToString() == row["TEN_FILE"].ToString())
                                {
                                    //Delete duplicated image from DB
                                    DALuuTruTapTin.Instance.Delete(HelpNumber.ParseInt64(row_item["ID"]));
                                    //-------------------------------
                                    //Delete duplicated image from folder
                                    FileInfo fi = new FileInfo(Temp_Path + itemSelect.Caption.ToString() + @"\" + row_item["TEN_FILE"].ToString());
                                    fi.Delete();
                                    //-----------------------------------
                                    Image_Dataset.Tables[0].Rows.Remove(row_item);
                                    Image_Dataset.Tables[0].AcceptChanges();
                                    break;
                                }
                            }
                        }
                        else
                            GridDataset.Tables[0].Rows.Remove(row);
                    }                                    
                //}
            }
            if (GridDataset.Tables[0].Rows.Count > 0)
            {
                HelpDataSet.MergeDataSet(new string[] { "ID" }, do_TT.DetailDataset, GridDataset);
                HelpDataSet.MergeDataSet(new string[] { "ID" }, Image_Dataset, GridDataset);
                DALuuTruTapTin.Instance.UpdateDataset(do_TT);
                foreach (DataRow row in GridDataset.Tables[0].Rows)
                {
                    InsertTo_HINH_ANH_TAP_TIN(PL_ID, HelpNumber.ParseInt64(row["ID"]));
                }
            }
            if (m != null) m.Finish();
            Application.DoEvents();
            HelpMsgBox.ShowNotificationMessage("Lưu ảnh hoàn tất !");
            Application.DoEvents();
        }
        private void ImageToDB(string[] File_names)
        {
            do_TT = DALuuTruTapTin.Instance.Load_For_Image(-2);
            DataSet GridDataset = do_TT.DetailDataset.Copy();
            long PL_ID = HelpNumber.ParseInt64(itemSelect.Name);
            Load_Image_table(PL_ID);
            DataSet Ds_for_duplicated_image = Image_Dataset.Copy();
            GridDataset.Tables[0].Columns.Add("OBJECT_ID", Type.GetType("System.Int64"));
            DateTime Ngay_cap_nhat = HelpDB.getDatabase().GetSystemCurrentDateTime();
            long Nguoi_cap_nhat = FrameworkParams.currentUser.employee_id;
            
            WaitingMsg m = new WaitingMsg();
            foreach (string file in File_names)
            {
                //string Extension = Path.GetExtension(file).ToLower();
                //if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".gif" || Extension == ".bmp" || Extension == ".png")
                //{
                    DataRow row = GridDataset.Tables[0].NewRow();
                    row["ID"] = DABase.getDatabase().GetID("G_NGHIEP_VU");
                    row["TEN_FILE"] = Path.GetFileName(file);
                    row["NOI_DUNG"] = HelpByte.FileToBytes(file);
                    row["NGAY_CAP_NHAT"] = Ngay_cap_nhat;
                    row["NGUOI_CAP_NHAT"] = Nguoi_cap_nhat;
                    row["OBJECT_ID"] = PL_ID;
                    GridDataset.Tables[0].Rows.Add(row);
                    HelpDataSet.MergeDataSet(new string[] { "OBJECT_ID", "TEN_FILE" }, Ds_for_duplicated_image, GridDataset);
                    if (Ds_for_duplicated_image.Tables[0].Rows.Count == Image_Dataset.Tables[0].Rows.Count)//Duplicate image has just inserted.
                    {
                        m.Finish();
                        if (HelpMsgBox.ShowConfirmMessage("Ảnh '" + row["TEN_FILE"] + "' đã tồn tại." + Environment.NewLine + "Bạn có muốn ảnh này thay thế ảnh cũ không?") == DialogResult.Yes)
                        {
                            Application.DoEvents();
                            m = new WaitingMsg();
                            DataRow[] Task_row = Image_Dataset.Tables[0].Select("OBJECT_ID=" + PL_ID);
                            foreach (DataRow row_item in Task_row)
                            {
                                if (row_item["TEN_FILE"].ToString() == row["TEN_FILE"].ToString())
                                {
                                    //Delete duplicated image from DB
                                    DALuuTruTapTin.Instance.Delete(HelpNumber.ParseInt64(row_item["ID"]));
                                    //-------------------------------
                                    //Delete duplicated image from folder
                                    FileInfo fi = new FileInfo(Temp_Path + itemSelect.Caption.ToString() + @"\" + row_item["TEN_FILE"].ToString());
                                    fi.Delete();
                                    //-----------------------------------
                                    Image_Dataset.Tables[0].Rows.Remove(row_item);
                                    Image_Dataset.Tables[0].AcceptChanges();                                    
                                    break;
                                }
                            }
                        }
                        else
                            GridDataset.Tables[0].Rows.Remove(row); 
                    //}
                }
            }
            if (GridDataset.Tables[0].Rows.Count > 0)
            {
                HelpDataSet.MergeDataSet(new string[] { "ID" }, do_TT.DetailDataset, GridDataset);
                HelpDataSet.MergeDataSet(new string[] { "ID" }, Image_Dataset, GridDataset);
                DALuuTruTapTin.Instance.UpdateDataset(do_TT);
                foreach (DataRow row in GridDataset.Tables[0].Rows)
                {
                    InsertTo_HINH_ANH_TAP_TIN(PL_ID, HelpNumber.ParseInt64(row["ID"]));
                }
            }
            if (m != null) m.Finish();
            Application.DoEvents();
            HelpMsgBox.ShowNotificationMessage("Lưu ảnh hoàn tất!");
            Application.DoEvents();
        }
        private bool InsertTo_HINH_ANH_TAP_TIN(long Phan_Loai_ID, long Tap_tin_ID)
        {
            string sql = string.Format("INSERT INTO OBJECT_TAP_TIN VALUES({0},{1},4)", Tap_tin_ID, Phan_Loai_ID);
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql.ToString());
            return (db.ExecuteNonQuery(cmd) > 0);
        }
        #endregion
       
        #endregion

        #region Các xử lý sự kiện        
        //View Thumbnail    
        private void Thumbnail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowThumbnailView();
            Thumbnail.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            barSlipView.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
            barImageView.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
        }
        //View Slip
        private void barSlipView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowSplitView();
            Thumbnail.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
            barSlipView.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            barImageView.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
        }
        //View Image
        private void barImageView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowImageView();
            Thumbnail.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
            barSlipView.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
            barImageView.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
        }
        //View FullScreen
        private void barFullScreen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetupFullScreen();
        }
        //View SlideShow
        private void barSlideShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_picController.Collector!=null)
            {
                if (_picController.GetSelectedItemIndex() == -1) {
                    HelpMsgBox.ShowNotificationMessage("Không có ảnh để trình diễn!");
                    return;
                } 
                barButtonItemExitSlideShow.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
                barButtonItemExitSlideShow.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barSlideShow.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;                
                barSubItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                indexSlideShow = _picController.GetSelectedItemIndex();
                StartSlideShow(indexSlideShow);
            }
            else
                return;
        }
        private void barButtonItemExitSlideShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Windows.Forms.Message msg = new System.Windows.Forms.Message() ;
            msg.Msg = 256;
            ProcessCmdKey(ref msg, Keys.Escape);
            viewerMain.EndSlideShow(); 
                    
        }                              
        //Copy image 
        private void toolStripButtonCopy_Click_1(object sender, EventArgs e)
        {
            List<CrystalImageItem> list = _picController.Collector.GridModel.GetSelectedImageList();
            foreach (CrystalImageItem image in list)
            {
                if (image.ImageName == "Header")
                {
                    list.Remove(image);
                    break;
                }

            }
            FolderBrowserDialog f_browser = new FolderBrowserDialog();
            if (f_browser.ShowDialog() == DialogResult.OK)
            {
                CrystalFileCollector cf = new CrystalFileCollector();
                cf.FileOperateImages(list, f_browser.SelectedPath, ShellLib.ShellFileOperation.FileOperations.FO_COPY, IntPtr.Zero);
            }
        }                 
        //Delete image  
        private void toolStripButtonXoa_Click_1(object sender, EventArgs e)
        {
            List<CrystalImageItem> Selected_Image = _picController.Collector.GridModel.GetSelectedImageList();
            if (Selected_Image.Count == 0) {
                HelpMsgBox.ShowNotificationMessage("Vui lòng chọn ảnh cần xóa!");
                return;
            }
            
            if (!Is_db_image)
            {
                foreach (CrystalImageItem item in Selected_Image)
                {
                    _picController.Collector.GridModel.CrystalImageList.RemoveAt(_picController.Collector.GridModel.CrystalImageList.IndexOf(item));
                }
                _picController.Collector.UpdateGrid();
                List<CrystalImageItem> Current_Images = _picController.Collector.GridModel.CrystalImageList;
                if (Current_Images.Count == 0)
                {
                    _picController.SetNullImage();
                    State_button(false);
                    barSave.Enabled = false;
                }
                else if (Current_Images.Count == 1 && Current_Images[0].DisplayName == "Header")
                {
                    _picController.SetNullImage();
                    State_button(false);
                    barSave.Enabled = false;
                }
                else
                    _picController.Collector.SelectImage(_picController.Collector.GridModel.FirstNonHeaderIndex());
            }
            else
            {
                if (HelpMsgBox.ShowConfirmMessage("Xóa hình ảnh đang chọn ?") == DialogResult.Yes)
                {
                    long phan_loaiID = HelpNumber.ParseInt64(itemSelect.Name);
                    if (phan_loaiID != -1 && PicturesPermission.I._checkPermissionResGroup(phan_loaiID, PermissionOfResource.RES_PERMISSION_TYPE.DELETE) == false)
                    {
                        HelpMsgBox.ShowNotificationMessage("Bạn không có quyền xóa ảnh của phân loại đang chọn!");
                        return;
                    }
                    foreach (CrystalImageItem item in Selected_Image)
                    {
                        _picController.Collector.GridModel.CrystalImageList.RemoveAt(_picController.Collector.GridModel.CrystalImageList.IndexOf(item));
                    }
                    _picController.Collector.UpdateGrid();
                    List<CrystalImageItem> Current_Images = _picController.Collector.GridModel.CrystalImageList;
                    if (Current_Images.Count== 0)
                    {
                        _picController.SetNullImage();
                        State_button(false);
                        barSave.Enabled = false;
                    }
                    else if (Current_Images.Count == 1 && Current_Images[0].DisplayName == "Header")
                    {
                        _picController.SetNullImage();
                        State_button(false);
                        barSave.Enabled = false;
                    }
                    else
                        _picController.Collector.SelectImage(_picController.Collector.GridModel.FirstNonHeaderIndex());
                    StringBuilder Deleted_Images = new StringBuilder("");

                    DirectoryInfo dir_temp = new DirectoryInfo(Temp_Path + itemSelect.Caption.ToString());
                    String interStr = dir_temp.FullName;
                    String lowerStr = interStr.ToLower();
                    int hashVal = lowerStr.GetHashCode();
                    string thumbnailFolder = hashVal.ToString();

                    foreach (CrystalImageItem item in Selected_Image)
                    {
                        if (item.ImageName.Equals("Header")) continue;
                        Deleted_Images.Append("'" + item.ImageName + "',");
                        //Delete images in full folder
                        StringBuilder fileFullDelete = new StringBuilder(interStr);
                        fileFullDelete.Append(@"\" + item.ImageName);
                        File.Delete(fileFullDelete.ToString());
                        //Delete image in thumbnail folder
                        StringBuilder fileThumbnailDelete = new StringBuilder(Temp_Path);
                        fileThumbnailDelete.Append(@"\");
                        fileThumbnailDelete.Append(thumbnailFolder);
                        fileThumbnailDelete.Append(@"\" + item.ImageName);
                        File.Delete(fileThumbnailDelete.ToString());
                    }
                    Deleted_Images.Remove(Deleted_Images.Length - 1, 1);
                    string sql = string.Format(@"DELETE FROM LUU_TRU_TAP_TIN 
                        WHERE ID IN (SELECT TAP_TIN_ID
                            FROM OBJECT_TAP_TIN H INNER JOIN LUU_TRU_TAP_TIN L ON H.TAP_TIN_ID=L.ID
                                WHERE OBJECT_ID ={0} AND TYPE_ID = 4  AND UPPER(TEN_FILE) IN ({1}))", HelpNumber.ParseInt64(itemSelect.Name), Deleted_Images.ToString().ToUpper());
                    DatabaseFB db = HelpDB.getDatabase();
                    DbCommand cmd = db.GetSQLStringCommand(sql);
                    if (db.ExecuteNonQuery(cmd) < 0)
                        HelpMsgBox.ShowNotificationMessage("Xóa không thành công!");
                    toolStripButtonRefresh.Enabled = true;
                    //Load_Image_table(HelpNumber.ParseInt64(item_select.Name));
                }
            }
        }        
        public void Load_navbar()
        {
            QueryBuilder query = new QueryBuilder("SELECT * FROM DM_TM_HINH_ANH WHERE 1=1");
            query.addCondition("VISIBLE_BIT = 'Y'");
            DataSet ds1 = PicturesPermission.I._LoadDataSetWithResGroupPermission(query, "ID");
            this.navBarControl1.Items.Clear();
            foreach (DataRow r1 in ds1.Tables[0].Rows)
            {
                if (HelpNumber.ParseInt64(r1["ID_CHA"]) != 0)
                {
                    NavBarItem item1 = new NavBarItem();
                    item1.Caption = r1["NAME"].ToString();
                    item1.Name = r1["ID"].ToString();
                    item1.SmallImage = imageList1.Images[0];
                    item1.LargeImage = imageList1.Images[0];
                    navBarGroup1.ItemLinks.Add(item1);
                }                              
            }
            navBarGroup1.SelectedLinkIndex = -1;
            navBarGroup1.ItemLinks.SortByCaption();
            f_load = true;
        }

        private void toolStripButtonCopyThumb_Click_1(object sender, EventArgs e)
        {
            toolStripButtonCopy_Click_1(sender, e);            
        }
        private void toolStripButtonXoaThumb_Click_1(object sender, EventArgs e)
        {
            toolStripButtonXoa_Click_1(sender, e);
        }           
        private void navBarControl1_SelectedLinkChanged(object sender, DevExpress.XtraNavBar.ViewInfo.NavBarSelectedLinkChangedEventArgs e)
        {
            if (f_load)
            {
                if (navBarControl1.SelectedLink != null)
                {
                    if (itemCurrent != null)
                    {

                        itemCurrent.Appearance.Options.UseFont = false;
                        itemCurrent.Appearance.Options.UseForeColor = false;
                    }
                    NavBarItem itemNav = new NavBarItem();
                    itemNav = navBarControl1.SelectedLink.Item;
                    itemCurrent = itemNav;
                    fontCurrent = itemNav.Appearance.GetFont();
                    colorCurrent = itemNav.Appearance.GetForeColor();
                    //e.Link.State = DevExpress.Utils.Drawing.ObjectState.Selected;
                    itemNav.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
                    itemNav.Appearance.ForeColor = System.Drawing.Color.Navy;
                    itemNav.Appearance.Options.UseFont = true;
                    itemNav.Appearance.Options.UseForeColor = true;

                    //--------------------------------
                    if (Is_SlideShow)
                    {
                        System.Windows.Forms.Message msg = new System.Windows.Forms.Message();
                        msg.Msg = 256;
                        ProcessCmdKey(ref msg, Keys.Escape);
                        viewerMain.EndSlideShow();
                        Is_SlideShow = false;
                    }
                    WaitingMsg wMsg = new WaitingMsg();
                    Load_anh_theo_pLoai(itemNav);
                    Application.DoEvents();
                    wMsg.Finish();
                    //Lưu lại item đang select
                    itemSelect = e.Link.Item;
                    navBarControl1.SelectedLink = null;

                }
            }
        }

        private void toolStripButtonPan_Click(object sender, EventArgs e)
        {
            _picController.ShowTrackerOnZoom(!_picController.PictureShow.ShowPanOnZoom);
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            WaitingMsg ms = new WaitingMsg();
            LoadNewImages();
            toolStripButtonRefresh.Enabled = false;
            ms.Finish();
            
        }
        #endregion       

        #region ---Extension---
        /// <summary>
        /// Gets extension of a image file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsFileImage(string fileName)
        {
            string fileExt = Path.GetExtension(fileName);

            if (fileExt != string.Empty)
                fileExt = fileExt.Remove(0, 1);
            else
                return false;

            fileExt = fileExt.ToLower();

            if ((fileExt == "jpg") || (fileExt == "jpeg"))
                return true;
            else if ((fileExt == "png") || (fileExt == "bmp"))
                return true;
            else if ((fileExt == "bmp") || (fileExt == "gif"))
                return true;
           
            return false;
        }
        
        /// <summary>
        /// Gets images of OBJECT_ID
        /// </summary>
        /// <param name="ID_PHAN_LOAI"></param>
        private void Load_Image_table(long ID_PHAN_LOAI)
        {
            string Sql = string.Format(@"SELECT ID,TEN_FILE,NOI_DUNG,OBJECT_ID 
            FROM LUU_TRU_TAP_TIN L INNER JOIN OBJECT_TAP_TIN H ON L.ID=H.TAP_TIN_ID
            WHERE OBJECT_ID={0} AND TYPE_ID = 4", ID_PHAN_LOAI);
            DataSet ds = HelpDB.getDatabase().LoadDataSet(Sql);
            if (ds != null)
            {
                Image_Dataset = ds;
            }
        }
        /// <summary>
        /// Loads images based on selected item.
        /// </summary>
        /// <param name="item">Item that loaded</param>
        private void Load_anh_theo_pLoai(NavBarItem item)
        {
            _picController.SetNullImage();
            if (_picController.Collector == null)
                _picController.InitCollector(Temp_Path + @"Empty_Image", 0);
            else
            {
                List<CrystalImageItem> List_1 = _picController.Collector.GridModel.CrystalImageList;
                List<CrystalImageItem> List_2 = new List<CrystalImageItem>();
                foreach (CrystalImageItem image in List_1)
                {
                    if (image.ImageName == "Header") continue;
                    List_2.Add(image);
                }
                if (List_2.Count > 0)
                    _picController.Collector.RemoveImages(List_2);
            }
            barSave.Enabled = false;
            navToolStrip.Enabled = true;
            Is_db_image = true;
            DirectoryInfo dir_temp = new DirectoryInfo(Temp_Path + item.Caption.ToString());
            if (!dir_temp.Exists)
            {
                dir_temp.Create();
                Load_Image_table(HelpNumber.ParseInt64(item.Name));
                if (Image_Dataset == null)
                    return;
                DataRow[] T_row = Image_Dataset.Tables[0].Select("OBJECT_ID=" + HelpNumber.ParseInt64(item.Name));
                foreach (DataRow row in T_row)
                {
                    string pathNew = dir_temp.FullName + @"\" + row["TEN_FILE"].ToString();
                    File.WriteAllBytes(pathNew, (Byte[])row["NOI_DUNG"]);
                    //HelpByte.BytesToFile((Byte[])row["NOI_DUNG"], pathNew);
                }
                if (T_row.Length == 0)
                {
                    State_button(false);
                    return;
                }
            }
            DirectoryInfo dirThumbnail = new DirectoryInfo(CreateThumbnail(Temp_Path, dir_temp.FullName, null, true));
            FileInfo[] File_names = dirThumbnail.GetFiles();
            if (File_names.Length > 0)
            {
                foreach (System.IO.FileInfo image_item in File_names)
                {
                    if (image_item.FullName.Contains("Thumbs.db")) continue;
                    _picController.Collector.AddNewModelImage(image_item.FullName);
                }
                _picController.Collector.SortCrystalList(CrystalSortType.ImageName, true, false);
                CrystalImageItem theImage = _picController.Collector.GridModel[_picController.Collector.GridModel.NextNonHeaderIndex(0)];
                _picController.ImageGridView.SelectImage(theImage);
                _picController.CenterCurrentImage();
                State_button(true);
            }
            else
            {
                State_button(false);
                _picController.SetNullImage();
            }
            toolStripButtonRefresh.Enabled = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        private void Reload_image(string path)
        {
            Application.DoEvents();
            if (_picController.Collector != null)
                _picController.Collector.PurgeImages();
            _picController.Collector = null;
            _picController.InitCollector(path, 0);

        }
        /// <summary>
        /// Set "Enabled" property of buttons.
        /// </summary>
        /// <param name="state"></param>
        private void State_button(bool state)
        {
            if (leftButton.Enabled)
                leftButton.Enabled = state;
            rightButton.Enabled = state;
            if (!Is_db_image)
            {
                toolStripButtonCopy.Enabled = false;
                toolStripButtonCopyThumb.Enabled = false;
            }
            else
            {
                toolStripButtonCopy.Enabled = state;
                toolStripButtonCopyThumb.Enabled = state;
            }
            toolStripButtonXoa.Enabled = state;
            toolStripButtonPan.Enabled = state;
            toolStripButtonXoaThumb.Enabled = state;
        }
        /// <summary>
        /// Refreshs images between database and form.
        /// </summary>
        private void LoadNewImages()
        {
            _picController.SetNullImage();
            if (_picController.Collector == null)
                _picController.InitCollector(Temp_Path + @"Empty_Image", 0);
            else
            {
                List<CrystalImageItem> List_1 = _picController.Collector.GridModel.CrystalImageList;
                List<CrystalImageItem> List_2 = new List<CrystalImageItem>();
                foreach (CrystalImageItem image in List_1)
                {
                    if (image.ImageName == "Header") continue;
                    List_2.Add(image);
                }
                if (List_2.Count > 0)
                    _picController.Collector.RemoveImages(List_2);
            }
            DirectoryInfo dir_temp = new DirectoryInfo(Temp_Path + itemCurrent.Caption.ToString());

            if (dir_temp.Exists) dir_temp.Delete(true);

            dir_temp.Create();
            Load_Image_table(HelpNumber.ParseInt64(itemCurrent.Name));
            if (Image_Dataset == null)
                return;
            DataRow[] T_row = Image_Dataset.Tables[0].Select("OBJECT_ID=" + HelpNumber.ParseInt64(itemCurrent.Name));

            foreach (DataRow row in T_row)
            {
                string pathNew = dir_temp.FullName + @"\" + row["TEN_FILE"].ToString();
                File.WriteAllBytes(pathNew, (Byte[])row["NOI_DUNG"]);
            }
            if (T_row.Length == 0)
            {
                State_button(false);
                return;
            }

            DirectoryInfo dirThumbnail = new DirectoryInfo(CreateThumbnail(Temp_Path, dir_temp.FullName, null, false));
            FileInfo[] File_names = dirThumbnail.GetFiles();
            if (File_names.Length > 0)
            {
                foreach (FileInfo image_item in File_names)
                {
                    if (image_item.FullName.Contains("Thumbs.db")) continue;
                    _picController.Collector.AddNewModelImage(image_item.FullName);
                }

                _picController.Collector.SortCrystalList(CrystalSortType.ImageName, true, false);
                CrystalImageItem theImage = _picController.Collector.GridModel[_picController.Collector.GridModel.NextNonHeaderIndex(0)];
                _picController.ImageGridView.SelectImage(theImage);
                _picController.CenterCurrentImage();
                _picController.PictureShow.SetLayout(); ;
                State_button(true);
            }
            else
            {
                State_button(false);
                _picController.SetNullImage();
            }
        }


        #endregion


        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            Load_navbar();
            return null;
        }

        #endregion
    }
}