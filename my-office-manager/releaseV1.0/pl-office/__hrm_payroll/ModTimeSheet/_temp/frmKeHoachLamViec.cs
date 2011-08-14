using System;
using System.Data;
using System.Windows.Forms;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Data.Common;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using pl.office;
using ProtocolVN.Plugin.TimeSheet.bo;


namespace ProtocolVN.Plugin.TimeSheet
{
    public partial class frmKeHoachLamViec : XtraFormPL
    {
        private DXErrorProvider Error;
        private DOChiTietCongViec chitietcongviec;
        #region 1.Hàm d?ng và Form Load
        public frmKeHoachLamViec()
        {
            InitializeComponent();
            Error = new DXErrorProvider();
            NgayNhap.DateTime = HelpDB.getDatabase().GetSystemCurrentDateTime();
            InitGrid();
            Duyet._init(true);
            PLTimeSheetCtrl.ChonNhanVien(NhanVien);
            NhanVien._setSelectedID(GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id)));
            NhanVien.Enabled = false;
            btnDuyet.Text = "Duyệt";
            InnitDodata(DateTime.Now, GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id)));
        }
        public frmKeHoachLamViec(DateTime Ngaylamviec, long ID_NV)
        {
            InitializeComponent();
            Error = new DXErrorProvider();
            NgayNhap.DateTime = HelpDB.getDatabase().GetSystemCurrentDateTime();
            InitGrid();
            Duyet._init(true);
            PLTimeSheetCtrl.ChonNhanVien(NhanVien);
            NhanVien._setSelectedID(ID_NV);
            NhanVien.Enabled = false;
            btnDuyet.Text = "Duyệt";
            InnitDodata(Ngaylamviec,ID_NV);
        }
        public frmKeHoachLamViec(DateTime Ngaylamviec, long ID_NV, bool isadd)
        {
            InitializeComponent();
            Error = new DXErrorProvider();
            NgayNhap.DateTime = HelpDB.getDatabase().GetSystemCurrentDateTime();
            InitGrid();
            Duyet._init(true);
            PLTimeSheetCtrl.ChonNhanVien(NhanVien);
            NhanVien._setSelectedID(ID_NV);
            NhanVien.Enabled = false;
            btnDuyet.Text = "Duyệt";
            InnitDodata(Ngaylamviec, ID_NV);
            gridViewDSCongviec.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            gridViewDSCongviec.OptionsBehavior.Editable = false;
            btnSave.Enabled = false;
            btnDuyet.Enabled = false;
            btnChonNhanVien.Enabled = false;
            NgayNhap.Enabled = false;
        }
        private void frmTimeTable_Load(object sender, EventArgs e)
        {
           
          
        }
        #endregion

        #region 2.Xu ly khoi tao
        public static void CloseDong(GridControl gridcontrol, GridView Gridview,bool? isadd)
        {
            GridColumn column = XtraGridSupportExt.CloseButton(gridcontrol,Gridview);
            if (isadd == null)
                column.Visible = false;
        }
        
        public void InitGrid()
        {
            XtraGridSupportExt.ComboboxGridColumn(cotnhanvien, GetNhanVien().Tables[0], "ID", "NAME","NV_ID");
            XtraGridSupportExt.ComboboxGridColumn(Cotduan, GetDuAn().Tables[0], "ID", "NAME", "DA_ID");
            //PLCtrl.CotCongViec(Cotcongviec,"CV_ID");
            //ID.FieldName = "DA_ID";
            PLTimeSheetUtil.ObjectChange(gridViewDSCongviec, Cotduan, Cotcongviec, new string[] { "DA_ID", "CV_ID" }, "LOAI_DU_AN", "DU_AN", "ID", "CONG_VIEC", "NAME", "ID");
            //RelGridColumn.CotPLDependRelation(gridViewDSCongviec, 
            //    Cotcongviec, "CV_ID", "CONG_VIEC", "NAME", "ID",
            //    "LOAI_DU_AN",
            //    Cotduan, "DA_ID", "DU_AN", "ID");
            Cotmota.FieldName = "MO_TA";
            //HelpGridColumn.CotTextLeft(Cotmota,"MO_TA");
            HelpGridColumn.CotPLTimeEdit(Cotbatdau, "BAT_DAU","HH:mm");
            HelpGridColumn.CotPLTimeEdit(Cotketthuc, "KET_THUC","HH:mm");
            HelpGridColumn.CotPLTimeEdit(CotTGTH,"THOI_GIAN_THUC_HIEN","HH:mm");
            CloseDong(gridDSCongviec, gridViewDSCongviec, true);

        }
        

        public void InnitDodata(DateTime ngaylamviec,long ID_NV)
        {
            if (ngaylamviec.ToString() != "" && ID_NV.ToString() != "")
            {
                chitietcongviec = GetCTCV(ngaylamviec, ID_NV);
                DataSet ds = GetData(ngaylamviec,ID_NV);
                NgayNhap.DateTime = ngaylamviec;
                NhanVien._setSelectedID(ID_NV);
                this.gridDSCongviec.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Info.Enabled = true;

                    PLTimeSheetUtil.UpdateInfo_Duyet(Info, chitietcongviec);
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        if (r["DUYET"].ToString() == "1")
                        {
                            chitietcongviec._DUYET = "1";
                            Duyet.SetDuyet(chitietcongviec);
                            Allow(true, gridViewDSCongviec);
                            btnDuyet.Text = "Duyệt";
                            break;
                        }
                        else if (r["DUYET"].ToString() == "2")
                        {
                           
                            Duyet.SetDuyet(chitietcongviec);
                            Allow(false, gridViewDSCongviec);
                            btnDuyet.Text = "Không Duyệt";
                            break;
                        }
                        else if (r["DUYET"].ToString() == "3")
                        {
                            
                            Duyet.SetDuyet(chitietcongviec);
                            Allow(true, gridViewDSCongviec);
                            btnDuyet.Text = "Duyệt";
                            break;
                        }

                    }
                    btnDuyet.Enabled = true;
                    
                }
                else
                {
                    Info.Enabled = false;
                    chitietcongviec._DUYET = "1";
                    Duyet.SetDuyet(chitietcongviec);
                    Allow(true,gridViewDSCongviec);
                    btnDuyet.Enabled = false;
                   
                }
            }
        }
        #endregion

        #region 3.CSDL        
        public DataSet GetDuAn()
        {
            string sql = "select * from DU_AN";
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "DUAN");
            return ds;
        }
        public DataSet GetNhanVien()
        {
            string sql = "select DM_NHAN_VIEN.* from DM_NHAN_VIEN,USER_CAT where  DM_NHAN_VIEN.ID=USER_CAT.EMPLOYEE_ID";
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "DUAN");
            return ds;
        }
        public static long GetNVID(long usercat)
        {
            string sql = "select EMPLOYEE_ID from USER_CAT where USERID=" + usercat;
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "USER");
            if (ds.Tables[0].Rows.Count > 0)
                return HelpNumber.ParseInt64(ds.Tables[0].Rows[0][0].ToString());
            else
                return -1;
        }
        public DataSet GetData(DateTime ngaylamviec,long nv_id)
        {
            DataSet ds=new DataSet();
            string sql = "select CTCCV_ID,DA_ID,CV_ID,NV_ID,MO_TA,BAT_DAU,KET_THUC,THOI_GIAN_THUC_HIEN,NGAY_LAM_VIEC,NGAY_CAP_NHAT,DUYET  from KE_HOACH_LAM_VIEC where NGAY_LAM_VIEC='" + ngaylamviec.ToString("MM/dd/yyyy") + "'and NV_ID=" + nv_id;
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            //db.AddInParameter(cmd, "NGAY_LAM_VIEC", DbType.Date, ngaylamviec);
            db.LoadDataSet(cmd,ds,"CTCV");
            return ds;
        }
        public DataSet GetData()
        {
            QueryBuilder filter = null;
            string sql = "select CTCCV_ID,DA_ID,CV_ID,NV_ID,MO_TA,BAT_DAU,KET_THUC,THOI_GIAN_THUC_HIEN,NGAY_LAM_VIEC,NGAY_CAP_NHAT,case when DUYET = 0 then 'Duyệt' else( case when DUYET = 1 then 'Chưa Duyệt' else 'Chờ Duyệt' end)end duyeta  from KE_HOACH_LAM_VIEC where 1=1";
            filter = new QueryBuilder(sql);
            filter.add("NGAY_LAM_VIEC",Operator.Equal,NgayNhap.DateTime,DbType.DateTime);
            filter.addID("NV_ID",NhanVien._getSelectedID());
            filter.addID("DUYET",comboBoxEdit1.SelectedIndex);
            filter.setAscOrderBy("NGAY_CAP_NHAT");
            DataSet ds = HelpDB.getDatabase().LoadDataSet(filter, "ABC");
            return HelpDB.getDatabase().LoadDataSet(filter, "ABC");
        }
        //hàm thêm,xóa,sửa
        public static bool Insert_Code(object CTCCV_ID, object DA_ID, object CV_ID, object NV_ID, string MO_TA, object BAT_DAU, object KET_THUC, object TGTH, object NGAY_LAM, object duyet, int count)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction tran = db.BeginTransaction(db.OpenConnection());
            string sql = ""; 
            if (count == 1)
            {
                sql = "Insert into KE_HOACH_LAM_VIEC(CTCCV_ID,DA_ID,CV_ID,NV_ID,MO_TA,BAT_DAU,KET_THUC,THOI_GIAN_THUC_HIEN,NGAY_LAM_VIEC,NGAY_CAP_NHAT,NGUOI_CAP_NHAT,DUYET) values(" + HelpNumber.ParseInt64(HelpDB.getDatabase().GetID("G_NGHIEP_VU")) + "," + HelpNumber.ParseInt64(DA_ID) + "," + HelpNumber.ParseInt64(CV_ID) + "," + HelpNumber.ParseInt64(NV_ID) + ",'" + MO_TA + "','" + Convert.ToDateTime(BAT_DAU).ToString("MM/dd/yyyy HH:mm:ss") + "','" + Convert.ToDateTime(KET_THUC).ToString("MM/dd/yyyy HH:mm:ss") + "','" + Convert.ToDateTime(TGTH).ToString("HH:mm:ss") + "','" + Convert.ToDateTime(NGAY_LAM).ToString("MM/dd/yyyy") + "','" + HelpDB.getDatabase().GetSystemCurrentDateTime().ToString("MM/dd/yyyy HH:mm:ss") + "'," + FrameworkParams.currentUser.id + ",'" + duyet.ToString() + "')";
            }
            else if(count==11)//day du
            {
                sql = "Insert into KE_HOACH_LAM_VIEC values(" + HelpNumber.ParseInt64(HelpDB.getDatabase().GetID("G_NGHIEP_VU")) + "," + HelpNumber.ParseInt64(DA_ID) + "," + HelpNumber.ParseInt64(CV_ID) + "," + HelpNumber.ParseInt64(NV_ID) + ",'" + MO_TA + "','" + Convert.ToDateTime(BAT_DAU).ToString("MM/dd/yyyy HH:mm:ss") + "','" + Convert.ToDateTime(KET_THUC).ToString("MM/dd/yyyy HH:mm:ss") + "','" + Convert.ToDateTime(TGTH).ToString("HH:mm:ss") + "','" + Convert.ToDateTime(NGAY_LAM).ToString("MM/dd/yyyy") + "','" + HelpDB.getDatabase().GetSystemCurrentDateTime().ToString("MM/dd/yyyy HH:mm:ss") + "'," + GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id)) + ",'" + "2" + "','" + HelpDB.getDatabase().GetSystemCurrentDateTime().ToString("MM/dd/yyyy HH:mm:ss") + "'," + GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id)) + ")";
            }
            else if (count == 2)
            {
                sql = "Update KE_HOACH_LAM_VIEC set DA_ID = " + HelpNumber.ParseInt64(DA_ID) + ",CV_ID = " + HelpNumber.ParseInt64(CV_ID) + ",NV_ID = " + HelpNumber.ParseInt64(NV_ID) + ",MO_TA = '" + MO_TA + "',BAT_DAU = '" + Convert.ToDateTime(BAT_DAU).ToString("MM/dd/yyyy HH:mm:ss") + "',KET_THUC = '" + Convert.ToDateTime(KET_THUC).ToString("MM/dd/yyyy HH:mm:ss") + "',THOI_GIAN_THUC_HIEN = '" + Convert.ToDateTime(TGTH).ToString("HH:mm:ss") + "',NGAY_CAP_NHAT ='" + HelpDB.getDatabase().GetSystemCurrentDateTime().ToString("MM/dd/yyyy HH:mm:ss") + "',NGUOI_CAP_NHAT =" + GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id)) + ",DUYET= '" + duyet.ToString() + "'" + " where CTCCV_ID = " + HelpNumber.ParseInt64(CTCCV_ID);
            }
            else if (count == 22)
            {
                sql = "Update KE_HOACH_LAM_VIEC set DA_ID = " + HelpNumber.ParseInt64(DA_ID) + ",CV_ID = " + HelpNumber.ParseInt64(CV_ID) + ",NV_ID = " + HelpNumber.ParseInt64(NV_ID) + ",MO_TA = '" + MO_TA + "',BAT_DAU = '" + Convert.ToDateTime(BAT_DAU).ToString("MM/dd/yyyy HH:mm:ss") + "',KET_THUC = '" + Convert.ToDateTime(KET_THUC).ToString("MM/dd/yyyy HH:mm:ss") + "',THOI_GIAN_THUC_HIEN = '" + Convert.ToDateTime(TGTH).ToString("HH:mm:ss") + "',NGAY_CAP_NHAT ='" + HelpDB.getDatabase().GetSystemCurrentDateTime().ToString("MM/dd/yyyy HH:mm:ss") + "',NGUOI_CAP_NHAT =" + GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id)) + ",DUYET= '" + "2" + "',NGAY_DUYET ='" + HelpDB.getDatabase().GetSystemCurrentDateTime().ToString("MM/dd/yyyy HH:mm:ss") + "',NGUOI_DUYET =" + GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id)) + " where CTCCV_ID = " + HelpNumber.ParseInt64(CTCCV_ID);
            }
            else if (count == 3)
            {
                //delete
                sql = "delete from KE_HOACH_LAM_VIEC where CTCCV_ID = " + HelpNumber.ParseInt64(CTCCV_ID);
            }
            try
            {
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.ExecuteNonQuery(cmd, tran);
                db.CommitTransaction(tran);
                return true;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                db.RollbackTransaction(tran);
                return false;
            }

        }
        public static DataSet GetdatabyNgay(object ngaylamviec)
        {
            string sql = "select * from CHI_TIET_CONG_VIEC where NGAY_LAM_VIEC='" + Convert.ToDateTime(ngaylamviec).ToString("MM/dd/yyyy") + "'";
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "CT");
            return ds;
        }
        public static DOChiTietCongViec GetCTCV(DateTime ngaylamviec, long nv_id)
        {
            DOChiTietCongViec ctcv = null;
            try
            {
                string sql = "select DUYET,NGAY_DUYET,NGUOI_DUYET,NGAY_CAP_NHAT,NGUOI_CAP_NHAT  from KE_HOACH_LAM_VIEC where NGAY_LAM_VIEC='" + ngaylamviec.ToString("MM/dd/yyyy") + "'and NV_ID=" + nv_id;
                ctcv = new DOChiTietCongViec();
                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);
                DataSet ds = new DataSet();
                db.LoadDataSet(cmd, ds, "a");
                //if(ds.Tables[0].Rows.Count>0)
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ctcv._DUYET = dr["DUYET"].ToString();
                    ctcv._NGAY_CAP_NHAT = Convert.ToDateTime(dr["NGAY_CAP_NHAT"]);
                    ctcv._NGUOI_CAP_NHAT = HelpNumber.ParseInt64(dr["NGUOI_CAP_NHAT"].ToString());
                    if (dr["NGAY_DUYET"].ToString()!="")
                    ctcv._NGAY_DUYET = Convert.ToDateTime(dr["NGAY_DUYET"]);
                    if (dr["NGUOI_DUYET"].ToString() != "")
                    ctcv._NGUOI_DUYET = HelpNumber.ParseInt64(dr["NGUOI_DUYET"].ToString());
                    break;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return ctcv;
        }
        public static bool Insert_Code(object CTCV_ID, object duyet)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction tran = db.BeginTransaction(db.OpenConnection());
            string sql = "";

            sql = "Update KE_HOACH_LAM_VIEC set NGAY_CAP_NHAT ='" + HelpDB.getDatabase().GetSystemCurrentDateTime().ToString("MM/dd/yyyy HH:mm:ss") + "',NGUOI_CAP_NHAT =" + FrameworkParams.currentUser.id + ",DUYET ='" + duyet + "',NGAY_DUYET ='" + HelpDB.getDatabase().GetSystemCurrentDateTime().ToString("MM/dd/yyyy HH:mm:ss") + "',NGUOI_DUYET =" + FrameworkParams.currentUser.id + " where CTCCV_ID =" + HelpNumber.ParseInt64(CTCV_ID);
            try
            {
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.ExecuteNonQuery(cmd, tran);
                db.CommitTransaction(tran);
                return true;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                db.RollbackTransaction(tran);
                return false;
            }

        }
        #endregion

        #region 4.Sử lý nút
        private void btnSave_Click(object sender, EventArgs e)
        {
            chitietcongviec = GetCTCV(NgayNhap.DateTime, NhanVien._getSelectedID());
            Duyet.GetDuyet(chitietcongviec);
            bool flag = false;
            DataSet ds =((DataView)gridViewDSCongviec.DataSource).Table.DataSet;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row.RowState != DataRowState.Unchanged)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        flag = Insert_Code("", row["DA_ID"], row["CV_ID"], NhanVien._getSelectedID()
                                     , row["MO_TA"].ToString(), row["BAT_DAU"], row["KET_THUC"]
                                     , row["THOI_GIAN_THUC_HIEN"], NgayNhap.DateTime,chitietcongviec._DUYET, 1);
                         
                    }
                    else if (row.RowState == DataRowState.Modified)
                    {
                       flag = Insert_Code(row["CTCCV_ID"], row["DA_ID"], row["CV_ID"], NhanVien._getSelectedID()
                                    , row["MO_TA"].ToString(), row["BAT_DAU"], row["KET_THUC"]
                                    , row["THOI_GIAN_THUC_HIEN"], "", chitietcongviec._DUYET, 2);
                       
                    }
                    else if (row.RowState == DataRowState.Deleted)
                    {
                        DataSet dsCV = null;
                        dsCV = GetData(NgayNhap.DateTime,NhanVien._getSelectedID());
                        foreach (DataRow r in dsCV.Tables[0].Rows)
                        {
                            DataRow[] deleterow = ds.Tables[0].Select("CTCCV_ID = " + r["CTCCV_ID"].ToString());
                            if (deleterow.Length == 0)
                            {
                                flag = Insert_Code(r["CTCCV_ID"], "", "", "", "", "", "", "", "", "", 3);
                            }
                        }
                    }
                }
                else
                {
                    if(flag!=false)
                    flag = true;
                }
            }
            if (flag != true)
                HelpMsgBox.ShowErrorMessage("Lưu Không thành công. Vui lòng kiểm tra số liệu!");
            else
            {
                this.Close();
            }
            
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn đóng?") == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnChonNhanVien_Click(object sender, EventArgs e)
        {
            NhanVien.Enabled = true;
        }
        private void btnDuyet_Click(object sender, EventArgs e)
        {
            DataSet dsCTCV = ((DataView)gridViewDSCongviec.DataSource).Table.DataSet;
            long[] aa = new long[dsCTCV.Tables[0].Rows.Count];
            if (btnDuyet.Text == "Duyệt")
            {
                btnDuyet.Text = "Không Duyệt";
                bool a = false;
                DataSet ds1 = (gridDSCongviec.DataSource as DataTable).DataSet;
                foreach (DataRow r in ds1.Tables[0].Rows)
                {
                    a = Insert_Code(r["CTCCV_ID"], "2");
                }
                if (a != true)
                    HelpMsgBox.ShowErrorMessage("Lưu Không thành công. Vui lòng kiểm tra số liệu!");
                else
                {
                    this.Close();
                }
            }
            else
            {
                btnDuyet.Text = "Duyệt";
                bool a = false;
                DataSet ds1 = (gridDSCongviec.DataSource as DataTable).DataSet;
                foreach (DataRow r in ds1.Tables[0].Rows)
                {
                    a = Insert_Code(r["CTCCV_ID"], "3");
                }
                if (a != true)
                    HelpMsgBox.ShowErrorMessage("Lưu Không thành công.Vui lòng kiểm tra số liệu!");
                else
                {
                    this.Close();
                }
            }
        }
        #endregion

        #region 5.Sự kiện
        private void NhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NgayNhap.DateTime <= HelpDB.getDatabase().GetSystemCurrentDateTime())
            {
                if (NhanVien._getSelectedID() != -1)
                {
                    Error.ClearErrors();
                    InnitDodata(NgayNhap.DateTime, NhanVien._getSelectedID());
                    NhanVien.Enabled = false;
                }
                else
                {
                    NhanVien.SetError(Error, "Mời nhập nhân viên!");
                }
            }
            else
            {

                Error.SetError(NgayNhap, "Ngày nhập không hợp lệ!");
            }
        }
        private void NgayNhap_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {

            if (NgayNhap.DateTime <= HelpDB.getDatabase().GetSystemCurrentDateTime())
            {
                if (NhanVien._getSelectedID() != -1)
                {
                    Error.ClearErrors();
                    InnitDodata(NgayNhap.DateTime, NhanVien._getSelectedID());
                }
                else
                {
                    NhanVien.SetError(Error, "Mời nhập nhân viên!");
                }
            }
            else
            {

                Error.SetError(NgayNhap,"Ngày nhập không hợp lệ!");
            }
        }
        private void gridViewDSCongviec_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView grid = (GridView)sender;
            DataRow row = grid.GetDataRow(e.RowHandle);
            bool flag = true;
            row.ClearErrors();
            if (row["DA_ID"].ToString() == "")
            {
                row.SetColumnError("DA_ID", "Mời nhập Dự án!");
                flag = false;
            }
            if (row["CV_ID"].ToString() == "")
            {
                row.SetColumnError("CV_ID", "Mời nhập công việc!");
                flag = false;
            }
            if (grid.GetRowCellDisplayText(e.RowHandle,Cotcongviec) == "")
            {
                row.SetColumnError("CV_ID", "Mời nhập công việc!");
                flag = false;
            }
            if (row["MO_TA"].ToString() == "")
            {
                row.SetColumnError("MO_TA", "Mời bạn mô tả công việc thực hiện!");
                flag = false;
            }
            if (row["BAT_DAU"].ToString() == "")
            {
                row.SetColumnError("BAT_DAU", "Mời bạn nhập thời gian bắt đầu!");
                flag = false;
            }
            if (row["KET_THUC"].ToString() == "")
            {
                row.SetColumnError("KET_THUC", "Mời bạn nhập thời gian Kết thúc!");
                flag = false;
            }
            if (row["THOI_GIAN_THUC_HIEN"].ToString() == "")
            {
                row.SetColumnError("THOI_GIAN_THUC_HIEN", "Mời nhập thời gian thực hiện!");
                flag = false;
            }
            if (row["BAT_DAU"].ToString() != "" && row["KET_THUC"].ToString() != "")
            {
                if ((HelpNumber.ParseInt32(Convert.ToDateTime(row["BAT_DAU"]).ToString("HH")) > HelpNumber.ParseInt32(Convert.ToDateTime(row["KET_THUC"]).ToString("HH"))) || ((HelpNumber.ParseInt32(Convert.ToDateTime(row["BAT_DAU"]).ToString("HH")) == HelpNumber.ParseInt32(Convert.ToDateTime(row["KET_THUC"]).ToString("HH"))) && (HelpNumber.ParseInt32(Convert.ToDateTime(row["BAT_DAU"]).ToString("mm")) > HelpNumber.ParseInt32(Convert.ToDateTime(row["KET_THUC"]).ToString("mm")))))
                {
                    row.SetColumnError("KET_THUC", "Giờ kết thúc không hợp lệ!");
                    flag = false;
                }
            }
            DataSet dsss = (gridDSCongviec.DataSource as DataTable).DataSet;
           
            foreach (DataRow r in dsss.Tables[0].Rows)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    if (r["CTCCV_ID"].ToString() != row["CTCCV_ID"].ToString())
                    {
                       
                            if (row["DA_ID"].ToString() == r["DA_ID"].ToString() && row["CV_ID"].ToString() == r["CV_ID"].ToString() && row["MO_TA"].ToString().ToLower() == r["MO_TA"].ToString().ToLower())
                            {
                                row.SetColumnError("DA_ID", "Dự án nhập không hợp lệ!");
                                row.SetColumnError("CV_ID", "Công việc nhập không hợp lệ!");
                                row.SetColumnError("MO_TA", "Mô tả nhập không hợp lệ!");
                                flag = false;
                            }
                       
                    }
                }
                
                
            }
            if (row["BAT_DAU"].ToString() != "" && row["KET_THUC"].ToString() != "")
            {
                int hbd = HelpNumber.ParseInt32(Convert.ToDateTime(row["BAT_DAU"]).ToString("HH"));
                int hkt = HelpNumber.ParseInt32(Convert.ToDateTime(row["KET_THUC"]).ToString("HH"));
                int phutbd = HelpNumber.ParseInt32(Convert.ToDateTime(row["BAT_DAU"]).ToString("mm"));
                int phutkt = HelpNumber.ParseInt32(Convert.ToDateTime(row["KET_THUC"]).ToString("mm"));
                foreach (DataRow rl in dsss.Tables[0].Rows)
                {

                    if (rl.RowState != DataRowState.Deleted)
                    {
                        if (rl["BAT_DAU"].ToString() != "" && rl["KET_THUC"].ToString() != "")
                        {
                            int h1 = HelpNumber.ParseInt32(Convert.ToDateTime(rl["BAT_DAU"]).ToString("HH"));
                            int h2 = HelpNumber.ParseInt32(Convert.ToDateTime(rl["KET_THUC"]).ToString("HH"));
                            int phutbd1 = HelpNumber.ParseInt32(Convert.ToDateTime(rl["BAT_DAU"]).ToString("mm"));
                            int phutkt2 = HelpNumber.ParseInt32(Convert.ToDateTime(rl["KET_THUC"]).ToString("mm"));
                            if (row["CTCCV_ID"].ToString() != rl["CTCCV_ID"].ToString() || row["CTCCV_ID"].ToString() == "")
                            {

                                if ((hbd > h1 && hbd < h2) || (hkt > h1 && hkt < h2) || (h1 > hbd && h1 < hkt) || (h2 > hbd && h2 < hkt)
                                    || ((hkt == h1) && (phutkt > phutbd1)) || (((hkt == h2)) && (phutkt < phutkt2)) || ((hbd == h1) && (phutbd > phutbd1)) || (((hbd == h2)) && (phutbd < phutkt2))
                                    || (hbd == h1) && (hkt == h2) && (hbd < hkt)
                                    )
                                {
                                    row.SetColumnError("BAT_DAU", "Giờ bắt đầu không hợp lệ!");
                                    row.SetColumnError("KET_THUC", "Giờ Kết thúc không hợp lệ!");
                                    flag = false;

                                }

                            }
                        }
                    }
                    
                    
                }
            }
            if (flag == false)
            {
                e.Valid = false;
                return;
            }
        }
        void Allow(bool flag, PLGridView gridView)
        {
            if (flag == false)
            {
                Duyet.Enabled = false;
                gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                gridView.OptionsBehavior.Editable = false;
                btnSave.Enabled = false;
            }
            else
            {
                Duyet.Enabled = false;
                gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                gridView.OptionsBehavior.Editable = true;
                btnSave.Enabled = true;
            }
        }
        Int64 i = 0;
        private void gridViewDSCongviec_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (row["CTCCV_ID"].ToString()=="")
                row["CTCCV_ID"] = i++;
            if (e.Column.FieldName == "BAT_DAU" || e.Column.FieldName == "KET_THUC")
            {
                if (row["BAT_DAU"].ToString() != "" && row["KET_THUC"].ToString() != "")
                {

                    string gio = "";
                    int giobd = HelpNumber.ParseInt32(Convert.ToDateTime(row["BAT_DAU"]).ToString("HH"));
                    int giokt = HelpNumber.ParseInt32(Convert.ToDateTime(row["KET_THUC"]).ToString("HH"));
                    int phutbd = HelpNumber.ParseInt32(Convert.ToDateTime(row["BAT_DAU"]).ToString("mm"));
                    int phutkt = HelpNumber.ParseInt32(Convert.ToDateTime(row["KET_THUC"]).ToString("mm"));
                    if (giokt>=giobd && phutkt > phutbd)
                    {
                        gio = ((giokt - giobd) < 10 ? "0" + (giokt - giobd) : "" + (giokt - giobd)) + ":" + ((phutkt - phutbd) < 10 ? "0" + (phutkt - phutbd) : "" + (phutkt - phutbd));
                    }
                    else if (giokt > giobd && phutkt < phutbd)
                    {
                        int phut = (phutkt+60)-phutbd;
                        int gioc = giokt - giobd -1;
                        gio = (gioc < 10 ? "0" + gioc : "" + gioc) + ":" + (phut < 10 ? "0" + phut : "" + phut);
                    }
                    else if (giokt > giobd && phutkt == phutbd)
                    {
                        gio = ((giokt - giobd) < 10 ? "0" + (giokt - giobd) : "" + (giokt - giobd)) + ":00"; 
                    }
                    gridViewDSCongviec.SetFocusedRowCellValue(CotTGTH, gio);
                }
            }
        }
       
        #endregion   
    }
}