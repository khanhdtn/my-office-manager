using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using ProtocolVN.Framework.Core;
using DevExpress.XtraGrid.Views.BandedGrid;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using System.Data;
using DevExpress.XtraTreeList.Columns;
using office;

namespace ProtocolVN.App.Office
{
    public class AppCtrl
    {
        private static ImageList getImageList()
        {
            ImageList arrayImage = new ImageList();
            arrayImage.Images.Add("DOC", ResourceMan.getImage48("fwWord.jpg"));
            arrayImage.Images.Add("EXCEL", ResourceMan.getImage48("mnsExcel.png"));
            arrayImage.Images.Add("IMAGE", ResourceMan.getImage48("pic_image.jpg"));
            arrayImage.Images.Add("DATABASE", ResourceMan.getImage48("fwLock.jpg"));
            arrayImage.Images.Add("ZIP", ResourceMan.getImage48("pic_compress.jpg"));
            arrayImage.Images.Add("CHM", ResourceMan.getImage48("pic_pdf.jpg"));
            arrayImage.Images.Add("PDF", ResourceMan.getImage48("pic_pdf.jpg"));
            arrayImage.Images.Add("TXT", ResourceMan.getImage48("pic_txt.jpg"));
            arrayImage.Images.Add("DEFAULT", ResourceMan.getImage48("pic_macdinh.jpg"));

            return arrayImage;
        }
        public static Image mapToImage(String FileName)
        {
            ImageList imageList = getImageList();
            if (imageList.Images.Empty) return null;
            imageList.ImageSize = new Size(48, 48);
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            string[] M = FileName.Split('.');
            string typeFile = M[M.Length - 1].ToUpper();
            switch (typeFile)
            {
                case "DOC":
                case "DOCX":
                case "DOT":
                case "DOTM":
                case "DOCM":
                    return imageList.Images["DOC"];
                case "XLS":
                case "XLSX":
                    return imageList.Images["EXCEL"];
                case "GDB":
                case "MDF":
                case "MDB":
                case "ACCDB":
                    return imageList.Images["DATABASE"];
                case "BMP":
                case "GIF":
                case "PNG":
                case "JPG":
                    return imageList.Images["IMAGE"];
                case "ZIP":
                case "RAR":
                    return imageList.Images["ZIP"];
                case "PDF":
                    return imageList.Images["PDF"];
                case "CHM":
                    return imageList.Images["CHM"];
                case "TXT":
                    return imageList.Images["TXT"];
            }
            return imageList.Images["DEFAULT"];
        }
        //public static void ShowAdvBandsGridViewIndicator(AdvBandedGridView advGrid)
        //{
        //    advGrid.CustomDrawRowIndicator += delegate(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        //    {
        //        if (e.Info.IsRowIndicator)
        //        {
        //            int stt = e.RowHandle + 1;
        //            e.Info.DisplayText = stt.ToString();
        //        }
        //    };
        //}
        public static RepositoryItemRichTextEdit CotRichTextEit(GridColumn Column, string ColumnField)
        {
            HelpGridColumn.SetHorzAlignment(Column, DevExpress.Utils.HorzAlignment.Center);
            RepositoryItemRichTextEdit rich = new RepositoryItemRichTextEdit();
            rich.ReadOnly = true;
            rich.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf;
            rich.EncodingWebName = "utf-8";
            Column.ColumnEdit = rich;
            if (ColumnField != null)
            {
                Column.FieldName = ColumnField;
            }
            return (RepositoryItemRichTextEdit)Column.ColumnEdit;
        }
        public static void SetRichText(DevExpress.XtraRichEdit.RichEditControl rich, byte[] ByteValues, bool SetCaretAtLast)
        {
            if (ByteValues == null || ByteValues.Length == 0) return;
            string text = HelpByte.BytesToUTF8String(ByteValues);
            if (!text.Contains(@"{\rtf"))
            {
                rich.Document.HtmlText = text;
            }
            else
                rich.Document.RtfText = text;
            //if (SetCaretAtLast)
            // rich.Document.CaretPosition = rich.Document.Range.End;
        }
        public static void InitTreeChonNhanVien(ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice tree, bool? IsAdd, bool ShowEmail)
        {
            if (ShowEmail)
            {

                tree._Init("DEPARTMENT", "", "ID", "NAME", "PARENT_ID", "DM_NHAN_VIEN", IsAdd == true ? "VISIBLE_BIT='Y'" : "",
                                            "ID", "NAME", "DEPARTMENT_ID",
                                            new string[] { "NAME","EMAIL" }, new string[] { "Nhân viên","Email" },
                                            new TreeListColumnType[] { TreeListColumnType.TextType, TreeListColumnType.TextType }, "navNoiBaoHanh.png", "mnbKhachHangNhom.png", "mnbTTinKhachHang.png");
            }
            else
            {
                tree._Init("DEPARTMENT", "", "ID", "NAME", "PARENT_ID", "DM_NHAN_VIEN", IsAdd == true ? "VISIBLE_BIT='Y'" : "",
                                            "ID", "NAME", "DEPARTMENT_ID",
                                            new string[] { "NAME" }, new string[] { "Nhân Viên" },
                                            new TreeListColumnType[] { TreeListColumnType.TextType }, "navNoiBaoHanh.png", "mnbKhachHangNhom.png", "mnbTTinKhachHang.png");
            }
        }
        public static void InitTreeChonNhanVien(ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice tree, bool? IsAdd)
        {
            InitTreeChonNhanVien(tree, IsAdd, true);
        }
        public static DMTreeGroup InitTreeChonDienDan(PLDMTreeGroup tree, bool? IsAdd)
        {
            if (IsAdd == true)
            {
                tree.InitReadOnly("NAME", "V_DIEN_DAN_CHUYEN_MUC", null, "ID", "PARENT_ID",
               new string[] { "NAME" },
               new string[] { "Diễn đàn" });
            }
            else
            {

                tree.InitReadOnly("NAME", "V_DIEN_DAN_CHUYEN_MUC", null, "ID", "PARENT_ID",
                    new string[] { "NAME" },
                    new string[] { "Diễn đàn" });
            }
              string sql="";
            if (DienDanPermission.I.IsPermission==false)
            {
               sql= @"SELECT DD.ID,DD.NAME,DD.ID_CHA PARENT_ID,DD.ID_ROOT,DD.VISIBLE_BIT,'Y' IS_GROUP
                    FROM NHOM_DIEN_DAN DD WHERE DD.VISIBLE_BIT = 'Y'
                    UNION SELECT CM.ID,CM.NAME,CM.ID_NHOM_DIEN_DAN PARENT_ID,
                        (SELECT N.ID_ROOT FROM NHOM_DIEN_DAN N WHERE N.ID = CM.ID_NHOM_DIEN_DAN),
                        CM.VISIBLE_BIT,'N' IS_GROUP 
                    FROM CHUYEN_MUC CM WHERE CM.VISIBLE_BIT = 'Y'";
            }
            else
            {
                string nddids = DienDanPermission.I._getPermissionResGroupStrIDs(PermissionOfResource.RES_PERMISSION_TYPE.READ);
                string cmids = DienDanPermission.I._getPermissionResStrIDs(PermissionOfResource.RES_PERMISSION_TYPE.READ);
                if (nddids == "") nddids = "-1";
                if (cmids == "") cmids = "-1";
                sql = @"SELECT DD.ID,DD.NAME,DD.ID_CHA PARENT_ID,DD.ID_ROOT,DD.VISIBLE_BIT,'Y' IS_GROUP
                    FROM NHOM_DIEN_DAN DD WHERE DD.VISIBLE_BIT = 'Y' and (dd.id=dd.ID_ROOT or dd.id in (" + nddids+ @")
                    or dd.id in (select cmuc.ID_NHOM_DIEN_DAN from CHUYEN_MUC cmuc where cmuc.id in (" + cmids + @")))
                    UNION SELECT CM.ID,CM.NAME,CM.ID_NHOM_DIEN_DAN PARENT_ID,
                        (SELECT N.ID_ROOT FROM NHOM_DIEN_DAN N WHERE N.ID = CM.ID_NHOM_DIEN_DAN),
                        CM.VISIBLE_BIT,'N' IS_GROUP 
                    FROM CHUYEN_MUC CM WHERE CM.VISIBLE_BIT = 'Y' and cm.id in (" + cmids +")";
            }
            
            PopupContainerControl popup = tree.Controls["popupContainerControl1"] as PopupContainerControl;
            if (popup == null) return null;
            DMTreeGroup tr = popup.Controls["plGroupCatNew1"] as DMTreeGroup;
            if (tr == null) return null;
            foreach (TreeListColumn col in tr.TreeList_1.Columns)
            {
                col.OptionsColumn.AllowFocus = false;
            }
            tr.TreeList_1.DataSource= HelpDB.getDatabase().LoadDataSet(sql,"DIEN_DAN").Tables[0];

            DataTable dt = tr.TreeList_1.DataSource as DataTable;
            dt.DefaultView.Sort = "IS_GROUP DESC ,NAME ASC";
            
            return tr;
        }
        public static void InitTreeChonNhanVien_Choice1(PLDMTreeGroup tree, bool? IsAdd)
        {
            if (IsAdd == true)
            {
                tree.InitReadOnly("NAME", "V_PHONG_BAN_NHAN_VIEN_VISBLE", null, "ID", "PARENT_ID",
               new string[] { "NAME" },
               new string[] { "Nhân viên" });
            }
            else
            {

                tree.InitReadOnly("NAME", "V_PHONG_BAN_NHAN_VIEN", null, "ID", "PARENT_ID",
                    new string[] { "NAME" },
                    new string[] { "Nhân viên" });
            }
            PopupContainerControl popup = tree.Controls["popupContainerControl1"] as PopupContainerControl;
            if (popup == null) return;
            DMTreeGroup tr = popup.Controls["plGroupCatNew1"] as DMTreeGroup;
            if (tr == null) return;
            foreach (TreeListColumn col in tr.TreeList_1.Columns)
            {
                col.OptionsColumn.AllowFocus = false;
            }

            int IndexGroupImage = -1;
            int IndexImage = -1;
            int IndexRootImage = -1;
            tr.TreeList_1.SelectImageList = null;
            DataTable dt = tr.TreeList_1.DataSource as DataTable;
            ImageCollection imList = new ImageCollection();
            imList.ImageSize = new Size(20, 20);
            dt.DefaultView.Sort = "IS_GROUP DESC ,NAME ASC";
            Image rimg = ResourceMan.getImage("navNoiBaoHanh.png");
            Image gimg = ResourceMan.getImage("mnbKhachHangNhom.png");
            Image img = ResourceMan.getImage("mnbTTinKhachHang.png");
            if (gimg != null || img != null || rimg != null)
            {
                IndexRootImage = imList.Images.Add(rimg, "navNoiBaoHanh.png");
                IndexGroupImage = imList.Images.Add(gimg, "mnbKhachHangNhom.png");
                IndexImage = imList.Images.Add(img, "mnbTTinKhachHang.png");
                tr.TreeList_1.StateImageList = imList;
            }
            else tr.TreeList_1.StateImageList = null;
            tr.TreeList_1.OptionsView.ShowIndicator = false;

            tr.TreeList_1.GetStateImage += delegate(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
            {
                if (e.Node.Level == 0)
                {

                    e.Node.StateImageIndex = IndexRootImage;
                }
                else
                {
                    if (e.Node["IS_GROUP"].ToString() == "Y")
                    {
                        e.Node.StateImageIndex = IndexGroupImage;
                    }
                    else e.Node.StateImageIndex = IndexImage;
                }
            };
            tr.TreeList_1.FocusedNodeChanged += delegate(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
            {

                if (e.Node["IS_GROUP"].ToString() == "Y")
                {
                    tr.btnAdd.Owner.Items["btnSelect"].Enabled = false;
                }
                else
                {
                    tr.btnAdd.Owner.Items["btnSelect"].Enabled = true;

                }
            };
            long selected = -1;

            tree.popupContainerEdit1.Popup += delegate(object sender, EventArgs e)
           {
               selected = tree._getSelectedID();
           };
            tree.popupContainerEdit1.QueryCloseUp += delegate(object sender, System.ComponentModel.CancelEventArgs e)
            {
                if (tr.SelectedNode != null)
                {
                    if (tr.SelectedNode["IS_GROUP"].ToString() == "Y")
                    {
                        e.Cancel = true;
                        DevExpress.XtraTreeList.Nodes.TreeListNode n = tr.TreeList_1.FindNodeByFieldValue("ID", selected);
                        //if (n != null)
                        tr.SelectedNode = n;
                        tree._setSelectedID(selected);
                    }
                }
            };
        }
        public static PLDataTree GetTreeList(PLDMTreeGroup tree)
        {
            PopupContainerControl popup = tree.Controls["popupContainerControl1"] as PopupContainerControl;
            if (popup == null) return null;            
            DMTreeGroup tr = popup.Controls["plGroupCatNew1"] as DMTreeGroup;
            if (tr == null) return null;
            return tr.TreeList_1;
        }

      

       

       

       
    }
}
