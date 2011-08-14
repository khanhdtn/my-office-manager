using System;
using ProtocolVN.Framework.Core;
using System.Data;
using System.Data.Common;
using DTO;
using System.Drawing;
using ProtocolVN.Framework.Win;
using office;
using System.Collections.Generic;

namespace DAO
{
    public class DADuAn:DAPhieu<DODuAn>
    {
        private static string KEY_FIELD_NAME = "ID";
        object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),                                                					
				"NAME", null,
                "LOAI_DU_AN",new IDConverter(),
                "NGUOI_QUAN_LY",new IDConverter(),
                "NGAY_BAT_DAU",null,
                "NGAY_KET_THUC",null,
                "TIEN_DO",null,
                "MUC_UU_TIEN",null,
                "TINH_TRANG",null,
                "MO_TA",null,
                "THONG_TIN_THEM",null,
                "NGUOI_THUC_HIEN",null,
                "NGAY_KET_THUC_THUC_TE",null
              
        };
        public static DADuAn Instance = new DADuAn();

        private DADuAn() : base() { }
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DODuAn LoadAll(long IDKey)
        {
            return Load(IDKey);
        }

        public override bool UpdateDetail(DataSet Detail, DataSet Grid)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateDetail(DataRow row)
        {
            throw new NotImplementedException();
        }

        public override DataTypeBuilder DefineDataTypeBuilder()
        {
            return new DataTypeBuilder(FIELD_MAP);
        }

        public override bool Delete(long IDKey)
        {
            return FWDBService.DeleteRecord("DU_AN","ID",IDKey);
        }

        public override DODuAn Load(long IDKey)
        {
            IDataReader reader = FWDBService.LoadRecord("DU_AN", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DODuAn data = (DODuAn)this.Builder.CreateFilledObject(typeof(DODuAn), reader);
                    return data;
                }
            }
            return new DODuAn();
        }

        public override bool Update(DODuAn data)
        {
            bool flag = false;
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DataSet MainDS = FWDBService.LoadDataSet("DU_AN", KEY_FIELD_NAME, data.ID);
            if (MainDS.Tables[0].Rows.Count == 1)
            {
                HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP, data);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            else
            {
                DataRow row = MainDS.Tables[0].NewRow();
                row[KEY_FIELD_NAME] = data.ID;// = DABase.getDatabase().GetID("G_NGHIEP_VU");
                HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                MainDS.Tables[0].Rows.Add(row);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            if (flag == true) db.CommitTransaction(dbTrans);
            else db.RollbackTransaction(dbTrans);
            return flag;
        }

        public override bool Validate(DODuAn element)
        {
            throw new NotImplementedException();
        }
        public void UpdateDATT(long IDDuAn, long IDTapTin)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand(string.Format(@"INSERT INTO OBJECT_TAP_TIN VALUES(@TAP_TIN_ID,@DU_AN_ID,@TYPE_ID)"));
            db.AddInParameter(cm, "@DU_AN_ID", DbType.Int64, IDDuAn);
            db.AddInParameter(cm, "@TAP_TIN_ID", DbType.Int64, IDTapTin);
            db.AddInParameter(cm, "@TYPE_ID", DbType.Int32, 7);
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        public static void InsertDuAn_CongViec(long duanID, long pccvID)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand(string.Format(@"INSERT INTO {0} VALUES (null, {1}, {2})", PLConst.bangKH_DA_CV, duanID, pccvID));
            db.ExecuteNonQuery(cm, dbTrans);
            db.CommitTransaction(dbTrans);
        }

        public static void InsertKhachHang_DuAn(long khachhangID, long duanID)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand(string.Format(@"INSERT INTO {0} VALUES ({1}, {2}, null)", PLConst.bangKH_DA_CV, khachhangID, duanID));
            db.ExecuteNonQuery(cm, dbTrans);
            db.CommitTransaction(dbTrans);
        }

        public void DeleteDATT(long IDTapTin)
        {
            DALuuTruTapTin.Instance.Delete(IDTapTin);
            string sql2 = "DELETE FROM OBJECT_TAP_TIN WHERE TAP_TIN_ID=@ID AND TYPE_ID=7";
            DatabaseFB db1 = HelpDB.getDatabase();
            DbCommand command2 = db1.GetSQLStringCommand(sql2);
            db1.AddInParameter(command2, "@ID", DbType.Int64, IDTapTin);
            db1.ExecuteNonQuery(command2);
        }
        public static bool CapNhatTinhTrangDuAn(long DA_ID, long TinhTrang)
        {
            DatabaseFB db = HelpDB.getDatabase();
            string Sql = string.Format(@"UPDATE DU_AN 
                                            SET TINH_TRANG = {0},NGAY_KET_THUC_THUC_TE='{1}' WHERE ID = {2}", TinhTrang, DateTime.Now.ToString("MM/dd/yyyy"), DA_ID);

            DbCommand cmd = db.GetSQLStringCommand(Sql);
            try
            {
                return db.ExecuteNonQuery(cmd) > 0;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "Cập nhật trạng thái của dự án");
                return false;
            }
        }
        public static void CapNhatTienDoDuAn(long DA_ID, decimal tienDo)
        {
            DatabaseFB db = HelpDB.getDatabase();
            string Sql =@"UPDATE DU_AN SET TIEN_DO = @tienDo WHERE ID = @ID";
            DbCommand cmd = db.GetSQLStringCommand(Sql);
            db.AddInParameter(cmd, "@tienDo", DbType.Decimal, tienDo);
            db.AddInParameter(cmd, "@ID", DbType.Int64, DA_ID);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "Cập nhật trạng thái của dự án");
            }
        }
        public static string LayTienDo(long DA_ID)
        {
            string tienDo = "";
            string sql = string.Format("select TIEN_DO || '%' TIEN_DO from DU_AN where ID={0}", DA_ID);
            DataTable dt = HelpDB.getDatabase().LoadDataSet(sql).Tables[0];
            tienDo = dt.Rows[0]["TIEN_DO"].ToString();
            return tienDo;
        }
        public static bool exists_ds_congviec(Int64 id)
        {
            if (id != 0)
            {
                DataSet ds = HelpDB.getDatabase().LoadDataSet("select * from PHAN_CONG_CONG_VIEC where PCCV_ID in(select da.PCCV_ID from KH_DA_CV da where da.DU_AN_ID='" + id + "')");
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
            }
            return false;
        }
        public static bool exists_ds_tailieu(Int64 id)
        {
            if (id != 0)
            {
                DataSet ds = HelpDB.getDatabase().LoadDataSet(@"SELECT * 
                FROM LUU_TRU_TAP_TIN 
                WHERE ID IN(SELECT TAP_TIN_ID FROM OBJECT_TAP_TIN  WHERE TYPE_ID=7 AND OBJECT_ID='" + id + "')");
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
            }
            return false;
        }
        public static bool check_TrinhTrang_isHoanThanh(Int64 id)
        {
            if (id != 0)
            {
                DataSet ds = HelpDB.getDatabase().LoadDataSet("select * from DU_AN where TINH_TRANG=5 and ID='" + id + "'");
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
            }
            return false;
        }

        public static bool tinhTrangChoXoa(Int64 id)
        {
            if (id != 0)
            {
                DataSet ds = HelpDB.getDatabase().LoadDataSet("select * from DU_AN where TINH_TRANG in (1,2,4) and ID='" + id + "'");
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
            }
            return false;
        }
        public static byte[] ImageToByteArray(Image image)
        {
            System.IO.MemoryStream mStream = new System.IO.MemoryStream();
            image.Save(mStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] ret = mStream.ToArray();
            mStream.Close();
            return ret;
        }
        public static bool exists_DATT(long ID_TT)
        {
            if (ID_TT != 0)
            {
                DatabaseFB db = HelpDB.getDatabase();
                DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());

                DbCommand cm = db.GetSQLStringCommand(@"SELECT COUNT(*) FROM OBJECT_TAP_TIN WHERE TYPE_ID=7 AND TAP_TIN_ID ='" + ID_TT + "'");
                int dem = (int)db.ExecuteScalar(cm, dbTrans);
                if (dem > 0)
                    return true;
            }
            return false;
        }
        public static bool exists_DACongViec(long ID_CV)
        {
            if (ID_CV != 0)
            {
                DatabaseFB db = HelpDB.getDatabase();
                DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());

                DbCommand cm = db.GetSQLStringCommand(string.Format(@"SELECT COUNT(*) FROM {0} WHERE PCCV_ID ={1}", PLConst.bangKH_DA_CV, ID_CV));
                int dem = (int)db.ExecuteScalar(cm, dbTrans);
                if (dem > 0)
                    return true;
            }
            return false;
        }
        private const string SQL_STRING_INSERT_NKDA = "INSERT INTO NHAT_KY_KH_DA_CV(ID,DA_ID,MA_NV,GHI_CHU,THOI_GIAN_CAP_NHAT) VALUES" +
                                                                   "(" +
                                                                 "@ID," +
                                                                 "@DA_ID," +
                                                                 "@MANV," +
                                                                 "@GHI_CHU," +
                                                                 "@THOI_GIAN_CAP_NHAT" +
                                                               ")";
        public static bool luuNhatKyDA(DONhatKyDuAn nhatKyDA)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction tran = db.BeginTransaction(db.OpenConnection());
            try
            {
                DbCommand cmd = db.GetSQLStringCommand(SQL_STRING_INSERT_NKDA);
                db.AddInParameter(cmd, "@ID", DbType.Int64, nhatKyDA.ID);
                db.AddInParameter(cmd, "@DA_ID", DbType.Int64, nhatKyDA.DA_ID);
                db.AddInParameter(cmd, "@MANV", DbType.Int64, nhatKyDA.MA_NV);
                db.AddInParameter(cmd, "@THOI_GIAN_CAP_NHAT", DbType.DateTime, nhatKyDA.THOI_GIAN_CAP_NHAT);
                db.AddInParameter(cmd, "GHI_CHU", DbType.String, nhatKyDA.GHI_CHU);
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
        public static DataTable GetNhatKyDA(long DA_ID)
        {
            string query = @"SELECT DA.ID, DA.THOI_GIAN_CAP_NHAT,DA.GHI_CHU ,NV.NAME AS NGUOI_THUC_HIEN
                                                FROM NHAT_KY_KH_DA_CV DA
                                                LEFT JOIN DM_NHAN_VIEN NV ON DA.MA_NV = NV.ID WHERE DA.da_id = " + DA_ID + " AND 1=1";
            DataTable KQ = HelpDB.getDatabase().LoadDataSet(query).Tables[0];

            return KQ;
        }
        public static String getLoaiDuAn(Int64 id)
        {
            DataTable dt = HelpDB.getDatabase().LoadDataSet("SELECT NAME FROM DM_LOAI_DU_AN WHERE ID = " + id).Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["NAME"].ToString();
            return "";
        }
        public static DataTable LoadCongViec(long ID)
        {
            DataSet ds = new DataSet();
            QueryBuilder query = new QueryBuilder(
               @"SELECT DISTINCT PC.PCCV_ID,PC.LCV_ID, PC.CONG_VIEC,DU_AN_ID,
                                   PC.NGAY_BAT_DAU TU_NGAY, PC.NGAY_KET_THUC_DU_KIEN DEN_NGAY,PC.NGAY_KET_THUC,
                                   IIF(PC.IS_NGAY ='Y',PC.THOI_GIAN_DU_KIEN ||' ngày', PC.THOI_GIAN_DU_KIEN ||' giờ') THOI_GIAN_DU_KIEN,
                                   PC.MUC_UU_TIEN,
                                   (CASE PC.MUC_UU_TIEN WHEN 1 THEN 'Cao nhất' ELSE (
                                   CASE PC.MUC_UU_TIEN WHEN 2 THEN 'Cao' ELSE (
                                   CASE PC.MUC_UU_TIEN WHEN 3 THEN 'Trung bình' ELSE (
                                   CASE PC.MUC_UU_TIEN WHEN 4 THEN 'Thấp' ELSE(
                                   CASE PC.MUC_UU_TIEN WHEN 5 THEN 'Thấp nhất' ELSE NULL END) END ) END ) END) END) TEN_MUC_UU_TIEN,
                                   '' TONG_TIEN_DO,
                                    PC.NGUOI_GIAO, TT.NAME AS TINH_TRANG,TT.ID AS ID_TT,
                                    IIF(LCV.NAME IS NOT NULL,(SELECT CV.NAME FROM DM_LOAI_CONG_VIECN CV WHERE PC.LCV_ID = CV.ID ),'Loại công việc khác') TEN_LCV,                                     
                                    (SELECT N.NAME FROM DM_NHAN_VIEN N WHERE PC.NGUOI_GIAO = N.ID) TEN_NGUOI_GIAO
                            FROM  (((PHAN_CONG_CONG_VIEC PC LEFT JOIN DM_TINH_TRANG TT ON PC.TINH_TRANG = TT.ID )
                                  INNER JOIN DM_LOAI_CONG_VIECN LCV ON PC.LCV_ID = LCV.ID) LEFT JOIN CHI_TIET_PHAN_CONG CT ON PC.PCCV_ID = CT.PCCV_ID)INNER JOIN KH_DA_CV ON KH_DA_CV.PCCV_ID=PC.PCCV_ID
                            WHERE 1=1");

            query.addID("DU_AN_ID", ID);
            ds = HelpDB.getDatabase().LoadDataSet(query);

            string sql = @"SELECT C.PCCV_ID,PHAN_TRAM_THAM_GIA,MAX(TIEN_DO) TIEN_DO,T.TONG_PHAN_TRAM
                            FROM CHI_TIET_PHAN_CONG C,
                            (SELECT PCCV_ID,SUM(PHAN_TRAM_THAM_GIA) TONG_PHAN_TRAM
                                FROM CHI_TIET_PHAN_CONG WHERE TIEN_DO = 0 GROUP BY PCCV_ID) T
                                    WHERE TIEN_DO > 0 AND T.PCCV_ID = C.PCCV_ID and 
                                    c.thoi_gian_cap_nhat IN (select max(ct.thoi_gian_cap_nhat) from chi_tiet_phan_cong ct where ct.pccv_id=T.pccv_id GROUP BY CT.MA_NV)
                                          GROUP BY C.PCCV_ID,C.MA_NV,PHAN_TRAM_THAM_GIA,T.TONG_PHAN_TRAM";
            DataSet dss = HelpDB.getDatabase().LoadDataSet(sql);
            ds.Tables[0].Columns.Add("NV_THAM_GIA");
            ds.Tables[0].Columns.Add("TIEN_DO");
            ds.Tables[0].Columns.Add("TONG_PHAN_TRAM_CV");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                String ten = "";
                String sqlString = "select ct.ma_nv, nv.NAME, ct.phan_tram_tham_gia from chi_tiet_phan_cong ct, dm_nhan_vien nv where ct.ma_nv = nv.id and ct.pccv_id = " + dr["PCCV_ID"].ToString() + " group by ma_nv,NAME, phan_tram_tham_gia";
                DataTable dt = DABase.getDatabase().LoadDataSet(sqlString).Tables[0];
                int tongPhamTramCV=0;
                foreach (DataRow row in dt.Rows)
                {
                    if (ten == "")
                    {
                        ten = ten + row["NAME"].ToString() + " (" + row["PHAN_TRAM_THAM_GIA"].ToString() + "%)";
                        tongPhamTramCV += HelpNumber.ParseInt32(row["PHAN_TRAM_THAM_GIA"]);
                    }
                    else
                    {
                        ten = ten + "\n" + row["NAME"].ToString() + " (" + row["PHAN_TRAM_THAM_GIA"].ToString() + "%)";
                        tongPhamTramCV += HelpNumber.ParseInt32(row["PHAN_TRAM_THAM_GIA"]);
                    }
                }
                dr["NV_THAM_GIA"] = ten;
                dr["TONG_PHAN_TRAM_CV"] = tongPhamTramCV;
                //////////////////////////////////
                long tam = HelpNumber.ParseInt64(dr["PCCV_ID"]);
                DataRow[] arrRow = dss.Tables[0].Select(string.Format("PCCV_ID = {0}", HelpNumber.ParseInt64(dr["PCCV_ID"])));
                decimal tongTienDo = 0;
                foreach (DataRow row in arrRow)
                    tongTienDo += (HelpNumber.ParseInt64(row["TIEN_DO"]) * HelpNumber.ParseInt64(row["PHAN_TRAM_THAM_GIA"]));
                if (arrRow.Length > 0)
                   HelpNumber.RoundDecimal(tongTienDo /=HelpNumber.ParseInt64(arrRow[0]["TONG_PHAN_TRAM"]),2);               
                dr["TONG_TIEN_DO"] = tongTienDo.ToString()+"%";
                dr["TIEN_DO"] = tongTienDo;
            }
            return ds.Tables[0];

        }
        public static bool InsertDuAn_KH(long DA_ID, long KH_ID)
        {
            string Sql = string.Format(@"INSERT INTO {0} VALUES ({1},{2},null)", office.PLConst.bangKH_DA_CV, KH_ID, DA_ID);
            try
            {
                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(Sql);
                return db.ExecuteNonQuery(cmd) > 0;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                return false;
            }
        }
        /// <summary>
        /// Trả về mảng các ID những người thực hiện dự án
        /// </summary>
        /// <param name="strIDs"></param>
        /// <returns></returns>
        public long[] GetLongNguoiThucHien(string strIDs)
        {
            if (strIDs.Length == 0 || strIDs == null) return null;
            List<long> lstNguoiThucHien = new List<long>();
            string[] str = strIDs.Split(',');
            foreach (string item in str)
                lstNguoiThucHien.Add(HelpNumber.ParseInt64(item));
            return lstNguoiThucHien.ToArray();
        }
    }
}
