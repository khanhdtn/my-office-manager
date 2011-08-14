using System;
using System.Data;
using System.Data.Common;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using ProtocolVN.DanhMuc;
using System.Collections.Generic;

namespace DAO
{
    public class DAYeuCau
    {
        #region Các hàm khởi tạo 

        public static DataTable DmCMucDoUuTienDataSource()
        {
            QueryBuilder query = new QueryBuilder("select * from DM_MUC_DO_UU_TIEN where 1=1");
            return HelpDB.getDatabase().LoadDataSet(query, "DM_MUC_DO_UU_TIEN").Tables[0];
        }
       

        public static DataTable Bang_uu_tien_new()
        {
            DataTable Bang_uu_tien = new DataTable();
            Bang_uu_tien = HelpDB.getDatabase().LoadDataSet("select * from DM_MUC_DO_UU_TIEN").Tables[0].Copy();
            return Bang_uu_tien;
        }
        public static DataTable Bang_tinh_trang()
        {
            DataSet ds = new DataSet();
            DataTable Bang_tinh_trang = new DataTable();
            Bang_tinh_trang.Columns.Add("ID", typeof(System.Int64));
            Bang_tinh_trang.Columns.Add("NAME", typeof(System.String));
            Bang_tinh_trang.Rows.Add(new object[] { 1, "Mới tạo" });
            Bang_tinh_trang.Rows.Add(new object[] { 2, "Đang xử lý" });
            Bang_tinh_trang.Rows.Add(new object[] { 3, "Không hỗ trợ" });
            Bang_tinh_trang.Rows.Add(new object[] { 4, "Hoàn tất" });
            ds.Tables.Add(Bang_tinh_trang);
            return ds.Tables[0];
        }
        public static DataTable Bang_tinh_trangBug()
        {
            DataTable Bang_tinh_trang = new DataTable("DMC_TINH_TRANG");
            Bang_tinh_trang.Columns.Add("ID", typeof(System.Int64));
            Bang_tinh_trang.Columns.Add("NAME", typeof(System.String));
            Bang_tinh_trang.Rows.Add(new object[] { 1, "Mới tạo" });
            Bang_tinh_trang.Rows.Add(new object[] { 2, "Đang xử lý" });
            Bang_tinh_trang.Rows.Add(new object[] { 3, "Hoàn tất" });
            return Bang_tinh_trang;
        }
        public static String getNameNV(string idNguoiNhan)
        {
            DataTable dt = HelpDB.getDatabase().LoadDataSet("select NAME from DM_NHAN_VIEN where ID = " + idNguoiNhan).Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["NAME"].ToString();
            return "";
        }   
        public static DataTable Bang_tinh_trang_DA_new()
        {
            DataTable Bang_tinh_trang = new DataTable();
            Bang_tinh_trang.Columns.Add("ID", Type.GetType("System.Int64"));
            Bang_tinh_trang.Columns.Add("NAME", Type.GetType("System.String"));
            Bang_tinh_trang.Rows.Add(new object[] { 1, "Mới đề xuất" });
            Bang_tinh_trang.Rows.Add(new object[] { 2, "Đang lập kế hoạch" });
            Bang_tinh_trang.Rows.Add(new object[] { 3, "Đang xử lý" });
            Bang_tinh_trang.Rows.Add(new object[] { 4, "Tạm dừng" });
            Bang_tinh_trang.Rows.Add(new object[] { 5, "Hoàn thành" });
            return Bang_tinh_trang;
        }
        #endregion

        #region Các hàm cập nhập dữ liệu

        public static bool Delete(long ID)
        {
            string Sql = "Delete from YEU_CAU where ID=@ID";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(Sql);
            db.AddInParameter(cmd,"@ID",DbType.Int64,ID);
            if (db.ExecuteNonQuery(cmd) > 0) return true;
            return false;
        }

        public static bool Insert(out long YeuCauID, long Nguoi_gui_ID, DateTime Ngay_gui, string Nguoi_nhan_ID, long Tinh_trang, long Loai_yeu_cau, long Muc_uu_tien, string Chu_de, byte[] Noi_dung, DataSet dsFile)
        {
            YeuCauID = -1;
            string Sql = @"Insert into YEU_CAU (ID,NGUOI_GUI_ID,
            NGUOI_NHAN_ID,NGAY_GUI,LOAI_YEU_CAU_ID,MUC_UU_TIEN,TINH_TRANG,CHU_DE,NOI_DUNG)
            values(@ID,@NGUOI_GUI_ID,@NGUOI_NHAN_ID,@NGAY_GUI,@LOAI_YEU_CAU,@MUC_UU_TIEN,@TINH_TRANG,@CHU_DE,@NOI_DUNG)";
            FWDBService db = HelpDB.getDBService();
            DbCommand cmd = db.GetSQLStringCommand(Sql);
            DbTransaction dbTrans = FWTransaction.BeginTrans(db);
            FWTransaction fwTrans = new FWTransaction(db, dbTrans);
            try
            {
                long ID = HelpGen.DT();
                YeuCauID = ID;
                db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
                db.AddInParameter(cmd, "@NGUOI_GUI_ID", DbType.Int64, Nguoi_gui_ID);
                db.AddInParameter(cmd, "@NGUOI_NHAN_ID", DbType.String, Nguoi_nhan_ID);
                db.AddInParameter(cmd, "@NGAY_GUI", DbType.DateTime, Ngay_gui);
                db.AddInParameter(cmd, "@LOAI_YEU_CAU", DbType.Int64, Loai_yeu_cau);
                db.AddInParameter(cmd, "@MUC_UU_TIEN", DbType.Int64, Muc_uu_tien);
                db.AddInParameter(cmd, "@TINH_TRANG", DbType.Int64, Tinh_trang);
                db.AddInParameter(cmd, "@CHU_DE", DbType.String, Chu_de);
                db.AddInParameter(cmd, "@NOI_DUNG", DbType.Binary, Noi_dung);
                bool flag = false;
                if (db.ExecuteNonQuery(cmd, dbTrans) > 0)
                {
                    if (dsFile != null && dsFile.Tables.Count > 0)
                    {
                        DataSet DsLuuTruTapTin = dsFile.Copy();

                        DataRow[] rows = dsFile.Tables[0].Select("ID is null", "", DataViewRowState.Added);

                        List<long> taptinIDs = db.GetID("G_NGHIEP_VU", dbTrans, rows.Length);

                        int i = 0;
                        foreach (DataRow row in DsLuuTruTapTin.Tables[0].Rows)
                        {
                            if (row.RowState == DataRowState.Deleted) continue;
                            row["OBJECT_ID"] = ID;
                            row["TYPE_ID"] = (Int32)10;
                            row["TIEU_DE"] = Chu_de;
                            if (row["ID"] is DBNull)
                            {
                                row["TAP_TIN_ID"] = taptinIDs[i];
                                row["ID"] = row["TAP_TIN_ID"];
                                i++;
                            }
                        }
                        DataSet DsObjectTapTin = DsLuuTruTapTin.Copy();
                        DsObjectTapTin.Tables[0].TableName = "OBJECT_TAP_TIN";



                        DataSet DsLuuTruTapTinSource = new DataSet();
                        string sqlTaptin = string.Format(@"SELECT LT.*
                            FROM LUU_TRU_TAP_TIN LT
                            INNER JOIN OBJECT_TAP_TIN OBJ ON OBJ.TAP_TIN_ID=LT.ID
                            AND OBJ.TYPE_ID=10 AND OBJ.OBJECT_ID={0}", ID);
                        if (fwTrans.LoadDataSet(DsLuuTruTapTinSource, sqlTaptin, "LUU_TRU_TAP_TIN") == false)
                        {
                            FWTransaction.Rollback(dbTrans);
                            return false;
                        }
                        HelpDataSet.MergeDataSet(new string[] { "ID" }, DsLuuTruTapTinSource, DsLuuTruTapTin, true);

                        DataSet DsObjectTapTinSource = new DataSet();
                        string sqlObj = string.Format(@"SELECT OBJ.*
                            FROM OBJECT_TAP_TIN OBJ WHERE OBJ.TYPE_ID=10 AND OBJ.OBJECT_ID={0}", ID);
                        if (fwTrans.LoadDataSet(DsObjectTapTinSource, sqlObj, "OBJECT_TAP_TIN") == false)
                        {
                            FWTransaction.Rollback(dbTrans);
                            return false;
                        }
                        HelpDataSet.MergeTable(new string[] { "TAP_TIN_ID" }, DsObjectTapTinSource.Tables[0], DsObjectTapTin.Tables[0], true, true);
                        flag = db.UpdateDataSet(DsLuuTruTapTinSource, dbTrans);
                        if (flag == true)
                        {
                            foreach (DataRow r in DsObjectTapTinSource.Tables[0].Rows)
                            {
                                DbCommand cmd1 = null;
                                if (r.RowState == DataRowState.Added)
                                {
                                    cmd1 = db.GetSQLStringCommand(string.Format(@"INSERT INTO OBJECT_TAP_TIN(TAP_TIN_ID,OBJECT_ID,TYPE_ID) VALUES({0},{1},10)", r["TAP_TIN_ID"], r["OBJECT_ID"], r["TYPE_ID"]));
                                }
                                if (cmd1 != null)
                                {
                                    if (db.ExecuteNonQuery(cmd1, dbTrans) <= 0)
                                    {
                                        FWTransaction.Rollback(dbTrans);
                                        return false;
                                    }
                                }
                            }

                        }
                    }
                    if (flag)
                    {
                        FWTransaction.Commit(dbTrans);
                        return true;
                    }
                    else
                    {
                        FWTransaction.Rollback(dbTrans);
                        return false;
                    }
                }
                return false;
            }
            catch {
                FWTransaction.Rollback(dbTrans);
                return false;
            }
        }

        public static bool Update(long ID,string Nguoi_nhan_ID, long Tinh_trang, long Loai_yeu_cau, long Muc_uu_tien, string Chu_de, byte[] Noi_dung, DataSet dsFile)
        {
            string Sql = @"Update YEU_CAU
                SET NGUOI_NHAN_ID=@NGUOI_NHAN_ID,TINH_TRANG=@TINH_TRANG,LOAI_YEU_CAU_ID=@LOAI_YEU_CAU_ID,
                MUC_UU_TIEN=@MUC_UU_TIEN,CHU_DE=@CHU_DE,NOI_DUNG=@NOI_DUNG
                Where ID=@ID ";

            FWDBService db = HelpDB.getDBService();
            DbCommand cmd = db.GetSQLStringCommand(Sql);
            DbTransaction dbTrans = FWTransaction.BeginTrans(db);
            FWTransaction fwTrans = new FWTransaction(db, dbTrans);
            try
            {
                db.AddInParameter(cmd, "@NGUOI_NHAN_ID", DbType.String, Nguoi_nhan_ID);
                db.AddInParameter(cmd, "@TINH_TRANG", DbType.Int64, Tinh_trang);
                db.AddInParameter(cmd, "@LOAI_YEU_CAU_ID", DbType.Int64, Loai_yeu_cau);
                db.AddInParameter(cmd, "@MUC_UU_TIEN", DbType.Int64, Muc_uu_tien);
                db.AddInParameter(cmd, "@CHU_DE", DbType.String, Chu_de);
                db.AddInParameter(cmd, "@NOI_DUNG", DbType.Binary, Noi_dung);
                db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
                bool flag = false;
                if (db.ExecuteNonQuery(cmd, dbTrans) > 0)
                {
                    if (dsFile != null && dsFile.Tables.Count > 0)
                    {
                        DataSet DsLuuTruTapTin = dsFile.Copy();

                        DataRow[] rows = dsFile.Tables[0].Select("ID is null", "", DataViewRowState.Added);

                        List<long> taptinIDs = db.GetID("G_NGHIEP_VU", dbTrans, rows.Length);

                        int i = 0;
                        foreach (DataRow row in DsLuuTruTapTin.Tables[0].Rows)
                        {
                            if (row.RowState == DataRowState.Deleted) continue;
                            row["OBJECT_ID"] = ID;
                            row["TYPE_ID"] = (Int32)10;
                            row["TIEU_DE"] = Chu_de;
                            if (row["ID"] is DBNull)
                            {
                                row["TAP_TIN_ID"] = taptinIDs[i];
                                row["ID"] = row["TAP_TIN_ID"];
                                i++;
                            }
                        }
                        DataSet DsObjectTapTin = DsLuuTruTapTin.Copy();
                        DsObjectTapTin.Tables[0].TableName = "OBJECT_TAP_TIN";



                        DataSet DsLuuTruTapTinSource = new DataSet();
                        string sqlTaptin = string.Format(@"SELECT LT.*
                            FROM LUU_TRU_TAP_TIN LT
                            INNER JOIN OBJECT_TAP_TIN OBJ ON OBJ.TAP_TIN_ID=LT.ID
                            AND OBJ.TYPE_ID=10 AND OBJ.OBJECT_ID={0}", ID);
                        if (fwTrans.LoadDataSet(DsLuuTruTapTinSource, sqlTaptin, "LUU_TRU_TAP_TIN") == false)
                        {
                            FWTransaction.Rollback(dbTrans);
                            return false;
                        }
                        HelpDataSet.MergeDataSet(new string[] { "ID" }, DsLuuTruTapTinSource, DsLuuTruTapTin, true);

                        DataSet DsObjectTapTinSource = new DataSet();
                        string sqlObj = string.Format(@"SELECT OBJ.*
                            FROM OBJECT_TAP_TIN OBJ WHERE OBJ.TYPE_ID=10 AND OBJ.OBJECT_ID={0}", ID);
                        if (fwTrans.LoadDataSet(DsObjectTapTinSource, sqlObj, "OBJECT_TAP_TIN") == false)
                        {
                            FWTransaction.Rollback(dbTrans);
                            return false;
                        }
                        HelpDataSet.MergeTable(new string[] { "TAP_TIN_ID" }, DsObjectTapTinSource.Tables[0], DsObjectTapTin.Tables[0], true, true);
                        flag = db.UpdateDataSet(DsLuuTruTapTinSource, dbTrans);
                        if (flag == true)
                        {
                            foreach (DataRow r in DsObjectTapTinSource.Tables[0].Rows)
                            {
                                DbCommand cmd1 = null;
                                if (r.RowState == DataRowState.Added)
                                {
                                    cmd1 = db.GetSQLStringCommand(string.Format(@"INSERT INTO OBJECT_TAP_TIN(TAP_TIN_ID,OBJECT_ID,TYPE_ID) VALUES({0},{1},10)", r["TAP_TIN_ID"], r["OBJECT_ID"], r["TYPE_ID"]));
                                }
                                if (cmd1 != null)
                                {
                                    if (db.ExecuteNonQuery(cmd1, dbTrans) <= 0)
                                    {
                                        FWTransaction.Rollback(dbTrans);
                                        return false;
                                    }
                                }
                            }

                        }
                    }
                    if (flag)
                    {
                        FWTransaction.Commit(dbTrans);
                        return true;
                    }
                    else
                    {
                        FWTransaction.Rollback(dbTrans);
                        return false;
                    }
                }
                return false;
            }
            catch {
                FWTransaction.Rollback(dbTrans);
                return false;
            }
        }

        public static void UpdateTinhTrangYeuCau(long id, long tinhTrang)
        {
            DatabaseFB db = HelpDB.getDatabase();
            string SQL = string.Format(@"UPDATE YEU_CAU
                                         SET    TINH_TRANG = @TINH_TRANG
                                        WHERE   ID = {0}", id);
            DbCommand cmd = db.GetSQLStringCommand(SQL);
            db.AddInParameter(cmd, "@TINH_TRANG", DbType.Int64, tinhTrang);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }

        public static bool Delete_yc_tra_loi(long Yeu_cau_ID,long Nguoi_gui_ID,DateTime Ngay_gui)
        {
            DataSet ds = HelpDB.getDatabase().LoadDataSet("select * from YEU_CAU_TRA_LOI");
            ds.Tables[0].TableName = "YEU_CAU_TRA_LOI";
            DatabaseFB db = DABase.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            int deleted_row = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row[0].ToString() == Yeu_cau_ID.ToString() && row[1].ToString() == Nguoi_gui_ID.ToString())
                    if (row[5].ToString() == Ngay_gui.ToString())
                    {
                        ds.Tables[0].Rows[deleted_row].Delete();
                        try
                        {
                            if (db.UpdateTable(ds, "YEU_CAU_TRA_LOI", dbTrans) <= 0)
                                return false;
                        }
                        catch
                        {
                            db.RollbackTransaction(dbTrans);
                            return false;
                        }
                        db.CommitTransaction(dbTrans);
                        return true;
                    }
                deleted_row++;
            }
            return false;
            
        }
        #endregion

        #region Các hàm lấy dữ liệu 

        public static DataTable Get_Bang_yeu_cau(long ID)
        {
            DataSet ds;
            QueryBuilder query = new QueryBuilder(@"SELECT YC.*,CASE YC.TINH_TRANG
            WHEN 1 THEN 'Mới tạo'WHEN 2 THEN 'Đang xử lý' WHEN 3 THEN 'Không hỗ trợ' ELSE 'Hoàn tất' END TEN_TINH_TRANG
            ,(SELECT COUNT(*) FROM YEU_CAU_TRA_LOI YCTL WHERE YCTL.YEU_CAU_ID = YC.ID) SO_PHAN_HOI
            FROM YEU_CAU YC WHERE 1=1");
            query.add("ID", Operator.Equal, ID, DbType.Int64);
            ds = HelpDB.getDatabase().LoadDataSet(query);
            return ds.Tables[0];
        }

        public static DataTable Get_Bang_yc_tra_loi(long ID)
        {
            DataSet ds;
            QueryBuilder query = new QueryBuilder(@"SELECT NGUOI_GUI_ID, NGUOI_NHAN_ID, NOI_DUNG, NGAY_GUI
            FROM YEU_CAU_TRA_LOI WHERE 1=1");
            query.add("ID", Operator.Equal, ID, DbType.Int64);
            ds = HelpDB.getDatabase().LoadDataSet(query);
            return ds.Tables[0];
        }

        public static DataTable GetYeuCauOfYCTraLoi(long ID)
        {
            DataSet ds;
            QueryBuilder query = new QueryBuilder(@"SELECT YC.*,CASE YC.TINH_TRANG
            WHEN 1 THEN 'Mới tạo'WHEN 2 THEN 'Đang xử lý' WHEN 3 THEN 'Không hỗ trợ' ELSE 'Hoàn tất' END TEN_TINH_TRANG 
            FROM YEU_CAU YC INNER JOIN YEU_CAU_TRA_LOI YCTL ON YC.ID = YCTL.YEU_CAU_ID WHERE 1=1");
            query.add("YCTL.ID", Operator.Equal, ID, DbType.Int64);
            ds = HelpDB.getDatabase().LoadDataSet(query);
            return ds.Tables[0];
        }



        #endregion

        internal static string GetTenYeuCau(long LoaiYC_ID)
        {
            string sql = @"SELECT NAME FROM DM_LOAI_YEU_CAU WHERE ID=" + LoaiYC_ID + "";
            DataTable dt = HelpDB.getDatabase().LoadDataSet(sql).Tables[0];
            return dt.Rows[0]["NAME"].ToString();
        }
    }
}
