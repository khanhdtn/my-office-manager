using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DevExpress.XtraEditors.Repository;
using System.Text;
using office;

namespace DAO
{
    public class DACongViec
    {
        private static string KEY_FIELD_NAME = "PCCV_ID";
        private static string TABLE_NAME = "PHAN_CONG_CONG_VIEC";
        object[] FIELD_MAP = new object[] {  
                "PCCV_ID", new IDConverter(),                                
                "MO_TA", null,	                                           										
				"CONG_VIEC", null,
                "MUC_UU_TIEN",null, 
                "TRINH_TRANG", null,	
                "NGAY_BAT_DAU",null,               
                "NGAY_KET_THUC_DU_KIEN",null,
                "NGAY_GUI",null,
                "NGAY_KET_THUC",null,
                "THOI_GIAN_DU_KIEN",null,
                "IS_NGAY",null,
                "NGUOI_GIAO",null,
                "LOAICV_ID",null,
                "IS_CONG_VIEC_KH",null,
                "CHI_TIET_CONG_VIEC",null
        };

        #region SQL STRING thêm xóa sữa
        private const string SQL_STRING_INSERT_PCCV = "Insert into PHAN_CONG_CONG_VIEC(PCCV_ID,MO_TA,CONG_VIEC,MUC_UU_TIEN,TINH_TRANG,NGAY_BAT_DAU,NGAY_KET_THUC_DU_KIEN,NGAY_KET_THUC,THOI_GIAN_DU_KIEN,IS_NGAY,NGUOI_GIAO,LCV_ID,IS_CONG_VIEC_KH,CHI_TIET_CONG_VIEC) values" +
                                                               "(" +
                                                                  "@PCCV_ID," +
                                                                  "@MO_TA," +
                                                                  "@CONG_VIEC,"+
                                                                   "@MUC_UU_TIEN," +
                                                                   "@TINH_TRANG," +
                                                                   "@NGAY_BAT_DAU," +
                                                                   "@NGAY_KET_THUC_DU_KIEN," +
                                                                   "@NGAY_KET_THUC," +
                                                                   "@THOI_GIAN_DU_KIEN," +
                                                                   "@IS_NGAY," +
                                                                   "@NGUOI_GIAO," +                                           
                                                                   "@LCV_ID," +
                                                                   "@IS_CONG_VIEC_KH," +
                                                                   "@CHI_TIET_CONG_VIEC" +
                                                                   ")";
        private const string SQL_STRING_UPDATE_PCCV = "Update PHAN_CONG_CONG_VIEC set " +
                                                                   "LCV_ID=@LCV_ID," +
                                                                   "MO_TA=@MO_TA," +
                                                                   "CONG_VIEC = @CONG_VIEC,"+
                                                                   "MUC_UU_TIEN=@MUC_UU_TIEN," +
                                                                   "TINH_TRANG=@TINH_TRANG," +
                                                                   "NGAY_BAT_DAU=@NGAY_BAT_DAU," +
                                                                   "NGAY_KET_THUC_DU_KIEN=@NGAY_KET_THUC_DU_KIEN," +
                                                                   "NGAY_KET_THUC=@NGAY_KET_THUC," +
                                                                   "THOI_GIAN_DU_KIEN=@THOI_GIAN_DU_KIEN," +
                                                                   "IS_NGAY=@IS_NGAY," +
                                                                   "NGUOI_GIAO=@NGUOI_GIAO," +
                                                                   "IS_CONG_VIEC_KH=@IS_CONG_VIEC_KH, " +
                                                                   "CHI_TIET_CONG_VIEC=@CHI_TIET_CONG_VIEC " +
                                                                   "where PCCV_ID=@PCCV_ID"
                                                                   ;
        private const string SQL_STRING_INSERT_CTPC = "insert into CHI_TIET_PHAN_CONG(PCCV_ID,MA_NV,PHAN_TRAM_THAM_GIA,TIEN_DO,GHI_CHU,THOI_GIAN_CAP_NHAT) values" +
                                                                    "(" +
                                                                  "@PCCV_ID," +
                                                                  "@MANV," +
                                                                  "@PHAN_TRAM_THAM_GIA," +                                                                  
                                                                  "@TIEN_DO,"+  
                                                                  "@GHI_CHU,"+
                                                                  "@THOI_GIAN_CAP_NHAT" +
                                                                ")";
        private const string SQL_STRING_INSERT_NKCV = "insert into NHAT_KY_KH_DA_CV(ID,PCCV_ID,MA_NV,GHI_CHU,THOI_GIAN_CAP_NHAT) values" +
                                                                    "(" +
                                                                  "@ID," + 
                                                                  "@PCCV_ID," +
                                                                  "@MANV," +
                                                                  "@GHI_CHU," +
                                                                  "@THOI_GIAN_CAP_NHAT" +
                                                                ")";
        private const string SQL_STRING_DELETE_CTPC = "Delete from CHI_TIET_PHAN_CONG where PCCV_ID=@PCCV_ID";
        #endregion

        #region khởi tạo các danh sách
        public static DataTable chonLoaiCongViec(bool? IsAdd) //trã về DataTable danh sách loại công việc
        {
            DataSet ds = new DataSet(); 
            DataTable dt = new DataTable();
            if (IsAdd == true)
            {
                ds = HelpDB.getDatabase().LoadDataSet("select distinct a.ID,a.NAME from DM_LOAI_CONG_VIECN a where a.VISIBLE_BIT='Y' Order by a.NAME");
            }
            else
            {
                ds = HelpDB.getDatabase().LoadDataSet("select distinct a.ID,a.NAME from DM_LOAI_CONG_VIECN a Order by a.NAME");
            }
            if (ds.Tables.Count > 0) dt = ds.Tables[0];
            return dt;

        }
        public static DataTable ChonNhanVien(bool? IsAdd)     //trã về DataTable danh sach nhân viên
        {
            DataSet dsNV = new DataSet();
            DataTable dt = new DataTable();
            if (IsAdd == true)
                dsNV = HelpDB.getDatabase().LoadDataSet("select ID,NAME from DM_NHAN_VIEN " +
                          "where VISIBLE_BIT='Y' Order by lower(NAME)", "DM_NHAN_VIEN");
            else
                dsNV = HelpDB.getDatabase().LoadDataSet("select ID,NAME from DM_NHAN_VIEN " +
                          "Order by lower(NAME)", "DM_NHAN_VIEN"); 
            if (dsNV.Tables.Count > 0) dt = dsNV.Tables[0];
            return dt;
        }
        public static DataTable ChonTinhTrang(bool? IsAdd)    //trã về DataTable danh sách tình trạng
        {
            DataSet dsNV = new DataSet();
            DataTable dt = new DataTable();
            if (IsAdd == true)
                dsNV = HelpDB.getDatabase().LoadDataSet("select ID, NAME from DM_TINH_TRANG " +
                          "where VISIBLE_BIT='Y' Order by lower(NAME)", "DM_TINH_TRANG");
            else
                dsNV = HelpDB.getDatabase().LoadDataSet("select ID, NAME from DM_TINH_TRANG " +
                          " Order by lower(NAME)", "DM_TINH_TRANG");
            if (dsNV.Tables.Count > 0) dt = dsNV.Tables[0];
            return dt;
        }
        public static void DeleteCVTT(long IDTapTin)
        {
            DALuuTruTapTin.Instance.Delete(IDTapTin);
            string sql2 = "DELETE FROM OBJECT_TAP_TIN WHERE TAP_TIN_ID=@ID AND TYPE_ID=5";
            DatabaseFB db1 = HelpDB.getDatabase();
            DbCommand command2 = db1.GetSQLStringCommand(sql2);
            db1.AddInParameter(command2, "@ID", DbType.Int64, IDTapTin);
            db1.ExecuteNonQuery(command2);
        }
        public static void DeleteCongViec(long IDCongViec)
        {
            string sql2 = "DELETE FROM KH_DA_CV WHERE PCCV_ID=@ID";
            DatabaseFB db1 = HelpDB.getDatabase();
            DbCommand command2 = db1.GetSQLStringCommand(sql2);
            db1.AddInParameter(command2, "@ID", DbType.Int64, IDCongViec);
            db1.ExecuteNonQuery(command2);
        }
        public static void DeleteNhatKy(long IDNhatKy)
        {
            string sql2 = "DELETE FROM NHAT_KY_KH_DA_CV WHERE ID=@ID";
            DatabaseFB db1 = HelpDB.getDatabase();
            DbCommand command2 = db1.GetSQLStringCommand(sql2);
            db1.AddInParameter(command2, "@ID", DbType.Int64, IDNhatKy);
            db1.ExecuteNonQuery(command2);
        }
        public static bool exists_DATT(long ID_TT)
        {
            if (ID_TT != 0)
            {
                DatabaseFB db = HelpDB.getDatabase();
                DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());

                DbCommand cm = db.GetSQLStringCommand(@"SELECT COUNT(*) FROM OBJECT_TAP_TIN WHERE TYPE_ID=5 AND TAP_TIN_ID ='" + ID_TT + "'");
                int dem = (int)db.ExecuteScalar(cm, dbTrans);
                if (dem > 0)
                    return true;
            }
            return false;
        }
        public static void UpdateCVTT(long IDCongViec, long IDTapTin)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand(string.Format(@"INSERT INTO OBJECT_TAP_TIN VALUES(@TAP_TIN_ID,@CV_ID,@TYPE_ID)"));
            db.AddInParameter(cm, "@CV_ID", DbType.Int64, IDCongViec);
            db.AddInParameter(cm, "@TAP_TIN_ID", DbType.Int64, IDTapTin);
            db.AddInParameter(cm, "@TYPE_ID", DbType.Int32, 5);
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        public static DataTable NhanVienThamGia(params long[] nguoiThucHien)  
        {
            string sql = string.Empty;
            if (nguoiThucHien.Length > 0)
            {
                StringBuilder str = new StringBuilder();
                foreach (long item in nguoiThucHien) str.Append(item + ",");
                sql = string.Format(@"SELECT NV.ID,NV.NAME,NV.DEPARTMENT_ID,BP.NAME TENBP 
                         FROM DM_NHAN_VIEN NV, DEPARTMENT BP 
                         WHERE NV.DEPARTMENT_ID = BP.ID AND NV.VISIBLE_BIT='Y' AND NV.DEPARTMENT_ID IS NOT NULL
                         AND NV.ID in ({0}) 
                         ORDER BY NV.NAME", str.Remove(str.Length - 1, 1));
            }
            else {
                sql = @"SELECT NV.ID,NV.NAME,NV.DEPARTMENT_ID,BP.NAME TENBP 
                         FROM DM_NHAN_VIEN NV, DEPARTMENT BP 
                         WHERE NV.DEPARTMENT_ID = BP.ID AND NV.VISIBLE_BIT='Y' AND NV.DEPARTMENT_ID IS NOT NULL
                         ORDER BY NV.NAME";
            }
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            DataTable dt = new DataTable();
            if (ds.Tables.Count > 0) dt = ds.Tables[0];
            return dt;
        }
        public static void ChonNhanvien_Cbx(PLCombobox Input, bool? IsAdd)
        {
            bool IsVisible = false;
            if (IsAdd != null && IsAdd == true) IsVisible = true;

            QueryBuilder query = null;
            if (IsVisible)
                query = new QueryBuilder("select * from DM_NHAN_VIEN where VISIBLE_BIT = 'Y' AND 1=1");
            else
                query = new QueryBuilder("SELECT * FROM DM_NHAN_VIEN where 1=1");
            query.setAscOrderBy("lower(MA_NV)");
            DataSet ds = HelpDB.getDatabase().LoadReadOnlyDataSet(query);
            Input._init(ds.Tables[0], "NAME", "ID");
        }
        public static void ChonTinhTrang_Cbx(PLCombobox Input, bool? IsAdd)
        {
            bool IsVisible = false;
            if (IsAdd == true) IsVisible = true;

            QueryBuilder query = null;
            if (IsVisible)
                query = new QueryBuilder("SELECT * FROM DM_TINH_TRANG where VISIBLE_BIT = 'Y' AND 1=1");
            else
                query = new QueryBuilder("SELECT * FROM DM_TINH_TRANG where 1=1");
            query.setAscOrderBy("lower(NAME)");
            DataSet ds = HelpDB.getDatabase().LoadReadOnlyDataSet(query);
            Input._init(ds.Tables[0], "NAME", "ID");
        }
        public static void ChonMucdo_cv(PLCombobox PLMucuutien)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.Int32"));
            dt.Columns.Add("NAME");
            dt.Rows.Add(new object[] { 0, "Cao nhất" });
            dt.Rows.Add(new object[] { 1, "Cao" });
            dt.Rows.Add(new object[] { 2, "Trung bình" });
            dt.Rows.Add(new object[] { 3, "Thấp" });
            dt.Rows.Add(new object[] { 4, "Thấp nhất" });
            ds.Tables.Add(dt);
            PLMucuutien._init(dt, "NAME", "ID");

        }
       
        public static DOPhanCongCongViec LoadPCCV(long pccv_id)
        {       
            DOPhanCongCongViec doPccv = new DOPhanCongCongViec();
            string sql = "SELECT * FROM PHAN_CONG_CONG_VIEC PCCV WHERE PCCV.PCCV_ID='" + pccv_id + "'";
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            DataRow row;
            if(ds.Tables[0].Rows.Count>0)
            {

                row = ds.Tables[0].Rows[0];
                doPccv.PCCV_ID = HelpNumber.ParseInt64(row["PCCV_ID"]);
                doPccv.CONG_VIEC = row["CONG_VIEC"].ToString();
                doPccv.MO_TA = row["MO_TA"].ToString();
                doPccv.LCV_ID = HelpNumber.ParseInt64(row["LCV_ID"]);
                doPccv.MUC_UU_TIEN = HelpNumber.ParseInt64(row["MUC_UU_TIEN"]);
                doPccv.TINH_TRANG = HelpNumber.ParseInt64(row["TINH_TRANG"]);
                if (row["THOI_GIAN_DU_KIEN"].ToString() != string.Empty)
                    doPccv.THOI_GIAN_DU_KIEN = HelpNumber.ParseDecimal(row["THOI_GIAN_DU_KIEN"]);
                doPccv.NGUOI_GIAO = HelpNumber.ParseInt64(row["NGUOI_GIAO"]);
                if (row["NGAY_BAT_DAU"].ToString() != "")
                    doPccv.NGAY_BAT_DAU = Convert.ToDateTime(row["NGAY_BAT_DAU"]);
                if (row["NGAY_KET_THUC"].ToString() != "")
                    doPccv.NGAY_KET_THUC = Convert.ToDateTime(row["NGAY_KET_THUC"]);
                if (row["NGAY_KET_THUC_DU_KIEN"].ToString() != "")
                    doPccv.NGAY_KET_THUC_DU_KIEN = Convert.ToDateTime(row["NGAY_KET_THUC_DU_KIEN"]);
                doPccv.IS_NGAY = row["IS_NGAY"].ToString();
                //CHAUTV
                if (row["CHI_TIET_CONG_VIEC"] != DBNull.Value)
                    doPccv.CHI_TIET_CONG_VIEC = (byte[])row["CHI_TIET_CONG_VIEC"];
            }
            return doPccv;


        }
        #endregion

        #region nhân viên chỉ có ở 1 danh sách : dự bị hoặc đang tham gia
        //loại bớt nhân viên
        public static void loaiNhanVienTrung(DataTable dt1, DataTable dt2)
        {
            foreach (DataRow dr2 in dt2.Rows)
                foreach (DataRow dr1 in dt1.Rows)
                    if (dr2["ID_NV"].ToString() == dr1["ID"].ToString())
                    {
                        dt1.Rows.Remove(dr1);
                        break;
                    }
        }
        #endregion

        #region "Lưu công việc"
        public static bool LuuCongViec(bool? IsAdd,DOPhanCongCongViec phanCongCV,List<DOChiTietPhanCong> cacChiTietPhanCong)
        {
            bool ok = true;
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            try
            {               
                #region lưu bảng phân công
                string sqlPC = SQL_STRING_INSERT_PCCV;
                if (IsAdd == false)//update
                    sqlPC = SQL_STRING_UPDATE_PCCV;
                DbCommand cmdPC = db.GetSQLStringCommand(sqlPC);
                db.AddInParameter(cmdPC, "@PCCV_ID", DbType.Int64, phanCongCV.PCCV_ID);                
                db.AddInParameter(cmdPC, "@MO_TA", DbType.String, phanCongCV.MO_TA);
                db.AddInParameter(cmdPC, "@CONG_VIEC",DbType.String,phanCongCV.CONG_VIEC);
                db.AddInParameter(cmdPC, "@MUC_UU_TIEN", DbType.Int32, phanCongCV.MUC_UU_TIEN);
                db.AddInParameter(cmdPC, "@TINH_TRANG", DbType.Int64, phanCongCV.TINH_TRANG);
                db.AddInParameter(cmdPC, "@NGAY_BAT_DAU", DbType.DateTime, phanCongCV.NGAY_BAT_DAU);
                db.AddInParameter(cmdPC, "@NGAY_KET_THUC", DbType.DateTime, phanCongCV.NGAY_KET_THUC);
                db.AddInParameter(cmdPC, "@NGAY_KET_THUC_DU_KIEN", DbType.DateTime, phanCongCV.NGAY_KET_THUC_DU_KIEN);
                db.AddInParameter(cmdPC, "@THOI_GIAN_DU_KIEN", DbType.Int32, phanCongCV.THOI_GIAN_DU_KIEN);
                db.AddInParameter(cmdPC, "@IS_NGAY", DbType.String, phanCongCV.IS_NGAY);
                db.AddInParameter(cmdPC, "@NGUOI_GIAO", DbType.Int64, phanCongCV.NGUOI_GIAO);
                db.AddInParameter(cmdPC, "@LCV_ID", DbType.Int64, phanCongCV.LCV_ID);
                db.AddInParameter(cmdPC, "@IS_CONG_VIEC_KH", DbType.String, phanCongCV.IS_CONG_VIEC_KH);

                db.AddInParameter(cmdPC, "@CHI_TIET_CONG_VIEC", DbType.Binary, phanCongCV.CHI_TIET_CONG_VIEC);
                if (db.ExecuteNonQuery(cmdPC, dbTrans) < 0) ok = false;
                
                #endregion
                #region lưu bảng chi tiết phân công
                if (IsAdd == false && cacChiTietPhanCong.Count > 0)//update
                {
                    DbCommand cmdDel = db.GetSQLStringCommand(SQL_STRING_DELETE_CTPC);
                    db.AddInParameter(cmdDel, "@PCCV_ID", DbType.Int64, phanCongCV.PCCV_ID);
                    if (db.ExecuteNonQuery(cmdDel, dbTrans) < 0) ok = false;
                }
                foreach (DOChiTietPhanCong chiTietPC in cacChiTietPhanCong)
                {
                    DbCommand cmdCTPC = db.GetSQLStringCommand(SQL_STRING_INSERT_CTPC);
                    db.AddInParameter(cmdCTPC, "@PCCV_ID", DbType.Int64, chiTietPC.PCCV_ID);
                    db.AddInParameter(cmdCTPC, "@MANV", DbType.Int64, chiTietPC.MA_NV);
                    db.AddInParameter(cmdCTPC, "@PHAN_TRAM_THAM_GIA", DbType.Int32, chiTietPC.PHAN_TRAM_THAM_GIA);
                    db.AddInParameter(cmdCTPC, "@TIEN_DO", DbType.Int32, chiTietPC.TIEN_DO);
                    db.AddInParameter(cmdCTPC, "@GHI_CHU", DbType.String, chiTietPC.GHI_CHU);
                    db.AddInParameter(cmdCTPC, "@THOI_GIAN_CAP_NHAT", DbType.DateTime, chiTietPC.THOI_GIAN_CAP_NHAT);

                    if (db.ExecuteNonQuery(cmdCTPC, dbTrans) < 0)
                    {
                        ok = false;
                        break;
                    }
                }
                db.CommitTransaction(dbTrans);
                #endregion            
            }
            catch(Exception e)
            {
                HelpMsgBox.ShowNotificationMessage(e.ToString());
                db.RollbackTransaction(dbTrans);
                return false;
            }
            return ok;
        }
        public static bool CapNhatTinhTrangCongViec(long PCCV_ID, long TinhTrang) {
            DatabaseFB db = HelpDB.getDatabase();
            string Sql = string.Format(@"UPDATE PHAN_CONG_CONG_VIEC 
                                            SET TINH_TRANG = {0},NGAY_KET_THUC='{1}' WHERE PCCV_ID = {2}", TinhTrang, DateTime.Now.ToString("MM/dd/yyyy"), PCCV_ID);

            DbCommand cmd = db.GetSQLStringCommand(Sql);
            try
            {
                return db.ExecuteNonQuery(cmd) > 0;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "Cập nhật trạng thái của Phân công công việc");
                return false;
            }
        }
        #endregion

        #region cập nhật tiến độ
        public static bool luuCapNhatTienDo(DOChiTietPhanCong chiTietPC)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction tran = db.BeginTransaction(db.OpenConnection());
            try
            {
                DbCommand cmd = db.GetSQLStringCommand(SQL_STRING_INSERT_CTPC);
                db.AddInParameter(cmd, "@PCCV_ID", DbType.Int64, chiTietPC.PCCV_ID);
                db.AddInParameter(cmd, "@MANV", DbType.Int64, chiTietPC.MA_NV);
                db.AddInParameter(cmd, "@PHAN_TRAM_THAM_GIA", DbType.Int32, chiTietPC.PHAN_TRAM_THAM_GIA);
                db.AddInParameter(cmd, "@TIEN_DO", DbType.Int32, chiTietPC.TIEN_DO);
                db.AddInParameter(cmd, "@THOI_GIAN_CAP_NHAT", DbType.DateTime, chiTietPC.THOI_GIAN_CAP_NHAT);
                db.AddInParameter(cmd, "GHI_CHU", DbType.String, chiTietPC.GHI_CHU);
                db.ExecuteNonQuery(cmd, tran);
            }
            catch(Exception ex)
            {
                PLException.AddException(ex);
                tran.Rollback();
                return false;
            }
            finally
            {
                tran.Commit();
            }
            return true;
        }
        #endregion
        #region Lưu nhật ký công việc
        public static bool luuNhatKyCongViec(DONhatKyCongViec nhatKyCV)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction tran = db.BeginTransaction(db.OpenConnection());
            try
            {
                DbCommand cmd = db.GetSQLStringCommand(SQL_STRING_INSERT_NKCV);
                db.AddInParameter(cmd, "@ID", DbType.Int64, nhatKyCV.ID);
                db.AddInParameter(cmd, "@PCCV_ID", DbType.Int64, nhatKyCV.PCCV_ID);
                db.AddInParameter(cmd, "@MANV", DbType.Int64, nhatKyCV.MA_NV);
                db.AddInParameter(cmd, "@THOI_GIAN_CAP_NHAT", DbType.DateTime, nhatKyCV.THOI_GIAN_CAP_NHAT);
                db.AddInParameter(cmd, "GHI_CHU", DbType.String, nhatKyCV.GHI_CHU);
                db.ExecuteNonQuery(cmd, tran);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                tran.Rollback();
                return false;
            }
            finally
            {
                tran.Commit();
            }
            return true;
        }
        #endregion

        #region xóa công việc
        public static bool DeleteAction(long PCCV_ID)
        {
            return FWDBService.DeleteRecord(TABLE_NAME, KEY_FIELD_NAME, PCCV_ID);     
        }
        #endregion

        #region tính tổng phần trăm tham gia để kiểm tra
        public static int tongPhanTramThamGia(DataTable dt)
        {
            int persent = 0;
            foreach (DataRow dr in dt.Rows)
                persent += int.Parse(dr["PHAN_TRAM_THAM_GIA"].ToString());
            return persent;
        }
        #endregion

        #region Thông tin cập nhật
        public static void loadThongTinCapNhat(ref DataTable dtThongTinCapNhat, long id)
        {
            String ttcapnhat = string.Format(@"SELECT CT.* ,NV.NAME AS NGUOI_THUC_HIEN
                                FROM CHI_TIET_PHAN_CONG CT LEFT JOIN DM_NHAN_VIEN NV ON CT.MA_NV = NV.ID 
                            WHERE CT.PCCV_ID = {0} AND CT.TIEN_DO >= 0 ORDER BY THOI_GIAN_CAP_NHAT DESC", id);
            dtThongTinCapNhat = HelpDB.getDatabase().LoadDataSet(ttcapnhat).Tables[0];
        }
        //thêm 1 dòng vào thông tin cập nhật
        public static void addRowThongTinCapNhat(ref DataTable dtThongTinCapNhat,DataRow dr)
        {
            DataRow drNew = dtThongTinCapNhat.NewRow();
            drNew["THOI_GIAN_CAP_NHAT"] = HelpDB.getDatabase().GetSystemCurrentDateTime();
                    drNew["MA_NV"] = dr["ID_NV"].ToString();                  
                    drNew["PHAN_TRAM_THAM_GIA"] = dr["PHAN_TRAM_THAM_GIA"].ToString();
                    drNew["TIEN_DO"] = 0;
                    drNew["THOI_GIAN_CAP_NHAT"] = HelpDB.getDatabase().GetSystemCurrentDateTime();
                    drNew["GHI_CHU"] = "";
                    drNew["NGUOI_THUC_HIEN"] = dr["NAME"].ToString();
                    dtThongTinCapNhat.Rows.Add(drNew);
        }
        //Xóa những dòng có ID đưa vào...
        public static void xoaNhanVien(ref DataTable dt, String fielName, long id)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (long.Parse(dt.Rows[i][fielName].ToString()) == id)
                    dt.Rows.RemoveAt(i);
            }
        }
        #endregion

        #region các hàm kiểm tra
        public static int kiemTraTonTaiDulieu(DataTable dtKiemTra, string tenCotKiemTra, string stringKiemTra)
        {
            int kiemTra = -1;
            for (int i = 0; i < dtKiemTra.Rows.Count; i++)
            {
                if (dtKiemTra.Rows[i][tenCotKiemTra].ToString().Equals(stringKiemTra))
                {
                    kiemTra = i;
                    break;
                }
            }
            return kiemTra;
        }

        // kiểm tra xem ngày hay giờ
        public static string getIsDay(String seTGDuKien, Int32 ngayGio)
        {
            string isDay = null;
            if (seTGDuKien != "" && HelpNumber.ParseInt32(seTGDuKien) != 0)
            {
                if (ngayGio == 0)
                    isDay = "Y";
                else 
                    isDay = "N";
            }
            return isDay;
        }

        //tìm nhân viên có trong công việc không
        public static bool isThuocCongViec(Int64 nv_id, Int64 pccv_id)
        {
            DataTable dt = HelpDB.getDatabase().LoadDataSet("select MA_NV from chi_tiet_phan_cong where MA_NV = " + nv_id + " and PCCV_ID = " + pccv_id).Tables[0];
            return (dt.Rows.Count > 0);
        }
        #endregion

        #region các hàm get
        //lấy tên nhân viên
        public static String getNameNV(Int64 id)
        {
            DataTable dt = HelpDB.getDatabase().LoadDataSet("select NAME from DM_NHAN_VIEN where ID = " + id).Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["NAME"].ToString();
            return "";
        }        
        public static String getTinhTrang(Int64 id)
        {
            DataTable dt = HelpDB.getDatabase().LoadDataSet("select NAME from DM_TINH_TRANG where ID = " + id).Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["NAME"].ToString();
            return "";
        }
        public static string getMucUuTien(long id)
        {
            DataTable Bang_uu_tien = HelpDB.getDatabase().LoadDataSet("select NAME from DM_MUC_DO_UU_TIEN WHERE ID=" + id + "").Tables[0];
            return Bang_uu_tien.Rows[0]["NAME"].ToString();
        }
        public static String getTenLoaiCV(Int64 id)
        {
            DataTable dt = HelpDB.getDatabase().LoadDataSet("select NAME from DM_LOAI_CONG_VIECN where ID = " + id).Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["NAME"].ToString();
            return "";
        }       
        //get phần tram tham gia
        public static Int32 getPhanTramThamGia(Int64 nv_id,Int64 pccv_id)
        {
            DataTable dt = HelpDB.getDatabase().LoadDataSet("select PHAN_TRAM_THAM_GIA from chi_tiet_phan_cong where MA_NV = " + nv_id + "and PCCV_ID = " + pccv_id).Tables[0];
            if (dt.Rows.Count > 0)
                return HelpNumber.ParseInt32(dt.Rows[0]["PHAN_TRAM_THAM_GIA"].ToString());
            return 0;
        }
        //get tiến độ thực hiện sao cùng
        public static Int32 tienDoCuoi(Int64 nv_id, Int64 pccv_id)
        {
            String sqlString = @"select TIEN_DO from chi_tiet_phan_cong where pccv_id = "+ pccv_id +@" and ma_nv = " + nv_id +@"
                                and thoi_gian_cap_nhat = (select max(ct.thoi_gian_cap_nhat) from chi_tiet_phan_cong ct where pccv_id = "+ pccv_id +@" and ma_nv = "+ nv_id +")";
            DataTable dt = HelpDB.getDatabase().LoadDataSet(sqlString).Tables[0];
            if (dt.Rows.Count > 0)
                return HelpNumber.ParseInt32(dt.Rows[0]["TIEN_DO"].ToString());
            return 0;
        }
        #endregion

        #region Extension
        public static int TongTienDo(long PCCV_ID) {
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetStoredProcCommand("ST_TONG_TIEN_DO_CV");
            db.AddInParameter(cmd, "@IPCCV_ID", DbType.Int64, PCCV_ID);
            try
            {
                return HelpNumber.ParseInt32(db.ExecuteScalar(cmd));
            }
            catch { return 0; }
        }
        public static bool InsertKhachHang_CongViec(long PCCV_ID, long KH_ID) {
            string Sql = string.Format(@"INSERT INTO {0} VALUES ({1}, null, {2})", PLConst.bangKH_DA_CV, KH_ID, PCCV_ID);
            try
            {
                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(Sql);
                return db.ExecuteNonQuery(cmd) > 0;
            }
            catch (Exception ex) {
                PLException.AddException(ex);
                return false;
            }
        }
        #endregion
    }
}
