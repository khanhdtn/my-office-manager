using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DAO;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using ProtocolVN.DanhMuc;
using DTO;
using System.Drawing;

namespace pl.office.form
{

    public partial class frmDuAnQL : PhieuQuanLyChange1N
    {
        //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
        //public DevExpress.XtraBars.BarManager barManager1;
        //public DevExpress.XtraBars.Bar MainBar;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        //public DevExpress.XtraBars.BarDockControl barDockControlTop;
        //public DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //public DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //public DevExpress.XtraBars.BarDockControl barDockControlRight;
        //public DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        //public DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //public DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //public DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //public DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        //public DevExpress.XtraBars.BarSubItem barSubItem1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemXem;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        //public DevExpress.XtraBars.PopupMenu popupMenuFilter;
        //public DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //public DevExpress.XtraBars.PopupMenu popupMenu1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //public DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //public DevExpress.XtraGrid.GridControl gridControlMaster;
        //public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //#endregion

        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.FIX;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmDuAnQL).FullName,
                "Quản trị dự án",
                ParentID, true,
                typeof(frmDuAnQL).FullName,
                true, IsSep, "mnbToChuc.png", true, "", "");
        }
        private PhieuQuanLyFix1N Fix;
        DODuAn DO = null;
        DataSet GridDataSet = null;
        #endregion

        #region hàm khởi tạo
        public frmDuAnQL()
        {

            InitializeComponent();
            gridViewMaster.OptionsView.ShowGroupedColumns = false;
            gridViewMaster.OptionsView.ColumnAutoWidth = true;
            gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewThongTinLienHe.OptionsView.ShowGroupedColumns = false;
            IDField = "ID";
            DisplayField = "NAME";
            Fix = new PhieuQuanLyFix1N(this);
            this.splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            this.barButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            gridViewMaster.OptionsView.ShowGroupPanel = false;
            gridViewMaster.OptionsView.ShowFooter = true;
            toolTip1.BackColor=Color.LightYellow;
        }
        private void frmQLCongviecQL1N_Load(object sender, EventArgs e)
        {
            InitColumnMaster();          
            gridViewCongviec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridViewThongTinLienHe.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;            
            PLCtrl.ChonLoaiDuAn(LoaiDA);
            HelpDate.OneWeekAgo(Tungay, denngay);
            HelpDate.OneWeekAgo(KetThucTu, KetThucDen);          
            DMCMucDoUuTien.I.InitCtrl(mucuutien, true, false);
            PLCtrl.ChonTinhTrangDuAn(tintrang, false, true);
            //DMLoaiCongViec.I.InitCtrl(LoaiCV, false, null);
            tintrang._setSelectedID(-1);
            gridControlThongTinLienHe.Load += new EventHandler(gridControlThongTinLienHe_Load);
        }

        void gridControlThongTinLienHe_Load(object sender, EventArgs e)
        {
            gridViewThongTinLienHe.BestFitColumns();
        }


        #endregion

        #region Step 1 : Xác định các cột sẽ hiển thị trong gridView
        public override void InitColumnMaster()
        {
            HelpGridColumn.CotTextLeft(colTen_DA, "NAME");
            HelpGridColumn.CotTextLeft(colLoaiDA, "TEN_DA");
            HelpGridColumn.CotTextLeft(colNguoi_QL, "TEN_NGUOI_QL");
            HelpGridColumn.CotTextLeft(colT_trang, "TEN_TT");
            HelpGridColumn.CotTextLeft(colMuc_UT, "TEN_MUC");
            XtraGridSupportExt.DateTimeGridColumn(colNgay_BD_DA, "NGAY_BAT_DAU");
            XtraGridSupportExt.DateTimeGridColumn(colNgayKT_DA, "NGAY_KET_THUC");
            HelpGridColumn.CotTextCenter(codT_do_DA, "TIEN_DO");

        }
        #endregion

        #region Step 2 : Xác định các cột sẽ hiển thị trong phần detail
        public override void InitColumDetail()
        {
            gridViewThongTinLienHe.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewThongTinLienHe.OptionsView.ShowAutoFilterRow = false;
            HelpGridColumn.CotTextLeft(colCong_viec, "CONG_VIEC");          
            DACongViec.colMultiline(colNguoi_TH, "NV_THAM_GIA");
            HelpGridColumn.CotTextLeft(colLoaiCV, "TEN_LCV");
            HelpGridColumn.CotTextLeft(colDo_UT, "TEN_MUC_UU_TIEN");
            HelpGridColumn.CotTextLeft(colTinh_trang, "TINH_TRANG");
            HelpGridColumn.CotTextCenter(ColTien_Do, "TIEN_DO_THUC_HIEN");
            HelpGridColumn.CotTextLeft(colNguoi_giao, "TEN_NGUOI_GIAO");
            XtraGridSupportExt.DateTimeGridColumn(colNgay_bat_dau, "TU_NGAY");
            XtraGridSupportExt.DateTimeGridColumn(colNgay_ket_thuc, "DEN_NGAY");
            XtraGridSupportExt.TextCenterColumn(colTG_DT, "THOI_GIAN_DU_KIEN");
            HelpGridColumn.CotTextLeft(colghichu, "GHI_CHU");
            HelpGridColumn.CotTextCenter(coltenfile, "TEN_FILE");
            HelpGridColumn.CotTextCenter(coltieude, "TIEU_DE");           
            PMSupport.SetTitle(this, Status);
            HelpXtraForm.SetFix(this);          
            XtraGridSupportExt.TextLeftColumn(cot_luu_file, "luu_file");
            XtraGridSupportExt.TextLeftColumn(colmofile, "mo_file");         
            toolTip1.BackColor = Color.LightYellow;
            layoutView1.OptionsCustomization.AllowSort = false;
            layoutView1.OptionsCustomization.AllowFilter = false;
            

        }
        #endregion

        #region DataTable GridDetail
        public override DataTable[] PLLoadDataDetailParts(long MasterID)
        {
            DataTable dt = new DataTable();
            return new DataTable[] { dt };
        }
        #endregion

        #region Step 3 : Xác định các control trong filter part và Khởi tạo control trong phần filter.
        public override void PLLoadFilterPart()
        {            
        }
        #endregion

        #region Step 4 : Cài đặt menu
        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem menu = new _MenuItem(
                new string[] { "Thêm công việc", "Thêm tài liệu"},
                new string[] { "NVThem_CV", "NVThem_TL"},
                "ID",
                new DelegationLib.CallFunction_MulIn_NoOut[]{    
                    Them_Cong_Viec,Them_Tai_Lieu                    
               });
            return menu;    
        }
        private void Them_Cong_Viec(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);

                Congviec frm = new Congviec(-2, true);
                frm.UpdateCongViec += new Congviec.UpdateCongViecHandler(frm_UpdateCongViec);
                ProtocolForm.ShowModalDialog(this, frm);
                gridControlThongTinLienHe.DataSource=DADuAn.loadDetail(HelpNumber.ParseInt64(row["ID"]));
             
            }
        }
        public void frm_UpdateCongViec(object sender, long id_pccv)
        {
            DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            DADuAn.luu_duan_congviec(HelpNumber.ParseInt64(r["ID"]), id_pccv);
        }
        private void Them_Tai_Lieu(List <object>ids)
        {
            if (ids != null && ids.Count > 0)
            {
                DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);

                frmThemTaiLieu frm = new frmThemTaiLieu(-2, true, HelpNumber.ParseInt64(row["ID"]));
                frm.UpdateTapTin += new frmThemTaiLieu.UpdateTapTinHandler(frm_UpdateTapTin);
                ProtocolForm.ShowModalDialog(this, frm);
               load_gridview(HelpNumber.ParseInt64(row["ID"]));
                //Fix.PLRefresh();
            }
        }
        public void frm_UpdateTapTin(object sender, DOLuuTruTapTin doLuuTruTapTin)
        {
            DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            DADuAn.Instance.UpdateDATT(HelpNumber.ParseInt64(r["ID"]), doLuuTruTapTin.ID);
        }
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        #endregion

        #region Step 5 : Xây dựng Query Buider cho việc tìm kiếm
        public override QueryBuilder PLBuildQueryFilter()
        {

            string chuoi = @"Select ID,NAME,
                    (Select Name from dm_nhan_vien Nv where Nv.id=B.NGUOI_QUAN_LY) TEN_NGUOI_QL,
                    (Select Name from DM_LOAI_DU_AN Da where Da.id=B.LOAI_DU_AN) TEN_DA,
                    NGAY_BAT_DAU,NGAY_KET_THUC,
                    MUC_UU_TIEN,TIEN_DO,TINH_TRANG
                    from DU_AN B where 1=1";
            if (LoaiCV._getSelectedID() != -1 && LoaiCV._getSelectedID() != 0)
                chuoi = @"Select ID,NAME,
                    (Select Name from dm_nhan_vien Nv where Nv.id=B.NGUOI_QUAN_LY) TEN_NGUOI_QL,
                    (Select Name from DM_LOAI_DU_AN Da where Da.id=B.LOAI_DU_AN) TEN_DA,
                    NGAY_BAT_DAU,NGAY_KET_THUC,
                    MUC_UU_TIEN,TIEN_DO,TINH_TRANG
                    from DU_AN B where exists(SELECT * FROM CONG_VIEC_DU_AN cvda,phan_cong_cong_viec pccv  where B.ID=cvda.DU_AN_ID and cvda.PCCV_ID=pccv.pccv_id and pccv.lcv_id='" + LoaiCV._getSelectedID() + "') and 1=1";
            QueryBuilder query = new QueryBuilder(chuoi);

            query.addID("LOAI_DU_AN", LoaiDA._getSelectedID());
            query.addID("MUC_UU_TIEN", mucuutien._getSelectedID());
            query.addID("TINH_TRANG", tintrang._getSelectedID());
            query.addDateFromTo("NGAY_BAT_DAU", Tungay.DateTime, denngay.DateTime);
            query.addDateFromTo("NGAY_KET_THUC", KetThucTu.DateTime, KetThucTu.DateTime);
            GridDataSet = DABase.getDatabase().LoadDataSet(query,"griddataset");
            DataTable Bang_uu_tien = DAYeuCau.Bang_uu_tien_new();
            DataTable Bang_tinh_trang = DAYeuCau.Bang_tinh_trang_DA_new();
            GridDataSet.Tables.AddRange(new DataTable[] { Bang_uu_tien, Bang_tinh_trang });
            GridDataSet.Relations.Add("MUC_UU_TIEN",Bang_uu_tien.Columns["ID"],GridDataSet.Tables[0].Columns["MUC_UU_TIEN"]);
            GridDataSet.Tables[0].Columns.Add("TEN_MUC", Type.GetType("System.String"), "Parent(MUC_UU_TIEN).NAME");
            GridDataSet.Relations.Add("TEN_TINH_TRANG", Bang_tinh_trang.Columns["ID"], GridDataSet.Tables[0].Columns["TINH_TRANG"]);
            GridDataSet.Tables[0].Columns.Add("TEN_TT", Type.GetType("System.String"), "Parent(TEN_TINH_TRANG).NAME");
            gridControlMaster.DataSource = GridDataSet.Tables[0];
            return null;
        }
        #endregion

        #region Step 7 : Xác định các form xử lý khi chọn Thêm, Xem , Sửa

        public override void ShowViewForm(long id)
        {       
            frmDuAn f = new frmDuAn(id, null);
            ProtocolForm.ShowDialog(this,f);            
        }

        public override void ShowUpdateForm(long id)
        {           
            frmDuAn f = new frmDuAn(id, false);
            ProtocolForm.ShowModalDialog(this, f);
            gridControlThongTinLienHe.DataSource =DADuAn.loadDetail(id);
            load_gridview(id);
        }

        public override long[] ShowAddForm()
        {           
            frmDuAn frm = new frmDuAn();
            frm.refreshfrda+=new frmDuAn.refreshfrm(frm_refreshfrda);
            ProtocolForm.ShowModalDialog(this, frm);
            
            return null;
        }
        public void frm_refreshfrda()
        {
            Fix.PLRefresh();
        }
        #endregion

        #region Step 8 : Xác định các hành động trên form

        public override bool XoaAction(long id)
        {
            bool bRefresh = false;
            bRefresh = DADuAn.Instance.Delete(id);

            if (bRefresh == true)
            {
                Fix.PLRefresh();
                PLMessageBox.ShowNotificationMessage("Thao tác xóa thực hiện thành công");
            }
            return bRefresh;
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }
        #endregion     

        #region HookFocusRow
        public override void HookFocusRow()
        {
            DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            DataTable thongtin = new DataTable();
            thongtin =DADuAn.loadDetail(HelpNumber.ParseInt64(r["ID"]));
            gridControlThongTinLienHe.DataSource = thongtin;
            load_gridview(HelpNumber.ParseInt64(r["ID"]));
            if (DADuAn.exists_ds_congviec(HelpNumber.ParseInt64(r["ID"])) || DADuAn.exists_ds_tailieu(HelpNumber.ParseInt64(r["ID"])))
                barButtonItemDelete.Enabled = false;

            else
                barButtonItemDelete.Enabled = true;
            if(DADuAn.check_TrinhTrang_isHoanThanh(HelpNumber.ParseInt64(r["ID"])))
                 barButtonItemDelete.Enabled = true;
        }
        #endregion

        #region UpdateRow
        public override string UpdateRow()
        {

            string chuoi = @"Select ID,NAME,
                    (Select Name from dm_nhan_vien Nv where Nv.id=B.NGUOI_QUAN_LY) TEN_NGUOI_QL,
                    (Select Name from DM_LOAI_DU_AN Da where Da.id=B.LOAI_DU_AN) TEN_DA,
                    NGAY_BAT_DAU,NGAY_KET_THUC,
                    MUC_UU_TIEN,TIEN_DO,TINH_TRANG
                    from DU_AN B where 1=1";
            if (LoaiCV._getSelectedID() != -1 && LoaiCV._getSelectedID() != 0)
                chuoi = @"Select ID,NAME,
                    (Select Name from dm_nhan_vien Nv where Nv.id=B.NGUOI_QUAN_LY) TEN_NGUOI_QL,
                    (Select Name from DM_LOAI_DU_AN Da where Da.id=B.LOAI_DU_AN) TEN_DA,
                    NGAY_BAT_DAU,NGAY_KET_THUC,
                    MUC_UU_TIEN,TIEN_DO,TINH_TRANG
                    from DU_AN B where exists(SELECT * FROM CONG_VIEC_DU_AN cvda,phan_cong_cong_viec cv where B.ID=cvda.DU_AN_ID and cvda.PCCV_ID=cv.PCCV_ID and cv.LCV_ID='" + LoaiCV._getSelectedID() + "') and 1=1";
            return chuoi;
        }
        #endregion

        #region sự kiện

        private void gridControlThongTinLienHe_DoubleClick(object sender, EventArgs e)
        {
            DataRow r=gridViewThongTinLienHe.GetDataRow(gridViewThongTinLienHe.FocusedRowHandle);
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (r != null)
            {
                Congviec frm = new Congviec(HelpNumber.ParseInt64(r["pccv_id"]), false);
                frm.UpdateCongViec+=new Congviec.UpdateCongViecHandler(frm_UpdateCongViec);
                //frm.IsAdd = null;
                ProtocolForm.ShowModalDialog(this, frm);
                DADuAn.loadDetail(HelpNumber.ParseInt64(r["pccv_id"]));
            }
        }
        private void LoaiDA_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet ds = DABase.getDatabase().LoadDataSet("select distinct cvn.ID,cvn.NAME from PHAN_CONG_CONG_VIEC cv, CONG_VIEC_DU_AN cvda,DM_LOAI_CONG_VIECN cvn where cvda.DU_AN_ID in(select ID from DU_AN where LOAI_DU_AN='" + LoaiDA._getSelectedID() + "') and cvda.PCCV_ID=cv.PCCV_ID and cvn.ID=cv.LCV_ID");
            LoaiCV._init(ds.Tables[0],"NAME", "ID");
            

        }

        private void rep_mofile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Open_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
        }

        private void rep_luu_file_Click_1(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Save_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
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
       
        #endregion 

        #region button cập nhật tiến độ
        #endregion             

        #region duynpn
        

        private void gridControlTaiLieu_Click(object sender, EventArgs e)
        {

            DataRow r = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            if (r != null)
            {
                LayoutViewHitInfo gHitInfo = layoutView1.CalcHitInfo(layoutView1.GridControl.PointToClient(Control.MousePosition));
                if (gHitInfo.Column == null) return;   
                if (gHitInfo.Column.FieldName == "TEN_FILE")//Nếu cell được click thuộc _columnField
                    {
                        WaitingMsg m = new WaitingMsg();
                        frmSaveOpen frm = new frmSaveOpen(DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(layoutView1.GetDataRow(layoutView1.FocusedRowHandle)["ID"])).NOI_DUNG, layoutView1.GetDataRow(layoutView1.FocusedRowHandle)["TEN_FILE"].ToString());
                        m.Finish();
                        ProtocolForm.ShowModalDialog(this, frm);
                    }
                
            }
        }
        private void load_gridview(long ID_TaiLieu)
        {
            try
            {
                if (imageList_layout.Images.Empty) return;
                DataSet ds = DABase.getDatabase().LoadDataSet("select * from LUU_TRU_TAP_TIN lttt where lttt.ID in(select TAP_TIN_ID from DU_AN_TAP_TIN where DU_AN_ID='" + ID_TaiLieu + "')");              
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
            }
        }

        #endregion

        #region Phân biệt tai liệu
        private Image lay_anh(string tenfile)
        {
            if (imageList3.Images.Empty) return null;
            string[] duoi = tenfile.Split('.');
            duoi[duoi.Length - 1] = duoi[duoi.Length - 1].ToLower();
            if (duoi[duoi.Length - 1] == "doc" || duoi[duoi.Length - 1] == "docx" || duoi[duoi.Length - 1] == "dotx" || duoi[duoi.Length - 1] == "dot" || duoi[duoi.Length - 1] == "dotm" || duoi[duoi.Length - 1] == "docm")
                return imageList3.Images[0];
            if (duoi[duoi.Length - 1] == "xls" || duoi[duoi.Length - 1] == "xlsx")
                return imageList3.Images[1];
            if (duoi[duoi.Length - 1] == "GDB" || duoi[duoi.Length - 1] == "mdb" || duoi[duoi.Length - 1] == "mdf" || duoi[duoi.Length - 1] == "accdb")
                return imageList3.Images[2];
            if (duoi[duoi.Length - 1] == "bmp" || duoi[duoi.Length - 1] == "jpg" || duoi[duoi.Length - 1] == "png" || duoi[duoi.Length - 1] == "gif")
                return imageList3.Images[4];
            if (duoi[duoi.Length - 1] == "zip" || duoi[duoi.Length - 1] == "rar" || duoi[duoi.Length - 1] == "7z")
                return imageList3.Images[3];
            if (duoi[duoi.Length - 1] == "pdf" || duoi[duoi.Length - 1] == "chm")
                return imageList3.Images[6];
            if (duoi[duoi.Length - 1] == "txt")
                return imageList3.Images[5];
            return imageList3.Images[7];
        }
        #endregion                           

        private void LoaiDA_Load(object sender, EventArgs e)
        {
        
        }
    }

}
