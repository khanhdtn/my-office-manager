using System;
using ProtocolVN.Framework.Core;
using System.Data;
using System.Data.Common;
using DTO;
using System.Collections.Generic;
using ProtocolVN.Framework.Win;


namespace DAO
{
    class DABaiViet : DAPhieu<DOBaiViet>
    {
        private static string KEY_FIELD_NAME = "ID";
        object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),                                
                "CHU_DE", null,
	            "NOI_DUNG",null,
                "SO_LAN_XEM",null,
                "SO_LAN_TRA_LOI",null,
				"NGAY_GUI",null,						
				"NGUOI_GUI", new IDConverter(),
                "ID_NHOM_DIEN_DAN",new IDConverter(),
                "ID_CHUYEN_MUC",new IDConverter(),
                "ID_BAI_VIET_PARENT",new IDConverter()               
        };
        public static DABaiViet Instance = new DABaiViet();

        private DABaiViet() : base() { }

        #region Các hàm kế thừa
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOBaiViet Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord("BAI_VIET", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOBaiViet data = (DOBaiViet)this.Builder.CreateFilledObject(typeof(DOBaiViet), reader);
                    return data;
                }
            }
            return new DOBaiViet();
        }
        public override DOBaiViet LoadAll(long IDKey)
        {
          
            DOBaiViet doBV = Load(IDKey);
            doBV.DSTapTinDinhKem = DALuuTruTapTin.Instance.GetTapTinByObjectID(IDKey, 2);
            return doBV;
        }

        public override bool UpdateDetail(System.Data.DataSet Detail, System.Data.DataSet Grid)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateDetail(System.Data.DataRow row)
        {
            throw new NotImplementedException();
        }

        public override DataTypeBuilder DefineDataTypeBuilder()
        {
            return new DataTypeBuilder(FIELD_MAP);
        }

        public override bool Delete(long IDKey)
        {
            return DatabaseFB.DeleteRecord("BAI_VIET", KEY_FIELD_NAME, IDKey);
        }



        public override bool Update(DOBaiViet data)
        {

            DbTransaction dbTrans = null;
            FWDBService db = null;
            FWTransaction fwTrans = null;
            try
            {
                db = HelpDB.getDBService();
                dbTrans = FWTransaction.BeginTrans(db);
                fwTrans = new FWTransaction(db, dbTrans);
                bool flag = false;
                DataSet MainDS = DatabaseFB.LoadDataSet("BAI_VIET", KEY_FIELD_NAME, data.ID);
                if (MainDS.Tables[0].Rows.Count == 1)
                {
                    HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP, data);
                    flag = db.UpdateDataSet(MainDS, dbTrans);
                }
                else
                {
                    DataRow row = MainDS.Tables[0].NewRow();
                    row[KEY_FIELD_NAME] = data.ID = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
                    HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                    MainDS.Tables[0].Rows.Add(row);
                    flag = db.UpdateDataSet(MainDS, dbTrans);
                }
                if (flag == true)
                {
                    if (data.DSTapTinDinhKem != null && data.DSTapTinDinhKem.Tables.Count > 0)
                    {
                        DataSet DsLuuTruTapTin = data.DSTapTinDinhKem.Copy();
                       
                        DataRow[] rows = data.DSTapTinDinhKem.Tables[0].Select("ID is null", "", DataViewRowState.Added);

                        List<long> taptinIDs = db.GetID("G_NGHIEP_VU", dbTrans, rows.Length);

                        int i = 0;
                        foreach (DataRow row in DsLuuTruTapTin.Tables[0].Rows)
                        {
                            if (row.RowState == DataRowState.Deleted) continue;
                            row["OBJECT_ID"] = data.ID;
                            row["TYPE_ID"] = (Int32)2;
                            row["TIEU_DE"] = data.CHU_DE;
                            if (row["ID"] is DBNull)
                            {
                                row["TAP_TIN_ID"] = taptinIDs[i];
                                row["ID"] = row["TAP_TIN_ID"];
                                i++;
                            }
                        }
                        DataSet DsObjectTapTin =DsLuuTruTapTin.Copy();
                        DsObjectTapTin.Tables[0].TableName = "OBJECT_TAP_TIN";
                    


                        DataSet DsLuuTruTapTinSource = new DataSet();
                        string sqlTaptin = string.Format(@"SELECT LT.*
                        from luu_tru_tap_tin LT
                        INNER JOIN object_tap_tin OBJ ON OBJ.tap_tin_id=LT.id
                        AND OBJ.type_id=2 and obj.object_id={0}", data.ID);
                        if (fwTrans.LoadDataSet(DsLuuTruTapTinSource, sqlTaptin, "LUU_TRU_TAP_TIN") == false)
                        {
                            FWTransaction.Rollback(dbTrans);
                            return false;
                        }
                        HelpDataSet.MergeDataSet(new string[] { "ID" }, DsLuuTruTapTinSource, DsLuuTruTapTin, true);

                        DataSet DsObjectTapTinSource = new DataSet();
                        string sqlObj = string.Format(@"SELECT OBJ.*
                        from object_tap_tin OBJ where OBJ.type_id=2 and obj.object_id={0}", data.ID);
                        if (fwTrans.LoadDataSet(DsObjectTapTinSource, sqlObj, "OBJECT_TAP_TIN") == false)
                        {
                            FWTransaction.Rollback(dbTrans);
                            return false;
                        }
                        HelpDataSet.MergeTable(new string[] { "TAP_TIN_ID" }, DsObjectTapTinSource.Tables[0], DsObjectTapTin.Tables[0], true, true);
                        flag = db.UpdateDataSet(DsLuuTruTapTinSource, dbTrans);
                        if (flag == true)
                        {
                            //flag = db.UpdateDataSet(DsObjectTapTinSource, dbTrans);// bị lỗi ở đây
                            foreach (DataRow r in DsObjectTapTinSource.Tables[0].Rows)
                            {
                                DbCommand cmd = null;
                                if (r.RowState == DataRowState.Added)
                                {
                                    cmd = db.GetSQLStringCommand(string.Format(@"INSERT INTO OBJECT_TAP_TIN(TAP_TIN_ID,OBJECT_ID,TYPE_ID) VALUES({0},{1},{2})", r["TAP_TIN_ID"], r["OBJECT_ID"], r["TYPE_ID"]));
                                }
                                if (cmd != null)
                                {
                                    if (db.ExecuteNonQuery(cmd, dbTrans) <= 0)
                                    {
                                        FWTransaction.Rollback(dbTrans);
                                        return false;
                                    }
                                }
                            }

                        }
                    }

                }
                if (flag == true)
                {
                    FWTransaction.Commit(dbTrans);
                    data.DSTapTinDinhKem = DALuuTruTapTin.Instance.GetTapTinByObjectID(data.ID, 2);
                }
                else
                {
                    FWTransaction.Rollback(dbTrans);
                }
                return flag;
            }
            catch
            {
                FWTransaction.Rollback(dbTrans);
                return false;

            }
        }

        public override bool Validate(DOBaiViet element)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Các hàm chức năng khác
        public bool INSERT_BAI_VIET_TAP_TIN(long BAI_VIET_ID, long TAP_TIN_ID)
        {
            string sql = string.Format(@"INSERT INTO OBJECT_TAP_TIN VALUES({0},{1},2)", TAP_TIN_ID, BAI_VIET_ID);
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            try
            {
                return db.ExecuteNonQuery(cmd) > 0;
            }
            catch (Exception ex) { HelpMsgBox.ShowConfirmMessage(ex.ToString()); return false; }
        }
        public void Update_TANG_SO_LAN_TRA_LOI(long BAI_VIET_GOC_ID)
        {

            string sql = "Update BAI_VIET Set SO_LAN_TRA_LOI = SO_LAN_TRA_LOI +1 where ID=@ID";

            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, BAI_VIET_GOC_ID);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch
            {
                HelpMsgBox.ShowConfirmMessage("Cập nhật số lần trả lời không thành công!");
            }
        }
        public void Update_GIAM_SO_LAN_TRA_LOI(long BAI_VIET_GOC_ID)
        {

            string sql = "Update BAI_VIET Set SO_LAN_TRA_LOI = SO_LAN_TRA_LOI -1 where ID=@ID";

            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, BAI_VIET_GOC_ID);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch
            {
                HelpMsgBox.ShowConfirmMessage("Cập nhật số lần trả lời không thành công!");
            }
        }
        public void Update_TANG_SO_LAN_XEM(long BAI_VIET_GOC_ID)
        {
            string sql = "Update BAI_VIET Set SO_LAN_XEM = SO_LAN_XEM + 1 where ID=@ID";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, BAI_VIET_GOC_ID);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch
            {
                HelpMsgBox.ShowConfirmMessage("Cập nhật số lần xem không thành công!");
            }
        }
        public DOLuuTruTapTin get_TapTin(long Tin_tuc_ID)
        {
            string sql = string.Empty;
            sql = string.Format(@"SELECT TAP_TIN_ID,NOI_DUNG,TEN_FILE 
            FROM OBJECT_TAP_TIN T INNER JOIN LUU_TRU_TAP_TIN L ON T.TAP_TIN_ID=L.ID 
            WHERE T.OBJECT_ID={0} AND TYPE_ID = 2", Tin_tuc_ID);
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "TIN_TUC_TAP_TIN");
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            return DATinTuc.Instance.Get_doLuuTru_TT(ds);
        }
        public DOBaiViet get_BaiViet(DataRow row)
        {
            DOBaiViet doBaiViet = new DOBaiViet();
            doBaiViet.ID = HelpNumber.ParseInt64(row["ID"]);
            doBaiViet.CHU_DE = row["CHU_DE"].ToString();
            doBaiViet.NOI_DUNG = (Byte[])row["NOI_DUNG"];
            doBaiViet.SO_LAN_XEM = HelpNumber.ParseInt64(row["SO_LAN_XEM"]);
            doBaiViet.SO_LAN_TRA_LOI = HelpNumber.ParseInt64(row["SO_LAN_TRA_LOI"]);
            doBaiViet.NGAY_GUI = System.Convert.ToDateTime(row["NGAY_GUI"].ToString());
            doBaiViet.NGUOI_GUI = HelpNumber.ParseInt64(row["NGUOI_GUI"]);
            doBaiViet.ID_NHOM_DIEN_DAN = HelpNumber.ParseInt64(row["ID_NHOM_DIEN_DAN"]);
            doBaiViet.ID_BAI_VIET_PARENT = HelpNumber.ParseInt64(row["ID_BAI_VIET_PARENT"]);
            return doBaiViet;
        }
        public DataRow get_BaiViet(long ID)
        {
            string sql = "Select * from Bai_viet where id=" + ID;
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "Bai_viet");
            return ds.Tables[0].Rows[0];
        }
        public DataRow Get_Updated_Row(long ID)
        {
            string sql = "Select * from Bai_viet where id=" + ID;
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "Bai_Viet");
            if (ds.Tables[0].Rows.Count == 0) return null;
            return ds.Tables[0].Rows[0];
        }
        public bool Da_tra_loi(long ID)
        {
            string sql = "Select count(*) from Bai_viet where id_bai_viet_parent=" + ID;
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "Bai_viet");
            if (HelpNumber.ParseInt64(ds.Tables[0].Rows[0][0]) > 0) return true;
            return false;
        }
        public DataTable GetAllBaiVietByBaiVietGoc(long BaiVietGocID)
        {
            string sql = @"SELECT B.*
                                FROM BAI_VIET B                                 
                                WHERE B.ID=@ID OR B.ID_BAI_VIET_PARENT=@ID ORDER BY NGAY_GUI ASC";

            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, BaiVietGocID);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "BAI_VIET");
            return ds.Tables[0];
        }
        public  DataTable GetAllFileByBaiVietGoc(long BaiVietGocID)
        {
            string sqlFile = string.Format(@"SELECT obj.*, lt.*
                        from OBJECT_TAP_TIN obj
                        inner JOIN LUU_TRU_TAP_TIN LT ON LT.ID=obj.TAP_TIN_ID
                        WHERE obj.type_id=2 and
                        obj.object_id in 
                    (select bv.id from bai_viet bv where bv.id={0} or bv.id_bai_viet_parent={0})", BaiVietGocID);
            DataSet dsFile = HelpDB.getDBService().LoadDataSet(sqlFile);
            return dsFile.Tables[0];

        }       
        // <summary>
        /// Convert HTML to Text
        /// </summary>
        /// <param name="HTML"></param>
        /// <returns></returns>
        public string HTMLtoText(string HTML)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("<[^>]*>");
            string s = reg.Replace(HTML, "");
            return s.Replace("&nbsp;", " ");
        }
        #endregion
    }
}
