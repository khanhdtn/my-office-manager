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
    #region Database
    //    CREATE TABLE BUG (
    //    ID            BIGINT NOT NULL,
    //    NAME          A_STR_SHORT /* A_STR_SHORT = VARCHAR(100) */,
    //    NGUOI_GUI     BIGINT,
    //    NGAY_GUI      TIMESTAMP,
    //    NGUOI_NHAN    BIGINT,
    //    DA_ID         BIGINT,
    //    MO_TA_BUG     BLOB SUB_TYPE 0 SEGMENT SIZE 80,
    //    NGHIEP_VU_ID  BIGINT,
    //    MUC_UT        INTEGER,
    //    TINH_TRANG    INTEGER
    //    ALTER TABLE BUG ADD CONSTRAINT PK_BUG PRIMARY KEY (ID);


    ///******************************************************************************/
    ///***                              Foreign Keys                              ***/
    ///******************************************************************************/

    //ALTER TABLE BUG ADD CONSTRAINT FK_BUG_1 FOREIGN KEY (NGUOI_GUI) REFERENCES DM_NHAN_VIEN (ID);
    //ALTER TABLE BUG ADD CONSTRAINT FK_BUG_2 FOREIGN KEY (NGUOI_NHAN) REFERENCES DM_NHAN_VIEN (ID);
    //ALTER TABLE BUG ADD CONSTRAINT FK_BUG_3 FOREIGN KEY (DA_ID) REFERENCES DU_AN (ID);
    //ALTER TABLE BUG ADD CONSTRAINT FK_BUG_4 FOREIGN KEY (NGHIEP_VU_ID) REFERENCES DM_NGHIEP_VU (ID);


    ///******************************************************************************/
    ///***                               Privileges                               ***/
    ///******************************************************************************/


    ///* Privileges of users */
    //    //); 
    #endregion

    public class DABugProduct:DAPhieu<DOBugProduct>
    {
        private static string KEY_FIELD_NAME = "ID";
        object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),                                                					
				"NAME", null,
                "NGUOI_GUI",new IDConverter(),
                "NGAY_GUI",null,
                "NGUOI_NHAN",null,
                "MUC_UT",null,
                "TINH_TRANG",null,
                "MO_TA_BUG",null,
                "LOAI_VAN_DE",new IDConverter()
        };
        public static DABugProduct Instance = new DABugProduct();

        private DABugProduct() : base() { }


        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOBugProduct LoadAll(long IDKey)
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
           return FWDBService.DeleteRecord("BUG", "ID", IDKey);
        }

        public override DOBugProduct Load(long IDKey)
        {
            IDataReader reader = FWDBService.LoadRecord("BUG", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOBugProduct data = (DOBugProduct)this.Builder.CreateFilledObject(typeof(DOBugProduct), reader);
                    return data;
                }
            }
            return new DOBugProduct();
        }

        public override bool Update(DOBugProduct data)
        {
            bool flag = false;
            FWDBService db = HelpDB.getDBService();
            DbTransaction dbTrans = FWTransaction.BeginTrans(db);
            FWTransaction fwTrans = new FWTransaction(db, dbTrans);
            try
            {
                DataSet MainDS = FWDBService.LoadDataSet("BUG", KEY_FIELD_NAME, data.ID);
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
            catch {
                FWTransaction.Rollback(dbTrans);
                return false;
            }
        }

        public override bool Validate(DOBugProduct element)
        {
            throw new NotImplementedException();
        }
       
        public static DataTable loadTT(long ID)
        {
            string sql = @"select lt.*,(SELECT NAME FROM DM_NHAN_VIEN WHERE ID = lt.NGUOI_CAP_NHAT) TEN_NGUOI_CN,bg.TYPE_ID from LUU_TRU_TAP_TIN lt
                        inner join OBJECT_TAP_TIN bg on bg.tap_tin_id=lt.id
                        where ID IN ( select TAP_TIN_ID from OBJECT_TAP_TIN where OBJECT_ID='" + ID + "')";
           return HelpDB.getDatabase().LoadDataSet(sql).Tables[0];
        }
        public static void ChonDuAn(PLCombobox Input)
        {
            QueryBuilder query = null;
            query = new QueryBuilder("SELECT ID,NAME FROM DU_AN WHERE 1=1");
            query.setAscOrderBy("NAME");
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            Input._init(ds.Tables[0], "NAME", "ID");
        }
        public static DataTable Get_Bang_Van_De(long ID)
        {
            DataSet ds;
            QueryBuilder query = new QueryBuilder(@"SELECT B.*,CASE B.TINH_TRANG
            WHEN 1 THEN 'Mới tạo'WHEN 2 THEN 'Đang xử lý'ELSE 'Hoàn tất' END TEN_TINH_TRANG
            ,(SELECT COUNT(*) FROM PHAN_HOI_BUG PH WHERE PH.BUG_ID = B.ID) SO_PHAN_HOI
            FROM BUG B WHERE 1=1");
            query.add("ID", Operator.Equal, ID, DbType.Int64);
            ds = HelpDB.getDatabase().LoadDataSet(query);
            return ds.Tables[0];
        }

        public static DataTable Get_Reply_Issue(long ID) {
            DataSet ds;
            QueryBuilder query = new QueryBuilder(@"SELECT ID,BUG_ID FROM PHAN_HOI_BUG WHERE 1=1");
            query.add("ID", Operator.Equal, ID, DbType.Int64);
            ds = HelpDB.getDatabase().LoadDataSet(query);
            return ds.Tables[0];
        }

        public static void UpdateStatusIssue(long id, long tinhTrang)
        {
            DatabaseFB db = HelpDB.getDatabase();
            string SQL = string.Format(@"UPDATE BUG
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
    }
}
