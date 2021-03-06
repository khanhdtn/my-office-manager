using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using DAO;
using ProtocolVN.Framework.Core;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using ProtocolVN.Framework.Win.Properties;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DTO;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using ProtocolVN.DanhMuc;
using ProtocolVN.App.Office;

namespace pl.office.form
{
    public partial class frmDocumentQL : XtraFormPL,IDuyetSupport
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NC;

        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmDocumentQL).FullName,
                PMSupport.UpdateTitle("Quản lý tài liệu", Status),
                ParentID, true,
                typeof(frmDocumentQL).FullName,
                true, IsSep, "mnbHSoUngVien.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến
        private DXErrorProvider Error;
        private DODocument do_TL;
        private DataSet gridDataSet;
        private bool _IsAdd;
        private long node_ID;
        DataTable dt = new DataTable();
        #endregion

        #region Init from
        public frmDocumentQL()
        {
            InitializeComponent();
            InitGrid();
            Error = new DXErrorProvider();
            InitData();

            #region gán image cho icon và set ẩn hiện của các nút
            imageList2.Images.Add(FWImageDic.ADD_IMAGE20);
            imageList2.Images.Add(FWImageDic.DELETE_IMAGE20);
            imageList2.Images.Add(FWImageDic.EDIT_IMAGE20);
            imageList2.Images.Add(FWImageDic.SAVE_IMAGE20);
            imageList2.Images.Add(FWImageDic.NO_SAVE_IMAGE20);

            imageList2.Images.Add(ProtocolVN.Framework.Win.Properties.Resources.uol);
            imageList2.Images.Add(FWImageDic.VIEW_IMAGE20);
            imageList2.Images.Add(FWImageDic.DUYET_IMAGE16);
            imageList2.Images.Add(FWImageDic.KHONG_DUYET_IMAGE16);
            imageList2.Images.Add(FWImageDic.FIND_IMAGE20);
            imageList2.Images.Add(FWImageDic.FILTER_IMAGE20);

            barManager1.Images = imageList2;
            Them.ImageIndex = 0;
            Xoa.ImageIndex = 1;
            Sua.ImageIndex = 2;
            xem.ImageIndex = 6;
            duyet.ImageIndex = 7;
            k_duyet.ImageIndex = 8;
            barbtTimKiem.ImageIndex = 9;
            barCheckItem2.ImageIndex = 10;
            Xoa.Enabled = false;
            Sua.Enabled = false;
            Them.Enabled = false;
            duyet.Enabled = false;
            k_duyet.Enabled = false;
            xem.Enabled = false;
            #endregion

            Load_tree();
        }

        private void InitGrid()
        {
            gridViewDSCongviec.OptionsNavigation.AutoFocusNewRow = false;
            gridDSCongviec.EmbeddedNavigator.CreateControl();
            gridViewDSCongviec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.gridViewDSCongviec.ViewCaption = gridViewDSCongviec.GroupPanelText;
            this.gridViewDSCongviec.OptionsView.ShowViewCaption = true;

            XtraGridSupportExt.TextLeftColumn(CotTenTaiLieu, "TEN_TAI_LIEU");
            XtraGridSupportExt.TextLeftColumn(CotPhienBan, "PHIEN_BAN");           
            XtraGridSupportExt.ComboboxGridColumn(CotNguoiCapNhat,
                DABase.getDatabase().LoadDataSet("Select * from  DM_NHAN_VIEN").Tables[0],
                "ID", "NAME", "NGUOI_CAP_NHAT");
            XtraGridSupportExt.DateTimeGridColumn(CotNgayCapNhat, "NGAY_CAP_NHAT");
            XtraGridSupportExt.BitGridColumn(CotHienThi, "VISIBLE_BIT");
            CotHienThi.Visible = false;
            XtraGridSupportExt.TextLeftColumn(CotID, "ID");
            XtraGridSupportExt.TextLeftColumn(cot_tinhtrang, "DUYET");
            XtraGridSupportExt.TextLeftColumn(cot_luu_file, "luu_file");
            XtraGridSupportExt.TextLeftColumn(colmofile, "mo_file");
            repositoryItemButtonEdit2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(repositoryItemButtonEdit2_ButtonClick);
            repositoryItemMemoExEdit1.ReadOnly = true;
            repositoryItemMemoExEdit1.ScrollBars = ScrollBars.Both;
            repositoryItemPictureEdit1.SizeMode = PictureSizeMode.Squeeze;
            layoutView1.OptionsCustomization.AllowFilter = false;
            layoutView1.OptionsCustomization.AllowSort = false;
            repositoryItemMemoExEdit2.ReadOnly = true;
            repositoryItemMemoExEdit2.ScrollBars = ScrollBars.Both;
            duyet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(duyet_ItemClick);
            k_duyet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(k_duyet_ItemClick);
            GridColumn col = new GridColumn();
            col.OptionsColumn.ReadOnly = true;
            gridViewDSCongviec.OptionsBehavior.Editable = false;
            XtraGridSupportExt.CreateDuyetGridColumn(col);
            this.gridViewDSCongviec.Columns.Add(col);
        }
        private void InitData()
        {
            popupControlContainer1.Show();       
            do_TL = DADocument.Instance.LoadAll(-2);
            gridDataSet = do_TL.DetailDataSet.Copy();          

            gridDSCongviec.DataSource = gridDataSet.Tables[0];
        }
        private void frmQLTaiLieu_Load(object sender, EventArgs e)
        {
            toolTip1.BackColor = Color.LightYellow;
            gridDSCongviec.Load += new EventHandler(gridDSCongviec_Load);
        }

        void gridDSCongviec_Load(object sender, EventArgs e)
        {
            gridViewDSCongviec.BestFitColumns();
        }
        public void Load_tree()
        {
            DataSet ds = DABase.getDatabase().LoadDataSet("select distinct PARENT_ID from DM_LOAI_TAI_LIEU");
            bool goc = true;
            TreeListNode parent = null;
            foreach (DataRow r in ds.Tables[0].Rows)
            {

                long PARENT_ID = HelpNumber.ParseInt64(r["PARENT_ID"]);
                if (PARENT_ID != 0)
                {
                    if (goc)
                    {
                        DataRow cha = DABase.getDatabase().LoadDataSet("select * from DM_LOAI_TAI_LIEU where ID=" + PARENT_ID).Tables[0].Rows[0];
                        parent = tree_LoaiTaiLieu.AppendNode(new object[] { cha["ID"], cha["NAME"].ToString() }, null);
                        parent.StateImageIndex = 0;
                        goc = false;
                    }
                    DataSet ds1 = DABase.getDatabase().LoadDataSet("select * from DM_LOAI_TAI_LIEU where PARENT_ID=" + PARENT_ID);
                    foreach (DataRow r1 in ds1.Tables[0].Rows)
                    {
                        tree_LoaiTaiLieu.AppendNode(new object[] { r1["ID"], r1["NAME"].ToString() }, parent).StateImageIndex = 0;
                    }
                }
                goc = true;

                tree_LoaiTaiLieu.ExpandAll();
            }

        }
        #endregion

        #region Xử lý nút
        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (int.Parse(r["DUYET"].ToString()) != 2)
            {
                if (PLMessageBox.ShowConfirmMessage("Bạn có muốn xóa tài liệu '" + r["TEN_TAI_LIEU"].ToString() + "' này không!") == DialogResult.Yes)
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
                        load_gridview(HelpNumber.ParseInt64(row["ID"]));
                    else
                        gridControlTaiLieu.DataSource = null;
                }
            }
        }


        #endregion

        #region xử lý sự kiện

        private void tree_LoaiTaiLieu_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            long id = HelpNumber.ParseInt64(e.Node["ID"]);
            node_ID = id;
            if (e.Node.Level != 0)
            {
                Them.Enabled = true;
                Xoa.Enabled = true;
                Sua.Enabled = true;
                xem.Enabled = true;
               
                dt = DADocument.getDM_TAI_LIEU(HelpNumber.ParseInt64(e.Node["ID"]));
                gridDSCongviec.DataSource = dt;               
                DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
                if (r != null)
                {
                    load_gridview(HelpNumber.ParseInt64(r["ID"]));
                }
                else
                    gridControlTaiLieu.DataSource = null;
            }
            else
            {
                duyet.Enabled = false;
                k_duyet.Enabled = false;
                Xoa.Enabled = true;
                Sua.Enabled = true;
                xem.Enabled = true;
                Them.Enabled = true;
                dt = DADocument.getDM_TAI_LIEU(1);
                gridDSCongviec.DataSource = dt;
            }
            DataRow dr = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (dr != null)
            {
                load_gridview(HelpNumber.ParseInt64(dr["ID"]));
                ButtonState(dr);
                //if (HelpNumber.ParseInt32(dr["DUYET"]) == (int)DuyetSupportStatus.ChoDuyet)
                //{
                //    duyet.Enabled = true;
                //    k_duyet.Enabled = true;
                //}
                //else if (HelpNumber.ParseInt32(dr["DUYET"]) == (int)DuyetSupportStatus.Duyet)
                //{
                //    duyet.Enabled = false;
                //    k_duyet.Enabled = true;
                //}
                //else if (HelpNumber.ParseInt32(dr["DUYET"]) == (int)DuyetSupportStatus.KhongDuyet)
                //{
                //    duyet.Enabled = true;
                //    k_duyet.Enabled = false;
                //}
                //if (DADocument.check_exists_taptin_in_tailieu(HelpNumber.ParseInt64(dr["ID"])))
                //{
                //    Xoa.Enabled = false;
                //}

            }
        }

        private void load_gridview(long ID_TaiLieu)
        {
            try
            {
                if (imageList_layout.Images.Empty) return;
                DataSet ds = DABase.getDatabase().LoadDataSet("select * from LUU_TRU_TAP_TIN lttt where lttt.ID in(select TAP_TIN_ID from TAI_LIEU_TAP_TIN where TAI_LIEU_ID='" + ID_TaiLieu + "')");
                HelpGridColumn.CotTextLeft(colghichu, "GHI_CHU");
                HelpGridColumn.CotTextCenter(coltenfile, "TEN_FILE");
                HelpGridColumn.CotTextCenter(coltieude, "TIEU_DE");
                ds.Tables[0].Columns.Add("hinh_anh", typeof(Image));
                ds.Tables[0].Columns.Add("mo_file", typeof(Image));
                ds.Tables[0].Columns.Add("luu_file", typeof(Image));
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    r["hinh_anh"] = lay_anh(r["TEN_FILE"].ToString());
                    r["mo_file"] = imageList_layout.Images[0];
                    r["luu_file"] = imageList_layout.Images[1];

                }
                HelpGridColumn.CotTextCenter(colfile, "hinh_anh");
                gridControlTaiLieu.DataSource = ds.Tables[0];
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
        private void gridViewDSCongviec_DoubleClick(object sender, EventArgs e)
        {
            DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (r != null)
            {
                frmAddFile frm = new frmAddFile(HelpNumber.ParseInt64(r["ID"]), null);
                ProtocolForm.ShowModalDialog(this, frm);
                load_gridview(HelpNumber.ParseInt64(r["ID"]));
            }
        }

        private void gridViewDSCongviec_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (r != null)
            {
                load_gridview(HelpNumber.ParseInt64(r["ID"]));
                ButtonState(r);                
            }
        }
      
        private void duyet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] Selected_row = gridViewDSCongviec.GetSelectedRows();
            foreach (int i in Selected_row)
            {
                DataRow row = gridViewDSCongviec.GetDataRow(i);
                if (PLGUIUtil.IsDuyet(row[PLDBUtil.FIELD_DUYET]))
                {
                    PLMessageBox.ShowNotificationMessage("Tài liệu '" + row["TEN_TAI_LIEU"].ToString() + "' đã duyệt!");
                }
                else
                {

                    if (PLMessageBox.ShowConfirmMessage("Duyệt tài liệu '" + row["TEN_TAI_LIEU"].ToString() + "' ?") == System.Windows.Forms.DialogResult.Yes)
                    {                    
                       
                        if (DuyetAction(HelpNumber.ParseInt64(row["ID"]),FrameworkParams.currentUser.employee_id,DABase.getDatabase().GetSystemCurrentDateTime()))
                        {
                            row[PLDBUtil.FIELD_DUYET] = ((Int32)DuyetSupportStatus.Duyet).ToString();                            
                            ButtonState(row);
                        }
                    }
                }
            }
        }

        private void k_duyet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] Selected_row = gridViewDSCongviec.GetSelectedRows();
            foreach (int i in Selected_row)
            {
                DataRow row = gridViewDSCongviec.GetDataRow(i);
                if (PLMessageBox.ShowConfirmMessage("Không duyệt tài liệu '" + row["TEN_TAI_LIEU"].ToString() + "' ?") == System.Windows.Forms.DialogResult.Yes)
                {                   
                    if (KhongDuyetAction(HelpNumber.ParseInt64(row["ID"]),FrameworkParams.currentUser.employee_id,DABase.getDatabase().GetSystemCurrentDateTime()))
                    {
                        row[PLDBUtil.FIELD_DUYET] = ((Int32)DuyetSupportStatus.KhongDuyet).ToString();                       
                        ButtonState(row);
                    }
                }
            }
        }
        private void gridControlTaiLieu_MouseMove(object sender, MouseEventArgs e)
        {
            LayoutViewHitInfo layouthit = layoutView1.CalcHitInfo(layoutView1.GridControl.PointToClient(Control.MousePosition));
            if (layouthit.Column != null)
            {
                if (layouthit.Column.Name == "colmofile")
                {
                    toolTip1.Show("Mở tập tin", this.MdiParent, MousePosition.X + 5, MousePosition.Y + 25, 500);
                }
                if (layouthit.Column.Name == "cot_luu_file")
                {
                    toolTip1.Show("Lưu tập tin", this.MdiParent, MousePosition.X + 5, MousePosition.Y + 25, 500);
                }
            }
        }
        private void barbtTimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GUIValidation.TrimAllData(new object[] { txtTenTaiLieu });
            string str = @"SELECT * FROM DM_TAI_LIEU Where 1=1";
            QueryBuilder query = new QueryBuilder(str);
            query.addDuyet(PLDBUtil.FIELD_DUYET, DuyetSelect.layTrangThai());
            query.addLike("upper(TEN_TAI_LIEU)", txtTenTaiLieu.Text.ToUpper());
            if (node_ID != 1)
                query.addID("LOAI_TAI_LIEU_ID", node_ID);
            DataSet ds = DABase.getDatabase().LoadDataSet(query);
            gridDSCongviec.DataSource = ds.Tables[0];

        }

        private void barCheckItem2_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barCheckItem2.Checked)
            {
                popupControlContainer1.Show();
            }
            else
                popupControlContainer1.Hide();

        }
        #endregion

        #region Xem,xoa,sua
        private void xem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (r != null)
            {
                frmAddFile frm = new frmAddFile(HelpNumber.ParseInt64(r["ID"]), null);
                ProtocolForm.ShowModalDialog(this, frm);
            }

        }
        private void Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddFile frm = new frmAddFile(-2, true);
            ProtocolForm.ShowModalDialog(this, frm);
            if (node_ID != 0)
                gridDSCongviec.DataSource = DADocument.getDM_TAI_LIEU(node_ID);
            else
                gridDSCongviec.DataSource = DADocument.getDM_TAI_LIEU(-1);
            DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (r != null)
                load_gridview(HelpNumber.ParseInt64(r[PLDBUtil.FIELD_ID]));
        }

        private void Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Them.Enabled = true;
            DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (r != null)
            {
                if (DADocument.check_exists_taptin_in_tailieu(HelpNumber.ParseInt64(r["ID"])))
                {
                    ErrorMsg.ShowBizRuleProblems("Tài liệu đã chứa tập tin, không thể xóa!", "Xóa hết các tập tin trước!", string.Empty);
                    return;
                }
                if (PLMessageBox.ShowConfirmMessage("Bạn có chắc muốn xóa tài liệu '" + r["TEN_TAI_LIEU"].ToString() + "' ?") == DialogResult.Yes)
                {
                    DADocument.Instance.Xoa_DM_TAI_LIEU(HelpNumber.ParseInt64(r["ID"]));
                    DADocument.Instance.Xoa_tap_tin_tai_lieu(HelpNumber.ParseInt64(r["ID"]));
                    gridViewDSCongviec.DeleteSelectedRows();
                    DataRow row = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
                    if (row == null)
                        gridControlTaiLieu.DataSource = null;
                    if (row != null)
                        load_gridview(HelpNumber.ParseInt64(row["ID"]));
                }
            }
        }

        private void Sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow r = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (r != null)
            {
                int row_indexed = gridViewDSCongviec.FocusedRowHandle;
                frmAddFile frm = new frmAddFile(HelpNumber.ParseInt64(r["ID"]), false);
                ProtocolForm.ShowModalDialog(this, frm);
                load_gridview(HelpNumber.ParseInt64(r["ID"]));
                if (node_ID != 0)
                    gridDSCongviec.DataSource = DADocument.getDM_TAI_LIEU(node_ID);
                else
                    gridDSCongviec.DataSource = DADocument.getDM_TAI_LIEU(-1);
                gridViewDSCongviec.SelectRow(row_indexed);
            }
        }
        #endregion

        #region Khác
        private Image lay_anh(string tenfile)
        {
            return AppCtrl.mapToImage(tenfile);           
        }
        private void ButtonState(DataRow r)
        {
            if (PLGUIUtil.IsKhongDuyet(r[PLDBUtil.FIELD_DUYET]))
            {
                duyet.Enabled = true;
                k_duyet.Enabled = false;
                Sua.Enabled = true;
                Xoa.Enabled = true;
            }
            else if (PLGUIUtil.IsDuyet(r[PLDBUtil.FIELD_DUYET]))
            {
                duyet.Enabled = false;
                k_duyet.Enabled = true;
                Sua.Enabled = false;
                Xoa.Enabled = false;
            }
            else if (PLGUIUtil.IsChoDuyet(r[PLDBUtil.FIELD_DUYET]))
            {
                duyet.Enabled = true;
                k_duyet.Enabled = true;
                Sua.Enabled = true;
                Xoa.Enabled = true;
            }
            
        }
        #endregion

        #region IDuyetSupport Members

        public bool DuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            if (PLGUIUtil.UpdateDuyetPhieu("DM_TAI_LIEU", "ID", ID, NguoiDuyetID, NgayDuyet, DuyetSupportStatus.Duyet)) {
                return true;
            }
            return false;
        }

        public bool KhongDuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            if (PLGUIUtil.UpdateDuyetPhieu("DM_TAI_LIEU", "ID", ID, NguoiDuyetID, NgayDuyet, DuyetSupportStatus.KhongDuyet)) {
                return true;   
            }
            return false;
        }

        #endregion       
    }

}





