using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using DAO;
using ProtocolVN.Framework.Core;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DTO;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using ProtocolVN.App.Office;
using DevExpress.XtraNavBar;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using PermissionOfResource;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using System.Text;
using System.IO;
namespace office
{
    public partial class frmDocumentQL : XtraFormPL
    {
        #region Vùng đặt Static

        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmDocumentQL).FullName,
                "Quản lý tài liệu",
                ParentID, true,
                typeof(frmDocumentQL).FullName,
                true, IsSep, "mnbHSoUngVien.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến
        private DXErrorProvider Error;
        private DODocument do_TL;
        private DataSet gridDataSet, cardViewDataSet;
        private long loaiTaiLieu = 0;
        DataTable dt = new DataTable();
        #endregion

        #region Init from
        public frmDocumentQL()
        {
            InitializeComponent();
            TaiLieuPermission.I.Init();
            InitGrid();
            InitCardView();
            Error = new DXErrorProvider();
            InitData();

            #region Gán image cho icon và set ẩn hiện của các nút
            imageList2.Images.Add(FWImageDic.ADD_IMAGE20);
            imageList2.Images.Add(FWImageDic.DELETE_IMAGE20);
            imageList2.Images.Add(FWImageDic.EDIT_IMAGE20);
            imageList2.Images.Add(FWImageDic.SAVE_IMAGE20);
            imageList2.Images.Add(FWImageDic.NO_SAVE_IMAGE20);

            imageList2.Images.Add(ProtocolVN.Framework.Win.Properties.Resources.uol);
            imageList2.Images.Add(FWImageDic.VIEW_IMAGE20);
            imageList2.Images.Add(FWImageDic.FILTER_IMAGE20);

            barManager1.Images = imageList2;
            Them.ImageIndex = 0;
            Xoa.ImageIndex = 1;
            Sua.ImageIndex = 2;
            xem.ImageIndex = 6;
            barCheckItem2.ImageIndex = 10;
            Xoa.Enabled = false;
            Sua.Enabled = false;
            barButtonItemPhanQuyenTailieu.Glyph = ResourceMan.getImage20("lvmnbQuanLyHopDong.png");
            #endregion

            Load_TreeNhomTL();

            InitSaveQueryDialog();
        }

        private void InitGrid()
        {
            this.btnShowDKTK.Glyph = FWImageDic.FILTER_IMAGE20;
            gridViewDSCongviec.OptionsNavigation.AutoFocusNewRow = false;
            gridDSCongviec.EmbeddedNavigator.CreateControl();
            gridViewDSCongviec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.gridViewDSCongviec.OptionsView.ShowViewCaption = true;
            HelpGrid.MoveGroupTextPanelToTitle(this.gridViewDSCongviec, new string[] { gridViewDSCongviec.GroupPanelText.ToUpper() });
            XtraGridSupportExt.TextLeftColumn(CotTenTaiLieu, "NAME");
            CotTenTaiLieu.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            XtraGridSupportExt.TextLeftColumn(CotPhienBan, "PHIEN_BAN");
            XtraGridSupportExt.ComboboxGridColumn(CotNguoiCapNhat,
                DABase.getDatabase().LoadDataSet("SELECT * FROM  DM_NHAN_VIEN").Tables[0],
                "ID", "NAME", "NGUOI_CAP_NHAT");
            HelpGridColumn.CotPLTimeEdit(CotNgayCapNhat, "NGAY_CAP_NHAT", PLConst.FORMAT_DATE_STRING);
            XtraGridSupportExt.BitGridColumn(CotHienThi, "VISIBLE_BIT");
            CotHienThi.Visible = false;
            XtraGridSupportExt.TextLeftColumn(CotID, "ID");
            XtraGridSupportExt.TextLeftColumn(cot_luufile, "LUU_FILE");
            XtraGridSupportExt.TextLeftColumn(cot_mofile, "MO_FILE");
            lvGhi_chu.OptionsColumn.ReadOnly = true;
            repositoryItemButtonEdit2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(repositoryItemButtonEdit2_ButtonClick);
            repositoryItemMemoExEdit1.ReadOnly = true;
            repositoryItemMemoExEdit1.ScrollBars = ScrollBars.Both;
            repositoryItemPictureEdit1.SizeMode = PictureSizeMode.Squeeze;
            layoutView1.OptionsCustomization.AllowFilter = false;
            layoutView1.OptionsCustomization.AllowSort = false;
            repositoryItemMemoExEdit2.ReadOnly = true;
            repositoryItemMemoExEdit2.ScrollBars = ScrollBars.Both;
            Them.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(Them_ItemClick);
            Sua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(Sua_ItemClick);
            Xoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(Xoa_ItemClick);
            xem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(xem_ItemClick);
            rep_mofile.Click += new EventHandler(rep_mofile_Click);
            rep_luufile.Click += new EventHandler(rep_luu_file_Click);
            gridControlTaiLieu.MouseMove += new MouseEventHandler(gridControlTaiLieu_MouseMove);
            gridViewDSCongviec.OptionsBehavior.Editable = false;
        }
        private void InitData()
        {
            do_TL = DADocument.Instance.LoadAll(-2);
            gridDataSet = do_TL.DetailDataSet.Copy();
            gridDSCongviec.DataSource = gridDataSet.Tables[0];
        }
        private void frmQLTaiLieu_Load(object sender, EventArgs e)
        {
            layoutView1.Appearance.CardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            toolTip1.BackColor = Color.LightYellow;
            gridDSCongviec.Load += new EventHandler(gridDSCongviec_Load);
            //this.navBarControl1.LinkClicked += new NavBarLinkEventHandler(navBarControl1_LinkClicked);
            this.gridViewDSCongviec.DoubleClick += new EventHandler(gridViewDSCongviec_DoubleClick);
            this.gridViewDSCongviec.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewDSCongviec_FocusedRowChanged);
            //this.splitContainerControl1.Panel2.MinSize = 300;
            //this.splitContainerControl1.Panel2.Size=new System.Drawing.Size(583, 300);
            layoutView1.OptionsHeaderPanel.EnableCustomizeButton = false;
            treeListNhomTL.SetFocusedNode(treeListNhomTL.MoveFirst());
        }
        void gridDSCongviec_Load(object sender, EventArgs e)
        {
            gridViewDSCongviec.BestFitColumns();
        }
        private void Load_TreeNhomTL()
        {

            DataSet dsParent = TaiLieuPermission.I._LoadDataSetWithResGroupPermission(@"SELECT *
            FROM DM_LOAI_TAI_LIEU 
            WHERE VISIBLE_BIT = 'Y' and id != ID_ROOT", "DM_LOAI_TAI_LIEU", "ID");
            treeListNhomTL.ParentFieldName = "PARENT_ID";
            treeListNhomTL.KeyFieldName = "ID";
            if (dsParent != null && dsParent.Tables.Count > 0)
                treeListNhomTL.DataSource = dsParent.Tables[0];

            treeListNhomTL.FocusedNodeChanged += delegate(object treeList, FocusedNodeChangedEventArgs nodeChanged)
            {
                NodeChanged(nodeChanged);
            };

        }
        #endregion

        private void NodeChanged(FocusedNodeChangedEventArgs nodeChanged)
        {
            FWWaitingMsg msg = new FWWaitingMsg();
            loaiTaiLieu = HelpNumber.ParseInt64(nodeChanged.Node["ID"]);
            dt = DADocument.getDM_TAI_LIEU(loaiTaiLieu);
            gridDSCongviec.DataSource = dt;
            xem.Enabled = (gridDSCongviec.DataSource as DataTable).Rows.Count > 0;
            DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (r != null)
            {
                Load_gridview(HelpNumber.ParseInt64(r["ID"]));
            }
            else
                gridControlTaiLieu.DataSource = null;
            ButtonState(r);
            if (msg != null) msg.Finish();
            msg.Finish();
        }
        private void InitCardView()
        {
            XtraGridSupportExt.TextLeftColumn(lvTieuDe, "TIEU_DE");
            XtraGridSupportExt.TextLeftColumn(lvFile_dinh_kem, "TEN_FILE");
            XtraGridSupportExt.TextLeftColumn(lvNguoiCapNhat, "TEN_NGUOI_CN");
            XtraGridSupportExt.TextLeftColumn(lvNgayCapNhat, "NGAY_CAP_NHAT");
            HelpGridColumn.CotMemoExEdit(lvGhi_chu, "GHI_CHU");
            HelpGridColumn.CotTextLeft(lvSize, "SIZE");
            layoutView1.OptionsBehavior.AllowSwitchViewModes = true;
            layoutView1.OptionsBehavior.AllowExpandCollapse = true;
            layoutView1.OptionsView.ShowCardCaption = true;
        }

        #region Xử lý nút
        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn xóa tài liệu '" + r["NAME"].ToString() + "' này không!") == DialogResult.Yes)
            {
                try
                {
                    DADocument.Instance.Xoa_DM_TAI_LIEU(HelpNumber.ParseInt64(r["ID"]));
                    DADocument.Instance.Xoa_tap_tin_tai_lieu(HelpNumber.ParseInt64(r["ID"]));
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                    HelpSysLog.AddException(ex, "");
                }

                gridViewDSCongviec.DeleteSelectedRows();
                DataRow row = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
                if (row != null)
                    Load_gridview(HelpNumber.ParseInt64(row["ID"]));
                else
                    gridControlTaiLieu.DataSource = null;
            }
        }


        #endregion

        #region xử lý sự kiện

        private void Load_gridview(long ID_TaiLieu)
        {
            try
            {
                cardViewDataSet = HelpDB.getDatabase().LoadDataSet(string.Format(@"SELECT LTTT.ID,LTTT.TIEU_DE,LTTT.NOI_DUNG,
                    (SELECT NAME FROM DM_NHAN_VIEN WHERE ID = LTTT.NGUOI_CAP_NHAT) TEN_NGUOI_CN,
                    LTTT.TEN_FILE,LTTT.NGAY_CAP_NHAT,LTTT.GHI_CHU
                    FROM LUU_TRU_TAP_TIN LTTT 
                     WHERE LTTT.ID IN(SELECT TAP_TIN_ID FROM OBJECT_TAP_TIN WHERE TYPE_ID = 3 and OBJECT_ID = {0})", ID_TaiLieu));
                cardViewDataSet.Tables[0].Columns.Add("MO_FILE", typeof(Image));
                cardViewDataSet.Tables[0].Columns.Add("LUU_FILE", typeof(Image));
                cardViewDataSet.Tables[0].Columns.Add("SIZE", typeof(String));
                foreach (DataRow row in cardViewDataSet.Tables[0].Rows)
                {
                    row["MO_FILE"] = FWImageDic.VIEW_IMAGE20;
                    row["LUU_FILE"] = FWImageDic.SAVE_IMAGE20;
                    byte[] a = row["NOI_DUNG"] as byte[];
                    row["SIZE"] = HelpNumber.RoundDecimal(HelpNumber.ParseDecimal(a.Length) / 1024, 3).ToString();
                }
                gridControlTaiLieu.DataSource = cardViewDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "");
            }
        }

        private void rep_mofile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            try
            {
                DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
                DADocument.Instance.Open_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "");
            }
        }

        private void rep_luu_file_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            try
            {
                DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
                DADocument.Instance.Save_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "");
            }

        }
        void gridViewDSCongviec_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (r != null)
            {
                Load_gridview(HelpNumber.ParseInt64(r["ID"]));
                ButtonState(r);


            }
            else barButtonItemPhanQuyenTailieu.Enabled = false;
        }

        void gridViewDSCongviec_DoubleClick(object sender, EventArgs e)
        {
            DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (r != null)
            {
                frmAddFile frm = new frmAddFile(HelpNumber.ParseInt64(r["ID"]), null);
                HelpProtocolForm.ShowModalDialog(this, frm);
                Load_gridview(HelpNumber.ParseInt64(r["ID"]));
            }
        }


        private void gridControlTaiLieu_MouseMove(object sender, MouseEventArgs e)
        {
            LayoutViewHitInfo layouthit = layoutView1.CalcHitInfo(layoutView1.GridControl.PointToClient(Control.MousePosition));
            if (layouthit.Column != null)
            {
                if (layouthit.Column.Name == "cot_mofile")
                {
                    toolTip1.Show("Mở tập tin", this.MdiParent, MousePosition.X + 5, MousePosition.Y + 25, 500);
                }
                if (layouthit.Column.Name == "cot_luufile")
                {
                    toolTip1.Show("Lưu tập tin", this.MdiParent, MousePosition.X + 5, MousePosition.Y + 25, 500);
                }
            }
        }

        #endregion

        #region Xem,xoa,sua
        private void xem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (r != null)
            {
                frmAddFile frm = new frmAddFile(HelpNumber.ParseInt64(r["ID"]), null);
                HelpProtocolForm.ShowModalDialog(this, frm);
            }

        }
        private void Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddFile frm = new frmAddFile(-2, true);
            HelpProtocolForm.ShowModalDialog(this, frm);
            if (loaiTaiLieu != 0)
                gridDSCongviec.DataSource = DADocument.getDM_TAI_LIEU(loaiTaiLieu);
            else
                gridDSCongviec.DataSource = null;//DADocument.getDM_TAI_LIEU(-1);
            DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (r != null)
            {
                Load_gridview(HelpNumber.ParseInt64(r[PLConst.FIELD_ID]));
                ButtonState(r);
            }
        }

        private void Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Them.Enabled = true;
                DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
                if (r != null)
                {
                    //if (DADocument.check_exists_taptin_in_tailieu(HelpNumber.ParseInt64(r["ID"])))
                    //{
                    //    ErrorMsg.ShowBizRuleProblems("Tài liệu đã chứa tập tin, không thể xóa!", "Xóa hết các tập tin trước!", string.Empty);
                    //    return;
                    //}
                    if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn xóa tài liệu '" + r["NAME"].ToString() + "' ?") == DialogResult.Yes)
                    {
                        //DUYVT: Kiểm tra quyền xóa trên tài nguyên
                        //if (!LoaiTaiLieu_TaiLieu.I._checkPermissionRes(
                        //    HelpNumber.ParseInt64(r["ID"]), PERMISSION_RES.DELETE))
                        //{
                        //    HelpMsgBox.ShowNotificationMessage(
                        //        "Bạn không có quyền xóa trên tài nguyên này!");
                        //    return;
                        //}
                        //
                        if (DADocument.Instance.Xoa_DM_TAI_LIEU(HelpNumber.ParseInt64(r["ID"])) == false) return;
                        DADocument.Instance.Xoa_tap_tin_tai_lieu(HelpNumber.ParseInt64(r["ID"]));
                        gridViewDSCongviec.DeleteSelectedRows();
                        DataRow row = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
                        if (row == null)
                            gridControlTaiLieu.DataSource = null;
                        else
                            Load_gridview(HelpNumber.ParseInt64(row["ID"]));
                        ButtonState(row);
                    }
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }

        private void Sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (r != null)
            {
                int row_indexed = gridViewDSCongviec.FocusedRowHandle;
                //DUYET: Kiểm tra quyền cập nhật trên tài nguyên
                //if (!LoaiTaiLieu_TaiLieu.I._checkPermissionRes(
                //    HelpNumber.ParseInt64(r["NGUOI_CAP_NHAT"]), PERMISSION_RES.UPDATE))
                //{
                //    HelpMsgBox.ShowNotificationMessage(
                //        "Bạn không có quyền cập nhật trên tài nguyên này!");
                //    return;
                //}
                //
                frmAddFile frm = new frmAddFile(HelpNumber.ParseInt64(r["ID"]), false);
                frm.RefreshUpdate += new frmAddFile.RefreshData(frm_RefreshUpdate);
                HelpProtocolForm.ShowModalDialog(this, frm);
                //Load_gridview(HelpNumber.ParseInt64(r["ID"]));
                //if (loaiTaiLieu != 0)
                //    gridDSCongviec.DataSource = DADocument.getDM_TAI_LIEU(loaiTaiLieu);
                //else
                //    gridDSCongviec.DataSource = DADocument.getDM_TAI_LIEU(-1);
                //gridViewDSCongviec.SelectRow(row_indexed);
            }
        }

        void frm_RefreshUpdate(DODocument doDocument)
        {
            DataRow row = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            row["NAME"] = doDocument.NAME;
            row["PHIEN_BAN"] = doDocument.PHIEN_BAN;
            row["NGAY_CAP_NHAT"] = doDocument.NGAY_CAP_NHAT;
            row["NGUOI_CAP_NHAT"] = doDocument.NGUOI_CAP_NHAT;
            if (HelpNumber.ParseInt64(row["LOAI_TAI_LIEU_ID"]) != doDocument.LOAI_TAI_LIEU_ID)
            {
                TreeListNode node = treeListNhomTL.FindNodeByFieldValue("ID", doDocument.LOAI_TAI_LIEU_ID);
                int i = -1;
                if (node != null)
                {
                    node.Selected = true;
                    treeListNhomTL.FocusedNode = node;
                    DataTable view = gridDSCongviec.DataSource as DataTable;
                    DataRow[] arrRow = view.Select("1=1", "NAME ASC");
                    foreach (DataRow rowView in arrRow)
                    {
                        i++;
                        if (HelpNumber.ParseInt64(rowView["ID"]) == doDocument.ID)
                        {
                            gridViewDSCongviec.FocusedRowHandle = i;
                            gridViewDSCongviec.SelectRow(i);
                            break;
                        }
                    }

                }
            }

        }
        #endregion

        #region Khác

        private void ButtonState(DataRow r)
        {
            if (r == null)
            {
                Sua.Enabled = false;
                Xoa.Enabled = false;
                xem.Enabled = false;
                barButtonItemPhanQuyenTailieu.Enabled = false;
                return;
            }
            xem.Enabled = true;
            Sua.Enabled = true;
            Xoa.Enabled = true;
            barButtonItemPhanQuyenTailieu.Enabled = FrameworkParams.currentUser.username == "admin" ||
                   HelpNumber.ParseInt64(r["NGUOI_CAP_NHAT"]) == FrameworkParams.currentUser.employee_id;
        }
        #endregion

        private void InitSaveQueryDialog()
        {
            string con = "";
            if (TaiLieuPermission.I.IsPermission)
            {
                con = TaiLieuPermission.I._getPermissionResStrIDs(RES_PERMISSION_TYPE.READ);
                if (con != "") con = " ID IN (" + con + ") AND";
                else con = "1=-1 AND";
            }
            string view = @"SELECT * FROM DM_TAI_LIEU Where " + con + " 1=1";
            HelpControl.addSaveQueryDialog(this, this.barManager1, this.gridDSCongviec, this.gridViewDSCongviec._GetPLGUI(), view);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataRow row = gridViewDSCongviec.GetFocusedDataRow();
            if (row == null) return;
            DOResource resource = new DOResource(HelpNumber.ParseInt64(row["ID"]),
                HelpNumber.ParseInt64(row["LOAI_TAI_LIEU_ID"]), HelpNumber.ParseInt64(row["NGUOI_CAP_NHAT"]), DateTime.Parse(row["NGAY_CAP_NHAT"].ToString()));
            //frmPermissionEmployeeTaiLieuPopUp frm = new frmPermissionEmployeeTaiLieuPopUp(resoure);
            frmPermissionDataPopUp frm = new frmPermissionDataPopUp(TaiLieuPermission.I, resource);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        private void treeListNhomTL_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            if (treeListNhomTL.FocusedNode != null && treeListNhomTL.FocusedNode[treeListNhomTL.KeyFieldName].Equals(e.Node[treeListNhomTL.KeyFieldName]))
            {
                e.NodeImageIndex = 2;
            }
            else e.NodeImageIndex = 1;
        }


    }

}





