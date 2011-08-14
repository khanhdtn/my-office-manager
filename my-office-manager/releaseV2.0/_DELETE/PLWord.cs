using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon.Gallery;
using System.IO;
using DevExpress.Tutorials.Controls;
using DevExpress.Utils;

using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;

namespace ProtocolVN.Framework.Win.Trial
{
    //PHUOCNC Còn vấn đề trong việc dán mình để con trỏ vào nó dán thì ok
    //Nhưng mình để chỗ khác nó cũng dán vào chỗ này.
    public partial class PLWord : DevExpress.XtraEditors.XtraUserControl
    {
        public PLWord()
        {
            InitializeComponent();
            CreateColorPopup(popupControlContainer1);
            InitFontGallery();
            InitColorGallery();
            RightClickWord obj = HelpRichTextBox.RightClick(this.rtbData);
            obj.plword_item.Visibility = BarItemVisibility.Never;

            ribbonControl1.Minimized = true;
        }
        ColorPopup cp;
        frmFind dlgFind = null;
        frmReplace dlgReplace = null;
        GalleryItem fCurrentFontItem , fCurrentColorItem;
        string DocumentName = null;

        public RichTextBox CurrentRichText
        {
            set { this.rtbData = value; }
            get { return this.rtbData; }
        }

        private void CreateColorPopup(PopupControlContainer container)
        {
            //CHAUTV : Bị lỗi tại phương thức này nên đã thiết kế lớp ColorPopup mới
            cp = new ProtocolVN.Framework.Win.Trial.ColorPopup(container, iFontColor, this);
        }
        #region Init

     
        protected void InitFormat()
        {
            iBold.Enabled = SelectFont != null;
            iItalic.Enabled = SelectFont != null;
            iUnderline.Enabled = SelectFont != null;
            iFont.Enabled = SelectFont != null;
            iFontColor.Enabled = SelectFont != null;
            if (SelectFont != null)
            {
                iBold.Down = SelectFont.Bold;
                iItalic.Down = SelectFont.Italic;
                iUnderline.Down = SelectFont.Underline;
            }
            bool enabled = rtbData != null;
            iProtected.Enabled = enabled;
            iBullets.Enabled = enabled;
            iAlignLeft.Enabled = enabled;
            iAlignRight.Enabled = enabled;
            iCenter.Enabled = enabled;
            rgbiFont.Enabled = enabled;
            rgbiFontColor.Enabled = enabled;
            rpgFont.ShowCaptionButton = enabled;
            rpgFontColor.ShowCaptionButton = enabled;
            if (!enabled) ClearFormats();
            if (rtbData != null)
            {
                iProtected.Down = rtbData.SelectionProtected;
                iBullets.Down = rtbData.SelectionBullet;
                switch (rtbData.SelectionAlignment)
                {
                    case HorizontalAlignment.Left:
                        iAlignLeft.Down = true;
                        break;
                    case HorizontalAlignment.Center:
                        iCenter.Down = true;
                        break;
                    case HorizontalAlignment.Right:
                        iAlignRight.Down = true;
                        break;
                }
            }
        }

        void ClearFormats()
        {
            iBold.Down = false;
            iItalic.Down = false;
            iUnderline.Down = false;
            iProtected.Down = false;
            iBullets.Down = false;
            iAlignLeft.Down = false;
            iAlignRight.Down = false;
            iCenter.Down = false;
        }

        protected void InitPaste()
        {
            bool enabledPase = rtbData != null && rtbData.CanPaste(DataFormats.GetFormat(0));
            iPaste.Enabled = enabledPase;
        }

        void InitUndo()
        {
            iUndo.Enabled = rtbData.CanUndo;
            iLargeUndo.Enabled = iUndo.Enabled;
        }
        protected void InitEdit(bool enabled)
        {
            iCut.Enabled = enabled;
            iCopy.Enabled = enabled;
            iClear.Enabled = enabled;
            iSelectAll.Enabled =rtbData.CanSelect;
            InitUndo();
        }
        
        #endregion
        #region File
        void OpenFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Files (*.rtf)|*.rtf";
            dlg.Title = "Open";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                OpenFile(dlg.FileName);
            }
        }

        void OpenFile(string name)
        {
            rtbData.LoadFile(name);
        }

        void iOpen_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFile();
        }

        private void iPrint_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rtbData == null) return;
            StringReader streamToPrint = new StringReader(rtbData.Text);
            System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            PrintDialog dlg = new PrintDialog();
            dlg.Document = pd;
            if (dlg.ShowDialog() == DialogResult.OK)
                pd.Print();
        }
        void iSave_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DocumentName == null)
                SaveAs();
            else
                rtbData.SaveFile(DocumentName , RichTextBoxStreamType.RichText);
        }
        void iSaveAs_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveAs();
        }
        public string SaveAs()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Files (*.rtf)|*.rtf";
            dlg.Title = "Save As";
            if (dlg.ShowDialog() == DialogResult.OK)
                rtbData.SaveFile(dlg.FileName , RichTextBoxStreamType.RichText);
            DocumentName = dlg.FileName;
            return string.Empty;
        }
        private void ribbonPageGroup1_CaptionButtonClick(object sender , DevExpress.XtraBars.Ribbon.RibbonPageGroupEventArgs e)
        {
            OpenFile();
        }
        #endregion
        #region Format
        private FontStyle rtPadFontStyle()
        {
            FontStyle fs = new FontStyle();
            if (iBold.Down) fs |= FontStyle.Bold;
            if (iItalic.Down) fs |= FontStyle.Italic;
            if (iUnderline.Down) fs |= FontStyle.Underline;
            return fs;
        }

        private void iBullets_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtbData.SelectionBullet = iBullets.Down;
            InitUndo();
        }

        private void iFontStyle_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtbData.SelectionFont = new Font(SelectFont , rtPadFontStyle());
        }

        private void iProtected_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtbData.SelectionProtected = iProtected.Down;
        }

        private void iAlign_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rtbData == null) return;
            if (iAlignLeft.Down)
                rtbData.SelectionAlignment = HorizontalAlignment.Left;
            if (iCenter.Down)
                rtbData.SelectionAlignment = HorizontalAlignment.Center;
            if (iAlignRight.Down)
                rtbData.SelectionAlignment = HorizontalAlignment.Right;
            InitUndo();
        }


        protected Font SelectFont
        {
            get
            {
                    return rtbData.SelectionFont;
            }
        }
        void ShowFontDialog()
        {
            if (rtbData == null) return;
            Font dialogFont = null;
            if (SelectFont != null)
                dialogFont = (Font)SelectFont.Clone();
            else dialogFont = rtbData.Font;
            XtraFontDialog dlg = new XtraFontDialog(dialogFont);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                rtbData.SelectionFont = dlg.ResultFont;
                beiFontSize.EditValue = dlg.ResultFont.Size;
            }
        }
        private void iFont_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowFontDialog();
        }
        private void iFontColor_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtbData.SelectionColor = cp.ResultColor;
        }
        #endregion
        #region Edit
        private void iUndo_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtbData.Undo();
            rtbData.Modified = rtbData.CanUndo;
            InitUndo();
            InitFormat();
        }

        private void iCut_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtbData.Cut();
            InitPaste();
        }

        private void iCopy_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtbData.Copy();
            InitPaste();
        }

        private void iPaste_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtbData.Paste();
        }

        private void iClear_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtbData.Clear();
            rtbData.SelectedRtf = "";
        }

        private void iSelectAll_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rtbData.SelectAll();
        }
        private void ribbonPageGroup2_CaptionButtonClick(object sender , DevExpress.XtraBars.Ribbon.RibbonPageGroupEventArgs e)
        {
            pmMain.ShowPopup(ribbonControl1.Manager , MousePosition);
        }
        #endregion
        #region FontGallery
        Image GetFontImage(int width , int height , string fontName , int fontSize)
        {
            Rectangle rect = new Rectangle(0 , 0 , width , height);
            Image fontImage = new Bitmap(width , height);
            try
            {
                using (Font fontSample = new Font(fontName , fontSize))
                {
                    Graphics g = Graphics.FromImage(fontImage);
                    g.FillRectangle(Brushes.White , rect);
                    using (StringFormat fs = new StringFormat())
                    {
                        fs.Alignment = StringAlignment.Center;
                        fs.LineAlignment = StringAlignment.Center;
                        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                        g.DrawString("Aa" , fontSample , Brushes.Black , rect , fs);
                        g.Dispose();
                    }
                }
            }
            catch { }
            return fontImage;
        }
        void InitFont(GalleryItemGroup groupDropDown , GalleryItemGroup galleryGroup)
        {
            FontFamily[] fonts = FontFamily.Families;
            for (int i = 0 ; i < fonts.Length ; i++)
            {
                string fontName = fonts[i].Name;
                GalleryItem item = new GalleryItem();
                item.Caption = fontName;
                item.Image = GetFontImage(32 , 28 , fontName , 12);
                item.HoverImage = item.Image;
                item.Description = fontName;
                item.Hint = fontName;
                try
                {
                    item.Tag = new Font(fontName , 9);
                    if (DevExpress.Utils.ControlUtils.IsSymbolFont((Font)item.Tag))
                    {
                        item.Tag = new Font(DevExpress.Utils.AppearanceObject.DefaultFont.FontFamily , 9);
                        item.Description += " (Symbol Font)";
                    }
                }
                catch
                {
                    continue;
                }
                groupDropDown.Items.Add(item);
                galleryGroup.Items.Add(item);
            }
        }
        void InitFontGallery()
        {
            InitFont(gddFont.Gallery.Groups[0] , rgbiFont.Gallery.Groups[0]);
            beiFontSize.EditValue = 8;
        }
        void SetFont(string fontName , GalleryItem item)
        {
            if (rtbData == null) return;
            rtbData.SelectionFont = new Font(fontName , Convert.ToInt32(beiFontSize.EditValue) , rtPadFontStyle());
            if (item != null) CurrentFontItem = item;
        }
        private void gddFont_Gallery_ItemClick(object sender , DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            SetFont(e.Item.Caption , e.Item);
        }
        private void rpgFont_CaptionButtonClick(object sender , DevExpress.XtraBars.Ribbon.RibbonPageGroupEventArgs e)
        {
            ShowFontDialog();
        }
        private void rgbiFont_Gallery_ItemClick(object sender , DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            SetFont(e.Item.Caption , e.Item);
        }
        private void gddFont_Gallery_CustomDrawItemText(object sender , GalleryItemCustomDrawEventArgs e)
        {
            DevExpress.XtraBars.Ribbon.ViewInfo.GalleryItemViewInfo itemInfo = e.ItemInfo as DevExpress.XtraBars.Ribbon.ViewInfo.GalleryItemViewInfo;
            itemInfo.PaintAppearance.ItemDescription.DrawString(e.Cache , e.Item.Description , itemInfo.DescriptionBounds);
            AppearanceObject app = itemInfo.PaintAppearance.ItemCaption.Clone() as AppearanceObject;
            app.Font = (Font)e.Item.Tag;
            e.Cache.Graphics.DrawString(e.Item.Caption , app.Font , app.GetForeBrush(e.Cache) , itemInfo.CaptionBounds);
            e.Handled = true;
        }
        #endregion
        #region ColorGallery
        void InitColorGallery()
        {
            gddFontColor.BeginUpdate();
            foreach (Color color in DevExpress.XtraEditors.Popup.ColorListBoxViewInfo.WebColors)
            {
                if (color == Color.Transparent) continue;
                GalleryItem item = new GalleryItem();
                item.Caption = color.Name;
                item.Tag = color;
                item.Hint = color.Name;
                gddFontColor.Gallery.Groups[0].Items.Add(item);
                rgbiFontColor.Gallery.Groups[0].Items.Add(item);
            }
            foreach (Color color in DevExpress.XtraEditors.Popup.ColorListBoxViewInfo.SystemColors)
            {
                GalleryItem item = new GalleryItem();
                item.Caption = color.Name;
                item.Tag = color;
                gddFontColor.Gallery.Groups[1].Items.Add(item);
            }
            gddFontColor.EndUpdate();
        }
        private void gddFontColor_Gallery_CustomDrawItemImage(object sender , GalleryItemCustomDrawEventArgs e)
        {
            Color clr = (Color)e.Item.Tag;
            using (Brush brush = new SolidBrush(clr))
            {
                e.Cache.FillRectangle(brush , e.Bounds);
                e.Handled = true;
            }
        }
        void SetResultColor(Color color , GalleryItem item)
        {
            cp.ResultColor = color;
            rtbData.SelectionColor = cp.ResultColor;
            if (item != null) CurrentColorItem = item;
        }
        private void gddFontColor_Gallery_ItemClick(object sender , DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            SetResultColor((Color)e.Item.Tag , e.Item);
        }
        private void rpgFontColor_CaptionButtonClick(object sender , DevExpress.XtraBars.Ribbon.RibbonPageGroupEventArgs e)
        {
            if (cp == null)
                CreateColorPopup(popupControlContainer1);
            popupControlContainer1.ShowPopup(ribbonControl1.Manager , MousePosition);
        }

        private void rgbiFontColor_Gallery_ItemClick(object sender , DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            SetResultColor((Color)e.Item.Tag , e.Item);
        }
        #endregion
        #region GalleryItemsChecked

        GalleryItem GetColorItemByColor(Color color, BaseGallery gallery)
        {
            foreach (GalleryItemGroup galleryGroup in gallery.Groups)
                foreach (GalleryItem item in galleryGroup.Items)
                    if (item.Caption == color.Name)
                        return item;
            return null;
        }
        GalleryItem GetFontItemByFont(string fontName, BaseGallery gallery)
        {
            foreach (GalleryItemGroup galleryGroup in gallery.Groups)
                foreach (GalleryItem item in galleryGroup.Items)
                    if (item.Caption == fontName)
                        return item;
            return null;
        }
        GalleryItem CurrentFontItem
        {
            get { return fCurrentFontItem; }
            set
            {
                if (fCurrentFontItem == value) return;
                if (fCurrentFontItem != null) fCurrentFontItem.Checked = false;
                fCurrentFontItem = value;
                if (fCurrentFontItem != null)
                {
                    fCurrentFontItem.Checked = true;
                    MakeFontVisible(fCurrentFontItem);
                }
            }
        }
        void MakeFontVisible(GalleryItem item)
        {
            try
            {
                gddFont.Gallery.MakeVisible(fCurrentFontItem);
                rgbiFont.Gallery.MakeVisible(fCurrentFontItem);
            }
            catch
            {
                
            }
        }
        GalleryItem CurrentColorItem
        {
            get { return fCurrentColorItem; }
            set
            {
                if (fCurrentColorItem == value) return;
                if (fCurrentColorItem != null) fCurrentColorItem.Checked = false;
                fCurrentColorItem = value;
                if (fCurrentColorItem != null)
                {
                    fCurrentColorItem.Checked = true;
                    MakeColorVisible(fCurrentColorItem);
                }
            }
        }
        void MakeColorVisible(GalleryItem item)
        {
            try
            {
                gddFontColor.Gallery.MakeVisible(fCurrentColorItem);
                rgbiFontColor.Gallery.MakeVisible(fCurrentColorItem);
            }
            catch
            {
            }
        }
        void CurrentFontChanged()
        {
            if (rtbData == null || rtbData.SelectionFont == null) return;
            CurrentFontItem = GetFontItemByFont(rtbData.SelectionFont.Name, rgbiFont.Gallery);
            CurrentColorItem = GetColorItemByColor(rtbData.SelectionColor, rgbiFontColor.Gallery);
        }
        private void gddFont_Popup(object sender, System.EventArgs e)
        {
            MakeFontVisible(CurrentFontItem);
        }

        private void gddFontColor_Popup(object sender, System.EventArgs e)
        {
            MakeColorVisible(CurrentColorItem);
        }
        #endregion

        private void iFind_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dlgReplace != null) dlgReplace.Close();
            if (dlgFind != null) dlgFind.Close();
            dlgFind = new frmFind(rtbData , Bounds);
            ProtocolForm.ShowDialog((XtraForm)this.FindForm(), dlgFind);
        }
        private void iReplace_ItemClick(object sender , DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dlgReplace != null) dlgReplace.Close();
            if (dlgFind != null) dlgFind.Close();
            dlgReplace = new frmReplace(rtbData , Bounds);
            ProtocolForm.ShowDialog((XtraForm)this.FindForm(), dlgFind);
        }
        private void barInsertImage_ItemClick(object sender , ItemClickEventArgs e)
        {
            OpenFileDialog openfileImage = new OpenFileDialog();
            openfileImage.Filter = "Image Files(*.jpg,*.png,*.ico,*.bmp,*.gif)|*.jpg;*.png;*.ico;*.bmp;*.gif";
            openfileImage.Title = "Open";
            if (openfileImage.ShowDialog() == DialogResult.OK)
                LoadImage(openfileImage.FileName);
        }
        public void LoadImage(string fileName)
        {
            Bitmap myBitmap = new Bitmap(fileName);
            Clipboard.SetDataObject(myBitmap);
            DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
            if (rtbData.CanPaste(myFormat))
                rtbData.Paste(myFormat);
        }

        private void WordEditor_Load(object sender , EventArgs e)
        {
            ribbonControl1.ForceInitialize();
            ribbonPageCategory1.Visible = false;
            iCopy.Enabled = false;
            iCut.Enabled = false;
            InitFormat();
        }
        void OnLabelClicked(object sender , EventArgs e)
        {
            this.Refresh();
            OpenFile(sender.ToString());
        }

        private void barbtnSave_ItemClick(object sender , ItemClickEventArgs e)
        {
            if (DocumentName != null)
                rtbData.SaveFile(DocumentName);
            else
                SaveAs();
        }
        private void iBold_ItemClick(object sender , ItemClickEventArgs e)
        {
            rtbData.SelectionFont = new Font(SelectFont , rtPadFontStyle());
        }

        private void iItalic_ItemClick(object sender , ItemClickEventArgs e)
        {
            rtbData.SelectionFont = new Font(SelectFont , rtPadFontStyle());
        }

        private void iUnderline_ItemClick(object sender , ItemClickEventArgs e)
        {
            rtbData.SelectionFont = new Font(SelectFont , rtPadFontStyle());
        }

        private void iAlignLeft_ItemClick(object sender , ItemClickEventArgs e)
        {
            if (iAlignLeft.Down)
                rtbData.SelectionAlignment = HorizontalAlignment.Left;
            if (iCenter.Down)
                rtbData.SelectionAlignment = HorizontalAlignment.Center;
            if (iAlignRight.Down)
                rtbData.SelectionAlignment = HorizontalAlignment.Right;
            InitUndo();
        }

        private void iCenter_ItemClick(object sender , ItemClickEventArgs e)
        {
            if (iAlignLeft.Down)
                rtbData.SelectionAlignment = HorizontalAlignment.Left;
            if (iCenter.Down)
                rtbData.SelectionAlignment = HorizontalAlignment.Center;
            if (iAlignRight.Down)
                rtbData.SelectionAlignment = HorizontalAlignment.Right;
            InitUndo();
        }

        private void iAlignRight_ItemClick(object sender , ItemClickEventArgs e)
        {
            if (iAlignLeft.Down)
                rtbData.SelectionAlignment = HorizontalAlignment.Left;
            if (iCenter.Down)
                rtbData.SelectionAlignment = HorizontalAlignment.Center;
            if (iAlignRight.Down)
                rtbData.SelectionAlignment = HorizontalAlignment.Right;
            InitUndo();
        }

        private void ShowHideFormatCategory()
        {
            RibbonPageCategory selectionCategory = ribbonControl1.PageCategories[0] as RibbonPageCategory;
            if (selectionCategory == null) return;
            selectionCategory.Visible = rtbData.SelectionLength != 0;
            if (selectionCategory.Visible) 
                ribbonControl1.SelectedPage = selectionCategory.Pages[0];
        }
        private void richTextBox1_SelectionChanged(object sender , EventArgs e)
        {
            ShowHideFormatCategory();
            RichTextBox rtPad = sender as RichTextBox;
            InitFormat();
            int line = 0 , col = 0;

            if (rtPad != null)
            {
                InitEdit(rtPad.SelectionLength > 0);
                line = rtPad.GetLineFromCharIndex(rtPad.SelectionStart) + 1;
                col = rtPad.SelectionStart + 1;
            }
            else
            {
                InitEdit(false);
            }
            //siPosition.Caption = string.Format("   Line: {0}  Position: {1}   " , line , col);
            siPosition.Caption = string.Format("   Dòng: {0}  Cột: {1}   ", line, col);
            CurrentFontChanged();
        }

        private void richTextBox1_TextChanged(object sender , EventArgs e)
        {
            rtbData.Modified = true;
        }

        private void iLargeUndo_ItemClick(object sender , ItemClickEventArgs e)
        {
            rtbData.Undo();
            rtbData.Modified = rtbData.CanUndo;
            InitUndo();
            InitFormat();
        }


        #region Cách làm của Huy
        public byte[] _GetByteContent()
        {
            //HUY
            //return System.Text.Encoding.Unicode.GetBytes(richTextBox1.Rtf);
            //return HelpRichTextBox.GetData(this.rtbData);  

            //CHAUTV
            return System.Text.Encoding.UTF8.GetBytes(this.rtbData.Rtf);
        }
        
        //public void _get(object data)
        //{
        //    HelpRichTextBox.SetData(data, this.rtbData);
        //}

        public byte[] _get()
        {
            //HUY
            //return HelpRichTextBox.GetData(this.rtbData);   
            //CHAUTV
            return System.Text.Encoding.UTF8.GetBytes(this.rtbData.Rtf);
         
        }
        //HUY
        public void _set(byte[] byteContent)
        {
            //HUY
            //System.Text.UnicodeEncoding encoding = new UnicodeEncoding();
            //rtbData.Rtf = encoding.GetString(byteContent , 0 , Convert.ToInt32(byteContent.Length));            
            //CHAUTV
            this.rtbData.Rtf = System.Text.Encoding.UTF8.GetString(byteContent);
        }
        #endregion

        #region PHUOCNT NC Phần xử lý Template
        private void barQLMau_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTemplateQL ql = new frmTemplateQL();
            Form frm = this.FindForm();
            if(frm!=null && frm is XtraForm)
                ProtocolForm.ShowModalDialog((XtraForm)frm, ql);            
            else
                ProtocolForm.ShowModalDialog(FrameworkParams.MainForm, ql);
        }

        //PHUOCNT NC
        //Nạp danh sách nhóm mẫu
        //Nap danh sách mẫu
        //Gắn sự kiện để chọn nhóm mẫu thì sẽ nạp mẫu tương ứng
        private void InitChonMau()
        {

        }

        //PHUOCNT NC
        //Mở họp thoại cho phép xem mẫu đang chọn
        private void barXemTruoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            PLMessageBox.ShowNotificationMessage("Đang xây dựng");
        }

        //PHUOCNT NC
        //Thông báo có muốn lấy mẫu mới này ko 
        //OK nạp vào rtf đang soạn
        private void barChon_ItemClick(object sender, ItemClickEventArgs e)
        {
            PLMessageBox.ShowNotificationMessage("Đang xây dựng");
        }
        #endregion        
    }
}
