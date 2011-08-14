using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ProtocolVN.Framework.Core;
using System.Data.Common;
using office;
using ProtocolVN.Framework.Win;

namespace DAO
{
    public class DAPhanHoi
    {
        #region Xử lý dữ liệu

            public static bool Insert(DOPhanHoi doPhanhoi)
            {
                string strSQL = "insert into YEU_CAU_TRA_LOI values(@id,@yeu_cau_id, @nguoi_gui_id, @nguoi_nhan_id, @ngay_gui, @noi_dung, @nguoi_cap_nhat_id, @ngay_cap_nhat)";

                FWDBService db = HelpDB.getDBService();
                DbCommand cmd = db.GetSQLStringCommand(strSQL);
                DbTransaction dbTrans = FWTransaction.BeginTrans(db);
                FWTransaction fwTrans = new FWTransaction(db, dbTrans);
                
                doPhanhoi.ID = HelpGen.DT();
                db.AddInParameter(cmd, "@id", DbType.Int64, doPhanhoi.ID);
                db.AddInParameter(cmd, "@yeu_cau_id", DbType.Int64, doPhanhoi.YEU_CAU_ID);

                db.AddInParameter(cmd, "@nguoi_gui_id", DbType.Int64, doPhanhoi.NGUOI_GUI_ID);

                db.AddInParameter(cmd, "@nguoi_nhan_id", DbType.String, doPhanhoi.NGUOI_NHAN_ID);

                db.AddInParameter(cmd, "@ngay_gui", DbType.DateTime, doPhanhoi.NGAY_GUI);
                db.AddInParameter(cmd, "@noi_dung", DbType.Binary, doPhanhoi.NOI_DUNG);
                db.AddInParameter(cmd, "@nguoi_cap_nhat_id", DbType.Int64, doPhanhoi.NGUOI_CAP_NHAT_ID);
                db.AddInParameter(cmd, "@ngay_cap_nhat", DbType.DateTime, doPhanhoi.NGAY_CAP_NHAT);
                try
                {
                    bool flag = false;
                    if (db.ExecuteNonQuery(cmd,dbTrans) > 0)
                    {
                        if (doPhanhoi.DSTapTinDinhKem != null && doPhanhoi.DSTapTinDinhKem.Tables.Count > 0)
                        {
                            DataSet DsLuuTruTapTin = doPhanhoi.DSTapTinDinhKem.Copy();

                            DataRow[] rows = doPhanhoi.DSTapTinDinhKem.Tables[0].Select("ID is null", "", DataViewRowState.Added);

                            List<long> taptinIDs = db.GetID("G_NGHIEP_VU", dbTrans, rows.Length);

                            int i = 0;
                            foreach (DataRow row in DsLuuTruTapTin.Tables[0].Rows)
                            {
                                if (row.RowState == DataRowState.Deleted) continue;
                                row["OBJECT_ID"] = doPhanhoi.ID;
                                row["TYPE_ID"] = (Int32)10;
                                row["TIEU_DE"] = row["TEN_FILE"];
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
                            AND OBJ.TYPE_ID=10 AND OBJ.OBJECT_ID={0}", doPhanhoi.ID);
                            if (fwTrans.LoadDataSet(DsLuuTruTapTinSource, sqlTaptin, "LUU_TRU_TAP_TIN") == false)
                            {
                                FWTransaction.Rollback(dbTrans);
                                return false;
                            }
                            HelpDataSet.MergeDataSet(new string[] { "ID" }, DsLuuTruTapTinSource, DsLuuTruTapTin, true);

                            DataSet DsObjectTapTinSource = new DataSet();
                            string sqlObj = string.Format(@"SELECT OBJ.*
                            FROM OBJECT_TAP_TIN OBJ WHERE OBJ.TYPE_ID=10 AND OBJ.OBJECT_ID={0}", doPhanhoi.ID);
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
                        else {
                            FWTransaction.Rollback(dbTrans);
                            return false;
                        }
                    }
                    return false;
                }
                catch
                {
                    FWTransaction.Rollback(dbTrans);
                    return false;   
                }
            }

            public static bool Update(DOPhanHoi doPhanhoi)
            {
                DataSet ds = HelpDB.getDatabase().LoadDataSet(string.Format(@"SELECT * 
                FROM YEU_CAU_TRA_LOI WHERE ID = {0}", doPhanhoi.ID));
                ds.Tables[0].TableName = "YEU_CAU_TRA_LOI";
                FWDBService db = HelpDB.getDBService();
                DbTransaction dbTrans = FWTransaction.BeginTrans(db);
                FWTransaction fwTrans = new FWTransaction(db, dbTrans);
                ds.Tables[0].Rows[0]["NOI_DUNG"] = doPhanhoi.NOI_DUNG;
                ds.Tables[0].Rows[0]["NGAY_GUI"] = doPhanhoi.NGAY_GUI;
                ds.Tables[0].Rows[0]["NGUOI_GUI_ID"] = doPhanhoi.NGUOI_GUI_ID;
                ds.Tables[0].Rows[0]["NGUOI_NHAN_ID"] = doPhanhoi.NGUOI_NHAN_ID;
                try
                {
                    if (db.UpdateTable(ds, "YEU_CAU_TRA_LOI", dbTrans) <= 0)
                        return false;
                    else
                    {
                        bool flag = false;
                        if (doPhanhoi.DSTapTinDinhKem != null && doPhanhoi.DSTapTinDinhKem.Tables.Count > 0)
                        {
                           //DataSet DsLuuTruTapTin = doPhanhoi.DSTapTinDinhKem.Copy();//không copy được
                            DataSet DsLuuTruTapTin = doPhanhoi.DSTapTinDinhKem;
                            DataRow[] rows = doPhanhoi.DSTapTinDinhKem.Tables[0].Select("ID is null", "", DataViewRowState.Added);
                            List<long> taptinIDs = db.GetID("G_NGHIEP_VU", dbTrans, rows.Length);
                            int i = 0;
                            foreach (DataRow row in DsLuuTruTapTin.Tables[0].Rows)
                            {
                                if (row.RowState == DataRowState.Deleted) continue;
                                row["OBJECT_ID"] = doPhanhoi.ID;
                                row["TYPE_ID"] = (Int32)10;
                                row["TIEU_DE"] = row["TEN_FILE"];
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
                            AND OBJ.TYPE_ID=10 AND OBJ.OBJECT_ID={0}", doPhanhoi.ID);
                            if (fwTrans.LoadDataSet(DsLuuTruTapTinSource, sqlTaptin, "LUU_TRU_TAP_TIN") == false)
                            {
                                FWTransaction.Rollback(dbTrans);
                                return false;
                            }
                            HelpDataSet.MergeDataSet(new string[] { "ID" }, DsLuuTruTapTinSource, DsLuuTruTapTin, true);

                            DataSet DsObjectTapTinSource = new DataSet();
                            string sqlObj = string.Format(@"SELECT OBJ.*
                            FROM OBJECT_TAP_TIN OBJ WHERE OBJ.TYPE_ID=10 AND OBJ.OBJECT_ID={0}", doPhanhoi.ID);
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
                }
                catch
                {
                    FWTransaction.Rollback(dbTrans);
                    return false;
                }
            }
            
            public static bool Delete(long _yeu_cau_id, long _nguoi_gui_id, DateTime _ngay_gui)
            {
                DataSet ds = HelpDB.getDatabase().LoadDataSet("select * from YEU_CAU_TRA_LOI");
                ds.Tables[0].TableName = "YEU_CAU_TRA_LOI";
                DatabaseFB db = HelpDB.getDatabase();
                DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
                int lc = 0;
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    if (r[0].ToString() == _yeu_cau_id.ToString() && r[1].ToString() == _nguoi_gui_id.ToString())
                        if (r[5].ToString() == _ngay_gui.ToString())
                        {
                            ds.Tables[0].Rows[lc].Delete();
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
                    lc++;
                }
                return false;
            }

            public static bool Delete(long ID)
            {
                string Sql = "Delete from YEU_CAU_TRA_LOI where ID=@ID";
                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(Sql);
                db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
                if (db.ExecuteNonQuery(cmd) > 0) return true;
                return false;
            }

            public static  DataRow getEmailNhanVien(long Id)
            {
                DataSet ds = HelpDB.getDatabase().LoadDataSet("select * from DM_NHAN_VIEN where ID=" + Id);
                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                return null;
            }

            public static byte[] getYeuCauTraLoi(long _yeu_cau_id, long _nguoi_gui_id, DateTime _ngay_gui)
            {
                DataTable dt = HelpDB.getDatabase().LoadDataSet(@"select YEU_CAU_ID, NGUOI_GUI_ID,
                                                          NGAY_GUI,NOI_DUNG
                                                        from YEU_CAU_TRA_LOI ").Tables[0];
                foreach (DataRow r in dt.Rows)
                {
                    if (r[0].ToString() == _yeu_cau_id.ToString() && r[1].ToString() == _nguoi_gui_id.ToString())
                        if(r[2].ToString() == _ngay_gui.ToString())
                            return  (byte[])r[3];
                }
                return null;
            }
        #endregion
        ///// <summary>
        ///// Kiểm quyền của currentUser, với Id là ID của Nhân Viên và\n 
        /////     2. Quyền Read
        /////     3. Quyền Insert
        /////     4. Quyền Update
        /////     5. Quyền Delete
        ///// </summary>
        //public static bool getGrantUser(long employeeId, string nameFeature, int value)
        //{ 
        //    string strSQL = "select uft.featureid, uft.userid, uft.isread_bit, uft.isinsert_bit, uft.isupdate_bit, uft.isdelete_bit " +
        //                    "from (user_cat usc inner join user_feature_rel uft on uft.userid = usc.userid) " +
        //                    "inner join feature_cat ft on uft.featureid = ft.id " +
        //                    "where usc.employee_id = " + employeeId + " " +
        //                    "and ft.name = '" + nameFeature + "'";
            
        //    DataTable dt = DABase.getDatabase().LoadDataSet(strSQL).Tables[0];
        //    if (dt.Rows.Count > 0)
        //        if (dt.Rows[0][value].ToString() == "Y")
        //            return true;
        //    return false;
        //}

            //#region Kiểm tra quyền

            ///// <summary>
            ///// Kiểm tra xem người dùng có quyền Read, Insert, Update, Delete hay không.
            /////     2. Quyền Read
            /////     3. Quyền Insert
            /////     4. Quyền Update
            /////     5. Quyền Delete
            ///// </summary>
            //public static bool checkUserId(string frmName, string grantValue, long nguoi_gui)
            //{
            //    //Người đăng nhập là người gửi tài liệu thì có toàn quyền
            //    if (FrameworkParams.currentUser.employee_id == nguoi_gui)
            //        return true;
            //    else // Người đăng nhập không phải là người gửi tài liệu
            //    {
            //        if (getGrantUser(frmName, FrameworkParams.currentUser.id, grantValue))
            //            return true;
            //    }
            //    return false;
            //}

            ///// <summary>
            ///// Kiểm quyền của currentUser, với Id là ID của currentUser và 
            /////     2. Quyền Read
            /////     3. Quyền Insert
            /////     4. Quyền Update
            /////     5. Quyền Delete
            ///// </summary>
            //public static bool getGrantUser(string frmName, long user_id, string grantValue)
            //{
            //    string strSQL = "select uft.featureid, uft.userid, uft.isread_bit, uft.isinsert_bit, uft.isupdate_bit, uft.isdelete_bit" +
            //                    " from user_feature_rel uft inner join feature_cat ft on uft.featureid = ft.id" +
            //                    " where uft.userid = " + user_id +
            //                    " and ft.name = '" + frmName + "'";

            //    DataTable dt = DABase.getDatabase().LoadDataSet(strSQL).Tables[0];
            //    if (dt.Rows.Count > 0)
            //        if (dt.Rows[0][grantValue].ToString() == "Y")
            //            return true;
            //    return false;
            //}

            //#endregion
    }
}
