using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using ProtocolVN.Framework.Core;
using System.Data;
using System.Data.Common;
using office;
using ProtocolVN.Framework.Win;
/*
 * Author : Trần Văn Châu
 * Email : chautv@protocolvn.net
 */
namespace DAO
{
    public class DAChamCongAuto : DAPhieu<DOChamCongAuto>
    {
        #region Fields
        public static string KEY_FIELD_NAME = "ID";
        public static string TABLE_MAP = "BANG_CHAM_CONG_AUTO";
        private object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),
                "NV_ID",new IDConverter(),
                "NGAY",null,
                "SANG",null,
                "CHIEU",null,
                "THOI_GIAN_LAM_VIEC",null
        };
        public static DAChamCongAuto Instance = new DAChamCongAuto();
        private DAChamCongAuto() : base() { }
        #endregion

        #region Method override
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            throw new NotImplementedException();
        }

        public override DOChamCongAuto LoadAll(long IDKey)
        {
            DOChamCongAuto phieu = this.Load(IDKey);
            phieu.DetailDataSet = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            phieu.DetailDataSet.Tables[0].TableName = TABLE_MAP;
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
            return DatabaseFB.DeleteRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
        }

        public override DOChamCongAuto Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOChamCongAuto data = (DOChamCongAuto)this.Builder.CreateFilledObjectExt(typeof(DOChamCongAuto), reader);

                    return data;
                }
            }
            return new DOChamCongAuto();
        }

        public override bool Update(DOChamCongAuto data)
        {
            bool flag = false;
            try
            {
                if (data.DetailDataSet.Tables[0].Rows.Count > 0){
                    foreach (DataRow row in data.DetailDataSet.Tables[0].Rows){
                        flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                    }
                }
                else{
                    DataRow row = data.DetailDataSet.Tables[0].NewRow();
                    data.DetailDataSet.Tables[0].Rows.Add(row);
                    flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                }
                if (flag) {
                    try{
                        DataSet dsMain = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, data.ID);
                        HelpDataSet.MergeDataSet(new string[] { KEY_FIELD_NAME }, dsMain, data.DetailDataSet);
                        if (data.ID == 0)
                            flag = DatabaseFB.Update2DataSet(PLConst.G_NGHIEP_VU, dsMain, null, true);
                        else {
                            flag = HelpDB.getDatabase().UpdateDataSet(dsMain);
                        }
                    }
                    catch (Exception ex){
                        PLException.AddException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return flag;
        }

        public override bool Validate(DOChamCongAuto element)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Others
      
        public DOChamCongAuto Load(long IDKeyNV, DateTime date){
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(@"
                SELECT * 
                FROM BANG_CHAM_CONG_AUTO 
                WHERE NV_ID = @NV_ID AND NGAY = @NGAY AND 1=1"
            );
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, IDKeyNV);
            db.AddInParameter(cmd, "@NGAY", DbType.DateTime, date);
            IDataReader reader = db.ExecuteReader(cmd);
            using (reader)
            {
                if (reader.Read())
                {
                    DOChamCongAuto data = (DOChamCongAuto)this.Builder.CreateFilledObjectExt(typeof(DOChamCongAuto), reader);

                    return data;
                }
            }
            return new DOChamCongAuto();
        }

        public DOChamCongAuto LoadAll(long IDKeyNV, DateTime date) {
            DOChamCongAuto phieu = this.Load(IDKeyNV, date);
            DatabaseFB db = HelpDB.getDatabase();
            QueryBuilder query = new QueryBuilder(@"SELECT * FROM BANG_CHAM_CONG_AUTO WHERE 1=1");
            query.add("NV_ID", Operator.Equal, IDKeyNV, DbType.Int64);
            query.add("NGAY", Operator.Equal, date, DbType.DateTime);
            phieu.DetailDataSet = db.LoadDataSet(query);
            return phieu;
        }

        public DOChamCongAuto LoadAll(FWTransaction fwTran,long IDKeyNV, DateTime date)
        {
            DOChamCongAuto phieu = this.Load(IDKeyNV, date);
            phieu.DetailDataSet = new DataSet();
            QueryBuilder query = new QueryBuilder(@"SELECT * FROM BANG_CHAM_CONG_AUTO WHERE 1=1");
            query.add("NV_ID", Operator.Equal, IDKeyNV, DbType.Int64);
            query.add("NGAY", Operator.Equal, date, DbType.DateTime);
            fwTran.LoadDataSet(phieu.DetailDataSet, query, "BANG_CHAM_CONG_AUTO");
            return phieu;
        }

        public bool MergeDataSet(DataSet forDB, DOChamCongAuto data) {
            bool flag = false;
            try
            {
                if (data.DetailDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in data.DetailDataSet.Tables[0].Rows)
                    {
                        flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                    }
                }
                else
                {
                    DataRow row = data.DetailDataSet.Tables[0].NewRow();
                    data.ID = HelpDB.getDatabase().GetID(PLConst.G_NGHIEP_VU);
                    row[KEY_FIELD_NAME] = data.ID;
                    flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                    data.DetailDataSet.Tables[0].Rows.Add(row);
                }
                if (flag)
                {
                    try
                    {
                        HelpDataSet.MergeDataSet(new string[] { KEY_FIELD_NAME }, forDB, data.DetailDataSet);
                    }
                    catch (Exception ex)
                    {
                        PLException.AddException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return flag;
        }

        public DataSet GetListEmploy(Int32 year,Int32 month)
        {
            QueryBuilder query = new QueryBuilder(@"SELECT NV_ID FROM " + TABLE_MAP + " WHERE 1=1");
            query.addDateFromTo("NGAY", new DateTime(year, month, 1), HelpDate.GetEndOfMonth(month, year));
            query.addGroupBy("NV_ID");
            return DABase.getDatabase().LoadDataSet(query, TABLE_MAP);
        }

        #endregion

    }
}
