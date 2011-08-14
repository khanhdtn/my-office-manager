using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using DTO;
using System.Data;
using System.Data.Common;
using pl.office;
using ProtocolVN.Framework.Win;

namespace DAO
{
    /// <summary>
    /// Lớp hỗ trợ In ấn
    /// </summary>
    public class DAHoTroFax : DAPhieu<DOHoTroFax>
    {
        #region Khởi tạo
        public static DAHoTroFax Instance = new DAHoTroFax();
        public DAHoTroFax() : base() { }
        #endregion

        #region Cấu hình dữ liệu
        private static string KEY_FIELD_NAME = "ID";
        object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),                                
                "NGUOI_GUI_ID", new IDConverter(),
                "NGUOI_NHAN_ID",new IDConverter(), 
                "THOI_GIAN_CAP_NHAT", null,	                
                "TINH_TRANG_FAX_ID",new IDConverter(),
                "MUC_DO_UU_TIEN_ID",new IDConverter(),
                "GUI_DEN_SO",null,
                "TEN_NGUOI_NHAN",null,
                "NOI_DUNG_KEM_THEO",null
        };
        object[] FIELD_MAP_TAP_TIN = new object[] {  
                "ID", new IDConverter(),                                
                "TIEU_DE", null,
	            "TEN_FILE",null,
                "NOI_DUNG",null,                										
				"NGUOI_CAP_NHAT", new IDConverter(),
                "NGAY_CAP_NHAT", null,	
                "GHI_CHU",null              
        };
        #endregion

        #region Phương thức Overrite
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOHoTroFax LoadAll(long IDKey)
        {
            DOHoTroFax phieu = this.Load(IDKey);
            phieu.DetailDataset = FWDBService.LoadDataSet("HO_TRO_FAX", "ID", IDKey);
            return phieu;
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
            throw new NotImplementedException();
        }

        public override DOHoTroFax Load(long IDKey)
        {
            IDataReader reader = FWDBService.LoadRecord("HO_TRO_FAX", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOHoTroFax data = (DOHoTroFax)this.Builder.CreateFilledObject(typeof(DOHoTroFax), reader);
                    return data;
                }
            }
            return new DOHoTroFax();
        }

        public override bool Update(DOHoTroFax data)
        {
            bool flag = false;
            FWDBService db = HelpDB.getDBService();
            DbTransaction dbTrans = FWTransaction.BeginTrans(db);
            FWTransaction fwTrans = new FWTransaction(db, dbTrans);
            try
            {
                DataSet MainDS = FWDBService.LoadDataSet("HO_TRO_FAX", KEY_FIELD_NAME, data.ID);
                if (MainDS.Tables[0].Rows.Count == 1)
                {
                    HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP, data);
                    flag = db.UpdateDataSet(MainDS, dbTrans);
                }
                else
                {
                    DataRow row = MainDS.Tables[0].NewRow();
                    row[KEY_FIELD_NAME] = data.ID;
                    HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                    MainDS.Tables[0].Rows.Add(row);
                    flag = db.UpdateDataSet(MainDS, dbTrans);
                }
                if (flag)
                {
                    if (data.DsFile != null && data.DsFile.Tables.Count > 0)
                    {
                        DataSet DsLuuTruTapTin = data.DsFile.Copy();

                        DataRow[] rows = data.DsFile.Tables[0].Select("ID is null", "", DataViewRowState.Added);

                        List<long> taptinIDs = db.GetID("G_NGHIEP_VU", dbTrans, rows.Length);

                        int i = 0;
                        foreach (DataRow row in DsLuuTruTapTin.Tables[0].Rows)
                        {
                            if (row.RowState == DataRowState.Deleted) continue;
                            row["OBJECT_ID"] = data.ID;
                            row["TYPE_ID"] = (Int32)11;
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
                            AND OBJ.TYPE_ID=11 AND OBJ.OBJECT_ID={0}", data.ID);
                        if (fwTrans.LoadDataSet(DsLuuTruTapTinSource, sqlTaptin, "LUU_TRU_TAP_TIN") == false)
                        {
                            FWTransaction.Rollback(dbTrans);
                            return false;
                        }
                        HelpDataSet.MergeDataSet(new string[] { "ID" }, DsLuuTruTapTinSource, DsLuuTruTapTin, true);

                        DataSet DsObjectTapTinSource = new DataSet();
                        string sqlObj = string.Format(@"SELECT OBJ.*
                            FROM OBJECT_TAP_TIN OBJ WHERE OBJ.TYPE_ID=6 AND OBJ.OBJECT_ID={0}", data.ID);
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
                                DbCommand cmd = null;
                                if (r.RowState == DataRowState.Added)
                                {
                                    cmd = db.GetSQLStringCommand(string.Format(@"INSERT INTO OBJECT_TAP_TIN(TAP_TIN_ID,OBJECT_ID,TYPE_ID) VALUES({0},{1},11)", r["TAP_TIN_ID"], r["OBJECT_ID"], r["TYPE_ID"]));
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
                    if (flag) {
                        FWTransaction.Commit(dbTrans);
                        return true;
                    }
                    else{
                        FWTransaction.Rollback(dbTrans);
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
                FWTransaction.Rollback(dbTrans);
                PLException.AddException(ex);
                HelpSysLog.AddException(ex,"Hàm cập nhật dữ liệu hỗ trợ in ấn");
            }
        }
        public bool UpdateDataset(DOHoTroFax data)
        {
            DatabaseFB db = HelpDB.getDatabase();
            db.OpenConnection();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            try
            {
                if (db.UpdateDataSet(data.DetailDataset, dbTrans) == false) return false;
            }
            catch
            {
                db.RollbackTransaction(dbTrans);
            }
            db.CommitTransaction(dbTrans);
            return true;
        }
        public override bool Validate(DOHoTroFax element)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Phương thức khác
        public string HTMLtoText(string HTML)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("<[^>]*>");
            string s = reg.Replace(HTML, "");
            return s.Replace("&nbsp;", " ");
        }
        public static void DeleteLuuTruTapTin(long ID)
        {
            string sql = "delete from LUU_TRU_TAP_TIN where ID=@ID";
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand(sql);
            db.AddInParameter(cm, "@ID", DbType.Int64, ID);
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        public static bool SaveFilePrint(DOTapTin_TapTinFax do_taptininan)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand("insert into TAP_TIN_FAX(TAP_TIN_ID,HO_TRO_FAX_ID,SO_TO,YEU_CAU) values(@TAP_TIN_ID,@HO_TRO_FAX_ID,@SO_TO,@YEU_CAU)");
            db.AddInParameter(cm, "@TAP_TIN_ID", DbType.Int64, do_taptininan.ID);
            db.AddInParameter(cm, "@HO_TRO_FAX_ID", DbType.Int64, do_taptininan.HO_TRO_FAX_ID);
            db.AddInParameter(cm, "@SO_TO", DbType.Decimal, do_taptininan.SO_TO);
            db.AddInParameter(cm, "@YEU_CAU", DbType.String, do_taptininan.YEU_CAU);
            try
            {
                db.ExecuteNonQuery(cm, trans);
                db.CommitTransaction(trans);
                return true;
            }
            catch 
            {
                return false;
            }            
        }
        public static bool EditFilePrint(DOTapTin_TapTinFax do_taptininan)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand(@"update TAP_TIN_FAX ttf set ttf.so_to = @SO_TO, ttf.yeu_cau = @YEU_CAU
                                                    where (TAP_TIN_ID = @TAP_TIN_ID) and (HO_TRO_FAX_ID = @HO_TRO_FAX_ID)");
            db.AddInParameter(cm, "@TAP_TIN_ID", DbType.Int64, do_taptininan.ID);
            db.AddInParameter(cm, "@HO_TRO_FAX_ID", DbType.Int64, do_taptininan.HO_TRO_FAX_ID);
            db.AddInParameter(cm, "@SO_TO", DbType.Decimal, do_taptininan.SO_TO);
            db.AddInParameter(cm, "@YEU_CAU", DbType.String, do_taptininan.YEU_CAU);
            try
            {
                db.ExecuteNonQuery(cm, trans);
                db.CommitTransaction(trans);
                return true;
            }
            catch
            {
                return false;
            }   
        }
        public bool UpdateTapTin(DOTapTin_TapTinFax data)
        {
            bool flag = false;
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DataSet MainDS = FWDBService.LoadDataSet("LUU_TRU_TAP_TIN", "ID", data.ID);
            if (MainDS.Tables[0].Rows.Count == 1)
            {
                HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP_TAP_TIN, data);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            else
            {
                DataRow row = MainDS.Tables[0].NewRow();
                row[KEY_FIELD_NAME] = data.ID = DABase.getDatabase().GetID("G_NGHIEP_VU");
                HelpDataSet.UpdataDataRow(row, FIELD_MAP_TAP_TIN, data);
                MainDS.Tables[0].Rows.Add(row);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            if (flag == true) db.CommitTransaction(dbTrans);
            else db.RollbackTransaction(dbTrans);
            return flag;
        }
        public static void DeleteFilePrint(long id_taptin)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand("delete from TAP_TIN_FAX where TAP_TIN_ID='" + id_taptin + "'");
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        public static void RemoveAllFilesPrint(long InAn_ID)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand("delete from TAP_TIN_FAX where HO_TRO_FAX_ID='" + InAn_ID + "'");
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        #endregion
    }
}
