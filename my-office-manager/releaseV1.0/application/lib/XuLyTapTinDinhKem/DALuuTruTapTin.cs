using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common; 
using office;
using System.Data;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DTO;

namespace DAO
{
    public class DALuuTruTapTin : DAPhieu<DOLuuTruTapTin>
    {
        private static string KEY_FIELD_NAME = "ID";
        object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),                                
                "TIEU_DE", null,
	            "TEN_FILE",null,
                "NOI_DUNG",null,                										
				"NGUOI_CAP_NHAT", new IDConverter(),
                "NGAY_CAP_NHAT", null,	
                "GHI_CHU",null              
        };
        public static DALuuTruTapTin Instance = new DALuuTruTapTin();

        private DALuuTruTapTin() : base() { }
    
        public override DOLuuTruTapTin Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord("LUU_TRU_TAP_TIN", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOLuuTruTapTin data = (DOLuuTruTapTin)this.Builder.CreateFilledObject(typeof(DOLuuTruTapTin), reader);
                    return data;
                }
            }
            return new DOLuuTruTapTin();
        }
        public override DOLuuTruTapTin  LoadAll(long IDKey)
        {
            return Load(IDKey);
        }
        public DOLuuTruTapTin Load_For_Image(long IDKey)
        {
            DOLuuTruTapTin phieu = this.Load(IDKey);
            phieu.DetailDataset = DatabaseFB.LoadDataSet("LUU_TRU_TAP_TIN", "ID", IDKey);
            return phieu;
        }
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }
        public override bool  UpdateDetail(DataSet Detail, DataSet Grid)
        {
 	        throw new NotImplementedException();
        }
        public override bool  ValidateDetail(DataRow row)
        {
 	        throw new NotImplementedException();
        }
        public override bool Validate(DOLuuTruTapTin element)
        {
            throw new NotImplementedException();
        }

        public override DataTypeBuilder DefineDataTypeBuilder()
        {
            return new DataTypeBuilder(FIELD_MAP);
        }
        public override bool Update(DOLuuTruTapTin data)
        {
            bool flag = false;
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DataSet MainDS = DatabaseFB.LoadDataSet("LUU_TRU_TAP_TIN", KEY_FIELD_NAME, data.ID);
            if (MainDS.Tables[0].Rows.Count == 1)
            {
                HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP, data);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            else
            {
                DataRow row = MainDS.Tables[0].NewRow();
                row[KEY_FIELD_NAME] = data.ID = DABase.getDatabase().GetID("G_NGHIEP_VU");
                HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                MainDS.Tables[0].Rows.Add(row);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            if (flag == true) db.CommitTransaction(dbTrans);
            else db.RollbackTransaction(dbTrans);
            return flag;
        }
        public  bool Update(DOLuuTruTapTin data,long id)
        {
            bool flag = false;
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DataSet MainDS = DatabaseFB.LoadDataSet("LUU_TRU_TAP_TIN", KEY_FIELD_NAME, data.ID);
            if (MainDS.Tables[0].Rows.Count == 1)
            {
                HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP, data);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            else
            {
                DataRow row = MainDS.Tables[0].NewRow();
                row[KEY_FIELD_NAME] = data.ID = id;
                HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                MainDS.Tables[0].Rows.Add(row);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            if (flag == true) db.CommitTransaction(dbTrans);
            else db.RollbackTransaction(dbTrans);
            return flag;
        }
        public bool UpdateDataset(DOLuuTruTapTin data)
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
        public override bool Delete(long IDKey)
        {
            return DatabaseFB.DeleteRecord("LUU_TRU_TAP_TIN", KEY_FIELD_NAME, IDKey);
        }

        public bool InputObject_Taptin(long taptinID,long objectID, long typeID) {

            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cmd = db.GetSQLStringCommand(string.Format(@"INSERT INTO OBJECT_TAP_TIN VALUES(@TAP_TIN_ID,@OBJECT_ID,@TYPE_ID)"));
            db.AddInParameter(cmd, "@OBJECT_ID", DbType.Int64, objectID);
            db.AddInParameter(cmd, "@TAP_TIN_ID", DbType.Int64, taptinID);
            db.AddInParameter(cmd, "@TYPE_ID", DbType.Int32, (int)typeID);
            if (db.ExecuteNonQuery(cmd, trans) > 0)
            {
                db.CommitTransaction(trans);
                return true;
            }
            else {
                db.RollbackTransaction(trans);
                return false;
            } 
        }

        public DataSet GetTapTinByObjectID(long ObjectID, long objectType)
        {
            string sql = string.Format(@"SELECT OBJ.*,LT.*
                        from object_tap_tin OBJ
                        INNER JOIN luu_tru_tap_tin LT ON OBJ.tap_tin_id=LT.id
                        AND OBJ.type_id={0} and obj.object_id = {1}
                        where lt.ten_file is not null and lt.ten_file <> ''", objectType, ObjectID);
            return HelpDB.getDBService().LoadDataSet(sql, "LUU_TRU_TAP_TIN");
        }
    }
}
