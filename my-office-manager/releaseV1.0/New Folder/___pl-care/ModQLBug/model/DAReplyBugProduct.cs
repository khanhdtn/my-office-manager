using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;
using System.Data.Common;
using DTO;
using office;
using ProtocolVN.Framework.Win;

namespace DAO
{
    public class DAReplyBugProduct:DAPhieu<DOReplyBugProduct>
    {
        private static string KEY_FIELD_NAME = "ID";
        public static string TABLE_MAP = "PHAN_HOI_BUG";
        object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),                                                					
				"BUG_ID", new IDConverter(),
                "NGUOI_GUI",new IDConverter(),
                "NGUOI_NHAN",null,
                "NGAY_GUI",null,
                "NOI_DUNG",null
        };
        public static DAReplyBugProduct Instance = new DAReplyBugProduct();

        private DAReplyBugProduct() : base() { }


        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOReplyBugProduct LoadAll(long IDKey)
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
            return FWDBService.DeleteRecord(TABLE_MAP, "ID", IDKey);
        }
        public override DOReplyBugProduct Load(long IDKey)
        {
            IDataReader reader = FWDBService.LoadRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOReplyBugProduct data = (DOReplyBugProduct)this.Builder.CreateFilledObject(typeof(DOReplyBugProduct), reader);
                    return data;
                }
            }
            return new DOReplyBugProduct();
        }

        public override bool Update(DOReplyBugProduct data)
        {
            bool flag = false;
            FWDBService db = HelpDB.getDBService();
            DbTransaction dbTrans = FWTransaction.BeginTrans(db);
            FWTransaction fwTrans = new FWTransaction(db, dbTrans);
            try
            {
                DataSet MainDS = FWDBService.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, data.ID);
                if (MainDS.Tables[0].Rows.Count == 1)
                {
                    HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP, data);
                    flag = db.UpdateDataSet(MainDS, dbTrans);
                }
                else
                {
                    DataRow row = MainDS.Tables[0].NewRow();
                    row[KEY_FIELD_NAME] = data.ID = HelpDB.getDatabase().GetID(PLConst.G_NGHIEP_VU);
                    HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                    MainDS.Tables[0].Rows.Add(row);
                    flag = db.UpdateDataSet(MainDS, dbTrans);
                }
                if (flag == true)
                {
                    if (data.DSFile != null && data.DSFile.Tables.Count > 0)
                    {
                        DataSet DsLuuTruTapTin = data.DSFile.Copy();

                        DataRow[] rows = data.DSFile.Tables[0].Select("ID is null", "", DataViewRowState.Added);

                        List<long> taptinIDs = db.GetID("G_NGHIEP_VU", dbTrans, rows.Length);

                        int i = 0;
                        foreach (DataRow row in DsLuuTruTapTin.Tables[0].Rows)
                        {
                            if (row.RowState == DataRowState.Deleted) continue;
                            row["OBJECT_ID"] = data.ID;
                            row["TYPE_ID"] = (Int32)9;
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
                            AND OBJ.TYPE_ID=9 AND OBJ.OBJECT_ID={0}", data.ID);
                        if (fwTrans.LoadDataSet(DsLuuTruTapTinSource, sqlTaptin, "LUU_TRU_TAP_TIN") == false)
                        {
                            FWTransaction.Rollback(dbTrans);
                            return false;
                        }
                        HelpDataSet.MergeDataSet(new string[] { "ID" }, DsLuuTruTapTinSource, DsLuuTruTapTin, true);

                        DataSet DsObjectTapTinSource = new DataSet();
                        string sqlObj = string.Format(@"SELECT OBJ.*
                            FROM OBJECT_TAP_TIN OBJ WHERE OBJ.TYPE_ID=9 AND OBJ.OBJECT_ID={0}", data.ID);
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
                                    cmd = db.GetSQLStringCommand(string.Format(@"INSERT INTO OBJECT_TAP_TIN(TAP_TIN_ID,OBJECT_ID,TYPE_ID) VALUES({0},{1},9)", r["TAP_TIN_ID"], r["OBJECT_ID"], r["TYPE_ID"]));
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
                    if (flag == true)
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
                else
                {
                    FWTransaction.Rollback(dbTrans);
                    return false;
                }
            }
            catch
            {
                FWTransaction.Rollback(dbTrans);
                return false;
            }
        }

        public override bool Validate(DOReplyBugProduct element)
        {
            throw new NotImplementedException();
        }
        public static Int64 lay_id_bug()
        {
            Int64 kq;
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());

            DbCommand cm = db.GetSQLStringCommand("SELECT MAX(ID) FROM BUG ");
            kq = (Int64)db.ExecuteScalar(cm, dbTrans);
            return kq;
        }
        public static void Luu_TaiLieu_TapTin(long ID_TaiLieu, long ID_TapTin)
        {

            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand("insert into BUG_TAP_TIN(BUG_ID,TAP_TIN_ID,IS_PHAN_HOI_BUG) values(@BUG_ID,@TAP_TIN_ID,'N')");
            db.AddInParameter(cm, "@BUG_ID", DbType.Int64, ID_TaiLieu);
            db.AddInParameter(cm, "@TAP_TIN_ID", DbType.Int64, ID_TapTin);

            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }

        public static void xoa_tt_dk(long ma_tap_tin)
        {
            string sql1 = "delete from LUU_TRU_TAP_TIN where ID=@ID";
            string sql2 = "delete from OBJECT_TAP_TIN where TAP_TIN_ID=@ID";
            DatabaseFB db = HelpDB.getDatabase();

            DbCommand command1 = db.GetSQLStringCommand(sql1);
            db.AddInParameter(command1, "@ID", DbType.Int64, ma_tap_tin);

            db.ExecuteNonQuery(command1);
            DatabaseFB db1 = HelpDB.getDatabase();
            DbCommand command2 = db1.GetSQLStringCommand(sql2);
            db1.AddInParameter(command2, "@ID", DbType.Int64, ma_tap_tin);

            db1.ExecuteNonQuery(command2);
        }
        public static bool TThoantat(Int64 ma)
        {
            DataSet ds = HelpDB.getDatabase().LoadDataSet("select TINH_TRANG from BUG where ID=" + ma + "");
            if (HelpNumber.ParseInt64(ds.Tables[0].Rows[0][0])==3)
                return true;
            return false;
        }

        public static bool HasReplyIssue(long Id) {
            DataSet ds = HelpDB.getDatabase().LoadDataSet("SELECT COUNT(*) FROM PHAN_HOI_BUG WHERE BUG_ID=" + Id + "");
            if (HelpNumber.ParseInt64(ds.Tables[0].Rows[0][0]) > 0)
                return true;
            return false;
        }

        public static void Luu_TaiLieu_TapTin_phoi(long ID_TaiLieu, long ID_TapTin)
        {

            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand("insert into BUG_TAP_TIN(BUG_ID,TAP_TIN_ID,IS_PHAN_HOI_BUG) values(@BUG_ID,@TAP_TIN_ID,'Y')");
            db.AddInParameter(cm, "@BUG_ID", DbType.Int64, ID_TaiLieu);
            db.AddInParameter(cm, "@TAP_TIN_ID", DbType.Int64, ID_TapTin);

            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        public static string lay_ten(Int64 ma)
        {
            string ten = "";
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());

            DbCommand cm = db.GetSQLStringCommand("SELECT NAME FROM DM_NHAN_VIEN where ID='" + ma + "'");
            ten = (string)db.ExecuteScalar(cm, dbTrans);
            return ten;
        }
    }
}
