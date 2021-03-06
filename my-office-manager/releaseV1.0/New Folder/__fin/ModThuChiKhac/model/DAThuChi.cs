using System;
using System.Data;
using System.Data.Common;
using DTO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;



namespace DAO
{
    public class DAPhieuThuChi
    {
        #region 1.Hàm thêm, xóa, sửa PHIẾU
        public static bool Insert(DOPhieuThuChi Phieu)
        {
            try
            {
                string sql = "INSERT INTO THU_CHI(ID,MA_PHIEU,NGAY_PHAT_SINH,NGAY_CAP_NHAT,NGUOI_CAP_NHAT_ID, "
                        + "NV_ID,DIEN_GIAI,IS_THU_CHI,SO_TIEN,LCP_ID,DON_VI_LIEN_QUAN) VALUES"
                        + "(@ID,@MA_PHIEU,@NGAY_PHAT_SINH,@NGAY_CAP_NHAT,@NGUOI_CAP_NHAT_ID,"
                        + "@NV_ID,@DIEN_GIAI,@IS_THU_CHI,@SO_TIEN,@LCP_ID,@DON_VI_LIEN_QUAN)";

                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@ID", DbType.Int64, Phieu.ID);
                db.AddInParameter(cmd, "@MA_PHIEU", DbType.String, Phieu.MA_PHIEU);
                db.AddInParameter(cmd, "@NGAY_PHAT_SINH", DbType.DateTime, Phieu.NGAY_PHAT_SINH);
                db.AddInParameter(cmd, "@NGAY_CAP_NHAT", DbType.DateTime, Phieu.NGAY_CAP_NHAT);
                db.AddInParameter(cmd, "@NGUOI_CAP_NHAT_ID", DbType.Int64, Phieu.NGUOI_CAP_NHAT_ID);
                db.AddInParameter(cmd, "@NV_ID", DbType.Int64, Phieu.NV_ID);
                db.AddInParameter(cmd, "@DIEN_GIAI", DbType.String, Phieu.DIEN_GIAI);
                db.AddInParameter(cmd, "@IS_THU_CHI", DbType.String, Phieu.IS_THU_CHI);
                db.AddInParameter(cmd, "@SO_TIEN", DbType.Decimal, Phieu.SO_TIEN);
                db.AddInParameter(cmd, "@LCP_ID", DbType.Int64, Phieu.LCP_ID);
                db.AddInParameter(cmd, "@DON_VI_LIEN_QUAN", DbType.String, Phieu.DON_VI_LIEN_QUAN);
                int iCmd = db.ExecuteNonQuery(cmd);
                if (iCmd > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        public static bool Delete(long ID)
        {
            try
            {
                string sql = "DELETE FROM THU_CHI WHERE ID = @ID";
                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
                int dCmd = db.ExecuteNonQuery(cmd);
                if (dCmd > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(DOPhieuThuChi Phieu)
        {
            try
            {
                string sql = "UPDATE THU_CHI set "
                        + "NGAY_PHAT_SINH = @NGAY_PHAT_SINH,"
                        + "NGAY_CAP_NHAT = @NGAY_CAP_NHAT,"
                        + "NGUOI_CAP_NHAT_ID = @NGUOI_CAP_NHAT_ID,"
                        + "NV_ID  =  @NV_ID,"
                        + "DIEN_GIAI = @DIEN_GIAI,"
                        + "IS_THU_CHI = @IS_THU_CHI,"
                        + "SO_TIEN  =  @SO_TIEN ,"
                        + "LCP_ID = @LCP_ID,"
                        + "DON_VI_LIEN_QUAN = @DON_VI_LIEN_QUAN "
                        + "WHERE ID = @ID";

                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@ID", DbType.Int64, Phieu.ID);
                db.AddInParameter(cmd, "@NGAY_PHAT_SINH", DbType.DateTime, Phieu.NGAY_PHAT_SINH);
                db.AddInParameter(cmd, "@NGAY_CAP_NHAT", DbType.DateTime, Phieu.NGAY_CAP_NHAT);
                db.AddInParameter(cmd, "@NGUOI_CAP_NHAT_ID", DbType.Int64, Phieu.NGUOI_CAP_NHAT_ID);
                db.AddInParameter(cmd, "@NV_ID", DbType.Int32, Phieu.NV_ID);
                db.AddInParameter(cmd, "@DIEN_GIAI", DbType.String, Phieu.DIEN_GIAI);
                db.AddInParameter(cmd, "@IS_THU_CHI", DbType.String, Phieu.IS_THU_CHI);
                db.AddInParameter(cmd, "@SO_TIEN", DbType.Decimal, Phieu.SO_TIEN);
                db.AddInParameter(cmd, "@LCP_ID", DbType.Int64, Phieu.LCP_ID);
                db.AddInParameter(cmd, "@DON_VI_LIEN_QUAN", DbType.String, Phieu.DON_VI_LIEN_QUAN);

                int iCmd = db.ExecuteNonQuery(cmd);
                if (iCmd > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                return false;   
            }
            
        }
        #endregion

        #region 2.Hàm tạo mã phiếu tự động
        public static string GetCodePhieu(bool IsTC)
        {
            if (IsTC)
                return DatabaseFB.getSoPhieu("THU_CHI", "MA_PHIEU", DatabaseFB.GetThamSo("MA_PTH"));
            else
                return DatabaseFB.getSoPhieu("THU_CHI", "MA_PHIEU", DatabaseFB.GetThamSo("MA_PCH"));
        }
        public static string TaoMaPhieu()
        {
            string sql = "select * from THU_CHI order by ID desc";
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "AA");
            int MP = (ds.Tables[0].Rows.Count > 0) ? int.Parse(ds.Tables[0].Rows[0]["ID"].ToString()) : 0;
            MP++;
            string[] M = DateTime.Today.ToShortDateString().Split('/');
            string Kq = "PH" + M[0] + M[1] + M[2] + "_";
            for (int i = 0; i < 4-MP.ToString().Length; i++)
            {
                Kq += "0";
            }
            Kq += MP.ToString();
            return Kq;
        }
        public static string getMaHoSO()
        {
            string sql = "select first 1 ID from RESUME order by ID desc";
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "AA");
            int MP = (ds.Tables[0].Rows.Count > 0) ? int.Parse(ds.Tables[0].Rows[0]["ID"].ToString()) : 0;
            MP++;
            string Kq = "HS_";
            for (int i = 0; i < 4 - MP.ToString().Length; i++)
            {
                Kq += "0";
            }
            Kq += MP.ToString();
            return Kq;
        }
        #endregion

        #region 3.Hàm lấy một PHIẾU theo ID
        public static DOPhieuThuChi GetPhieu(long ID)
        {
            string sql = "select * FROM THU_CHI WHERE ID = @ID";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "PHIEU");
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            DOPhieuThuChi Phieu = new DOPhieuThuChi();
            try
            {
                Phieu.ID = ID;
                Phieu.MA_PHIEU = ds.Tables[0].Rows[0]["MA_PHIEU"].ToString();
                Phieu.NGAY_PHAT_SINH = (DateTime)ds.Tables[0].Rows[0]["NGAY_PHAT_SINH"];
                Phieu.NGAY_CAP_NHAT = (DateTime)ds.Tables[0].Rows[0]["NGAY_CAP_NHAT"];
                Phieu.NGUOI_CAP_NHAT_ID = HelpNumber.ParseInt64(ds.Tables[0].Rows[0]["NGUOI_CAP_NHAT_ID"]);
                Phieu.DIEN_GIAI = ds.Tables[0].Rows[0]["DIEN_GIAI"].ToString();
                Phieu.NV_ID = HelpNumber.ParseInt32(ds.Tables[0].Rows[0]["NV_ID"]);
                Phieu.SO_TIEN = HelpNumber.ParseDecimal(ds.Tables[0].Rows[0]["SO_TIEN"]);
                Phieu.LCP_ID = HelpNumber.ParseInt32(ds.Tables[0].Rows[0]["LCP_ID"]);
                Phieu.DON_VI_LIEN_QUAN = ds.Tables[0].Rows[0]["DON_VI_LIEN_QUAN"].ToString();
                Phieu.IS_THU_CHI = ds.Tables[0].Rows[0]["IS_THU_CHI"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message) ;
            }
            return Phieu;
        }
        #endregion

        #region 4.Các hàm hỗ trợ chốt, mở chốt cho PHIẾU

        public static string GetIsKetChuyenPhieu(DateTime? NgayPhatSinh)
        {
            string sql = "select IS_KET_CHUYEN FROM DM_KY_KINH_DOANH "
                       + "WHERE TU_NGAY<=@NGAY_PHAT_SINH and @NGAY_PHAT_SINH <= DEN_NGAY";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@NGAY_PHAT_SINH", DbType.DateTime,NgayPhatSinh);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "PHIEU");
            if (ds.Tables[0].Rows.Count == 0)
                return "";
            return ds.Tables[0].Rows[0]["IS_KET_CHUYEN"].ToString();

        }

        public static DataTable getKyKinhDoanh(string IsKetChuyen)
        {
            string sql = "select * FROM DM_KY_KINH_DOANH WHERE IS_KET_CHUYEN ='" + IsKetChuyen + "' order by TU_NGAY";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "AA");
            return ds.Tables[0];
        }

        public static bool UpdateChot(int Id,string IsKetChuyen)
        {
            string sql = "Update DM_KY_KINH_DOANH set IS_KET_CHUYEN = @IS_KET_CHUYEN where ID = @ID";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64,Id);
            db.AddInParameter(cmd, "@IS_KET_CHUYEN", DbType.String, IsKetChuyen);
            if (db.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }

        public static int ChotPhieu(long  id)
        {
            DOPhieuThuChi Phieu = DAPhieuThuChi.GetPhieu(id);
            string IsKetChuyen = DAPhieuThuChi.GetIsKetChuyenPhieu(Phieu.NGAY_PHAT_SINH);
            if (IsKetChuyen == "Y")
                return 1;
            if (IsKetChuyen == "N")
                return 0;
            return -1;
        }

        public static bool ChotPhieu(DateTime? NgayPhatSinh)
        {
            string Chot = GetIsKetChuyenPhieu(NgayPhatSinh);
            if (Chot == "Y")
                return true;
            return false;

        }

        #endregion
    }
    
    public class TKThongKeThuChi
    {
        #region 1.Hàm thống kê hiển thị lên lưới Form quản lý
        public static DataSet ThongKe(
            int I_LOAI_CHI_PHI_ID,
            DateTime I_TU_NGAY,
            DateTime I_DEN_NGAY,
            int I_NHAN_VIEN_ID,
            decimal I_SO_TIEN_TU,
            decimal I_SO_TIEN_DEN,
            string I_IS_THU_CHI
        )
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetStoredProcCommand("ST_THONGKE_THUCHI");
            db.AddInParameter(cmd, "@I_LOAI_CHI_PHI_ID", DbType.Int32,I_LOAI_CHI_PHI_ID);
            db.AddInParameter(cmd, "@I_TU_NGAY", DbType.DateTime, I_TU_NGAY);
            db.AddInParameter(cmd, "@I_DEN_NGAY", DbType.DateTime, I_DEN_NGAY);
            db.AddInParameter(cmd, "@I_NHAN_VIEN_ID", DbType.Int32, I_NHAN_VIEN_ID);
            db.AddInParameter(cmd, "@I_SO_TIEN_TU", DbType.Decimal, I_SO_TIEN_TU);
            db.AddInParameter(cmd, "@I_SO_TIEN_DEN", DbType.Decimal, I_SO_TIEN_DEN);
            db.AddInParameter(cmd, "@I_IS_THU_CHI", DbType.String, I_IS_THU_CHI);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "AA");
            if(ds!=null && ds.Tables[0].Rows.Count>=2)
                ds.Tables[0].Rows.RemoveAt(ds.Tables[0].Rows.Count-1);
            if (ds != null && ds.Tables[0].Rows.Count == 1 && (ds.Tables[0].Rows[0][0] == null||ds.Tables[0].Rows[0][0].ToString()==""))
                ds.Tables[0].Rows.RemoveAt(0);
            return ds;

        }
        #endregion

        #region 2.Hàm cập nhật thống kê khi kết chuyển (chốt, mở chốt) có giá trị trả về là [error]
        public static bool CapNhatThongKe(long I_KY_KINH_DOANH_ID, string I_IS_DONG_MO,DateTime I_NGAY_CHOT)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetStoredProcCommand("ST_FORM_KETCHUYENSODUTIEN");
            db.AddInParameter(cmd, "@I_KY_KINH_DOANH_ID", DbType.Int64, I_KY_KINH_DOANH_ID);
            db.AddInParameter(cmd, "@I_IS_DONG_MO", DbType.String, I_IS_DONG_MO);
            db.AddInParameter(cmd, "@I_NGAY_CHOT", DbType.DateTime, I_NGAY_CHOT);
            db.AddOutParameter(cmd, "@O_ERROR", DbType.Int32,1);
            db.ExecuteNonQuery(cmd);
            object objError = db.GetParameterValue(cmd, "@O_ERROR");
            getError((int)objError);
            if((int)objError==0)
                return true;
            return false;
        }
        public static void getError(int ErrorID)
        {
            switch (ErrorID)
            {
                case  0: break;
                case -1: HelpMsgBox.ShowErrorMessage("Thực hiện không thành công \nNguyên nhân : Kỳ trước chưa được chốt"); break ;
                case -2: HelpMsgBox.ShowConfirmMessage("Thực hiện không thành công \nNguyên nhân : Không có kỳ tiếp theo để kết chuyển"); break;
            }
        }
        public static DateTime Get_NGAYDAUKY_MAX()
        {
            DataSet ds = HelpDB.getDatabase().LoadDataSet("SELECT KKD.TU_NGAY FROM DM_KY_KINH_DOANH KKD WHERE KKD.ID=(SELECT MAX(KKD1.ID) FROM DM_KY_KINH_DOANH KKD1)");
            return Convert.ToDateTime(ds.Tables[0].Rows[0]["TU_NGAY"]);
        }
        public static DateTime GetMinKKD() {
            string Sql = string.Format(@"SELECT MIN(TU_NGAY)
                            FROM DM_KY_KINH_DOANH
                                WHERE EXTRACT(YEAR FROM TU_NGAY)={0}", HelpDB.getDatabase().GetSystemCurrentDateTime().Year);
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(Sql);
            return (DateTime)db.ExecuteScalar(cmd);
        }
        #endregion
    }
      
}
